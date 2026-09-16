import { API_BASE_URL } from "../../config";
export default function setup(env) {
  const {
    document,
    window,
    fetch,
    alert,
    confirm,
    setTimeout,
    setInterval,
    clearTimeout,
    clearInterval,
    Chart,
    XLSX,
    Fuse,
    $,
    bootstrap,
    FullCalendar,
    Prism,
    axios
  } = env;
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let courses = [];
  let fuse = null;
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  function removeVietnameseTones(str) {
    return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D").toLowerCase();
  }
  function createFuseIndex(data) {
    return new Fuse(data, {
      keys: ["name", "courseCode", "semesterName", "facultyCode", "startDate", "endDate", "defenseDate"],
      includeScore: true,
      threshold: 0.4,
      ignoreLocation: true,
      useExtendedSearch: true,
      getFn: (obj, path) => removeVietnameseTones(Fuse.config.getFn(obj, path))
    });
  }
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_ADMIN") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      document.getElementById("adminName").textContent = user.fullName || "Admin HUTECH";
      document.getElementById("adminEmail").textContent = user.email || "admin@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function loadSemesters() {
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses/semesters`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải kỳ học: ${response.status}`);
      const semesters = await response.json();
      ["addSemester", "editSemester"].forEach(id => {
        const select = document.getElementById(id);
        semesters.forEach(s => {
          const option = document.createElement("option");
          option.value = s.name;
          option.textContent = s.name;
          select.appendChild(option);
        });
      });
    } catch (error) {
      console.error("Lỗi khi tải kỳ học:", error);
    }
  }
  async function loadFaculties() {
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses/faculties`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải khoa: ${response.status}`);
      const faculties = await response.json();
      ["addFaculty", "editFaculty", "facultyFilter"].forEach(id => {
        const select = document.getElementById(id);
        faculties.forEach(f => {
          const option = document.createElement("option");
          option.value = f.code;
          option.textContent = f.name;
          select.appendChild(option);
        });
      });
    } catch (error) {
      console.error("Lỗi khi tải khoa:", error);
    }
  }
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách học phần: ${response.status}`);
      courses = await response.json();
      fuse = createFuseIndex(courses);
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi tải học phần:", error);
    }
  }
  function getFilteredCourses() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const facultyFilter = document.getElementById("facultyFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : courses;
    if (facultyFilter) {
      filtered = filtered.filter(course => course.facultyCode === facultyFilter);
    }
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn] ? sortColumn.includes("Date") ? new Date(a[sortColumn]) : a[sortColumn] : "";
        let valueB = b[sortColumn] ? sortColumn.includes("Date") ? new Date(b[sortColumn]) : b[sortColumn] : "";
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredCourses = getFilteredCourses();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredCourses.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((course, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${course.courseCode}</td>
                            <td>${course.name}</td>
                            <td>${course.semesterName}</td>
                            <td>${course.facultyCode}</td>
                            <td>${course.startDate ? new Date(course.startDate).toLocaleDateString() : ""}</td>
                            <td>${course.endDate ? new Date(course.endDate).toLocaleDateString() : ""}</td>
                            <td>${course.defenseDate ? new Date(course.defenseDate).toLocaleDateString() : ""}</td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editCourse(course.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteCourse(course.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredCourses.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    let paginationHTML = `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`;
    if (currentPage > 2) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`;
    if (currentPage > 3) paginationHTML += `<li>...</li>`;
    if (currentPage > 1) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li><a href="#" class="active">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li>...</li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function showAddCourseModal() {
    const modal = new bootstrap.Modal(document.getElementById("addCourseModal"));
    modal.show();
  }
  async function saveAddCourse() {
    const form = document.getElementById("addCourseForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const newCourse = {
      name: document.getElementById("addCourseName").value,
      semesterName: document.getElementById("addSemester").value,
      facultyCode: document.getElementById("addFaculty").value,
      startDate: document.getElementById("addStartDate").value ? new Date(document.getElementById("addStartDate").value).toISOString() : null,
      endDate: document.getElementById("addEndDate").value ? new Date(document.getElementById("addEndDate").value).toISOString() : null,
      defenseDate: document.getElementById("addDefenseDate").value ? new Date(document.getElementById("addDefenseDate").value).toISOString() : null
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(newCourse)
      });
      if (!response.ok) throw new Error("Thêm học phần thất bại.");
      alert("Thêm học phần thành công!");
      bootstrap.Modal.getInstance(document.getElementById("addCourseModal")).hide();
      await loadCourses();
    } catch (error) {
      alert("Lỗi: " + error.message);
    }
  }
  async function editCourse(id) {
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses/${id}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải học phần: ${response.status}`);
      const course = await response.json();
      document.getElementById("editCourseId").value = course.id;
      document.getElementById("editCourseCode").value = course.courseCode;
      document.getElementById("editCourseName").value = course.name;
      document.getElementById("editSemester").value = course.semesterName;
      document.getElementById("editFaculty").value = course.facultyCode;
      document.getElementById("editStartDate").value = course.startDate ? new Date(course.startDate).toISOString().split("T")[0] : "";
      document.getElementById("editEndDate").value = course.endDate ? new Date(course.endDate).toISOString().split("T")[0] : "";
      document.getElementById("editDefenseDate").value = course.defenseDate ? new Date(course.defenseDate).toISOString().split("T")[0] : "";
      const modal = new bootstrap.Modal(document.getElementById("editCourseModal"));
      modal.show();
    } catch (error) {
      console.error("Error:", error);
      alert("Không tải được thông tin học phần: " + error.message);
    }
  }
  async function saveEditCourse() {
    const form = document.getElementById("editCourseForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const id = document.getElementById("editCourseId").value;
    const updatedCourse = {
      id: parseInt(id),
      name: document.getElementById("editCourseName").value,
      semesterName: document.getElementById("editSemester").value,
      facultyCode: document.getElementById("editFaculty").value,
      startDate: document.getElementById("editStartDate").value ? new Date(document.getElementById("editStartDate").value).toISOString() : null,
      endDate: document.getElementById("editEndDate").value ? new Date(document.getElementById("editEndDate").value).toISOString() : null,
      defenseDate: document.getElementById("editDefenseDate").value ? new Date(document.getElementById("editDefenseDate").value).toISOString() : null
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedCourse)
      });
      if (!response.ok) throw new Error("Cập nhật học phần thất bại.");
      alert("Cập nhật học phần thành công!");
      bootstrap.Modal.getInstance(document.getElementById("editCourseModal")).hide();
      await loadCourses();
    } catch (error) {
      alert("Lỗi: " + error.message);
    }
  }
  async function deleteCourse(id) {
    if (!confirm("Bạn có chắc muốn xóa học phần này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminCourses/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Xóa học phần thất bại.");
      alert("Xóa học phần thành công!");
      await loadCourses();
    } catch (error) {
      alert("Lỗi: " + error.message);
    }
  }
  function exportCourses() {
    const filteredCourses = getFilteredCourses();
    const worksheetData = [["Danh sách học phần - Hệ thống Sinh viên HUTECH"], [], ["#", "Mã học phần", "Tên học phần", "Kỳ học", "Khoa", "Ngày bắt đầu", "Ngày kết thúc", "Ngày bảo vệ"]];
    filteredCourses.forEach((course, index) => {
      worksheetData.push([index + 1, course.courseCode, course.name, course.semesterName, course.facultyCode, course.startDate ? new Date(course.startDate).toLocaleDateString() : "", course.endDate ? new Date(course.endDate).toLocaleDateString() : "", course.defenseDate ? new Date(course.defenseDate).toLocaleDateString() : ""]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachMonHoc");
    XLSX.writeFile(workbook, "danh_sach_mon_hoc.xlsx");
  }
  async function importCourses() {
    const input = document.createElement("input");
    input.type = "file";
    input.accept = ".xlsx, .xls";
    input.onchange = async e => {
      const file = e.target.files[0];
      const data = await file.arrayBuffer();
      const workbook = XLSX.read(data, {
        type: "array"
      });
      const sheetName = workbook.SheetNames[0];
      const worksheet = workbook.Sheets[sheetName];
      const jsonData = XLSX.utils.sheet_to_json(worksheet);
      const courses = jsonData.map(row => ({
        name: row["Tên học phần"],
        semesterName: row["Kỳ học"],
        facultyCode: row["Khoa"]
      }));
      try {
        const response = await fetch(`${API_URL}/api/AdminCourses/import`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(courses)
        });
        if (!response.ok) throw new Error("Nhập Excel thất bại.");
        const result = await response.json();
        alert(`Nhập thành công: ${result.successCount} học phần, Thất bại: ${result.failedCount}`);
        await loadCourses();
      } catch (error) {
        alert("Lỗi: " + error.message);
      }
    };
    input.click();
  }
  async function logout() {
    try {
      const response = await fetch(`${API_URL}/api/Auth/logout`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      const text = await response.text();
      if (response.ok) {
        const data = text ? JSON.parse(text) : {};
        alert(data.message || "Đã đăng xuất thành công.");
      } else {
        const data = text ? JSON.parse(text) : {};
        alert(`Đăng xuất thất bại: ${data.message || response.statusText}`);
      }
    } catch (error) {
      alert("Đăng xuất bị lỗi: " + error.message);
      console.error("Đăng xuất bị lỗi:", error);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("/font-end/admin/admin_notifications.html");
  });
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(event.target) && event.target.id !== "profileBtn") {
      dropdown.style.display = "none";
    }
  });
  env.listen(document.getElementById("toggleFullscreen"), "click", () => {
    if (!document.fullscreenElement) document.documentElement.requestFullscreen();else document.exitFullscreen();
  });
  env.listen(document.getElementById("toggleFullscreenBtn"), "click", () => {
    if (!document.fullscreenElement) document.documentElement.requestFullscreen();else document.exitFullscreen();
  });
  env.listen(document.getElementById("toggleTheme"), "click", () => {
    document.body.classList.toggle("dark-mode");
    localStorage.setItem("theme", document.body.classList.contains("dark-mode") ? "dark" : "light");
  });
  if (localStorage.getItem("theme") === "dark") document.body.classList.add("dark-mode");
  function toggleDropdown(event) {
    event.preventDefault();
    const dropdown = event.target.closest(".dropdown-menu-wrapper").querySelector(".dropdown-content");
    dropdown.style.display = dropdown.style.display === "none" ? "block" : "none";
  }
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let content = document.querySelector(".content");
    let icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    if (sidebar.classList.contains("collapsed")) {
      icon.classList.replace("bi-list", "bi-layout-sidebar-inset");
    } else {
      icon.classList.replace("bi-layout-sidebar-inset", "bi-list");
    }
  }
  env.ready(async () => {
    try {
      await loadUserProfile();
      await loadSemesters();
      await loadFaculties();
      await loadCourses();
    } catch (error) {
      console.error("Error loading courses:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      env.navigate("/font-end/login/login.html");
    }
  });
  return {
    event0: function (event) {
      toggleDropdown(event);
    },
    event1: function (event) {
      toggleSidebar();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      logout();
    },
    event4: function (event) {
      showAddCourseModal();
    },
    event5: function (event) {
      importCourses();
    },
    event6: function (event) {
      exportCourses();
    },
    event7: function (event) {
      filterTable();
    },
    event8: function (event) {
      filterTable();
    },
    event9: function (event) {
      sortTable("courseCode");
    },
    event10: function (event) {
      sortTable("name");
    },
    event11: function (event) {
      sortTable("semesterName");
    },
    event12: function (event) {
      sortTable("facultyCode");
    },
    event13: function (event) {
      sortTable("startDate");
    },
    event14: function (event) {
      sortTable("endDate");
    },
    event15: function (event) {
      sortTable("defenseDate");
    },
    event16: function (event) {
      saveAddCourse();
    },
    event17: function (event) {
      saveEditCourse();
    }
  };
}

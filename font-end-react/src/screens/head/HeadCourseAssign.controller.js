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
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let courses = [];
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let currentHead = null;
  let currentIdHead = null;
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/head_notifications.html"));
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(event.target) && event.target.id !== "profileBtn") dropdown.style.display = "none";
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
  function toggleSidebar() {
    const sidebar = document.querySelector(".sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list", !sidebar.classList.contains("collapsed"));
    icon.classList.toggle("bi-layout-sidebar-inset", sidebar.classList.contains("collapsed"));
  }
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_HEAD") throw new Error("Không có quyền Trưởng bộ môn.");
      currentIdHead = user.id;
      currentHead = user.fullName;
      document.getElementById("headName").textContent = currentHead || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function fetchCourses() {
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment?headLecturer=${encodeURIComponent(currentIdHead)}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) {
        if (response.status === 401) throw new Error("Phiên đăng nhập hết hạn.");
        throw new Error(`Không thể lấy danh sách học phần: ${response.statusText}`);
      }
      const data = await response.json();
      courses = data.courses || [];
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi lấy học phần:", error);
      alert(`Lỗi: ${error.message}`);
      courses = [];
      displayTable(currentPage);
    }
  }
  function getFilteredCourses() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    return courses.filter(course => course.courseId?.toString().toLowerCase().includes(searchText) || course.name?.toLowerCase().includes(searchText) || course.semester?.toLowerCase().includes(searchText) || course.facultyCode?.toLowerCase().includes(searchText)).sort((a, b) => {
      if (!sortColumn) return 0;
      let valueA = sortColumn === "studentCount" || sortColumn === "assignedCount" || sortColumn === "assignedNullCount" ? Number(a[sortColumn] || 0) : (a[sortColumn] || "").toString().toLowerCase();
      let valueB = sortColumn === "studentCount" || sortColumn === "assignedCount" || sortColumn === "assignedNullCount" ? Number(b[sortColumn] || 0) : (b[sortColumn] || "").toString().toLowerCase();
      return sortDirection === "asc" ? valueA.localeCompare(valueB) : valueB.localeCompare(valueA);
    });
  }
  function displayTable(page) {
    const filteredCourses = getFilteredCourses();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredCourses.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không tìm thấy học phần.</td></tr>");
    } else {
      paginatedData.forEach((course, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${course.courseId || "N/A"}</td>
                            <td>${course.name || "N/A"}</td>
                            <td>${course.semester || "N/A"}</td>
                            <td>${course.facultyCode || "N/A"}</td>
                            <td>${course.studentCount || 0}</td>
                            <td>${course.assignedCount || 0}</td>
                            <td>${course.assignedNullCount || 0}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewAssignments(String(course.courseId || ""), String(course.semester || ""), String(course.facultyCode || ""));
        })}">
                                    <i class="bi bi-eye"></i> Xem sinh viên
                                </button>
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
    pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`);
    if (currentPage > 2) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`);
    if (currentPage > 3) pagination.innerHTML += env.html(`<li class="page-item disabled"><span class="page-link">...</span></li>`);
    if (currentPage > 1) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`);
    pagination.innerHTML += env.html(`<li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>`);
    if (currentPage < totalPages) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`);
    if (currentPage < totalPages - 2) pagination.innerHTML += env.html(`<li class="page-item disabled"><span class="page-link">...</span></li>`);
    if (currentPage < totalPages - 1) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`);
    pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`);
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
  function viewAssignments(courseId, semester, facultyCode) {
    if (!courseId || !semester || !facultyCode) {
      alert("Thông tin học phần không đầy đủ!");
      return;
    }
    env.navigate(`/font-end/head/head_assign.html?courseId=${courseId}`);
  }
  function exportCourses() {
    const filteredCourses = getFilteredCourses();
    const worksheetData = [["Danh sách học phần cần phân công GVHD - Hệ thống Sinh viên HUTECH"], ["Trưởng bộ môn: " + (document.getElementById("headName").textContent || "Head HUTECH")], [], ["#", "Mã học phần", "Tên học phần", "Học kỳ", "Mã khoa", "Số sinh viên", "Số SV đã phân công", "Số SV chưa phân công"]];
    filteredCourses.forEach((course, index) => {
      worksheetData.push([index + 1, course.courseId || "N/A", course.name || "N/A", course.semester || "N/A", course.facultyCode || "N/A", course.studentCount || 0, course.assignedCount || 0, course.assignedNullCount || 0]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "MonHocPhanCong");
    XLSX.writeFile(workbook, `mon_hoc_can_phan_cong_${currentHead || "head"}.xlsx`);
  }
  async function logout() {
    try {
      const token = localStorage.getItem("token");
      if (!token) throw new Error("Chưa đăng nhập.");
      const response = await fetch(`${API_URL}/api/Auth/logout`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${response.statusText}`);
      alert("Đăng xuất thành công!");
    } catch (error) {
      alert(`Lỗi đăng xuất: ${error.message}`);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await fetchCourses();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      filterTable();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      exportCourses();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      sortTable("courseId");
    },
    event6: function (event) {
      sortTable("name");
    },
    event7: function (event) {
      sortTable("semester");
    },
    event8: function (event) {
      sortTable("facultyCode");
    },
    event9: function (event) {
      sortTable("studentCount");
    },
    event10: function (event) {
      sortTable("assignedCount");
    },
    event11: function (event) {
      sortTable("assignedNullCount");
    }
  };
}

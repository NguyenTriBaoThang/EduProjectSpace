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
  let projects = [];
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
      keys: [{
        name: "courseName",
        weight: 0.3
      }, {
        name: "title",
        weight: 0.4
      }, {
        name: "lecturerName",
        weight: 0.3
      }],
      includeScore: true,
      threshold: 0.4,
      ignoreLocation: true,
      useExtendedSearch: true,
      getFn: (obj, path) => {
        const value = Fuse.config.getFn(obj, path);
        return removeVietnameseTones(value);
      }
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
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/AdminProjects/courses`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách học phần: ${response.status}`);
      const courses = await response.json();
      const courseFilter = document.getElementById("courseFilter");
      courses.forEach(course => {
        const option = document.createElement("option");
        option.value = course.name;
        option.textContent = course.name;
        courseFilter.appendChild(option);
      });
    } catch (error) {
      console.error("Lỗi khi tải học phần:", error);
      alert(`Không thể tải danh sách học phần: ${error.message}`);
    }
  }
  async function loadProjects() {
    try {
      const response = await fetch(`${API_URL}/api/AdminProjects`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách đề tài: ${response.status}`);
      projects = await response.json();
      fuse = createFuseIndex(projects);
      displayTable(currentPage);
    } catch (error) {
      throw new Error(`Lỗi API: ${error.message}`);
    }
  }
  function getFilteredProjects() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const statusFilter = document.getElementById("statusFilter").value;
    const courseFilter = document.getElementById("courseFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : projects;
    if (statusFilter) {
      filtered = filtered.filter(project => project.status === statusFilter);
    }
    if (courseFilter) {
      filtered = filtered.filter(project => project.courseName === courseFilter);
    }
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn] || "";
        let valueB = b[sortColumn] || "";
        if (sortColumn === "lecturerName") {
          valueA = a.lecturerName || "";
          valueB = b.lecturerName || "";
        }
        valueA = valueA.toString().toLowerCase();
        valueB = valueB.toString().toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredProjects = getFilteredProjects();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredProjects.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy đề tài nào.</td></tr>");
    } else {
      paginatedData.forEach((project, index) => {
        const statusText = project.status === "PENDING" ? "Chưa duyệt" : project.status === "APPROVED" ? "Đã duyệt" : "Hoàn thành";
        const statusClass = project.status === "PENDING" ? "bg-warning" : project.status === "APPROVED" ? "bg-info" : "bg-success";
        const students = project.group?.students?.map(s => s.fullName).join(", ") || "Chưa có sinh viên";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${project.courseName}</td>
                            <td>${project.title}</td>
                            <td>${students}</td>
                            <td>${project.lecturerName || "Chưa có giảng viên"}</td>
                            <td><span class="badge ${statusClass}">${statusText}</span></td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editProject(project.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteProject(project.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredProjects.length);
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
  async function editProject(id) {
    try {
      const response = await fetch(`${API_URL}/api/AdminProjects/${id}`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải thông tin đề tài: ${response.status}`);
      const project = await response.json();
      document.getElementById("editProjectId").value = project.id;
      document.getElementById("editProjectCourseId").value = project.courseId;
      document.getElementById("editProjectCourse").value = project.courseName;
      document.getElementById("editProjectTitle").value = project.title;
      document.getElementById("editProjectDescription").value = project.description || "";
      document.getElementById("editProjectStatus").value = project.status;
      const modal = new bootstrap.Modal(document.getElementById("editProjectModal"));
      modal.show();
    } catch (error) {
      console.error("Error:", error);
      alert("Không tải được thông tin đề tài: " + error.message);
    }
  }
  async function saveEditProject() {
    const form = document.getElementById("editProjectForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const id = parseInt(document.getElementById("editProjectId").value);
    const updatedProject = {
      id: id,
      title: document.getElementById("editProjectTitle").value,
      description: document.getElementById("editProjectDescription").value,
      courseId: parseInt(document.getElementById("editProjectCourseId").value),
      status: document.getElementById("editProjectStatus").value
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminProjects/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedProject)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không cập nhật được đề tài.");
      }
      alert("Đã cập nhật thông tin đề tài: " + updatedProject.title);
      bootstrap.Modal.getInstance(document.getElementById("editProjectModal")).hide();
      await loadProjects();
    } catch (error) {
      console.error("Error:", error);
      alert("Không cập nhật được đề tài: " + error.message);
    }
  }
  async function deleteProject(id) {
    if (!confirm("Bạn có chắc muốn xóa đề tài này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminProjects/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không xóa được đề tài.");
      alert("Đã xóa đề tài!");
      await loadProjects();
    } catch (error) {
      console.error("Error:", error);
      alert("Không xóa được đề tài: " + error.message);
    }
  }
  function exportProjects() {
    const filteredProjects = getFilteredProjects();
    const worksheetData = [["Danh sách đề tài - Hệ thống Sinh viên HUTECH"], [], ["#", "Tên học phần", "Tên đề tài", "Sinh viên", "Giảng viên", "Trạng thái"]];
    filteredProjects.forEach((project, index) => {
      const students = project.group?.students?.map(s => s.fullName).join(", ") || "Chưa có sinh viên";
      worksheetData.push([index + 1, project.courseName, project.title, students, project.lecturerName || "Chưa có giảng viên", project.status === "PENDING" ? "Chưa duyệt" : project.status === "APPROVED" ? "Đã duyệt" : "Hoàn thành"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachDeTai");
    XLSX.writeFile(workbook, "danh_sach_de_tai.xlsx");
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
      await loadCourses();
      await loadProjects();
    } catch (error) {
      console.error("Error loading projects:", error);
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
      exportProjects();
    },
    event5: function (event) {
      filterTable();
    },
    event6: function (event) {
      filterTable();
    },
    event7: function (event) {
      filterTable();
    },
    event8: function (event) {
      sortTable("courseName");
    },
    event9: function (event) {
      sortTable("title");
    },
    event10: function (event) {
      sortTable("lecturerName");
    },
    event11: function (event) {
      sortTable("status");
    },
    event12: function (event) {
      saveEditProject();
    }
  };
}

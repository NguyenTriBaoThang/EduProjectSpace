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
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let allProjects = [];

  // Lấy courseId từ URL
  // Lấy courseId từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const courseId = urlParams.get("courseId");
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("lecturer_notifications.html"));
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("project-id");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "project-id";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("project-id");
    if (!dropdown.contains(event.target) && event.target.id !== "profileBtn") dropdown.style.display = "none";
  });
  env.listen(document.getElementById("toggleFullscreen"), "click", toggleFullscreen);
  env.listen(document.getElementById("toggleFullscreenBtn"), "click", toggleFullscreen);
  env.listen(document.getElementById("toggleTheme"), "click", () => {
    document.body.classList.toggle("dark-mode");
    localStorage.setItem("theme", document.body.classList.contains("dark-mode") ? "dark" : "light");
  });
  if (localStorage.getItem("theme") === "dark") document.body.classList.add("dark-mode");
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let content = document.querySelector(".content");
    let icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }
  function toggleFullscreen() {
    if (!document.fullscreenElement) document.documentElement.requestFullscreen();else document.exitFullscreen();
  }

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }
  async function fetchProjects() {
    const url = courseId ? `${API_URL}/api/LecturerCourses/projects?courseId=${encodeURIComponent(courseId)}` : `${API_URL}/api/LecturerCourses/projects`;
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (!response.ok) throw new Error("Lỗi tải danh sách đồ án");
    return await response.json();
  }
  function filterTable() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    const filteredProjects = allProjects.filter(project => (project.projectId.toLowerCase().includes(searchText) || project.name.toLowerCase().includes(searchText) || project.groupName.toLowerCase().includes(searchText)) && (statusFilter === "" || project.status === statusFilter));
    displayTable(filteredProjects);
  }
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    const filteredProjects = allProjects.sort((a, b) => {
      let valueA = column === "students" ? a.students.map(s => s.fullName).join(", ").toLowerCase() : a[column].toLowerCase();
      let valueB = column === "students" ? b.students.map(s => s.fullName).join(", ").toLowerCase() : b[column].toLowerCase();
      return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
    });
    displayTable();
  }
  function displayTable(data = allProjects) {
    const start = (currentPage - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = data.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy đồ án nào.</td></tr>");
    } else {
      paginatedData.forEach((project, index) => {
        const statusClass = project.status === "COMPLETED" ? "bg-success" : project.status === "APPROVED" ? "bg-info" : "bg-warning";
        const statusName = project.status === "COMPLETED" ? "Hoàn thành" : project.status === "APPROVED" ? "Đã duyệt" : "Chưa duyệt";
        const studentNames = project.students.map(s => s.fullName).join(", ");
        let actionButtons = `
                        <button class="btn btn-sm btn-primary me-1" data-page-click="${env.bind(function (event) {
          env.navigate("lecturer_project_progress.html?projectId=" + String(project.projectId));
        })}">
                            <i class="bi bi-eye"></i> Tiến độ
                        </button>
                    `;
        if (project.status !== "APPROVED" && project.status !== "COMPLETED") {
          actionButtons += `
                            <button class="btn btn-sm btn-success" data-page-click="${env.bind(function (event) {
            env.navigate("lecturer_approval.html?projectId=" + String(project.projectId));
          })}">Duyệt</button>
                        `;
        }
        if (project.status !== "COMPLETED") {
          actionButtons += `
                            <button class="btn btn-sm btn-info" data-page-click="${env.bind(function (event) {
            env.navigate("/font-end/lecturer/lecturer_project_review.html?projectId=" + String(project.projectId) + "&courseId=" + String(courseId));
          })}">Chấm điểm</button>
                        `;
        }
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${project.projectId}</td>
                            <td>${project.name}</td>
                            <td>${project.groupName}</td>
                            <td>${studentNames}</td>
                            <td><span class="badge ${statusClass}">${statusName}</span></td>
                            <td>${actionButtons}</td>
                        </tr>
                    `);
      });
    }
    setupPagination(data.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    let paginationHTML = `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`;
    if (currentPage > 2) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`;
    if (currentPage > 3) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage > 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }
  function changePage(page) {
    currentPage = page;
    filterTable();
  }
  async function exportProjects() {
    const url = courseId ? `${API_URL}/api/LecturerCourses/projects?courseId=${encodeURIComponent(courseId)}` : `${API_URL}/api/LecturerCourses/projects`;
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    const projects = await response.json();
    const worksheetData = [["Danh sách đồ án - Hệ thống Sinh viên học viên", "HUTECH"], ["Giảng viên: " + (JSON.parse(localStorage.getItem("user")).fullName || ", Huy Cường")], [], ["#", "Mã đồ án", "Tên đồ án", "Tên nhóm", "Sinh viên", "Trạng thái"]];
    projects.forEach((project, index) => {
      const studentNames = project.students.map(s => s.fullName).join(", ");
      worksheetData.push([index + 1, project.projectId, project.name, project.groupName, studentNames, project.status]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachDoAn");
    XLSX.writeFile(workbook, "danh_sach_do_an.xlsx");
  }

  // Ghi chú: Đăng xuất
  // Ghi chú: Đăng xuất
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
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      allProjects = await fetchProjects();
      displayTable();
    } catch (error) {
      console.error("Lỗi khi tải bảng điều khiển:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      logout();
    }
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      exportProjects();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      sortTable("projectId");
    },
    event6: function (event) {
      sortTable("name");
    },
    event7: function (event) {
      sortTable("groupName");
    },
    event8: function (event) {
      sortTable("students");
    },
    event9: function (event) {
      sortTable("status");
    }
  };
}

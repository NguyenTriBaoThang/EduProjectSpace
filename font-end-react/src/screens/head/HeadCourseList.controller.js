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
  let courseList = [];
  let headLecturerId = null;

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/lecturer_notifications.html"));
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
      const user = JSON.parse(localStorage.getItem("user") || "{}");
      if (!user || user.roleName !== "ROLE_HEAD" || !user.id) {
        throw new Error("Không có quyền Trưởng bộ môn hoặc chưa đăng nhập.");
      }
      headLecturerId = user.id;
      document.getElementById("headName").textContent = user.fullName || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      showToast(`Vui lòng đăng nhập lại: ${error.message}`, true);
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria/courses?headLecturer=${headLecturerId}`, {
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách học phần: ${await response.text()}`);
      courseList = await response.json();
      displayTable(currentPage);
    } catch (error) {
      showToast(`Lỗi tải danh sách học phần: ${error.message}`, true);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"4\" class=\"text-center\">Không thể tải danh sách học phần.</td></tr>");
    }
  }
  function displayTable(page) {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const filtered = courseList.filter(c => c.name.toLowerCase().includes(searchText) || c.courseCode.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn].toLowerCase();
        let valueB = b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginated = filtered.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html(paginated.length === 0 ? "<tr><td colspan=\"4\" class=\"text-center\">Không tìm thấy học phần.</td></tr>" : paginated.map((c, i) => `
                    <tr>
                        <td>${start + i + 1}</td>
                        <td>${c.name}</td>
                        <td>${c.courseCode}</td>
                        <td>
                            <a href="/font-end/head/head_grade_criteria.html?courseId=${c.id}&headLecturer=${headLecturerId}" class="btn btn-sm btn-primary">
                                <i class="bi bi-list-ul"></i> Quản lý tiêu chí
                            </a>
                        </td>
                    </tr>
                `).join(""));
    setupPagination(filtered.length);
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
  function showToast(message, isError = false) {
    const toast = new bootstrap.Toast(document.getElementById("toast"));
    const toastBody = document.querySelector(".toast-body");
    toastBody.textContent = message;
    toastBody.className = `toast-body ${isError ? "bg-danger text-white" : "bg-success text-white"}`;
    toast.show();
  }
  async function logout() {
    try {
      const response = await fetch(`${API_URL}/api/Auth/logout`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${await response.text()}`);
      showToast("Đăng xuất thành công!");
      localStorage.removeItem("user");
      localStorage.removeItem("token");
      env.navigate("/font-end/login/login.html", true);
    } catch (error) {
      showToast(`Lỗi đăng xuất: ${error.message}`, true);
    }
  }
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await loadCourses();
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
      sortTable("name");
    },
    event4: function (event) {
      sortTable("courseCode");
    }
  };
}

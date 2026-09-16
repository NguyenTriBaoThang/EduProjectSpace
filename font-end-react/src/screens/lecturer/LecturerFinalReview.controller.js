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
  // Cấu hình API
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let token = localStorage.getItem("token");
  let fullNameLecturer = null;
  let projects = [];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const courseId = urlParams.get("courseId");

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/lecturer/lecturer_notifications.html"));
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

  // Toggle Sidebar
  // Toggle Sidebar
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let content = document.querySelector(".content");
    let icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      }
      fullNameLecturer = user.fullName;
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Tải danh sách đồ án từ API
  // Tải danh sách đồ án từ API
  async function loadProjects() {
    if (!courseId) {
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không tìm thấy học phần.</td></tr>");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerReview/courses/${encodeURIComponent(courseId)}/projects`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Không thể tải danh sách đồ án: ${response.statusText}`);
      projects = await response.json();
      displayTable(currentPage);
    } catch (e) {
      console.error("Lỗi khi tải đồ án:", e);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không thể tải dữ liệu.</td></tr>");
    }
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredProjects() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = projects.filter(project => {
      const matchesSearch = (project.projectId || "").toLowerCase().includes(searchText) || (project.name || "").toLowerCase().includes(searchText) || (project.groupName || "").toLowerCase().includes(searchText) || (project.groupLeader || "").toLowerCase().includes(searchText);
      const matchesStatus = statusFilter === "" || (statusFilter === "Hoàn tất" && project.isFullyReviewed) || (statusFilter === "Chưa hoàn tất" && !project.isFullyReviewed);
      return matchesSearch && matchesStatus;
    });
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn] || "";
        let valueB = b[sortColumn] || "";
        if (sortColumn === "memberCount") {
          valueA = parseInt(valueA) || 0;
          valueB = parseInt(valueB) || 0;
        } else if (sortColumn === "isFullyReviewed") {
          valueA = valueA ? 1 : 0;
          valueB = valueB ? 1 : 0;
        } else {
          valueA = valueA.toLowerCase();
          valueB = valueB.toLowerCase();
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Hiển thị bảng
  // Hiển thị bảng
  function displayTable(page) {
    const filteredProjects = getFilteredProjects();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredProjects.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (!courseId) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Vui lòng chọn học phần từ danh sách.</td></tr>");
    } else if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không tìm thấy đồ án nào.</td></tr>");
    } else {
      paginatedData.forEach((project, index) => {
        const reviewStatusClass = project.isFullyReviewed ? "bg-success" : "bg-danger";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${project.projectId || "N/A"}</td>
                            <td>${project.name || "N/A"}</td>
                            <td>${project.groupName || "N/A"}</td>
                            <td>${project.groupLeader || "N/A"}</td>
                            <td>${project.memberCount || 0}</td>
                            <td><span class="badge ${reviewStatusClass}">${project.isFullyReviewed ? "Hoàn tất" : "Chưa hoàn tất"}</span></td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          env.navigate("/font-end/lecturer/lecturer_project_review.html?projectId=" + String(project.projectId) + "&courseId=" + String(courseId));
        })}">
                                <i class="bi bi-star"></i> Đánh giá
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredProjects.length);
  }

  // Setup pagination
  // Setup pagination
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
    if (currentPage > 3) paginationHTML += `<li class="page-item disabled"><a class="page-link">...</a></li>`;
    if (currentPage > 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li class="page-item active"><a class="page-link">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li class="page-item disabled"><a class="page-link">...</a></li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }

  // Change page
  // Change page
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }

  // Sort table
  // Sort table
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }

  // Filter table
  // Filter table
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Export projects to Excel
  // Export projects to Excel
  function exportProjects() {
    const filteredProjects = getFilteredProjects();
    const worksheetData = [["Danh sách đồ án cần đánh giá - Hệ thống Sinh viên HUTECH"], [`Giảng viên hướng dẫn: ${fullNameLecturer || ""}`], [`học phần: ${courseId || "N/A"}`], [], ["#", "Mã đồ án", "Tên đồ án", "Tên nhóm phát triển", "Nhóm trưởng", "Số thành viên", "Trạng thái", "Đã đánh giá"]];
    filteredProjects.forEach((project, index) => {
      worksheetData.push([index + 1, project.projectId || "", project.name || "", project.groupName || "", project.groupLeader || "", project.memberCount || "", project.isFullyReviewed ? "Hoàn thành" : "Chưa hoàn tất"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DoAnDanhGia");
    XLSX.writeFile(workbook, `do-an_${courseId || "unknown"}.xlsx`);
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
          "Authorization": `Bearer ${token}`
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
    env.navigate("/login/login.html", true);
  }

  // Initialize
  // Initialize
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadProjects();
    } catch (error) {
      console.error("Lỗi khi tải bảng:", error);
      alert(`Không thể tải dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
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
      sortTable("groupLeader");
    },
    event9: function (event) {
      sortTable("memberCount");
    },
    event10: function (event) {
      sortTable("isFullyReviewed");
    }
  };
}

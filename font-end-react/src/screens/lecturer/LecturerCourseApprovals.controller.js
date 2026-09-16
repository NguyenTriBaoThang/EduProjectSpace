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
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";

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
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerProjectApproval`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to load courses");
      courses = await response.json();
      displayTable(currentPage);
    } catch (error) {
      alert("Không thể tải danh sách học phần.");
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Lỗi tải dữ liệu.</td></tr>");
    }
  }
  function getFilteredCourses() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    let filtered = courses.filter(course => course.courseId.toLowerCase().includes(searchText) || course.name.toLowerCase().includes(searchText) || course.semester.toLowerCase().includes(searchText) || course.facultyCode.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "proposalCount" ? a.proposalCount : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "proposalCount" ? b.proposalCount : b[sortColumn].toLowerCase();
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
    tableBody.innerHTML = env.html(paginatedData.length ? paginatedData.map((course, index) => `
                <tr>
                    <td>${start + index + 1}</td>
                    <td>${course.courseId}</td>
                    <td>${course.name}</td>
                    <td>${course.semester}</td>
                    <td>${course.facultyCode}</td>
                    <td>${course.proposalCount}</td>
                    <td>
                        <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
      viewProposals(String(course.courseId));
    })}">
                            <i class="bi bi-eye"></i> Xem đề tài
                        </button>
                    </td>
                </tr>
            `).join("") : "<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    setupPagination(filteredCourses.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html(totalPages <= 1 ? "" : `
                <li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>
                ${currentPage > 2 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>` : ""}
                ${currentPage > 3 ? `<li class="page-item disabled"><span class="page-link">...</span></li>` : ""}
                ${currentPage > 1 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>` : ""}
                <li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>
                ${currentPage < totalPages ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>` : ""}
                ${currentPage < totalPages - 2 ? `<li class="page-item disabled"><span class="page-link">...</span></li>` : ""}
                ${currentPage < totalPages - 1 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>` : ""}
                <li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>
            `);
  }
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }
  function sortTable(column) {
    sortColumn = sortColumn === column ? sortColumn : column;
    sortDirection = sortColumn === column && sortDirection === "asc" ? "desc" : "asc";
    displayTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function viewProposals(courseId) {
    env.navigate(`/font-end/lecturer/lecturer_approval.html?courseId=${courseId}`);
  }
  function exportCourses() {
    const filteredCourses = getFilteredCourses();
    const data = [["Danh sách học phần cần duyệt đề tài - HUTECH"], ["Giảng viên: " + document.getElementById("userName").textContent], [], ["#", "Mã học phần", "Tên học phần", "Học kỳ", "Mã lớp", "Số đề tài"]].concat(filteredCourses.map((course, index) => [index + 1, course.courseId, course.name, course.semester, course.facultyCode, course.proposalCount]));
    const worksheet = XLSX.utils.aoa_to_sheet(data);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "MonHocDuyetDeTai");
    XLSX.writeFile(workbook, "mon_hoc_can_duyet.xlsx");
  }
  function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("/font-end/lecturer/lecturer_notifications.html");
  });
  env.listen(document.getElementById("profileBtn"), "click", e => {
    e.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", e => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(e.target) && e.target.id !== "profileBtn") {
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

  // Đăng xuất tài khoản
  // Đăng xuất tài khoản
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
      const data = await response.json();
      if (response.ok) {
        alert(data.message);
      } else {
        alert(`Đăng xuất thất bại: ${data.message || response.statusText}`);
      }
    } catch (error) {
      alert("Đăng xuất bị lỗi: " + error.message);
    }
    localStorage.removeItem("user");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadCourses();
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
      exportCourses();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      sortTable("courseId");
    },
    event5: function (event) {
      sortTable("name");
    },
    event6: function (event) {
      sortTable("semester");
    },
    event7: function (event) {
      sortTable("facultyCode");
    },
    event8: function (event) {
      sortTable("proposalCount");
    }
  };
}

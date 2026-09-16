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
  const token = localStorage.getItem("token");
  let courses = [];
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => {
    toggleSidebar();
  });
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("notifications_list.html");
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
  async function loadCourses() {
    if (!token) {
      alert("Vui lòng đăng nhập lại.");
      env.navigate("../LOGIN/login.html");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/StudentCourse`, {
        headers: {
          "Authorization": `Bearer ${token}`,
          "Accept": "*/*",
          "Content-Type": "application/json"
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi ${response.status}`);
      const data = await response.json();
      courses = data.items || [];
      displayTable(1, data.totalCount); // Reset về trang 1 khi tải lại
    } catch (error) {
      console.error("Lỗi khi tải danh sách học phần:", error);
      alert(`Không tải được dữ liệu: ${error.message}`);
    }
  }
  function getFilteredCourses() {
    let filtered = [...courses];
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    filtered = filtered.filter(course => course.name.toLowerCase().includes(searchText) && (statusFilter === "" || course.status === statusFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "progress" ? a[sortColumn] : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "progress" ? b[sortColumn] : b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page, totalCount) {
    const filteredCourses = getFilteredCourses();
    const start = (page - 1) * 5;
    const end = start + 5;
    const paginatedData = filteredCourses.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((course, index) => {
        let statusClass = "";
        if (course.status === "Đã chấm điểm") statusClass = "bg-primary";
        if (course.status === "Đã nộp") statusClass = "bg-success";
        if (course.status === "Chưa hoàn thành") statusClass = "bg-warning";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${course.name}</td>
                            <td>${course.instructor}</td>
                            <td><div class="status ${statusClass}">${course.status}</div></td>
                            <td><div class="progress"><div class="progress-bar ${statusClass}" style="width: ${course.progress}%">${course.progress}%</div></div></td>
                            <td><a href="student_submissions_week.html?id=${course.id}" class="btn btn-sm btn-info">📄 Xem</a></td>
                        </tr>
                    `);
      });
    }
    setupPagination(totalCount);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / 5);
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
    displayTable(currentPage, courses.length); // Sử dụng tổng số bản ghi từ API
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage, courses.length);
  }
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage, courses.length);
  }
  function exportCourses() {
    const worksheetData = [["Danh sách học phần"], [], ["#", "học phần", "Giảng viên hướng dẫn", "Trạng thái", "Tiến độ"]];
    courses.forEach((course, index) => {
      worksheetData.push([index + 1, course.name, course.instructor, course.status, course.progress + "%"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachMonHoc");
    XLSX.writeFile(workbook, "danh_sach_mon_hoc.xlsx");
  }
  env.listen(document, "DOMContentLoaded", () => {
    loadCourses();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportCourses();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      sortTable("name");
    },
    event5: function (event) {
      sortTable("status");
    }
  };
}

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
  let lecturers = [];
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let currentHead = null;
  let currentIdHead = null;

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/lecturer_notifications.html"));
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
    if (sidebar.classList.contains("collapsed")) {
      icon.classList.replace("bi-list", "bi-layout-sidebar-inset");
    } else {
      icon.classList.replace("bi-layout-sidebar-inset", "bi-list");
    }
  }

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_HEAD") {
        throw new Error("Không có quyền Trưởng bộ môn hoặc chưa đăng nhập.");
      }
      currentIdHead = user.id;
      currentHead = user.fullName;
      document.getElementById("headName").textContent = currentHead || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }

  // Load danh sách giảng viên từ API
  // Load danh sách giảng viên từ API
  async function loadLecturers() {
    try {
      const response = await fetch(`${API_URL}/api/HeadLecturer?headLecturer=${currentIdHead}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi: ${await response.text()}`);
      lecturers = await response.json();
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi tải danh sách giảng viên:", error);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không thể tải danh sách giảng viên.</td></tr>");
    }
  }

  // Hiển thị bảng
  // Hiển thị bảng
  function displayTable(page) {
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    let paginatedData = [...lecturers];

    // Sắp xếp nếu có sortColumn
    if (sortColumn) {
      paginatedData.sort((a, b) => {
        let valueA = sortColumn === "studentCount" || sortColumn === "groupCount" ? a[sortColumn] : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "studentCount" || sortColumn === "groupCount" ? b[sortColumn] : b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    paginatedData = paginatedData.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy giảng viên nào.</td></tr>");
    } else {
      paginatedData.forEach((lecturerData, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${lecturerData.lecturer}</td>
                            <td>${lecturerData.courseCode}</td>
                            <td>${lecturerData.semesterName}</td>
                            <td>${lecturerData.facultyCode}</td>
                            <td>${lecturerData.studentCount}</td>
                            <td>${lecturerData.groupCount}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewDetails(String(lecturerData.lecturer), String(lecturerData.courseCode), String(lecturerData.semesterName), String(lecturerData.facultyCode));
        })}">
                                    <i class="bi bi-eye"></i> Xem chi tiết xem
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(lecturers.length);
  }

  // Thiết lập phân trang
  // Thiết lập phân trang
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const paginationItems = document.getElementById("pagination");
    paginationItems.innerHTML = env.html("");
    if (totalItems <= 1) return;
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
    document.getElementById("pagination").innerHTML = env.html(paginationHTML);
  }

  // Chuyển trang
  // Chuyển trang
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }

  // Sắp xếp bảng
  // Sắp xếp bảng
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }

  // Lọc theo search input
  // Lọc theo search input
  function filterTable() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    lecturers = lecturers.filter(l => l.lecturer.toLowerCase().includes(searchText) || l.courseCode.toLowerCase().includes(searchText) || l.semesterName.toLowerCase().includes(searchText) || l.facultyCode.toLowerCase().includes(searchText));
    currentPage = 1;
    displayTable(currentPage);
  }

  // Điều hướng đến trang chi tiết
  // Điều hướng đến trang chi tiết
  function viewDetails(lecturer, courseCode, semesterName, facultyCode) {
    env.navigate(`/font-end/head/head_lecturer_details.html?lecturer=${encodeURIComponent(lecturer)}&courseId=${courseCode}&semester=${semesterName}&facultyCode=${facultyCode}`);
  }

  // Xuất danh sách giảng viên sang Excel
  // Xuất danh sách giảng viên sang Excel
  function exportLecturers() {
    const worksheetData = [["Danh sách giảng viên hướng dẫn - Hệ thống Sinh viên HUTECH"], [`Trưởng bộ môn: ${currentHead}`], [], ["#", "Tên GVHD", "Mã học phần", "Học kỳ", "Mã khoa", "Số sinh viên", "Số nhóm"]];
    lecturers.forEach((lecturerData, index) => {
      worksheetData.push([index + 1, lecturerData.lecturer, lecturerData.courseCode, lecturerData.semesterName, lecturerData.facultyCode, lecturerData.studentCount, lecturerData.groupCount]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachGVHD");
    XLSX.writeFile(workbook, "danh_sach_gvhd.xlsx");
  }

  // Đăng xuất
  // Đăng xuất
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
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${await response.text()}`);
      alert("Đã đăng xuất thành công!");
    } catch (error) {
      alert("Lỗi khi đăng xuất: " + error.message);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html");
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await loadLecturers();
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
      exportLecturers();
    },
    event4: function (event) {
      sortTable("lecturer");
    },
    event5: function (event) {
      sortTable("courseCode");
    },
    event6: function (event) {
      sortTable("semesterName");
    },
    event7: function (event) {
      sortTable("facultyCode");
    },
    event8: function (event) {
      sortTable("studentCount");
    },
    event9: function (event) {
      sortTable("groupCount");
    }
  };
}

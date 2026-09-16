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
  const API_URL = window.EDU_CONFIG.apiBaseUrl + ""; // URL API backend
  // URL API backend
  let token = localStorage.getItem("token"); // Token xác thực
  // Token xác thực
  let fullNameLecturer = null; // Tên giảng viên
  // Tên giảng viên
  let courses = []; // Danh sách học phần từ API
  // Danh sách học phần từ API
  const itemsPerPage = 5; // Số mục mỗi trang
  // Số mục mỗi trang
  let currentPage = 1; // Trang hiện tại
  // Trang hiện tại
  let sortColumn = null; // Cột đang sắp xếp
  // Cột đang sắp xếp
  let sortDirection = "asc"; // Hướng sắp xếp

  // Navbar Functions
  // Hướng sắp xếp

  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("lecturer_notifications.html"));
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(event.target) && event.target.id === "profileBtn") {
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
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
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

  // Tải danh sách học phần từ API
  // Tải danh sách học phần từ API
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerReview`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể tải danh sách học phần");
      courses = await response.json();
      displayTable(currentPage);
    } catch (e) {
      console.error("Lỗi khi tải học phần:", e);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không thể tải dữ liệu.</td></tr>");
    }
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredCourses() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    let filtered = courses.filter(course => course.courseId.toLowerCase().includes(searchText) || course.name.toLowerCase().includes(searchText) || course.semester.toLowerCase().includes(searchText) || course.facultyCode.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "projectCount" || sortColumn === "reviewedCount") {
          valueA = parseInt(valueA);
          valueB = parseInt(valueB);
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
    const filteredCourses = getFilteredCourses();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredCourses.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((course, index) => {
        const progress = (course.reviewedCount / course.projectCount * 100).toFixed(1);
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${course.courseId}</td>
                            <td>${course.name}</td>
                            <td>${course.semester}</td>
                            <td>${course.facultyCode}</td>
                            <td>${course.projectCount}</td>
                            <td>${course.reviewedCount} (${progress}%)</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewReviews(String(course.courseId));
        })}">
                                    <i class="bi bi-eye"></i> Xem đồ án
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredCourses.length);
  }

  // Thiết lập phân trang
  // Thiết lập phân trang
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

  // Lọc bảng
  // Lọc bảng
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Điều hướng đến trang đánh giá
  // Điều hướng đến trang đánh giá
  function viewReviews(courseId) {
    env.navigate(`lecturer_final_review.html?courseId=${courseId}`);
  }

  // Xuất danh sách học phần sang Excel
  // Xuất danh sách học phần sang Excel
  function exportCourses() {
    const filteredCourses = getFilteredCourses();
    const worksheetData = [["Danh sách học phần cần đánh giá tổng quan - Hệ thống Sinh viên HUTECH"], [`Giảng viên hướng dẫn: ${fullNameLecturer}`], [], ["#", "Mã học phần", "Tên học phần", "Học kỳ", "Mã khoa", "Số đồ án", "Số đồ án đã đánh giá"]];
    filteredCourses.forEach((course, index) => {
      const progress = (course.reviewedCount / course.projectCount * 100).toFixed(1);
      worksheetData.push([index + 1, course.courseId, course.name, course.semester, course.facultyCode, course.projectCount, `${course.reviewedCount} (${progress}%)`]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "MonHocDanhGia");
    XLSX.writeFile(workbook, "mon_hoc_can_danh_gia.xlsx");
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

  // Khởi chạy
  // Khởi chạy
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
      sortTable("projectCount");
    },
    event9: function (event) {
      sortTable("reviewedCount");
    }
  };
}

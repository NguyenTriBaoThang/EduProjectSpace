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
  // Hằng số và biến toàn cục
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let currentHead = null; // Trưởng bộ môn hiện tại
  // Trưởng bộ môn hiện tại
  let currentIdHead = null;
  let allCourses = []; // Lưu trữ danh sách học phần từ API

  // Đường dẫn API cơ bản (thay đổi theo URL backend của bạn)
  // Lưu trữ danh sách học phần từ API

  // Đường dẫn API cơ bản (thay đổi theo URL backend của bạn)
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("lecturer_notifications.html"));
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

  // Hàm toggle sidebar
  // Hàm toggle sidebar
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

  // Hàm lấy danh sách học phần từ API
  // Hàm lấy danh sách học phần từ API
  async function fetchCourses() {
    try {
      const response = await fetch(`${API_URL}/api/HeadProgressCourses/?headLecturer=${encodeURIComponent(currentIdHead)}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể lấy danh sách học phần");
      const courses = await response.json();
      return courses;
    } catch (error) {
      console.error("Lỗi khi lấy danh sách học phần:", error);
      return [];
    }
  }

  // Hàm lọc danh sách học phần
  // Hàm lọc danh sách học phần
  function getFilteredCourses() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    return allCourses.filter(course => course.courseId.toLowerCase().includes(searchText) || course.name.toLowerCase().includes(searchText) || course.semester.toLowerCase().includes(searchText) || course.facultyCode.toLowerCase().includes(searchText));
  }

  // Hàm sắp xếp danh sách học phần
  // Hàm sắp xếp danh sách học phần
  function sortCourses(courses) {
    if (!sortColumn) return courses;
    return [...courses].sort((a, b) => {
      let valueA = a[sortColumn];
      let valueB = b[sortColumn];
      if (sortColumn === "groupCount" || sortColumn === "completedCount") {
        valueA = parseInt(valueA);
        valueB = parseInt(valueB);
      } else {
        valueA = valueA.toLowerCase();
        valueB = valueB.toLowerCase();
      }
      return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
    });
  }

  // Hàm hiển thị bảng
  // Hàm hiển thị bảng
  async function displayTable(page) {
    if (!allCourses.length) {
      allCourses = await fetchCourses();
    }
    const filteredCourses = getFilteredCourses();
    const sortedCourses = sortCourses(filteredCourses);
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = sortedCourses.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((course, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${course.courseId}</td>
                            <td>${course.name}</td>
                            <td>${course.semester}</td>
                            <td>${course.facultyCode}</td>
                            <td>${course.groupCount}</td>
                            <td>${course.completedCount}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewProgress(String(course.courseId), String(course.semester), String(course.facultyCode));
        })}">
                                    <i class="bi bi-eye"></i> Xem tiến độ
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(sortedCourses.length);
  }

  // Hàm thiết lập phân trang
  // Hàm thiết lập phân trang
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

  // Hàm chuyển trang
  // Hàm chuyển trang
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }

  // Hàm sắp xếp bảng
  // Hàm sắp xếp bảng
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }

  // Hàm lọc bảng
  // Hàm lọc bảng
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Hàm điều hướng đến trang theo dõi tiến độ
  // Hàm điều hướng đến trang theo dõi tiến độ
  function viewProgress(courseId, semester, facultyCode) {
    env.navigate(`head_progress.html?courseId=${courseId}&semester=${semester}&facultyCode=${facultyCode}`);
  }

  // Hàm xuất danh sách học phần sang Excel
  // Hàm xuất danh sách học phần sang Excel
  function exportCourses() {
    const filteredCourses = getFilteredCourses();
    const worksheetData = [["Danh sách học phần cần theo dõi tiến độ - Hệ thống Sinh viên HUTECH"], ["Trưởng bộ môn: Nguyễn Huy Cường"], [], ["#", "Mã học phần", "Tên học phần", "Học kỳ", "Mã lớp", "Số nhóm", "Số nhóm hoàn thành"]];
    filteredCourses.forEach((course, index) => {
      worksheetData.push([index + 1, course.courseId, course.name, course.semester, course.facultyCode, course.groupCount, course.completedCount]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "MonHocTienDo");
    XLSX.writeFile(workbook, "mon_hoc_theo_doi_tien_do.xlsx");
  }

  // Đăng xuất tài khoản
  // Đăng xuất tài khoản
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

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await displayTable(currentPage);
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
      sortTable("groupCount");
    },
    event10: function (event) {
      sortTable("completedCount");
    }
  };
}

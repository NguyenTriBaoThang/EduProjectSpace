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
  // Constants and global variables
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let allGroups = [];
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";

  // Get query parameters từ URL
  // Get query parameters từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const selectedLecturer = decodeURIComponent(urlParams.get("lecturer"));
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");

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
    if (!document.getElementById("profileDropdown").contains(event.target) && event.target.id !== "profileBtn") {
      document.getElementById("profileDropdown").style.display = "none";
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
      document.getElementById("headName").textContent = user.fullName || "Head HITECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }

  // Fetch chi tiết giảng viên từ API
  // Fetch chi tiết giảng viên từ API
  async function fetchLecturerDetails() {
    try {
      const response = await fetch(`${API_URL}/api/HeadLecturer/details?lecturer=${encodeURIComponent(selectedLecturer)}&courseId=${selectedCourseId}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi: ${await response.text()}`);
      return await response.json();
    } catch (error) {
      console.error("Error fetching lecturer details:", error);
      return null;
    }
  }

  // Fetch group details từ API
  // Fetch group details từ API
  async function fetchGroups() {
    try {
      const response = await fetch(`${API_URL}/api/HeadLecturer/groups?lecturer=${encodeURIComponent(selectedLecturer)}&courseId=${encodeURIComponent(selectedCourseId)}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to fetch groups");
      const groups = await response.json();
      return groups;
    } catch (error) {
      console.error("Error fetching groups:", error);
      return [];
    }
  }

  // Hiển thị thông tin giảng viên
  // Hiển thị thông tin giảng viên
  async function displayLecturerInfo() {
    const details = await fetchLecturerDetails();
    if (!details) {
      document.getElementById("lecturerName").textContent = "Không tìm thấy";
      document.getElementById("courseInfo").textContent = "Không tìm thấy";
      document.getElementById("studentCount").textContent = "0";
      document.getElementById("groupCount").textContent = "0";
      return;
    }
    document.getElementById("lecturerName").textContent = details.lecturer;
    document.getElementById("courseInfo").textContent = `${details.courseCode} (${details.facultyCode} - ${details.semesterName})`;
    document.getElementById("studentCount").textContent = details.studentCount;
    document.getElementById("groupCount").textContent = details.groupCount;
  }

  // Lọc nhóm theo tìm kiếm
  // Lọc nhóm theo tìm kiếm
  function getFilteredGroups() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    return allGroups.filter(data => data.studentIds.toLowerCase().includes(searchText) || data.studentNames.toLowerCase().includes(searchText) || data.groupName.toLowerCase().includes(searchText) || data.projectName.toLowerCase().includes(searchText));
  }

  // Sắp xếp nhóm
  // Sắp xếp nhóm
  function sortGroups(groups) {
    if (!sortColumn) return groups;
    return [...groups].sort((a, b) => {
      const valA = a[sortColumn].toLowerCase();
      const valB = b[sortColumn].toLowerCase();
      return sortDirection === "asc" ? valA > valB ? 1 : -1 : valA < valB ? 1 : -1;
    });
  }

  // Hiển thị bảng với phân trang
  // Hiển thị bảng với phân trang
  async function displayTable(page) {
    if (!allGroups.length) {
      allGroups = await fetchGroups();
    }
    const filteredGroups = getFilteredGroups();
    const sortedGroups = sortGroups(filteredGroups);
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = sortedGroups.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (!selectedLecturer || !selectedCourseId || !selectedSemester || !selectedFacultyCode) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Vui lòng chọn một giảng viên từ danh sách.</td></tr>");
    } else if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy nhóm nào.</td></tr>");
    } else {
      paginatedData.forEach(groupData => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${groupData.groupId}</td>
                            <td>${groupData.studentIds}</td>
                            <td>${groupData.studentNames}</td>
                            <td>${groupData.groupName}</td>
                            <td>${groupData.projectName}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewGroupDetails(groupData.groupId);
        })}">
                                    <i class="bi bi-eye"></i> Xem chi tiết
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(sortedGroups.length);
  }

  // Thiết lập phân trang
  // Thiết lập phân trang
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

  // Chuyển trang
  // Chuyển trang
  function changePage(page) {
    currentPage = page;
    displayTable(page);
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

  // Lọc nhóm theo tìm kiếm
  // Lọc nhóm theo tìm kiếm
  function filterGroups() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Điều hướng đến trang chi tiết nhóm
  // Điều hướng đến trang chi tiết nhóm
  function viewGroupDetails(groupId) {
    env.navigate(`/font-end/head/head_group_details.html?lecturer=${encodeURIComponent(selectedLecturer)}&courseId=${selectedCourseId}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}&groupId=${groupId}`);
  }

  // Xuất dữ liệu sang Excel
  // Xuất dữ liệu sang Excel
  async function exportDetails() {
    const filteredGroups = getFilteredGroups();
    const worksheetData = [["Chi tiết giảng viên hướng dẫn - Hệ thống Sinh viên HUTECH"], [`GVHD: ${selectedLecturer}`], [`Học phần: ${selectedCourseId} - ${selectedFacultyCode} - ${selectedSemester}`], [], ["ID Nhóm", "Mã SV", "Tên SV", "Tên nhóm", "Tên dự án"]];
    filteredGroups.forEach(groupData => {
      worksheetData.push([groupData.groupId, groupData.studentIds, groupData.studentNames, groupData.groupName, groupData.projectName]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietGVHD");
    XLSX.writeFile(workbook, `chi_tiet_gvhd_${selectedLecturer}_${selectedCourseId}_${selectedFacultyCode}_${selectedSemester}.xlsx`);
  }

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
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${await response.text()}`);
      alert("Đăng xuất thành công!");
    } catch (error) {
      alert("Đăng xuất bị lỗi: " + error.message);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await displayLecturerInfo();
    await displayTable(currentPage);
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      filterGroups();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      exportDetails();
    },
    event4: function (event) {
      filterGroups();
    },
    event5: function (event) {
      sortTable("studentIds");
    },
    event6: function (event) {
      sortTable("studentNames");
    },
    event7: function (event) {
      sortTable("groupName");
    },
    event8: function (event) {
      sortTable("projectName");
    }
  };
}

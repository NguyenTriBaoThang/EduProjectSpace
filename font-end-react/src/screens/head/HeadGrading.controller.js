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
  const urlParams = new URLSearchParams(window.location.search);
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");
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
      document.getElementById("headName").textContent = user.fullName || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function fetchGroups() {
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseGrading/groups-for-grading?courseId=${encodeURIComponent(selectedCourseId)}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}`, {
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách nhóm: ${response.status}`);
      return await response.json();
    } catch (error) {
      console.error("Error loading groups:", error);
      alert("Không thể tải danh sách nhóm. Vui lòng thử lại sau.");
      return [];
    }
  }
  function getFilteredGroups() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    const approvalFilter = document.getElementById("approvalFilter").value;
    let filtered = allGroups.filter(group => (group.name.toLowerCase().includes(searchText) || group.projectId.toLowerCase().includes(searchText) || group.projectName.toLowerCase().includes(searchText) || group.members.toLowerCase().includes(searchText) || group.lecturer.toLowerCase().includes(searchText)) && (statusFilter === "" || group.status === statusFilter) && (approvalFilter === "" || group.approved === approvalFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn].toLowerCase();
        let valueB = b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  async function displayTable(page) {
    if (!allGroups.length) allGroups = await fetchGroups();
    const filteredGroups = getFilteredGroups();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredGroups.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (!selectedCourseId || !selectedSemester || !selectedFacultyCode) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"10\" class=\"text-center\">Vui lòng chọn một học phần từ danh sách để xem và duyệt điểm.</td></tr>");
    } else if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"10\" class=\"text-center\">Không tìm thấy nhóm nào.</td></tr>");
    } else {
      paginatedData.forEach((group, index) => {
        const statusClass = group.status === "APPROVED" ? "bg-success" : group.status === "REJECTED" ? "bg-danger" : "bg-warning";
        const approvalClass = group.approved === "Đã duyệt" ? "bg-success" : "bg-warning";
        const isBothNotApproved = group.status === "Chưa duyệt" && group.approved === "Chưa duyệt";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${group.name}</td>
                            <td>${group.projectId}</td>
                            <td>${group.projectName}</td>
                            <td>${group.members}</td>
                            <td>${group.lecturer}</td>
                            <td>${group.grade}</td>
                            <td><span class="badge ${statusClass}">${group.status === "APPROVED" ? "Đã duyệt" : group.status === "REJECTED" ? "Từ chối" : "Chưa duyệt"}</span></td>
                            <td><span class="badge ${approvalClass}">${group.approved}</span></td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          viewGradingDetails(group.id);
        })}" ${isBothNotApproved ? "disabled" : ""}>
                                    <i class="bi bi-eye"></i> Xem & duyệt
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredGroups.length);
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
  function viewGradingDetails(groupId) {
    env.navigate(`head_grading_details.html?courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}&groupId=${groupId}`);
  }
  function exportGrades() {
    const filteredGroups = getFilteredGroups();
    const worksheetData = [["Báo cáo chấm điểm - Hệ thống Sinh viên HUTECH"], [`Lớp: ${selectedCourseId} - ${selectedFacultyCode} - ${selectedSemester}`], [], ["#", "Tên nhóm", "Mã đồ án", "Tên đồ án", "Thành viên", "GVHD", "Điểm tổng", "Trạng thái duyệt", "Trạng thái đồ án"]];
    filteredGroups.forEach((group, index) => {
      worksheetData.push([index + 1, group.name, group.projectId, group.projectName, group.members, group.lecturer, group.grade, group.approved, group.status]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "BaoCaoChamDiem");
    XLSX.writeFile(workbook, `bao_cao_cham_diem_${selectedCourseId}_${selectedFacultyCode}_${selectedSemester}.xlsx`);
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
  let allGroups = [];
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
      exportGrades();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      filterTable();
    },
    event6: function (event) {
      filterTable();
    },
    event7: function (event) {
      sortTable("name");
    },
    event8: function (event) {
      sortTable("projectId");
    },
    event9: function (event) {
      sortTable("projectName");
    },
    event10: function (event) {
      sortTable("members");
    },
    event11: function (event) {
      sortTable("lecturer");
    }
  };
}

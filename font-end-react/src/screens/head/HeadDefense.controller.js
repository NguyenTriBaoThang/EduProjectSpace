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
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let schedules = [];
  let headId = null;

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const courseId = urlParams.get("courseId");
  const semester = urlParams.get("semester");
  const classId = urlParams.get("classId");
  document.getElementById("schedule-title").innerHTML = env.html(`📅 Quản lý lịch bảo vệ - ${courseId || "Chưa chọn học phần"}`);

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
      headId = parseInt(user.id);
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Trưởng bộ môn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Tải danh sách lịch bảo vệ
  // Tải danh sách lịch bảo vệ
  async function loadSchedules() {
    if (!courseId || !semester || !classId) {
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Vui lòng chọn một học phần từ danh sách để quản lý lịch bảo vệ.</td></tr>");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadDefenseSchedule?courseId=${courseId}&semester=${semester}&classId=${classId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`HTTP ${response.status}: Không thể tải lịch bảo vệ.`);
      schedules = await response.json();
      filterTable();
    } catch (e) {
      console.error("Lỗi tải lịch bảo vệ:", e);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy lịch bảo vệ nào.</td></tr>");
    }
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredSchedules() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    let filtered = schedules.filter(s => s.projectId.toLowerCase().includes(searchText) || s.groupName.toLowerCase().includes(searchText) || s.members.toLowerCase().includes(searchText) || s.date.toLowerCase().includes(searchText) || s.location.toLowerCase().includes(searchText) || s.council.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "date") {
          valueA = valueA === "Chưa xếp lịch" ? "" : new Date(valueA.split("/").reverse().join("-"));
          valueB = valueB === "Chưa xếp lịch" ? "" : new Date(valueB.split("/").reverse().join("-"));
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
    const filteredSchedules = getFilteredSchedules();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredSchedules.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (!courseId || !semester || !classId) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Vui lòng chọn một học phần từ danh sách để quản lý lịch bảo vệ.</td></tr>");
    } else if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy nhóm nào.</td></tr>");
    } else {
      paginatedData.forEach((item, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${item.projectId}</td>
                            <td>${item.groupName}</td>
                            <td>${item.members}</td>
                            <td>${item.date}</td>
                            <td>${item.location}</td>
                            <td>${item.council}</td>
                            <td>
                                ${item.id ? `
                                    <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editDefense(item.id, String(item.projectId));
        })}">
                                        <i class="bi bi-pencil"></i>
                                    </button>
                                    <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteDefense(item.id);
        })}">
                                        <i class="bi bi-trash"></i>
                                    </button>
                                ` : `
                                    <button class="btn btn-sm btn-success" data-page-click="${env.bind(function (event) {
          addDefenseForGroup(String(item.projectId));
        })}">
                                        <i class="bi bi-plus-circle"></i>
                                    </button>
                                `}
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredSchedules.length);
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

  // Chuyển đến trang thêm lịch bảo vệ cho nhóm
  // Chuyển đến trang thêm lịch bảo vệ cho nhóm
  function addDefenseForGroup(projectId) {
    env.navigate(`head_defense_add.html?projectId=${projectId}&courseId=${courseId}&semester=${semester}&classId=${classId}`);
  }

  // Chuyển đến trang thêm lịch bảo vệ
  // Chuyển đến trang thêm lịch bảo vệ
  function addDefensePage() {
    env.navigate(`head_defense_add.html?courseId=${courseId}&semester=${semester}&classId=${classId}`);
  }

  // Chuyển đến trang sửa lịch bảo vệ
  // Chuyển đến trang sửa lịch bảo vệ
  function editDefense(id, projectId) {
    env.navigate(`head_defense_edit.html?id=${id}&projectId=${projectId}&courseId=${courseId}&semester=${semester}&classId=${classId}`);
  }

  // Xóa lịch bảo vệ
  // Xóa lịch bảo vệ
  async function deleteDefense(id) {
    if (confirm("Bạn có chắc muốn xóa lịch bảo vệ này không?")) {
      try {
        const response = await fetch(`${API_URL}/api/HeadDefenseSchedule/${id}`, {
          method: "DELETE",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (!response.ok) {
          const error = await response.json();
          throw new Error(error.message || `HTTP ${response.status}: Không thể xóa lịch bảo vệ.`);
        }
        alert("Đã xóa lịch bảo vệ!");
        await loadSchedules();
      } catch (e) {
        console.error("Lỗi khi xóa lịch bảo vệ:", e);
        alert(`Lỗi khi xóa lịch bảo vệ: ${e.message}`);
      }
    }
  }

  // Xuất danh sách lịch bảo vệ sang Excel
  // Xuất danh sách lịch bảo vệ sang Excel
  function exportDefense() {
    const filteredSchedules = getFilteredSchedules();
    const worksheetData = [["Danh sách lịch bảo vệ - Hệ thống Sinh viên HUTECH"], [`Trưởng bộ môn: ${document.getElementById("userName").textContent}`], [`Học phần: ${courseId || "Chưa chọn"} - Học kỳ: ${semester || "Chưa chọn"} - Lớp: ${classId || "Chưa chọn"}`], [], ["#", "Mã đề tài", "Tên nhóm", "Thành viên", "Ngày bảo vệ", "Địa điểm", "Hội đồng"]];
    filteredSchedules.forEach((item, index) => {
      worksheetData.push([index + 1, item.projectId, item.groupName, item.members, item.date, item.location, item.council]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "LichBaoVe");
    XLSX.writeFile(workbook, `lich_bao_ve_${courseId || "mon-hoc"}_${semester || "hk"}_${classId || "lop"}.xlsx`);
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
      if (response.ok) {
        alert("Đã đăng xuất thành công.");
      } else {
        alert("Đăng xuất thất bại.");
      }
    } catch (error) {
      console.error("Lỗi đăng xuất:", error);
      alert("Lỗi khi đăng xuất.");
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("../LOGIN/login.html", true);
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadSchedules();
    } catch (error) {
      console.error("Lỗi tải trang:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      logout();
    }
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
      addDefensePage();
    },
    event4: function (event) {
      exportDefense();
    },
    event5: function (event) {
      filterTable();
    },
    event6: function (event) {
      sortTable("projectId");
    },
    event7: function (event) {
      sortTable("groupName");
    },
    event8: function (event) {
      sortTable("members");
    },
    event9: function (event) {
      sortTable("date");
    },
    event10: function (event) {
      sortTable("location");
    },
    event11: function (event) {
      sortTable("council");
    }
  };
}

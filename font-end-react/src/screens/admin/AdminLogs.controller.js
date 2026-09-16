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
  let logs = [];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let fuse = null;

  // Hàm chuẩn hóa tiếng Việt (bỏ dấu)
  // Hàm chuẩn hóa tiếng Việt (bỏ dấu)
  function removeVietnameseTones(str) {
    if (!str) return "";
    return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D").toLowerCase();
  }

  // Hàm tạo chỉ mục cho Fuse.js
  // Hàm tạo chỉ mục cho Fuse.js
  function createFuseIndex(data) {
    return new Fuse(data, {
      keys: [{
        name: "fullName",
        weight: 0.4
      }, {
        name: "action",
        weight: 0.3
      }, {
        name: "details",
        weight: 0.3
      }],
      includeScore: true,
      threshold: 0.4,
      // Độ nhạy tìm kiếm mờ
      ignoreLocation: true,
      // Tìm kiếm chuỗi con
      useExtendedSearch: true,
      getFn: (obj, path) => {
        const value = Fuse.config.getFn(obj, path);
        return removeVietnameseTones(value);
      }
    });
  }

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_ADMIN") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      document.getElementById("adminName").textContent = user.fullName || "Admin HUTECH";
      document.getElementById("adminEmail").textContent = user.email || "admin@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }

  // Lấy danh sách log từ API
  // Lấy danh sách log từ API
  async function loadLogs() {
    try {
      const response = await fetch(`${API_URL}/api/Log`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Lỗi tải danh sách log: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      const rawLogs = JSON.parse(text);
      logs = rawLogs.map(log => ({
        id: log.id,
        createdAt: new Date(log.createdAt).toLocaleString("vi-VN", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit"
        }),
        userId: log.userId,
        fullName: log.fullName,
        roleName: log.roleName,
        action: mapAction(log.action),
        details: log.details
      }));
      fuse = createFuseIndex(logs); // Tạo chỉ mục Fuse.js
      displayTable(currentPage);
    } catch (error) {
      throw error;
    }
  }

  // Ánh xạ hành động
  // Ánh xạ hành động
  function mapAction(action) {
    switch (action) {
      case "LOGIN":
        return "Đăng nhập";
      case "LOGOUT":
        return "Đăng xuất";
      case "CREATE":
        return "Tạo";
      case "UPDATE":
        return "Sửa";
      case "DELETE":
        return "Xóa";
      case "EXPORT_EXCEL":
        return "Xuất excel";
      case "SEND_NOTIFICATION":
        return "Gửi thông báo";
      case "CREATE_ASSIGNMENT":
        return "Tạo bài tập";
      case "SUBMIT_ASSIGNMENT":
        return "Nộp bài";
      case "APPROVE":
        return "Duyệt";
      case "DIVIDE_GROUPS":
        return "Chia nhóm";
      case "GREADE":
        return "Chấm điểm";
      case "COMMENT":
        return "Nhận xét";
      default:
        return action;
    }
  }

  // Ánh xạ Quyền
  // Ánh xạ Quyền
  function getRoleDisplayName(roleName) {
    const roleMap = {
      ROLE_ADMIN: "Quản trị viên",
      ROLE_LECTURER_GUIDE: "Giảng viên hướng dẫn",
      ROLE_STUDENT: "Sinh viên",
      ROLE_HEAD: "Trưởng bộ môn",
      ROLE_REVIEWER: "Giảng viên phản biện"
    };
    return roleMap[roleName] || "Không xác định";
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredLogs() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const roleFilter = document.getElementById("roleFilter").value;
    const actionFilter = document.getElementById("actionFilter").value;

    // Tìm kiếm bằng Fuse.js
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : logs;

    // Lọc theo vai trò và hành động
    filtered = filtered.filter(log => (roleFilter === "" || log.roleName === roleFilter) && (actionFilter === "" || log.action === mapAction(actionFilter)));

    // Sắp xếp nếu có
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn] || "";
        let valueB = b[sortColumn] || "";
        if (sortColumn === "createdAt") {
          valueA = new Date(a.createdAt.replace(/(\d{2})\/(\d{2})\/(\d{4}), (\d{2}):(\d{2})/, "$3-$2-$1T$4:$5:00"));
          valueB = new Date(b.createdAt.replace(/(\d{2})\/(\d{2})\/(\d{4}), (\d{2}):(\d{2})/, "$3-$2-$1T$4:$5:00"));
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Hiển thị bảng
  // Hiển thị bảng
  function displayTable(page) {
    const filteredLogs = getFilteredLogs();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredLogs.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy log nào.</td></tr>");
    } else {
      paginatedData.forEach((log, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${log.createdAt}</td>
                            <td>${log.fullName}</td>
                            <td>${getRoleDisplayName(log.roleName)}</td>
                            <td>${log.action}</td>
                            <td style="max-width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="${log.details}">${log.details}</td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredLogs.length);
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

  // Xuất danh sách log sang Excel
  // Xuất danh sách log sang Excel
  async function exportLogs() {
    const search = encodeURIComponent(document.getElementById("searchInputFuse").value);
    const roleFilter = encodeURIComponent(document.getElementById("roleFilter").value);
    const actionFilter = encodeURIComponent(document.getElementById("actionFilter").value);
    try {
      const response = await fetch(`${API_URL}/api/Log/export?search=${search}&roleFilter=${roleFilter}&actionFilter=${actionFilter}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.status === 401) {
        alert("Bạn không có quyền xuất log. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không xuất được file Excel: ${errorText || response.statusText}`);
      }
      const blob = await response.blob();
      const url = window.env.objectUrl(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = "lich_su_hoat_dong.xlsx";
      document.body.appendChild(a);
      a.click();
      a.remove();
      window.URL.revokeObjectURL(url);
    } catch (error) {
      console.error("Error:", error);
      alert("Không xuất được file Excel: " + error.message);
    }
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

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("/font-end/admin/admin_notifications.html");
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
  function toggleDropdown(event) {
    event.preventDefault();
    const dropdown = event.target.closest(".dropdown-menu-wrapper").querySelector(".dropdown-content");
    dropdown.style.display = dropdown.style.display === "none" ? "block" : "none";
  }
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

  // Tải dữ liệu khi trang được load
  // Tải dữ liệu khi trang được load
  env.ready(async () => {
    try {
      await loadUserProfile();
      await loadLogs();
    } catch (error) {
      console.error("Error loading logs:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      env.navigate("/font-end/login/login.html");
    }
  });
  return {
    event0: function (event) {
      toggleDropdown(event);
    },
    event1: function (event) {
      toggleSidebar();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      exportLogs();
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
      sortTable("createdAt");
    },
    event8: function (event) {
      sortTable("fullName");
    },
    event9: function (event) {
      sortTable("roleName");
    },
    event10: function (event) {
      sortTable("action");
    },
    event11: function (event) {
      sortTable("details");
    }
  };
}

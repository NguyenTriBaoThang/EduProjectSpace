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
  let users = [];
  let fuse = null;
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let departments = [];

  // Hàm chuẩn hóa tiếng Việt (bỏ dấu)
  // Hàm chuẩn hóa tiếng Việt (bỏ dấu)
  function removeVietnameseTones(str) {
    return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D").toLowerCase();
  }

  // Hàm tạo chỉ mục cho Fuse.js
  // Hàm tạo chỉ mục cho Fuse.js
  function createFuseIndex(data) {
    return new Fuse(data, {
      keys: [{
        name: "username",
        weight: 0.3
      }, {
        name: "fullName",
        weight: 0.4
      }, {
        name: "email",
        weight: 0.3
      }],
      includeScore: true,
      threshold: 0.4,
      ignoreLocation: true,
      useExtendedSearch: true,
      getFn: (obj, path) => {
        const value = Fuse.config.getFn(obj, path);
        return removeVietnameseTones(value);
      }
    });
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

  // Tải danh sách khoa
  // Tải danh sách khoa
  async function loadDepartments() {
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/department`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Lỗi tải danh sách khoa");
      departments = await response.json();
      populateDepartmentSelect("addUserDepartmentId");
      populateDepartmentSelect("editUserDepartmentId");
    } catch (error) {
      console.error("Error loading departments:", error);
      alert("Không tải được danh sách khoa: " + error.message);
    }
  }

  // Điền danh sách khoa vào select
  // Điền danh sách khoa vào select
  function populateDepartmentSelect(selectId) {
    const selectElement = document.getElementById(selectId);
    if (!selectElement) {
      console.warn(`Element with ID '${selectId}' not found.`);
      return;
    }
    selectElement.innerHTML = env.html("<option value=\"\">Chọn khoa</option>" + departments.map(dept => `<option value="${dept.id}">${dept.facultyName}</option>`).join(""));
  }

  // Hiển thị/ẩn các trường dựa trên vai trò
  // Hiển thị/ẩn các trường dựa trên vai trò
  function toggleRoleFields(prefix) {
    const roleSelectId = prefix === "add" ? "userRole" : "editUserRole";
    const roleSelect = document.getElementById(roleSelectId);
    const departmentContainer = document.getElementById(`${prefix}UserDepartmentIdContainer`);
    const classCodeContainer = document.getElementById(`${prefix}UserClassCodeContainer`);
    if (!roleSelect || !departmentContainer || !classCodeContainer) {
      console.warn(`One or more elements not found: roleSelect=${roleSelect}, departmentContainer=${departmentContainer}, classCodeContainer=${classCodeContainer}`);
      return;
    }
    const roleId = parseInt(roleSelect.value);
    departmentContainer.style.display = [2, 3, 4].includes(roleId) ? "block" : "none";
    const departmentSelect = document.getElementById(`${prefix}UserDepartmentId`);
    if (departmentSelect) {
      departmentSelect.required = [2, 3, 4].includes(roleId);
    }
    classCodeContainer.style.display = roleId === 3 ? "block" : "none";
    const classCodeInput = document.getElementById(`${prefix}UserClassCode`);
    if (classCodeInput) {
      classCodeInput.required = roleId === 3;
    }
  }
  async function loadUserProfile() {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user || user.roleName !== "ROLE_ADMIN") {
      throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
    }
    document.getElementById("adminName").textContent = user.fullName || "Admin HUTECH";
    document.getElementById("adminEmail").textContent = user.email || "admin@hutech.edu.vn";
  }
  async function loadUsers() {
    try {
      const response = await fetch(`${API_URL}/api/AdminUser`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách người dùng: ${response.status}`);
      users = await response.json();
      fuse = createFuseIndex(users);
      displayTable(currentPage);
    } catch (error) {
      throw new Error(`Lỗi API: ${error.message}`);
    }
  }
  function isUsernameDuplicate(username, excludeId = null) {
    return users.some(user => user.username === username && (!excludeId || user.id !== excludeId));
  }
  function getFilteredUsers() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const roleFilter = document.getElementById("roleFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : users;
    if (roleFilter) {
      filtered = filtered.filter(user => user.roleName === roleFilter);
    }
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "locked" ? a.locked : (a[sortColumn] || "").toLowerCase();
        let valueB = sortColumn === "locked" ? b.locked : (b[sortColumn] || "").toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredUsers = getFilteredUsers();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredUsers.slice(start, end);
    const tableBody = document.getElementById("userTableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy người dùng nào.</td></tr>");
    } else {
      paginatedData.forEach((user, index) => {
        const statusText = user.locked ? "Khóa" : "Hoạt động";
        const statusClass = user.locked ? "bg-danger" : "bg-success";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${user.fullName}</td>
                            <td>${user.email}</td>
                            <td>${getRoleDisplayName(user.roleName)}</td>
                            <td><span class="badge ${statusClass}">${statusText}</span></td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editUser(user.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteUser(user.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredUsers.length);
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
  async function addUser() {
    const form = document.getElementById("addUserForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const username = document.getElementById("userUsername").value;
    if (isUsernameDuplicate(username)) {
      alert("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
      return;
    }
    const roleSelect = document.getElementById("userRole");
    if (!roleSelect) {
      console.error("Role select element not found.");
      alert("Lỗi: Không tìm thấy trường vai trò.");
      return;
    }
    const roleId = parseInt(roleSelect.value);
    const departmentSelect = document.getElementById("addUserDepartmentId");
    const classCodeInput = document.getElementById("userClassCode");
    const newUser = {
      username: username,
      fullName: document.getElementById("userFullName").value,
      email: document.getElementById("userEmail").value,
      roleId: roleId,
      departmentId: [2, 3, 4].includes(roleId) && departmentSelect ? parseInt(departmentSelect.value) : null,
      classCode: roleId === 3 && classCodeInput ? classCodeInput.value : null
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(newUser)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không thêm được người dùng.");
      }
      alert("Đã thêm người dùng: " + newUser.fullName);
      bootstrap.Modal.getInstance(document.getElementById("addUserModal")).hide();
      await loadUsers();
    } catch (error) {
      console.error("Error:", error);
      alert("Không thêm được người dùng: " + error.message);
    }
  }
  function editUser(id) {
    const user = users.find(u => u.id === id);
    if (user) {
      document.getElementById("editUserId").value = user.id;
      document.getElementById("editUserUsername").value = user.username;
      document.getElementById("editUserFullName").value = user.fullName;
      document.getElementById("editUserEmail").value = user.email;
      document.getElementById("editUserPassword").value = "";
      document.getElementById("editUserRole").value = user.roleId;
      document.getElementById("editUserStatus").value = user.locked.toString();
      document.getElementById("editUserDepartmentId").value = user.departmentId || "";
      document.getElementById("editUserClassCode").value = user.classCode || "";
      toggleRoleFields("edit");
      const modal = new bootstrap.Modal(document.getElementById("editUserModal"));
      modal.show();
    }
  }
  async function saveEditUser() {
    const form = document.getElementById("editUserForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const id = parseInt(document.getElementById("editUserId").value);
    const roleId = parseInt(document.getElementById("editUserRole").value);
    const updatedUser = {
      id: id,
      username: document.getElementById("editUserUsername").value,
      fullName: document.getElementById("editUserFullName").value,
      email: document.getElementById("editUserEmail").value,
      password: document.getElementById("editUserPassword").value || undefined,
      roleId: roleId,
      departmentId: [2, 3, 4].includes(roleId) ? parseInt(document.getElementById("editUserDepartmentId").value) : null,
      classCode: roleId === 3 ? document.getElementById("editUserClassCode").value : null,
      locked: document.getElementById("editUserStatus").value === "true"
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedUser)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không cập nhật được người dùng.");
      }
      alert("Đã cập nhật thông tin người dùng: " + updatedUser.fullName);
      bootstrap.Modal.getInstance(document.getElementById("editUserModal")).hide();
      await loadUsers();
    } catch (error) {
      console.error("Error:", error);
      alert("Không cập nhật được người dùng: " + error.message);
    }
  }
  async function deleteUser(id) {
    if (!confirm("Bạn có chắc muốn xóa người dùng này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/${id}`, {
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
        throw new Error(error.message || "Không xóa được người dùng.");
      }
      alert("Đã xóa người dùng!");
      await loadUsers();
    } catch (error) {
      console.error("Error:", error);
      alert("Không xóa được người dùng: " + error.message);
    }
  }
  function exportUsers() {
    const filteredUsers = getFilteredUsers();
    const worksheetData = [["Danh sách người dùng - Hệ thống Sinh viên HUTECH"], [], ["#", "Tên", "Email", "Vai trò", "Trạng thái", "Khoa", "Mã lớp"]];
    filteredUsers.forEach((user, index) => {
      worksheetData.push([index + 1, user.fullName, user.email, user.roleName.replace("ROLE_", ""), user.locked ? "Khóa" : "Hoạt động", departments.find(dept => dept.id === user.departmentId)?.name || "", user.classCode || ""]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachNguoiDung");
    XLSX.writeFile(workbook, "danh_sach_nguoi_dung.xlsx");
  }
  async function importUsers(event) {
    const file = event.target.files[0];
    if (!file) return;
    try {
      const reader = new FileReader();
      reader.onload = async e => {
        const data = new Uint8Array(e.target.result);
        const workbook = XLSX.read(data, {
          type: "array"
        });
        const sheet = workbook.Sheets[workbook.SheetNames[0]];
        const rows = XLSX.utils.sheet_to_json(sheet, {
          header: ["Username", "FullName", "Email", "RoleId", "DepartmentId", "ClassCode"],
          skipHeader: true
        });
        if (rows.length === 0) {
          alert("File Excel trống hoặc định dạng không đúng.");
          return;
        }
        const usersToImport = rows.map(row => ({
          username: row.Username?.toString(),
          fullName: row.FullName?.toString(),
          email: row.Email?.toString(),
          roleId: parseInt(row.RoleId) || 3,
          departmentId: row.DepartmentId ? parseInt(row.DepartmentId) : null,
          classCode: row.ClassCode?.toString()
        })).filter(user => user.username && user.fullName && user.email && [1, 2, 3, 4].includes(user.roleId));
        if (usersToImport.length === 0) {
          alert("Không có dữ liệu hợp lệ trong file Excel. Đảm bảo có Username, FullName, Email, RoleId (1-4).");
          return;
        }

        // Kiểm tra dữ liệu bắt buộc theo vai trò
        const invalidUsers = [];
        usersToImport.forEach(user => {
          if (user.roleId === 3 && (!user.classCode || !user.departmentId)) {
            invalidUsers.push(`Sinh viên ${user.username}: Thiếu Mã lớp hoặc Khoa.`);
          } else if ([2, 4].includes(user.roleId) && !user.departmentId) {
            invalidUsers.push(`Giảng viên ${user.username}: Thiếu Khoa.`);
          }
        });
        if (invalidUsers.length > 0) {
          alert("Dữ liệu không hợp lệ:\n" + invalidUsers.join("\n"));
          return;
        }
        const usernameSet = new Set();
        const duplicateUsernames = [];
        for (const user of usersToImport) {
          if (usernameSet.has(user.username)) {
            duplicateUsernames.push(user.username);
          } else {
            usernameSet.add(user.username);
          }
        }
        if (duplicateUsernames.length > 0) {
          alert(`File Excel chứa Username trùng lặp: ${duplicateUsernames.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        const existingDuplicates = usersToImport.filter(user => isUsernameDuplicate(user.username)).map(user => user.username);
        if (existingDuplicates.length > 0) {
          alert(`Username đã tồn tại trong hệ thống: ${existingDuplicates.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        try {
          const response = await fetch(`${API_URL}/api/AdminUser/import`, {
            method: "POST",
            headers: {
              "Accept": "*/*",
              "Content-Type": "application/json",
              "Authorization": `Bearer ${localStorage.getItem("token")}`
            },
            credentials: "include",
            body: JSON.stringify(usersToImport)
          });
          if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || "Không nhập được danh sách người dùng.");
          }
          const result = await response.json();
          alert(`Đã nhập ${result.successCount} người dùng thành công. Thất bại: ${result.failedCount}. ${result.errors.length > 0 ? "Lỗi: " + result.errors.join("; ") : ""}`);
          await loadUsers();
        } catch (error) {
          console.error("Import error:", error);
          alert("Không nhập được danh sách người dùng: " + error.message);
        }
      };
      reader.readAsArrayBuffer(file);
    } catch (error) {
      console.error("Error reading file:", error);
      alert("Lỗi đọc file Excel: " + error.message);
    }
  }
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
  env.ready(async () => {
    try {
      await loadUserProfile();
      await loadDepartments();
      await loadUsers();
    } catch (error) {
      console.error("Error loading users:", error);
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
      filterTable();
    },
    event3: function (event) {
      logout();
    },
    event4: function (event) {
      document.getElementById("importExcel").click();
    },
    event5: function (event) {
      importUsers(event);
    },
    event6: function (event) {
      exportUsers();
    },
    event7: function (event) {
      filterTable();
    },
    event8: function (event) {
      filterTable();
    },
    event9: function (event) {
      sortTable("fullName");
    },
    event10: function (event) {
      sortTable("roleName");
    },
    event11: function (event) {
      sortTable("locked");
    },
    event12: function (event) {
      toggleRoleFields("add");
    },
    event13: function (event) {
      addUser();
    },
    event14: function (event) {
      toggleRoleFields("edit");
    },
    event15: function (event) {
      saveEditUser();
    }
  };
}

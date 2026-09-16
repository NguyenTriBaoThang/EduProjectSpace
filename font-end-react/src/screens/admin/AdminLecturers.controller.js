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
  let lecturers = [];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let fuse = null;
  let departments = [];

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
        name: "username",
        weight: 0.4
      }, {
        name: "fullName",
        weight: 0.4
      }, {
        name: "email",
        weight: 0.2
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

  // Tải danh sách khoa
  // Tải danh sách khoa
  async function loadDepartments() {
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/Department`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Lỗi tải danh sách khoa");
      departments = await response.json();
      populateDepartmentSelect("lecturerDepartmentId");
      populateDepartmentSelect("editLecturerDepartmentId");
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

  // Lấy danh sách giảng viên từ API
  // Lấy danh sách giảng viên từ API
  async function loadLecturers() {
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/lecturers`, {
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
        throw new Error(`Lỗi tải danh sách giảng viên: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      lecturers = JSON.parse(text);
      fuse = createFuseIndex(lecturers);
      displayTable(currentPage);
    } catch (error) {
      throw error;
    }
  }

  // Kiểm tra trùng mã giảng viên
  // Kiểm tra trùng mã giảng viên
  function isUsernameDuplicate(username, excludeId = null) {
    return lecturers.some(lecturer => lecturer.username === username && (!excludeId || lecturer.id !== excludeId));
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredLecturers() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const roleFilter = document.getElementById("roleFilter").value;
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : lecturers;
    filtered = filtered.filter(lecturer => (roleFilter === "" || lecturer.roleName === roleFilter) && (statusFilter === "" || lecturer.locked.toString() === statusFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "locked" ? a.locked : sortColumn === "departmentName" ? (departments.find(d => d.id === a.departmentId)?.name || "").toLowerCase() : (a[sortColumn] || "").toLowerCase();
        let valueB = sortColumn === "locked" ? b.locked : sortColumn === "departmentName" ? (departments.find(d => d.id === b.departmentId)?.name || "").toLowerCase() : (b[sortColumn] || "").toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Hiển thị bảng
  // Hiển thị bảng
  function displayTable(page) {
    const filteredLecturers = getFilteredLecturers();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredLecturers.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy giảng viên nào.</td></tr>");
    } else {
      paginatedData.forEach((lecturer, index) => {
        const statusText = lecturer.locked ? "Khóa" : "Hoạt động";
        const statusClass = lecturer.locked ? "bg-danger" : "bg-success";
        const department = departments.find(d => d.id === lecturer.departmentId);
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${lecturer.username}</td>
                            <td>${lecturer.fullName}</td>
                            <td>${lecturer.email}</td>
                            <td>${department ? department.facultyName : "Chưa có"}</td>
                            <td>${lecturer.roleName === "ROLE_LECTURER_GUIDE" ? "Giảng viên hướng dẫn" : "Trưởng bộ môn"}</td>
                            <td><span class="badge ${statusClass}">${statusText}</span></td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editLecturer(lecturer.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteLecturer(lecturer.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredLecturers.length);
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
    if (currentPage > 3) paginationHTML += `<li class="page-item disabled"><a class="page-link">...</a></li>`;
    if (currentPage > 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li class="page-item active"><a class="page-link">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li class="page-item disabled"><a class="page-link">...</a></li>`;
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

  // Thêm giảng viên
  // Thêm giảng viên
  async function addLecturer() {
    const form = document.getElementById("addLecturerForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const usernameElement = document.getElementById("lecturerUsername");
    const departmentElement = document.getElementById("lecturerDepartmentId");
    const roleElement = document.getElementById("lecturerRole");
    const passwordElement = document.getElementById("lecturerPassword");
    if (!usernameElement || !departmentElement || !roleElement) {
      alert("Lỗi: Không tìm thấy trường mã giảng viên, khoa, hoặc vai trò.");
      return;
    }
    const username = usernameElement.value;
    if (isUsernameDuplicate(username)) {
      alert("Mã giảng viên đã tồn tại. Vui lòng chọn mã khác.");
      return;
    }
    const newLecturer = {
      username: username,
      fullName: document.getElementById("lecturerFullName").value,
      email: document.getElementById("lecturerEmail").value,
      password: passwordElement.value || undefined,
      departmentId: parseInt(departmentElement.value),
      roleId: parseInt(roleElement.value)
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/lecturers`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(newLecturer)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không thêm được giảng viên.");
      }
      alert("Đã thêm giảng viên: " + newLecturer.fullName);
      bootstrap.Modal.getInstance(document.getElementById("addLecturerModal")).hide();
      await loadLecturers();
    } catch (error) {
      console.error("Error:", error);
      alert("Không thêm được giảng viên: " + error.message);
    }
  }

  // Sửa giảng viên
  // Sửa giảng viên
  function editLecturer(id) {
    const lecturer = lecturers.find(l => l.id === id);
    if (lecturer) {
      document.getElementById("editLecturerId").value = lecturer.id;
      document.getElementById("editLecturerUsername").value = lecturer.username;
      document.getElementById("editLecturerFullName").value = lecturer.fullName;
      document.getElementById("editLecturerEmail").value = lecturer.email;
      document.getElementById("editLecturerPassword").value = "";
      document.getElementById("editLecturerDepartmentId").value = lecturer.departmentId || "";
      document.getElementById("editLecturerRole").value = lecturer.roleId;
      document.getElementById("editLecturerStatus").value = lecturer.locked.toString();
      const modal = new bootstrap.Modal(document.getElementById("editLecturerModal"));
      modal.show();
    }
  }
  async function saveEditLecturer() {
    const form = document.getElementById("editLecturerForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const idElement = document.getElementById("editLecturerId");
    const departmentElement = document.getElementById("editLecturerDepartmentId");
    const roleElement = document.getElementById("editLecturerRole");
    if (!idElement || !departmentElement || !roleElement) {
      alert("Lỗi: Không tìm thấy trường ID, khoa, hoặc vai trò.");
      return;
    }
    const id = parseInt(idElement.value);
    const updatedLecturer = {
      id: id,
      username: document.getElementById("editLecturerUsername").value,
      fullName: document.getElementById("editLecturerFullName").value,
      email: document.getElementById("editLecturerEmail").value,
      password: document.getElementById("editLecturerPassword").value || undefined,
      departmentId: parseInt(departmentElement.value),
      roleId: parseInt(roleElement.value),
      locked: document.getElementById("editLecturerStatus").value === "true"
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/lecturers/update/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedLecturer)
      });

      // Log response for debugging
      console.log("Response status:", response.status);
      const text = await response.text();
      console.log("Response text:", text);
      if (!response.ok) {
        let errorMessage = "Không cập nhật được giảng viên.";
        if (response.status === 405) {
          errorMessage = "Phương thức PUT không được hỗ trợ. Vui lòng kiểm tra API.";
        } else if (text) {
          try {
            const error = JSON.parse(text);
            errorMessage = error.message || errorMessage;
          } catch (e) {
            errorMessage = text || errorMessage;
          }
        }
        throw new Error(errorMessage);
      }
      alert("Đã cập nhật thông tin giảng viên: " + updatedLecturer.fullName);
      bootstrap.Modal.getInstance(document.getElementById("editLecturerModal")).hide();
      await loadLecturers();
    } catch (error) {
      console.error("Error in saveEditLecturer:", error);
      alert("Không cập nhật được giảng viên: " + error.message);
    }
  }

  // Xóa giảng viên
  // Xóa giảng viên
  async function deleteLecturer(id) {
    if (!confirm("Bạn có chắc muốn xóa giảng viên này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/lecturers/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Authorization": `Bearer ${localStorage.getItem("token")}`,
          "Content-Type": "application/json"
        },
        credentials: "include"
      });
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không xóa được giảng viên: ${errorText || response.statusText}`);
      }
      alert("Đã xóa giảng viên!");
      await loadLecturers();
    } catch (error) {
      console.error("Error:", error);
      alert("Không xóa được giảng viên: " + error.message);
    }
  }

  // Xuất danh sách giảng viên sang Excel
  // Xuất danh sách giảng viên sang Excel
  function exportLecturers() {
    const filteredLecturers = getFilteredLecturers();
    const worksheetData = [["Danh sách giảng viên - Hệ thống Sinh viên HUTECH"], [], ["#", "Mã GV", "Họ và tên", "Email", "Khoa", "Vai trò", "Trạng thái"]];
    filteredLecturers.forEach((lecturer, index) => {
      const department = departments.find(d => d.id === lecturer.departmentId);
      worksheetData.push([index + 1, lecturer.username, lecturer.fullName, lecturer.email, department ? department.name : "Chưa có", lecturer.roleId === 2 ? "Giảng viên hướng dẫn" : "Trưởng bộ môn", lecturer.locked ? "Khóa" : "Hoạt động"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachGiangVien");
    XLSX.writeFile(workbook, "danh_sach_giang_vien.xlsx");
  }

  // Nhập danh sách giảng viên từ Excel
  // Nhập danh sách giảng viên từ Excel
  async function importLecturers(event) {
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
          header: ["Username", "FullName", "Email", "DepartmentId", "RoleId", "Password"],
          skipHeader: true
        });
        if (rows.length === 0) {
          alert("File Excel trống hoặc định dạng không đúng.");
          return;
        }
        const lecturersToImport = rows.map(row => ({
          username: row.Username?.toString(),
          fullName: row.FullName?.toString(),
          email: row.Email?.toString(),
          departmentId: parseInt(row.DepartmentId) || null,
          roleId: parseInt(row.RoleId) || 2,
          password: row.Password?.toString()
        })).filter(lecturer => lecturer.username && lecturer.fullName && lecturer.email && lecturer.departmentId && departments.some(d => d.id === lecturer.departmentId) && [2, 4].includes(lecturer.roleId));
        if (lecturersToImport.length === 0) {
          alert("Không có dữ liệu hợp lệ. Đảm bảo có Username, FullName, Email, DepartmentId hợp lệ, RoleId (2 hoặc 4).");
          return;
        }
        const usernameSet = new Set();
        const duplicateUsernames = [];
        for (const lecturer of lecturersToImport) {
          if (usernameSet.has(lecturer.username)) {
            duplicateUsernames.push(lecturer.username);
          } else {
            usernameSet.add(lecturer.username);
          }
        }
        if (duplicateUsernames.length > 0) {
          alert(`File Excel chứa Mã GV trùng lặp: ${duplicateUsernames.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        const existingDuplicates = lecturersToImport.filter(lecturer => isUsernameDuplicate(lecturer.username)).map(lecturer => lecturer.username);
        if (existingDuplicates.length > 0) {
          alert(`Mã GV đã tồn tại trong hệ thống: ${existingDuplicates.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        try {
          const response = await fetch(`${API_URL}/api/AdminUser/lecturers/import`, {
            method: "POST",
            headers: {
              "Accept": "*/*",
              "Content-Type": "application/json",
              "Authorization": `Bearer ${localStorage.getItem("token")}`
            },
            credentials: "include",
            body: JSON.stringify(lecturersToImport)
          });
          if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || "Không nhập được danh sách giảng viên.");
          }
          const result = await response.json();
          let message = `Đã nhập ${result.successCount} giảng viên thành công. Thất bại: ${result.failedCount}.`;
          if (result.errors.length > 0) {
            message += `\nLỗi chi tiết:\n${result.errors.join("\n")}`;
          }
          alert(message);
          await loadLecturers();
        } catch (error) {
          console.error("Import error:", error);
          alert("Không nhập được danh sách giảng viên: " + error.message);
        }
      };
      reader.readAsArrayBuffer(file);
    } catch (error) {
      console.error("Error reading file:", error);
      alert("Lỗi đọc file Excel: " + error.message);
    }
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
      await loadDepartments();
      await loadLecturers();
    } catch (error) {
      console.error("Error loading data:", error);
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
      document.getElementById("importExcel").click();
    },
    event4: function (event) {
      importLecturers(event);
    },
    event5: function (event) {
      exportLecturers();
    },
    event6: function (event) {
      filterTable();
    },
    event7: function (event) {
      filterTable();
    },
    event8: function (event) {
      filterTable();
    },
    event9: function (event) {
      sortTable("username");
    },
    event10: function (event) {
      sortTable("fullName");
    },
    event11: function (event) {
      sortTable("departmentName");
    },
    event12: function (event) {
      sortTable("roleName");
    },
    event13: function (event) {
      sortTable("locked");
    },
    event14: function (event) {
      addLecturer();
    },
    event15: function (event) {
      saveEditLecturer();
    }
  };
}

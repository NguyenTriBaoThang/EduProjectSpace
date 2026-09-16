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
  let students = [];
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
      populateDepartmentSelect("studentDepartmentId");
      populateDepartmentSelect("editStudentDepartmentId");
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

  // Lấy danh sách sinh viên từ API
  // Lấy danh sách sinh viên từ API
  async function fetchStudents() {
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/students`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách sinh viên: ${response.status}`);
      students = await response.json();
      fuse = createFuseIndex(students);
      displayTable(currentPage);
    } catch (error) {
      throw new Error(`Lỗi API: ${error.message}`);
    }
  }

  // Kiểm tra Username trùng trong danh sách hiện tại
  // Kiểm tra Username trùng trong danh sách hiện tại
  function isUsernameDuplicate(username, excludeId = null) {
    return students.some(student => student.username === username && (!excludeId || student.id !== excludeId));
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredStudents() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : students;
    if (statusFilter) {
      filtered = filtered.filter(student => (statusFilter === "Hoạt động" && !student.locked) || (statusFilter === "Khóa" && student.locked));
    }
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
    const filteredStudents = getFilteredStudents();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredStudents.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy sinh viên nào.</td></tr>");
    } else {
      paginatedData.forEach((student, index) => {
        const status = student.locked ? "Khóa" : "Hoạt động";
        const statusClass = student.locked ? "bg-danger" : "bg-success";
        const department = departments.find(d => d.id === student.departmentId);
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${student.username}</td>
                            <td>${student.fullName}</td>
                            <td>${student.email}</td>
                            <td>${department ? department.facultyName : "Chưa có"}</td>
                            <td>${student.classCode || ""}</td>
                            <td><span class="badge ${statusClass}">${status}</span></td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editStudent(student.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteStudent(student.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredStudents.length);
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

  // Thêm sinh viên
  // Thêm sinh viên
  async function addStudent() {
    const form = document.getElementById("addStudentForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const usernameElement = document.getElementById("studentId");
    const departmentElement = document.getElementById("studentDepartmentId");
    if (!usernameElement || !departmentElement) {
      alert("Lỗi: Không tìm thấy trường mã sinh viên hoặc khoa.");
      return;
    }
    const username = usernameElement.value;
    if (isUsernameDuplicate(username)) {
      alert("Mã sinh viên đã tồn tại. Vui lòng chọn mã khác.");
      return;
    }
    const newStudent = {
      username: username,
      fullName: document.getElementById("studentName").value,
      email: document.getElementById("studentEmail").value,
      roleId: 3,
      // Student role
      departmentId: parseInt(departmentElement.value),
      classCode: document.getElementById("studentClass").value
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/students`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(newStudent)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không thêm được sinh viên.");
      }
      alert("Đã thêm sinh viên: " + newStudent.fullName);
      bootstrap.Modal.getInstance(document.getElementById("addStudentModal")).hide();
      await fetchStudents();
    } catch (error) {
      console.error("Error:", error);
      alert("Không thêm được sinh viên: " + error.message);
    }
  }

  // Sửa sinh viên
  // Sửa sinh viên
  function editStudent(id) {
    const student = students.find(s => s.id === id);
    if (student) {
      document.getElementById("editStudentId").value = student.id;
      document.getElementById("editStudentCode").value = student.username;
      document.getElementById("editStudentName").value = student.fullName;
      document.getElementById("editStudentEmail").value = student.email;
      document.getElementById("editStudentDepartmentId").value = student.departmentId || "";
      document.getElementById("editStudentClass").value = student.classCode || "";
      document.getElementById("editStudentPassword").value = "";
      document.getElementById("editStudentStatus").value = student.locked ? "Khóa" : "Hoạt động";
      const modal = new bootstrap.Modal(document.getElementById("editStudentModal"));
      modal.show();
    }
  }
  async function saveEditStudent() {
    const form = document.getElementById("editStudentForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const idElement = document.getElementById("editStudentId");
    const departmentElement = document.getElementById("editStudentDepartmentId");
    if (!idElement || !departmentElement) {
      alert("Lỗi: Không tìm thấy trường ID hoặc khoa.");
      return;
    }
    const id = parseInt(idElement.value);
    const updatedStudent = {
      id: id,
      email: document.getElementById("editStudentEmail").value,
      fullName: document.getElementById("editStudentName").value,
      departmentId: parseInt(departmentElement.value),
      classCode: document.getElementById("editStudentClass").value,
      password: document.getElementById("editStudentPassword").value || undefined,
      locked: document.getElementById("editStudentStatus").value === "Khóa"
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/students/update/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedStudent)
      });
      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || "Không cập nhật được sinh viên.");
      }
      alert("Đã cập nhật thông tin sinh viên: " + updatedStudent.fullName);
      bootstrap.Modal.getInstance(document.getElementById("editStudentModal")).hide();
      await fetchStudents();
    } catch (error) {
      console.error("Error:", error);
      alert("Không cập nhật được sinh viên: " + error.message);
    }
  }

  // Xóa sinh viên
  // Xóa sinh viên
  async function deleteStudent(id) {
    if (!confirm("Bạn có chắc muốn xóa sinh viên này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminUser/students/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không xóa được sinh viên.");
      alert("Đã xóa sinh viên!");
      await fetchStudents();
    } catch (error) {
      console.error("Error:", error);
      alert("Không xóa được sinh viên: " + error.message);
    }
  }

  // Xuất danh sách sinh viên sang Excel
  // Xuất danh sách sinh viên sang Excel
  function exportStudents() {
    const filteredStudents = getFilteredStudents();
    const worksheetData = [["Danh sách sinh viên - Hệ thống Sinh viên HUTECH"], [], ["#", "Mã SV", "Họ và tên", "Email", "Khoa", "Lớp", "Trạng thái"]];
    filteredStudents.forEach((student, index) => {
      const department = departments.find(d => d.id === student.departmentId);
      worksheetData.push([index + 1, student.username, student.fullName, student.email, department ? department.name : "Chưa có", student.classCode || "", student.locked ? "Khóa" : "Hoạt động"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachSinhVien");
    XLSX.writeFile(workbook, "danh_sach_sinh_vien.xlsx");
  }

  // Nhập danh sách sinh viên từ Excel
  // Nhập danh sách sinh viên từ Excel
  async function importStudents(event) {
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
          header: ["Username", "FullName", "Email", "DepartmentId", "ClassCode"],
          skipHeader: true
        });
        if (rows.length === 0) {
          alert("File Excel trống hoặc định dạng không đúng.");
          return;
        }
        const studentsToImport = rows.map(row => ({
          username: row.Username?.toString(),
          fullName: row.FullName?.toString(),
          email: row.Email?.toString(),
          roleId: 3,
          departmentId: parseInt(row.DepartmentId) || null,
          classCode: row.ClassCode?.toString() || ""
        })).filter(student => student.username && student.fullName && student.email && student.departmentId && departments.some(d => d.id === student.departmentId) && student.classCode);
        if (studentsToImport.length === 0) {
          alert("Không có dữ liệu hợp lệ trong file Excel. Đảm bảo có Username, FullName, Email, DepartmentId hợp lệ, ClassCode.");
          return;
        }
        const usernameSet = new Set();
        const duplicateUsernames = [];
        for (const student of studentsToImport) {
          if (usernameSet.has(student.username)) {
            duplicateUsernames.push(student.username);
          } else {
            usernameSet.add(student.username);
          }
        }
        if (duplicateUsernames.length > 0) {
          alert(`File Excel chứa Username trùng lặp: ${duplicateUsernames.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        const existingDuplicates = studentsToImport.filter(student => isUsernameDuplicate(student.username)).map(student => student.username);
        if (existingDuplicates.length > 0) {
          alert(`Username đã tồn tại trong hệ thống: ${existingDuplicates.join(", ")}. Vui lòng sửa trước khi nhập.`);
          return;
        }
        try {
          const response = await fetch(`${API_URL}/api/AdminUser/students/import`, {
            method: "POST",
            headers: {
              "Accept": "*/*",
              "Content-Type": "application/json",
              "Authorization": `Bearer ${localStorage.getItem("token")}`
            },
            credentials: "include",
            body: JSON.stringify(studentsToImport)
          });
          if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || "Không nhập được danh sách sinh viên.");
          }
          const result = await response.json();
          alert(`Đã nhập ${result.successCount} sinh viên thành công. Thất bại: ${result.failedCount}. ${result.errors.length > 0 ? "Lỗi: " + result.errors.join("; ") : ""}`);
          await fetchStudents();
        } catch (error) {
          console.error("Import error:", error);
          alert("Không nhập được danh sách sinh viên: " + error.message);
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

  // Navbar Functions (unchanged)
  // Navbar Functions (unchanged)
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
  function toggleDropdown(event) {
    event.preventDefault();
    const dropdown = event.target.closest(".dropdown-menu-wrapper").querySelector(".dropdown-content");
    dropdown.style.display = dropdown.style.display === "none" ? "block" : "none";
  }

  // Tải dữ liệu khi trang được load
  // Tải dữ liệu khi trang được load
  env.ready(async () => {
    try {
      await loadUserProfile();
      await loadDepartments();
      await fetchStudents();
    } catch (error) {
      console.error("Error loading students:", error);
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
      importStudents(event);
    },
    event6: function (event) {
      exportStudents();
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
      sortTable("classCode");
    },
    event13: function (event) {
      sortTable("locked");
    },
    event14: function (event) {
      addStudent();
    },
    event15: function (event) {
      saveEditStudent();
    }
  };
}

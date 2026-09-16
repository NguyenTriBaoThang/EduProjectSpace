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
  // File: wwwroot/js/admin_grading.js
  // Mục đích: Xử lý logic giao diện và gọi API cho trang quản lý hội đồng.
  // Hỗ trợ chức năng: 
  //   19: Admin - Thành lập hội đồng chấm điểm

  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let councils = [];
  let lecturers = [];
  let semesters = [];
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
        name: "name",
        weight: 0.4
      }, {
        name: "semesterName",
        weight: 0.3
      }, {
        name: "members.fullName",
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
        if (Array.isArray(value)) {
          return value.map(item => removeVietnameseTones(item.fullName || ""));
        }
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

  // Ghi chú: Lấy danh sách kỳ học
  // Ghi chú: Lấy danh sách kỳ học
  async function loadSemesters() {
    try {
      const response = await fetch(`${API_URL}/api/AdminSemester`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.status === 401) {
        throw new Error("Bạn không có quyền truy cập. Vui lòng đăng nhập lại.");
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Lỗi tải danh sách kỳ học: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      semesters = JSON.parse(text);
      if (!Array.isArray(semesters)) {
        throw new Error("Dữ liệu kỳ học không hợp lệ.");
      }
      populateSemesterOptions("semesterFilter", "");
      populateSemesterOptions("gradingSemester", "");
      populateSemesterOptions("editGradingSemester", "");
    } catch (error) {
      console.error("Lỗi khi lấy danh sách kỳ học:", error);
      throw error;
    }
  }

  // Ghi chú: Populate dropdown kỳ học
  // Ghi chú: Populate dropdown kỳ học
  function populateSemesterOptions(elementId, selectedId) {
    const select = document.getElementById(elementId);
    select.innerHTML = env.html(elementId === "semesterFilter" ? "<option value=\"\">📅 Kỳ học</option>" : "");
    semesters.forEach(semester => {
      select.innerHTML += env.html(`<option value="${semester.id}" ${String(selectedId) === String(semester.id) ? "selected" : ""}>${semester.name}</option>`);
    });
  }

  // Ghi chú: Lấy danh sách giảng viên
  // Ghi chú: Lấy danh sách giảng viên
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
      if (response.status === 401) {
        throw new Error("Bạn không có quyền truy cập. Vui lòng đăng nhập lại.");
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Lỗi tải danh sách giảng viên: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      lecturers = JSON.parse(text);
      if (!Array.isArray(lecturers)) {
        throw new Error("Dữ liệu giảng viên không hợp lệ.");
      }
      populateLecturerCheckboxes("lecturerCheckboxes", []);
      populateLecturerCheckboxes("editLecturerCheckboxes", []);
    } catch (error) {
      console.error("Lỗi khi lấy danh sách giảng viên:", error);
      throw error;
    }
  }

  // Ghi chú: Populate checkbox và select vai trò cho giảng viên
  // Ghi chú: Populate checkbox và select vai trò cho giảng viên
  function populateLecturerCheckboxes(containerId, selectedMembers) {
    const container = document.getElementById(containerId);
    container.innerHTML = env.html("");
    lecturers.forEach(lecturer => {
      const member = selectedMembers.find(m => String(m.lecturerId) === String(lecturer.id));
      const div = document.createElement("div");
      div.className = "form-check d-flex align-items-center gap-2";
      div.innerHTML = env.html(`
                    <input type="checkbox" id="${containerId}_lecturer${lecturer.id}" class="form-check-input" 
                        value="${lecturer.id}" ${member ? "checked" : ""}>
                    <label class="form-check-label" for="${containerId}_lecturer${lecturer.id}">${lecturer.fullName}</label>
                    <select class="form-select form-select-sm w-auto" id="${containerId}_role${lecturer.id}" 
                        ${member ? "" : "disabled"}>
                        <option value="Chủ tịch" ${member && member.role === "Chủ tịch" ? "selected" : ""}>Chủ tịch</option>
                        <option value="Thư ký" ${member && member.role === "Thư ký" ? "selected" : ""}>Thư ký</option>
                        <option value="Thành viên" ${member && member.role === "Thành viên" ? "selected" : ""}>Thành viên</option>
                    </select>
                `);
      container.appendChild(div);

      // Ghi chú: Enable/disable select khi checkbox thay đổi
      const checkbox = div.querySelector(`#${containerId}_lecturer${lecturer.id}`);
      const select = div.querySelector(`#${containerId}_role${lecturer.id}`);
      env.listen(checkbox, "change", () => {
        select.disabled = !checkbox.checked;
      });
    });
  }

  // Ghi chú: Navbar Functions
  // Ghi chú: Navbar Functions
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
    icon.classList.replace(sidebar.classList.contains("collapsed") ? "bi-list" : "bi-layout-sidebar-inset", sidebar.classList.contains("collapsed") ? "bi-layout-sidebar-inset" : "bi-list");
  }

  // Ghi chú: Lấy danh sách hội đồng từ API
  // Ghi chú: Lấy danh sách hội đồng từ API
  async function loadCouncils() {
    try {
      const response = await fetch(`${API_URL}/api/AdminDefenseCommittees`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.status === 401) {
        alert("Bạn không có quyền truy cập. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Lỗi tải danh sách hội đồng: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      councils = JSON.parse(text);
      if (!Array.isArray(councils)) {
        throw new Error("Dữ liệu hội đồng không hợp lệ.");
      }
      fuse = createFuseIndex(councils); // Tạo chỉ mục Fuse.js
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi lấy danh sách hội đồng:", error);
      alert("Không thể tải danh sách hội đồng: " + error.message);
    }
  }

  // Ghi chú: Lọc và sắp xếp hội đồng
  // Ghi chú: Lọc và sắp xếp hội đồng
  function getFilteredCouncils() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const semesterFilter = document.getElementById("semesterFilter").value;

    // Tìm kiếm bằng Fuse.js
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : councils;

    // Lọc theo kỳ học
    filtered = filtered.filter(council => semesterFilter === "" || String(council.semesterId) === String(semesterFilter));

    // Sắp xếp nếu có
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "members" ? a[sortColumn].map(m => m.fullName).join(", ") : a[sortColumn];
        let valueB = sortColumn === "members" ? b[sortColumn].map(m => m.fullName).join(", ") : b[sortColumn];
        valueA = valueA ? valueA.toLowerCase() : "";
        valueB = valueB ? valueB.toLowerCase() : "";
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Ghi chú: Hiển thị bảng hội đồng
  // Ghi chú: Hiển thị bảng hội đồng
  function displayTable(page) {
    const filteredCouncils = getFilteredCouncils();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredCouncils.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Không tìm thấy hội đồng nào.</td></tr>");
    } else {
      paginatedData.forEach((council, index) => {
        const memberDisplay = council.members.map(m => `${m.fullName} (${m.role})`).join(", ");
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${council.name}</td>
                            <td>${council.semesterName}</td>
                            <td style="max-width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" 
                                title="${memberDisplay}">${memberDisplay}</td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editGrading(council.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteGrading(council.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredCouncils.length);
  }

  // Ghi chú: Thiết lập phân trang
  // Ghi chú: Thiết lập phân trang
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

  // Ghi chú: Thêm hội đồng
  // Ghi chú: Thêm hội đồng
  async function addGrading() {
    const form = document.getElementById("addGradingForm");
    if (form.checkValidity()) {
      const members = [];
      document.querySelectorAll("#lecturerCheckboxes .form-check-input:checked").forEach(checkbox => {
        const lecturerId = parseInt(checkbox.value);
        const role = document.getElementById(`lecturerCheckboxes_role${lecturerId}`).value;
        members.push({
          lecturerId,
          role
        });
      });
      if (members.length === 0) {
        alert("Vui lòng chọn ít nhất một giảng viên!");
        return;
      }
      const request = {
        name: document.getElementById("gradingName").value,
        semesterId: parseInt(document.getElementById("gradingSemester").value),
        members: members
      };
      try {
        const response = await fetch(`${API_URL}/api/AdminDefenseCommittees`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(request)
        });
        if (response.status === 401) {
          alert("Bạn không có quyền tạo hội đồng. Vui lòng đăng nhập lại.");
          env.navigate("/font-end/login/login.html");
          return;
        }
        if (!response.ok) {
          const errorText = await response.text();
          throw new Error(`Không thể tạo hội đồng: ${errorText || response.statusText}`);
        }
        alert("Đã thêm hội đồng: " + request.name);
        bootstrap.Modal.getInstance(document.getElementById("addGradingModal")).hide();
        form.reset();
        await loadCouncils();
      } catch (error) {
        console.error("Lỗi khi thêm hội đồng:", error);
        alert("Không thể thêm hội đồng: " + error.message);
      }
    } else {
      form.reportValidity();
    }
  }

  // Ghi chú: Sửa hội đồng
  // Ghi chú: Sửa hội đồng
  async function editGrading(id) {
    try {
      const response = await fetch(`${API_URL}/api/AdminDefenseCommittees/${id}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.status === 401) {
        alert("Bạn không có quyền truy cập. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Hội đồng không tồn tại: ${errorText || response.statusText}`);
      }
      const council = await response.json();
      document.getElementById("editGradingId").value = council.id;
      document.getElementById("editGradingName").value = council.name;
      document.getElementById("editGradingSemester").value = council.semesterId;
      populateLecturerCheckboxes("editLecturerCheckboxes", council.members);
      const modal = new bootstrap.Modal(document.getElementById("editGradingModal"));
      modal.show();
    } catch (error) {
      console.error("Lỗi khi tải hội đồng:", error);
      alert("Không thể tải hội đồng: " + error.message);
    }
  }

  // Ghi chú: Lưu hội đồng đã sửa
  // Ghi chú: Lưu hội đồng đã sửa
  async function saveEditGrading() {
    const id = parseInt(document.getElementById("editGradingId").value);
    const members = [];
    document.querySelectorAll("#editLecturerCheckboxes .form-check-input:checked").forEach(checkbox => {
      const lecturerId = parseInt(checkbox.value);
      const role = document.getElementById(`editLecturerCheckboxes_role${lecturerId}`).value;
      members.push({
        lecturerId,
        role
      });
    });
    if (members.length === 0) {
      alert("Vui lòng chọn ít nhất một giảng viên!");
      return;
    }
    const request = {
      name: document.getElementById("editGradingName").value,
      semesterId: parseInt(document.getElementById("editGradingSemester").value),
      members: members
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminDefenseCommittees/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(request)
      });
      if (response.status === 401) {
        alert("Bạn không có quyền sửa hội đồng. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể cập nhật hội đồng: ${errorText || response.statusText}`);
      }
      alert("Đã cập nhật hội đồng: " + request.name);
      bootstrap.Modal.getInstance(document.getElementById("editGradingModal")).hide();
      await loadCouncils();
    } catch (error) {
      console.error("Lỗi khi cập nhật hội đồng:", error);
      alert("Không thể cập nhật hội đồng: " + error.message);
    }
  }

  // Ghi chú: Xóa hội đồng
  // Ghi chú: Xóa hội đồng
  async function deleteGrading(id) {
    if (confirm("Bạn có chắc muốn xóa hội đồng này không?")) {
      try {
        const response = await fetch(`${API_URL}/api/AdminDefenseCommittees/${id}`, {
          method: "DELETE",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (response.status === 401) {
          alert("Bạn không có quyền xóa hội đồng. Vui lòng đăng nhập lại.");
          env.navigate("/font-end/login/login.html");
          return;
        }
        if (!response.ok) {
          const errorText = await response.text();
          throw new Error(`Không thể xóa hội đồng: ${errorText || response.statusText}`);
        }
        alert("Đã xóa hội đồng!");
        await loadCouncils();
      } catch (error) {
        console.error("Lỗi khi xóa hội đồng:", error);
        alert("Không thể xóa hội đồng: " + error.message);
      }
    }
  }

  // Ghi chú: Xuất Excel
  // Ghi chú: Xuất Excel
  function exportGrading() {
    const filteredCouncils = getFilteredCouncils();
    const worksheetData = [["Danh sách hội đồng chấm điểm - Hệ thống Sinh viên HUTECH"], [], ["#", "Tên hội đồng", "Kỳ học", "Thành viên"]];
    filteredCouncils.forEach((council, index) => {
      const memberDisplay = council.members.map(m => `${m.fullName} (${m.role})`).join(", ");
      worksheetData.push([index + 1, council.name, council.semesterName, memberDisplay]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachHoiDong");
    XLSX.writeFile(workbook, "danh_sach_hoi_dong.xlsx");
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

  // Ghi chú: Khởi chạy
  // Ghi chú: Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await Promise.all([loadSemesters(), loadLecturers(), loadCouncils()]);
    } catch (error) {
      console.error("Error loading grading page:", error);
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
      exportGrading();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      filterTable();
    },
    event6: function (event) {
      sortTable("name");
    },
    event7: function (event) {
      sortTable("semesterName");
    },
    event8: function (event) {
      sortTable("members");
    },
    event9: function (event) {
      addGrading();
    },
    event10: function (event) {
      saveEditGrading();
    }
  };
}

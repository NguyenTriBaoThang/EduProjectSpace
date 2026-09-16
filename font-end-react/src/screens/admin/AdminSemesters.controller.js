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
        weight: 1.0
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

  // Lấy danh sách kỳ học từ API
  // Lấy danh sách kỳ học từ API
  async function fetchSemesters() {
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
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể lấy dữ liệu kỳ học: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      semesters = JSON.parse(text);
      fuse = createFuseIndex(semesters); // Tạo chỉ mục Fuse.js
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi lấy dữ liệu:", error);
      throw error;
    }
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredSemesters() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const statusFilter = document.getElementById("statusFilter").value;

    // Tìm kiếm bằng Fuse.js
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : semesters;

    // Lọc theo trạng thái
    if (statusFilter) {
      filtered = filtered.filter(semester => semester.status === statusFilter);
    }

    // Sắp xếp nếu có
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "startDate" || sortColumn === "endDate") {
          valueA = new Date(valueA);
          valueB = new Date(valueB);
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
    const filteredSemesters = getFilteredSemesters();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredSemesters.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy kỳ học nào.</td></tr>");
    } else {
      paginatedData.forEach((semester, index) => {
        const statusClass = semester.status === "Hoạt động" ? "bg-success" : "bg-danger";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${semester.name}</td>
                            <td>${new Date(semester.startDate).toLocaleDateString("vi-VN")}</td>
                            <td>${new Date(semester.endDate).toLocaleDateString("vi-VN")}</td>
                            <td><span class="badge ${statusClass}">${semester.status}</span></td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editSemester(semester.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteSemester(semester.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredSemesters.length);
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

  // Thêm kỳ học
  // Thêm kỳ học
  async function addSemester() {
    const form = document.getElementById("addSemesterForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const startDate = new Date(document.getElementById("semesterStartDate").value + "T00:00:00Z");
    const endDate = new Date(document.getElementById("semesterEndDate").value + "T00:00:00Z");
    const newSemester = {
      name: document.getElementById("semesterName").value,
      startDate: startDate.toISOString(),
      endDate: endDate.toISOString()
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminSemester`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(newSemester)
      });
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể thêm kỳ học: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      const addedSemester = JSON.parse(text);
      semesters.push(addedSemester);
      fuse = createFuseIndex(semesters); // Cập nhật chỉ mục Fuse.js
      alert("Đã thêm kỳ học: " + addedSemester.name);
      bootstrap.Modal.getInstance(document.getElementById("addSemesterModal")).hide();
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi thêm kỳ học:", error);
      alert(error.message);
    }
  }

  // Sửa kỳ học
  // Sửa kỳ học
  function editSemester(id) {
    const semester = semesters.find(s => s.id === id);
    if (semester) {
      document.getElementById("editSemesterId").value = semester.id;
      document.getElementById("editSemesterName").value = semester.name;
      document.getElementById("editSemesterStartDate").value = new Date(semester.startDate).toISOString().split("T")[0];
      document.getElementById("editSemesterEndDate").value = new Date(semester.endDate).toISOString().split("T")[0];
      new bootstrap.Modal(document.getElementById("editSemesterModal")).show();
    }
  }
  async function saveEditSemester() {
    const id = parseInt(document.getElementById("editSemesterId").value);
    const startDate = new Date(document.getElementById("editSemesterStartDate").value + "T00:00:00Z");
    const endDate = new Date(document.getElementById("editSemesterEndDate").value + "T00:00:00Z");
    const updatedSemester = {
      id: id,
      name: document.getElementById("editSemesterName").value,
      startDate: startDate.toISOString(),
      endDate: endDate.toISOString()
    };
    try {
      const response = await fetch(`${API_URL}/api/AdminSemester/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(updatedSemester)
      });
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể cập nhật kỳ học: ${errorText || response.statusText}`);
      }
      const index = semesters.findIndex(s => s.id === id);
      semesters[index] = {
        ...semesters[index],
        ...updatedSemester
      };
      fuse = createFuseIndex(semesters); // Cập nhật chỉ mục Fuse.js
      alert("Đã cập nhật kỳ học: " + updatedSemester.name);
      bootstrap.Modal.getInstance(document.getElementById("editSemesterModal")).hide();
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi cập nhật kỳ học:", error);
      alert(error.message);
    }
  }

  // Xóa kỳ học
  // Xóa kỳ học
  async function deleteSemester(id) {
    if (!confirm("Bạn có chắc muốn xóa kỳ học này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/AdminSemester/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || `Không thể xóa kỳ học: ${response.statusText}`);
      }
      semesters = semesters.filter(s => s.id !== id);
      fuse = createFuseIndex(semesters); // Cập nhật chỉ mục Fuse.js
      alert("Đã xóa kỳ học!");
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi xóa kỳ học:", error);
      alert(error.message); // Hiển thị thông báo lỗi từ server
    }
  }

  // Xuất danh sách kỳ học sang Excel
  // Xuất danh sách kỳ học sang Excel
  async function exportSemesters() {
    try {
      const response = await fetch(`${API_URL}/api/AdminSemester/export`, {
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
        throw new Error(`Không thể xuất danh sách kỳ học: ${errorText || response.statusText}`);
      }
      const blob = await response.blob();
      const url = window.env.objectUrl(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = "danh_sach_ky_hoc.xlsx";
      document.body.appendChild(a);
      a.click();
      a.remove();
      window.URL.revokeObjectURL(url);
    } catch (error) {
      console.error("Lỗi khi xuất danh sách:", error);
      alert(error.message);
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
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await fetchSemesters();
    } catch (error) {
      console.error("Error loading semesters:", error);
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
      exportSemesters();
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
      sortTable("startDate");
    },
    event8: function (event) {
      sortTable("endDate");
    },
    event9: function (event) {
      sortTable("status");
    },
    event10: function (event) {
      addSemester();
    },
    event11: function (event) {
      saveEditSemester();
    }
  };
}

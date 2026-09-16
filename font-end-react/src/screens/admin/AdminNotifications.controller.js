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
  env.listen(document, "DOMContentLoaded", () => {
    $("#notificationUserId").select2({
      placeholder: "Chọn tài khoản",
      allowClear: true,
      width: "100%"
    });
    $("#notificationGroupId").select2({
      placeholder: "Chọn nhóm",
      allowClear: true,
      width: "100%"
    });
  });
  let notifications = [];
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let fuse = null;
  function removeVietnameseTones(str) {
    if (!str) return "";
    return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/đ/g, "d").replace(/Đ/g, "D").toLowerCase();
  }
  function createFuseIndex(data) {
    return new Fuse(data, {
      keys: [{
        name: "title",
        weight: 0.6
      }, {
        name: "content",
        weight: 0.4
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
  async function loadUsersAndGroups() {
    try {
      const userResponse = await fetch(`${API_URL}/api/Notifications/users`, {
        headers: {
          "Authorization": `Bearer ${localStorage.getItem("token")}`,
          "Accept": "*/*"
        },
        credentials: "include"
      });
      if (!userResponse.ok) throw new Error("Không thể tải danh sách người dùng.");
      const users = await userResponse.json();
      const userSelect = document.getElementById("notificationUserId");
      userSelect.innerHTML = env.html(users.map(user => `<option value="${user.id}">${user.fullName} (${user.email})</option>`).join(""));
      const groupResponse = await fetch(`${API_URL}/api/Notifications/groups`, {
        headers: {
          "Authorization": `Bearer ${localStorage.getItem("token")}`,
          "Accept": "*/*"
        },
        credentials: "include"
      });
      if (!groupResponse.ok) throw new Error("Không thể tải danh sách nhóm.");
      const groups = await groupResponse.json();
      const groupSelect = document.getElementById("notificationGroupId");
      groupSelect.innerHTML = env.html(groups.map(group => `<option value="${group.id}">${group.name}</option>`).join(""));
    } catch (error) {
      console.error("Lỗi khi tải danh sách người dùng/nhóm:", error);
      alert("Không thể tải danh sách: " + error.message);
    }
  }
  env.listen(document.getElementById("addNotificationModal"), "shown.bs.modal", loadUsersAndGroups);
  async function loadNotifications() {
    try {
      const response = await fetch(`${API_URL}/api/Notifications`, {
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
        throw new Error(`Lỗi tải danh sách thông báo: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      const data = JSON.parse(text);
      notifications = Array.isArray(data.notifications) ? data.notifications : [];
      notifications = notifications.map(notification => ({
        ...notification,
        createdAt: notification.createdAt ? new Date(notification.createdAt).toLocaleString("vi-VN", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit"
        }) : "Chưa gửi",
        firstViewedAt: notification.firstViewedAt ? new Date(notification.firstViewedAt).toLocaleString("vi-VN", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit"
        }) : "Chưa xem"
      }));
      fuse = createFuseIndex(notifications);
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi khi lấy thông báo:", error);
      alert("Không thể tải thông báo: " + error.message);
    }
  }
  async function fetchRecentNotifications() {
    try {
      const response = await fetch(`${API_URL}/api/Notifications/recent`, {
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
        throw new Error(`Lỗi tải thông báo gần đây: ${errorText || response.statusText}`);
      }
      const text = await response.text();
      if (!text) {
        throw new Error("Phản hồi từ server trống.");
      }
      const data = JSON.parse(text);
      const recentNotifications = Array.isArray(data) ? data : [];
      displayRecentNotifications(recentNotifications);
    } catch (error) {
      console.error("Lỗi khi lấy thông báo gần đây:", error);
      alert("Không thể tải thông báo gần đây: " + error.message);
    }
  }
  function displayRecentNotifications(data) {
    const container = document.getElementById("recentNotifications");
    container.innerHTML = env.html("");
    if (data.length === 0) {
      container.innerHTML = env.html("<p class=\"text-muted mb-0\">Không có thông báo gần đây.</p>");
    } else {
      container.innerHTML = env.html(`
                    <div id="notificationCarousel" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                        <div class="carousel-inner"></div>
                        <button class="carousel-control-prev bg-dark bg-opacity-50 rounded-3 p-3" type="button" data-bs-target="#notificationCarousel" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next bg-dark bg-opacity-50 rounded-3 p-3" type="button" data-bs-target="#notificationCarousel" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                `);
      const carouselInner = container.querySelector(".carousel-inner");
      data.slice(0, 3).forEach((notification, index) => {
        const isActive = index === 0 ? "active" : "";
        const iconColor = ["text-primary", "text-success", "text-warning"][index % 3];
        const buttonColor = ["btn-primary", "btn-success", "btn-warning"][index % 3];
        carouselInner.innerHTML += env.html(`
                        <div class="carousel-item ${isActive}">
                            <div class="d-flex flex-column align-items-center justify-content-center p-3 bg-light rounded-3 border border-light-subtle text-center">
                                <i class="bi bi-bell-fill ${iconColor} fs-3 mb-2"></i>
                                <h6 class="mb-1 fw-bold text-dark fs-6">${notification.title}</h6>
                                <p class="mb-2 text-muted small">${notification.content || "Vui lòng kiểm tra chi tiết thông báo."}</p>
                                <div class="d-flex align-items-center justify-content-center mb-2">
                                    <small class="text-muted">
                                        <i class="bi bi-calendar-event me-1"></i>
                                        Ngày gửi: ${notification.createdAt ? new Date(notification.createdAt).toLocaleDateString("vi-VN") : "Chưa gửi"}
                                    </small>
                                </div>
                                <button class="btn ${buttonColor} btn-sm py-1 px-3" data-page-click="${env.bind(function (event) {
          viewNotificationDetails(notification.id);
        })}">Xem chi tiết</button>
                            </div>
                        </div>
                    `);
      });
    }
  }
  function viewNotificationDetails(id) {
    const notification = notifications.find(n => n.id === id);
    if (notification) {
      document.getElementById("viewNotificationTitle").textContent = notification.title;
      document.getElementById("viewNotificationContent").textContent = notification.content || "Không có nội dung.";
      document.getElementById("viewNotificationRecipient").textContent = notification.userId ? "Cá nhân" : notification.groupId ? "Nhóm" : notification.recipientType || "Tất cả";
      document.getElementById("viewNotificationDate").textContent = notification.createdAt !== "Chưa gửi" ? notification.createdAt : "Chưa gửi";
      document.getElementById("viewNotificationStatus").textContent = notification.status === "SENT" ? "Đã gửi" : notification.status === "PENDING" ? "Chưa gửi" : "Thất bại";
      document.getElementById("viewNotificationIsFirstViewed").textContent = notification.isFirstViewed ? "Đã xem" : "Chưa xem";
      document.getElementById("viewNotificationFirstViewedAt").textContent = notification.firstViewedAt !== "Chưa xem" ? notification.firstViewedAt : "Chưa xem";
      const modal = new bootstrap.Modal(document.getElementById("viewNotificationModal"));
      modal.show();
    }
  }
  function getFilteredNotifications() {
    const searchText = removeVietnameseTones(document.getElementById("searchInputFuse").value);
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = searchText ? fuse.search(searchText).map(result => result.item) : notifications;
    filtered = filtered.filter(notification => statusFilter === "" || notification.status === statusFilter);
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn] || "";
        let valueB = b[sortColumn] || "";
        if (sortColumn === "createdAt" || sortColumn === "firstViewedAt") {
          valueA = a[sortColumn] === "Chưa gửi" || a[sortColumn] === "Chưa xem" ? "" : new Date(a[sortColumn].replace(/(\d{2})\/(\d{2})\/(\d{4}), (\d{2}):(\d{2})/, "$3-$2-$1T$4:$5:00"));
          valueB = b[sortColumn] === "Chưa gửi" || b[sortColumn] === "Chưa xem" ? "" : new Date(b[sortColumn].replace(/(\d{2})\/(\d{2})\/(\d{4}), (\d{2}):(\d{2})/, "$3-$2-$1T$4:$5:00"));
        } else if (sortColumn === "recipient") {
          valueA = a.userId ? "Cá nhân" : a.groupId ? "Nhóm" : a.recipientType || "Tất cả";
          valueB = b.userId ? "Cá nhân" : b.groupId ? "Nhóm" : b.recipientType || "Tất cả";
        } else if (sortColumn === "isFirstViewed") {
          valueA = a.isFirstViewed;
          valueB = b.isFirstViewed;
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredNotifications = getFilteredNotifications();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredNotifications.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"9\" class=\"text-center\">Không tìm thấy thông báo nào.</td></tr>");
    } else {
      paginatedData.forEach((notification, index) => {
        const statusClass = notification.status === "SENT" ? "bg-success" : notification.status === "PENDING" ? "bg-warning" : "bg-danger";
        const recipient = notification.userId ? "Cá nhân" : notification.groupId ? "Nhóm" : notification.recipientType || "Tất cả";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${notification.title}</td>
                            <td style="max-width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="${notification.content}">${notification.content}</td>
                            <td>${recipient}</td>
                            <td>${notification.createdAt}</td>
                            <td><span class="badge ${statusClass}">${notification.status === "SENT" ? "Đã gửi" : notification.status === "PENDING" ? "Chưa gửi" : "Thất bại"}</span></td>
                            <td>${notification.isFirstViewed ? "Đã xem" : "Chưa xem"}</td>
                            <td>${notification.firstViewedAt}</td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editNotification(notification.id);
        })}"><i class="bi bi-pencil"></i></button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteNotification(notification.id);
        })}"><i class="bi bi-trash"></i></button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredNotifications.length);
  }
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
  function toggleRecipientFields(isEdit = false) {
    const recipientType = (isEdit ? document.getElementById("editNotificationRecipient") : document.getElementById("notificationRecipient")).value;
    const userIdField = isEdit ? document.getElementById("editUserIdField") : document.getElementById("userIdField");
    const groupIdField = isEdit ? document.getElementById("editGroupIdField") : document.getElementById("groupIdField");
    const userIdInput = isEdit ? document.getElementById("editNotificationUserId") : document.getElementById("notificationUserId");
    const groupIdInput = isEdit ? document.getElementById("editNotificationGroupId") : document.getElementById("notificationGroupId");
    userIdField.style.display = recipientType === "Individual" ? "block" : "none";
    groupIdField.style.display = recipientType === "Group" ? "block" : "none";
    if (isEdit) {
      const id = parseInt(document.getElementById("editNotificationId").value);
      const notification = notifications.find(n => n.id === id);
      userIdInput.value = recipientType === "Individual" ? notification?.userId || "" : "";
      groupIdInput.value = recipientType === "Group" ? notification?.groupId || "" : "";
    }
  }
  function toggleEmailConfig() {
    const enableEmail = document.getElementById("enableEmail").checked;
    document.getElementById("emailConfig").style.display = enableEmail ? "block" : "none";
  }
  async function addNotification(event) {
    event.preventDefault();
    const form = document.getElementById("addNotificationForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const recipientType = document.getElementById("notificationRecipient").value;
    const userSelect = document.getElementById("notificationUserId");
    const groupSelect = document.getElementById("notificationGroupId");
    const notification = {
      title: document.getElementById("notificationTitle")?.value || "",
      content: document.getElementById("notificationContent")?.value || "",
      recipientType: recipientType,
      userIds: recipientType === "Individual" ? Array.from(userSelect.selectedOptions).map(opt => parseInt(opt.value)) : [],
      groupIds: recipientType === "Group" ? Array.from(groupSelect.selectedOptions).map(opt => parseInt(opt.value)) : [],
      type: document.getElementById("notificationType")?.value || "Web",
      status: "SENT"
    };
    if (!notification.title || !notification.content || !notification.recipientType) {
      alert("Vui lòng điền đầy đủ các trường bắt buộc.");
      return;
    }
    if (recipientType === "Individual" && !notification.userIds.length) {
      alert("Vui lòng chọn ít nhất một tài khoản.");
      return;
    }
    if (recipientType === "Group" && !notification.groupIds.length) {
      alert("Vui lòng chọn ít nhất một nhóm.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/Notifications`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify({
          notificationDto: notification
        })
      });
      const responseText = await response.text();
      console.log("Add notification response:", response.status, responseText);
      if (response.status === 401) {
        alert("Bạn không có quyền tạo thông báo. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        throw new Error(`Không thể tạo thông báo: ${responseText || response.statusText}`);
      }
      alert("Đã gửi thông báo: " + notification.title);
      bootstrap.Modal.getInstance(document.getElementById("addNotificationModal")).hide();
      form.reset();
      await loadNotifications();
    } catch (error) {
      console.error("Lỗi khi tạo thông báo:", error);
      alert("Không thể tạo thông báo: " + error.message);
    }
  }
  function editNotification(id) {
    const notification = notifications.find(n => n.id === id);
    if (notification) {
      document.getElementById("editNotificationId").value = notification.id;
      document.getElementById("editNotificationTitle").value = notification.title;
      document.getElementById("editNotificationContent").value = notification.content;
      document.getElementById("editNotificationRecipient").value = notification.recipientType || "All";
      document.getElementById("editNotificationStatus").value = notification.status;
      document.getElementById("editNotificationType").value = notification.type;
      toggleRecipientFields(true);
      const modal = new bootstrap.Modal(document.getElementById("editNotificationModal"));
      modal.show();
    }
  }
  async function saveEditNotification() {
    const form = document.getElementById("editNotificationForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const id = parseInt(document.getElementById("editNotificationId").value);
    const notification = {
      id: id,
      title: document.getElementById("editNotificationTitle").value,
      content: document.getElementById("editNotificationContent").value,
      recipientType: document.getElementById("editNotificationRecipient").value,
      userId: document.getElementById("editNotificationUserId").value ? parseInt(document.getElementById("editNotificationUserId").value) : null,
      groupId: document.getElementById("editNotificationGroupId").value ? parseInt(document.getElementById("editNotificationGroupId").value) : null,
      status: document.getElementById("editNotificationStatus").value,
      type: document.getElementById("editNotificationType").value
    };
    try {
      const response = await fetch(`${API_URL}/api/Notifications/${id}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(notification)
      });
      console.log("Edit notification response:", response.status, await response.text());
      if (response.status === 401) {
        alert("Bạn không có quyền sửa thông báo. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể cập nhật thông báo: ${errorText || response.statusText}`);
      }
      alert("Đã cập nhật thông báo: " + notification.title);
      bootstrap.Modal.getInstance(document.getElementById("editNotificationModal")).hide();
      await loadNotifications();
    } catch (error) {
      console.error("Lỗi khi cập nhật thông báo:", error);
      alert("Không thể cập nhật thông báo: " + error.message);
    }
  }
  async function deleteNotification(id) {
    if (!confirm("Bạn có chắc muốn xóa thông báo này không?")) return;
    try {
      const response = await fetch(`${API_URL}/api/Notifications/${id}`, {
        method: "DELETE",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.status === 401) {
        alert("Bạn không có quyền xóa thông báo. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể xóa thông báo: ${errorText || response.statusText}`);
      }
      alert("Đã xóa thông báo!");
      await loadNotifications();
    } catch (error) {
      console.error("Lỗi khi xóa thông báo:", error);
      alert("Không thể xóa thông báo: " + error.message);
    }
  }
  function exportNotifications() {
    const filteredNotifications = getFilteredNotifications();
    const worksheetData = [["Danh sách thông báo - Hệ thống Sinh viên HUTECH"], [], ["#", "Tiêu đề", "Nội dung", "Người nhận", "Ngày gửi", "Trạng thái", "Đã xem", "Thời gian xem"]];
    filteredNotifications.forEach((notification, index) => {
      const recipient = notification.userId ? "Cá nhân" : notification.groupId ? "Nhóm" : notification.recipientType || "Tất cả";
      worksheetData.push([index + 1, notification.title, notification.content, recipient, notification.createdAt, notification.status === "SENT" ? "Đã gửi" : notification.status === "PENDING" ? "Chưa gửi" : "Thất bại", notification.isFirstViewed ? "Đã xem" : "Chưa xem", notification.firstViewedAt]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachThongBao");
    XLSX.writeFile(workbook, "danh_sach_thong_bao.xlsx");
  }
  async function saveConfig() {
    const config = {
      enableWeb: document.getElementById("enableWeb").checked,
      enableEmail: document.getElementById("enableEmail").checked,
      reminderFrequency: document.getElementById("reminderFrequency").value,
      smtpConfig: document.getElementById("enableEmail").checked ? {
        host: document.getElementById("smtpHost").value,
        port: parseInt(document.getElementById("smtpPort").value) || 587,
        username: document.getElementById("smtpUsername").value,
        password: document.getElementById("smtpPassword").value
      } : null
    };
    try {
      const response = await fetch(`${API_URL}/api/Notifications/config`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(config)
      });
      if (response.status === 401) {
        alert("Bạn không có quyền cấu hình thông báo. Vui lòng đăng nhập lại.");
        env.navigate("/font-end/login/login.html");
        return;
      }
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể lưu cấu hình: ${errorText || response.statusText}`);
      }
      alert("Đã lưu cấu hình thông báo!");
      bootstrap.Modal.getInstance(document.getElementById("configNotificationModal")).hide();
    } catch (error) {
      console.error("Lỗi khi lưu cấu hình:", error);
      alert("Không thể lưu cấu hình: " + error.message);
    }
  }
  async function loadConfig() {
    try {
      const response = await fetch(`${API_URL}/api/Notifications/config`, {
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
        throw new Error(`Không thể tải cấu hình: ${errorText || response.statusText}`);
      }
      const config = await response.json();
      document.getElementById("enableWeb").checked = config.enableWeb;
      document.getElementById("enableEmail").checked = config.enableEmail;
      document.getElementById("reminderFrequency").value = config.reminderFrequency || "none";
      if (config.smtpConfig) {
        document.getElementById("smtpHost").value = config.smtpConfig.host || "";
        document.getElementById("smtpPort").value = config.smtpConfig.port || "";
        document.getElementById("smtpUsername").value = config.smtpConfig.username || "";
        document.getElementById("smtpPassword").value = config.smtpConfig.password || "";
      }
      toggleEmailConfig();
    } catch (error) {
      console.error("Lỗi khi tải cấu hình:", error);
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
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadNotifications();
      await fetchRecentNotifications();
      await loadConfig();
      env.listen(document.getElementById("notificationRecipient"), "change", () => toggleRecipientFields());
      env.listen(document.getElementById("editNotificationRecipient"), "change", () => toggleRecipientFields(true));
      env.listen(document.getElementById("enableEmail"), "change", toggleEmailConfig);
    } catch (error) {
      console.error("Error loading notifications:", error);
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
      exportNotifications();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      filterTable();
    },
    event6: function (event) {
      sortTable("title");
    },
    event7: function (event) {
      sortTable("content");
    },
    event8: function (event) {
      sortTable("recipient");
    },
    event9: function (event) {
      sortTable("createdAt");
    },
    event10: function (event) {
      sortTable("status");
    },
    event11: function (event) {
      sortTable("isFirstViewed");
    },
    event12: function (event) {
      sortTable("firstViewedAt");
    },
    event13: function (event) {
      addNotification();
    },
    event14: function (event) {
      saveEditNotification();
    },
    event15: function (event) {
      saveConfig();
    }
  };
}

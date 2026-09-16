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

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
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

  // Cập nhật giao diện với dữ liệu từ API
  // Cập nhật giao diện với dữ liệu từ API
  async function updateDashboard() {
    try {
      const response = await fetch(`${API_URL}/api/HeadDashboard/summary`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      const summary = await response.json();
      document.getElementById("projectCount").textContent = summary.projectCount;
      document.getElementById("approvedProjects").textContent = summary.approvedProjects;
      document.getElementById("pendingProjects").textContent = summary.pendingProjects;
    } catch (error) {
      console.error("Error fetching summary:", error);
      alert("Không thể tải dữ liệu tổng quan.");
    }
    try {
      // Tải thông báo gần đây
      const notificationsResponse = await fetch(`${API_URL}/api/Notifications/recent`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!notificationsResponse.ok) {
        throw new Error(`Lỗi tải thông báo gần đây: ${notificationsResponse.status}`);
      }
      const notifications = await notificationsResponse.json();
      updateRecentNotifications(notifications);
      document.getElementById("recentNotificationsCount").textContent = notifications.length;
    } catch (error) {
      throw new Error(`Lỗi API: ${error.message}`);
    }
  }

  // Cập nhật thông báo gần đây
  // Cập nhật thông báo gần đây
  function updateRecentNotifications(notifications) {
    const list = document.getElementById("recentNotifications");
    list.innerHTML = env.html("");
    notifications.forEach(notification => {
      const li = document.createElement("li");
      li.className = "dashboard-list-group-item";
      const details = notification.title || "";
      li.innerHTML = env.html(`
                    <i class="bi bi-bell"></i>
                    <span class="dashboard-notification-title" data-full-text="${details}">${details.substring(0, 30)}...</span>
                    <span class="text-muted">${new Date(notification.createdAt).toLocaleString()}</span>
                `);
      list.appendChild(li);
    });
  }

  //Đăng xuất
  //Đăng xuất
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

  // Khởi chạy khi trang tải
  // Khởi chạy khi trang tải
  env.listen(document, "DOMContentLoaded", () => {
    // Kiểm tra token trước khi gọi API
    loadUserProfile();
    updateDashboard();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    }
  };
}

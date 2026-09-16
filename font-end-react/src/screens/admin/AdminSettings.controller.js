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
  // File: wwwroot/font-end/static/js/admin_settings.js
  // Mục đích: Xử lý logic giao diện và gọi API cho trang cài đặt hệ thống
  // Ghi chú: Tích hợp API để quản lý quyền truy cập (4.7 - Phân quyền và bảo mật)

  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";

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

  // Ghi chú: Lấy danh sách quyền từ API
  // Ghi chú: Lấy danh sách quyền từ API
  async function loadPermissions() {
    try {
      const response = await fetch(`${API_URL}/api/AdminRolePermissions`, {
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
        throw new Error(`HTTP error! Status: ${response.status}, Message: ${errorText}`);
      }
      const permissions = await response.json();
      displayPermissions(permissions);
    } catch (error) {
      console.error("Lỗi khi lấy danh sách quyền:", error);
      alert(`Không thể tải danh sách quyền: ${error.message}`);
    }
  }

  // Ghi chú: Hiển thị danh sách quyền trong bảng
  // Ghi chú: Hiển thị danh sách quyền trong bảng
  function displayPermissions(permissions) {
    const tbody = document.getElementById("permissionsTable");
    tbody.innerHTML = env.html("");
    permissions.forEach(perm => {
      const isAdmin = perm.roleId === 1;
      const isStudent = perm.roleId === 3;
      tbody.innerHTML += env.html(`
                    <tr>
                        <td>${perm.roleName}</td> <!-- Ghi chú: Lấy từ Role.Name qua API -->
                        <td><input type="checkbox" id="viewUsers_${perm.roleId}" ${isAdmin ? "checked disabled" : ""} ${perm.viewUsers ? "checked" : ""}></td>
                        <td><input type="checkbox" id="editUsers_${perm.roleId}" ${isAdmin ? "checked disabled" : isStudent ? "disabled" : ""} ${perm.editUsers ? "checked" : ""}></td>
                        <td><input type="checkbox" id="viewProjects_${perm.roleId}" ${isAdmin ? "checked disabled" : ""} ${perm.viewProjects ? "checked" : ""}></td>
                        <td><input type="checkbox" id="editProjects_${perm.roleId}" ${isAdmin ? "checked disabled" : ""} ${perm.editProjects ? "checked" : ""}></td>
                        <td><input type="checkbox" id="viewGrading_${perm.roleId}" ${isAdmin ? "checked disabled" : ""} ${perm.viewGrading ? "checked" : ""}></td>
                        <td><input type="checkbox" id="editGrading_${perm.roleId}" ${isAdmin ? "checked disabled" : isStudent ? "disabled" : ""} ${perm.editGrading ? "checked" : ""}></td>
                    </tr>
                `);
    });
  }

  // Ghi chú: Lưu cài đặt quyền
  // Ghi chú: Lưu cài đặt quyền
  async function saveSettings() {
    const permissions = [];
    document.querySelectorAll("#permissionsTable tr").forEach(row => {
      const roleId = parseInt(row.querySelector("input").id.split("_")[1]);
      const roleName = row.cells[0].textContent;
      permissions.push({
        roleId: roleId,
        roleName: roleName,
        viewUsers: document.getElementById(`viewUsers_${roleId}`).checked,
        editUsers: document.getElementById(`editUsers_${roleId}`).checked,
        viewProjects: document.getElementById(`viewProjects_${roleId}`).checked,
        editProjects: document.getElementById(`editProjects_${roleId}`).checked,
        viewGrading: document.getElementById(`viewGrading_${roleId}`).checked,
        editGrading: document.getElementById(`editGrading_${roleId}`).checked
      });
    });
    try {
      for (const perm of permissions) {
        if (perm.roleId === 1) continue; // Ghi chú: Bỏ qua Admin
        const response = await fetch(`${API_URL}/api/AdminRolePermissions/${perm.roleId}`, {
          method: "PUT",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(perm)
        });
        if (!response.ok) {
          const errorText = await response.text();
          throw new Error(`Cập nhật quyền cho vai trò ${perm.roleName} thất bại: ${errorText}`);
        }
      }
      alert("Đã lưu cài đặt quyền truy cập!");
      loadPermissions(); // Ghi chú: Tải lại để cập nhật giao diện
    } catch (error) {
      console.error("Lỗi khi lưu quyền:", error);
      alert(`Lỗi khi lưu cài đặt quyền: ${error.message}`);
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

  // Ghi chú: Hàm toggle sidebar
  // Ghi chú: Hàm toggle sidebar
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let content = document.querySelector(".content");
    let icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.replace(sidebar.classList.contains("collapsed") ? "bi-list" : "bi-layout-sidebar-inset", sidebar.classList.contains("collapsed") ? "bi-layout-sidebar-inset" : "bi-list");
  }
  env.ready(async () => {
    try {
      await loadUserProfile();
      await loadPermissions();
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
      logout();
    },
    event3: function (event) {
      saveSettings();
    }
  };
}

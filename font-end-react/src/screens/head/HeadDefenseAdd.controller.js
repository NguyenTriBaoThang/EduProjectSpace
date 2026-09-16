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

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const projectIdFromUrl = urlParams.get("projectId");
  const courseId = urlParams.get("courseId");
  const semester = urlParams.get("semester");
  const classId = urlParams.get("classId");

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

  // Load danh sách dự án chưa có lịch bảo vệ
  // Load danh sách dự án chưa có lịch bảo vệ
  async function populateDefenseProjects() {
    if (!courseId || !semester || !classId) {
      document.querySelector(".card-body").innerHTML = env.html("<p class='text-center text-muted'>Vui lòng chọn một học phần từ danh sách để thêm lịch bảo vệ.</p>");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadDefenseSchedule/projects?courseId=${courseId}&semester=${semester}&classId=${classId}`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to load projects");
      const projects = await response.json();
      const select = document.getElementById("defenseProjectId");
      select.innerHTML = env.html("<option value=\"\">Chọn nhóm</option>");
      projects.forEach(project => {
        select.innerHTML += env.html(`<option value="${project.id}" data-name="${project.name}" data-members="${project.members}" data-status="${project.status}">${project.projectId} - ${project.name}</option>`);
      });
      if (projectIdFromUrl) {
        select.value = projectIdFromUrl;
        updateGroupInfo(projectIdFromUrl);
      }
      env.listen(select, "change", () => {
        const selectedOption = select.options[select.selectedIndex];
        updateGroupInfo(select.value, selectedOption);
      });
      document.getElementById("backToDefenseLink").href = `head_defense.html?courseId=${courseId}&semester=${semester}&classId=${classId}`;
    } catch (error) {
      console.error("Error loading projects:", error);
      alert("Không thể tải danh sách dự án.");
    }
  }

  // Cập nhật thông tin nhóm khi chọn dự án
  // Cập nhật thông tin nhóm khi chọn dự án
  function updateGroupInfo(projectId, option) {
    if (projectId && option) {
      document.getElementById("defenseName").value = option.dataset.name || "";
      document.getElementById("defenseMembers").value = option.dataset.members || "";
      document.getElementById("defenseStatus").value = option.dataset.status || "";
    } else {
      document.getElementById("defenseName").value = "";
      document.getElementById("defenseMembers").value = "";
      document.getElementById("defenseStatus").value = "";
    }
  }

  // Load danh sách meeting
  // Load danh sách meeting
  async function populateMeetings() {
    try {
      const response = await fetch(`${API_URL}/api/HeadDefenseSchedule/meeting`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to load meetings");
      const meetings = await response.json();
      const select = document.getElementById("meetingId");
      meetings.forEach(meeting => {
        select.innerHTML += env.html(`<option value="${meeting.meetingId}" data-link="${meeting.link}">${meeting.meetingId} (${meeting.link || "No link"})</option>`);
      });
      env.listen(select, "change", () => {
        const selectedOption = select.options[select.selectedIndex];
        document.getElementById("meetingLink").value = selectedOption.dataset.link || "";
      });
    } catch (error) {
      console.error("Error loading meetings:", error);
      alert("Không thể tải danh sách meeting.");
    }
  }

  // Lưu lịch bảo vệ
  // Lưu lịch bảo vệ
  async function saveDefense() {
    const form = document.getElementById("addDefenseForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const defenseData = {
      projectId: parseInt(document.getElementById("defenseProjectId").value),
      startTime: document.getElementById("startTime").value,
      endTime: document.getElementById("endTime").value,
      room: document.getElementById("defenseRoom").value,
      meetingId: document.getElementById("meetingId").value || null
    };
    try {
      const response = await fetch(`${API_URL}/api/HeadDefenseSchedule`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(defenseData)
      });
      if (response.ok) {
        alert("Đã thêm lịch bảo vệ thành công!");
        env.navigate(`head_defense.html?courseId=${courseId}&semester=${semester}&classId=${classId}`);
      } else {
        const error = await response.json();
        alert("Lỗi: " + error.message);
      }
    } catch (error) {
      console.error("Error saving defense schedule:", error);
      alert("Đã xảy ra lỗi khi lưu lịch bảo vệ.");
    }
  }

  // Hủy thêm lịch
  // Hủy thêm lịch
  function cancelAdd() {
    env.navigate(`head_defense.html?courseId=${courseId}&semester=${semester}&classId=${classId}`);
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", () => {
    populateDefenseProjects();
    populateMeetings();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      saveDefense();
    },
    event2: function (event) {
      cancelAdd();
    }
  };
}

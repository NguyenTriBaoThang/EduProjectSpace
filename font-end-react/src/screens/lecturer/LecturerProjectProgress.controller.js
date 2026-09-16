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
  let project = null;
  let tasks = [];

  // Get projectId from URL
  // Get projectId from URL
  const urlParams = new URLSearchParams(window.location.search);
  const projectId = urlParams.get("projectId");

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Load project details
  // Load project details
  async function loadProjectDetails() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerCourses/projects/${projectId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to load project");
      project = await response.json();
      document.getElementById("projectId").textContent = project.projectId;
      document.getElementById("projectName").textContent = project.name;
      document.getElementById("groupName").textContent = project.groupName;
      document.getElementById("groupLeader").textContent = project.students.find(s => s.isLeader)?.fullName || "Chưa có";
      document.getElementById("groupMembers").textContent = project.students.map(s => s.fullName).join(", ");
    } catch (error) {
      console.error("Error loading project:", error);
      alert("Không thể tải thông tin đồ án");
    }
  }

  // Load tasks
  // Load tasks
  async function loadTasks() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerCourses/projects/${projectId}/tasks`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Failed to load tasks");
      tasks = await response.json();
      renderTasks();
    } catch (error) {
      console.error("Error loading tasks:", error);
      alert("Không thể tải danh sách nhiệm vụ");
    }
  }

  // Render tasks table
  // Render tasks table
  function renderTasks() {
    const tableBody = document.getElementById("tasksTable");
    tableBody.innerHTML = env.html(tasks.length > 0 ? tasks.map((task, index) => `
                <tr>
                    <td>${index + 1}</td>
                    <td>${task.title}</td>
                    <td>${task.description || "Không có mô tả"}</td>
                    <td>
                        <ul class="submission-list">
                            ${task.submissions.length > 0 ? task.submissions.map(s => `
                                <li><a href="${API_URL}/api/File/files/${s.filePath}" target="_blank">${s.filePath.split("/").pop()} (${s.submittedBy} - ${project.students.find(st => st.username === s.submittedBy)?.fullName || "Unknown"})</a></li>
                            `).join("") : "Chưa nộp"}
                        </ul>
                    </td>
                    <td>${task.deadline ? new Date(task.deadline).toLocaleDateString("vi-VN") : "-"}</td>
                    <td>${task.feedback || "Chưa có"}</td>
                    <td>
                        <button class="btn btn-sm btn-primary btn-action-spacing" data-page-click="${env.bind(function (event) {
      openFeedbackModal(String(projectId), task.id, String(task.title), String(task.feedback || ""));
    })}">
                            <i class="bi bi-chat-left-text"></i> Phản hồi
                        </button>
                        <button class="btn btn-sm btn-warning" data-page-click="${env.bind(function (event) {
      openEditModal(String(projectId), task.id, String(task.title), String(task.description || ""), String(task.deadline || ""), String(task.status), task.submissions);
    })}">
                            <i class="bi bi-pencil"></i> Sửa
                        </button>
                    </td>
                </tr>
            `).join("") : "<tr><td colspan=\"7\" class=\"text-center\">Chưa có nhiệm vụ</td></tr>");
  }

  // Open feedback modal
  // Open feedback modal
  function openFeedbackModal(projectId, taskId, title, feedback) {
    document.getElementById("feedbackProjectId").value = projectId;
    document.getElementById("feedbackTaskId").value = taskId;
    document.getElementById("feedbackTaskTitle").value = title;
    document.getElementById("feedbackComment").value = feedback;
    new bootstrap.Modal(document.getElementById("feedbackModal")).show();
  }

  // Save feedback
  // Save feedback
  async function saveFeedback() {
    const projectId = document.getElementById("feedbackProjectId").value;
    const taskId = document.getElementById("feedbackTaskId").value;
    const feedback = document.getElementById("feedbackComment").value;
    try {
      const response = await fetch(`${API_URL}/api/LecturerCourses/projects/${projectId}/tasks/${taskId}/feedback`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify({
          feedback
        })
      });
      if (!response.ok) throw new Error("Failed to save feedback");
      alert("Phản hồi đã được lưu!");
      bootstrap.Modal.getInstance(document.getElementById("feedbackModal")).hide();
      await loadTasks();
    } catch (error) {
      console.error("Error saving feedback:", error);
      alert("Lỗi khi lưu phản hồi");
    }
  }

  // Open edit modal
  // Open edit modal
  function openEditModal(projectId, taskId, title, description, deadline, status, submissions) {
    document.getElementById("editProjectId").value = projectId;
    document.getElementById("editTaskId").value = taskId;
    document.getElementById("editTaskTitle").value = title;
    document.getElementById("editDescription").value = description;
    document.getElementById("editDueDate").value = deadline ? new Date(deadline).toISOString().split("T")[0] : "";
    document.getElementById("editStatus").value = status;
    const submissionList = document.getElementById("submissionList");
    submissionList.innerHTML = env.html("");
    if (submissions.length > 0) {
      submissions.forEach(s => addSubmissionField(s.filePath, s.submittedBy));
    } else {
      addSubmissionField();
    }
    new bootstrap.Modal(document.getElementById("editTaskModal")).show();
  }

  // Add submission field
  // Add submission field
  function addSubmissionField(filePath = "", submittedBy = "") {
    const submissionList = document.getElementById("submissionList");
    const div = document.createElement("div");
    div.classList.add("input-group", "mb-2");
    div.innerHTML = env.html(`
                <input type="text" class="form-control submission-file" value="${filePath}" placeholder="Tên tệp (VD: baocao.pdf)" required>
                <input type="text" class="form-control submission-submitted-by" value="${submittedBy}" placeholder="Mã sinh viên nộp" required>
                <button type="button" class="btn btn-danger" data-page-click="${env.bind(function (event) {
      this.parentElement.remove();
    })}">Xóa</button>
            `);
    submissionList.appendChild(div);
  }

  // Save task edit
  // Save task edit
  async function saveTaskEdit() {
    const form = document.getElementById("editTaskForm");
    if (form.checkValidity()) {
      const projectId = document.getElementById("editProjectId").value;
      const taskId = document.getElementById("editTaskId").value;
      const taskDto = {
        id: taskId,
        title: document.getElementById("editTaskTitle").value,
        description: document.getElementById("editDescription").value,
        deadline: document.getElementById("editDueDate").value,
        status: document.getElementById("editStatus").value,
        submissions: []
      };
      const submissionEntries = document.querySelectorAll(".input-group");
      submissionEntries.forEach(entry => {
        const filePath = entry.querySelector(".submission-file").value;
        const submittedBy = entry.querySelector(".submission-submitted-by").value;
        if (filePath && submittedBy) {
          taskDto.submissions.push({
            filePath,
            submittedBy
          });
        }
      });
      try {
        const response = await fetch(`${API_URL}/api/LecturerCourses/projects/${projectId}/tasks/${taskId}`, {
          method: "PUT",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(taskDto)
        });
        if (!response.ok) throw new Error("Failed to save task");
        alert("Nhiệm vụ đã được cập nhật!");
        bootstrap.Modal.getInstance(document.getElementById("editTaskModal")).hide();
        await loadTasks();
      } catch (error) {
        console.error("Error saving task:", error);
        alert("Lỗi khi lưu nhiệm vụ");
      }
    } else {
      form.reportValidity();
    }
  }

  // Export to Excel
  // Export to Excel
  function exportProgress() {
    try {
      const data = tasks.map((t, index) => ({
        STT: index + 1,
        "Nhiệm vụ": t.title,
        "Mô tả": t.description || "Không có",
        "Tệp báo cáo": t.submissions.map(s => `${s.filePath.split("/").pop()} (${s.submittedBy} - ${project.students.find(st => st.username === s.submittedBy)?.fullName || "Unknown"})`).join(", "),
        "Hạn nộp": t.deadline ? new Date(t.deadline).toLocaleDateString("vi-VN") : "-",
        "Phản hồi": t.feedback || "Chưa có"
      }));
      const worksheet = XLSX.utils.json_to_sheet([{
        "Chi tiết tiến độ đồ án": `Mã đồ án: ${project?.projectId || "N/A"}`
      }, {
        "Chi tiết tiến độ đồ án": `Tên đồ án: ${project?.name || "N/A"}`
      }, {
        "Chi tiết tiến độ đồ án": `Nhóm: ${project?.groupName || "N/A"}`
      }, {
        "Chi tiết tiến độ đồ án": `Nhóm trưởng: ${project?.students?.find(s => s.isLeader)?.fullName || "N/A"}`
      }, {
        "Chi tiết tiến độ đồ án": `Thành viên: ${project?.students?.map(s => s.fullName).join(", ") || "N/A"}`
      }, {}, ...data]);
      const workbook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(workbook, worksheet, "Tasks");
      XLSX.writeFile(workbook, `tien_do_do_an_${projectId}.xlsx`);
    } catch (error) {
      console.error("Error exporting to Excel:", error);
      alert("Lỗi khi xuất Excel");
    }
  }

  // Toggle sidebar
  // Toggle sidebar
  function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    if (sidebar.classList.contains("collapsed")) {
      icon.classList.replace("bi-list", "bi-layout-sidebar-inset");
    } else {
      icon.classList.replace("bi-layout-sidebar-inset", "bi-list");
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

  // Navbar functions
  // Navbar functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("/font-end/lecturer/lecturer_notifications.html");
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

  // Initialize
  // Initialize
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadProjectDetails();
      await loadTasks();
    } catch (error) {
      console.error("Lỗi khi tải bảng điều khiển:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      logout();
    }
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      exportProgress();
    },
    event3: function (event) {
      env.navigate("/font-end/lecturer/lecturer_projects.html");
    },
    event4: function (event) {
      saveFeedback();
    },
    event5: function (event) {
      addSubmissionField();
    },
    event6: function (event) {
      saveTaskEdit();
    }
  };
}

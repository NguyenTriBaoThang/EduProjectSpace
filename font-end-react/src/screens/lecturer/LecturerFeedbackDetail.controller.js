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
  // Cấu hình API
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let token = localStorage.getItem("token");
  let fullNameLecturer = null;
  let projectDetail = null;

  // Lấy projectId từ URL
  // Lấy projectId từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const projectId = urlParams.get("projectId");

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

  // Toggle Sidebar
  // Toggle Sidebar
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let content = document.querySelector(".content");
    let icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      fullNameLecturer = user.fullName;
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Tải chi tiết đồ án từ API
  // Tải chi tiết đồ án từ API
  async function loadProjectDetail() {
    if (!projectId) {
      document.querySelector(".card-content").innerHTML = env.html("<p>Không tìm thấy đồ án.</p>");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerFeedback/projects/${encodeURIComponent(projectId)}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể tải chi tiết đồ án");
      projectDetail = await response.json();
      displayProjectInfo();
      displaySubmissions();
    } catch (e) {
      console.error("Lỗi khi tải chi tiết đồ án:", e);
      document.querySelector(".card-content").innerHTML = env.html("<p>Không tìm thấy đồ án.</p>");
    }
  }

  // Hiển thị thông tin đồ án
  // Hiển thị thông tin đồ án
  function displayProjectInfo() {
    if (projectDetail) {
      const statusClass = projectDetail.status === "APPROVED" ? "text-success" : projectDetail.status === "REJECTED" ? "text-danger" : "text-warning";
      document.getElementById("projectId").textContent = projectDetail.projectId;
      document.getElementById("projectName").textContent = projectDetail.name;
      document.getElementById("groupName").textContent = projectDetail.groupName;
      document.getElementById("groupLeader").textContent = projectDetail.groupLeader;
      document.getElementById("groupMembers").textContent = projectDetail.groupMembers;
      document.getElementById("projectStatus").innerHTML = env.html(`<span class="${statusClass}"><strong>${projectDetail.status === "APPROVED" ? "Đã duyệt" : projectDetail.status === "REJECTED" ? "Từ chối" : "Chưa duyệt"}</strong></span>`);
      document.getElementById("backLink").href = `lecturer_feedback.html?courseId=${projectDetail.courseId}`;
    }
  }

  // Hiển thị bảng bài nộp theo nhóm Task
  // Hiển thị bảng bài nộp theo nhóm Task
  function displaySubmissions() {
    const taskSubmissionGroupsContainer = document.getElementById("taskSubmissionGroups");
    const taskSubmissionGroups = projectDetail?.taskSubmissionGroups || [];
    if (taskSubmissionGroups.length === 0) {
      taskSubmissionGroupsContainer.innerHTML = env.html("<p class=\"text-center\">Chưa có bài nộp</p>");
      return;
    }
    taskSubmissionGroupsContainer.innerHTML = env.html(taskSubmissionGroups.map(group => `
                <div class="mb-4">
                    <h5 class="fw-bold">${group.taskTitle}</h5>
                    <p class="text-muted">${group.taskDescription || "Không có mô tả"}</p>
                    <table class="table-custom table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Tên báo cáo</th>
                                <th>Tệp báo cáo</th>
                                <th>Ngày nộp</th>
                                <th>Người nộp</th>
                                <th>Phản hồi</th>
                            </tr>
                        </thead>
                        <tbody>
                            ${group.submissions.length > 0 ? group.submissions.map(s => `
                                <tr>
                                    <td>${s.title}</td>
                                    <td>
                                        ${s.fileName === null ? "<li>Chưa nộp</li>" : `<li>
                                                <a href="${API_URL}/api/File/files/${s.fileName}" target="_blank">${s.fileName.split("/").pop()}</a>
                                            </li>`}
                                    </td>
                                    <td>${s.submittedAt}</td>
                                    <td>${s.submittedBy}</td>
                                    <td><textarea class="form-control feedback-text" data-submission-id="${s.submissionId}" rows="2">${s.feedback}</textarea></td>
                                </tr>
                            `).join("") : "<tr><td colspan=\"5\" class=\"text-center\">Chưa có bài nộp cho nhiệm vụ này</td></tr>"}
                        </tbody>
                    </table>
                </div>
            `).join(""));
  }

  // Lưu phản hồi
  // Lưu phản hồi
  async function saveFeedback() {
    if (!projectDetail) return;
    const feedbacks = Array.from(document.querySelectorAll(".feedback-text")).map(input => ({
      submissionId: parseInt(input.getAttribute("data-submission-id")),
      content: input.value.trim()
    }));
    try {
      const response = await fetch(`${API_URL}/api/LecturerFeedback/projects/${encodeURIComponent(projectId)}/feedback`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(feedbacks)
      });
      if (!response.ok) throw new Error("Không thể gửi phản hồi");
      alert(`Đã gửi phản hồi cho đồ án ${projectDetail.name}`);
      await loadProjectDetail();
      //window.location.href = document.getElementById("backLink").href;
    } catch (e) {
      console.error("Lỗi khi gửi phản hồi:", e);
      alert("Đã xảy ra lỗi khi gửi phản hồi.");
    }
  }

  // Quay lại
  // Quay lại
  function goBack() {
    env.navigate(document.getElementById("backLink").href);
  }

  // Xuất phản hồi sang Excel
  // Xuất phản hồi sang Excel
  function exportFeedback() {
    if (!projectDetail) return;
    const worksheetData = [["Chi tiết phản hồi - Hệ thống Sinh viên HUTECH"], [`Giảng viên hướng dẫn: ${fullNameLecturer.fullName}`], [], ["Mã đồ án", "Tên đồ án", "Tên nhóm", "Nhóm trưởng", "Thành viên", "Trạng thái"], [projectDetail.projectId, projectDetail.name, projectDetail.groupName, projectDetail.groupLeader, projectDetail.groupMembers, projectDetail.status], [], ["Tệp báo cáo", "Mô tả", "Ngày nộp", "Người nộp", "Phản hồi"]];
    projectDetail.submissions.forEach(s => {
      worksheetData.push([s.fileName, s.description, s.submittedAt, s.submittedBy, s.feedback || ""]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietPhanHoi");
    XLSX.writeFile(workbook, `phan_hoi_${projectDetail.projectId}.xlsx`);
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

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadProjectDetail();
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
      exportFeedback();
    },
    event3: function (event) {
      goBack();
    },
    event4: function (event) {
      saveFeedback();
    }
  };
}

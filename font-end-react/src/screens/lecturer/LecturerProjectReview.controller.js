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
  let fullNameLecturer = "";

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const projectId = urlParams.get("projectId");
  const courseId = urlParams.get("courseId");
  function goBack() {
    env.navigate(`/font-end/lecturer/lecturer_project_review.html?courseId=${courseId}`);
  }

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/lecturer/lecturer_notifications.html"));
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
        throw new Error("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
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

  // Tải chi tiết đồ án để đánh giá
  // Tải chi tiết đồ án để đánh giá
  async function loadProjectReview() {
    if (!projectId) {
      alert("Không tìm thấy mã đồ án.");
      env.navigate(`/font-end/lecturer/lecturer_project_review.html?projectId=${projectId}&courseId=${courseId}`);
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerReview/projects/${encodeURIComponent(projectId)}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Không thể tải chi tiết đồ án: ${response.statusText}`);
      const project = await response.json();
      document.getElementById("projectCode").value = project.projectId || "";
      document.getElementById("projectName").value = project.name || "";
      document.getElementById("groupName").value = project.groupName || "";
      document.getElementById("groupLeader").value = project.groupLeader || "";
      document.getElementById("groupMembers").value = project.groupMembers || "";
      const criteriaTable = document.getElementById("criteriaTable");
      criteriaTable.innerHTML = env.html("");
      project.studentGrades.forEach(student => {
        student.criteriaGrades.forEach((criteria, index) => {
          const row = `
                            <tr>
                                ${index === 0 ? `<td rowspan="${student.criteriaGrades.length}">${student.fullName || ""}</td>` : ""}
                                <td>${criteria.criteriaName || ""}</td>
                                <td>${criteria.weight || 0}</td>
                                <td>
                                    <input type="number" class="criteria-score" data-student-id="${student.studentId}" data-criteria-id="${criteria.criteriaId}" value="${criteria.score != null ? criteria.score : ""}" class="form-control" min="0" max="10" step="0.1" required>
                                </td>
                                ${index === 0 ? `<td rowspan="${student.criteriaGrades.length}" id="totalScore-${student.studentId}">${student.totalScore != null ? student.totalScore.toFixed(2) : "Chưa đủ tiêu chí"}</td>` : ""}
                                ${index === 0 ? `<td rowspan="${student.criteriaGrades.length}"><select class="form-select" data-student-id="${student.studentId}"><option value="Chưa duyệt" ${!student.comment || student.comment === "Chưa duyệt" ? "selected" : ""}>Chưa duyệt</option><option value="Đã duyệt" ${student.comment === "Đã duyệt" ? "selected" : ""}>Đã duyệt</option></select></td>` : ""}
                            </tr>
                        `;
          criteriaTable.innerHTML += env.html(row);
        });
      });

      // Tự động cập nhật Điểm tổng khi thay đổi điểm
      document.querySelectorAll(".criteria-score").forEach(input => {
        env.listen(input, "input", () => {
          const studentId = parseInt(input.getAttribute("data-student-id"));
          calculateTotalScore(studentId);
        });
      });
      const progressTable = document.getElementById("progressTable");
      progressTable.innerHTML = env.html("");
      if (project.tasks && project.tasks.length) {
        project.tasks.forEach(task => {
          progressTable.innerHTML += env.html(`
                            <tr>
                                <td>${task.title || "N/A"}</td>
                                <td>${task.description || "Chưa có mô tả"}</td>
                                <td><ul class="submission-list">${task.submissions.map(sub => `<li><a href="${API_URL}/api/File/files/${sub.filePath}" target="_blank">${sub.fileName || sub.filePath.split("/").pop() || "N/A"} (${sub.submittedById} - ${sub.fullName || "Unknown"})</a></li>`).join("")}</ul></td>
                                <td>${task.dueDate || "N/A"}</td>
                                <td><ul class="submission-list">${task.submissions.map(sub => `<li><a href="${API_URL}/api/File/files/${sub.filePath}" target="_blank">${sub.fileName || (sub.filePath ? sub.filePath.split("/").pop() : "N/A")} (${sub.submittedById} - ${sub.fullName || "Unknown"})</a><br><em>Phản hồi: ${sub.feedback || "Chưa có phản hồi"}</em></li>`).join("")}</ul></td>
                            </tr>
                        `);
        });
      } else {
        progressTable.innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Chưa có tiến độ</td></tr>");
      }

      // Lấy lịch sử từ GradeVersions
      const historyResponse = await fetch(`${API_URL}/api/LecturerReview/projects/${encodeURIComponent(projectId)}/history`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
        credentials: "include"
      });
      if (historyResponse.ok) {
        const history = await historyResponse.json();
        const historyDiv = document.getElementById("reviewHistory");
        historyDiv.innerHTML = env.html(history.map(h => `Sinh viên: ${h.fullName}, Version: Phiên bản ${h.versionNumber}, TotalScore: ${h.totalScore?.toFixed(2) || "Chưa có"}, Nhận xét: ${h.comment || ""}, Ngày: ${new Date(h.createdAt).toLocaleString("vi-VN")}`).join("<br/>") || "Chưa có lịch sử đánh giá");
      }
    } catch (e) {
      alert("Lỗi khi tải chi tiết đồ án: " + e.message);
      env.navigate(`/font-end/lecturer/lecturer_project_review.html?projectId=${projectId}&courseId=${courseId}`);
    }
  }
  function calculateTotalScore(studentId) {
    const scores = document.querySelectorAll(`.criteria-score[data-student-id="${studentId}"]`);
    const weights = document.querySelectorAll(`td:nth-child(3)[rowspan="${scores.length}"]`);
    let total = 0;
    let weightSum = 0;
    scores.forEach((scoreInput, index) => {
      const score = parseFloat(scoreInput.value) || 0;
      const weight = parseFloat(weights[index].textContent) || 0;
      total += score * weight;
      weightSum += weight;
    });
    const totalScoreCell = document.getElementById(`totalScore-${studentId}`);
    totalScoreCell.textContent = weightSum > 0 ? (total / weightSum).toFixed(2) : "Chưa đủ tiêu chí";
  }
  async function saveReview() {
    const form = document.createElement("form");
    const projectId = urlParams.get("projectId");
    const studentGrades = [];
    const studentIds = new Set();
    document.querySelectorAll(".criteria-score").forEach(input => {
      const studentId = parseInt(input.getAttribute("data-student-id"));
      const criteriaId = parseInt(input.getAttribute("data-criteria-id"));
      const score = parseFloat(input.value);
      if (isNaN(score) || score < 0 || score > 10) {
        alert(`Điểm cho sinh viên ID ${studentId} không hợp lệ (phải từ 0 đến 10).`);
        return;
      }
      if (!studentIds.has(studentId)) {
        studentIds.add(studentId);
        const statusSelect = document.querySelector(`select[data-student-id="${studentId}"]`);
        const status = statusSelect ? statusSelect.value : "Chưa duyệt";
        studentGrades.push({
          studentId: studentId,
          criteriaGrades: [],
          comment: status // Sử dụng trạng thái thay vì comment tự do
        });
      }
      const studentGrade = studentGrades.find(sg => sg.studentId === studentId);
      studentGrade.criteriaGrades.push({
        criteriaId,
        score
      });
    });
    if (studentGrades.length === 0) {
      alert("Không có dữ liệu điểm để lưu.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerReview/projects/${encodeURIComponent(projectId)}/grades`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
        credentials: "include",
        body: JSON.stringify({
          studentGrades
        })
      });
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Không thể lưu điểm: ${errorText || response.statusText}`);
      }
      alert("Đã lưu điểm thành công");
      env.navigate(`/font-end/lecturer/lecturer_project_review.html?projectId=${encodeURIComponent(projectId)}&courseId=${courseId}`);
    } catch (e) {
      console.error("Lỗi khi lưu điểm:", e);
      alert("Lỗi khi lưu điểm: " + e.message);
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
          "Authorization": `Bearer ${token}`
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
    env.navigate("/login/login.html", true);
  }

  // Khởi tạo
  // Khởi tạo
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadProjectReview();
    } catch (error) {
      console.error("Lỗi khi tải trang:", error);
      alert(`Không thể tải dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
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
      goBack();
    },
    event3: function (event) {
      saveReview();
    },
    event4: function (event) {
      env.navigate(`/lecturer/project-review?projectId=${encodeURIComponent(projectId)}&courseId=${encodeURIComponent(courseId)}`);
    }
  };
}

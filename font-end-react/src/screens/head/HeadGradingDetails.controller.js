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
  const urlParams = new URLSearchParams(window.location.search);
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");
  const selectedGroupId = parseInt(urlParams.get("groupId"));
  let groupDetails = null;

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/head_notifications.html"));
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

  // Hiển thị toast
  // Hiển thị toast
  function showToast(message, isError = false) {
    const toast = new bootstrap.Toast(document.getElementById("toast"));
    const toastBody = document.querySelector(".toast-body");
    toastBody.textContent = message;
    toastBody.className = `toast-body ${isError ? "bg-danger text-white" : "bg-success text-white"}`;
    toast.show();
  }
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_HEAD") {
        throw new Error("Không có quyền Trưởng bộ môn hoặc chưa đăng nhập.");
      }
      document.getElementById("headName").textContent = user.fullName || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      showToast(`Lỗi khi tải thông tin người dùng: ${error.message}`, true);
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function fetchGroupDetails() {
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseGrading/group-details?groupId=${selectedGroupId}&courseId=${encodeURIComponent(selectedCourseId)}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}`, {
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải chi tiết nhóm: ${response.status}`);
      const data = await response.json();
      groupDetails = data;
      return data;
    } catch (error) {
      showToast(`Lỗi tải chi tiết nhóm: ${error.message}`, true);
      return null;
    }
  }
  async function viewCode(filePath, fileName) {
    try {
      const response = await fetch(`${API_URL}/api/File/files/${filePath}`, {
        headers: {
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải tệp: ${response.status}`);
      const modal = new bootstrap.Modal(document.getElementById("codeModal"));
      const modalContent = document.getElementById("modalContent");
      if (fileName.endsWith(".pdf")) {
        const blob = await response.blob();
        const url = env.objectUrl(blob);
        const frame = document.createElement('iframe');
        frame.src = url;
        frame.title = 'Xem PDF';
        frame.style.cssText = 'width:100%;height:70vh;border:0';
        modalContent.replaceChildren(frame);
        document.getElementById("codeModalLabel").textContent = `Xem tệp PDF: ${fileName}`;
      } else {
        const code = await response.text();
        modalContent.innerHTML = env.html(`<pre><code id="codeContent"></code></pre>`);
        const codeContent = document.getElementById("codeContent");
        codeContent.textContent = code;
        codeContent.className = fileName.endsWith(".java") ? "language-java" : "language-csharp";
        document.getElementById("codeModalLabel").textContent = `Xem mã nguồn: ${fileName}`;
        Prism.highlightElement(codeContent);
      }
      document.getElementById("downloadCodeLink").href = `${API_URL}/api/File/files/${filePath}?download=true`;
      modal.show();
    } catch (error) {
      showToast(`Lỗi tải tệp: ${error.message}`, true);
    }
  }
  function displayGradingDetails(data) {
    if (!data) {
      document.querySelector(".card-body").innerHTML = env.html("<p class='text-center text-muted'>Không tìm thấy thông tin nhóm.</p>");
      return;
    }
    document.getElementById("gradeGroupId").value = data.groupId;
    document.getElementById("gradeGroupName").value = data.groupName;
    document.getElementById("gradeProjectId").value = data.projectId;
    document.getElementById("gradeProjectName").value = data.projectName;
    document.getElementById("gradeMembers").value = data.members.map(m => m.fullName).join(", ");
    document.getElementById("gradeLecturer").value = data.lecturer;
    document.getElementById("councilFeedback").value = data.grades.councilFeedback;
    const reportFiles = document.getElementById("reportFiles");
    reportFiles.innerHTML = env.html(data.grades.reportFiles && data.grades.reportFiles.length > 0 ? data.grades.reportFiles.map(file => {
      const fileName = file.filePath.split("/").pop();
      const isCodeFile = fileName.endsWith(".java") || fileName.endsWith(".cs");
      const isZipFile = fileName.endsWith(".zip");
      const isPdfFile = fileName.endsWith(".pdf");
      const demoUrl = isZipFile ? "https://samplewebapp-thang20250623.azurewebsites.net" : null;
      return `
                            <li>
                                <a href="#" ${isCodeFile || isPdfFile ? `data-page-click="${env.bind(function (event) {
        viewCode(String(file.filePath), String(fileName));
      })}"` : isZipFile ? `href="${demoUrl}" target="_blank"` : `href="${API_URL}/api/File/files/${file.filePath}" target="_blank"`}>
                                    ${fileName} (${file.studentCode} - ${file.fullName})
                                </a>
                                <a href="${API_URL}/api/File/files/${file.filePath}?download=true" title="Tải xuống"><i class="bi bi-download"></i></a>
                            </li>`;
    }).join("") : "<li>Chưa có tệp</li>");
    document.getElementById("gradeApproval").value = data.grades.approved;
    const memberGrades = document.getElementById("memberGrades");
    memberGrades.innerHTML = env.html(data.members.map(member => `
                    <tr>
                        <td>${member.fullName}</td>
                        <td>${member.totalScore !== null ? member.totalScore.toFixed(1) : "Chưa chấm"}</td>
                        <td>${member.councilFeedback}</td>
                    </tr>
                `).join(""));
    document.getElementById("backToGradingLink").href = `/font-end/head/head_grading_courses.html?courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}`;
  }
  async function saveGradeApproval() {
    const form = document.getElementById("gradeFormDetails");
    if (form.checkValidity()) {
      const groupId = parseInt(document.getElementById("gradeGroupId").value);
      const approval = document.getElementById("gradeApproval").value;
      const councilFeedback = document.getElementById("councilFeedback").value;
      try {
        const response = await fetch(`${API_URL}/api/HeadCourseGrading/approve-grade`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          body: JSON.stringify({
            groupId: groupId,
            courseId: selectedCourseId,
            semester: selectedSemester,
            facultyCode: selectedFacultyCode,
            councilFeedback: councilFeedback
          }),
          credentials: "include"
        });
        if (!response.ok) {
          const errorData = await response.json();
          throw new Error(errorData.message || `Lỗi cập nhật trạng thái: ${response.status}`);
        }
        const result = await response.json();
        showToast(`Đã cập nhật trạng thái duyệt điểm cho nhóm ${document.getElementById("gradeGroupName").value}: ${approval}. Email thông báo đã được gửi.`, false);
        env.navigate(`/font-end/head/head_grading_courses.html?courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}`);
      } catch (error) {
        showToast(`Lỗi cập nhật trạng thái: ${error.message}`, true);
      }
    } else {
      form.reportValidity();
    }
  }
  function exportDetails() {
    if (!groupDetails) {
      showToast("Không có dữ liệu để xuất!", true);
      return;
    }
    const members = groupDetails.members.map(m => `${m.fullName}: Điểm tổng=${m.totalScore?.toFixed(1) || "Chưa chấm"}, Phản hồi=${m.councilFeedback}`).join("\n");
    const reportFiles = groupDetails.grades.reportFiles && groupDetails.grades.reportFiles.length > 0 ? groupDetails.grades.reportFiles.map(file => `${file.filePath.split("/").pop()} (${file.studentCode} - ${file.fullName})`).join(", ") : "Chưa có tệp";
    const worksheetData = [["Chi tiết duyệt chấm điểm - Hệ thống Sinh viên HUTECH"], [`Lớp: ${selectedCourseId} - ${selectedFacultyCode} - ${selectedSemester}`], [], ["Tên nhóm", "Mã đồ án", "Tên đồ án", "Thành viên", "GVHD", "Tệp báo cáo", "Trạng thái duyệt", "Trạng thái đồ án", "Nhận xét hội đồng"], [groupDetails.groupName, groupDetails.projectId, groupDetails.projectName, members, groupDetails.lecturer, reportFiles, groupDetails.grades.approved, groupDetails.status, groupDetails.grades.councilFeedback]];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietChamDiem");
    XLSX.writeFile(workbook, `chi_tiet_cham_diem_${groupDetails.groupName}_${selectedCourseId}_${selectedFacultyCode}_${selectedSemester}.xlsx`);
  }
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
        showToast(data.message, false);
      } else {
        showToast(`Đăng xuất thất bại: ${data.message || response.statusText}`, true);
      }
    } catch (error) {
      showToast(`Đăng xuất bị lỗi: ${error.message}`, true);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    const data = await fetchGroupDetails();
    displayGradingDetails(data);
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      exportDetails();
    },
    event3: function (event) {
      saveGradeApproval();
    }
  };
}

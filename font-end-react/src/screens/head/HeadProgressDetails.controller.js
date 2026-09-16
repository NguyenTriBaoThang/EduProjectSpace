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
  const API_URL = window.EDU_CONFIG.apiBaseUrl + ""; // Backend API URL
  // Backend API URL
  const urlParams = new URLSearchParams(window.location.search);
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");
  const selectedGroupId = parseInt(urlParams.get("groupId"));
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
    icon.classList.replace(sidebar.classList.contains("collapsed") ? "bi-list" : "bi-layout-sidebar-inset", sidebar.classList.contains("collapsed") ? "bi-layout-sidebar-inset" : "bi-list");
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
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function fetchProgressDetails() {
    try {
      const response = await fetch(`${API_URL}/api/HeadProgressCourses/details?courseId=${encodeURIComponent(selectedCourseId)}&semester=${encodeURIComponent(selectedSemester)}&facultyCode=${encodeURIComponent(selectedFacultyCode)}&groupId=${selectedGroupId}`, {
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải tiến độ: ${response.status}`);
      return await response.json();
    } catch (error) {
      console.error("Error loading progress:", error);
      alert("Không thể tải chi tiết tiến độ. Vui lòng thử lại.");
      return null;
    }
  }
  function displayProgressDetails(data) {
    if (!data) {
      document.querySelector(".card-body").innerHTML = env.html("<p>Không tìm thấy thông tin nhóm.</p>");
      document.getElementById("progressTableBody").innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy tiến độ.</td></tr>");
      return;
    }
    const dataStatus = data.status === "APPROVED" ? "Đã duyệt" : data.status === "REJECTED" ? "Từ chối" : "Chưa duyệt";
    document.getElementById("groupName").textContent = data.groupName;
    document.getElementById("projectId").textContent = data.projectId;
    document.getElementById("projectName").textContent = data.projectName;
    document.getElementById("members").textContent = data.members;
    document.getElementById("lecturer").textContent = data.lecturer;
    document.getElementById("status").textContent = dataStatus;
    const progressTableBody = document.getElementById("progressTableBody");
    progressTableBody.innerHTML = env.html(data.phases.length > 0 ? data.phases.map((p, index) => `
                <tr>
                    <td>${index + 1}</td>
                    <td>${p.phase}</td>
                    <td>${p.description}</td>
                    <td><ul class="file-list">${p.files.length > 0 ? p.files.map(file => `<li><a href="${API_URL}/api/File/files/${file.filePath}" target="_blank">${file.filePath.split("/").pop()} (${file.studentCode} - ${file.fullName})</a></li>`).join("") : "<li>Chưa nộp</li>"}</ul></td>
                    <td>${p.date}</td>
                    <td>${p.deadline}</td>
                </tr>
            `).join("") : "<tr><td colspan=\"6\" class=\"text-center\">Chưa có tiến độ</td></tr>");
    document.getElementById("backToProgressLink").href = `head_progress.html?courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}`;
  }
  function exportDetails(data) {
    if (!data) return;
    const worksheetData = [["Chi tiết tiến độ đồ án - Hệ thống Sinh viên HUTECH"], [`Lớp: ${selectedCourseId} - ${selectedFacultyCode} - ${selectedSemester}`], [`Tên nhóm: ${data.groupName}`], [`Mã đồ án: ${data.projectId}`], [`Tên đồ án: ${data.projectName}`], [`Thành viên: ${data.members}`], [`GVHD: ${data.lecturer}`], [`Trạng thái: ${data.status}`], [`Ngày xuất: ${new Date().toLocaleString("vi-VN", {
      timeZone: "Asia/Ho_Chi_Minh"
    })}`], [], ["#", "Giai đoạn", "Mô tả", "Tệp báo cáo", "Ngày nộp", "Hạn nộp"]];
    if (data.phases.length === 0) {
      worksheetData.push(["", "Chưa có tiến độ", "", "", "", ""]);
    } else {
      data.phases.forEach((p, index) => {
        worksheetData.push([index + 1, p.phase, p.description, p.files.map(file => `${file.filePath.split("/").pop()} (${file.studentCode} - ${file.fullName})`).join(", ") || "Chưa nộp", p.date, p.deadline]);
      });
    }
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietTienDo");
    XLSX.writeFile(workbook, `chi_tiet_tien_do_${data.groupName}_${selectedCourseId}_${selectedFacultyCode}_${selectedSemester}.xlsx`);
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
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    const data = await fetchProgressDetails();
    displayProgressDetails(data);
    env.listen(document.querySelector(".btn-info"), "click", () => exportDetails(data));
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
    }
  };
}

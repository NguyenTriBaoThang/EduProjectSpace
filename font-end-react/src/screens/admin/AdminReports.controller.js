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
  let reportData = {
    Summary: {},
    Students: [],
    Projects: [],
    Lecturers: []
  };
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("admin_notifications.html");
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
    icon.classList.replace(sidebar.classList.contains("collapsed") ? "bi-list" : "bi-layout-sidebar-inset", sidebar.classList.contains("collapsed") ? "bi-layout-sidebar-inset" : "bi-list");
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
  async function loadSemesters() {
    try {
      const response = await fetch(`${API_URL}/api/AdminReports/semesters`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
      const semesters = await response.json();
      const semesterFilter = document.getElementById("semesterFilter");
      semesters.forEach(sem => {
        const option = document.createElement("option");
        option.value = sem.name;
        option.textContent = sem.name;
        semesterFilter.appendChild(option);
      });
    } catch (error) {
      console.error("Lỗi khi tải kỳ học:", error);
      alert(`Không thể tải danh sách kỳ học: ${error.message}`);
    }
  }
  async function loadDepartments() {
    try {
      const response = await fetch(`${API_URL}/api/AdminReports/departments`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
      const departments = await response.json();
      const facultyFilter = document.getElementById("facultyFilter");
      departments.forEach(dep => {
        const option = document.createElement("option");
        option.value = dep.code;
        option.textContent = dep.name;
        facultyFilter.appendChild(option);
      });
    } catch (error) {
      console.error("Lỗi khi tải khoa:", error);
      alert(`Không thể tải danh sách khoa: ${error.message}`);
    }
  }
  async function updateReport() {
    const semesterFilter = document.getElementById("semesterFilter").value;
    const facultyFilter = document.getElementById("facultyFilter").value;
    try {
      const query = new URLSearchParams();
      if (semesterFilter) query.append("semesterCode", semesterFilter);
      if (facultyFilter) query.append("facultyCode", facultyFilter);
      const response = await fetch(`${API_URL}/api/AdminReports/?${query.toString()}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}, Message: ${await response.text()}`);
      reportData = await response.json();
      document.getElementById("studentCount").textContent = reportData.summary.studentCount;
      document.getElementById("approvedProjects").textContent = reportData.summary.approvedProjects;
      document.getElementById("pendingProjects").textContent = reportData.summary.pendingProjects;
      document.getElementById("lecturerCount").textContent = reportData.summary.lecturerCount;
    } catch (error) {
      console.error("Lỗi khi tải báo cáo:", error);
      alert(`Không thể tải báo cáo: ${error.message}`);
    }
  }
  function exportReport() {
    const semesterFilter = document.getElementById("semesterFilter").value;
    const facultyFilter = document.getElementById("facultyFilter").value;
    const worksheetData = [["Báo cáo thống kê - Hệ thống Sinh viên HUTECH"], ["Kỳ học:", semesterFilter || "Tất cả", "Khoa:", facultyFilter || "Tất cả"], [], ["Thống kê tổng quan"], ["Số lượng sinh viên:", reportData.summary.studentCount], ["Số đề tài đã duyệt:", reportData.summary.approvedProjects], ["Số đề tài chưa duyệt:", reportData.summary.pendingProjects], ["Số giảng viên:", reportData.summary.lecturerCount], [], ["Danh sách sinh viên"], ["Mã SV", "Họ và tên", "Lớp", "Khoa", "Kỳ học"]];
    reportData.students.forEach(student => {
      worksheetData.push([student.studentId, student.name, student.classCode, student.facultyCode, student.semesterCode]);
    });
    worksheetData.push([], ["Danh sách đề tài"], ["Mã đề tài", "Tên đề tài", "Sinh viên", "Giảng viên hướng dẫn", "Trạng thái", "Kỳ học"]);
    reportData.projects.forEach(project => {
      worksheetData.push([project.projectId, project.name, project.studentName, project.lecturerName, project.status === "APPROVED" ? "Đã duyệt đề tài" : "Chưa duyệt đề tài", project.semesterCode]);
    });
    worksheetData.push([], ["Danh sách giảng viên"], ["Mã GV", "Họ và tên", "Khoa"]);
    reportData.lecturers.forEach(lecturer => {
      worksheetData.push([lecturer.lecturerId, lecturer.name, lecturer.facultyCode]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "BaoCaoThongKe");
    XLSX.writeFile(workbook, "bao_cao_thong_ke.xlsx");
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
      await loadSemesters();
      await loadDepartments();
      await updateReport();
    } catch (error) {
      console.error("Lỗi khi tải bảng điều khiển:", error);
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
      exportReport();
    },
    event4: function (event) {
      updateReport();
    },
    event5: function (event) {
      updateReport();
    }
  };
}

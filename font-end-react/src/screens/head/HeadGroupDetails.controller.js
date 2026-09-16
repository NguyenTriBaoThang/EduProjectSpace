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
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const selectedLecturer = decodeURIComponent(urlParams.get("lecturer"));
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");
  const selectedGroupId = parseInt(urlParams.get("groupId"));

  // Đường dẫn API cơ bản
  // Đường dẫn API cơ bản
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";

  // Dữ liệu nhóm để sử dụng cho xuất Excel
  // Dữ liệu nhóm để sử dụng cho xuất Excel
  let groupDetails = null;

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/lecturer_notifications.html"));
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

  // Hàm toggle sidebar
  // Hàm toggle sidebar
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

  // Hàm lấy thông tin chi tiết nhóm từ API
  // Hàm lấy thông tin chi tiết nhóm từ API
  async function fetchGroupDetails() {
    try {
      const response = await fetch(`${API_URL}/api/HeadLecturer/groupdetails?groupId=${selectedGroupId}&lecturer=${encodeURIComponent(selectedLecturer)}&courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi: ${await response.text()}`);
      const details = await response.json();
      groupDetails = details;
      return details;
    } catch (error) {
      console.error("Lỗi khi lấy thông tin nhóm:", error);
      return null;
    }
  }

  // Hàm hiển thị chi tiết nhóm và đồ án
  // Hàm hiển thị chi tiết nhóm và đồ án
  async function displayGroupDetails() {
    const details = await fetchGroupDetails();
    if (!details) {
      document.querySelector(".group-details-container").innerHTML = env.html("<p class='text-center'>Không tìm thấy thông tin nhóm.</p>");
      return;
    }

    // Hiển thị thông tin giảng viên
    document.getElementById("lecturerName").textContent = details.lecturerName;
    document.getElementById("courseInfo").textContent = details.courseInfo;

    // Hiển thị thông tin nhóm
    document.getElementById("groupName").textContent = details.groupName;
    const membersList = document.getElementById("membersList");
    membersList.innerHTML = env.html("");
    details.members.forEach(member => {
      membersList.innerHTML += env.html(`<li class="list-group-item">${member.studentId} - ${member.studentName}</li>`);
    });

    // Hiển thị thông tin đồ án
    document.getElementById("projectName").textContent = details.projectName;
    document.getElementById("startDate").textContent = details.startDate;
    document.getElementById("endDate").textContent = details.endDate;
    document.getElementById("gradingDate").textContent = details.gradingDate;
    document.getElementById("description").textContent = details.description;

    // Hiển thị danh sách file
    const fileList = document.getElementById("fileList");
    fileList.innerHTML = env.html("");
    details.files.forEach(file => {
      if (file.filePath === "Chưa có file") {
        fileList.innerHTML += env.html(`<li>${file.filePath}</li>`);
      } else {
        fileList.innerHTML += env.html(`<li><a href="${API_URL}/api/File/files/${file.filePath}" target="_blank">${file.filePath.split("/").pop()} (${file.studentCode} - ${file.fullName})</a></li>`);
      }
    });

    // Cập nhật link quay lại
    document.getElementById("backToLecturerLink").href = `/font-end/head/head_lecturer_details.html?lecturer=${encodeURIComponent(selectedLecturer)}&courseId=${selectedCourseId}&semester=${selectedSemester}&facultyCode=${selectedFacultyCode}`;
  }

  // Hàm xuất thông tin chi tiết sang Excel
  // Hàm xuất thông tin chi tiết sang Excel
  function exportDetails() {
    if (!groupDetails) {
      alert("Không có dữ liệu để xuất!");
      return;
    }
    const worksheetData = [["Chi tiết nhóm và đồ án - Hệ thống Sinh viên HUTECH"], [`GVHD: ${groupDetails.lecturerName}`], [`Học phần: ${selectedCourseId} - ${selectedFacultyCode} - ${selectedSemester}`], [], ["Mã SV", "Tên SV", "Tên nhóm", "Tên đồ án", "Thời gian bắt đầu", "Thời gian kết thúc", "Thời gian chấm", "Mô tả đề tài", "File mô tả"]];
    groupDetails.members.forEach(member => {
      worksheetData.push([member.studentId, member.studentName, groupDetails.groupName, groupDetails.projectName, groupDetails.startDate, groupDetails.endDate, groupDetails.gradingDate, groupDetails.description, groupDetails.files.map(file => file.filePath === "Chưa có file" ? "Chưa có file" : `${file.filePath.split("/").pop()} (${file.studentCode} - ${file.fullName})`).join(", ")]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietNhom");
    XLSX.writeFile(workbook, `chi_tiet_nhom_${groupDetails.groupName}_${selectedCourseId}_${selectedFacultyCode}_${selectedSemester}.xlsx`);
  }

  // Đăng xuất tài khoản
  // Đăng xuất tài khoản
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
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${await response.text()}`);
      alert("Đăng xuất thành công!");
    } catch (error) {
      alert("Đăng xuất bị lỗi: " + error.message);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await displayGroupDetails();
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

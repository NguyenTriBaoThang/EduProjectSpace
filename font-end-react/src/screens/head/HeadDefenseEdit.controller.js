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
  // Dữ liệu mẫu nhóm sinh viên
  let groups = [{
    id: 1,
    name: "Nhóm 1",
    courseId: "CS101",
    semester: "HK1-2025",
    classId: "CNTT01",
    projectId: "DT001",
    members: ["Nguyễn Tri Bão Thắng", "Trần Văn A"],
    status: "Đã duyệt",
    grades: {
      lecturerScore: 8.5,
      councilScore: 8.0,
      approved: "Chưa duyệt"
    }
  }, {
    id: 2,
    name: "Nhóm 2",
    courseId: "CS101",
    semester: "HK1-2025",
    classId: "CNTT01",
    projectId: "DT002",
    members: ["Lê Thị B"],
    status: "Chưa duyệt",
    grades: null
  }, {
    id: 3,
    name: "Nhóm 3",
    courseId: "CS101",
    semester: "HK1-2025",
    classId: "CNTT01",
    projectId: "DT003",
    members: ["Phạm Văn C", "Nguyễn Thị D"],
    status: "Hoàn thành",
    grades: {
      lecturerScore: 9.0,
      councilScore: 8.8,
      approved: "Đã duyệt"
    }
  }, {
    id: 4,
    name: "Nhóm 4",
    courseId: "AI201",
    semester: "HK1-2025",
    classId: "AI01",
    projectId: "DT004",
    members: ["Hoàng Văn E", "Trần Thị F"],
    status: "Đã duyệt",
    grades: {
      lecturerScore: 7.5,
      councilScore: 7.8,
      approved: "Chưa duyệt"
    }
  }];
  let defenseSchedules = [{
    id: 1,
    projectId: "DT001",
    date: "01/03/2025",
    location: "Phòng họp A",
    council: "HD001"
  }, {
    id: 2,
    projectId: "DT003",
    date: "02/03/2025",
    location: "Phòng họp B",
    council: "HD002"
  }, {
    id: 3,
    projectId: "DT004",
    date: "03/03/2025",
    location: "Phòng họp C",
    council: "HD003"
  }];

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const urlParams = new URLSearchParams(window.location.search);
  const scheduleId = parseInt(urlParams.get("id"));
  const projectId = urlParams.get("projectId");
  const courseId = urlParams.get("courseId"); // Thêm để quay lại đúng ngữ cảnh
  // Thêm để quay lại đúng ngữ cảnh
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

  // Hiển thị thông tin lịch bảo vệ để sửa
  // Hiển thị thông tin lịch bảo vệ để sửa
  function displayDefenseDetails() {
    const schedule = defenseSchedules.find(s => s.id === scheduleId && s.projectId === projectId);
    const group = groups.find(g => g.projectId === projectId);
    if (!schedule || !group) {
      document.querySelector(".card-body").innerHTML = env.html("<p class='text-center text-muted'>Không tìm thấy lịch bảo vệ hoặc nhóm.</p>");
      return;
    }
    document.getElementById("editDefenseId").value = schedule.id;
    document.getElementById("editDefenseProjectId").value = schedule.projectId;
    document.getElementById("editDefenseName").value = group.name;
    document.getElementById("editDefenseMembers").value = group.members.join(", ");
    document.getElementById("editDefenseStatus").value = group.status;
    document.getElementById("editDefenseLecturerScore").value = group.grades ? group.grades.lecturerScore : "Chưa có";
    document.getElementById("editDefenseCouncilScore").value = group.grades ? group.grades.councilScore : "Chưa có";
    document.getElementById("editDefenseApproved").value = group.grades ? group.grades.approved : "Chưa duyệt";
    document.getElementById("editDefenseDate").value = unformatDate(schedule.date);
    document.getElementById("editDefenseLocation").value = schedule.location;
    document.getElementById("editDefenseCouncil").value = schedule.council;

    // Cập nhật link quay lại
    document.getElementById("backToDefenseLink").href = `head_defense.html?courseId=${group.courseId}&semester=${group.semester}&classId=${group.classId}`;
  }

  // Lưu thông tin chỉnh sửa
  // Lưu thông tin chỉnh sửa
  function saveEditDefense() {
    const form = document.getElementById("editDefenseForm");
    if (form.checkValidity()) {
      const id = parseInt(document.getElementById("editDefenseId").value);
      const schedule = defenseSchedules.find(s => s.id === id);
      if (schedule) {
        schedule.date = formatDate(document.getElementById("editDefenseDate").value);
        schedule.location = document.getElementById("editDefenseLocation").value;
        schedule.council = document.getElementById("editDefenseCouncil").value;
        alert(`Đã cập nhật lịch bảo vệ cho nhóm ${schedule.projectId} vào ngày ${schedule.date}`);
        const group = groups.find(g => g.projectId === schedule.projectId);
        env.navigate(`head_defense.html?courseId=${group.courseId}&semester=${group.semester}&classId=${group.classId}`);
      }
    } else {
      form.reportValidity();
    }
  }

  // Hủy chỉnh sửa
  // Hủy chỉnh sửa
  function cancelEdit() {
    const projectId = document.getElementById("editDefenseProjectId").value;
    const group = groups.find(g => g.projectId === projectId);
    env.navigate(`head_defense.html?courseId=${group.courseId}&semester=${group.semester}&classId=${group.classId}`);
  }

  // Hàm định dạng ngày từ ISO sang dd/mm/yyyy
  // Hàm định dạng ngày từ ISO sang dd/mm/yyyy
  function formatDate(isoDate) {
    const date = new Date(isoDate);
    return date.toLocaleDateString("vi-VN");
  }

  // Hàm chuyển định dạng ngày từ dd/mm/yyyy về yyyy-mm-dd cho input date
  // Hàm chuyển định dạng ngày từ dd/mm/yyyy về yyyy-mm-dd cho input date
  function unformatDate(dateStr) {
    const [day, month, year] = dateStr.split("/");
    return `${year}-${month.padStart(2, "0")}-${day.padStart(2, "0")}`;
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", () => {
    displayDefenseDetails();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      saveEditDefense();
    },
    event2: function (event) {
      cancelEdit();
    }
  };
}

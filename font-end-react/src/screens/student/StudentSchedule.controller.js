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
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => {
    toggleSidebar();
  });
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("notifications_list.html");
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

  // Toggle Sidebar
  // Toggle Sidebar
  function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let navbar = document.querySelector(".navbar");
    let content = document.querySelector(".content");
    if (sidebar.classList.contains("collapsed")) {
      sidebar.classList.remove("collapsed");
      navbar.style.width = "calc(100% - 270px)";
      content.style.marginLeft = "270px";
    } else {
      sidebar.classList.add("collapsed");
      navbar.style.width = "calc(100% - 80px)";
      content.style.marginLeft = "80px";
    }
  }

  // Dữ liệu sự kiện mẫu (10 sự kiện trong ngày 2025-02-15)
  // Dữ liệu sự kiện mẫu (10 sự kiện trong ngày 2025-02-15)
  const events = [{
    id: "1",
    title: "Hạn nộp báo cáo chuyên ngành",
    start: "2025-02-15",
    description: "Nộp báo cáo về tiến độ đồ án cho giáo viên hướng dẫn"
  }, {
    id: "2",
    title: "Hạn nộp báo cáo cơ sở",
    start: "2025-02-15",
    description: "Nộp báo cáo về tiến độ đồ án cơ sở"
  }, {
    id: "3",
    title: "Thảo luận dự án",
    start: "2025-02-15",
    description: "Thảo luận về tiến độ và kế hoạch làm đồ án"
  }, {
    id: "4",
    title: "Họp nhóm đồ án",
    start: "2025-02-15",
    description: "Họp nhóm để phân công nhiệm vụ"
  }, {
    id: "5",
    title: "Nộp đề cương",
    start: "2025-02-15",
    description: "Nộp đề cương chi tiết cho giảng viên"
  }, {
    id: "6",
    title: "Kiểm tra tiến độ",
    start: "2025-02-15",
    description: "Giảng viên kiểm tra tiến độ đồ án"
  }, {
    id: "7",
    title: "Hạn chỉnh sửa báo cáo",
    start: "2025-02-15",
    description: "Chỉnh sửa báo cáo theo phản hồi"
  }, {
    id: "8",
    title: "Seminar đồ án",
    start: "2025-02-15",
    description: "Tham gia seminar đồ án với giảng viên"
  }, {
    id: "9",
    title: "Nộp tài liệu bổ sung",
    start: "2025-02-15",
    description: "Nộp tài liệu bổ sung theo yêu cầu"
  }, {
    id: "10",
    title: "Hạn gửi slide thuyết trình",
    start: "2025-02-15",
    description: "Gửi slide thuyết trình cho giảng viên"
  }];

  // Khởi tạo FullCalendar
  // Khởi tạo FullCalendar
  env.listen(document, "DOMContentLoaded", function () {
    var calendarEl = document.getElementById("calendar");
    var calendar = new FullCalendar.Calendar(calendarEl, {
      initialView: "dayGridMonth",
      locale: "vi",
      buttonText: {
        today: "Hôm nay",
        month: "Tháng",
        week: "Tuần",
        day: "Ngày",
        list: "Lịch"
      },
      events: events,
      eventClick: function (info) {
        var modal = new bootstrap.Modal(document.getElementById("notificationModal"));
        var message = `Sự kiện: ${info.event.title}<br>Ngày: ${info.event.start.toLocaleDateString()}`;
        var description = info.event.extendedProps.description;
        document.getElementById("notificationMessage").innerHTML = env.html(message);
        document.getElementById("eventDescription").innerHTML = env.html(description);
        modal.show();
      },
      eventLimit: true,
      // Hiển thị nút "more" khi có nhiều sự kiện trong ngày
      moreLinkText: function (num) {
        return "xem thêm +" + num; // Tùy chỉnh nút "more" thành "xem thêm +số lượng"
      },
      dayMaxEvents: 3 // Giới hạn tối đa 3 sự kiện hiển thị trực tiếp
    });
    calendar.render();
  });

  // Xuất sự kiện sang Excel
  // Xuất sự kiện sang Excel
  function exportEvents() {
    const worksheetData = [["Lịch cá nhân"], [], ["Tiêu đề", "Ngày", "Mô tả"]];
    events.forEach(event => {
      worksheetData.push([event.title, event.start, event.description]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "LichCaNhan");
    XLSX.writeFile(workbook, "lich_ca_nhan.xlsx");
  }
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportEvents();
    }
  };
}

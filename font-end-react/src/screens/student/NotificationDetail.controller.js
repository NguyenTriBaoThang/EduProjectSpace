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
  // Dữ liệu mẫu thông báo
  const notifications = {
    "1": {
      title: "Gia hạn thời gian nộp đơn các thủ tục học vụ Học kỳ 2 (2024 - 2025)",
      time: "🕒 09:05 - 07/12/2024",
      author: "@Cao Thanh Thúy",
      content: "Do tình hình dịch bệnh, nhà trường quyết định gia hạn thời gian nộp đơn các thủ tục học vụ Học kỳ 2 (2024 - 2025) đến ngày **20/12/2024**. Sinh viên vui lòng chuẩn bị đầy đủ giấy tờ cần thiết.\n\nLưu ý: Sau thời gian này, các đơn nộp muộn sẽ không được chấp nhận.",
      status: "unread"
    },
    "2": {
      title: "Thông báo về việc thực hiện các thủ tục học vụ - Học kỳ 2 năm học 2024 - 2025",
      time: "🕒 09:22 - 13/11/2024",
      author: "@Bùi Hồng Ẩn",
      content: "Sinh viên cần hoàn tất các thủ tục học vụ trước ngày **30/11/2024** để tránh bị gián đoạn học tập. Các thủ tục bao gồm:\n- Nộp đơn xin nghỉ học tạm thời (nếu có).\n- Đăng ký tín chỉ bổ sung.",
      status: "unread"
    },
    "3": {
      title: "Gián đoạn truy cập để bảo trì nâng cấp hệ thống học vụ điện tử",
      time: "🕒 08:44 - 28/10/2024",
      author: "@Phạm Đình Phùng",
      content: "Hệ thống học vụ điện tử sẽ bảo trì từ ngày **01/11** đến ngày **03/11**. Sinh viên vui lòng sắp xếp công việc nộp đơn trước thời gian này.\n\nNếu có thắc mắc, liên hệ phòng Đào tạo qua email: daotao@hutech.edu.vn.",
      status: "unread"
    }
  };

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => {
    const sidebar = document.querySelector(".sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
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

  // Lấy thông tin thông báo từ URL
  // Lấy thông tin thông báo từ URL
  const params = new URLSearchParams(window.location.search);
  const id = params.get("id");
  function loadNotification() {
    if (notifications[id]) {
      const notif = notifications[id];
      document.getElementById("notificationsTitle").textContent = notif.title;
      document.getElementById("notificationsTime").textContent = notif.time;
      document.getElementById("notificationsAuthor").textContent = notif.author;
      document.getElementById("notificationsContent").innerHTML = env.html(formatContent(notif.content));
      document.getElementById("markAsReadBtn").style.display = notif.status === "unread" ? "inline-block" : "none";
      updateUnreadCount();
    } else {
      document.getElementById("notificationsTitle").textContent = "Không tìm thấy thông báo";
      document.getElementById("notificationsContent").textContent = "Thông báo với ID này không tồn tại.";
      document.getElementById("markAsReadBtn").style.display = "none";
    }
  }

  // Định dạng nội dung thông báo (hỗ trợ xuống dòng và in đậm)
  // Định dạng nội dung thông báo (hỗ trợ xuống dòng và in đậm)
  function formatContent(content) {
    return content.replace(/\n/g, "<br>").replace(/\*\*(.*?)\*\*/g, "<strong>$1</strong>");
  }

  // Đánh dấu đã đọc
  // Đánh dấu đã đọc
  function markAsRead() {
    if (notifications[id]) {
      notifications[id].status = "read";
      document.getElementById("markAsReadBtn").style.display = "none";
      updateUnreadCount();
    }
  }

  // Xóa thông báo
  // Xóa thông báo
  function deleteNotification() {
    if (confirm("Bạn có chắc muốn xóa thông báo này không?")) {
      delete notifications[id];
      env.navigate("notifications_list.html");
    }
  }

  // Chia sẻ thông báo
  // Chia sẻ thông báo
  function shareNotification() {
    const notif = notifications[id];
    if (notif) {
      const shareText = `${notif.title}\n${notif.time}\n${notif.author}\n${notif.content}`;
      if (navigator.share) {
        navigator.share({
          title: notif.title,
          text: shareText,
          url: window.location.href
        }).catch(err => alert("Không thể chia sẻ: " + err));
      } else {
        navigator.clipboard.writeText(shareText).then(() => alert("Đã sao chép thông báo vào clipboard!"));
      }
    }
  }

  // Cập nhật số lượng thông báo chưa đọc
  // Cập nhật số lượng thông báo chưa đọc
  function updateUnreadCount() {
    const unreadCount = Object.values(notifications).filter(n => n.status === "unread").length;
    document.getElementById("unreadCount").textContent = unreadCount;
  }

  // Khởi chạy
  // Khởi chạy
  loadNotification();
  return {
    event0: function (event) {
      deleteNotification();
    },
    event1: function (event) {
      shareNotification();
    },
    event2: function (event) {
      markAsRead();
    }
  };
}

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
  const notifications = [];
  for (let i = 1; i <= 50; i++) {
    notifications.push({
      id: i,
      title: `Thông báo ${i} - Cập nhật thông tin quan trọng`,
      date: `0${i % 9 + 1}/0${i % 12 + 1}/2025`,
      author: `Người gửi ${i}`,
      link: `notification_detail.html?id=${i}`,
      status: i % 3 === 0 ? "read" : "unread" // 1/3 thông báo đã đọc
    });
  }
  const itemsPerPage = 15;
  let currentPage = 1;

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

  // Hiển thị thông báo
  // Hiển thị thông báo
  function displayNotifications(page, filteredNotifications) {
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedNotifications = filteredNotifications.slice(start, end);
    const notificationList = document.getElementById("notificationList");
    notificationList.innerHTML = env.html("");
    if (paginatedNotifications.length === 0) {
      notificationList.innerHTML = env.html("<p class=\"text-center\">Không tìm thấy thông báo nào.</p>");
    } else {
      paginatedNotifications.forEach(notification => {
        const statusIcon = notification.status === "unread" ? "<i class=\"bi bi-circle-fill text-danger me-2\"></i>" : "";
        notificationList.innerHTML += env.html(`
                        <div class="notification-card">
                            <div class="notification-avatar">
                                <div class="avatar-circle">${notification.author.charAt(0)}</div>
                            </div>
                            <div class="notification-content">
                                <h6 class="notification-title">${statusIcon}${notification.title}</h6>
                                <div class="notification-meta d-flex justify-content-between">
                                    <span>📅 ${notification.date}</span>
                                    <span>🧑‍💼 ${notification.author}</span>
                                </div>
                            </div>
                            <div class="view-detail">
                                <a href="${notification.link}" data-page-click="${env.bind(function (event) {
          markAsRead(notification.id);
          return false;
        })}">Xem chi tiết</a>
                            </div>
                        </div>
                    `);
      });
    }
    document.getElementById("unreadCount").textContent = filteredNotifications.filter(n => n.status === "unread").length;
    setupPagination(filteredNotifications.length);
  }

  // Lọc thông báo
  // Lọc thông báo
  function getFilteredNotifications() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    return notifications.filter(notif => {
      const matchesSearch = notif.title.toLowerCase().includes(searchText) || notif.date.toLowerCase().includes(searchText) || notif.author.toLowerCase().includes(searchText);
      const matchesStatus = statusFilter === "" || notif.status === statusFilter;
      return matchesSearch && matchesStatus;
    }).sort((a, b) => new Date(b.date.split("/").reverse().join("-")) - new Date(a.date.split("/").reverse().join("-")));
  }
  function filterNotifications() {
    currentPage = 1; // Reset về trang đầu khi lọc
    const filtered = getFilteredNotifications();
    displayNotifications(currentPage, filtered);
  }

  // Đánh dấu đã đọc
  // Đánh dấu đã đọc
  function markAsRead(id) {
    const notification = notifications.find(n => n.id === id);
    if (notification) notification.status = "read";
    const filtered = getFilteredNotifications();
    displayNotifications(currentPage, filtered);
  }

  // Phân trang
  // Phân trang
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalItems === 0) return; // Không hiển thị phân trang nếu không có kết quả

    pagination.innerHTML += env.html(`<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">« Đầu</a></li>`);
    if (currentPage > 1) {
      pagination.innerHTML += env.html(`<li><a href="#" data-page-click="${env.bind(function (event) {
        changePage(currentPage - 1);
      })}">Trước</a></li>`);
    }
    const maxVisiblePages = 5;
    let startPage = Math.max(1, currentPage - 2);
    let endPage = Math.min(totalPages, startPage + maxVisiblePages - 1);
    if (endPage - startPage < maxVisiblePages - 1) startPage = Math.max(1, endPage - maxVisiblePages + 1);
    for (let i = startPage; i <= endPage; i++) {
      pagination.innerHTML += env.html(`<li><a href="#" class="${i === currentPage ? "active" : ""}" data-page-click="${env.bind(function (event) {
        changePage(i);
      })}">${i}</a></li>`);
    }
    if (currentPage < totalPages) {
      pagination.innerHTML += env.html(`<li><a href="#" data-page-click="${env.bind(function (event) {
        changePage(currentPage + 1);
      })}">Sau</a></li>`);
    }
    pagination.innerHTML += env.html(`<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">Cuối »</a></li>`);
  }
  function changePage(page) {
    currentPage = page;
    const filtered = getFilteredNotifications();
    displayNotifications(currentPage, filtered);
  }

  // Khởi chạy
  // Khởi chạy
  const initialFiltered = getFilteredNotifications();
  displayNotifications(currentPage, initialFiltered);
  return {
    event0: function (event) {
      filterNotifications();
    },
    event1: function (event) {
      filterNotifications();
    },
    event2: function (event) {
      filterNotifications();
    }
  };
}

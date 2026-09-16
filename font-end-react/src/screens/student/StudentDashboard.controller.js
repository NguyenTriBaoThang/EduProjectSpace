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
  const token = localStorage.getItem("token");
  let dashboardData = {};
  let notifications = [];
  let tasks = [];
  let calendarEvents = [];
  let currentPage = 1;
  const itemsPerPage = 5;
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/student/notifications_list.html"));
  env.listen(document.getElementById("calendarBtn"), "click", () => env.navigate("/font-end/student/student_schedule.html"));
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(event.target) && event.target.id !== "profileBtn") dropdown.style.display = "none";
  });
  env.listen(document.getElementById("toggleFullscreen"), "click", toggleFullscreen);
  env.listen(document.getElementById("toggleFullscreenBtn"), "click", toggleFullscreen);
  env.listen(document.getElementById("toggleTheme"), "click", toggleTheme);
  function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const content = document.getElementById("content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }
  function toggleFullscreen() {
    if (!document.fullscreenElement) document.documentElement.requestFullscreen();else document.exitFullscreen();
  }
  function toggleTheme() {
    document.body.classList.toggle("dark-mode");
    localStorage.setItem("theme", document.body.classList.contains("dark-mode") ? "dark" : "light");
  }
  if (localStorage.getItem("theme") === "dark") document.body.classList.add("dark-mode");
  async function loadUserProfile() {
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user || user.roleName !== "ROLE_STUDENT") {
      alert("Không có quyền Sinh viên hoặc chưa đăng nhập.");
      logout();
      return;
    }
    document.getElementById("userName").textContent = user.fullName || "Nguyễn Tri Bão Thắng";
    document.getElementById("userEmail").textContent = user.email || "nguyentribaothang@gmail.com";
  }
  async function loadDashboardData() {
    try {
      const response = await fetch(`${API_URL}/api/StudentDashboard`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi ${response.status}`);
      dashboardData = await response.json();
      document.getElementById("totalSubmissions").textContent = dashboardData.totalSubmissions || 0;
      document.getElementById("pendingTasks").textContent = dashboardData.pendingTasks || 0;
      document.getElementById("unreadNotifications").textContent = dashboardData.unreadNotifications || 0;
      document.getElementById("unreadCount").textContent = dashboardData.unreadNotifications || 0;

      // Cập nhật đề xuất đề tài
      const proposalMessage = document.getElementById("proposalMessage");
      const proposalLink = document.getElementById("proposalLink");
      if (dashboardData.hasTodoProposal) {
        proposalMessage.textContent = "Bạn có đề tài chưa hoàn thành. Hãy đề xuất ngay!";
        proposalLink.style.display = "block";
      } else {
        proposalMessage.textContent = "Chưa có đề tài nào được đề xuất.";
        proposalLink.style.display = "none";
      }
      renderCharts();
    } catch (error) {
      console.error("Lỗi dashboard:", error);
      alert(`Lỗi: ${error.message}`);
    }
  }
  async function loadNotifications() {
    try {
      const response = await fetch(`${API_URL}/api/StudentDashboard/notifications?limit=5`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi ${response.status}`);
      notifications = await response.json();
      displayNotifications();
    } catch (error) {
      console.error("Lỗi notifications:", error);
      alert(`Lỗi: ${error.message}`);
    }
  }
  async function loadTasks() {
    try {
      const searchText = encodeURIComponent(document.getElementById("taskSearchInput").value);
      const status = document.getElementById("statusFilter").value;
      const response = await fetch(`${API_URL}/api/StudentDashboard/tasks?searchText=${searchText}&status=${status}&page=${currentPage}&pageSize=${itemsPerPage}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi ${response.status}`);
      const data = await response.json();
      tasks = data.tasks || [];
      displayTable(data.totalCount || 0);
    } catch (error) {
      console.error("Lỗi tasks:", error);
      document.getElementById("taskTable").innerHTML = env.html("<tr><td colspan=\"7\">Không tải được công việc</td></tr>");
    }
  }
  async function loadCalendarEvents() {
    try {
      const response = await fetch(`${API_URL}/api/StudentDashboard/calendar`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi ${response.status}`);
      calendarEvents = await response.json();
      displayCalendarEvents();
    } catch (error) {
      console.error("Lỗi calendar:", error);
      alert(`Lỗi: ${error.message}`);
    }
  }
  function renderCharts() {
    const ctx1 = document.getElementById("submissionChart").getContext("2d");
    new Chart(ctx1, {
      type: "doughnut",
      data: {
        labels: Object.keys(dashboardData.submissionByProject || {}),
        datasets: [{
          data: Object.values(dashboardData.submissionByProject || {}),
          backgroundColor: ["#4CAF50", "#2196F3", "#FF9800"]
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: "bottom"
          },
          tooltip: {
            enabled: true
          }
        }
      }
    });
    const ctx2 = document.getElementById("progressChart").getContext("2d");
    new Chart(ctx2, {
      type: "bar",
      data: {
        labels: Object.keys(dashboardData.progressByProject || {}),
        datasets: [{
          label: "Tiến độ (%)",
          data: Object.values(dashboardData.progressByProject || {}),
          backgroundColor: ["#4CAF50", "#2196F3", "#FF9800"]
        }]
      },
      options: {
        responsive: true,
        indexAxis: "y",
        scales: {
          x: {
            beginAtZero: true,
            max: 100
          }
        }
      }
    });
  }
  function displayNotifications() {
    const notificationList = document.getElementById("notificationList");
    notificationList.innerHTML = env.html("");
    (notifications || []).forEach((notif, index) => {
      const iconClass = index === 0 ? "bi-exclamation-circle text-warning" : "bi-info-circle text-primary";
      notificationList.innerHTML += env.html(`<li class="dashboard-list-group-item"><div class="d-flex align-items-center"><i class="${iconClass} me-2"></i><a href="/font-end/student/notification_detail.html?id=${notif.id}" class="dashboard-notification-title text-decoration-none text-dark">${notif.title || "Không có tiêu đề"}</a><span class="ms-auto text-muted fs-6">${formatDate(notif.date)}</span></div></li>`);
    });
    document.getElementById("viewMoreNotifications").style.display = notifications.length >= 5 ? "block" : "none";
  }
  function displayCalendarEvents() {
    const calendarList = document.getElementById("calendarList");
    calendarList.innerHTML = env.html("");
    (calendarEvents || []).forEach(event => {
      const iconClass = event.type === "Deadline" ? "bi-folder-check" : event.type === "Meeting" ? "bi-people" : "bi-bell";
      calendarList.innerHTML += env.html(`<li class="dashboard-list-group-item"><i class="${iconClass}"></i><span class="dashboard-notification-title">${event.eventTitle || "Không có tiêu đề"}</span><span class="text-muted">${formatDate(event.startTime)}</span></li>`);
    });
  }
  function displayTable(totalCount) {
    const tableBody = document.getElementById("taskTable");
    tableBody.innerHTML = env.html("");
    (tasks || []).forEach((task, index) => {
      const daysRemaining = calculateDaysRemaining(task.deadline);
      const statusClass = daysRemaining === "Hết hạn nộp" ? "badge bg-danger" : task.status === "Chưa nộp" ? "badge bg-warning" : "badge bg-success";
      tableBody.innerHTML += env.html(`<tr><td>${(currentPage - 1) * itemsPerPage + index + 1}</td><td>${task.name || "Không có tên"}</td><td>${task.projectName || "Không có dự án"}</td><td>${formatDate(task.deadline)}</td><td>${daysRemaining}</td><td><span class="${statusClass}">${daysRemaining === "Hết hạn nộp" ? "Hết hạn" : task.status}</span></td><td><button class="btn btn-sm btn-info">👁️ Xem</button>${task.status === "Chưa nộp" && daysRemaining !== "Hết hạn nộp" ? `<button class="btn btn-sm btn-primary ms-1" data-page-click="${env.bind(function (event) {
        submitTask(task.id);
      })}">📤 Nộp</button>` : ""}</td></tr>`);
    });
    setupPagination(totalCount);
  }
  function calculateDaysRemaining(deadline) {
    const today = new Date();
    const deadlineDate = new Date(deadline);
    const timeDiff = deadlineDate - today;
    return timeDiff < 0 ? "Hết hạn nộp" : `${Math.ceil(timeDiff / (1000 * 60 * 60 * 24))} ngày`;
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    let paginationHTML = `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`;
    if (currentPage > 2) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`;
    if (currentPage > 3) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage > 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }
  function changePage(page) {
    currentPage = page;
    loadTasks();
  }
  function filterTable() {
    currentPage = 1;
    loadTasks();
  }
  function submitTask(id) {
    env.navigate(`/font-end/student/student_submissions_list.html?taskId=${id}`);
  }
  function formatDate(date) {
    if (!date) return "";
    const d = new Date(date);
    return `${d.getDate().toString().padStart(2, "0")}-${(d.getMonth() + 1).toString().padStart(2, "0")}-${d.getFullYear()}`;
  }
  async function logout() {
    if (!token) return;
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
      if (response.ok) alert("Đã đăng xuất thành công.");
    } catch (error) {
      console.error("Lỗi logout:", error);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await loadDashboardData();
    await loadNotifications();
    await loadTasks();
    await loadCalendarEvents();
  });
  return {
    event0: function (event) {
      filterTable();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      filterTable();
    }
  };
}

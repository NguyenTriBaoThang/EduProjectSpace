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
  // Dữ liệu mẫu
  const subjects = {
    "1": {
      name: "Công nghệ phần mềm",
      tasks: [{
        id: 1,
        name: "Đề xuất đề tài",
        startDate: "05/01/2025",
        deadline: "10/01/2025",
        status: "Hoàn thành",
        note: "✔ Đã duyệt"
      }, {
        id: 2,
        name: "Thiết kế hệ thống",
        startDate: "12/01/2025",
        deadline: "20/01/2025",
        status: "Hoàn thành",
        note: "✔ Đã gửi báo cáo"
      }, {
        id: 3,
        name: "Phát triển Backend",
        startDate: "22/01/2025",
        deadline: "05/02/2025",
        status: "Đang thực hiện",
        note: "🔄 Chưa gửi báo cáo"
      }, {
        id: 4,
        name: "Kiểm thử phần mềm",
        startDate: "02/02/2025",
        deadline: "10/02/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Chưa bắt đầu"
      }, {
        id: 5,
        name: "Triển khai hệ thống",
        startDate: "10/02/2025",
        deadline: "15/02/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Đang lên kế hoạch"
      }, {
        id: 6,
        name: "Nghiên cứu tài liệu",
        startDate: "15/02/2025",
        deadline: "20/02/2025",
        status: "Hoàn thành",
        note: "✔ Đã nộp báo cáo"
      }, {
        id: 7,
        name: "Xây dựng cơ sở dữ liệu",
        startDate: "20/02/2025",
        deadline: "25/02/2025",
        status: "Đang thực hiện",
        note: "🔄 Cần kiểm tra"
      }, {
        id: 8,
        name: "Tạo báo cáo cuối kỳ",
        startDate: "25/02/2025",
        deadline: "01/03/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Đang chuẩn bị"
      }, {
        id: 9,
        name: "Hoàn thành đồ án",
        startDate: "01/03/2025",
        deadline: "05/03/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Chưa bắt đầu"
      }, {
        id: 10,
        name: "Nộp đồ án",
        startDate: "05/03/2025",
        deadline: "10/03/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Đang làm báo cáo"
      }, {
        id: 11,
        name: "Chỉnh sửa đồ án",
        startDate: "10/03/2025",
        deadline: "15/03/2025",
        status: "Hoàn thành",
        note: "✔ Đã sửa lại theo yêu cầu"
      }, {
        id: 12,
        name: "Đánh giá đồ án",
        startDate: "15/03/2025",
        deadline: "20/03/2025",
        status: "Hoàn thành",
        note: "✔ Đã đánh giá"
      }, {
        id: 13,
        name: "Trình bày đồ án",
        startDate: "20/03/2025",
        deadline: "25/03/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Đang chuẩn bị bài thuyết trình"
      }, {
        id: 14,
        name: "Tổng kết đồ án",
        startDate: "25/03/2025",
        deadline: "30/03/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Cần chỉnh sửa"
      }]
    },
    "2": {
      name: "Lập trình Web",
      tasks: [{
        id: 15,
        name: "Thiết kế giao diện",
        startDate: "01/02/2025",
        deadline: "07/02/2025",
        status: "Hoàn thành",
        note: "✔ Đã hoàn thành"
      }, {
        id: 16,
        name: "Phát triển frontend",
        startDate: "08/02/2025",
        deadline: "14/02/2025",
        status: "Chưa hoàn thành",
        note: "🔄 Chưa bắt đầu"
      }]
    }
  };
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let currentTasks = [];

  // Lấy dữ liệu từ URL
  // Lấy dữ liệu từ URL
  const params = new URLSearchParams(window.location.search);
  const subjectId = params.get("id") || "1"; // Mặc định là môn ID 1 nếu không có trong URL
  // Mặc định là môn ID 1 nếu không có trong URL
  currentTasks = subjects[subjectId]?.tasks || [];
  document.getElementById("subjectTitle").textContent = `📊 Giai đoạn thực hiện - ${subjects[subjectId]?.name || "Không xác định"}`;

  // Navbar Functions
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

  // Lọc và sắp xếp dữ liệu bảng
  // Lọc và sắp xếp dữ liệu bảng
  function getFilteredTasks() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = currentTasks.filter(task => task.name.toLowerCase().includes(searchText) && (statusFilter === "" || task.status === statusFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "startDate" || sortColumn === "deadline") {
          valueA = new Date(valueA.split("/").reverse().join("-"));
          valueB = new Date(valueB.split("/").reverse().join("-"));
        } else {
          valueA = valueA.toLowerCase();
          valueB = valueB.toLowerCase();
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Hiển thị dữ liệu bảng
  // Hiển thị dữ liệu bảng
  function displayTable(page) {
    const filteredTasks = getFilteredTasks();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredTasks.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy bài tập nào.</td></tr>");
    } else {
      paginatedData.forEach((task, index) => {
        let statusClass = "status-completed";
        if (task.status === "Chưa hoàn thành") statusClass = "status-warning";
        if (task.status === "Đang thực hiện") statusClass = "status-inprogress";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${task.name}</td>
                            <td>${task.startDate}</td>
                            <td>${task.deadline}</td>
                            <td><span class="${statusClass}">${task.status}</span></td>
                            <td>${task.note}</td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredTasks.length);
    updateProgressAndChart();
  }

  // Tạo phân trang
  // Tạo phân trang
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    let paginationHTML = `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`;
    if (currentPage > 2) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`;
    if (currentPage > 3) paginationHTML += `<li>...</li>`;
    if (currentPage > 1) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li><a href="#" class="active">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li>...</li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li><a href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }

  // Chuyển trang
  // Chuyển trang
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }

  // Lọc bảng
  // Lọc bảng
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Sắp xếp bảng
  // Sắp xếp bảng
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }

  // Cập nhật thanh tiến độ và biểu đồ
  // Cập nhật thanh tiến độ và biểu đồ
  function updateProgressAndChart() {
    const filteredTasks = getFilteredTasks();
    const completedTasks = filteredTasks.filter(task => task.status === "Hoàn thành").length;
    const totalTasks = filteredTasks.length;
    const progress = totalTasks > 0 ? Math.round(completedTasks / totalTasks * 100) : 0;
    document.getElementById("progressBar").style.width = `${progress}%`;
    document.getElementById("progressBar").textContent = `${progress}% Hoàn thành`;
    const ctx = document.getElementById("progressChart").getContext("2d");
    if (window.progressChart) window.progressChart.destroy();
    window.progressChart = new Chart(ctx, {
      type: "pie",
      data: {
        labels: ["Hoàn thành", "Đang thực hiện", "Chưa hoàn thành"],
        datasets: [{
          label: "Tiến độ (%)",
          data: [filteredTasks.filter(task => task.status === "Hoàn thành").length, filteredTasks.filter(task => task.status === "Đang thực hiện").length, filteredTasks.filter(task => task.status === "Chưa hoàn thành").length],
          backgroundColor: ["#28a745", "#ffc107", "#dc3545"]
        }]
      },
      options: {
        responsive: true
      }
    });
  }

  // Xuất dữ liệu sang Excel
  // Xuất dữ liệu sang Excel
  function exportTasks() {
    const filteredTasks = getFilteredTasks();
    const worksheetData = [[`Giai đoạn thực hiện - ${subjects[subjectId]?.name || "Không xác định"}`], ["Tiến độ tổng thể", `${Math.round(filteredTasks.filter(t => t.status === "Hoàn thành").length / filteredTasks.length * 100)}%`], [], ["#", "Bài tập", "Ngày bắt đầu", "Hạn hoàn thành", "Trạng thái", "Ghi chú"]];
    filteredTasks.forEach((task, index) => {
      worksheetData.push([index + 1, task.name, task.startDate, task.deadline, task.status, task.note]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "TienDoDoAn");
    XLSX.writeFile(workbook, `tien_do_do_an_${subjectId}.xlsx`);
  }

  // Khởi chạy
  // Khởi chạy
  displayTable(currentPage);
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportTasks();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      sortTable("name");
    },
    event5: function (event) {
      sortTable("startDate");
    },
    event6: function (event) {
      sortTable("deadline");
    },
    event7: function (event) {
      sortTable("status");
    }
  };
}

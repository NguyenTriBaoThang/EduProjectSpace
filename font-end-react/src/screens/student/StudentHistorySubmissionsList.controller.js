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
  const tasks = [];
  for (let i = 1; i <= 300; i++) {
    const day = String(i % 30 + 1).padStart(2, "0");
    const month = String(i % 12 + 1).padStart(2, "0");
    tasks.push({
      id: i,
      name: `Bài tập ${i}: Nội dung bài`,
      projectType: ["Đồ án cơ sở", "Đồ án chuyên ngành", "Đồ án tốt nghiệp"][i % 3],
      date: `${day}-${month}-2025`,
      status: i % 2 === 0 ? "Đã chấm" : "Đã nộp",
      score: i % 2 === 0 ? (Math.random() * 10).toFixed(1) : "Chưa chấm"
    });
  }
  const itemsPerPage = 10;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";

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

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredTasks() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    const projectFilter = document.getElementById("projectFilter").value;
    let filtered = tasks.filter(task => task.name.toLowerCase().includes(searchText) && (statusFilter === "" || task.status === statusFilter) && (projectFilter === "" || task.projectType === projectFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "score") {
          valueA = valueA === "Chưa chấm" ? -1 : parseFloat(valueA);
          valueB = valueB === "Chưa chấm" ? -1 : parseFloat(valueB);
        } else if (sortColumn === "date") {
          valueA = new Date(valueA.split("-").reverse().join("-"));
          valueB = new Date(valueB.split("-").reverse().join("-"));
        } else {
          valueA = valueA.toLowerCase();
          valueB = valueB.toLowerCase();
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredTasks = getFilteredTasks();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredTasks.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy bài nộp nào.</td></tr>");
    } else {
      paginatedData.forEach((task, index) => {
        let statusClass = task.status === "Đã chấm" ? "status-graded" : "status-submitted";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${task.name}</td>
                            <td>${task.projectType}</td>
                            <td>${task.date}</td>
                            <td><span class="status ${statusClass}">${task.status}</span></td>
                            <td>${task.score}</td>
                            <td>
                                <button class="btn btn-sm btn-info btn-action" data-page-click="${env.bind(function (event) {
          viewDetails(task.id);
        })}">👁️‍🗨️ Xem</button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredTasks.length);
  }
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
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayTable(currentPage);
  }
  function viewDetails(id) {
    env.navigate(`student_history_submissions_overview.html?taskId=${id}`);
  }

  // Xuất file Excel
  // Xuất file Excel
  function exportHistory() {
    const filteredTasks = getFilteredTasks();
    const worksheetData = [["Lịch sử nộp bài"], [], ["#", "Bài tập", "học phần", "Ngày nộp", "Trạng thái", "Điểm"]];
    filteredTasks.forEach((task, index) => {
      worksheetData.push([index + 1, task.name, task.projectType, task.date, task.status, task.score]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "LichSuNopBai");
    XLSX.writeFile(workbook, "lich_su_nop_bai.xlsx");
  }

  // Khởi chạy
  // Khởi chạy
  displayTable(currentPage);
  return {
    event0: function (event) {
      filterTable();
    },
    event1: function (event) {
      filterTable();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      exportHistory();
    },
    event4: function (event) {
      sortTable("name");
    },
    event5: function (event) {
      sortTable("date");
    },
    event6: function (event) {
      sortTable("score");
    }
  };
}

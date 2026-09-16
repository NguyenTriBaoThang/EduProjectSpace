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
  // Dữ liệu học phần và bài tập
  const subjects = {
    "1": {
      name: "Công nghệ phần mềm",
      tasks: [{
        id: 1,
        name: "Đề xuất đề tài giữa kỳ",
        startDate: "25/01/2025",
        deadline: "01-02-2025",
        status: "Đã nộp",
        grade: "Chưa có điểm"
      }, {
        id: 2,
        name: "Bài tập Tuần 1",
        startDate: "02/02/2025",
        deadline: "07-02-2025",
        status: "Đã nộp",
        grade: "7.0"
      }, {
        id: 3,
        name: "Bài tập Tuần 2",
        startDate: "08/02/2025",
        deadline: "14-02-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 4,
        name: "Bài tập Tuần 3",
        startDate: "15/02/2025",
        deadline: "21-02-2025",
        status: "Đã nộp",
        grade: "8.5"
      }, {
        id: 5,
        name: "Bài tập Tuần 4",
        startDate: "22/02/2025",
        deadline: "28-02-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 6,
        name: "Bài tập giữa kỳ",
        startDate: "01/03/2025",
        deadline: "07-03-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 7,
        name: "Đề xuất đề tài cuối kỳ",
        startDate: "08/03/2025",
        deadline: "14-03-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 8,
        name: "Bài tập Tuần 5",
        startDate: "15/03/2025",
        deadline: "21-03-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 9,
        name: "Bài tập Tuần 6",
        startDate: "22/03/2025",
        deadline: "28-03-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 10,
        name: "Bài tập Tuần 7",
        startDate: "29/03/2025",
        deadline: "04-04-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 11,
        name: "Bài tập Tuần 8",
        startDate: "05/04/2025",
        deadline: "11-04-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 12,
        name: "Bài tập Tuần 9",
        startDate: "12/04/2025",
        deadline: "18-04-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 13,
        name: "Bài tập Tuần 10",
        startDate: "19/04/2025",
        deadline: "25-04-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }, {
        id: 14,
        name: "Báo cáo cuối kỳ",
        startDate: "26/04/2025",
        deadline: "02-05-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }]
    },
    // Thêm dữ liệu học phần khác nếu cần
    "2": {
      name: "Lập trình Web",
      tasks: [{
        id: 15,
        name: "Bài tập Tuần 1",
        startDate: "01/02/2025",
        deadline: "07-02-2025",
        status: "Đã nộp",
        grade: "8.0"
      }, {
        id: 16,
        name: "Bài tập Tuần 2",
        startDate: "08/02/2025",
        deadline: "14-02-2025",
        status: "Chưa nộp",
        grade: "Chưa có điểm"
      }]
    }
  };
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let currentTasks = [];

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

  // Lấy dữ liệu từ URL
  // Lấy dữ liệu từ URL
  const params = new URLSearchParams(window.location.search);
  const subjectId = params.get("id") || "1"; // Mặc định là môn ID 1 nếu không có trong URL
  // Mặc định là môn ID 1 nếu không có trong URL
  currentTasks = subjects[subjectId]?.tasks || [];
  document.getElementById("subjectTitle").textContent = `📌 Danh sách bài tập - ${subjects[subjectId]?.name || "Không xác định"}`;

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
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
        } else if (sortColumn === "name" || sortColumn === "status") {
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
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy bài tập nào.</td></tr>");
    } else {
      paginatedData.forEach((task, index) => {
        let statusClass = "status";
        if (task.status === "Chưa nộp") statusClass = "status-warning";
        if (task.status === "Đã nộp") statusClass = "status-success";
        let statusIcons = task.status === "Chưa nộp" ? "🕒" : "✔";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${task.name}</td>
                            <td>${task.startDate}</td>
                            <td>${task.deadline}</td>
                            <td><span class="${statusClass}">${statusIcons} ${task.status}</span></td>
                            <td>${task.grade}</td>
                            <td>
                                <button class="btn btn-sm btn-info" data-page-click="${env.bind(function (event) {
          viewDetails(task.id);
        })}">👁️ Xem</button>
                                ${task.status === "Chưa nộp" ? `<button class="btn btn-sm btn-success ms-1" data-page-click="${env.bind(function (event) {
          showSubmitModal(task.id);
        })}">📤 Nộp</button>` : ""}
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
    env.navigate(`student_submissions.html?taskId=${id}`);
  }
  function showSubmitModal(id) {
    const task = currentTasks.find(t => t.id === id);
    if (task) {
      document.getElementById("taskName").value = task.name;
      document.getElementById("fileName").textContent = "";
      document.getElementById("taskFile").value = "";
      document.getElementById("submitForm").dataset.taskId = id;
      const modal = new bootstrap.Modal(document.getElementById("submitModal"));
      modal.show();
    }
  }
  function submitTask() {
    const form = document.getElementById("submitForm");
    const taskId = form.dataset.taskId;
    const fileInput = document.getElementById("taskFile");
    if (form.checkValidity()) {
      const task = currentTasks.find(t => String(t.id) === String(taskId));
      if (task) {
        task.status = "Đã nộp";
        alert(`Đã nộp bài tập: ${task.name}`);
        const modal = bootstrap.Modal.getInstance(document.getElementById("submitModal"));
        modal.hide();
        displayTable(currentPage);
      }
    } else {
      form.reportValidity();
    }
  }
  env.listen(document.getElementById("taskFile"), "change", () => {
    const fileInput = document.getElementById("taskFile");
    const fileName = document.getElementById("fileName");
    if (fileInput.files.length > 0) {
      fileName.textContent = `File đã chọn: ${fileInput.files[0].name}`;
    } else {
      fileName.textContent = "";
    }
  });

  // Xuất danh sách bài tập sang Excel
  // Xuất danh sách bài tập sang Excel
  function exportTasks() {
    const filteredTasks = getFilteredTasks();
    const worksheetData = [[`Danh sách bài tập - ${subjects[subjectId]?.name || "Không xác định"}`], [], ["#", "Bài tập", "Ngày bắt đầu", "Thời gian nộp", "Trạng thái", "Điểm"]];
    filteredTasks.forEach((task, index) => {
      worksheetData.push([index + 1, task.name, task.startDate, task.deadline, task.status, task.grade]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachBaiTap");
    XLSX.writeFile(workbook, `danh_sach_bai_tap_${subjectId}.xlsx`);
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
    },
    event8: function (event) {
      submitTask();
    }
  };
}

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
  const grades = [{
    id: 1,
    subject: "Thiết kế phần mềm",
    score: 8.5,
    status: "Đạt"
  }, {
    id: 2,
    subject: "Phát triển Web",
    score: 7.8,
    status: "Đạt"
  }, {
    id: 3,
    subject: "Lập trình di động",
    score: 9.2,
    status: "Xuất sắc"
  }, {
    id: 4,
    subject: "CSDL nâng cao",
    score: 6.9,
    status: "Cần cải thiện"
  }, {
    id: 5,
    subject: "Kỹ thuật lập trình",
    score: 4.5,
    status: "Không đạt"
  }, {
    id: 6,
    subject: "Lập trình C++",
    score: 8.0,
    status: "Đạt"
  }, {
    id: 7,
    subject: "Lập trình trên môi trường Windows",
    score: 7.5,
    status: "Đạt"
  }, {
    id: 8,
    subject: "Cơ sở dữ liệu",
    score: 4.0,
    status: "Không đạt"
  }, {
    id: 9,
    subject: "Đồ án cơ sở",
    score: 6.0,
    status: "Cần cải thiện"
  }, {
    id: 10,
    subject: "Đồ án chuyên ngành",
    score: 3.5,
    status: "Không đạt"
  }, {
    id: 11,
    subject: "Đồ án tốt nghiệp",
    score: 3.0,
    status: "Không đạt"
  }];
  const itemsPerPage = 5;
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

  // Tính toán tổng quan
  // Tính toán tổng quan
  function calculateSummary() {
    document.getElementById("totalSubjects").textContent = grades.length;
    document.getElementById("passedSubjects").textContent = grades.filter(g => g.status === "Đạt" || g.status === "Xuất sắc").length;
    document.getElementById("failedSubjects").textContent = grades.filter(g => g.status === "Không đạt").length;
  }

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredGrades() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    let filtered = grades.filter(grade => grade.subject.toLowerCase().includes(searchText) || grade.status.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        const valueA = sortColumn === "score" ? a[sortColumn] : a[sortColumn].toLowerCase();
        const valueB = sortColumn === "score" ? b[sortColumn] : b[sortColumn].toLowerCase();
        if (sortDirection === "asc") return valueA > valueB ? 1 : -1;
        return valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayGradeTable(page) {
    const filteredGrades = getFilteredGrades();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredGrades.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((grade, index) => {
        let badgeClass = "badge bg-secondary";
        if (grade.status === "Đạt") badgeClass = "badge bg-success";
        if (grade.status === "Xuất sắc") badgeClass = "badge bg-primary";
        if (grade.status === "Cần cải thiện") badgeClass = "badge bg-warning";
        if (grade.status === "Không đạt") badgeClass = "badge bg-danger";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${grade.subject}</td>
                            <td><span class="${badgeClass}">${grade.score}</span></td>
                            <td class="text-${badgeClass.includes("danger") ? "danger" : badgeClass.includes("warning") ? "warning" : "success"}"><strong>${grade.status}</strong></td>
                            <td><a href="student_grades_detail.html?id=${grade.id}" class="btn btn-info btn-sm">📖 Xem chi tiết</a></td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredGrades.length);
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
    displayGradeTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayGradeTable(currentPage);
  }
  function sortTable(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    displayGradeTable(currentPage);
  }

  // Xuất file Excel
  // Xuất file Excel
  function exportGrades() {
    const worksheetData = [["Hệ thống chấm điểm - Danh sách các môn"], [], ["#", "học phần", "Điểm số", "Trạng thái"]];
    grades.forEach((grade, index) => {
      worksheetData.push([index + 1, grade.subject, grade.score, grade.status]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DiemSo");
    XLSX.writeFile(workbook, "diem_so_mon_hoc.xlsx");
  }

  // Biểu đồ kết quả học tập
  // Biểu đồ kết quả học tập
  const ctx1 = document.getElementById("studyResultChart").getContext("2d");
  new Chart(ctx1, {
    type: "bar",
    data: {
      labels: grades.map(grade => grade.subject),
      datasets: [{
        label: "Điểm số",
        data: grades.map(grade => grade.score),
        backgroundColor: grades.map(grade => grade.status === "Xuất sắc" ? "#007bff" : grade.status === "Đạt" ? "#28a745" : grade.status === "Cần cải thiện" ? "#fd7e14" : "#dc3545"),
        borderColor: "#333",
        borderWidth: 1
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        y: {
          beginAtZero: true,
          max: 10
        }
      },
      plugins: {
        tooltip: {
          callbacks: {
            label: context => `Điểm: ${context.raw} (${grades[context.dataIndex].status})`
          }
        }
      }
    }
  });

  // Biểu đồ tiến độ học tập
  // Biểu đồ tiến độ học tập
  const ctx2 = document.getElementById("progressChart").getContext("2d");
  new Chart(ctx2, {
    type: "doughnut",
    data: {
      labels: ["Đạt", "Xuất sắc", "Cần cải thiện", "Không đạt"],
      datasets: [{
        data: [grades.filter(g => g.status === "Đạt").length, grades.filter(g => g.status === "Xuất sắc").length, grades.filter(g => g.status === "Cần cải thiện").length, grades.filter(g => g.status === "Không đạt").length],
        backgroundColor: ["#28a745", "#007bff", "#fd7e14", "#dc3545"]
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        tooltip: {
          callbacks: {
            label: context => `${context.label}: ${context.raw} môn`
          }
        }
      }
    }
  });

  // Khởi chạy
  // Khởi chạy
  calculateSummary();
  displayGradeTable(currentPage);
  return {
    event0: function (event) {
      filterTable();
    },
    event1: function (event) {
      exportGrades();
    },
    event2: function (event) {
      sortTable("subject");
    },
    event3: function (event) {
      sortTable("score");
    }
  };
}

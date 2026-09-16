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

  // Dữ liệu mẫu điểm số
  // Dữ liệu mẫu điểm số
  const scores = [{
    id: 1,
    name: "Bài tập tuần 1",
    score: 8.0,
    evaluation: "Khá",
    suggestion: "Cần cải thiện thuật toán tối ưu"
  }, {
    id: 2,
    name: "Bài tập tuần 2",
    score: 8.5,
    evaluation: "Tốt",
    suggestion: "Chưa có đề xuất cải thiện"
  }, {
    id: 3,
    name: "Bài tập tuần 3",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 4,
    name: "Bài tập tuần 4",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 5,
    name: "Bài tập tuần 5",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 6,
    name: "Bài tập tuần 6",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 7,
    name: "Bài tập tuần 7",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 8,
    name: "Bài tập tuần 8",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }, {
    id: 9,
    name: "Báo cáo hết môn",
    score: 9.0,
    evaluation: "Xuất sắc",
    suggestion: "Hoàn thành tốt, tiếp tục phát huy"
  }];
  const itemsPerPage = 5;
  let currentPage = 1;

  // Tính toán tổng quan điểm số
  // Tính toán tổng quan điểm số
  function calculateSummary() {
    const totalScore = scores.reduce((sum, score) => sum + score.score, 0);
    const avgScore = (totalScore / scores.length).toFixed(1);
    const minScore = Math.min(...scores.map(s => s.score));
    const maxScore = Math.max(...scores.map(s => s.score));
    const minAssignment = scores.find(s => s.score === minScore).name;
    const maxAssignment = scores.find(s => s.score === maxScore).name;
    document.getElementById("avgScore").textContent = avgScore;
    document.getElementById("minScore").textContent = minScore;
    document.getElementById("maxScore").textContent = maxScore;
    document.getElementById("minAssignment").textContent = minAssignment;
    document.getElementById("maxAssignment").textContent = maxAssignment;
    document.getElementById("avgEvaluation").textContent = avgScore >= 9 ? "Xuất sắc" : avgScore >= 8 ? "Tốt" : avgScore >= 6.5 ? "Khá" : "Trung bình";
  }

  // Hiển thị bảng điểm
  // Hiển thị bảng điểm
  function displayScoreTable(page, filteredScores = scores) {
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredScores.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy bài tập nào.</td></tr>");
    } else {
      paginatedData.forEach((score, index) => {
        let badgeClass = "badge bg-secondary";
        if (score.evaluation === "Khá") badgeClass = "badge bg-warning";
        if (score.evaluation === "Tốt") badgeClass = "badge bg-success";
        if (score.evaluation === "Xuất sắc") badgeClass = "badge bg-primary";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${score.name}</td>
                            <td>${score.score}</td>
                            <td><span class="${badgeClass}">${score.evaluation}</span></td>
                            <td>${score.suggestion}</td>
                            <td><a href="student_grades_week.html?id=${score.id}" class="btn btn-primary btn-sm">Xem chi tiết</a></td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredScores.length);
  }

  // Lọc bảng điểm
  // Lọc bảng điểm
  function filterTable() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const filteredScores = scores.filter(score => score.name.toLowerCase().includes(searchText) || score.evaluation.toLowerCase().includes(searchText) || score.suggestion.toLowerCase().includes(searchText));
    currentPage = 1;
    displayScoreTable(currentPage, filteredScores);
  }

  // Phân trang
  // Phân trang
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
    filterTable();
  }

  // Xuất file Excel
  // Xuất file Excel
  function exportGrades() {
    // Chuẩn bị dữ liệu cho Excel
    const worksheetData = [["Chi tiết điểm số - Thiết kế phần mềm"], [`Điểm trung bình: ${document.getElementById("avgScore").textContent}`, "", "Đánh giá: " + document.getElementById("avgEvaluation").textContent], [], ["#", "Bài tập", "Điểm số", "Đánh giá", "Gợi ý cải thiện"]];
    scores.forEach((score, index) => {
      worksheetData.push([index + 1, score.name, score.score, score.evaluation, score.suggestion]);
    });

    // Tạo workbook và worksheet
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DiemSo");

    // Xuất file Excel
    XLSX.writeFile(workbook, "diem_so_thiet_ke_phan_mem.xlsx");
  }

  // Biểu đồ điểm số
  // Biểu đồ điểm số
  const ctx = document.getElementById("subjectChart").getContext("2d");
  new Chart(ctx, {
    type: "line",
    data: {
      labels: scores.map(score => score.name),
      datasets: [{
        label: "Điểm số",
        data: scores.map(score => score.score),
        borderColor: "#007bff",
        backgroundColor: "rgba(0, 123, 255, 0.1)",
        borderWidth: 2,
        fill: true,
        tension: 0.4
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        y: {
          beginAtZero: false,
          suggestedMin: 5,
          suggestedMax: 10
        }
      },
      plugins: {
        tooltip: {
          callbacks: {
            label: context => `${context.dataset.label}: ${context.raw} (${scores[context.dataIndex].evaluation})`
          }
        }
      }
    }
  });

  // Khởi chạy
  // Khởi chạy
  calculateSummary();
  displayScoreTable(currentPage);
  return {
    event0: function (event) {
      exportGrades();
    },
    event1: function (event) {
      filterTable();
    }
  };
}

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
  // Dữ liệu của bảng
  const projects = [{
    id: 1,
    name: "Công nghệ phần mềm",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 2,
    name: "Lập trình trên môi trường Windows",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 3,
    name: "Trí tuệ nhân tạo",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 4,
    name: "Bảo mật thông tin",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 5,
    name: "Lập trình ứng dụng với Java",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 6,
    name: "Lập trình Web",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 7,
    name: "Cơ sở dữ liệu nâng cao",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 8,
    name: "Lập trình mạng máy tính",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 9,
    name: "Lập trình trên thiết bị di động",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 10,
    name: "Quản lý dự án công nghệ thông tin",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 11,
    name: "Lập trình hướng đối tượng",
    status: "Đã chấm điểm",
    progress: 100
  }, {
    id: 12,
    name: "Đồ án cơ sở Công nghệ thông tin",
    status: "Đã nộp",
    progress: 80
  }, {
    id: 13,
    name: "Đồ án chuyên ngành Công nghệ thông tin",
    status: "Đã nộp",
    progress: 90
  }, {
    id: 14,
    name: "Đồ án tốt nghiệp Công nghệ thông tin",
    status: "Chưa nộp",
    progress: 50
  }];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";

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
  function getFilteredProjects() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = projects.filter(project => project.name.toLowerCase().includes(searchText) && (statusFilter === "" || project.status === statusFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = a[sortColumn];
        let valueB = b[sortColumn];
        if (sortColumn === "name" || sortColumn === "status") {
          valueA = valueA.toLowerCase();
          valueB = valueB.toLowerCase();
        }
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }

  // Hiển thị bảng
  // Hiển thị bảng
  function displayTable(page) {
    const filteredProjects = getFilteredProjects();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredProjects.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Không tìm thấy học phần nào.</td></tr>");
    } else {
      paginatedData.forEach((project, index) => {
        const statusClass = project.status === "Đã chấm điểm" ? "bg-primary" : project.status === "Đã nộp" ? "bg-success" : "bg-warning";
        const progressClass = project.status === "Đã chấm điểm" ? "bg-primary" : project.status === "Đã nộp" ? "bg-success" : "bg-warning";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${project.name}</td>
                            <td><span class="badge ${statusClass}">${project.status}</span></td>
                            <td>
                                <div class="progress">
                                    <div class="progress-bar ${progressClass}" style="width: ${project.progress}%" aria-valuenow="${project.progress}" aria-valuemin="0" aria-valuemax="100">${project.progress}%</div>
                                </div>
                            </td>
                            <td><a href="student_tracking_details.html?id=${project.id}" class="btn btn-primary btn-sm">Xem tiến độ</a></td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredProjects.length);
  }

  // Thiết lập phân trang
  // Thiết lập phân trang
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

  // Lọc bảng
  // Lọc bảng
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }

  // Xuất dữ liệu sang Excel
  // Xuất dữ liệu sang Excel
  function exportProjects() {
    const filteredProjects = getFilteredProjects();
    const worksheetData = [["Danh sách đồ án - Theo dõi tiến độ"], [], ["#", "học phần", "Trạng thái", "Tiến độ"]];
    filteredProjects.forEach((project, index) => {
      worksheetData.push([index + 1, project.name, project.status, project.progress + "%"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachDoAn");
    XLSX.writeFile(workbook, "danh_sach_do_an.xlsx");
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", () => {
    displayTable(currentPage);
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportProjects();
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
      sortTable("status");
    },
    event6: function (event) {
      sortTable("progress");
    }
  };
}

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
  const proposals = [{
    id: 1,
    title: "Đồ án cơ sở",
    type: "Chuyên ngành",
    status: "Đã duyệt"
  }, {
    id: 2,
    title: "Đồ án chuyên ngành",
    type: "Chuyên ngành",
    status: "Chưa duyệt"
  }, {
    id: 3,
    title: "Đồ án tốt nghiệp",
    type: "Chuyên cơ sở",
    status: "Đã duyệt"
  }, {
    id: 4,
    title: "Đồ án 1",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 5,
    title: "Đồ án 2",
    type: "Chuyên ngành",
    status: "Đã duyệt"
  }, {
    id: 6,
    title: "Đồ án 3",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 7,
    title: "Đồ án 4",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 8,
    title: "Đồ án 5",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 9,
    title: "Đồ án 6",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 10,
    title: "Đồ án 7",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
  }, {
    id: 11,
    title: "Đồ án 8",
    type: "Chuyên cơ sở",
    status: "Chưa duyệt"
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

  // Lọc và sắp xếp bảng
  // Lọc và sắp xếp bảng
  function getFilteredProposals() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    const typeFilter = document.getElementById("typeFilter").value;
    let filtered = proposals.filter(proposal => proposal.title.toLowerCase().includes(searchText) && (statusFilter === "" || proposal.status === statusFilter) && (typeFilter === "" || proposal.type === typeFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        const valueA = a[sortColumn].toLowerCase();
        const valueB = b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filteredProposals = getFilteredProposals();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredProposals.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Không tìm thấy đề tài nào.</td></tr>");
    } else {
      paginatedData.forEach((proposal, index) => {
        const statusClass = proposal.status === "Đã duyệt" ? "bg-success" : "bg-warning";
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${proposal.title}</td>
                            <td>${proposal.type}</td>
                            <td><span class="badge ${statusClass}">${proposal.status}</span></td>
                            <td><a href="student_proposals_detail.html?id=${proposal.id}" class="btn btn-primary btn-sm">Xem chi tiết</a></td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredProposals.length);
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

  // Xuất danh sách đề xuất sang Excel
  // Xuất danh sách đề xuất sang Excel
  function exportProposals() {
    const filteredProposals = getFilteredProposals();
    const worksheetData = [["Danh sách đề xuất đề tài đồ án"], [], ["#", "Tên đề tài", "Loại đồ án", "Trạng thái"]];
    filteredProposals.forEach((proposal, index) => {
      worksheetData.push([index + 1, proposal.title, proposal.type, proposal.status]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DanhSachDeXuat");
    XLSX.writeFile(workbook, "danh_sach_de_xuat.xlsx");
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", () => {
    displayTable(currentPage);
  });
  return {
    event0: function (event) {
      exportProposals();
    },
    event1: function (event) {
      filterTable();
    },
    event2: function (event) {
      filterTable();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      sortTable("title");
    },
    event5: function (event) {
      sortTable("type");
    },
    event6: function (event) {
      sortTable("status");
    }
  };
}

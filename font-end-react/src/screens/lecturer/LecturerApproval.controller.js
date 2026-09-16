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
  let projects = [];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  const urlParams = new URLSearchParams(window.location.search);
  const selectedProjectId = urlParams.get("projectId");
  const selectedCourseId = urlParams.get("courseId");

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }
  async function loadProjects() {
    if (!selectedProjectId) {
      try {
        const response = await fetch(`${API_URL}/api/LecturerProjectApproval/course?courseId=${selectedCourseId}`, {
          method: "GET",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (!response.ok) throw new Error("Failed to load projects");
        projects = await response.json();
        displayTable(currentPage);
      } catch (error) {
        alert("Không thể tải đề tài.");
        document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Lỗi tải dữ liệu.</td></tr>");
      }
    } else {
      try {
        const response = await fetch(`${API_URL}/api/LecturerProjectApproval/project?projectId=${selectedProjectId}`, {
          method: "GET",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (!response.ok) throw new Error("Failed to load projects");
        projects = await response.json();
        displayTable(currentPage);
      } catch (error) {
        alert("Không thể tải đề tài.");
        document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"8\" class=\"text-center\">Lỗi tải dữ liệu.</td></tr>");
      }
    }
  }
  function getFilteredProjects() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const statusFilter = document.getElementById("statusFilter").value;
    let filtered = projects.filter(p => (p.projectId.toLowerCase().includes(searchText) || p.name.toLowerCase().includes(searchText) || p.groupName.toLowerCase().includes(searchText) || p.students.map(s => s.fullName.toLowerCase()).join(", ").includes(searchText)) && (!statusFilter || p.approvalStatus === statusFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "members" ? a.students.map(s => s.fullName).join(", ").toLowerCase() : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "members" ? b.students.map(s => s.fullName).join(", ").toLowerCase() : b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page) {
    const filtered = getFilteredProjects();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginated = filtered.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html(paginated.length ? paginated.map((p, i) => {
      const statusClass = p.approvalStatus === "APPROVED" ? "bg-success" : p.approvalStatus === "REJECTED" ? "bg-danger" : "bg-warning";
      return `
                    <tr>
                        <td>${start + i + 1}</td>
                        <td>${p.projectId}</td>
                        <td><a href="#" data-page-click="${env.bind(function (event) {
        showDescription(String(p.id));
      })}">${p.name}</a></td>
                        <td>${p.groupName}</td>
                        <td>${p.students.map(s => s.fullName).join(", ")}</td>
                        <td><ul class="file-list">${p.descriptionFilePath.length ? p.descriptionFilePath.map(f => {
        const fileName = f.split("/").pop();
        const student = p.students.find(s => f.includes(s.username)) || p.students[0];
        return `<li><a href="${API_URL}/api/File/files/${f}" target="_blank">${fileName} (${student.username} - ${student.fullName})</a></li>`;
      }).join("") : "<li>Chưa có</li>"}</ul></td>
                        <td><span class="badge ${statusClass}">${p.approvalStatus === "APPROVED" ? "Đã duyệt" : p.approvalStatus === "REJECTED" ? "Từ chối" : "Chưa duyệt"}</span></td>
                        <td>
                            <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
        approveProject(String(p.id));
      })}" ${p.approvalStatus !== "PENDING" ? "disabled" : ""}>
                                <i class="bi bi-check-circle"></i> Duyệt/Từ chối
                            </button>
                        </td>
                    </tr>
                `;
    }).join("") : "<tr><td colspan=\"8\" class=\"text-center\">Không tìm thấy đề tài.</td></tr>");
    setupPagination(filtered.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html(totalPages <= 1 ? "" : `
                <li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>
                ${currentPage > 2 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>` : ""}
                ${currentPage > 3 ? `<li class="page-item disabled"><span class="page-link">...</span></li>` : ""}
                ${currentPage > 1 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>` : ""}
                <li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>
                ${currentPage < totalPages ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>` : ""}
                ${currentPage < totalPages - 2 ? `<li class="page-item disabled"><span class="page-link">...</span></li>` : ""}
                ${currentPage < totalPages - 1 ? `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>` : ""}
                <li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>
            `);
  }
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }
  function sortTable(column) {
    sortColumn = sortColumn === column ? sortColumn : column;
    sortDirection = sortColumn === column && sortDirection === "asc" ? "desc" : "asc";
    displayTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function showDescription(projectId) {
    const project = projects.find(p => String(p.id) === String(projectId));
    if (project) {
      document.getElementById("modalDescription").textContent = project.description || "Chưa có";
      new bootstrap.Modal(document.getElementById("descriptionModal")).show();
    }
  }
  function approveProject(projectId) {
    const project = projects.find(p => String(p.id) === String(projectId));
    if (project) {
      document.getElementById("approvalProjectId").value = project.id;
      document.getElementById("approvalProjectCode").value = project.projectId;
      document.getElementById("approvalProjectName").value = project.name;
      document.getElementById("approvalGroupName").value = project.groupName;
      document.getElementById("approvalMembers").value = project.students.map(s => s.fullName).join(", ");
      document.getElementById("approvalFiles").innerHTML = env.html(project.descriptionFilePath.length ? project.descriptionFilePath.map(f => {
        const fileName = f.split("/").pop();
        const student = project.students.find(s => f.includes(s.username)) || project.students[0];
        return `<li><a href="${API_URL}/api/File/files/${f}" target="_blank">${fileName} (${student.username} - ${student.fullName})</a></li>`;
      }).join("") : "<li>Chưa có</li>");
      document.getElementById("approvalDescription").value = project.description || "Chưa có";
      document.getElementById("approvalStatus").value = project.approvalStatus;
      document.getElementById("approvalReason").value = project.approvalReason || "";
      toggleReasonField(project.approvalStatus);
      document.getElementById("approvalStatus").onchange = e => toggleReasonField(e.target.value);
      new bootstrap.Modal(document.getElementById("approvalModal")).show();
    }
  }
  function toggleReasonField(status) {
    document.getElementById("reasonField").style.display = status === "REJECTED" ? "block" : "none";
  }
  async function saveApproval() {
    const form = document.getElementById("approvalForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const projectId = document.getElementById("approvalProjectCode").value;
    const status = document.getElementById("approvalStatus").value;
    const reason = document.getElementById("approvalReason").value;
    if (status === "REJECTED" && !reason.trim()) {
      alert("Vui lòng nhập lý do từ chối!");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerProjectApproval/${projectId}`, {
        method: "PUT",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify({
          approvalStatus: status,
          approvalReason: reason
        })
      });
      if (!response.ok) throw new Error("Failed to save approval");
      alert(`Đã cập nhật trạng thái: ${status}${reason ? ` (Lý do: ${reason})` : ""}`);
      bootstrap.Modal.getInstance(document.getElementById("approvalModal")).hide();
      await loadProjects();
    } catch (error) {
      alert("Lỗi khi lưu trạng thái.");
    }
  }
  function exportApprovals() {
    const filtered = getFilteredProjects();
    const data = [["Danh sách duyệt đề tài - HUTECH"], ["Giảng viên: " + document.getElementById("userName").textContent], [], ["#", "Mã đề tài", "Tên đề tài", "Tên nhóm", "Thành viên", "File mô tả", "Trạng thái duyệt", "Lý do từ chối"]].concat(filtered.map((p, i) => [i + 1, p.projectId, p.name, p.groupName, p.students.map(s => s.fullName).join(", "), p.descriptionFilePath.map(f => {
      const fileName = f.split("/").pop();
      const student = p.students.find(s => f.includes(s.username)) || p.students[0];
      return `${fileName} (${student.username} - ${student.fullName})`;
    }).join("; ") || "Chưa có", p.approvalStatus === "APPROVED" ? "Đã duyệt" : p.approvalStatus === "REJECTED" ? "Từ chối" : "Chưa duyệt", p.approvalReason || ""]));
    const worksheet = XLSX.utils.aoa_to_sheet(data);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DuyetDeTai");
    XLSX.writeFile(workbook, `duyet_de_tai_${selectedProjectId || selectedCourseId}.xlsx`);
  }
  function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list");
    icon.classList.toggle("bi-layout-sidebar-inset");
  }
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => {
    env.navigate("/font-end/lecturer/lecturer_notifications.html");
  });
  env.listen(document.getElementById("profileBtn"), "click", e => {
    e.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", e => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(e.target) && e.target.id !== "profileBtn") {
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

  // Ghi chú: Đăng xuất
  // Ghi chú: Đăng xuất
  async function logout() {
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
      const text = await response.text();
      if (response.ok) {
        const data = text ? JSON.parse(text) : {};
        alert(data.message || "Đã đăng xuất thành công.");
      } else {
        const data = text ? JSON.parse(text) : {};
        alert(`Đăng xuất thất bại: ${data.message || response.statusText}`);
      }
    } catch (error) {
      alert("Đăng xuất bị lỗi: " + error.message);
      console.error("Đăng xuất bị lỗi:", error);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadProjects();
    } catch (error) {
      console.error("Lỗi khi tải bảng điều khiển:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      logout();
    }
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      exportApprovals();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      sortTable("projectId");
    },
    event6: function (event) {
      sortTable("name");
    },
    event7: function (event) {
      sortTable("groupName");
    },
    event8: function (event) {
      sortTable("members");
    },
    event9: function (event) {
      sortTable("approvalStatus");
    },
    event10: function (event) {
      saveApproval();
    }
  };
}

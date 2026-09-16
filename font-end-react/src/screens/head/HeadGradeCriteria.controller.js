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
  function escapeHtml(value) {
    return String(value ?? "").replace(/[&<>"']/g, character => ({
      "&": "&amp;",
      "<": "&lt;",
      ">": "&gt;",
      "\"": "&quot;",
      "'": "&#39;"
    })[character]);
  }
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let gradeCriteriaList = [];
  let headLecturerId = null;
  let courseId = null;
  let courseName = "Học phần";
  function getQueryParams() {
    const params = new URLSearchParams(window.location.search);
    courseId = parseInt(params.get("courseId")) || null;
    headLecturerId = parseInt(params.get("headLecturer")) || null;
  }
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user") || "{}");
      if (!user || user.roleName !== "ROLE_HEAD" || !user.id) {
        throw new Error("Không có quyền Trưởng bộ môn hoặc chưa đăng nhập.");
      }
      if (!headLecturerId) headLecturerId = user.id;
      if (headLecturerId !== user.id) throw new Error("ID Trưởng bộ môn không khớp.");
      document.getElementById("headName").textContent = user.fullName || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      showToast(`Vui lòng đăng nhập lại: ${error.message}`, true);
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function loadCourseName() {
    if (!courseId) {
      showToast("Không tìm thấy học phần.", true);
      env.navigate("/font-end/head/head_course_list.html", true);
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria/courses?headLecturer=${headLecturerId}`, {
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải thông tin học phần: ${await response.text()}`);
      const courses = await response.json();
      const course = courses.find(c => c.id === courseId);
      if (!course) throw new Error("Học phần không tồn tại hoặc không thuộc quyền quản lý.");
      courseName = course.name;
      document.getElementById("courseName").textContent = courseName;
      document.getElementById("addCourseId").value = courseId;
      document.getElementById("editCourseId").value = courseId;
    } catch (error) {
      showToast(`Lỗi tải thông tin học phần: ${error.message}`, true);
      env.navigate("/font-end/head/head_course_list.html", true);
    }
  }
  async function loadGradeCriteria() {
    if (!courseId) return;
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria?headLecturer=${headLecturerId}`, {
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách tiêu chí: ${await response.text()}`);
      gradeCriteriaList = (await response.json()).filter(c => c.courseId === courseId);
      displayTable(currentPage);
    } catch (error) {
      showToast(`Lỗi tải danh sách tiêu chí: ${error.message}`, true);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"5\" class=\"text-center\">Không thể tải danh sách tiêu chí.</td></tr>");
    }
  }
  function displayTable(page) {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const filtered = gradeCriteriaList.filter(c => c.name.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "weight" ? a[sortColumn] : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "weight" ? b[sortColumn] : b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginated = filtered.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html(paginated.length === 0 ? "<tr><td colspan=\"5\" class=\"text-center\">Không tìm thấy tiêu chí.</td></tr>" : paginated.map((c, i) => `
                    <tr>
                        <td>${start + i + 1}</td>
                        <td>${escapeHtml(c.name)}</td>
                        <td>${(c.weight * 100).toFixed(0)}%</td>
                        <td>${escapeHtml(c.description || "N/A")}</td>
                        <td>
                            <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
      editGradeCriteria(c.id);
    })}"><i class="bi bi-pencil"></i> Sửa</button>
                            <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
      deleteGradeCriteria(c.id);
    })}"><i class="bi bi-trash"></i> Xóa</button>
                        </td>
                    </tr>
                `).join(""));
    setupPagination(filtered.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`);
    if (currentPage > 2) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`);
    if (currentPage > 3) pagination.innerHTML += env.html(`<li class="page-item disabled"><span class="page-link">...</span></li>`);
    if (currentPage > 1) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`);
    pagination.innerHTML += env.html(`<li class="page-item active"><a class="page-link" href="#">${currentPage}</a></li>`);
    if (currentPage < totalPages) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`);
    if (currentPage < totalPages - 2) pagination.innerHTML += env.html(`<li class="page-item disabled"><span class="page-link">...</span></li>`);
    if (currentPage < totalPages - 1) pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`);
    pagination.innerHTML += env.html(`<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`);
  }
  function changePage(page) {
    currentPage = page;
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
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function showToast(message, isError = false) {
    const toast = new bootstrap.Toast(document.getElementById("toast"));
    const toastBody = document.querySelector(".toast-body");
    toastBody.textContent = message;
    toastBody.className = `toast-body ${isError ? "bg-danger text-white" : "bg-success text-white"}`;
    toast.show();
  }
  async function addGradeCriteria() {
    const form = document.getElementById("addForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const criteria = {
      courseId: parseInt(document.getElementById("addCourseId").value),
      name: document.getElementById("addName").value.trim(),
      weight: parseFloat(document.getElementById("addWeight").value),
      description: document.getElementById("addDescription").value.trim() || null
    };
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria?headLecturer=${headLecturerId}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(criteria)
      });
      if (!response.ok) throw new Error((await response.json()).message || "Lỗi khi thêm tiêu chí.");
      bootstrap.Modal.getInstance(document.getElementById("addModal")).hide();
      form.reset();
      await loadGradeCriteria();
      showToast("Thêm tiêu chí thành công!");
    } catch (error) {
      showToast(`Lỗi khi thêm tiêu chí: ${error.message}`, true);
    }
  }
  function editGradeCriteria(id) {
    const criteria = gradeCriteriaList.find(c => c.id === id);
    if (!criteria) {
      showToast("Tiêu chí không tồn tại.", true);
      return;
    }
    document.getElementById("editId").value = criteria.id;
    document.getElementById("editCourseId").value = criteria.courseId;
    document.getElementById("editName").value = criteria.name;
    document.getElementById("editWeight").value = criteria.weight;
    document.getElementById("editDescription").value = criteria.description || "";
    new bootstrap.Modal(document.getElementById("editModal")).show();
  }
  async function updateGradeCriteria() {
    const form = document.getElementById("editForm");
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const criteria = {
      id: parseInt(document.getElementById("editId").value),
      courseId: parseInt(document.getElementById("editCourseId").value),
      name: document.getElementById("editName").value.trim(),
      weight: parseFloat(document.getElementById("editWeight").value),
      description: document.getElementById("editDescription").value.trim() || null
    };
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria/${criteria.id}?headLecturer=${headLecturerId}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(criteria)
      });
      if (!response.ok) throw new Error((await response.json()).message || "Lỗi khi cập nhật tiêu chí.");
      bootstrap.Modal.getInstance(document.getElementById("editModal")).hide();
      await loadGradeCriteria();
      showToast("Cập nhật tiêu chí thành công!");
    } catch (error) {
      showToast(`Lỗi khi cập nhật tiêu chí: ${error.message}`, true);
    }
  }
  async function deleteGradeCriteria(id) {
    if (!confirm("Xác nhận xóa tiêu chí này?")) return;
    try {
      const response = await fetch(`${API_URL}/api/HeadGradeCriteria/${id}?headLecturer=${headLecturerId}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error((await response.json()).message || "Lỗi khi xóa tiêu chí.");
      await loadGradeCriteria();
      showToast("Xóa tiêu chí thành công!");
    } catch (error) {
      showToast(`Lỗi khi xóa tiêu chí: ${error.message}`, true);
    }
  }
  async function importExcel(event) {
    const file = event.target.files[0];
    if (!file) {
      showToast("Vui lòng chọn file Excel.", true);
      return;
    }
    const reader = new FileReader();
    reader.onload = async e => {
      try {
        const workbook = XLSX.read(e.target.result, {
          type: "array"
        });
        const sheet = workbook.Sheets[workbook.SheetNames[0]];
        const rows = XLSX.utils.sheet_to_json(sheet, {
          header: ["name", "courseId", "weight", "description"],
          skipHeader: true
        });
        const criteriaList = rows.map(row => ({
          courseId: courseId,
          name: row.name?.trim(),
          weight: parseFloat(row.weight),
          description: row.description?.trim() || null
        })).filter(c => c.name && c.weight >= 0 && c.weight <= 1);
        if (!criteriaList.length) throw new Error("File Excel không chứa dữ liệu hợp lệ.");
        const response = await fetch(`${API_URL}/api/HeadGradeCriteria/import?headLecturer=${headLecturerId}`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(criteriaList)
        });
        if (!response.ok) throw new Error((await response.json()).message || "Lỗi khi nhập Excel.");
        const result = await response.json();
        let message = `Nhập thành công ${result.successCount} tiêu chí.`;
        if (result.failedCount > 0) message += `\nLỗi: ${result.errors.join("; ")}`;
        await loadGradeCriteria();
        showToast(message, result.failedCount > 0);
        event.target.value = "";
      } catch (error) {
        showToast(`Lỗi nhập Excel: ${error.message}`, true);
      }
    };
    reader.readAsArrayBuffer(file);
  }
  function exportExcel() {
    const user = JSON.parse(localStorage.getItem("user") || "{}");
    const worksheetData = [["Danh sách tiêu chí chấm điểm - Hệ thống Sinh viên HUTECH"], [`Trưởng bộ môn: ${user.fullName || "Head HUTECH"}`], [`Học phần: ${courseName}`], [], ["Tên tiêu chí", "Trọng số", "Mô tả"], ...gradeCriteriaList.map(c => [c.name, c.weight, c.description || "N/A"])];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "TieuChi");
    XLSX.writeFile(workbook, `tieu_chi_cham_diem_${courseId}.xlsx`);
  }
  async function logout() {
    try {
      const response = await fetch(`${API_URL}/api/Auth/logout`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${await response.text()}`);
      showToast("Đăng xuất thành công!");
      localStorage.removeItem("user");
      localStorage.removeItem("token");
      env.navigate("/font-end/login/login.html", true);
    } catch (error) {
      showToast(`Lỗi đăng xuất: ${error.message}`, true);
    }
  }
  env.listen(document, "DOMContentLoaded", async () => {
    getQueryParams();
    await loadUserProfile();
    await loadCourseName();
    await loadGradeCriteria();
  });
  function toggleSidebar() {
    document.querySelector(".sidebar")?.classList.toggle("collapsed");
    document.querySelector(".content")?.classList.toggle("expanded");
  }
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      filterTable();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      importExcel(event);
    },
    event4: function (event) {
      exportExcel();
    },
    event5: function (event) {
      sortTable("name");
    },
    event6: function (event) {
      sortTable("weight");
    },
    event7: function (event) {
      addGradeCriteria();
    },
    event8: function (event) {
      updateGradeCriteria();
    }
  };
}

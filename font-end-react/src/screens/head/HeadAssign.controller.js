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
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let students = [];
  let lecturers = [];
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_HEAD") throw new Error("Không có quyền Trưởng bộ môn.");
      document.getElementById("headName").textContent = user.fullName || "Head HUTECH";
      document.getElementById("headEmail").textContent = user.email || "head@hutech.edu.vn";
    } catch (error) {
      alert("Vui lòng đăng nhập lại!");
      env.navigate("/font-end/login/login.html", true);
    }
  }
  async function loadLecturers() {
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment/lecturers?courseId=${courseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách giảng viên: ${await response.text()}`);
      lecturers = await response.json();
      const select = document.getElementById("assignLecturer");
      select.innerHTML = env.html("<option value=\"\">Chọn giảng viên</option>");
      lecturers.forEach(lecturer => {
        const option = document.createElement("option");
        option.value = lecturer.fullName;
        option.textContent = lecturer.fullName;
        select.appendChild(option);
      });
    } catch (error) {
      console.error("Lỗi tải danh sách giảng viên:", error);
      alert(`Không thể tải danh sách giảng viên: ${error.message}`);
    }
  }
  async function loadStudents() {
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    if (!courseId) {
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Thiếu thông tin học phần.</td></tr>");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment/students?courseId=${courseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách sinh viên: ${await response.text()}`);
      students = await response.json();
      document.getElementById("courseCodeDisplay").value = students[0]?.courseCode || "";
      document.getElementById("semesterNameDisplay").value = "";
      document.getElementById("facultyCodeDisplay").value = "";
      displayTable(currentPage);
    } catch (error) {
      console.error("Lỗi tải danh sách sinh viên:", error);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không thể tải danh sách sinh viên.</td></tr>");
    }
  }
  function displayTable(page) {
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = students.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy sinh viên.</td></tr>");
    } else {
      paginatedData.forEach((student, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${student.studentCode}</td>
                            <td>${student.fullName}</td>
                            <td>${student.courseCode}</td>
                            <td>${student.lecturerName || "Chưa phân công"}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" data-page-click="${env.bind(function (event) {
          assignLecturer(student.id);
        })}">
                                    <i class="bi bi-person-plus"></i> Phân công
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(students.length);
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
    students.sort((a, b) => {
      let valueA = a[sortColumn] ? a[sortColumn].toLowerCase() : "";
      let valueB = b[sortColumn] ? b[sortColumn].toLowerCase() : "";
      return sortDirection === "asc" ? valueA.localeCompare(valueB) : valueB.localeCompare(valueA);
    });
    displayTable(currentPage);
  }
  function filterTable() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const originalStudents = [...students];
    students = originalStudents.filter(student => student.studentCode.toLowerCase().includes(searchText) || student.fullName.toLowerCase().includes(searchText) || (student.lecturerName && student.lecturerName.toLowerCase().includes(searchText)));
    currentPage = 1;
    displayTable(currentPage);
  }
  function assignLecturer(studentId) {
    const student = students.find(s => s.id === studentId);
    if (student) {
      document.getElementById("assignStudentId").value = student.id;
      document.getElementById("assignStudentCode").value = student.studentCode;
      document.getElementById("assignStudentName").value = student.fullName;
      document.getElementById("assignCourseCode").value = student.courseCode;
      document.getElementById("assignLecturer").value = student.lecturerName || "";
      new bootstrap.Modal(document.getElementById("assignModal")).show();
    }
  }
  async function showAutoAssignModal() {
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    if (!courseId) {
      alert("Thiếu thông tin học phần.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment/available-lecturers?courseId=${courseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Lỗi tải danh sách giảng viên: ${await response.text()}`);
      const lecturers = await response.json();
      const checkboxesDiv = document.getElementById("lecturerCheckboxes");
      checkboxesDiv.innerHTML = env.html("");
      lecturers.forEach(lecturer => {
        const div = document.createElement("div");
        div.className = "form-check";
        div.innerHTML = env.html(`<input type="checkbox" class="form-check-input" id="lecturer_${lecturer.id}" value="${lecturer.id}">
                                     <label class="form-check-label" for="lecturer_${lecturer.id}">${lecturer.fullName}</label>`);
        checkboxesDiv.appendChild(div);
      });
      new bootstrap.Modal(document.getElementById("autoAssignModal")).show();
    } catch (error) {
      console.error("Lỗi tải danh sách giảng viên:", error);
      alert(`Không thể tải danh sách giảng viên: ${error.message}`);
    }
  }
  async function confirmAutoAssign() {
    const checkboxes = document.querySelectorAll("#lecturerCheckboxes input[type=\"checkbox\"]:checked");
    const selectedLecturerIds = Array.from(checkboxes).map(cb => parseInt(cb.value));
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    if (!courseId) {
      alert("Thiếu thông tin học phần.");
      return;
    }
    if (selectedLecturerIds.length < 1) {
      alert("Vui lòng chọn ít nhất một giảng viên.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment/auto-assign?courseId=${courseId}`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(selectedLecturerIds)
      });
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || `Lỗi phân công tự động: ${response.statusText}`);
      }
      alert("Phân công tự động thành công!");
      bootstrap.Modal.getInstance(document.getElementById("autoAssignModal")).hide();
      await loadStudents();
    } catch (error) {
      console.error("Lỗi phân công tự động:", error);
      alert(`Không thể phân công tự động: ${error.message}`);
    }
  }
  async function saveAssignment() {
    const form = document.getElementById("assignForm");
    if (form.checkValidity()) {
      const studentId = document.getElementById("assignStudentId").value;
      const lecturerName = document.getElementById("assignLecturer").value;
      const urlParams = new URLSearchParams(window.location.search);
      const courseId = urlParams.get("courseId");
      try {
        const response = await fetch(`${API_URL}/api/HeadCourseAssignment/assign?courseId=${courseId}`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify({
            studentId: parseInt(studentId),
            lecturerName
          })
        });
        alert(`Đã phân công ${lecturerName} cho ${document.getElementById("assignStudentName").value}`);
        bootstrap.Modal.getInstance(document.getElementById("assignModal")).hide();
        await loadStudents();
      } catch (error) {
        console.error("Lỗi lưu phân công:", error);
        alert(`Không thể lưu phân công: ${error.message}`);
      }
    } else {
      form.reportValidity();
    }
  }
  function exportAssignments() {
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    const worksheetData = [["Danh sách phân công GVHD - Hệ thống Sinh viên HUTECH"], [`Học phần: ${courseId}`], [], ["#", "Mã SV", "Tên SV", "Học phần", "Giảng viên hướng dẫn"]];
    students.forEach((student, index) => {
      worksheetData.push([index + 1, student.studentCode, student.fullName, student.courseCode, student.lecturerName || "Chưa phân công"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "PhanCongGVHD");
    XLSX.writeFile(workbook, `phan_cong_gvhd_${courseId}.xlsx`);
  }
  async function importAssignments(event) {
    const file = event.target.files[0];
    if (!file) {
      alert("Vui lòng chọn file Excel.");
      return;
    }
    const formData = new FormData();
    formData.append("file", file);
    const urlParams = new URLSearchParams(window.location.search);
    const courseId = urlParams.get("courseId");
    if (!courseId) {
      alert("Thiếu thông tin học phần.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/HeadCourseAssignment/import?courseId=${courseId}`, {
        method: "POST",
        headers: {
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: formData
      });
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || `Lỗi nhập phân công từ Excel: ${response.statusText}`);
      }
      alert("Nhập phân công từ Excel thành công!");
      await loadStudents();
      event.target.value = "";
    } catch (error) {
      console.error("Lỗi nhập phân công từ Excel:", error);
      alert(`Không thể nhập phân công từ Excel: ${error.message}`);
    }
  }
  env.listen(document.getElementById("toggleSidebarBtn"), "click", toggleSidebar);
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/head/lecturer_notifications.html"));
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
  function toggleSidebar() {
    const sidebar = document.querySelector(".sidebar");
    const content = document.querySelector(".content");
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    icon.classList.toggle("bi-list", !sidebar.classList.contains("collapsed"));
    icon.classList.toggle("bi-layout-sidebar-inset", sidebar.classList.contains("collapsed"));
  }
  async function logout() {
    try {
      const token = localStorage.getItem("token");
      if (!token) throw new Error("Chưa đăng nhập.");
      const response = await fetch(`${API_URL}/api/Auth/logout`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error(`Đăng xuất thất bại: ${response.statusText}`);
      alert("Đăng xuất thành công!");
    } catch (error) {
      alert(`Lỗi đăng xuất: ${error.message}`);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    await loadUserProfile();
    await loadLecturers();
    await loadStudents();
  });
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
      showAutoAssignModal();
    },
    event4: function (event) {
      exportAssignments();
    },
    event5: function (event) {
      importAssignments(event);
    },
    event6: function (event) {
      sortTable("studentCode");
    },
    event7: function (event) {
      sortTable("fullName");
    },
    event8: function (event) {
      sortTable("lecturerName");
    },
    event9: function (event) {
      confirmAutoAssign();
    },
    event10: function (event) {
      saveAssignment();
    }
  };
}

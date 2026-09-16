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
  // Cấu hình API
  const API_URL = window.EDU_CONFIG.apiBaseUrl + "";
  let token = localStorage.getItem("token");
  let fullNameLecturer = null;
  let courses = [];
  let projects = [];
  let semesters = [];
  let tasks = [];

  // Navbar functions
  // Navbar functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("lecturer_notifications.html"));
  env.listen(document.getElementById("profileBtn"), "click", event => {
    event.stopPropagation();
    const dropdown = document.getElementById("profileDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
  });
  env.listen(document, "click", event => {
    const dropdown = document.getElementById("profileDropdown");
    if (!dropdown.contains(event.target) && event.target.id !== "profileBtn") dropdown.style.display = "none";
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

  // Toggle sidebar
  // Toggle sidebar
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

  // Tải thông tin người dùng
  // Tải thông tin người dùng
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Admin hoặc chưa đăng nhập.");
      }
      fullNameLecturer = user.fullName;
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Lấy danh sách học phần
  // Lấy danh sách học phần
  async function loadCourses() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerCourses`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể lấy học phần");
      courses = await response.json();
      const courseSelect = document.getElementById("courseFilter");
      const taskCourseSelect = document.getElementById("taskCourseId");
      courseSelect.innerHTML = env.html("<option value=''>Tất cả học phần</option>");
      taskCourseSelect.innerHTML = env.html("<option value=''>Chọn học phần</option>");
      courses.forEach(c => {
        courseSelect.innerHTML += env.html(`<option value="${c.courseId}">${c.name}</option>`);
        taskCourseSelect.innerHTML += env.html(`<option value="${c.courseId}">${c.name}</option>`);
      });
    } catch (e) {
      console.error("Lỗi khi tải học phần:", e);
    }
  }

  // Lấy danh sách dự án theo học phần
  // Lấy danh sách dự án theo học phần
  async function updateProjectOptions() {
    const courseId = document.getElementById("taskCourseId").value;
    try {
      const response = await fetch(`${API_URL}/api/LecturerProjectApproval/course?courseId=${courseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể lấy dự án");
      projects = await response.json();
      const projectSelect = document.getElementById("taskProjectId");
      projectSelect.innerHTML = env.html("<option value=''>Chọn đồ án</option>");
      projects.forEach(p => {
        projectSelect.innerHTML += env.html(`<option value="${p.projectId}">${p.projectId} - ${p.name}</option>`);
      });
    } catch (e) {
      console.error("Lỗi khi tải dự án:", e);
    }
  }

  // Lấy danh sách học kỳ
  // Lấy danh sách học kỳ
  async function loadSemesters() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerTask/semesters`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể lấy học kỳ");
      semesters = await response.json();
      const semesterSelect = document.getElementById("semesterFilter");
      semesterSelect.innerHTML = env.html("<option value=''>Tất cả học kỳ</option>");
      semesters.forEach(s => {
        semesterSelect.innerHTML += env.html(`<option value="${s}">${s}</option>`);
      });
    } catch (e) {
      console.error("Lỗi khi tải học kỳ:", e);
    }
  }

  // Lọc và tải công việc
  // Lọc và tải công việc
  async function filterTasks() {
    const searchText = document.querySelector(".search-box").value.toLowerCase();
    const courseFilter = document.getElementById("courseFilter").value;
    const projectFilter = document.getElementById("projectFilter").value;
    const semesterFilter = document.getElementById("semesterFilter").value;
    const statusFilter = document.getElementById("statusFilter").value;
    try {
      const queryParams = new URLSearchParams({
        ...(courseFilter && {
          courseId: courseFilter
        }),
        ...(projectFilter && {
          projectId: projectFilter
        }),
        ...(semesterFilter && {
          semester: semesterFilter
        }),
        ...(statusFilter && {
          status: statusFilter
        })
      });
      const response = await fetch(`${API_URL}/api/LecturerTask?courseId=${courseFilter}&projectId=${projectFilter}&semester=${semesterFilter}&status=${statusFilter}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể tải công việc");
      tasks = await response.json();

      // Lọc theo tìm kiếm
      const filteredTasks = tasks.filter(task => task.projectId.toLowerCase().includes(searchText) || task.taskDescription.toLowerCase().includes(searchText));

      // Cập nhật danh sách dự án trong bộ lọc
      const projectSelect = document.getElementById("projectFilter");
      projectSelect.innerHTML = env.html("<option value=''>Tất cả đồ án</option>");
      const filteredProjects = courseFilter ? projects.filter(p => p.courseId === courseFilter) : projects;
      filteredProjects.forEach(p => {
        projectSelect.innerHTML += env.html(`<option value="${p.projectId}">${p.projectId} - ${p.name}</option>`);
      });
      displayTasks(filteredTasks);
    } catch (e) {
      console.error("Lỗi khi tải công việc:", e);
      document.getElementById("tasksAccordion").innerHTML = env.html("<p class=\"text-center\">Không tìm thấy công việc nào.</p>");
    }
  }

  // Hiển thị công việc theo dạng accordion
  // Hiển thị công việc theo dạng accordion
  function displayTasks(filteredTasks) {
    const accordion = document.getElementById("tasksAccordion");
    accordion.innerHTML = env.html("");
    const tasksByCourse = {};
    filteredTasks.forEach(task => {
      if (!tasksByCourse[task.courseId]) tasksByCourse[task.courseId] = {};
      if (!tasksByCourse[task.courseId][task.projectId]) tasksByCourse[task.courseId][task.projectId] = [];
      tasksByCourse[task.courseId][task.projectId].push(task);
    });
    Object.entries(tasksByCourse).forEach(([courseId, courseTasks], courseIndex) => {
      const course = courses.find(c => c.courseId === courseId) || {
        name: courseId
      };
      const courseAccordionItem = `
                    <div class="accordion-item">
                        <h2 class="accordion-header" id="courseHeading${courseId}">
                            <button class="accordion-button ${courseIndex === 0 ? "" : "collapsed"}" type="button" data-bs-toggle="collapse" data-bs-target="#courseCollapse${courseId}" aria-expanded="${courseIndex === 0}" aria-controls="courseCollapse${courseId}">
                                ${courseId} - ${course.name} (${Object.values(courseTasks).flat().length} công việc)
                            </button>
                        </h2>
                        <div id="courseCollapse${courseId}" class="accordion-collapse collapse ${courseIndex === 0 ? "show" : ""}" aria-labelledby="courseHeading${courseId}" data-bs-parent="#tasksAccordion">
                            <div class="accordion-body">
                                <div class="accordion" id="courseAccordion${courseId}">
                                    ${Object.entries(courseTasks).map(([projectId, projectTasks], projectIndex) => {
        const project = projects.find(p => p.projectId === projectId) || {
          name: projectId
        };
        return `
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="projectHeading${courseId}_${projectId}">
                                                    <button class="accordion-button ${projectIndex === 0 ? "" : "collapsed"}" type="button" data-bs-toggle="collapse" data-bs-target="#projectCollapse${projectId}" aria-expanded="${projectIndex === 0}" aria-controls="projectCollapse${projectId}">
                                                        ${projectId} - ${project.name} (${projectTasks.length} công việc)
                                                    </button>
                                                </h2>
                                                <div id="projectCollapse${projectId}" class="accordion-collapse collapse ${projectIndex === 0 ? "show" : ""}" aria-labelledby="projectHeading${projectId}" data-bs-parent="#courseAccordion${courseId}">
                                                    <div class="accordion-body">
                                                        <table class="table-custom table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>#</th>
                                                                    <th>Công việc</th>
                                                                    <th>Học kỳ</th>
                                                                    <th>Thời gian bắt đầu</th>
                                                                    <th>Thời gian hết hạn</th>
                                                                    <th>Trạng thái</th>
                                                                    <th>Hành động</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                ${projectTasks.map((task, taskIndex) => {
          const statusClass = task.status === "Quá hạn" ? "bg-danger" : task.status === "Đã hoàn thành" ? "bg-success" : "bg-warning";
          return `
                                                                        <tr>
                                                                            <td>${taskIndex + 1}</td>
                                                                            <td>${task.taskDescription}</td>
                                                                            <td>${task.semester}</td>
                                                                            <td>${formatDate(task.startDate)}</td>
                                                                            <td>${formatDate(task.dueDate)}</td>
                                                                            <td><span class="badge ${statusClass}">${task.status}</span></td>
                                                                            <td>
                                                                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
            editTask(task.id);
          })}"><i class="bi bi-pencil"></i></button>
                                                                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
            deleteTask(task.id);
          })}"><i class="bi bi-trash"></i></button>
                                                                            </td>
                                                                        </tr>
                                                                    `;
        }).join("")}
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        `;
      }).join("")}
                                </div>
                            </div>
                        </div>
                    </div>
                `;
      accordion.innerHTML += env.html(courseAccordionItem);
    });
    if (accordion.innerHTML === "") {
      accordion.innerHTML = env.html("<p class=\"text-center\">Không tìm thấy công việc nào.</p>");
    }
  }

  // Định dạng ngày
  // Định dạng ngày
  function formatDate(date) {
    if (!date) return "";
    const d = new Date(date);
    return d.toISOString().split("T")[0];
  }

  // Thêm công việc
  // Thêm công việc
  async function addTask() {
    const form = document.getElementById("addTaskForm");
    if (form.checkValidity()) {
      try {
        const taskData = {
          courseId: document.getElementById("taskCourseId").value,
          projectId: document.getElementById("taskProjectId").value,
          taskDescription: document.getElementById("taskDescription").value,
          startDate: document.getElementById("taskStartDate").value,
          dueDate: document.getElementById("taskDueDate").value
        };
        const response = await fetch(`${API_URL}/api/LecturerTask`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(taskData)
        });
        if (!response.ok) throw new Error("Không thể thêm công việc");
        const newTask = await response.json();
        alert(`Đã thêm công việc: ${newTask.taskDescription} cho đồ án ${newTask.projectId}`);
        bootstrap.Modal.getInstance(document.getElementById("addTaskModal")).hide();
        await filterTasks();
      } catch (e) {
        console.error("Lỗi khi thêm công việc:", e);
        alert("Lỗi khi thêm công việc");
      }
    } else {
      form.reportValidity();
    }
  }

  // Sửa công việc
  // Sửa công việc
  function editTask(taskId) {
    const task = tasks.find(t => t.id === taskId);
    if (task) {
      document.getElementById("editTaskId").value = task.id;
      document.getElementById("editTaskProjectId").value = task.projectId;
      document.getElementById("editTaskDescription").value = task.taskDescription;
      document.getElementById("editTaskStartDate").value = formatDate(task.startDate);
      document.getElementById("editTaskDueDate").value = formatDate(task.dueDate);
      document.getElementById("editTaskStatus").value = task.status;
      const modal = new bootstrap.Modal(document.getElementById("editTaskModal"));
      modal.show();
    }
  }
  async function saveEditTask() {
    const form = document.getElementById("editTaskForm");
    if (form.checkValidity()) {
      try {
        const taskId = parseInt(document.getElementById("editTaskId").value);
        const taskData = {
          taskDescription: document.getElementById("editTaskDescription").value,
          dueDate: document.getElementById("editTaskDueDate").value,
          status: document.getElementById("editTaskStatus").value
        };
        const response = await fetch(`${API_URL}/api/Task/${taskId}`, {
          method: "PUT",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(taskData)
        });
        if (!response.ok) throw new Error("Không thể cập nhật công việc");
        alert(`Đã cập nhật công việc: ${taskData.taskDescription}`);
        bootstrap.Modal.getInstance(document.getElementById("editTaskModal")).hide();
        await filterTasks();
      } catch (e) {
        console.error("Lỗi khi cập nhật công việc:", e);
        alert("Lỗi khi cập nhật công việc");
      }
    } else {
      form.reportValidity();
    }
  }

  // Xóa công việc
  // Xóa công việc
  async function deleteTask(taskId) {
    if (confirm("Bạn có chắc muốn xóa công việc này không?")) {
      try {
        const response = await fetch(`${API_URL}/api/Task/${taskId}`, {
          method: "DELETE",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (!response.ok) throw new Error("Không thể xóa công việc");
        alert("Đã xóa công việc!");
        await filterTasks();
      } catch (e) {
        console.error("Lỗi khi xóa công việc:", e);
        alert("Lỗi khi xóa công việc");
      }
    }
  }

  // Xuất danh sách công việc sang Excel
  // Xuất danh sách công việc sang Excel
  function exportTasks() {
    const worksheetData = [["Danh sách công việc theo học kỳ - Hệ thống Sinh viên HUTECH"], [`Giảng viên hướng dẫn: ${fullNameLecturer}`], [], ["#", "Học phần", "Mã đồ án", "Công việc", "Học kỳ", "Thời gian bắt đầu", "Thời gian hết hạn", "Trạng thái"]];
    tasks.forEach((task, index) => {
      const course = courses.find(c => c.courseId === task.courseId) || {
        name: task.courseId
      };
      worksheetData.push([index + 1, `${task.courseId} - ${course.name}`, task.projectId, task.taskDescription, task.semester, formatDate(task.startDate), formatDate(task.dueDate), task.status]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "CongViecHocKy");
    XLSX.writeFile(workbook, "cong_viec_hoc_ky.xlsx");
  }

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

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadCourses();
      await loadSemesters();
      await filterTasks();
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
      filterTasks();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      exportTasks();
    },
    event4: function (event) {
      filterTasks();
    },
    event5: function (event) {
      filterTasks();
    },
    event6: function (event) {
      filterTasks();
    },
    event7: function (event) {
      filterTasks();
    },
    event8: function (event) {
      updateProjectOptions();
    },
    event9: function (event) {
      addTask();
    },
    event10: function (event) {
      saveEditTask();
    }
  };
}

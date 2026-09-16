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
  let mockMeetings = [];
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let courses = [];
  let groups = [];

  // Navbar Functions
  // Navbar Functions
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

  // Load dữ liệu từ API
  // Load dữ liệu từ API
  async function loadData() {
    try {
      const responseCourses = await fetch("/api/Courses");
      courses = await responseCourses.json();
      updateCourseOptions("");
      const responseGroups = await fetch("/api/Groups");
      groups = await responseGroups.json();
      const responseMeetings = await fetch("/api/GoogleMeet");
      mockMeetings = await responseMeetings.json();
      renderMeetings(currentPage);
    } catch (error) {
      console.error("Lỗi khi tải dữ liệu:", error);
    }
  }

  // Cập nhật danh sách học phần
  // Cập nhật danh sách học phần
  function updateCourseOptions(searchText) {
    const courseSelect = document.getElementById("courseId");
    courseSelect.innerHTML = env.html("<option value=\"\">Chọn học phần</option>");
    courses.filter(course => course.name.toLowerCase().includes(searchText.toLowerCase())).forEach(course => {
      courseSelect.innerHTML += env.html(`<option value="${course.courseId}">${course.name}</option>`);
    });
    env.listen(courseSelect, "change", () => {
      const selectedCourseId = courseSelect.value;
      updateGroupOptions(selectedCourseId);
    });
  }

  // Cập nhật danh sách nhóm theo học phần
  // Cập nhật danh sách nhóm theo học phần
  function updateGroupOptions(courseId) {
    const groupSelect = document.getElementById("groupIds");
    groupSelect.innerHTML = env.html("<option value=\"\">Chọn nhóm</option>");
    if (courseId) {
      const semesterId = document.getElementById("semesterId").value;
      groups.filter(group => group.courseId === courseId && group.semester === semesterId).forEach(group => {
        groupSelect.innerHTML += env.html(`<option value="${group.projectId}">${group.groupName}</option>`);
      });
    }
  }

  // Tạo cuộc họp
  // Tạo cuộc họp
  env.listen(document.getElementById("createMeetingForm"), "submit", async function (e) {
    e.preventDefault();
    const date = document.getElementById("startTime").value;
    const startTime = document.getElementById("startTimeHour").value;
    const endTime = document.getElementById("endTimeHour").value;
    const startDateTime = new Date(`${date}T${startTime}:00Z`);
    const endDateTime = new Date(`${date}T${endTime}:00Z`);
    if (startDateTime >= endDateTime) {
      alert("Thời gian bắt đầu phải sớm hơn thời gian kết thúc!");
      return;
    }
    const dto = {
      title: document.getElementById("meetingTitle").value,
      semesterId: document.getElementById("semesterId").value,
      courseId: document.getElementById("courseId").value,
      lecturerId: document.getElementById("lecturerId").value,
      groupIds: Array.from(document.getElementById("groupIds").selectedOptions).map(option => parseInt(option.value)),
      startTime: startDateTime.toISOString(),
      endTime: endDateTime.toISOString(),
      location: document.getElementById("location").value,
      autoRecord: document.getElementById("autoRecord").checked
    };
    try {
      const response = await fetch("/api/GoogleMeet", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
      });
      if (!response.ok) throw new Error("Lỗi khi tạo cuộc họp");
      const newMeeting = await response.json();
      mockMeetings.push(newMeeting);
      currentPage = Math.ceil(mockMeetings.length / itemsPerPage);
      renderMeetings(currentPage);
      this.reset();
      updateCourseOptions("");
      alert("Tạo cuộc họp thành công!");
      document.getElementById("list-tab").click();
    } catch (error) {
      alert("Lỗi khi tạo cuộc họp: " + error.message);
    }
  });

  // Hiển thị danh sách cuộc họp
  // Hiển thị danh sách cuộc họp
  function renderMeetings(page) {
    const filteredMeetings = getFilteredMeetings();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedMeetings = filteredMeetings.slice(start, end);
    const tableBody = document.getElementById("meetingTableBody");
    tableBody.innerHTML = env.html("");
    if (paginatedMeetings.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"6\" class=\"text-center\">Không tìm thấy cuộc họp nào.</td></tr>");
    } else {
      paginatedMeetings.forEach((meeting, index) => {
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${meeting.title}</td>
                            <td>${formatDateTime(meeting.startTime)}</td>
                            <td>${formatDateTime(meeting.endTime)}</td>
                            <td><a href="${meeting.meetingLink}" target="_blank">Tham gia</a></td>
                            <td>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteMeeting(meeting.id);
        })}">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredMeetings.length);
  }

  // Lọc danh sách cuộc họp
  // Lọc danh sách cuộc họp
  function getFilteredMeetings() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    let filtered = mockMeetings.filter(meeting => meeting.title.toLowerCase().includes(searchText) || formatDateTime(meeting.startTime).toLowerCase().includes(searchText) || formatDateTime(meeting.endTime).toLowerCase().includes(searchText) || meeting.meetingLink.toLowerCase().includes(searchText));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "startTime" || sortColumn === "endTime" ? new Date(a[sortColumn]) : a[sortColumn].toLowerCase();
        let valueB = sortColumn === "startTime" || sortColumn === "endTime" ? new Date(b[sortColumn]) : b[sortColumn].toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
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
    renderMeetings(currentPage);
  }

  // Sắp xếp danh sách
  // Sắp xếp danh sách
  function sortMeetings(column) {
    if (sortColumn === column) {
      sortDirection = sortDirection === "asc" ? "desc" : "asc";
    } else {
      sortColumn = column;
      sortDirection = "asc";
    }
    renderMeetings(currentPage);
  }

  // Lọc danh sách
  // Lọc danh sách
  function filterMeetings() {
    currentPage = 1;
    renderMeetings(currentPage);
  }

  // Xóa cuộc họp
  // Xóa cuộc họp
  async function deleteMeeting(id) {
    if (confirm("Bạn có chắc muốn xóa cuộc họp này không?")) {
      try {
        await fetch(`/api/GoogleMeet/${id}`, {
          method: "DELETE"
        });
        mockMeetings = mockMeetings.filter(m => m.id !== id);
        alert("Đã xóa cuộc họp!");
        renderMeetings(currentPage);
      } catch (error) {
        alert("Lỗi khi xóa cuộc họp: " + error.message);
      }
    }
  }

  // Xuất danh sách cuộc họp sang Excel
  // Xuất danh sách cuộc họp sang Excel
  function exportMeetings() {
    const filteredMeetings = getFilteredMeetings();
    const worksheetData = [["Danh sách cuộc họp Google Meet - Hệ thống Sinh viên HUTECH"], [], ["#", "Tiêu đề", "Thời gian bắt đầu", "Thời gian kết thúc", "Link cuộc họp"]];
    filteredMeetings.forEach((meeting, index) => {
      worksheetData.push([index + 1, meeting.title, formatDateTime(meeting.startTime), formatDateTime(meeting.endTime), meeting.meetingLink]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "GoogleMeet");
    XLSX.writeFile(workbook, "google_meet_meetings.xlsx");
  }

  // Hàm định dạng ngày giờ
  // Hàm định dạng ngày giờ
  function formatDateTime(isoDate) {
    const date = new Date(isoDate);
    return date.toLocaleString("vi-VN");
  }

  // Khởi chạy
  // Khởi chạy
  env.listen(document, "DOMContentLoaded", () => {
    loadData();
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportMeetings();
    },
    event2: function (event) {
      document.getElementById("createMeetingForm").reset();
    },
    event3: function (event) {
      filterMeetings();
    },
    event4: function (event) {
      sortMeetings("title");
    },
    event5: function (event) {
      sortMeetings("startTime");
    },
    event6: function (event) {
      sortMeetings("endTime");
    }
  };
}

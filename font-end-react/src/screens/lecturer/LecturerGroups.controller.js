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
  const urlParams = new URLSearchParams(window.location.search);
  let selectedCourseId = urlParams.get("courseId");
  let groups = [];
  let students = [];

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

  // Gợi ý cấu trúc Excel trước khi nhập
  // Gợi ý cấu trúc Excel trước khi nhập
  function showImportInstructions() {
    const instructions = `
                Vui lòng chuẩn bị file Excel với cấu trúc sau:\n
                - Cột A: Tên nhóm (VD: Nhóm Alpha) - Bắt buộc\n
                - Cột B: Thành viên (VD: 21520001 - Nguyễn Tri Bão Thắng, 21520002 - Trần Văn A) - Bắt buộc\n
                - Cột C: Nhóm trưởng (VD: 21520001) - Không bắt buộc (nếu trống, chọn SV đầu tiên; chỉ 1 người)\n
                Dòng 1-3 có thể là tiêu đề, dữ liệu bắt đầu từ dòng 4.
            `;
    if (confirm(instructions + "\nNhấn OK để chọn file Excel.")) {
      document.getElementById("importExcel").click();
    }
  }

  // Lọc danh sách sinh viên chưa chia nhóm
  // Lọc danh sách sinh viên chưa chia nhóm
  async function filterStudents() {
    const searchText = document.querySelector(".search-box").value.toLowerCase();
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/ungrouped-students?courseId=${selectedCourseId}`, {
      method: "GET",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    students = await response.json();
    const studentList = document.getElementById("studentList");
    const ungroupedStudents = students.filter(s => !s.GroupId);
    studentList.innerHTML = env.html(ungroupedStudents.map(student => {
      if (student.name.toLowerCase().includes(searchText) || student.id.toLowerCase().includes(searchText)) {
        return `
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            ${student.username} - ${student.name} ${student.isLeader ? "(Nhóm trưởng)" : ""}
                            <select class="form-select w-50" data-page-change="${env.bind(function (event) {
          addToGroup(String(student.id), this.value);
        })}">
                                <option value="">Chọn nhóm</option>
                                ${groups.map(g => `<option value="${g.id}">${g.name} (${g.projectName})</option>`).join("")}
                            </select>
                        </li>
                    `;
      }
      return "";
    }).join(""));
    if (!studentList.innerHTML) {
      studentList.innerHTML = env.html("<li class=\"list-group-item text-center\">Không có sinh viên chưa chia nhóm</li>");
    }
  }

  // Hiển thị danh sách nhóm
  // Hiển thị danh sách nhóm
  async function displayGroups() {
    if (!selectedCourseId) {
      document.getElementById("studentList").innerHTML = env.html("<li class=\"list-group-item text-center\">Vui lòng chọn một học phần từ danh sách để chia nhóm.</li>");
      document.getElementById("groupList").innerHTML = env.html("<p class=\"text-center\">Vui lòng chọn một học phần từ danh sách để chia nhóm.</p>");
      return;
    }
    const groupSize = parseInt(document.getElementById("groupSize").value) || 3;
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/groups?courseId=${selectedCourseId}`, {
      method: "GET",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    groups = await response.json();
    const groupList = document.getElementById("groupList");
    groupList.innerHTML = env.html("");
    groups.forEach(group => {
      const memberList = group.members.map(member => `
                    <li class="list-group-item d-flex justify-content-between align-items-center">
                        ${member.username} - ${member.name} ${member.isLeader ? "(Nhóm trưởng)" : ""}
                        <div>
                            <button class="btn btn-sm btn-warning me-1" data-page-click="${env.bind(function (event) {
        toggleLeader(String(member.id), String(group.id));
      })}">${member.isLeader ? "Bỏ nhóm trưởng" : "Chọn nhóm trưởng"}</button>
                            <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
        removeFromGroup(String(member.id), String(group.id));
      })}">Xóa</button>
                        </div>
                    </li>
                `).join("");
      groupList.innerHTML += env.html(`
                    <div class="card mb-3">
                        <div class="card-header d-flex justify-content-between align-items-center">
                            <h6>${group.name} - ${group.projectName || "Chưa gán đồ án"}</h6>
                            <div>
                                <button class="btn btn-sm btn-primary me-1" data-page-click="${env.bind(function (event) {
        showEditGroupModal(String(group.id), String(group.name));
      })}">Chỉnh sửa</button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
        deleteGroup(String(group.id));
      })}">Xóa</button>
                            </div>
                        </div>
                        <div class="card-body">
                            <ul class="list-group">
                                ${memberList || "<li class=\"list-group-item text-center\">Chưa có thành viên</li>"}
                            </ul>
                            <p class="mt-2">Số lượng: ${group.members.length}/${groupSize}</p>
                        </div>
                    </div>
                `);
    });
    await filterStudents();
  }

  // Thêm nhóm mới
  // Thêm nhóm mới
  async function addNewGroup() {
    const form = document.getElementById("addGroupForm");
    if (form.checkValidity()) {
      const groupName = document.getElementById("newGroupName").value.trim();
      const response = await fetch(`${API_URL}/api/LecturerCourseGroup/add-group?groupName=${encodeURIComponent(groupName)}&courseId=${selectedCourseId}`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.ok) {
        bootstrap.Modal.getInstance(document.getElementById("addGroupModal")).hide();
        await displayGroups();
        alert(`Đã thêm nhóm: ${groupName}`);
      } else {
        const error = await response.json();
        alert(`Lỗi: ${error.message || "Tên nhóm đã tồn tại trong học phần này."}`);
      }
    } else {
      form.reportValidity();
    }
  }

  // Thêm sinh viên vào nhóm
  // Thêm sinh viên vào nhóm
  async function addToGroup(studentId, groupId) {
    const groupSize = parseInt(document.getElementById("groupSize").value) || 3;
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/add-to-group?studentId=${studentId}&groupId=${groupId}&groupSize=${groupSize}`, {
      method: "POST",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (response.ok) {
      await displayGroups();
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Nhóm đã đầy hoặc sinh viên đã thuộc nhóm khác."}`);
    }
  }

  // Xóa sinh viên khỏi nhóm
  // Xóa sinh viên khỏi nhóm
  async function removeFromGroup(studentId, groupId) {
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/remove-from-group?studentId=${studentId}&groupId=${groupId}`, {
      method: "POST",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (response.ok) {
      await displayGroups();
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Không thể xóa sinh viên khỏi nhóm."}`);
    }
  }

  // Chọn/bỏ nhóm trưởng
  // Chọn/bỏ nhóm trưởng
  async function toggleLeader(studentId, groupId) {
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/toggle-leader?studentId=${studentId}&groupId=${groupId}`, {
      method: "POST",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (response.ok) {
      await displayGroups();
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Không thể thay đổi nhóm trưởng."}`);
    }
  }

  // Chia nhóm tự động
  // Chia nhóm tự động
  async function autoGroup() {
    const groupSize = parseInt(document.getElementById("groupSize").value) || 3;
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/auto-group`, {
      method: "POST",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include",
      body: JSON.stringify({
        courseId: selectedCourseId,
        groupSize: groupSize
      })
    });
    if (response.ok) {
      await displayGroups();
      alert("Đã chia nhóm tự động!");
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Không thể chia nhóm tự động."}`);
    }
  }

  // Nhập từ file Excel
  // Nhập từ file Excel
  function importFromExcel(event) {
    const file = event.target.files[0];
    if (!file) return;
    const reader = new FileReader();
    reader.onload = async function (e) {
      const data = new Uint8Array(e.target.result);
      const workbook = XLSX.read(data, {
        type: "array"
      });
      const sheet = workbook.Sheets[workbook.SheetNames[0]];
      // Đọc dữ liệu với phân cách cột là |
      const rows = XLSX.utils.sheet_to_json(sheet, {
        header: 1
      });
      console.log("Raw Rows:", rows);
      if (!rows || rows.length <= 3 || !rows.slice(3).some(row => row.length > 0)) {
        alert("File Excel không chứa dữ liệu hợp lệ từ dòng 4 trở đi. Vui lòng kiểm tra lại file.");
        return;
      }
      for (const row of rows.slice(3)) {
        console.log("Row:", row);
        const [groupName, membersStr, leaderId] = row; // Phân tách cột theo |
        console.log("groupName:", groupName);
        console.log("membersStr:", membersStr);
        console.log("leaderId:", leaderId);
        if (groupName && membersStr) {
          const members = membersStr.split(", ").map(m => {
            const [username] = m.split(" - ");
            return username.trim();
          });
          console.log("Members:", members);
          let groupResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/add-group?groupName=${encodeURIComponent(groupName)}&courseId=${selectedCourseId}`, {
            method: "POST",
            headers: {
              "Accept": "*/*",
              "Content-Type": "application/json",
              "Authorization": `Bearer ${localStorage.getItem("token")}`
            },
            credentials: "include"
          });
          if (!groupResponse.ok) {
            const error = await groupResponse.json();
            alert(`Lỗi khi tạo nhóm ${groupName}: ${error.message || "Tên nhóm đã tồn tại."}`);
            continue;
          }
          const newGroup = await groupResponse.json();
          const groupId = newGroup.id;
          for (const username of members) {
            const userResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/getIdByUsername?username=${username}`, {
              method: "GET",
              headers: {
                "Accept": "*/*",
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("token")}`
              },
              credentials: "include"
            });
            alert(`Sinh viên ${username}.`);
            if (userResponse.ok) {
              const userData = await userResponse.json();
              const studentId = userData.id;
              const checkResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/check-student?studentId=${studentId}&courseId=${selectedCourseId}`, {
                method: "GET",
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                  "Authorization": `Bearer ${localStorage.getItem("token")}`
                },
                credentials: "include"
              });
              if (!checkResponse.ok) {
                const error = await checkResponse.json();
                alert(`Lỗi: Sinh viên ${username} không thuộc học phần ${selectedCourseId}.`);
                continue;
              }
              const addResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/add-to-group?studentId=${studentId}&groupId=${groupId}&groupSize=5`, {
                method: "POST",
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                  "Authorization": `Bearer ${localStorage.getItem("token")}`
                },
                credentials: "include"
              });
              if (!addResponse.ok) {
                const error = await addResponse.json();
                alert(`Lỗi khi thêm thành viên ${username} vào nhóm ${groupName}: ${error.message || "Nhóm đã đầy."}`);
              }
            } else {
              alert(`Lỗi khi lấy ID của sinh viên ${username}.`);
            }
          }
          if (leaderId) {
            const [leaderUsername] = leaderId.split(" - ");
            const userResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/getIdByUsername?username=${leaderUsername}`, {
              method: "GET",
              headers: {
                "Accept": "*/*",
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("token")}`
              },
              credentials: "include"
            });
            if (userResponse.ok) {
              const userData = await userResponse.json();
              const leaderStudentId = userData.id;
              const checkLeaderResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/check-student?studentId=${leaderStudentId}&courseId=${selectedCourseId}`, {
                method: "GET",
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                  "Authorization": `Bearer ${localStorage.getItem("token")}`
                },
                credentials: "include"
              });
              if (!checkLeaderResponse.ok) {
                const error = await checkLeaderResponse.json();
                alert(`Lỗi: Sinh viên ${leaderUsername} không thuộc học phần ${selectedCourseId}.`);
                continue;
              }
              const leaderResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/toggle-leader?studentId=${leaderStudentId}&groupId=${groupId}`, {
                method: "POST",
                headers: {
                  "Accept": "*/*",
                  "Content-Type": "application/json",
                  "Authorization": `Bearer ${localStorage.getItem("token")}`
                },
                credentials: "include"
              });
              if (!leaderResponse.ok) {
                const error = await leaderResponse.json();
                alert(`Lỗi khi đặt nhóm trưởng ${leaderUsername} cho nhóm ${groupName}: ${error.message || "Không thể đặt nhóm trưởng."}`);
              }
            } else {
              alert(`Lỗi khi lấy ID của sinh viên ${leaderUsername}.`);
            }
          }
        } else {
          alert("Dữ liệu Excel không hợp lệ: Tên nhóm hoặc thành viên bị thiếu.");
        }
      }
      await displayGroups();
      alert("Đã nhập danh sách nhóm từ Excel!");
    };
    reader.readAsArrayBuffer(file);
  }

  // Xuất danh sách nhóm sang Excel
  // Xuất danh sách nhóm sang Excel
  async function exportGroups() {
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/export-excel?courseId=${selectedCourseId}`, {
      method: "GET",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (response.ok) {
      const blob = await response.blob();
      const courseResponse = await fetch(`${API_URL}/api/LecturerCourseGroup/courses`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      const courseData = await courseResponse.json();
      const course = courseData.courses.find(c => c.courseId === selectedCourseId);
      const fileName = `${course.Name}_${selectedCourseId}.xlsx`;
      const url = window.env.objectUrl(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = fileName;
      a.click();
      window.URL.revokeObjectURL(url);
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Không thể xuất Excel."}`);
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
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hướng dẫn hoặc chưa đăng nhập.");
      logout();
    }
  }

  // Hiển thị modal chỉnh sửa tên nhóm
  // Hiển thị modal chỉnh sửa tên nhóm
  function showEditGroupModal(groupId, groupName) {
    document.getElementById("editGroupId").value = groupId;
    document.getElementById("editGroupName").value = groupName;
    new bootstrap.Modal(document.getElementById("editGroupModal")).show();
  }

  // Cập nhật tên nhóm
  // Cập nhật tên nhóm
  async function updateGroupName() {
    const groupId = document.getElementById("editGroupId").value;
    const newGroupName = document.getElementById("editGroupName").value.trim();
    const response = await fetch(`${API_URL}/api/LecturerCourseGroup/update-group-name?groupId=${groupId}&newGroupName=${newGroupName}`, {
      method: "POST",
      headers: {
        "Accept": "*/*",
        "Content-Type": "application/json",
        "Authorization": `Bearer ${localStorage.getItem("token")}`
      },
      credentials: "include"
    });
    if (response.ok) {
      bootstrap.Modal.getInstance(document.getElementById("editGroupModal")).hide();
      await displayGroups();
      alert(`Đã cập nhật tên nhóm thành: ${newGroupName}`);
    } else {
      const error = await response.json();
      alert(`Lỗi: ${error.message || "Tên nhóm đã tồn tại trong học phần này."}`);
    }
  }

  // Xóa nhóm
  // Xóa nhóm
  async function deleteGroup(groupId) {
    if (confirm("Bạn có chắc chắn muốn xóa nhóm này? Các thành viên sẽ được chuyển về chưa có nhóm.")) {
      const response = await fetch(`${API_URL}/api/LecturerCourseGroup/delete-group?groupId=${groupId}`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (response.ok) {
        await displayGroups();
        alert("Đã xóa nhóm thành công!");
      } else {
        const error = await response.json();
        alert(`Lỗi: ${error.message || "Không thể xóa nhóm."}`);
      }
    }
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
      if (!selectedCourseId) {
        alert("Vui lòng chọn một học phần từ danh sách để chia nhóm!");
        env.navigate("lecturer_course_groups.html");
        return;
      }
      await loadUserProfile();
      await displayGroups();
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
      filterStudents();
    },
    event2: function (event) {
      logout();
    },
    event3: function (event) {
      autoGroup();
    },
    event4: function (event) {
      importFromExcel(event);
    },
    event5: function (event) {
      showImportInstructions();
    },
    event6: function (event) {
      exportGroups();
    },
    event7: function (event) {
      displayGroups();
    },
    event8: function (event) {
      addNewGroup();
    },
    event9: function (event) {
      updateGroupName();
    }
  };
}

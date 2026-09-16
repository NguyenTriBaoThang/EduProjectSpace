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
  const tasks = {
    "1": {
      subjectId: 1,
      name: "Bài tập Tuần 1",
      instructor: "Nguyen Huy Cuong",
      created: "12/02/2025",
      updated: "13/02/2025",
      deadline: "20/02/2025",
      points: 100,
      status: "Chưa nộp",
      files: [],
      classComments: [],
      privateComments: []
    },
    "2": {
      subjectId: 1,
      name: "Bài tập Tuần 2",
      instructor: "Nguyen Huy Cuong",
      created: "08/02/2025",
      updated: "09/02/2025",
      deadline: "14/02/2025",
      points: 100,
      status: "Đã nộp",
      files: [{
        name: "week2.pdf"
      }],
      classComments: [],
      privateComments: []
    }
  };
  let currentTask = null;
  let submittedFiles = [];

  // Lấy thông tin từ URL
  // Lấy thông tin từ URL
  const params = new URLSearchParams(window.location.search);
  const taskId = params.get("taskId") || "1";
  currentTask = tasks[taskId];
  if (currentTask) {
    document.getElementById("taskTitle").textContent = `📌 ${currentTask.name}`;
    document.getElementById("taskName").innerHTML = env.html(`<i class="bi bi-journal-check"></i> ${currentTask.name}`);
    document.getElementById("taskInfo").textContent = `CNTT ${currentTask.instructor} • ${currentTask.created} (Đã chỉnh sửa ${currentTask.updated})`;
    document.getElementById("taskDeadline").textContent = `Hạn nộp: ${currentTask.deadline}`;
    document.getElementById("taskPoints").textContent = `${currentTask.points} điểm`;
    document.getElementById("submissionStatus").textContent = currentTask.status;
    document.getElementById("submissionStatus").className = currentTask.status === "Đã nộp" ? "text-success" : "text-warning";
    document.getElementById("backLink").href = `student_submissions_week.html?id=${currentTask.subjectId}`;
    document.getElementById("subjectBreadcrumb").innerHTML = env.html(`<a href="student_submissions_week.html?id=${currentTask.subjectId}"><i class="bi bi-file-earmark-text"></i> Danh sách bài tập</a>`);
    document.getElementById("taskBreadcrumb").textContent = currentTask.name;
    if (currentTask.status === "Đã nộp") {
      document.getElementById("submitButton").textContent = "Hủy nộp bài";
      document.getElementById("submitButton").onclick = cancelSubmission;
      currentTask.files.forEach(file => addFileToList(file.name));
    }
  } else {
    document.getElementById("taskTitle").textContent = "📌 Không tìm thấy bài tập";
    document.querySelector(".card-custom").innerHTML = env.html("<p>Không tìm thấy bài tập với ID này.</p>");
  }

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

  // Nộp bài tập
  // Nộp bài tập
  function submitAssignment(files) {
    var fileList = document.getElementById("fileList");
    submittedFiles = [];
    for (let i = 0; i < files.length; i++) {
      const fileName = files[i].name;
      submittedFiles.push({
        name: fileName
      });
      addFileToList(fileName);
    }
  }
  function addFileToList(fileName) {
    var fileList = document.getElementById("fileList");
    var newFile = document.createElement("div");
    newFile.classList.add("submission-box");
    newFile.innerHTML = env.html(`
                <img src="https://upload.wikimedia.org/wikipedia/commons/d/da/Google_Drive_logo.png" alt="Google Drive">
                <div class="submission-text">
                    <strong title="${fileName}">${fileName}</strong>
                    <p class="text-muted">Tệp lưu trữ nén</p>
                </div>
                ${currentTask.status === "Chưa nộp" ? `<button class="remove-file" data-page-click="${env.bind(function (event) {
      removeFile(this);
    })}">×</button>` : ""}
            `);
    fileList.appendChild(newFile);
  }
  function finalizeSubmission() {
    if (submittedFiles.length === 0) {
      alert("Vui lòng chọn ít nhất một file để nộp!");
      return;
    }
    currentTask.status = "Đã nộp";
    currentTask.files = submittedFiles;
    document.getElementById("submissionStatus").textContent = "Đã nộp";
    document.getElementById("submissionStatus").className = "text-success";
    document.getElementById("submitButton").textContent = "Hủy nộp bài";
    document.getElementById("submitButton").onclick = cancelSubmission;
    document.querySelectorAll(".remove-file").forEach(button => button.style.display = "none");
    alert("Bài tập đã được nộp thành công!");
  }
  function cancelSubmission() {
    if (confirm("Bạn có chắc muốn hủy nộp bài không?")) {
      currentTask.status = "Chưa nộp";
      currentTask.files = [];
      submittedFiles = [];
      document.getElementById("fileList").innerHTML = env.html("");
      document.getElementById("submissionStatus").textContent = "Chưa nộp";
      document.getElementById("submissionStatus").className = "text-warning";
      document.getElementById("submitButton").textContent = "Nộp bài";
      document.getElementById("submitButton").onclick = finalizeSubmission;
    }
  }
  function removeFile(button) {
    const fileName = button.parentElement.querySelector("strong").textContent;
    submittedFiles = submittedFiles.filter(f => f.name !== fileName);
    button.parentElement.remove();
  }
  env.listen(document, "DOMContentLoaded", () => {
    let dropArea = document.getElementById("submissionSection");
    let fileInput = document.getElementById("fileInput");
    env.listen(dropArea, "dragover", event => {
      event.preventDefault();
    });
    env.listen(dropArea, "drop", event => {
      event.preventDefault();
      if (currentTask.status === "Chưa nộp") submitAssignment(event.dataTransfer.files);
    });
    env.listen(fileInput, "change", () => {
      if (currentTask.status === "Chưa nộp") submitAssignment(fileInput.files);
    });
  });

  // Nhận xét
  // Nhận xét
  function toggleCommentBox(id, textId) {
    var inputBox = document.getElementById(id);
    var textBox = document.getElementById(textId);
    if (inputBox.style.display === "none" || inputBox.style.display === "") {
      inputBox.style.display = "block";
      textBox.style.display = "none";
      inputBox.querySelector("input").focus();
    }
  }
  function submitComment(inputId, listId) {
    var inputBox = document.getElementById(inputId).querySelector("input");
    var commentText = inputBox.value.trim();
    if (commentText !== "") {
      var commentList = document.getElementById(listId);
      var newComment = document.createElement("div");
      newComment.classList.add("comment-item");
      newComment.innerHTML = env.html(`
                    <img src="img/avatar.jpg" alt="Avatar">
                    <div class="comment-content">
                        <strong>Người dùng</strong>
                        <div class="comment-time">Vừa xong</div>
                        <p>${commentText}</p>
                    </div>
                `);
      commentList.appendChild(newComment);
      if (listId === "classCommentList") currentTask.classComments.push(commentText);else currentTask.privateComments.push(commentText);
      inputBox.value = "";
      toggleCommentBox(inputId, inputId.replace("Comment", "CommentText"));
    }
  }

  // Xuất dữ liệu sang Excel
  // Xuất dữ liệu sang Excel
  function exportSubmission() {
    const worksheetData = [[`${currentTask.name}`], ["Giảng viên", currentTask.instructor], ["Ngày tạo", currentTask.created], ["Ngày chỉnh sửa", currentTask.updated], ["Hạn nộp", currentTask.deadline], ["Điểm tối đa", currentTask.points], ["Trạng thái", currentTask.status], ["File đã nộp", currentTask.files.map(f => f.name).join(", ") || "Chưa có file"], [], ["Nhận xét lớp học"], ...currentTask.classComments.map((comment, index) => [index + 1, comment]), [], ["Nhận xét riêng tư"], ...currentTask.privateComments.map((comment, index) => [index + 1, comment])];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "BaiTapTuan1");
    XLSX.writeFile(workbook, `bai_tap_${taskId}.xlsx`);
  }
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      exportSubmission();
    },
    event2: function (event) {
      toggleCommentBox("classComment", "classCommentText");
    },
    event3: function (event) {
      submitComment("classComment", "classCommentList");
    },
    event4: function (event) {
      document.getElementById("fileInput").click();
    },
    event5: function (event) {
      finalizeSubmission();
    },
    event6: function (event) {
      toggleCommentBox("privateComment", "privateCommentText");
    },
    event7: function (event) {
      submitComment("privateComment", "privateCommentList");
    }
  };
}

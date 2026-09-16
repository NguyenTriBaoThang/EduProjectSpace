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
  // Dữ liệu mẫu bài nộp
  const submissions = {
    "1": {
      name: "Bài tập 1: Lập trình Web",
      projectType: "Đồ án cơ sở",
      date: "10-02-2025",
      status: "Đã chấm",
      score: 9.0,
      content: "Xây dựng giao diện người dùng bằng HTML, CSS và JavaScript.",
      files: [{
        name: "web_project.pdf",
        url: "files/web_project.pdf"
      }, {
        name: "design_mockup.png",
        url: "files/design_mockup.png"
      }, {
        name: "documentation.docx",
        url: "files/documentation.docx"
      }],
      teacher: "Nguyễn Huy Cường",
      feedback: "Bài làm tốt, giao diện thiết kế đẹp, đầy đủ chức năng. Cần tối ưu mã nguồn để hiệu suất cao hơn."
    },
    "2": {
      name: "Bài tập 2: Ứng dụng di động",
      projectType: "Đồ án chuyên ngành",
      date: "15-02-2025",
      status: "Đã nộp",
      score: "Chưa chấm",
      content: "Phát triển ứng dụng di động với Flutter.",
      files: [{
        name: "mobile_app.zip",
        url: "files/mobile_app.zip"
      }],
      teacher: "Trần Văn B",
      feedback: "Chưa có nhận xét."
    }
  };

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

  // Lấy thông tin bài nộp từ URL
  // Lấy thông tin bài nộp từ URL
  const params = new URLSearchParams(window.location.search);
  const taskId = params.get("taskId");
  function loadSubmission() {
    const submission = submissions[taskId];
    if (submission) {
      document.getElementById("submissionTitle").textContent = `📑 Chi tiết bài nộp - ${submission.name}`;
      document.getElementById("taskName").textContent = submission.name;
      document.getElementById("projectType").textContent = submission.projectType;
      document.getElementById("submissionDate").textContent = submission.date;
      document.getElementById("submissionStatus").innerHTML = env.html(`<span class="status ${submission.status === "Đã chấm" ? "status-graded" : "status-submitted"}">${submission.status}</span>`);
      document.getElementById("submissionScore").innerHTML = env.html(submission.score === "Chưa chấm" ? submission.score : `<span class="badge bg-success">${submission.score}</span>`);
      document.getElementById("submissionContent").textContent = submission.content;
      const fileList = document.getElementById("fileList");
      fileList.innerHTML = env.html("");
      submission.files.forEach(file => {
        fileList.innerHTML += env.html(`<li><a href="${file.url}" download class="btn btn-sm btn-outline-primary">📥 ${file.name}</a></li>`);
      });
      document.getElementById("teacherFeedback").innerHTML = env.html(`
                    <p><strong>👨‍🏫 Giáo viên:</strong> ${submission.teacher}</p>
                    <p>${submission.feedback}</p>
                `);
    } else {
      document.getElementById("submissionTitle").textContent = "📑 Không tìm thấy bài nộp";
      document.getElementById("submissionDetails").innerHTML = env.html("<p>Không có thông tin bài nộp với ID này.</p>");
    }
  }

  // Tải tất cả file đính kèm
  // Tải tất cả file đính kèm
  function downloadAllFiles() {
    const submission = submissions[taskId];
    if (submission && submission.files.length > 0) {
      submission.files.forEach(file => {
        const link = document.createElement("a");
        link.href = file.url;
        link.download = file.name;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
      });
    } else {
      alert("Không có file nào để tải!");
    }
  }

  // Xuất báo cáo Excel
  // Xuất báo cáo Excel
  function exportReport() {
    const submission = submissions[taskId];
    if (!submission) return;
    const worksheetData = [[`Chi tiết bài nộp - ${submission.name}`], ["học phần", submission.projectType], ["Ngày nộp", submission.date], ["Trạng thái", submission.status], ["Điểm", submission.score], [], ["Nội dung bài nộp", submission.content], ["File đính kèm", submission.files.map(f => f.name).join(", ")], ["Giáo viên", submission.teacher], ["Nhận xét", submission.feedback]];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietBaiNop");
    XLSX.writeFile(workbook, `bai_nop_${taskId}.xlsx`);
  }

  // Khởi chạy
  // Khởi chạy
  loadSubmission();
  return {
    event0: function (event) {
      downloadAllFiles();
    },
    event1: function (event) {
      exportReport();
    }
  };
}

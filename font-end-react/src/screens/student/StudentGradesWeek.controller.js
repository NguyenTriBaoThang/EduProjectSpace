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
  // Dữ liệu mẫu bài tập
  const assignments = {
    "1": {
      title: "Bài tập tuần 1",
      score: 8.5,
      evaluation: "Tốt",
      status: "Đã nộp",
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
      title: "Bài tập tuần 2",
      score: 9.0,
      evaluation: "Xuất sắc",
      status: "Đã nộp",
      content: "Phát triển chức năng đăng nhập và đăng ký.",
      files: [{
        name: "login_system.zip",
        url: "files/login_system.zip"
      }],
      teacher: "Trần Văn B",
      feedback: "Hoàn thành xuất sắc, mã nguồn sạch và tối ưu."
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

  // Lấy thông tin bài tập từ URL
  // Lấy thông tin bài tập từ URL
  const params = new URLSearchParams(window.location.search);
  const id = params.get("id");
  function loadAssignment() {
    const assignment = assignments[id];
    if (assignment) {
      document.getElementById("assignmentTitle").textContent = `📖 Chi tiết điểm bài tập - ${assignment.title}`;
      document.getElementById("assignmentScore").textContent = assignment.score;
      document.getElementById("assignmentEvaluation").textContent = assignment.evaluation;
      document.getElementById("assignmentStatus").textContent = assignment.status;
      document.getElementById("submissionContent").textContent = assignment.content;
      const fileList = document.getElementById("fileList");
      fileList.innerHTML = env.html("");
      assignment.files.forEach(file => {
        fileList.innerHTML += env.html(`<li><a href="${file.url}" download class="btn btn-sm btn-outline-primary">📥 ${file.name}</a></li>`);
      });
      document.getElementById("teacherFeedback").innerHTML = env.html(`
                    <p><strong>👨‍🏫 Giáo viên:</strong> ${assignment.teacher}</p>
                    <p>${assignment.feedback}</p>
                `);
    } else {
      document.getElementById("assignmentTitle").textContent = "📖 Không tìm thấy bài tập";
      document.getElementById("submissionDetails").innerHTML = env.html("<p>Không có thông tin bài tập với ID này.</p>");
    }
  }

  // Tải tất cả file đính kèm
  // Tải tất cả file đính kèm
  function downloadAllFiles() {
    const assignment = assignments[id];
    if (assignment && assignment.files.length > 0) {
      assignment.files.forEach(file => {
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
    const assignment = assignments[id];
    if (!assignment) return;
    const worksheetData = [[`Chi tiết điểm bài tập - ${assignment.title}`], ["Điểm số", assignment.score], ["Đánh giá", assignment.evaluation], ["Trạng thái", assignment.status], [], ["Nội dung bài nộp", assignment.content], ["File đính kèm", assignment.files.map(f => f.name).join(", ")], ["Giáo viên", assignment.teacher], ["Nhận xét", assignment.feedback]];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietDiem");
    XLSX.writeFile(workbook, `diem_bai_tap_${id}.xlsx`);
  }

  // Khởi chạy
  // Khởi chạy
  loadAssignment();
  return {
    event0: function (event) {
      downloadAllFiles();
    },
    event1: function (event) {
      exportReport();
    }
  };
}

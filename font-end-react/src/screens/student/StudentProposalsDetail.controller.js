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
  // Dữ liệu mẫu đề tài
  const proposals = {
    "1": {
      title: "Đồ án cơ sở: Xây dựng hệ thống quản lý sinh viên",
      status: "Đã duyệt",
      type: "Chuyên ngành",
      date: "10-02-2025",
      proposer: "Nguyễn Tri Bão Thắng",
      description: "Đây là đề tài đồ án cơ sở với các mục tiêu nghiên cứu về ứng dụng công nghệ trong phát triển phần mềm, bao gồm việc sử dụng các công cụ hiện đại như Java, Spring Boot, và cơ sở dữ liệu MySQL.",
      feedback: "Đề tài này đã được duyệt. Bạn cần chú trọng vào phần phân tích hệ thống và tối ưu hóa các quy trình. Nên tập trung vào việc ứng dụng các công nghệ mới và có thể mở rộng hệ thống sau khi hoàn thành.",
      files: [{
        name: "proposal_document.pdf",
        url: "#"
      }, {
        name: "system_design.png",
        url: "#"
      }]
    },
    "2": {
      title: "Đồ án chuyên ngành: Ứng dụng di động đặt vé xe",
      status: "Chưa duyệt",
      type: "Chuyên ngành",
      date: "15-02-2025",
      proposer: "Nguyễn Tri Bão Thắng",
      description: "Phát triển ứng dụng di động đặt vé xe sử dụng Flutter và Firebase để quản lý dữ liệu thời gian thực.",
      feedback: "Đề tài cần bổ sung thêm phần phân tích yêu cầu và kế hoạch triển khai chi tiết hơn.",
      files: [{
        name: "mobile_app_proposal.docx",
        url: "#"
      }]
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

  // Lấy thông tin đề tài từ URL
  // Lấy thông tin đề tài từ URL
  const params = new URLSearchParams(window.location.search);
  const proposalId = params.get("id");
  function loadProposal() {
    const proposal = proposals[proposalId];
    if (proposal) {
      document.getElementById("proposalTitle").textContent = `Đề tài: ${proposal.title}`;
      document.getElementById("proposalStatus").textContent = proposal.status;
      document.getElementById("proposalStatus").className = `badge ${proposal.status === "Đã duyệt" ? "bg-success" : "bg-warning"}`;
      document.getElementById("proposalType").textContent = proposal.type;
      document.getElementById("proposalDate").textContent = proposal.date;
      document.getElementById("proposer").textContent = proposal.proposer;
      document.getElementById("proposalDescription").textContent = proposal.description;
      document.getElementById("feedbackText").textContent = proposal.feedback;
      const fileList = document.getElementById("fileList");
      fileList.innerHTML = env.html("");
      proposal.files.forEach(file => {
        fileList.innerHTML += env.html(`<li><a href="${file.url}" download class="btn btn-outline-primary btn-sm">📥 ${file.name}</a></li>`);
      });
    } else {
      document.getElementById("proposalDetails").innerHTML = env.html("<p class='p-4'>Không tìm thấy đề tài với ID này.</p>");
    }
  }

  // Tải tất cả file đính kèm
  // Tải tất cả file đính kèm
  function downloadAllFiles() {
    const proposal = proposals[proposalId];
    if (proposal && proposal.files.length > 0) {
      proposal.files.forEach(file => {
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
  function exportProposal() {
    const proposal = proposals[proposalId];
    if (!proposal) return;
    const worksheetData = [[`Chi tiết đề tài đồ án - ${proposal.title}`], ["Trạng thái", proposal.status], ["Loại đồ án", proposal.type], ["Ngày đề xuất", proposal.date], ["Người đề xuất", proposal.proposer], ["Mô tả", proposal.description], ["Gợi ý từ giảng viên", proposal.feedback], ["File đính kèm", proposal.files.map(f => f.name).join(", ")]];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "ChiTietDeTai");
    XLSX.writeFile(workbook, `de_tai_${proposalId}.xlsx`);
  }

  // Khởi chạy
  // Khởi chạy
  loadProposal();
  return {
    event0: function (event) {
      exportProposal();
    },
    event1: function (event) {
      downloadAllFiles();
    }
  };
}

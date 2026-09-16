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

  // Hiển thị tên file đã chọn
  // Hiển thị tên file đã chọn
  function displayFileName() {
    const fileInput = document.getElementById("attachment");
    const fileName = document.getElementById("fileName");
    if (fileInput.files.length > 0) {
      fileName.textContent = `File đã chọn: ${fileInput.files[0].name}`;
    } else {
      fileName.textContent = "";
    }
  }

  // Hiển thị modal xác nhận
  // Hiển thị modal xác nhận
  function showConfirmation() {
    const form = document.getElementById("proposalForm");
    if (form.checkValidity()) {
      const confirmationModal = new bootstrap.Modal(document.getElementById("confirmationModal"));
      confirmationModal.show();
    } else {
      form.reportValidity();
    }
  }

  // Gửi form và xuất Excel
  // Gửi form và xuất Excel
  function submitForm() {
    const form = document.getElementById("proposalForm");
    const formData = new FormData(form);
    const proposalData = {
      subject: formData.get("subject"),
      title: formData.get("title"),
      description: formData.get("description"),
      technology: formData.get("technology"),
      attachment: formData.get("attachment") ? formData.get("attachment").name : "Không có file"
    };

    // Xuất Excel
    const worksheetData = [["Đề xuất đề tài đồ án"], ["học phần", proposalData.subject], ["Tên đề tài", proposalData.title], ["Mô tả ngắn", proposalData.description], ["Công nghệ sử dụng", proposalData.technology], ["File đính kèm", proposalData.attachment]];
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "DeXuatDeTai");
    XLSX.writeFile(workbook, `de_xuat_${proposalData.title.replace(/\s+/g, "_")}.xlsx`);

    // Hiển thị modal thành công
    const confirmationModal = bootstrap.Modal.getInstance(document.getElementById("confirmationModal"));
    confirmationModal.hide();
    const successModal = new bootstrap.Modal(document.getElementById("successModal"));
    successModal.show();
  }

  // Chuyển hướng sau khi gửi thành công
  // Chuyển hướng sau khi gửi thành công
  function redirectToList() {
    env.navigate("student_proposals_list.html");
  }

  // Xử lý submit form
  // Xử lý submit form
  function submitProposal(event) {
    event.preventDefault();
    showConfirmation();
  }
  return {
    event0: function (event) {
      submitProposal(event);
    },
    event1: function (event) {
      displayFileName();
    },
    event2: function (event) {
      showConfirmation();
    },
    event3: function (event) {
      submitForm();
    },
    event4: function (event) {
      redirectToList();
    }
  };
}

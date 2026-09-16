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
  let fullNameLecturer = null;
  const itemsPerPage = 5;
  let currentPage = 1;
  let sortColumn = null;
  let sortDirection = "asc";
  let resources = [];
  let projects = [];
  let groups = [];
  let aiSuggestions = [];
  const urlParams = new URLSearchParams(window.location.search);
  const selectedCourseId = urlParams.get("courseId");
  const selectedSemester = urlParams.get("semester");
  const selectedFacultyCode = urlParams.get("facultyCode");

  // Navbar Functions
  // Navbar Functions
  env.listen(document.getElementById("toggleSidebarBtn"), "click", () => toggleSidebar());
  env.listen(document.getElementById("notificationBtn"), "click", () => env.navigate("/font-end/lecturer/lecturer_notifications.html"));
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
  function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const content = document.getElementById("content"); // Note: ID added to content div
    const icon = document.getElementById("sidebarIcon");
    sidebar.classList.toggle("collapsed");
    content.classList.toggle("expanded");
    if (sidebar.classList.contains("collapsed")) {
      icon.classList.replace("bi-list", "bi-layout-sidebar-inset");
    } else {
      icon.classList.replace("bi-layout-sidebar-inset", "bi-list");
    }
  }
  async function loadUserProfile() {
    try {
      const user = JSON.parse(localStorage.getItem("user"));
      if (!user || user.roleName !== "ROLE_LECTURER_GUIDE") {
        throw new Error("Không có quyền Giảng viên hoặc chưa đăng nhập.");
      }
      fullNameLecturer = user.fullName;
      document.getElementById("userName").textContent = user.fullName || "Nguyễn Huy Cường";
      document.getElementById("userEmail").textContent = user.email || "nguyenhuycuong@hutech.edu.vn";
    } catch (error) {
      console.error("Lỗi khi tải thông tin người dùng:", error);
      alert("Không có quyền Giảng viên hoặc chưa đăng nhập.");
      logout();
    }
  }
  async function loadResources() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerResources/resources?courseId=${selectedCourseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể tải danh sách tài liệu");
      resources = await response.json();
      await loadProjectsAndGroups();
      displayTable();
    } catch (e) {
      console.error("Lỗi khi tải danh sách tài liệu:", e);
      document.getElementById("tableBody").innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy tài liệu nào.</td></tr>");
    }
  }
  async function loadProjectsAndGroups() {
    try {
      const response = await fetch(`${API_URL}/api/LecturerFeedback/projects?courseId=${selectedCourseId}`, {
        method: "GET",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include"
      });
      if (!response.ok) throw new Error("Không thể tải danh sách đồ án");
      projects = await response.json();
      groups = projects.map(p => ({
        id: p.groupId || Math.floor(Math.random() * 1000),
        name: p.groupName || `Group-${p.projectId}`,
        projectId: p.projectId
      }));
      populateFiltersAndForms();
    } catch (e) {
      console.error("Lỗi khi tải danh sách đồ án:", e);
    }
  }
  function getFilteredResources() {
    const searchText = document.getElementById("searchInput").value.toLowerCase();
    const projectFilter = document.getElementById("projectFilter").value;
    let filtered = resources.filter(resource => (resource.projectId?.toLowerCase().includes(searchText) || resource.groupName?.toLowerCase().includes(searchText) || resource.title?.toLowerCase()?.includes(searchText) || resource.type?.toLowerCase()?.includes(searchText) || resource.link?.toLowerCase()?.includes(searchText)) && (projectFilter === "" || resource.projectId === projectFilter));
    if (sortColumn) {
      filtered.sort((a, b) => {
        let valueA = sortColumn === "groupName" ? (a.groupName || "").toLowerCase() : (a[sortColumn] || "").toLowerCase();
        let valueB = sortColumn === "groupName" ? (b.groupName || "").toLowerCase() : (b[sortColumn] || "").toLowerCase();
        return sortDirection === "asc" ? valueA > valueB ? 1 : -1 : valueA < valueB ? 1 : -1;
      });
    }
    return filtered;
  }
  function displayTable(page = currentPage) {
    const filteredResources = getFilteredResources();
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedData = filteredResources.slice(start, end);
    const tableBody = document.getElementById("tableBody");
    tableBody.innerHTML = env.html("");
    if (!selectedCourseId) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Vui lòng chọn một học phần từ danh sách để xem tài liệu.</td></tr>");
    } else if (paginatedData.length === 0) {
      tableBody.innerHTML = env.html("<tr><td colspan=\"7\" class=\"text-center\">Không tìm thấy tài liệu nào.</td></tr>");
    } else {
      paginatedData.forEach((resource, index) => {
        const fileUrl = resource.link ? `/api/File/files/${resource.link}` : "#";
        let displayLink = resource.link || "N/A";
        if (resource.type === "PDF" || resource.type === "Video") {
          displayLink = `<a href="${fileUrl}" target="_blank">${displayLink}</a>`;
        } else {
          displayLink = `<a href="${resource.link}" target="_blank">${displayLink}</a>`; // Website
        }
        tableBody.innerHTML += env.html(`
                        <tr>
                            <td>${start + index + 1}</td>
                            <td>${resource.projectName || "N/A"}</td>
                            <td>${resource.groupName || "N/A"}</td>
                            <td>${resource.title || "N/A"}</td>
                            <td>${resource.type || "N/A"}</td>
                            <td>${displayLink}</td>
                            <td>
                                <button class="btn btn-sm btn-info me-1" data-page-click="${env.bind(function (event) {
          editResource(resource.id);
        })}">
                                    <i class="bi bi-pencil"></i>
                                </button>
                                <button class="btn btn-sm btn-danger" data-page-click="${env.bind(function (event) {
          deleteResource(resource.id);
        })}">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `);
      });
    }
    setupPagination(filteredResources.length);
  }
  function setupPagination(totalItems) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = env.html("");
    if (totalPages <= 1) return;
    let paginationHTML = `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">«</a></li>`;
    if (currentPage > 2) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(1);
    })}">1</a></li>`;
    if (currentPage > 3) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage > 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage - 1);
    })}">${currentPage - 1}</a></li>`;
    paginationHTML += `<li class="page-item active"><a class="page-link">${currentPage}</a></li>`;
    if (currentPage < totalPages) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(currentPage + 1);
    })}">${currentPage + 1}</a></li>`;
    if (currentPage < totalPages - 2) paginationHTML += `<li class="page-item disabled"><span class="page-link">...</span></li>`;
    if (currentPage < totalPages - 1) paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">${totalPages}</a></li>`;
    paginationHTML += `<li class="page-item"><a class="page-link" href="#" data-page-click="${env.bind(function (event) {
      changePage(totalPages);
    })}">»</a></li>`;
    pagination.innerHTML = env.html(paginationHTML);
  }
  function changePage(page) {
    currentPage = page;
    displayTable(currentPage);
  }
  function sortTable(column) {
    sortDirection = sortColumn === column ? sortDirection === "asc" ? "desc" : "asc" : "asc";
    sortColumn = column;
    displayTable(currentPage);
  }
  function filterTable() {
    currentPage = 1;
    displayTable(currentPage);
  }
  function populateFiltersAndForms() {
    const projectFilter = document.getElementById("projectFilter");
    const aiProjectFilter = document.getElementById("aiProjectId");
    projectFilter.innerHTML = env.html("<option value=\"\">📂 Chọn đồ án</option>");
    aiProjectFilter.innerHTML = env.html("<option value=\"\">Chọn đồ án</option>");
    projects.forEach(project => {
      projectFilter.innerHTML += env.html(`<option value="${project.projectId}">${project.projectId} - ${project.name || "N/A"}</option>`);
      aiProjectFilter.innerHTML += env.html(`<option value="${project.projectId}">${project.projectId} - ${project.name || "N/A"}</option>`);
    });

    // Update all resource group selects with IDs
    let entryCount = 1;
    while (document.getElementById(`resourceGroup${entryCount}`)) {
      const select = document.getElementById(`resourceGroup${entryCount}`);
      select.innerHTML = env.html("<option value=\"\">Chọn nhóm</option>");
      for (const project of projects) {
        const group = groups.find(g => g.projectId === project.projectId);
        if (group) {
          select.innerHTML += env.html(`<option value="${project.projectId}">${group.name} (${project.projectId} - ${project.name || "N/A"})</option>`);
        }
      }
      entryCount++;
    }
  }
  let resourceEntryCount = 1; // Track number of resource entries (though no longer used for adding)
  // Track number of resource entries (though no longer used for adding)

  function removeResourceEntry(entryId) {
    const entry = document.getElementById(entryId);
    if (entry) entry.remove();
    populateFiltersAndForms(); // Update selects after removal
  }
  function toggleLinkInput(typeId, linkId, fileId) {
    const typeSelect = document.getElementById(typeId);
    const urlInput = document.getElementById(linkId);
    const fileInput = document.getElementById(fileId);
    if (typeSelect.value === "Website") {
      urlInput.style.display = "block";
      fileInput.style.display = "none";
      urlInput.required = true;
      fileInput.required = false;
    } else {
      // PDF hoặc Video
      urlInput.style.display = "none";
      fileInput.style.display = "block";
      urlInput.required = false;
      fileInput.required = true;
    }
  }
  function toggleEditLinkInput(typeId, linkId, fileId) {
    const typeSelect = document.getElementById(typeId);
    const linkInput = document.getElementById(linkId);
    if (typeSelect.value === "Website") {
      linkInput.type = "url";
    } else {
      linkInput.type = "text";
    }
  }
  async function addResources() {
    const form = document.getElementById("addResourceForm");
    if (form.checkValidity()) {
      const token = localStorage.getItem("token");
      const entryCount = 1; // Chỉ xử lý entry đầu tiên

      const groupSelect = document.getElementById(`resourceGroup${entryCount}`);
      const [projectId] = groupSelect.value.split("|"); // Chỉ lấy projectId
      const titleInput = document.getElementById(`resourceTitle${entryCount}`);
      const typeSelect = document.getElementById(`resourceType${entryCount}`);
      const urlInput = document.getElementById(`resourceLink${entryCount}`);
      const fileInput = document.getElementById(`resourceFile${entryCount}`);
      const title = titleInput.value;
      const type = typeSelect.value;
      if (!type || type === "") {
        alert("Vui lòng chọn loại tài liệu.");
        return;
      }
      let link = "";
      if (type === "Website") {
        link = urlInput.value;
      } else {
        const file = fileInput.files[0];
        if (!file) {
          alert("Vui lòng chọn file cho loại tài liệu PDF hoặc Video.");
          return;
        }
        const formData = new FormData();
        formData.append("file", file);
        formData.append("projectId", projectId);
        formData.append("title", title);
        formData.append("type", type);
        console.log("FormData contents:", [...formData.entries()]);
        const uploadResponse = await fetch(`${API_URL}/api/LecturerResources/upload`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Authorization": `Bearer ${token}`
          },
          credentials: "include",
          body: formData
        });
        if (!uploadResponse.ok) {
          const errorText = await uploadResponse.text();
          console.error("Upload error:", uploadResponse.status, errorText);
          alert(`Lỗi tải file lên: ${uploadResponse.status} - ${errorText}`);
          return;
        }
        const result = await uploadResponse.json();
        console.log("Upload response:", result);
        link = result.filePath || result.link || "";
        if (!link) {
          alert("Không nhận được liên kết từ server sau khi tải file.");
          return;
        }
      }
      const newResource = {
        courseId: selectedCourseId,
        projectId: projectId,
        title: title,
        type: type,
        link: link
      };
      try {
        console.log("Sending resource:", newResource);
        const response = await fetch(`${API_URL}/api/LecturerResources/resources`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
          },
          credentials: "include",
          body: JSON.stringify(newResource)
        });
        if (!response.ok) {
          const errorText = await response.text();
          console.error("Add resource error:", response.status, errorText);
          throw new Error(`Không thể thêm tài liệu: ${response.status} - ${errorText}`);
        }
        const result = await response.json();
        alert(result.message);
        bootstrap.Modal.getInstance(document.getElementById("addResourceModal")).hide();
        await loadResources();
      } catch (error) {
        console.error("Lỗi khi thêm tài liệu:", error);
        alert("Lỗi khi thêm tài liệu: " + error.message);
      }
    } else {
      form.reportValidity();
    }
  }
  async function editResource(resourceId) {
    const resource = resources.find(r => r.id === resourceId);
    if (resource) {
      document.getElementById("editResourceId").value = resource.id;
      document.getElementById("editResourceProjectId").value = resource.projectId || "N/A";
      document.getElementById("editResourceTitle").value = resource.title || "";
      document.getElementById("editResourceType").value = resource.type || "PDF";
      document.getElementById("editResourceLink").value = resource.link || "";
      const modal = new bootstrap.Modal(document.getElementById("editResourceModal"));
      modal.show();
    }
  }
  async function saveEditResource() {
    const form = document.getElementById("editResourceForm");
    if (form.checkValidity()) {
      const resourceId = parseInt(document.getElementById("editResourceId").value);
      const type = document.getElementById("editResourceType").value;
      const title = document.getElementById("editResourceTitle").value;
      const linkInput = document.getElementById("editResourceLink");
      const fileInput = document.getElementById("editResourceFile");
      let link = linkInput.value;
      if (type !== "Website" && fileInput.files.length > 0) {
        const file = fileInput.files[0];
        const formData = new FormData();
        formData.append("file", file);
        formData.append("projectId", document.getElementById("editResourceProjectId").value);
        formData.append("groupId", resources.find(r => r.id === resourceId)?.groupId || 0);
        formData.append("title", title);
        formData.append("type", type);
        const response = await fetch(`${API_URL}/api/LecturerResources/upload`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: formData
        });
        if (!response.ok) throw new Error("Không thể tải file lên");
        const result = await response.json();
        link = result.filePath;
      }
      const resourceDto = {
        title,
        type,
        link
      };
      try {
        const response = await fetch(`${API_URL}/api/LecturerResources/resources/${resourceId}`, {
          method: "PUT",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify(resourceDto)
        });
        if (!response.ok) throw new Error("Không thể cập nhật tài liệu");
        const result = await response.json();
        alert(result.message);
        bootstrap.Modal.getElementById("editResourceModal").hide();
        await loadResources();
      } catch (error) {
        console.error("Lỗi khi cập nhật tài liệu:", error);
        alert("Lỗi khi cập nhật tài liệu: " + error.message);
      }
    } else {
      form.reportValidity();
    }
  }
  async function deleteResource(resourceId) {
    if (confirm("Bạn có chắc chắn muốn xóa tài liệu này không?")) {
      try {
        const response = await fetch(`${API_URL}/api/LecturerResources/resources/${resourceId}`, {
          method: "DELETE",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include"
        });
        if (!response.ok) throw new Error("Không thể xóa tài liệu");
        const result = await response.json();
        alert(result.message);
        await loadResources();
      } catch (error) {
        console.error("Lỗi khi xóa tài liệu:", error);
        alert("Lỗi khi xóa tài liệu: " + error.message);
      }
    }
  }
  async function generateSuggestions() {
    const form = document.getElementById("aiSuggestionForm");
    const modalBody = document.getElementById("aiModalBody");
    const generateBtn = document.getElementById("generateBtn");
    if (form.checkValidity()) {
      modalBody.classList.add("loading");
      generateBtn.disabled = true;
      const projectId = document.getElementById("aiProjectId").value;
      const keywords = document.getElementById("aiKeywords").value;
      try {
        const response = await fetch(`${API_URL}/api/LecturerResources/suggestions`, {
          method: "POST",
          headers: {
            "Accept": "*/*",
            "Content-Type": "application/json",
            "Authorization": `Bearer ${localStorage.getItem("token")}`
          },
          credentials: "include",
          body: JSON.stringify({
            projectId,
            keywords
          })
        });
        if (!response.ok) throw new Error("Không thể tạo gợi ý");
        aiSuggestions = await response.json();
        displaySuggestions();
        document.getElementById("saveSuggestionsBtn").disabled = false;
      } catch (error) {
        console.error("Lỗi khi tạo gợi ý:", error);
        alert("Lỗi khi tạo gợi ý: " + error.message);
      } finally {
        modalBody.classList.remove("loading");
        generateBtn.disabled = false;
      }
    } else {
      form.reportValidity();
    }
  }
  function displaySuggestions() {
    const suggestionsList = document.getElementById("suggestionsList");
    suggestionsList.innerHTML = env.html("");
    if (aiSuggestions.length === 0) {
      suggestionsList.innerHTML = env.html("<p class=\"text-center\">Không có gợi ý nào.</p>");
      return;
    }
    aiSuggestions.forEach((suggestion, index) => {
      suggestionsList.innerHTML += env.html(`
                    <div class="suggestion-entry">
                        <div class="form-check">
                            <input class="form-check-input suggestion-checkbox" type="checkbox" id="suggestion-${index}" data-index="${index}">
                            <label class="form-check-label" for="suggestion-${index}">
                                ${suggestion.content}
                            </label>
                        </div>
                    </div>
                `);
    });
  }
  async function saveSelectedSuggestions() {
    const selectedSuggestions = [];
    document.querySelectorAll(".suggestion-checkbox:checked").forEach(checkbox => {
      const index = parseInt(checkbox.dataset.index);
      selectedSuggestions.push(aiSuggestions[index]);
    });
    if (selectedSuggestions.length === 0) {
      alert("Vui lòng chọn ít nhất một gợi ý để lưu.");
      return;
    }
    try {
      const response = await fetch(`${API_URL}/api/LecturerResources/save-suggestions`, {
        method: "POST",
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("token")}`
        },
        credentials: "include",
        body: JSON.stringify(selectedSuggestions)
      });
      if (!response.ok) throw new Error("Không thể lưu gợi ý");
      const result = await response.json();
      alert(result.message);
      bootstrap.Modal.getInstance(document.getElementById("aiSuggestionModal")).hide();
      await loadResources();
    } catch (error) {
      console.error("Lỗi khi lưu gợi ý:", error);
      alert("Lỗi khi lưu gợi ý: " + error.message);
    }
  }
  function exportResources() {
    const filteredResources = getFilteredResources();
    const worksheetData = [["Danh sách tài liệu gợi ý - Hệ thống Sinh viên HUTECH"], [`Giảng viên hướng dẫn: ${fullNameLecturer || "Nguyễn Huy Cường"}`], [], ["#", "Mã đồ án", "Tên nhóm", "Tiêu đề", "Loại tài liệu", "Liên kết"]];
    filteredResources.forEach((resource, index) => {
      worksheetData.push([index + 1, resource.projectId || "N/A", resource.groupName || "N/A", resource.title || "N/A", resource.type || "N/A", resource.link || "N/A"]);
    });
    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "TaiLieuGoiY");
    XLSX.writeFile(workbook, `tai_lieu_goi_y_${selectedCourseId}_${selectedFacultyCode}.xlsx`);
  }
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
      console.error("Lỗi khi đăng xuất:", error);
    }
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    env.navigate("/font-end/login/login.html", true);
  }
  env.listen(document, "DOMContentLoaded", async () => {
    try {
      await loadUserProfile();
      await loadResources();
    } catch (error) {
      console.error("Lỗi khi tải trang:", error);
      alert(`Không tải được dữ liệu: ${error.message || "Vui lòng đăng nhập lại."}`);
      logout();
    }
  });
  return {
    event0: function (event) {
      toggleSidebar();
    },
    event1: function (event) {
      logout();
    },
    event2: function (event) {
      exportResources();
    },
    event3: function (event) {
      filterTable();
    },
    event4: function (event) {
      filterTable();
    },
    event5: function (event) {
      sortTable("projectId");
    },
    event6: function (event) {
      sortTable("groupName");
    },
    event7: function (event) {
      sortTable("title");
    },
    event8: function (event) {
      sortTable("type");
    },
    event9: function (event) {
      sortTable("link");
    },
    event10: function (event) {
      toggleLinkInput("resourceType1", "resourceLink1", "resourceFile1");
    },
    event11: function (event) {
      removeResourceEntry("resourceEntry1");
    },
    event12: function (event) {
      addResources();
    },
    event13: function (event) {
      toggleEditLinkInput("editResourceType", "editResourceLink", "editResourceFile");
    },
    event14: function (event) {
      saveEditResource();
    },
    event15: function (event) {
      generateSuggestions();
    },
    event16: function (event) {
      saveSelectedSuggestions();
    }
  };
}

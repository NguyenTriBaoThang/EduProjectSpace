import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerResources.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/resources");
export default function LecturerResources() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/resources">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <h6 className="sidebar-subtitle">{"Giảng viên hướng dẫn"}</h6>
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Danh sách môn duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
    <a href="/lecturer/course-resources" className="active"><i className="bi bi-book"></i>{" Gợi ý tài liệu"}</a>
    <a href="/lecturer/course-reviews"><i className="bi bi-star"></i>{" Đánh giá tổng quan"}</a>
    <a href="/lecturer/course-groups"><i className="bi bi-people"></i>{" Chia nhóm sinh viên"}</a>
  </div>
    </div>


    <div className="content">

  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <button className="navbar-toggler toggle-btn" onClick={event => page.invoke("event0", event)}>
      <i className="bi bi-list"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>

  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Lecturer Avatar" />
      <h6 id="userName">{"Nguyễn Huy Cường"}</h6>
      <p id="userEmail">{"nguyenhuycuong@hutech.edu.vn"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event1", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>

  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"📚 Gợi ý tài liệu"}</h2>
      <div>
        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#addResourceModal">{"Thêm tài liệu "}<i className="bi bi-plus-circle"></i></button>
        <button className="btn btn-primary me-2" data-bs-toggle="modal" data-bs-target="#aiSuggestionModal">{"Tạo gợi ý AI "}<i className="bi bi-robot"></i></button>
        <button className="btn btn-info" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/lecturer/course-resources"><i className="bi bi-book"></i>{" Danh sách môn cần gợi ý tài liệu"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-folder"></i>{" Gợi ý tài liệu"}</li>
      </ol>
    </nav>

    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm tài liệu..."} onKeyUp={event => page.invoke("event3", event)} />
        <select id="projectFilter" className="form-select" onChange={event => page.invoke("event4", event)}>
          <option value="">{"📂 Chọn đồ án"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Mã đồ án "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Tên nhóm "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Tiêu đề "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Loại tài liệu "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Liên kết "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Hành động"}</th>
            </tr>
          </thead>
          <tbody id="tableBody"></tbody>
        </table>
      </div>
      <div className="table-footer">
        <ul id="pagination" className="pagination"></ul>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="addResourceModal" tabIndex="-1" aria-labelledby="addResourceModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addResourceModalLabel">{"Thêm tài liệu"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addResourceForm">
          <div id="resourceList">
            <div id="resourceEntry1" className="resource-entry">
              <div className="mb-3">
                <label className="form-label">{"Nhóm và đồ án"}</label>
                <select id="resourceGroup1" className="form-select" required={true}>
                  <option value="">{"Chọn nhóm"}</option>
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">{"Tiêu đề"}</label>
                <input type="text" id="resourceTitle1" className="form-control" required={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Loại tài liệu"}</label>
                <select id="resourceType1" className="form-select" required={true} onChange={event => page.invoke("event10", event)}>
                  <option value="">{"Chọn loại"}</option>
                  <option value="PDF">{"PDF"}</option>
                  <option value="Website">{"Website"}</option>
                  <option value="Video">{"Video"}</option>
                </select>
              </div>
              <div className="mb-3 resource-link-container">
                <label className="form-label">{"Liên kết"}</label>
                <input type="url" id="resourceLink1" className="form-control" required={true} />
                <input type="file" id="resourceFile1" className="form-control" style={{
                      "display": "none"
                    }} accept=".pdf,.mp4" />
              </div>
              <button type="button" className="btn btn-danger btn-sm" onClick={event => page.invoke("event11", event)}>{"Xóa"}</button>
            </div>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event12", event)}>{"Thêm"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="editResourceModal" tabIndex="-1" aria-labelledby="editResourceModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editResourceModalLabel">{"Sửa tài liệu"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editResourceForm">
          <input type="hidden" id="editResourceId" />
          <div className="mb-3">
            <label className="form-label">{"Mã đồ án"}</label>
            <input type="text" id="editResourceProjectId" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tiêu đề"}</label>
            <input type="text" id="editResourceTitle" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Loại tài liệu"}</label>
            <select id="editResourceType" className="form-select" required={true} onChange={event => page.invoke("event13", event)}>
              <option value="PDF">{"PDF"}</option>
              <option value="Website">{"Website"}</option>
              <option value="Video">{"Video"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Liên kết hoặc File"}</label>
            <input type="url" id="editResourceLink" className="form-control" required={true} />
            <input type="file" id="editResourceFile" className="form-control" style={{
                  "display": "none"
                }} accept=".pdf,.mp4" />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event14", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="aiSuggestionModal" tabIndex="-1" aria-labelledby="aiSuggestionModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="aiSuggestionModalLabel">{"Tạo gợi ý tài liệu bằng AI"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body" id="aiModalBody">
        <form id="aiSuggestionForm">
          <div className="mb-3">
            <label className="form-label">{"Chọn đồ án"}</label>
            <select id="aiProjectId" className="form-select" required={true}>
              <option value="">{"Chọn đồ án"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Từ khóa (cách nhau bằng dấu phẩy)"}</label>
            <input type="text" id="aiKeywords" className="form-control" placeholder={"ví dụ: Java, Web Development"} required={true} />
          </div>
        </form>
        <div id="suggestionsList" className="mt-3"></div>
        <div className="loading-spinner" id="loadingSpinner"></div>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" id="generateBtn" onClick={event => page.invoke("event15", event)}>{"Tạo gợi ý"}</button>
        <button type="button" className="btn btn-success" id="saveSuggestionsBtn" onClick={event => page.invoke("event16", event)} disabled={true}>{"Lưu gợi ý đã chọn"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

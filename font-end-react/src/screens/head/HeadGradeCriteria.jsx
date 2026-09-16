import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadGradeCriteria.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/grade-criteria");
export default function HeadGradeCriteria() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/grade-criteria">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list" className="active"><i className="bi bi-book"></i>{" Danh sách học phần"}</a>
    <a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
    <a href="/head/grading-courses"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a>
    <a href="/head/defense-list"><i className="bi bi-calendar"></i>{" Quản lý lịch bảo vệ"}</a>
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
      <input type="text" className="search-box me-3" id="searchInput" placeholder={"🔍 Tìm tiêu chí..."} onKeyUp={event => page.invoke("event1", event)} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>
  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Avatar" />
      <h6 id="headName">{"Head HUTECH"}</h6>
      <p id="headEmail">{"head@hutech.edu.vn"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button id="resetDefaultBtn" type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>
  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"📊 Quản lý tiêu chí chấm điểm: "}<span id="courseName">{"Học phần"}</span></h2>
      <div>
        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#addModal">{"Thêm tiêu chí "}<i className="bi bi-plus-circle"></i></button>
        <label className="btn btn-warning me-2">{"\n                        Nhập Excel "}<input type="file" id="importExcel" accept=".xlsx" style={{
                "display": "none"
              }} onChange={event => page.invoke("event3", event)} />
        </label>
        <button className="btn btn-info" onClick={event => page.invoke("event4", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/course-list">{"Danh sách học phần"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Tên tiêu chí "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Trọng số "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Mô tả"}</th>
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
  <div className="toast-container">
    <div id="toast" className="toast" role="alert" data-bs-autohide="true" data-bs-delay="3000">
      <div className="toast-body"></div>
    </div>
  </div>
  <div className="modal fade" id="addModal" tabIndex="-1" aria-labelledby="addModalLabel" aria-hidden="true">
    <div className="modal-dialog">
      <div className="modal-content">
        <div className="modal-header">
          <h5 className="modal-title" id="addModalLabel">{"Thêm tiêu chí chấm điểm"}</h5>
          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div className="modal-body">
          <form id="addForm">
            <input type="hidden" id="addCourseId" />
            <div className="mb-3">
              <label className="form-label">{"Tên tiêu chí"}</label>
              <input type="text" id="addName" className="form-control" maxLength="100" required={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Trọng số (0-1)"}</label>
              <input type="number" id="addWeight" className="form-control" step="0.01" min="0" max="1" required={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Mô tả"}</label>
              <textarea id="addDescription" className="form-control" maxLength="500"></textarea>
            </div>
          </form>
        </div>
        <div className="modal-footer">
          <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
          <button type="button" className="btn btn-primary" onClick={event => page.invoke("event7", event)}>{"Thêm"}</button>
        </div>
      </div>
    </div>
  </div>
  <div className="modal fade" id="editModal" tabIndex="-1" aria-labelledby="editModalLabel" aria-hidden="true">
    <div className="modal-dialog">
      <div className="modal-content">
        <div className="modal-header">
          <h5 className="modal-title" id="editModalLabel">{"Sửa tiêu chí chấm điểm"}</h5>
          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div className="modal-body">
          <form id="editForm">
            <input type="hidden" id="editId" />
            <input type="hidden" id="editCourseId" />
            <div className="mb-3">
              <label className="form-label">{"Tên tiêu chí"}</label>
              <input type="text" id="editName" className="form-control" maxLength="100" required={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Trọng số (0-1)"}</label>
              <input type="number" id="editWeight" className="form-control" step="0.01" min="0" max="1" required={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Mô tả"}</label>
              <textarea id="editDescription" className="form-control" maxLength="500"></textarea>
            </div>
          </form>
        </div>
        <div className="modal-footer">
          <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
          <button type="button" className="btn btn-primary" onClick={event => page.invoke("event8", event)}>{"Lưu"}</button>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền HUTECH – Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

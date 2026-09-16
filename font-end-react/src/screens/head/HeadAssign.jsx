import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadAssign.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/assign");
export default function HeadAssign() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/assign">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign" className="active"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
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
      <input type="text" className="search-box me-3" id="searchInput" placeholder={"🔍 Tìm sinh viên..."} onKeyUp={event => page.invoke("event1", event)} />
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
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>
  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"👩‍🏫 Phân công giảng viên hướng dẫn"}</h2>
      <div>
        <button className="btn btn-success me-2" onClick={event => page.invoke("event3", event)}>{"Phân công tự động"}</button>
        <button className="btn btn-info me-2" onClick={event => page.invoke("event4", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
        <label className="btn btn-warning">{"\n                        Nhập Excel "}<input type="file" id="importFile" accept=".xlsx" style={{
                "display": "none"
              }} onChange={event => page.invoke("event5", event)} />
        </label>
      </div>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Danh sách môn cần phân công"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-folder"></i>{" Phân công GVHD"}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="courseCodeDisplay" className="form-control" readOnly={true} placeholder={"Học phần"} />
        <input type="text" id="semesterNameDisplay" className="form-control" readOnly={true} placeholder={"Học kỳ"} />
        <input type="text" id="facultyCodeDisplay" className="form-control" readOnly={true} placeholder="Khoa" />
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Mã SV "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Tên SV "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Học phần"}</th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Giảng viên HD "}<i className="bi bi-arrow-down-up"></i></th>
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
    <div className="modal fade" id="autoAssignModal" tabIndex="-1" aria-labelledby="autoAssignModalLabel" aria-hidden="true">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title" id="autoAssignModalLabel">{"Phân công tự động"}</h5>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div className="modal-body">
            <form id="autoAssignForm">
              <div className="mb-3">
                <label className="form-label">{"Chọn giảng viên (ít nhất 1)"}</label>
                <div id="lecturerCheckboxes" className="lecturer-checkboxes"></div>
              </div>
            </form>
          </div>
          <div className="modal-footer">
            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
            <button type="button" className="btn btn-primary" onClick={event => page.invoke("event9", event)}>{"Xác nhận"}</button>
          </div>
        </div>
      </div>
    </div>
    <div className="modal fade" id="assignModal" tabIndex="-1" aria-labelledby="assignModalLabel" aria-hidden="true">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title" id="assignModalLabel">{"Phân công giảng viên hướng dẫn"}</h5>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div className="modal-body">
            <form id="assignForm">
              <input type="hidden" id="assignStudentId" />
              <div className="mb-3">
                <label className="form-label">{"Mã sinh viên"}</label>
                <input type="text" id="assignStudentCode" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Tên sinh viên"}</label>
                <input type="text" id="assignStudentName" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Học phần"}</label>
                <input type="text" id="assignCourseCode" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Giảng viên hướng dẫn"}</label>
                <select id="assignLecturer" className="form-select" required={true}>
                  <option value="">{"Chọn giảng viên"}</option>
                </select>
              </div>
            </form>
          </div>
          <div className="modal-footer">
            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
            <button type="button" className="btn btn-primary" onClick={event => page.invoke("event10", event)}>{"Lưu"}</button>
          </div>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền HUTECH – Team TAD Programmer ©2025\n    "}</div>





  </div>;
}

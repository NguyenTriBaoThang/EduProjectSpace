import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./AdminCourses.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/admin/courses");
export default function AdminCourses() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/admin/courses">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Admin"}</h4>
  <a href="/admin/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="dropdown-menu-wrapper">
    <button onClick={event => page.invoke("event0", event)} className="dropdown-toggle link-button" type="button">
      <i className="bi bi-person-circle"></i>{" Quản lý tài khoản\n            "}</button>
    <div className="dropdown-content" style={{
          "display": "none",
          "paddingLeft": "20px"
        }}>
      <a href="/admin/users"><i className="bi bi-person-lines-fill"></i>{" Người dùng"}</a>
      <a href="/admin/lecturers"><i className="bi bi-person-workspace"></i>{" Giảng viên"}</a>
      <a href="/admin/students"><i className="bi bi-people"></i>{" Sinh viên"}</a>
    </div>
  </div>
  <a href="/admin/semesters"><i className="bi bi-calendar"></i>{" Quản lý kỳ học"}</a>
  <a href="/admin/courses" className="active"><i className="bi bi-book"></i>{" Quản lý học phần"}</a>
  <a href="/admin/projects"><i className="bi bi-folder"></i>{" Quản lý đề tài"}</a>
  <a href="/admin/notifications"><i className="bi bi-bell"></i>{" Quản lý thông báo"}</a>
  <a href="/admin/logs"><i className="bi bi-clock-history"></i>{" Lịch sử hoạt động"}</a>
  <a href="/admin/grading"><i className="bi bi-award"></i>{" Quản lý hội đồng"}</a>
  <a href="/admin/settings"><i className="bi bi-gear"></i>{" Cài đặt hệ thống"}</a>
  <a href="/admin/reports"><i className="bi bi-bar-chart"></i>{" Báo cáo thống kê"}</a>
    </div>

    <div className="content">
  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <button className="navbar-toggler toggle-btn" onClick={event => page.invoke("event1", event)}>
      <i className="bi bi-list"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} id="searchInput" onKeyUp={event => page.invoke("event2", event)} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>
  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Admin Avatar" />
      <h6 id="adminName">{"Admin HUTECH"}</h6>
      <p id="adminEmail">{"admin@hutech.edu.vn"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event3", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>
  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"📚 Quản lý học phần"}</h2>
      <div>
        <button className="btn btn-success me-2" onClick={event => page.invoke("event4", event)}>{"Thêm học phần "}<i className="bi bi-plus"></i></button>
        <button className="btn btn-info me-2" onClick={event => page.invoke("event5", event)}>{"Nhập Excel "}<i className="bi bi-file-earmark-arrow-up"></i></button>
        <button className="btn btn-info" onClick={event => page.invoke("event6", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/admin/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-book"></i>{" Quản lý học phần\n                    "}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInputFuse" className="form-control" placeholder={"🔍 Tìm tên học phần..."} onKeyUp={event => page.invoke("event7", event)} />
        <select id="facultyFilter" className="form-select" onChange={event => page.invoke("event8", event)}>
          <option value="">{"🏫 Chọn khoa"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Mã học phần "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event10", event)}>{"Tên học phần "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event11", event)}>{"Kỳ học "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event12", event)}>{"Khoa "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event13", event)}>{"Ngày bắt đầu "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event14", event)}>{"Ngày kết thúc "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event15", event)}>{"Ngày bảo vệ "}<i className="bi bi-arrow-down-up"></i></th>
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

    <div className="modal fade" id="addCourseModal" tabIndex="-1" aria-labelledby="addCourseModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addCourseModalLabel">{"Thêm học phần"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addCourseForm">
          <div className="mb-3">
            <label className="form-label">{"Tên học phần"}</label>
            <input type="text" id="addCourseName" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Kỳ học"}</label>
            <select id="addSemester" className="form-select" required={true}>
              <option value="">{"Chọn kỳ học"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Khoa"}</label>
            <select id="addFaculty" className="form-select" required={true}>
              <option value="">{"Chọn khoa"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày bắt đầu"}</label>
            <input type="date" id="addStartDate" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày kết thúc"}</label>
            <input type="date" id="addEndDate" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày bảo vệ"}</label>
            <input type="date" id="addDefenseDate" className="form-control" />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event16", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="editCourseModal" tabIndex="-1" aria-labelledby="editCourseModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editCourseModalLabel">{"Sửa học phần"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editCourseForm">
          <input type="hidden" id="editCourseId" />
          <div className="mb-3">
            <label className="form-label">{"Mã học phần"}</label>
            <input type="text" id="editCourseCode" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tên học phần"}</label>
            <input type="text" id="editCourseName" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Kỳ học"}</label>
            <select id="editSemester" className="form-select" required={true}>
              <option value="">{"Chọn kỳ học"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Khoa"}</label>
            <select id="editFaculty" className="form-select" required={true}>
              <option value="">{"Chọn khoa"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày bắt đầu"}</label>
            <input type="date" id="editStartDate" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày kết thúc"}</label>
            <input type="date" id="editEndDate" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Ngày bảo vệ"}</label>
            <input type="date" id="editDefenseDate" className="form-control" />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event17", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

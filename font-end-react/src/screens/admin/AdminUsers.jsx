import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./AdminUsers.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/admin/users");
export default function AdminUsers() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/admin/users">

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
      <a href="/admin/users" className="active"><i className="bi bi-person-lines-fill"></i>{" Người dùng"}</a>
      <a href="/admin/lecturers"><i className="bi bi-person-workspace"></i>{" Giảng viên"}</a>
      <a href="/admin/students"><i className="bi bi-people"></i>{" Sinh viên"}</a>
    </div>
  </div>
  <a href="/admin/semesters"><i className="bi bi-calendar"></i>{" Quản lý kỳ học"}</a>
  <a href="/admin/courses"><i className="bi bi-book"></i>{" Quản lý học phần"}</a>
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
      <h2 className="fw-bold text-primary">{"👤 Quản lý người dùng"}</h2>
      <div>
        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#addUserModal">{"Thêm người dùng "}<i className="bi bi-plus-circle"></i></button>
        <button className="btn btn-warning me-2" onClick={event => page.invoke("event4", event)}>{"Nhập Excel "}<i className="bi bi-file-earmark-arrow-up"></i></button>
        <input type="file" id="importExcel" style={{
              "display": "none"
            }} accept=".xlsx, .xls" onChange={event => page.invoke("event5", event)} />
        <button className="btn btn-info" onClick={event => page.invoke("event6", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/admin/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-person-lines-fill"></i>{" Quản lý người dùng\n                    "}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInputFuse" className="form-control" placeholder={"🔍 Tìm người dùng..."} onKeyUp={event => page.invoke("event7", event)} />
        <select id="roleFilter" className="form-select" onChange={event => page.invoke("event8", event)}>
          <option value="">{"📂 Vai trò"}</option>
          <option value="ROLE_ADMIN">{"Admin"}</option>
          <option value="ROLE_HEAD">{"Trưởng bộ môn"}</option>
          <option value="ROLE_LECTURER_GUIDE">{"Giảng viên hướng dẫn"}</option>
          <option value="ROLE_STUDENT">{"Sinh viên"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Tên "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Email"}</th>
              <th className="sortable" onClick={event => page.invoke("event10", event)}>{"Vai trò "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event11", event)}>{"Trạng thái "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Hành động"}</th>
            </tr>
          </thead>
          <tbody id="userTableBody"></tbody>
        </table>
      </div>
      <div className="table-footer">
        <ul id="pagination" className="pagination"></ul>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="addUserModal" tabIndex="-1" aria-labelledby="addUserModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addUserModalLabel">{"Thêm người dùng mới"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addUserForm">
          <div className="mb-3">
            <label className="form-label" htmlFor="userUsername">{"Tên đăng nhập"}</label>
            <input type="text" id="userUsername" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="userFullName">{"Họ và tên"}</label>
            <input type="text" id="userFullName" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="userEmail">{"Email"}</label>
            <input type="email" id="userEmail" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="userRole">{"Vai trò"}</label>
            <select id="userRole" className="form-select" onChange={event => page.invoke("event12", event)}>
              <option value="1">{"Admin"}</option>
              <option value="2">{"Giảng viên hướng dẫn"}</option>
              <option value="3">{"Sinh viên"}</option>
              <option value="4">{"Trưởng bộ môn"}</option>
            </select>
          </div>
          <div className="mb-3" id="addUserDepartmentIdContainer" style={{
                "display": "none"
              }}>
            <label className="form-label" htmlFor="addUserDepartmentId">{"Khoa"}</label>
            <select id="addUserDepartmentId" className="form-select" required={true}>

            </select>
          </div>
          <div className="mb-3" id="addUserClassCodeContainer" style={{
                "display": "none"
              }}>
            <label className="form-label" htmlFor="userClassCode">{"Mã lớp"}</label>
            <input type="text" id="userClassCode" className="form-control" />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event13", event)}>{"Thêm"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="editUserModal" tabIndex="-1" aria-labelledby="editUserModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editUserModalLabel">{"Sửa thông tin người dùng"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editUserForm">
          <input type="hidden" id="editUserId" />
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserUsername">{"Tên đăng nhập"}</label>
            <input type="text" id="editUserUsername" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserFullName">{"Họ và tên"}</label>
            <input type="text" id="editUserFullName" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserEmail">{"Email"}</label>
            <input type="email" id="editUserEmail" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserPassword">{"Mật khẩu"}</label>
            <input type="password" id="editUserPassword" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserRole">{"Vai trò"}</label>
            <select id="editUserRole" className="form-select" required={true} onChange={event => page.invoke("event14", event)}>
              <option value="1">{"Admin"}</option>
              <option value="2">{"Giảng viên hướng dẫn"}</option>
              <option value="3">{"Sinh viên"}</option>
              <option value="4">{"Trưởng bộ môn"}</option>
            </select>
          </div>
          <div className="mb-3" id="editUserDepartmentIdContainer" style={{
                "display": "none"
              }}>
            <label className="form-label" htmlFor="editUserDepartmentId">{"Khoa"}</label>
            <select id="editUserDepartmentId" className="form-select" required={true}>

            </select>
          </div>
          <div className="mb-3" id="editUserClassCodeContainer" style={{
                "display": "none"
              }}>
            <label className="form-label" htmlFor="editUserClassCode">{"Mã lớp"}</label>
            <input type="text" id="editUserClassCode" className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label" htmlFor="editUserStatus">{"Trạng thái"}</label>
            <select id="editUserStatus" className="form-select" required={true}>
              <option value="false">{"Hoạt động"}</option>
              <option value="true">{"Khóa"}</option>
            </select>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event15", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./AdminLogs.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/admin/logs");
export default function AdminLogs() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/admin/logs">

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
  <a href="/admin/courses"><i className="bi bi-book"></i>{" Quản lý học phần"}</a>
  <a href="/admin/projects"><i className="bi bi-folder"></i>{" Quản lý đề tài"}</a>
  <a href="/admin/notifications"><i className="bi bi-bell"></i>{" Quản lý thông báo"}</a>
  <a href="/admin/logs" className="active"><i className="bi bi-clock-history"></i>{" Lịch sử hoạt động"}</a>
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
      <input type="text" className="search-box me-3" id="searchInputFuse" placeholder={"🔍 Tìm log..."} />
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
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>
  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"⏳ Lịch sử hoạt động"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event3", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/admin/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-clock-history"></i>{" Lịch sử hoạt động\n                    "}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInputFuse" className="form-control" placeholder={"🔍 Tìm log..."} onKeyUp={event => page.invoke("event4", event)} />
        <select id="roleFilter" className="form-select" onChange={event => page.invoke("event5", event)}>
          <option value="">{"📂 Vai trò"}</option>
          <option value="ROLE_ADMIN">{"Admin"}</option>
          <option value="ROLE_HEAD">{"Trưởng bộ môn"}</option>
          <option value="ROLE_LECTURER_GUIDE">{"Giảng viên hướng dẫn"}</option>
          <option value="ROLE_STUDENT">{"Sinh viên"}</option>
        </select>
        <select id="actionFilter" className="form-select" onChange={event => page.invoke("event6", event)}>
          <option value="">{"📌 Hành động"}</option>
          <option value="LOGIN">{"Đăng nhập"}</option>
          <option value="LOGOUT">{"Đăng xuất"}</option>
          <option value="CREATE">{"Thêm"}</option>
          <option value="UPDATE">{"Sửa"}</option>
          <option value="DELETE">{"Xóa"}</option>
          <option value="SEND">{"Gửi tin nhắn"}</option>
          <option value="SUBMISSION">{"Nộp bài"}</option>
          <option value="JONT_GROUP">{"Tham gia nhóm"}</option>
          <option value="GREADE">{"Chấm điểm"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Thời gian "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Người dùng "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Vai trò "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event10", event)}>{"Hành động "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event11", event)}>{"Chi tiết "}<i className="bi bi-arrow-down-up"></i></th>
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

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

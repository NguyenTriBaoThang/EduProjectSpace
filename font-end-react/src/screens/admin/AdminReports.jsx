import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./AdminReports.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/admin/reports");
export default function AdminReports() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/admin/reports">


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
  <a href="/admin/logs"><i className="bi bi-clock-history"></i>{" Lịch sử hoạt động"}</a>
  <a href="/admin/grading"><i className="bi bi-award"></i>{" Quản lý hội đồng"}</a>
  <a href="/admin/settings"><i className="bi bi-gear"></i>{" Cài đặt hệ thống"}</a>
  <a href="/admin/reports" className="active"><i className="bi bi-bar-chart"></i>{" Báo cáo thống kê"}</a>
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
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} />
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
      <h2 className="fw-bold text-primary">{"📊 Báo cáo thống kê"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event3", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/admin/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-bar-chart"></i>{" Báo cáo thống kê\n                    "}</li>
      </ol>
    </nav>

    <div className="mb-4">
      <div className="d-flex gap-3 mb-3">
        <select id="semesterFilter" className="form-select" onChange={event => page.invoke("event4", event)}>
          <option value="">{"📅 Chọn kỳ học"}</option>
        </select>
        <select id="facultyFilter" className="form-select" onChange={event => page.invoke("event5", event)}>
          <option value="">{"🏫 Chọn khoa"}</option>
        </select>
      </div>

      <div className="row">
        <div className="col-md-3">
          <div className="card-dashboard" style={{
                "background": "linear-gradient(90deg, #3498db, #2980b9)",
                "color": "white"
              }}>
            <div className="card-header">
              <i className="bi bi-people"></i>
              <h5>{"Số lượng sinh viên"}</h5>
            </div>
            <div className="card-content">
              <h3 id="studentCount">{"0"}</h3>
            </div>
          </div>
        </div>
        <div className="col-md-3">
          <div className="card-dashboard" style={{
                "background": "linear-gradient(90deg, #2ecc71, #27ae60)",
                "color": "white"
              }}>
            <div className="card-header">
              <i className="bi bi-folder-check"></i>
              <h5>{"Số đề tài đã duyệt"}</h5>
            </div>
            <div className="card-content">
              <h3 id="approvedProjects">{"0"}</h3>
            </div>
          </div>
        </div>
        <div className="col-md-3">
          <div className="card-dashboard" style={{
                "background": "linear-gradient(90deg, #f39c12, #e67e22)",
                "color": "white"
              }}>
            <div className="card-header">
              <i className="bi bi-lightbulb"></i>
              <h5>{"Số đề tài chưa duyệt"}</h5>
            </div>
            <div className="card-content">
              <h3 id="pendingProjects">{"0"}</h3>
            </div>
          </div>
        </div>
        <div className="col-md-3">
          <div className="card-dashboard" style={{
                "background": "linear-gradient(90deg, #9b59b6, #8e44ad)",
                "color": "white"
              }}>
            <div className="card-header">
              <i className="bi bi-person-workspace"></i>
              <h5>{"Số giảng viên"}</h5>
            </div>
            <div className="card-content">
              <h3 id="lecturerCount">{"0"}</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

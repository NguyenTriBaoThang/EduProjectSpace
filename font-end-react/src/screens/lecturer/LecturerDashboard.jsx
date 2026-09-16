import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerDashboard.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/dashboard");
export default function LecturerDashboard() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/dashboard">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard" className="active"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section" id="lecturerSection">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
    <a href="/lecturer/course-resources"><i className="bi bi-book"></i>{" Gợi ý tài liệu"}</a>
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
      <h2 className="fw-bold text-primary">{"📊 Tổng quan Giảng viên hướng dẫn"}</h2>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-house-door-fill"></i>{" Tổng quan\n                    "}</li>
      </ol>
    </nav>

    <div className="row mb-4">
      <div className="col-md-3">
        <div className="card-dashboard" style={{
              "background": "linear-gradient(90deg, #3498db, #2980b9)",
              "color": "white"
            }}>
          <div className="card-header">
            <i className="bi bi-folder"></i>
            <h5>{"Số đề tài hướng dẫn"}</h5>
          </div>
          <div className="card-content">
            <h3 id="projectCount">{"0"}</h3>
          </div>
        </div>
      </div>
      <div className="col-md-3">
        <div className="card-dashboard" style={{
              "background": "linear-gradient(90deg, #2ecc71, #27ae60)",
              "color": "white"
            }}>
          <div className="card-header">
            <i className="bi bi-check-circle"></i>
            <h5>{"Đề tài đã duyệt"}</h5>
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
            <i className="bi bi-hourglass-split"></i>
            <h5>{"Đề tài chờ duyệt"}</h5>
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
            <i className="bi bi-bell"></i>
            <h5>{"Thông báo mới"}</h5>
          </div>
          <div className="card-content">
            <h3 id="notificationCount">{"0"}</h3>
          </div>
        </div>
      </div>
    </div>

    <div className="card-dashboard">
      <div className="card-header">
        <i className="bi bi-bell"></i>
        <h5>{"Thông báo hệ thống"}</h5>
      </div>
      <div className="card-content">
        <ul className="list-group list-group-flush" id="notificationList">
          <li className="dashboard-list-group-item">
            <i className="bi bi-folder-check"></i>
            <span className="dashboard-notification-title">{"Đang tải thông báo..."}</span>
            <span className="text-muted"></span>
          </li>
        </ul>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

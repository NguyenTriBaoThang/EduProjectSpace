import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./NotificationsList.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/notifications-list");
export default function NotificationsList() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/notifications-list">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
  <a href="/student/proposals-list"><i className="bi bi-lightbulb"></i>{" Đề xuất đề tài đồ án"}</a>
  <a href="/student/schedule"><i className="bi bi-calendar"></i>{" Lịch cá nhân"}</a>
  <a href="/student/grades-list"><i className="bi bi-award"></i>{" Hệ thống chấm điểm"}</a>
    </div>


    <div className="content">

  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} id="searchInput" onKeyUp={event => page.invoke("event0", event)} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn position-relative">
        <i className="bi bi-bell"></i>
        <span className="badge bg-danger position-absolute top-0 start-100 translate-middle" id="unreadCount">{"0"}</span>
      </button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>

  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/student/img/avatar.jpg" alt="User Avatar" />
      <h6>{"Nguyễn Tri Bão Thắng"}</h6>
      <p>{"nguyentribaothang@gmail.com"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <a href="/login" className="logout"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</a>
    </div>
  </div>
  <div className="container mt-4 notification-container">

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-bell-fill"></i>{" Danh sách thông báo\n                    "}</li>
      </ol>
    </nav>

    <div className="mb-4 d-flex gap-3">
      <input type="text" className="form-control" id="searchInput" placeholder={"🔍 Tìm kiếm thông báo..."} onKeyUp={event => page.invoke("event1", event)} />
      <select className="form-select w-25" id="statusFilter" onChange={event => page.invoke("event2", event)}>
        <option value="">{"Trạng thái"}</option>
        <option value="unread">{"Chưa đọc"}</option>
        <option value="read">{"Đã đọc"}</option>
      </select>
    </div>

    <div id="notificationList" className="notification-grid"></div>

    <div className="pagination-container">
      <ul id="pagination" className="pagination"></ul>
    </div>
  </div>
    </div>


    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>




  </div>;
}

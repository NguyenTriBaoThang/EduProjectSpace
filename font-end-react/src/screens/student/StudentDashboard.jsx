import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentDashboard.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/dashboard");
export default function StudentDashboard() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/dashboard">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard" className="active"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án "}<span className="badge bg-danger ms-2" id="pendingTasks">{"0"}</span></a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
  <a href="/student/proposals-list"><i className="bi bi-lightbulb"></i>{" Đề xuất đề tài đồ án"}</a>
  <a href="/student/schedule"><i className="bi bi-calendar"></i>{" Lịch cá nhân"}</a>
  <a href="/student/grades-list"><i className="bi bi-award"></i>{" Hệ thống chấm điểm"}</a>
    </div>


    <div className="content" id="content">

  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} id="searchInput" onKeyUp={event => page.invoke("event0", event)} />
      <button id="calendarBtn" className="btn"><i className="bi bi-calendar"></i></button>
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
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="User Avatar" />
      <h6 id="userName">{"Nguyễn Tri Bão Thắng"}</h6>
      <p id="userEmail">{"nguyentribaothang@gmail.com"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <a href="/login" className="logout" onClick={event => page.invoke("event1", event)}><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</a>
    </div>
  </div>

  <div className="container mt-4">
    <h2 className="fw-bold text-primary">{"📊 BẢNG ĐIỀU KHIỂN"}</h2>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-house-door-fill"></i>{" Tổng quan\n                    "}</li>
      </ol>
    </nav>

    <div className="row mt-4">

      <div className="col-md-4">
        <div className="card-dashboard shadow">
          <div className="card-header d-flex align-items-center">
            <i className="bi bi-upload text-primary fs-4 me-2"></i>
            <h5 className="mb-0">{"Bài tập đã nộp"}</h5>
          </div>
          <div className="card-content text-center">
            <canvas id="submissionChart"></canvas>
            <p className="fw-bold mt-2 text-success">{"Tổng số: "}<span id="totalSubmissions">{"0"}</span></p>
          </div>
          <div className="card-footer text-center text-muted">{"📅 Cập nhật: Hôm nay"}</div>
        </div>
      </div>

      <div className="col-md-4">
        <div className="card-dashboard shadow">
          <div className="card-header d-flex align-items-center">
            <i className="bi bi-bar-chart-line text-success fs-4 me-2"></i>
            <h5 className="mb-0">{"Tiến độ đồ án"}</h5>
          </div>
          <div className="card-content">
            <canvas id="progressChart"></canvas>
          </div>
          <div className="card-footer text-center text-muted">{"📅 Cập nhật: Hôm nay"}</div>
        </div>
      </div>

      <div className="col-md-4">
        <div className="card-dashboard shadow">
          <div className="card-header d-flex align-items-center">
            <i className="bi bi-lightbulb text-warning fs-4 me-2"></i>
            <h5 className="mb-0">{"Đề xuất đề tài"}</h5>
          </div>
          <div className="card-content text-center">
            <p id="proposalMessage">{"Chưa có đề tài nào được đề xuất."}</p>
            <a href="/student/proposals-list" className="btn btn-primary" id="proposalLink" style={{
                  "display": "none"
                }}>{"Đề xuất ngay"}</a>
          </div>
          <div className="card-footer text-center text-muted">{"📅 Cập nhật: Hôm nay"}</div>
        </div>
      </div>
    </div>

    <div className="row mt-4">

      <div className="col-md-6">
        <div className="card-dashboard shadow">
          <div className="card-header d-flex align-items-center justify-content-between">
            <div className="d-flex align-items-center">
              <i className="bi bi-bell text-danger fs-4 me-2"></i>
              <h5 className="mb-0">{"Thông báo mới"}</h5>
            </div>
            <span className="badge bg-danger" id="unreadNotifications">{"0"}</span>
          </div>
          <div className="card-content">
            <ul className="list-group list-group-flush" id="notificationList"></ul>
            <div className="text-center mt-2" id="viewMoreNotifications" style={{
                  "display": "none"
                }}>
              <a href="/student/notifications-list" className="btn btn-sm btn-primary">{"Xem thêm"}</a>
            </div>
          </div>
          <div className="card-footer text-center text-muted">{"📅 Cập nhật: Hôm nay"}</div>
        </div>
      </div>

      <div className="col-md-6">
        <div className="card-dashboard shadow">
          <div className="card-header d-flex align-items-center">
            <i className="bi bi-calendar text-primary fs-4 me-2"></i>
            <h5 className="mb-0">{"Lịch cá nhân"}</h5>
          </div>
          <div className="card-content">
            <ul className="list-group list-group-flush" id="calendarList"></ul>
          </div>
          <div className="card-footer text-center text-muted">{"📅 Cập nhật: Hôm nay"}</div>
        </div>
      </div>
    </div>

    <h2 className="fw-bold text-primary mt-5">{"📌 Công việc sắp đến hạn"}</h2>
    <div className="table-container">
      <div className="table-header">
        <input type="text" id="taskSearchInput" className="form-control" placeholder={"🔍 Tìm công việc..."} onKeyUp={event => page.invoke("event2", event)} />
        <select id="statusFilter" className="form-select" onChange={event => page.invoke("event3", event)}>
          <option value="">{"📂 Trạng thái"}</option>
          <option value={"Chưa nộp"}>{"Chưa nộp"}</option>
          <option value={"Đã nộp"}>{"Đã nộp"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th>{"Bài tập"}</th>
              <th>{"học phần"}</th>
              <th>{"Hạn chót"}</th>
              <th>{"Thời gian còn lại"}</th>
              <th>{"Trạng thái"}</th>
              <th>{"Hành động"}</th>
            </tr>
          </thead>
          <tbody id="taskTable"></tbody>
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

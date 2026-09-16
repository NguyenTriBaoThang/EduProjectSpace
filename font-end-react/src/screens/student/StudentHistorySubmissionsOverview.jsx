import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentHistorySubmissionsOverview.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/history-submissions-overview");
export default function StudentHistorySubmissionsOverview() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/history-submissions-overview">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list" className="active"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
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
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
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
  <div className="container mt-4">
    <h2 className="fw-bold text-primary" id="submissionTitle">{"📑 Chi tiết bài nộp"}</h2>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Danh sách lịch sử nộp bài"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-file-earmark-text"></i>{" Chi tiết bài nộp\n                    "}</li>
      </ol>
    </nav>
    <div id="submissionDetails" className="card p-4 shadow-sm">
      <h5 className="fw-bold" id="taskName">Đang tải…</h5>
      <p><strong>{"học phần:"}</strong>
        <span id="projectType"></span></p>
      <p><strong>{"Ngày nộp:"}</strong>
        <span id="submissionDate"></span></p>
      <p><strong>{"Trạng thái:"}</strong>
        <span id="submissionStatus"></span></p>
      <p><strong>{"Điểm:"}</strong>
        <span id="submissionScore"></span></p>
      <hr />
      <h6 className="fw-bold">{"📂 Nội dung bài nộp:"}</h6>
      <p id="submissionContent"></p>
      <hr />
      <h6 className="fw-bold">{"📎 File đính kèm:"}</h6>
      <ul className="file-list" id="fileList"></ul>
      <button className="btn btn-outline-primary btn-sm mt-2" onClick={event => page.invoke("event0", event)}>{"Tải tất cả file"}</button>
      <hr />
      <h6 className="fw-bold">{"📝 Nhận xét của giáo viên:"}</h6>
      <div className="teacher-feedback" id="teacherFeedback"></div>
      <hr />
      <div className="d-flex gap-2">
        <button className="btn btn-info" onClick={event => page.invoke("event1", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
        <a href="/student/history-submissions-list" className="btn btn-outline-secondary"><i className="bi bi-arrow-left-circle"></i>{" Quay lại danh sách"}</a>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

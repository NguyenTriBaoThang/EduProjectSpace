import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentProposalsDetail.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/proposals-detail");
export default function StudentProposalsDetail() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/proposals-detail">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
  <a href="/student/proposals-list" className="active"><i className="bi bi-lightbulb"></i>{" Đề xuất đề tài đồ án"}</a>
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
    <h2 className="fw-bold text-primary">{"📋 Xem chi tiết đề tài đồ án"}</h2>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/proposals-list"><i className="bi bi-list-ul"></i>{" Danh sách đề xuất"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-file-earmark-text"></i>{" Chi tiết đề xuất\n                    "}</li>
      </ol>
    </nav>

    <div className="card mt-4" id="proposalDetails">
      <div className="card-header d-flex justify-content-between align-items-center">
        <div>
          <h5 className="text-uppercase" id="proposalTitle">Đang tải…</h5>
          <span id="proposalStatus" className="badge"></span>
        </div>
        <button className="btn btn-info btn-sm" onClick={event => page.invoke("event0", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
      <div className="card-body">
        <h5 className="card-title">{"Thông tin chi tiết đề tài"}</h5>
        <p className="card-text">
          <strong>{"Loại đồ án:"}</strong>
          <span id="proposalType"></span>
          <br />
          <strong>{"Ngày đề xuất:"}</strong>
          <span id="proposalDate"></span>
          <br />
          <strong>{"Người đề xuất:"}</strong>
          <span id="proposer"></span>
          <br />
          <strong>{"Mô tả:"}</strong>
          <span id="proposalDescription"></span>
        </p>

        <div className="alert alert-info" role="alert" id="teacherFeedback">
          <h5 className="alert-heading">{"Gợi ý từ giảng viên:"}</h5>
          <p id="feedbackText"></p>
        </div>
      </div>

      <div className="card-footer text-muted">
        <strong>{"File đính kèm:"}</strong>
        <ul className="file-list" id="fileList"></ul>
        <button className="btn btn-outline-primary btn-sm mt-2" onClick={event => page.invoke("event1", event)}>{"Tải tất cả file"}</button>
      </div>
    </div>

    <div className="mt-4 text-right">
      <a href="/student/proposals-list" className="btn btn-secondary btn-back">
        <i className="bi bi-arrow-left-circle"></i>{" Quay lại danh sách đề tài\n                "}</a>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

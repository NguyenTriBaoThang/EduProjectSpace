import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentGradesDetail.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/grades-detail");
export default function StudentGradesDetail() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/grades-detail">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
  <a href="/student/proposals-list"><i className="bi bi-lightbulb"></i>{" Đề xuất đề tài đồ án"}</a>
  <a href="/student/schedule"><i className="bi bi-calendar"></i>{" Lịch cá nhân"}</a>
  <a href="/student/grades-list" className="active"><i className="bi bi-award"></i>{" Hệ thống chấm điểm"}</a>
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
    <h2 className="fw-bold text-primary" id="subjectTitle">{"📖 Chi tiết điểm số"}</h2>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/grades-list"><i className="bi bi-list-ul"></i>{" Danh sách các môn"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-file-earmark-text"></i>{" Chi tiết điểm số\n                    "}</li>
      </ol>
    </nav>

    <div className="mt-4 text-right d-flex justify-content-end gap-2">
      <button className="btn btn-info" onClick={event => page.invoke("event0", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      <a href="/student/grades-list" className="btn btn-secondary btn-back"><i className="bi bi-arrow-left-circle"></i>{" Quay lại"}</a>
    </div>

    <div className="row mt-4">
      <div className="col-md-4">
        <div className="summary-card avg">
          <h4>{"📊 Điểm trung bình"}</h4>
          <h2 className="fw-bold" id="avgScore">{"0.0"}</h2>
          <p>{"Đánh giá: "}<span className="fw-bold" id="avgEvaluation">{"Chưa có"}</span></p>
        </div>
      </div>
      <div className="col-md-4">
        <div className="summary-card low">
          <h4>{"📉 Điểm thấp nhất"}</h4>
          <h2 className="fw-bold" id="minScore">{"0.0"}</h2>
          <p>{"Bài tập: "}<span className="fw-bold" id="minAssignment">{"-"}</span></p>
        </div>
      </div>
      <div className="col-md-4">
        <div className="summary-card high">
          <h4>{"📈 Điểm cao nhất"}</h4>
          <h2 className="fw-bold" id="maxScore">{"0.0"}</h2>
          <p>{"Bài tập: "}<span className="fw-bold" id="maxAssignment">{"-"}</span></p>
        </div>
      </div>
    </div>

    <div className="table-container mt-4">
      <div className="table-header">
        <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm bài tập..."} onKeyUp={event => page.invoke("event1", event)} />
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th>{"Bài tập"}</th>
              <th>{"Điểm số"}</th>
              <th>{"Đánh giá"}</th>
              <th>{"Gợi ý cải thiện"}</th>
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

    <h4 className="mt-5">{"📊 Biểu đồ điểm số"}</h4>
    <div className="chart-container">
      <canvas id="subjectChart"></canvas>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>


  </div>;
}

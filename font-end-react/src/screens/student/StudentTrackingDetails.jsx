import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentTrackingDetails.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/tracking-details");
export default function StudentTrackingDetails() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/tracking-details">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list" className="active"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
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
    <button className="navbar-toggler toggle-btn" onClick={event => page.invoke("event0", event)}>
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
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary" id="subjectTitle">{"📊 Giai đoạn thực hiện"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event1", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/tracking-list"><i className="bi bi-list-ul"></i>{" Danh sách học phần"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-bar-chart-line"></i>{" Giai đoạn thực hiện\n                    "}</li>
      </ol>
    </nav>
    <div className="row mt-4 mb-4 align-items-center">
      <div className="text-center d-flex flex-column justify-content-center">
        <h5>{"Tiến độ tổng thể"}</h5>
        <div className="progress w-100" style={{
              "height": "30px"
            }} id="overallProgress">
          <div className="progress-bar bg-success" id="progressBar"></div>
        </div>
      </div>
    </div>
    <div className="table-container">

      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm bài tập..."} onKeyUp={event => page.invoke("event2", event)} />
        <select id="statusFilter" className="form-select" onChange={event => page.invoke("event3", event)}>
          <option value="">{"📂 Trạng thái"}</option>
          <option value={"Hoàn thành"}>{"Hoàn thành"}</option>
          <option value={"Đang thực hiện"}>{"Đang thực hiện"}</option>
          <option value={"Chưa hoàn thành"}>{"Chưa hoàn thành"}</option>
        </select>
      </div>

      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event4", event)}>{"Bài tập "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Ngày bắt đầu "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Hạn hoàn thành "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Trạng thái "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"Ghi chú"}</th>
            </tr>
          </thead>
          <tbody id="tableBody"></tbody>
        </table>
      </div>

      <div className="table-footer">
        <ul id="pagination" className="pagination"></ul>
      </div>
    </div>
    <div className="row mt-4 align-items-center">
      <div className="text-center">
        <div className="chart-container mb-4">
          <canvas id="progressChart"></canvas>
        </div>
        <h5>{"Biểu đồ tiến độ"}</h5>
      </div>
    </div>
    <div className="mt-4 mb-4 text-right">
      <a href="/student/tracking-list" className="btn btn-secondary btn-back">
        <i className="bi bi-arrow-left-circle"></i>{" Danh sách học phần\n                "}</a>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

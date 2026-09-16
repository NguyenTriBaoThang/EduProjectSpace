import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentSubmissions.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/submissions");
export default function StudentSubmissions() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/submissions">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list" className="active"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
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
      <h2 className="fw-bold text-primary" id="taskTitle">Đang tải…</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event1", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/submissions-list"><i className="bi bi-list-ul"></i>{" Danh sách học phần"}</a>
        </li>
        <li className="breadcrumb-item" id="subjectBreadcrumb">
          <a href="/student/submissions-week"><i className="bi bi-file-earmark-text"></i>{" Danh sách bài tập"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-journal-check"></i>
          <span id="taskBreadcrumb"></span>
        </li>
      </ol>
    </nav>
    <div className="row">
      <div className="col-md-8">
        <div className="card p-4 shadow-sm card-custom">
          <h3 className="fw-bold" id="taskName"><i className="bi bi-journal-check"></i>
          </h3>
          <p className="text-muted" id="taskInfo"></p>
          <span className="due-date" id="taskDeadline"></span>
          <h5 className="fw-bold text-primary" id="taskPoints">Đang tải…</h5>
          <hr />
          <p className="text-muted">{"Lưu ý: Nộp bài đúng thời gian."}</p>
          <hr />
          <div className="mb-3">
            <h6 className="fw-bold"><i className="bi bi-chat-left-text"></i>{" Nhận xét của lớp học"}</h6>
            <div id="classCommentText" className="comment-box" onClick={event => page.invoke("event2", event)}>{"\n                                Thêm nhận xét về lớp học...\n                            "}</div>
            <div id="classComment" className="comment-input" style={{
                  "display": "none"
                }}>
              <input type="text" placeholder={"Thêm nhận xét trong lớp học..."} />
              <button onClick={event => page.invoke("event3", event)}><i className="bi bi-send"></i></button>
            </div>
            <div id="classCommentList" className="comment-list"></div>
          </div>
        </div>
      </div>
      <div className="col-md-4">
        <div className="submission-container mb-3" id="submissionSection">
          <h6 className="fw-bold">{"Bài tập của bạn "}<span id="submissionStatus" className="text-warning"></span></h6>
          <div className="add-button" onClick={event => page.invoke("event4", event)}>
            <i className="bi bi-plus-circle"></i>{" Thêm hoặc tạo\n                        "}</div>
          <input type="file" id="fileInput" className="form-control mb-2" style={{
                "display": "none"
              }} multiple={true} />
          <div id="fileList"></div>
          <button id="submitButton" className="btn btn-primary w-100 btn-custom mt-2" onClick={event => page.invoke("event5", event)}>{"Nộp bài"}</button>
        </div>
        <div className="card p-3 shadow-sm card-custom">
          <h6 className="fw-bold"><i className="bi bi-person"></i>{" Nhận xét riêng tư"}</h6>
          <div id="privateCommentText" className="comment-box" onClick={event => page.invoke("event6", event)}>{"\n                            Thêm nhận xét riêng tư...\n                        "}</div>
          <div id="privateComment" className="comment-input" style={{
                "display": "none"
              }}>
            <input type="text" placeholder={"Thêm nhận xét riêng tư..."} />
            <button onClick={event => page.invoke("event7", event)}><i className="bi bi-send"></i></button>
          </div>
          <div id="privateCommentList" className="comment-list"></div>
        </div>
        <div className="mt-4 mb-4 text-right">
          <a href="/student/submissions-week" className="btn btn-secondary btn-back" id="backLink">
            <i className="bi bi-arrow-left-circle"></i>{" Danh sách Bài tập\n                        "}</a>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadGroupDetails.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/group-details");
export default function HeadGroupDetails() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/group-details">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign" className="active"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
    <a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
    <a href="/head/grading-courses"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a>
    <a href="/head/defense-list"><i className="bi bi-calendar"></i>{" Quản lý lịch bảo vệ"}</a>
  </div>
    </div>


    <div className="content">

  <nav className="navbar navbar-expand-lg px-3 bg-primary text-white">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <button className="navbar-toggler toggle-btn" onClick={event => page.invoke("event0", event)}>
      <i className="bi bi-list text-white"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <button id="toggleFullscreen" className="btn btn-outline-light mx-2"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn btn-outline-light mx-2"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn btn-outline-light mx-2"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn btn-outline-light"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>

  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Lecturer Avatar" />
      <h6 id="headName">{"Head HUTECH"}</h6>
      <p id="headEmail">{"head@hutech.edu.vn"}</p>
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
      <h2 className="fw-bold text-primary">{"👥 Chi tiết nhóm và đồ án"}</h2>
      <button className="btn btn-primary" onClick={event => page.invoke("event2", event)}><i className="bi bi-file-earmark-excel"></i>{" Xuất Excel"}</button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/lecturer-assign"><i className="bi bi-person-plus"></i>{" Danh sách GVHD"}</a></li>
        <li className="breadcrumb-item"><button id="backToLecturerLink" type="button" className="link-button"><i className="bi bi-folder"></i>{" Chi tiết GVHD"}</button></li>
        <li className="breadcrumb-item active"><i className="bi bi-file-earmark-text"></i>{" Chi tiết nhóm và đồ án"}</li>
      </ol>
    </nav>

    <div className="lecturer-info">
      <h6 className="text-primary"><i className="bi bi-person-circle"></i>{" Giảng viên hướng dẫn"}</h6>
      <p><strong>{"Tên GVHD:"}</strong>
        <span id="lecturerName"></span></p>
      <p><strong>{"Học phần:"}</strong>
        <span id="courseInfo"></span></p>
    </div>

    <div className="group-details-container">
      <div className="vertical-divider"></div>
      <div className="row">

        <div className="col-md-6">
          <h5><i className="bi bi-people"></i>{" Thông tin nhóm"}</h5>
          <div className="info-item">
            <i className="bi bi-tag"></i>
            <div>
              <strong>{"Tên nhóm:"}</strong>
              <span id="groupName"></span>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-person-lines-fill"></i>
            <div>
              <strong>{"Thành viên:"}</strong>
              <ul id="membersList" className="members-list list-group"></ul>
            </div>
          </div>
        </div>

        <div className="col-md-6">
          <h5><i className="bi bi-file-earmark-text"></i>{" Chi tiết đồ án"}</h5>
          <div className="info-item">
            <i className="bi bi-book"></i>
            <div>
              <strong>{"Tên đồ án:"}</strong>
              <span id="projectName"></span>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-calendar-event"></i>
            <div>
              <strong>{"Thời gian bắt đầu:"}</strong>
              <span id="startDate"></span>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-calendar-check"></i>
            <div>
              <strong>{"Thời gian kết thúc:"}</strong>
              <span id="endDate"></span>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-award"></i>
            <div>
              <strong>{"Thời gian chấm:"}</strong>
              <span id="gradingDate"></span>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-card-text"></i>
            <div>
              <strong>{"Mô tả đề tài:"}</strong>
              <p id="description" className="mt-1"></p>
            </div>
          </div>
          <div className="info-item">
            <i className="bi bi-files"></i>
            <div>
              <strong>{"File mô tả đề tài:"}</strong>
              <ul id="fileList" className="file-list mt-1"></ul>
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

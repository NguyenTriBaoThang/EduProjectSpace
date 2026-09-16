import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerFeedbackDetail.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/feedback-detail");
export default function LecturerFeedbackDetail() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/feedback-detail">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback" className="active"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
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
      <h2 className="fw-bold text-primary">{"💬 Chi tiết phản hồi"}</h2>
      <div>
        <button className="btn btn-info me-2" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
        <button className="btn btn-secondary" onClick={event => page.invoke("event3", event)}>{"Quay lại"}</button>
      </div>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Danh sách môn cần phản hồi"}</a></li>
        <li className="breadcrumb-item"><button id="backLink" type="button" className="link-button"><i className="bi bi-folder"></i>{" Nhận xét & phản hồi"}</button></li>
        <li className="breadcrumb-item active"><i className="bi bi-eye"></i>{" Chi tiết phản hồi"}</li>
      </ol>
    </nav>

    <div className="card-dashboard mb-4">
      <div className="card-header">
        <h5>{"Thông tin đồ án"}</h5>
      </div>
      <div className="card-content">
        <p><strong>{"Mã đồ án:"}</strong>
          <span id="projectId"></span></p>
        <p><strong>{"Tên đồ án:"}</strong>
          <span id="projectName"></span></p>
        <p><strong>{"Tên nhóm:"}</strong>
          <span id="groupName"></span></p>
        <p><strong>{"Nhóm trưởng:"}</strong>
          <span id="groupLeader"></span></p>
        <p><strong>{"Thành viên:"}</strong>
          <span id="groupMembers"></span></p>
        <p><strong>{"Trạng thái:"}</strong>
          <span id="projectStatus"></span></p>
      </div>
    </div>

    <div className="table-container">
      <div className="table-content">
        <div id="taskSubmissionGroups"></div>
      </div>
    </div>

    <div className="mt-4 text-end">
      <button className="btn btn-primary" onClick={event => page.invoke("event4", event)}>{"Gửi phản hồi"}</button>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

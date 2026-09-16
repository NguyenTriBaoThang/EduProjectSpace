import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadProgressDetails.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/progress-details");
export default function HeadProgressDetails() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/progress-details">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
    <a href="/head/progress-courses" className="active"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
    <a href="/head/grading-courses"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a>
    <a href="/head/defense-list"><i className="bi bi-calendar"></i>{" Quản lý lịch bảo vệ"}</a>
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
      <h2 className="fw-bold text-primary">{"⏳ Chi tiết tiến độ đồ án"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a></li>
        <li className="breadcrumb-item"><button id="backToProgressLink" type="button" className="link-button"><i className="bi bi-folder"></i>{" Chi tiết tiến độ"}</button></li>
        <li className="breadcrumb-item active"><i className="bi bi-file-earmark-text"></i>{" Tiến độ đồ án"}</li>
      </ol>
    </nav>

    <div className="card mb-4">
      <div className="card-header">
        <h5>{"Thông tin nhóm và đồ án"}</h5>
      </div>
      <div className="card-body">
        <p><strong>{"Tên nhóm:"}</strong>
          <span id="groupName"></span></p>
        <p><strong>{"Mã đồ án:"}</strong>
          <span id="projectId"></span></p>
        <p><strong>{"Tên đồ án:"}</strong>
          <span id="projectName"></span></p>
        <p><strong>{"Thành viên:"}</strong>
          <span id="members"></span></p>
        <p><strong>{"Giảng viên hướng dẫn:"}</strong>
          <span id="lecturer"></span></p>
        <p><strong>{"Trạng thái:"}</strong>
          <span id="status"></span></p>
      </div>
    </div>

    <div className="table-container">
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th>{"Giai đoạn"}</th>
              <th>{"Mô tả"}</th>
              <th>{"Tệp báo cáo"}</th>
              <th>{"Ngày nộp"}</th>
              <th>{"Hạn nộp"}</th>
            </tr>
          </thead>
          <tbody id="progressTableBody"></tbody>
        </table>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

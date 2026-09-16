import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadCourseAssign.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/course-assign");
export default function HeadCourseAssign() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/course-assign">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign" className="active"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
    <a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
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
      <input type="text" className="search-box me-3" id="searchInput" placeholder={"🔍 Tìm kiếm..."} onKeyUp={event => page.invoke("event1", event)} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>
  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Avatar" />
      <h6 id="headName">{"Head HUTECH"}</h6>
      <p id="headEmail">{"head@hutech.edu.vn"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>
  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"👩‍🏫 Danh sách học phần cần phân công GVHD"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event3", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item active"><i className="bi bi-person-plus"></i>{" Danh sách môn cần phân công"}</li>
      </ol>
    </nav>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm học phần..."} onKeyUp={event => page.invoke("event4", event)} />
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Mã học phần "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Tên học phần "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Học kỳ "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Mã khoa "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Số sinh viên "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event10", event)}>{"Số SV đã phân công "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event11", event)}>{"Số SV chưa phân công "}<i className="bi bi-arrow-down-up"></i></th>
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
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền HUTECH – Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

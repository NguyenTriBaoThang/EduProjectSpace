import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadGradingDetails.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/grading-details");
export default function HeadGradingDetails() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/grading-details">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/head/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
    <a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
    <a href="/head/grading-courses" className="active"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a>
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
      <h2 className="fw-bold text-primary">{"🏆 Chi tiết duyệt chấm điểm"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/head/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/grading-courses"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a></li>
        <li className="breadcrumb-item"><button id="backToGradingLink" type="button" className="link-button"><i className="bi bi-folder"></i>{" Chi tiết chấm điểm"}</button></li>
        <li className="breadcrumb-item active"><i className="bi bi-file-earmark-text"></i>{" Chi tiết duyệt điểm"}</li>
      </ol>
    </nav>
    <div className="card">
      <div className="card-header">
        <h5 className="mb-0">{"Thông tin nhóm và đồ án"}</h5>
      </div>
      <div className="card-body">
        <div className="row">
          <div className="col-md-5 info-section">
            <form id="gradeForm">
              <input type="hidden" id="gradeGroupId" />
              <div className="mb-3">
                <label className="form-label">{"Tên nhóm"}</label>
                <input type="text" id="gradeGroupName" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Mã đồ án"}</label>
                <input type="text" id="gradeProjectId" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Tên đồ án"}</label>
                <input type="text" id="gradeProjectName" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Thành viên"}</label>
                <input type="text" id="gradeMembers" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Giảng viên hướng dẫn"}</label>
                <input type="text" id="gradeLecturer" className="form-control" readOnly={true} />
              </div>
            </form>
          </div>
          <div className="col-md-7 grade-section">
            <form id="gradeFormDetails">
              <div className="mb-3">
                <label className="form-label">{"Tệp báo cáo cuối kỳ"}</label>
                <ul id="reportFiles" className="file-list"></ul>
              </div>
              <div className="mb-3">
                <label className="form-label">{"Trạng thái duyệt"}</label>
                <select id="gradeApproval" className="form-select" required={true}>
                  <option value={"Chưa duyệt"}>{"Chưa duyệt"}</option>
                  <option value={"Đã duyệt"}>{"Đã duyệt"}</option>
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">{"Nhận xét từ hội đồng"}</label>
                <textarea id="councilFeedback" className="form-control" rows="4" placeholder={"Nhập nhận xét từ hội đồng"}></textarea>
              </div>
              <div className="mb-3">
                <label className="form-label">{"Điểm từng thành viên"}</label>
                <table className="member-table">
                  <thead>
                    <tr>
                      <th>{"Thành viên"}</th>
                      <th>{"Điểm tổng"}</th>
                      <th>{"Phản hồi"}</th>
                    </tr>
                  </thead>
                  <tbody id="memberGrades"></tbody>
                </table>
              </div>
              <button type="button" className="btn btn-primary" onClick={event => page.invoke("event3", event)}>{"Lưu"}</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div className="toast-container">
    <div id="toast" className="toast" role="alert" data-bs-autohide="true" data-bs-delay="3000">
      <div className="toast-body"></div>
    </div>
  </div>

  <div className="modal fade" id="codeModal" tabIndex="-1" aria-labelledby="codeModalLabel" aria-hidden="true">
    <div className="modal-dialog modal-xl">
      <div className="modal-content">
        <div className="modal-header">
          <h5 className="modal-title" id="codeModalLabel">{"Xem mã nguồn hoặc tệp"}</h5>
          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div className="modal-body">
          <div id="modalContent"></div>
        </div>
        <div className="modal-footer">
          <button id="downloadCodeLink" className="btn btn-info link-button" type="button"><i className="bi bi-download"></i>{" Tải xuống"}</button>
          <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Đóng"}</button>
        </div>
      </div>
    </div>
  </div>
  <div className="footer">{"\n            Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n        "}</div>


    </div>
  </div>;
}

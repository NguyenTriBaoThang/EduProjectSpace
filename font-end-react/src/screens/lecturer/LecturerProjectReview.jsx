import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerProjectReview.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/project-review");
export default function LecturerProjectReview() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/project-review">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
    <a href="/lecturer/course-resources"><i className="bi bi-book"></i>{" Gợi ý tài liệu"}</a>
    <a href="/lecturer/course-reviews" className="active"><i className="bi bi-star"></i>{" Đánh giá tổng quan"}</a>
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
      <h2 className="fw-bold text">{"⭐ Chi tiết đánh giá đồ án"}</h2>
      <button className="btn btn-secondary" onClick={event => page.invoke("event2", event)}>{"Quay lại"}</button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/lecturer/course-reviews"><i className="bi bi-star"></i>{" Danh sách môn cần đánh giá"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-folder"></i>{" Chi tiết đánh giá"}</li>
      </ol>
    </nav>

    <div className="card">
      <div className="card-header">
        <h4>{"Thông tin đồ án"}</h4>
      </div>
      <div className="card-body">
        <div className="row">
          <div className="col-md-6">
            <div className="mb-3">
              <label className="form-label">{"Mã đồ án"}</label>
              <input type="text" id="projectCode" className="form-control" readOnly={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Tên đồ án"}</label>
              <input type="text" id="projectName" className="form-control" readOnly={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Tên nhóm"}</label>
              <input type="text" id="groupName" className="form-control" readOnly={true} />
            </div>
          </div>
          <div className="col-md-6">
            <div className="mb-3">
              <label className="form-label">{"Nhóm trưởng"}</label>
              <input type="text" id="groupLeader" className="form-control" readOnly={true} />
            </div>
            <div className="mb-3">
              <label className="form-label">{"Thành viên"}</label>
              <input type="text" id="groupMembers" className="form-control" readOnly={true} />
            </div>
          </div>
        </div>
      </div>
    </div>

    <div className="card mt-4">
      <div className="card-header">
        <h4>{"Điểm từng sinh viên"}</h4>
      </div>
      <div className="card-body">
        <table className="table-custom table-bordered criteria-table">
          <thead>
            <tr>
              <th>{"Sinh viên"}</th>
              <th>{"Tiêu chí"}</th>
              <th>{"Trọng số"}</th>
              <th>{"Điểm (0-10)"}</th>
              <th>{"Điểm tổng"}</th>
              <th>{"Trạng thái"}</th>
            </tr>
          </thead>
          <tbody id="criteriaTable"></tbody>
        </table>
      </div>
    </div>

    <div className="card mt-4">
      <div className="card-header">
        <h4>{"Tiến độ đồ án"}</h4>
      </div>
      <div className="card-body">
        <table className="table-custom table-bordered">
          <thead>
            <tr>
              <th>{"Giai đoạn"}</th>
              <th>{"Mô tả"}</th>
              <th>{"Tệp báo cáo"}</th>
              <th>{"Hạn nộp"}</th>
              <th>{"Phản hồi"}</th>
            </tr>
          </thead>
          <tbody id="progressTable"></tbody>
        </table>
      </div>
    </div>

    <div className="card mt-4">
      <div className="card-header">
        <h4>{"Lịch sử đánh giá"}</h4>
      </div>
      <div className="card-body">
        <div id="reviewHistory" className="form-text"></div>
      </div>
    </div>

    <div className="d-flex justify-content-end mt-4">
      <button type="button" className="btn btn-primary" onClick={event => page.invoke("event3", event)}>{"Lưu"}</button>
      <button type="button" className="btn btn-info ms-2" onClick={event => page.invoke("event4", event)}>{"Đánh giá"}</button>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

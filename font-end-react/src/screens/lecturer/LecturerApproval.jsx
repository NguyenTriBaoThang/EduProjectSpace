import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerApproval.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/approval");
export default function LecturerApproval() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/approval">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals" className="active"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
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
      <h2 className="fw-bold text-primary">{"✅ Duyệt đề tài đồ án"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</li>
      </ol>
    </nav>

    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm đề tài..."} onKeyUp={event => page.invoke("event3", event)} />
        <select id="statusFilter" className="form-select" onChange={event => page.invoke("event4", event)}>
          <option value="">{"📂 Trạng thái duyệt"}</option>
          <option value="PENDING">{"Chưa duyệt"}</option>
          <option value="APPROVED">{"Đã duyệt"}</option>
          <option value="REJECTED">{"Từ chối"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Mã đề tài "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Tên đề tài "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Tên nhóm "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Thành viên "}<i className="bi bi-arrow-down-up"></i></th>
              <th>{"File mô tả"}</th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Trạng thái duyệt "}<i className="bi bi-arrow-down-up"></i></th>
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


    <div className="modal fade" id="descriptionModal" tabIndex="-1" aria-labelledby="descriptionModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="descriptionModalLabel">{"Chi tiết mô tả"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <p id="modalDescription"></p>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Đóng"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="approvalModal" tabIndex="-1" aria-labelledby="approvalModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="approvalModalLabel">{"Duyệt đề tài"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="approvalForm">
          <input type="hidden" id="approvalProjectId" />
          <div className="mb-3">
            <label className="form-label">{"Mã đề tài"}</label>
            <input type="text" id="approvalProjectCode" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tên đề tài"}</label>
            <input type="text" id="approvalProjectName" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tên nhóm"}</label>
            <input type="text" id="approvalGroupName" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Thành viên"}</label>
            <input type="text" id="approvalMembers" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"File mô tả"}</label>
            <ul id="approvalFiles" className="file-list"></ul>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Mô tả"}</label>
            <textarea id="approvalDescription" className="form-control" rows="3" readOnly={true}></textarea>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Trạng thái duyệt"}</label>
            <select id="approvalStatus" className="form-select" required={true}>
              <option value="PENDING">{"Chưa duyệt"}</option>
              <option value="APPROVED">{"Đã duyệt"}</option>
              <option value="REJECTED">{"Từ chối"}</option>
            </select>
          </div>
          <div className="mb-3" id="reasonField" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Lý do từ chối"}</label>
            <textarea id="approvalReason" className="form-control" rows="3"></textarea>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event10", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

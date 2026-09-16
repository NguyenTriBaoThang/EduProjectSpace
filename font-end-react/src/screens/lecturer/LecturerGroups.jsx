import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerGroups.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/groups");
export default function LecturerGroups() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/groups">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
    <a href="/lecturer/course-feedback"><i className="bi bi-chat-left-text"></i>{" Nhận xét & phản hồi"}</a>
    <a href="/lecturer/course-resources"><i className="bi bi-book"></i>{" Gợi ý tài liệu"}</a>
    <a href="/lecturer/course-reviews"><i className="bi bi-star"></i>{" Đánh giá tổng quan"}</a>
    <a href="/lecturer/course-groups" className="active"><i className="bi bi-people"></i>{" Chia nhóm sinh viên"}</a>
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
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} onKeyUp={event => page.invoke("event1", event)} />
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>

  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"👥 Chia nhóm sinh viên"}</h2>
      <div>
        <button className="btn btn-success me-2" onClick={event => page.invoke("event3", event)}>{"Chia tự động"}</button>
        <button className="btn btn-warning me-2" data-bs-toggle="modal" data-bs-target="#addGroupModal">{"Thêm nhóm"}</button>
        <input type="file" id="importExcel" accept=".xlsx" className="d-none" onChange={event => page.invoke("event4", event)} />
        <button className="btn btn-primary me-2" onClick={event => page.invoke("event5", event)}>{"Nhập từ Excel"}</button>
        <button className="btn btn-info" onClick={event => page.invoke("event6", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/lecturer/course-groups"><i className="bi bi-people"></i>{" Danh sách môn cần chia nhóm"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-folder"></i>{" Chia nhóm sinh viên"}</li>
      </ol>
    </nav>

    <div className="mb-4">
      <label className="form-label fw-bold">{"Số lượng tối đa mỗi nhóm:"}</label>
      <input type="number" id="groupSize" className="form-control w-25 d-inline-block" min="1" defaultValue="3" onChange={event => page.invoke("event7", event)} />
    </div>

    <div className="row">

      <div className="col-md-6">
        <div className="card-dashboard">
          <div className="card-header">
            <h5>{"Danh sách sinh viên chưa chia nhóm"}</h5>
          </div>
          <div className="card-content">
            <ul id="studentList" className="list-group"></ul>
          </div>
        </div>
      </div>

      <div className="col-md-6">
        <div className="card-dashboard">
          <div className="card-header">
            <h5>{"Danh sách nhóm"}</h5>
          </div>
          <div className="card-content">
            <div id="groupList"></div>
          </div>
        </div>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="addGroupModal" tabIndex="-1" aria-labelledby="addGroupModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addGroupModalLabel">{"Thêm nhóm mới"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addGroupForm">
          <div className="mb-3">
            <label className="form-label">{"Tên nhóm"}</label>
            <input type="text" id="newGroupName" className="form-control" required={true} />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event8", event)}>{"Thêm"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="editGroupModal" tabIndex="-1" aria-labelledby="editGroupModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editGroupModalLabel">{"Chỉnh sửa tên nhóm"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editGroupForm">
          <input type="hidden" id="editGroupId" />
          <div className="mb-3">
            <label className="form-label">{"Tên nhóm mới"}</label>
            <input type="text" id="editGroupName" className="form-control" required={true} />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event9", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerProjectProgress.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/project-progress");
export default function LecturerProjectProgress() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/project-progress">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses" className="active"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
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
      <h2 className="fw-bold text-primary">{"📈 Chi tiết tiến độ đồ án"}</h2>
      <div>
        <button className="btn btn-info me-2" onClick={event => page.invoke("event2", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
        <button className="btn btn-secondary" onClick={event => page.invoke("event3", event)}>{"Quay lại"}</button>
      </div>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/projects"><i className="bi bi-folder"></i>{" Quản lý đồ án"}</a></li>
        <li className="breadcrumb-item active"><i className="bi bi-eye"></i>{" Chi tiết tiến độ"}</li>
      </ol>
    </nav>

    <div className="card mb-4">
      <div className="card-header">
        <h5>{"Thông tin đồ án"}</h5>
      </div>
      <div className="card-body">
        <p><strong>{"Mã đồ án:"}</strong>
          <span id="projectId"></span></p>
        <p><strong>{"Tên đồ án:"}</strong>
          <span id="projectName"></span></p>
        <p><strong>{"Nhóm:"}</strong>
          <span id="groupName"></span></p>
        <p><strong>{"Nhóm trưởng:"}</strong>
          <span id="groupLeader"></span></p>
        <p><strong>{"Thành viên:"}</strong>
          <span id="groupMembers"></span></p>
      </div>
    </div>

    <div className="table-container">
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th>{"Nhiệm vụ"}</th>
              <th>{"Mô tả"}</th>
              <th>{"Tệp báo cáo"}</th>
              <th>{"Hạn nộp"}</th>
              <th>{"Phản hồi"}</th>
              <th>{"Hành động"}</th>
            </tr>
          </thead>
          <tbody id="tasksTable"></tbody>
        </table>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="feedbackModal" tabIndex="-1" aria-labelledby="feedbackModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="feedbackModalLabel">{"Cập nhật phản hồi"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="feedbackForm">
          <input type="hidden" id="feedbackProjectId" />
          <input type="hidden" id="feedbackTaskId" />
          <div className="mb-3">
            <label className="form-label">{"Nhiệm vụ"}</label>
            <input type="text" id="feedbackTaskTitle" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Phản hồi"}</label>
            <textarea id="feedbackComment" className="form-control" rows="3" required={true}></textarea>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event4", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="editTaskModal" tabIndex="-1" aria-labelledby="editTaskModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editTaskModalLabel">{"Chỉnh sửa nhiệm vụ"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editTaskForm">
          <input type="hidden" id="editProjectId" />
          <input type="hidden" id="editTaskId" />
          <div className="mb-3">
            <label className="form-label">{"Nhiệm vụ"}</label>
            <input type="text" id="editTaskTitle" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Mô tả"}</label>
            <textarea id="editDescription" className="form-control" rows="2" required={true}></textarea>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Hạn nộp"}</label>
            <input type="date" id="editDueDate" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Trạng thái"}</label>
            <select id="editStatus" className="form-select" required={true}>
              <option value="Todo">{"Todo"}</option>
              <option value="InProgress">{"Đang tiến hành"}</option>
              <option value="Done">{"Hoàn thành"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tệp báo cáo"}</label>
            <div id="submissionList" className="submission-list"></div>
            <button type="button" className="btn btn-sm btn-success mt-2" onClick={event => page.invoke("event5", event)}>{"Thêm tệp"}</button>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event6", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

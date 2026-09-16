import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./LecturerTasks.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/lecturer/tasks");
export default function LecturerTasks() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/lecturer/tasks">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Giảng viên hướng dẫn"}</h4>
  <a href="/lecturer/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/lecturer/courses"><i className="bi bi-book"></i>{" Đồ án học phần"}</a>
    <a href="/lecturer/course-approvals"><i className="bi bi-check-circle"></i>{" Duyệt đề tài"}</a>
    <a href="/lecturer/tasks" className="active"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</a>
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
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} onKeyUp={event => page.invoke("event1", event)} />
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
      <button className="logout link-button" onClick={event => page.invoke("event2", event)} type="button"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</button>
    </div>
  </div>

  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold text-primary">{"📋 Quản lý công việc theo học kỳ"}</h2>
      <div>
        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#addTaskModal">{"Thêm công việc "}<i className="bi bi-plus-circle"></i></button>
        <button className="btn btn-info" onClick={event => page.invoke("event3", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/lecturer/dashboard"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item active"><i className="bi bi-list-task"></i>{" Quản lý công việc"}</li>
      </ol>
    </nav>

    <div className="table-header d-flex gap-2 mb-4">
      <select id="courseFilter" className="form-select" onChange={event => page.invoke("event4", event)}>
        <option value="">{"Tất cả học phần"}</option>
      </select>
      <select id="projectFilter" className="form-select" onChange={event => page.invoke("event5", event)}>
        <option value="">{"Tất cả đồ án"}</option>
      </select>
      <select id="semesterFilter" className="form-select" onChange={event => page.invoke("event6", event)}>
        <option value="">{"Tất cả học kỳ"}</option>
      </select>
      <select id="statusFilter" className="form-select" onChange={event => page.invoke("event7", event)}>
        <option value="">{"Tất cả trạng thái"}</option>
        <option value={"Chưa hoàn thành"}>{"Chưa hoàn thành"}</option>
        <option value={"Đã hoàn thành"}>{"Đã hoàn thành"}</option>
        <option value={"Quá hạn"}>{"Quá hạn"}</option>
      </select>
    </div>

    <div className="table-container">
      <div className="table-content">
        <div className="accordion" id="tasksAccordion"></div>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="addTaskModal" tabIndex="-1" aria-labelledby="addTaskModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addTaskModalLabel">{"Thêm công việc"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addTaskForm">
          <div className="mb-3">
            <label className="form-label">{"Học phần"}</label>
            <select id="taskCourseId" className="form-select" required={true} onChange={event => page.invoke("event8", event)}>
              <option value="">{"Chọn học phần"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Mã đồ án"}</label>
            <select id="taskProjectId" className="form-select" required={true}>
              <option value="">{"Chọn đồ án"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Công việc"}</label>
            <input type="text" id="taskDescription" className="form-control" required={true} placeholder={"Nhập mô tả công việc"} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Thời gian bắt đầu"}</label>
            <input type="date" id="taskStartDate" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Thời gian hết hạn"}</label>
            <input type="date" id="taskDueDate" className="form-control" required={true} />
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event9", event)}>{"Thêm"}</button>
      </div>
    </div>
  </div>
    </div>


    <div className="modal fade" id="editTaskModal" tabIndex="-1" aria-labelledby="editTaskModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editTaskModalLabel">{"Sửa công việc"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editTaskForm">
          <input type="hidden" id="editTaskId" />
          <div className="mb-3">
            <label className="form-label">{"Mã đồ án"}</label>
            <input type="text" id="editTaskProjectId" className="form-control" readOnly={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Công việc"}</label>
            <input type="text" id="editTaskDescription" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Thời gian bắt đầu"}</label>
            <input type="date" id="editTaskStartDate" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Thời gian hết hạn"}</label>
            <input type="date" id="editTaskDueDate" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Trạng thái"}</label>
            <select id="editTaskStatus" className="form-select" required={true}>
              <option value={"Chưa hoàn thành"}>{"Chưa hoàn thành"}</option>
              <option value={"Đã hoàn thành"}>{"Đã hoàn thành"}</option>
            </select>
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

import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./StudentProposalsCreate.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/student/proposals-create");
export default function StudentProposalsCreate() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/student/proposals-create">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Sinh viên"}</h4>
  <a href="/student/dashboard"><i className="bi bi-house-door"></i>{" Trang chủ"}</a>
  <a href="/student/submissions-list"><i className="bi bi-upload"></i>{" Nộp bài tập đồ án"}</a>
  <a href="/student/tracking-list"><i className="bi bi-bar-chart-line"></i>{" Theo dõi tiến độ đồ án"}</a>
  <a href="/student/history-submissions-list"><i className="bi bi-clock-history"></i>{" Xem lịch sử nộp bài"}</a>
  <a href="/student/proposals-list" className="active"><i className="bi bi-lightbulb"></i>{" Đề xuất đề tài đồ án"}</a>
  <a href="/student/schedule"><i className="bi bi-calendar"></i>{" Lịch cá nhân"}</a>
  <a href="/student/grades-list"><i className="bi bi-award"></i>{" Hệ thống chấm điểm"}</a>
    </div>


    <div className="content">

  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <div className="ms-auto d-flex align-items-center">
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>

  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/student/img/avatar.jpg" alt="User Avatar" />
      <h6>{"Nguyễn Tri Bão Thắng"}</h6>
      <p>{"nguyentribaothang@gmail.com"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <a href="/login" className="logout"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</a>
    </div>
  </div>

  <div className="container mt-4">
    <h2 className="fw-bold text-primary">{"💡 Đề xuất đề tài đồ án"}</h2>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/student/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item">
          <a href="/student/proposals-list"><i className="bi bi-list-ul"></i>{" Danh sách đề xuất"}</a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-lightbulb"></i>{" Đề xuất đề tài\n                    "}</li>
      </ol>
    </nav>
    <form id="proposalForm" className="mt-4" onSubmit={event => page.invoke("event0", event)}>
      <div className="mb-3">
        <label className="form-label">{"học phần"}</label>
        <select id="subject" className="form-select" name="subject" required={true}>
          <option value="">{"-- Chọn học phần --"}</option>
          <option value={"Kỹ thuật lập trình"}>{"Kỹ thuật lập trình"}</option>
          <option value={"Đồ án chuyên ngành"}>{"Đồ án chuyên ngành"}</option>
          <option value={"Đồ án cơ sở"}>{"Đồ án cơ sở"}</option>
        </select>
      </div>
      <div className="mb-3">
        <label className="form-label">{"Tên đề tài"}</label>
        <input type="text" id="title" className="form-control" name="title" placeholder={"Nhập tên đề tài"} required={true} />
      </div>
      <div className="mb-3">
        <label className="form-label">{"Mô tả ngắn"}</label>
        <textarea id="description" className="form-control" name="description" rows="3" placeholder={"Mô tả ngắn về đề tài"} required={true}></textarea>
      </div>
      <div className="mb-3">
        <label className="form-label">{"Công nghệ sử dụng"}</label>
        <input type="text" id="technology" className="form-control" name="technology" placeholder={"Ví dụ: Java, Spring Boot, Flutter..."} required={true} />
      </div>
      <div className="mb-3">
        <label className="form-label">{"File đính kèm (nếu có)"}</label>
        <input type="file" id="attachment" className="form-control" name="attachment" onChange={event => page.invoke("event1", event)} />
        <small id="fileName" className="form-text text-muted"></small>
      </div>
      <div className="text-center d-flex justify-content-center gap-2">
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event2", event)}>{"Gửi đề xuất"}</button>
        <a href="/student/proposals-list" className="btn btn-secondary btn-back"><i className="bi bi-arrow-left-circle"></i>{" Quay lại danh sách"}</a>
      </div>
    </form>
  </div>

  <div className="modal fade" id="confirmationModal" tabIndex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
    <div className="modal-dialog">
      <div className="modal-content">
        <div className="modal-header">
          <h5 className="modal-title" id="confirmationModalLabel">{"Xác nhận đề xuất"}</h5>
          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div className="modal-body">
          <p>{"Bạn đã chắc chắn muốn gửi đề xuất chưa? Hãy xem kỹ thông tin trước khi gửi."}</p>
        </div>
        <div className="modal-footer">
          <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
          <button type="button" className="btn btn-primary" onClick={event => page.invoke("event3", event)}>{"Xác nhận"}</button>
        </div>
      </div>
    </div>
  </div>

  <div className="modal fade" id="successModal" tabIndex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
    <div className="modal-dialog">
      <div className="modal-content">
        <div className="modal-header">
          <h5 className="modal-title" id="successModalLabel">{"Gửi đề xuất thành công"}</h5>
          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div className="modal-body">
          <p>{"Đề xuất của bạn đã được gửi thành công!"}</p>
        </div>
        <div className="modal-footer">
          <button type="button" className="btn btn-primary" data-bs-dismiss="modal" onClick={event => page.invoke("event4", event)}>{"OK"}</button>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

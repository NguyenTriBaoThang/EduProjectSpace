import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./HeadDefenseEdit.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/defense-edit");
export default function HeadDefenseEdit() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/defense-edit">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/font-end/head/lecturer_dashboard.html"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/course-list"><i className="bi bi-list-ul"></i>{" Quản lý tiêu chí chấm điểm"}</a>
    <a href="/head/progress-courses"><i className="bi bi-clock"></i>{" Theo dõi tiến độ"}</a>
    <a href="/head/grading-courses"><i className="bi bi-award"></i>{" Duyệt chấm điểm"}</a>
    <a href="/head/defense-list" className="active"><i className="bi bi-calendar"></i>{" Quản lý lịch bảo vệ"}</a>
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
      <input type="text" className="search-box me-3" placeholder={"🔍 Tìm kiếm..."} />
      <button id="toggleFullscreen" className="btn"><i className="bi bi-arrows-fullscreen"></i></button>
      <button id="toggleTheme" className="btn"><i className="bi bi-moon"></i></button>
      <button id="notificationBtn" className="btn"><i className="bi bi-bell"></i></button>
      <button id="profileBtn" className="btn"><i className="bi bi-person-circle"></i></button>
    </div>
  </nav>

  <div className="profile-dropdown" id="profileDropdown">
    <div className="profile-header">
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Lecturer Avatar" />
      <h6>{"Nguyễn Huy Cường"}</h6>
      <p>{"nguyenhuycuong@hutech.edu.vn"}</p>
    </div>
    <div className="profile-menu">
      <button type="button" className="link-button"><i className="bi bi-gear"></i>{" Cài đặt hiển thị"}</button>
      <button id="toggleFullscreenBtn" type="button" className="link-button"><i className="bi bi-arrows-fullscreen"></i>{" Toàn màn hình"}</button>
      <button type="button" className="link-button"><i className="bi bi-arrow-clockwise"></i>{" Khôi phục mặc định"}</button>
      <a href="/login" className="logout"><i className="bi bi-box-arrow-right"></i>{" Đăng xuất"}</a>
    </div>
  </div>

  <div className="container mt-4">
    <div className="d-flex justify-content-between align-items-center mb-4">
      <h2 className="fw-bold" style={{
            "color": "#007bff"
          }}>{"✏️ Sửa lịch bảo vệ"}</h2>
    </div>

    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item"><a href="/font-end/head/lecturer_dashboard.html"><i className="bi bi-house-door"></i></a></li>
        <li className="breadcrumb-item"><a href="/head/defense-list"><i className="bi bi-list-ul"></i>{" Danh sách môn cần xếp lịch bảo vệ"}</a></li>
        <li className="breadcrumb-item"><button id="backToDefenseLink" type="button" className="link-button"><i className="bi bi-calendar"></i>{" Quản lý lịch bảo vệ"}</button></li>
        <li className="breadcrumb-item active"><i className="bi bi-pencil"></i>{" Sửa lịch bảo vệ"}</li>
      </ol>
    </nav>

    <div className="card">
      <div className="card-header">
        <h5 className="mb-0">{"Thông tin lịch bảo vệ"}</h5>
      </div>
      <div className="card-body">
        <form id="editDefenseForm">
          <input type="hidden" id="editDefenseId" />
          <div className="row">
            <div className="col-md-6">
              <div className="mb-3">
                <label className="form-label">{"Mã đề tài"}</label>
                <input type="text" id="editDefenseProjectId" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Tên nhóm"}</label>
                <input type="text" id="editDefenseName" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Thành viên"}</label>
                <input type="text" id="editDefenseMembers" className="form-control" readOnly={true} />
              </div>
            </div>
            <div className="col-md-6">
              <div className="mb-3">
                <label className="form-label">{"Trạng thái"}</label>
                <input type="text" id="editDefenseStatus" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Điểm GVHD"}</label>
                <input type="text" id="editDefenseLecturerScore" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Điểm hội đồng"}</label>
                <input type="text" id="editDefenseCouncilScore" className="form-control" readOnly={true} />
              </div>
              <div className="mb-3">
                <label className="form-label">{"Duyệt điểm"}</label>
                <input type="text" id="editDefenseApproved" className="form-control" readOnly={true} />
              </div>
            </div>
          </div>
          <hr />
          <div className="row">
            <div className="col-md-4">
              <div className="mb-3">
                <label className="form-label">{"Ngày bảo vệ"}</label>
                <input type="date" id="editDefenseDate" className="form-control" required={true} />
              </div>
            </div>
            <div className="col-md-4">
              <div className="mb-3">
                <label className="form-label">{"Địa điểm"}</label>
                <input type="text" id="editDefenseLocation" className="form-control" required={true} />
              </div>
            </div>
            <div className="col-md-4">
              <div className="mb-3">
                <label className="form-label">{"Hội đồng"}</label>
                <select id="editDefenseCouncil" className="form-select" required={true}>
                  <option value="">{"Chọn hội đồng"}</option>
                  <option value="HD001">{"HD001"}</option>
                  <option value="HD002">{"HD002"}</option>
                  <option value="HD003">{"HD003"}</option>
                </select>
              </div>
            </div>
          </div>
          <div className="d-flex justify-content-end gap-2">
            <button type="button" className="btn btn-primary" onClick={event => page.invoke("event1", event)}>{"Lưu"}</button>
            <button type="button" className="btn btn-secondary" onClick={event => page.invoke("event2", event)}>{"Hủy"}</button>
          </div>
        </form>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

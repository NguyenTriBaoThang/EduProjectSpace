import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./GoogleMeet.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/head/google-meet");
export default function GoogleMeet() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/head/google-meet">


    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Trưởng bộ môn"}</h4>
  <a href="/font-end/head/lecturer_dashboard.html"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="sidebar-section">
    <h6 className="sidebar-subtitle">{"Trưởng bộ môn"}</h6>
    <a href="/head/course-assign"><i className="bi bi-person-plus"></i>{" Phân công GVHD"}</a>
    <a href="/head/lecturer-assign"><i className="bi bi-list-ul"></i>{" Danh sách GVHD"}</a>
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
      <img src="/assets/head/img/avatar.jpg" alt="Lecturer Avatar" />
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
      <h2 className="fw-bold text-primary">{"📅 Quản lý Google Meet"}</h2>
      <button className="btn btn-info" onClick={event => page.invoke("event1", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
    </div>

    <ul className="nav nav-tabs mb-4">
      <li className="nav-item">
        <a className="nav-link active" id="create-tab" data-bs-toggle="tab" href="#create">{"Tạo cuộc họp"}</a>
      </li>
      <li className="nav-item">
        <a className="nav-link" id="list-tab" data-bs-toggle="tab" href="#list">{"Danh sách cuộc họp"}</a>
      </li>
    </ul>

    <div className="tab-content">

      <div className="tab-pane fade show active" id="create">
        <div className="card">
          <div className="card-header bg-primary text-white">
            <h5 className="mb-0">{"Tạo cuộc họp Google Meet"}</h5>
          </div>
          <div className="card-body">
            <form id="createMeetingForm">
              <div className="row">
                <div className="col-md-6">
                  <div className="mb-3">
                    <label className="form-label">{"Tiêu đề cuộc họp"}</label>
                    <input type="text" id="meetingTitle" className="form-control" required={true} />
                  </div>
                  <div className="mb-3">
                    <label className="form-label">{"Học kỳ"}</label>
                    <select id="semesterId" className="form-select" required={true}>
                      <option value="">{"Chọn học kỳ"}</option>
                      <option value="HK1-2024">{"HK1-2024"}</option>
                      <option value="HK2-2024">{"HK2-2024"}</option>
                      <option value="HK3-2024">{"HK3-2024"}</option>
                    </select>
                  </div>
                  <div className="mb-3">
                    <label className="form-label">{"Học phần"}</label>
                    <select id="courseId" className="form-select" required={true}>
                      <option value="">{"Chọn học phần"}</option>
                    </select>
                  </div>
                </div>
                <div className="col-md-6">
                  <div className="mb-3">
                    <label className="form-label">{"Giảng viên"}</label>
                    <select id="lecturerId" className="form-select" required={true}>
                      <option value="">{"Chọn giảng viên"}</option>
                      <option value="lecturer123">{"Nguyễn Văn A"}</option>
                      <option value="lecturer456">{"Trần Thị B"}</option>
                    </select>
                  </div>
                  <div className="mb-3">
                    <label className="form-label">{"Nhóm"}</label>
                    <select id="groupIds" className="form-select" multiple={true} required={true}>
                      <option value="">{"Chọn nhóm"}</option>
                    </select>
                  </div>
                </div>
              </div>
              <hr />
              <div className="row">
                <div className="col-md-4">
                  <div className="mb-3">
                    <label className="form-label">{"Ngày bắt đầu"}</label>
                    <input type="date" id="startTime" className="form-control" required={true} />
                  </div>
                </div>
                <div className="col-md-4">
                  <div className="mb-3">
                    <label className="form-label">{"Thời gian bắt đầu"}</label>
                    <input type="time" id="startTimeHour" className="form-control" required={true} />
                  </div>
                </div>
                <div className="col-md-4">
                  <div className="mb-3">
                    <label className="form-label">{"Thời gian kết thúc"}</label>
                    <input type="time" id="endTimeHour" className="form-control" required={true} />
                  </div>
                </div>
                <div className="col-md-4">
                  <div className="mb-3">
                    <label className="form-label">{"Địa điểm"}</label>
                    <input type="text" id="location" className="form-control" defaultValue="Online" readOnly={true} />
                  </div>
                </div>
                <div className="col-md-4">
                  <div className="mb-3">
                    <label className="form-check-label">{"Tự động ghi hình"}</label>
                    <input type="checkbox" id="autoRecord" className="form-check-input" defaultChecked={true} />
                  </div>
                </div>
              </div>
              <div className="d-flex justify-content-end gap-2">
                <button type="submit" className="btn btn-primary">{"Tạo cuộc họp"}</button>
                <button type="button" className="btn btn-secondary" onClick={event => page.invoke("event2", event)}>{"Hủy"}</button>
              </div>
            </form>
          </div>
        </div>
      </div>

      <div className="tab-pane fade" id="list">
        <div className="table-container">
          <div className="table-header d-flex gap-2">
            <input type="text" id="searchInput" className="form-control" placeholder={"🔍 Tìm cuộc họp..."} onKeyUp={event => page.invoke("event3", event)} />
          </div>
          <div className="table-content">
            <table className="table-custom table-bordered table-hover">
              <thead>
                <tr>
                  <th>{"#"}</th>
                  <th className="sortable" onClick={event => page.invoke("event4", event)}>{"Tiêu đề "}<i className="bi bi-arrow-down-up"></i></th>
                  <th className="sortable" onClick={event => page.invoke("event5", event)}>{"Thời gian bắt đầu "}<i className="bi bi-arrow-down-up"></i></th>
                  <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Thời gian kết thúc "}<i className="bi bi-arrow-down-up"></i></th>
                  <th>{"Link cuộc họp"}</th>
                  <th>{"Hành động"}</th>
                </tr>
              </thead>
              <tbody id="meetingTableBody"></tbody>
            </table>
          </div>
          <div className="table-footer">
            <ul id="pagination" className="pagination"></ul>
          </div>
        </div>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>



  </div>;
}

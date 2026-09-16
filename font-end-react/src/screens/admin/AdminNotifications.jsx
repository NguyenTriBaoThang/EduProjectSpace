import React from "react";
import { usePageController } from "../../runtime/usePageController";
import setup from "./AdminNotifications.controller";
import pages from "../../pageManifest.json";
const definition = pages.find(page => page.path === "/admin/notifications");
export default function AdminNotifications() {
  const page = usePageController(setup, definition);
  return <div ref={page.root} className="page-frame" data-page="/admin/notifications">

    <div className="sidebar" id="sidebar">
  <h4 className="text-center mb-4">{"🎓 Hệ thống Admin"}</h4>
  <a href="/admin/dashboard"><i className="bi bi-house-door"></i>{" Tổng quan"}</a>
  <div className="dropdown-menu-wrapper">
    <button onClick={event => page.invoke("event0", event)} className="dropdown-toggle link-button" type="button">
      <i className="bi bi-person-circle"></i>{" Quản lý tài khoản\n            "}</button>
    <div className="dropdown-content" style={{
          "display": "none",
          "paddingLeft": "20px"
        }}>
      <a href="/admin/users"><i className="bi bi-person-lines-fill"></i>{" Người dùng"}</a>
      <a href="/admin/lecturers"><i className="bi bi-person-workspace"></i>{" Giảng viên"}</a>
      <a href="/admin/students"><i className="bi bi-people"></i>{" Sinh viên"}</a>
    </div>
  </div>
  <a href="/admin/semesters"><i className="bi bi-calendar"></i>{" Quản lý kỳ học"}</a>
  <a href="/admin/courses"><i className="bi bi-book"></i>{" Quản lý học phần"}</a>
  <a href="/admin/projects"><i className="bi bi-folder"></i>{" Quản lý đề tài"}</a>
  <a href="/admin/notifications" className="active"><i className="bi bi-bell"></i>{" Quản lý thông báo"}</a>
  <a href="/admin/logs"><i className="bi bi-clock-history"></i>{" Lịch sử hoạt động"}</a>
  <a href="/admin/grading"><i className="bi bi-award"></i>{" Quản lý hội đồng"}</a>
  <a href="/admin/settings"><i className="bi bi-gear"></i>{" Cài đặt hệ thống"}</a>
  <a href="/admin/reports"><i className="bi bi-bar-chart"></i>{" Báo cáo thống kê"}</a>
    </div>

    <div className="content">
  <nav className="navbar navbar-expand-lg px-3">
    <button id="toggleSidebarBtn" className="btn btn-outline-light me-2">
      <i id="sidebarIcon" className="bi bi-list"></i>
    </button>
    <button className="navbar-toggler toggle-btn" onClick={event => page.invoke("event1", event)}>
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
      <img src="/assets/static/medit/imgUser/avatar.jpg" alt="Admin Avatar" />
      <h6 id="adminName">{"Admin HUTECH"}</h6>
      <p id="adminEmail">{"admin@hutech.edu.vn"}</p>
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
      <h2 className="fw-bold text-primary">{"🔔 Quản lý thông báo"}</h2>
      <div>
        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#addNotificationModal">{"Thêm thông báo "}<i className="bi bi-plus-circle"></i></button>
        <button className="btn btn-warning me-2" data-bs-toggle="modal" data-bs-target="#configNotificationModal">{"Cấu hình "}<i className="bi bi-gear"></i></button>
        <button className="btn btn-info" onClick={event => page.invoke("event3", event)}>{"Xuất Excel "}<i className="bi bi-file-earmark-excel"></i></button>
      </div>
    </div>
    <nav className="breadcrumb-container">
      <ol className="breadcrumb">
        <li className="breadcrumb-item">
          <a href="/admin/dashboard"><i className="bi bi-house-door"></i></a>
        </li>
        <li className="breadcrumb-item active">
          <i className="bi bi-bell"></i>{" Quản lý thông báo\n                    "}</li>
      </ol>
    </nav>
    <div className="card border-0 shadow-sm rounded-3 mb-4">
      <div className="card-header bg-primary text-white d-flex align-items-center py-2">
        <i className="bi bi-bell-fill me-2 fs-5"></i>
        <span className="fw-semibold">{"Thông báo gần đây"}</span>
      </div>
      <div className="card-body p-3" id="recentNotifications">
        <p className="text-muted mb-0">{"Đang tải thông báo gần đây..."}</p>
      </div>
    </div>
    <div className="table-container">
      <div className="table-header d-flex gap-2">
        <input type="text" id="searchInputFuse" className="form-control" placeholder={"🔍 Tìm thông báo..."} onKeyUp={event => page.invoke("event4", event)} />
        <select id="statusFilter" className="form-select" onChange={event => page.invoke("event5", event)}>
          <option value="">{"📂 Trạng thái"}</option>
          <option value="SENT">{"Đã gửi"}</option>
          <option value="PENDING">{"Chưa gửi"}</option>
        </select>
      </div>
      <div className="table-content">
        <table className="table-custom table-bordered table-hover">
          <thead>
            <tr>
              <th>{"#"}</th>
              <th className="sortable" onClick={event => page.invoke("event6", event)}>{"Tiêu đề "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event7", event)}>{"Nội dung "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event8", event)}>{"Người nhận "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event9", event)}>{"Ngày gửi "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event10", event)}>{"Trạng thái "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event11", event)}>{"Đã xem "}<i className="bi bi-arrow-down-up"></i></th>
              <th className="sortable" onClick={event => page.invoke("event12", event)}>{"Thời gian xem "}<i className="bi bi-arrow-down-up"></i></th>
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

    <div className="modal fade" id="addNotificationModal" tabIndex="-1" aria-labelledby="addNotificationModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="addNotificationModalLabel">{"Thêm thông báo mới"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="addNotificationForm">
          <div className="mb-3">
            <label className="form-label">{"Tiêu đề"}</label>
            <input type="text" id="notificationTitle" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Nội dung"}</label>
            <textarea id="notificationContent" className="form-control" rows="4" required={true}></textarea>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Người nhận"}</label>
            <select id="notificationRecipient" className="form-select" required={true}>
              <option value="All">{"Tất cả"}</option>
              <option value="Student">{"Sinh viên"}</option>
              <option value="Lecturer">{"Giảng viên"}</option>
              <option value="Admin">{"Quản trị viên"}</option>
              <option value="Head">{"Trưởng bộ môn"}</option>
              <option value="Individual">{"Cá nhân"}</option>
              <option value="Group">{"Nhóm"}</option>
            </select>
          </div>
          <div className="mb-3" id="userIdField" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Chọn tài khoản"}</label>
            <select id="notificationUserId" className="form-select" multiple={true}></select>
          </div>
          <div className="mb-3" id="groupIdField" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Chọn nhóm"}</label>
            <select id="notificationGroupId" className="form-select" multiple={true}></select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Loại thông báo"}</label>
            <select id="notificationType" className="form-select" required={true}>
              <option value="Web">{"Web"}</option>
              <option value="Email">{"Email"}</option>
              <option value="Urgent">{"Khẩn cấp"}</option>
            </select>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event13", event)}>{"Gửi"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="editNotificationModal" tabIndex="-1" aria-labelledby="editNotificationModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="editNotificationModalLabel">{"Sửa thông báo"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="editNotificationForm">
          <input type="hidden" id="editNotificationId" />
          <div className="mb-3">
            <label className="form-label">{"Tiêu đề"}</label>
            <input type="text" id="editNotificationTitle" className="form-control" required={true} />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Nội dung"}</label>
            <textarea id="editNotificationContent" className="form-control" rows="4" required={true}></textarea>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Người nhận"}</label>
            <select id="editNotificationRecipient" className="form-select" required={true}>
              <option value="All">{"Tất cả"}</option>
              <option value="Student">{"Sinh viên"}</option>
              <option value="Lecturer">{"Giảng viên"}</option>
              <option value="Admin">{"Quản trị viên"}</option>
              <option value="Head">{"Trưởng bộ môn"}</option>
              <option value="Individual">{"Cá nhân"}</option>
              <option value="Group">{"Nhóm"}</option>
            </select>
          </div>
          <div className="mb-3" id="userIdField" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Chọn tài khoản"}</label>
            <select id="notificationUserId" className="form-select" multiple={true}></select>
          </div>
          <div className="mb-3" id="groupIdField" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Chọn nhóm"}</label>
            <select id="notificationGroupId" className="form-select" multiple={true}></select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Trạng thái"}</label>
            <select id="editNotificationStatus" className="form-select" required={true}>
              <option value="SENT">{"Đã gửi"}</option>
              <option value="PENDING">{"Chưa gửi"}</option>
              <option value="FAILED">{"Thất bại"}</option>
            </select>
          </div>
          <div className="mb-3">
            <label className="form-label">{"Loại thông báo"}</label>
            <select id="editNotificationType" className="form-select" required={true}>
              <option value="Web">{"Web"}</option>
              <option value="Email">{"Email"}</option>
              <option value="Urgent">{"Khẩn cấp"}</option>
            </select>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event14", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="configNotificationModal" tabIndex="-1" aria-labelledby="configNotificationModalLabel" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="configNotificationModalLabel">{"Cấu hình thông báo"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <form id="configNotificationForm">
          <div className="mb-3">
            <label className="form-label">{"Kênh gửi thông báo"}</label>
            <div className="form-check">
              <input type="checkbox" id="enableWeb" className="form-check-input" defaultChecked={true} />
              <label className="form-check-label" htmlFor="enableWeb">{"Hiển thị trên web"}</label>
            </div>
            <div className="form-check">
              <input type="checkbox" id="enableEmail" className="form-check-input" />
              <label className="form-check-label" htmlFor="enableEmail">{"Gửi qua email"}</label>
            </div>
          </div>
          <div className="mb-3" id="emailConfig" style={{
                "display": "none"
              }}>
            <label className="form-label">{"Cấu hình SMTP"}</label>
            <input type="text" id="smtpHost" className="form-control mb-2" placeholder="SMTP Host (e.g., smtp.gmail.com)" />
            <input type="number" id="smtpPort" className="form-control mb-2" placeholder="SMTP Port (e.g., 587)" />
            <input type="text" id="smtpUsername" className="form-control mb-2" placeholder="SMTP Username" />
            <input type="password" id="smtpPassword" className="form-control" placeholder="SMTP Password" />
          </div>
          <div className="mb-3">
            <label className="form-label">{"Tần suất nhắc nhở tự động"}</label>
            <select id="reminderFrequency" className="form-select">
              <option value="none">{"Không nhắc"}</option>
              <option value="daily">{"Hàng ngày"}</option>
              <option value="weekly">{"Hàng tuần"}</option>
            </select>
          </div>
        </form>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Hủy"}</button>
        <button type="button" className="btn btn-primary" onClick={event => page.invoke("event15", event)}>{"Lưu"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="modal fade" id="viewNotificationModal" tabIndex="-1" aria-labelledby="viewNotificationModalLabel" aria-hidden="true">
  <div className="modal-dialog modal-lg">
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title" id="viewNotificationModalLabel">{"Chi tiết thông báo"}</h5>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        <div className="mb-3">
          <label className="form-label fw-bold">{"Tiêu đề"}</label>
          <p id="viewNotificationTitle" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Nội dung"}</label>
          <p id="viewNotificationContent" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Người nhận"}</label>
          <p id="viewNotificationRecipient" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Ngày gửi"}</label>
          <p id="viewNotificationDate" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Trạng thái"}</label>
          <p id="viewNotificationStatus" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Đã xem"}</label>
          <p id="viewNotificationIsFirstViewed" className="bg-light p-2 rounded-3"></p>
        </div>
        <div className="mb-3">
          <label className="form-label fw-bold">{"Thời gian xem"}</label>
          <p id="viewNotificationFirstViewedAt" className="bg-light p-2 rounded-3"></p>
        </div>
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">{"Đóng"}</button>
      </div>
    </div>
  </div>
    </div>

    <div className="footer">{"\n        Bản quyền của HUTECH – Phát triển bởi Team TAD Programmer ©2025\n    "}</div>






  </div>;
}

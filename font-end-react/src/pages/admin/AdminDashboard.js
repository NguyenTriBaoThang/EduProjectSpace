// src/pages/admin/AdminDashboard.js
import React, { useEffect, useRef, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Helmet } from 'react-helmet';
import Chart from 'chart.js/auto';
import * as XLSX from 'xlsx';
import HeaderAdmin from '../../components/HeaderAdmin';
import FooterAdmin from '../../components/FooterAdmin';
import Sidebar from '../../components/SidebarAdmin';

function AdminDashboard() {
  const navigate = useNavigate();
  const chartRef = useRef(null);
  const [user, setUser] = useState(null);
  const [summary, setSummary] = useState({
    studentCount: 0,
    submittedProjects: 0,
    pendingTopics: 0,
  });
  const [notifications, setNotifications] = useState([]);
  const [projectStatus, setProjectStatus] = useState({
    notSubmitted: 0,
    submitted: 0,
    graded: 0,
  });

  const API_URL = 'https://localhost:7047';

  // Load user profile
  useEffect(() => {
    const loadUserProfile = async () => {
      const storedUser = JSON.parse(localStorage.getItem('user'));
      if (!storedUser || storedUser.roleName !== 'ROLE_ADMIN') {
        alert('Không có quyền Admin hoặc chưa đăng nhập.');
        navigate('/login');
        return;
      }
      setUser(storedUser);
    };
    loadUserProfile();
  }, [navigate]);

  // Load dashboard data
  useEffect(() => {
    const loadDashboardData = async () => {
      try {
        // Load summary
        const summaryResponse = await fetch(`${API_URL}/api/Dashboard/summary`, {
          method: 'GET',
          headers: { Accept: '*/*' },
          credentials: 'include',
        });
        if (!summaryResponse.ok) throw new Error(`Lỗi tải thống kê tổng quan: ${summaryResponse.status}`);
        const summaryData = await summaryResponse.json();
        setSummary(summaryData);

        // Load project status
        const statusResponse = await fetch(`${API_URL}/api/Dashboard/project-status`, {
          method: 'GET',
          headers: { Accept: '*/*' },
          credentials: 'include',
        });
        if (!statusResponse.ok) throw new Error(`Lỗi tải trạng thái đồ án: ${statusResponse.status}`);
        const statusData = await statusResponse.json();
        setProjectStatus(statusData);

        // Load recent notifications
        const notificationsResponse = await fetch(`${API_URL}/api/Notifications/recent`, {
          method: 'GET',
          headers: { Accept: '*/*' },
          credentials: 'include',
        });
        if (!notificationsResponse.ok) throw new Error(`Lỗi tải thông báo gần đây: ${notificationsResponse.status}`);
        const notificationsData = await notificationsResponse.json();
        setNotifications(notificationsData);
      } catch (error) {
        console.error('Error loading dashboard:', error);
        alert(`Không tải được dữ liệu: ${error.message || 'Vui lòng đăng nhập lại.'}`);
        navigate('/login');
      }
    };
    if (user) loadDashboardData();
  }, [user, navigate]);

  // Update project status chart
  useEffect(() => {
    if (chartRef.current) {
      const ctx = chartRef.current.getContext('2d');
      const projectStatusChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
          labels: ['Chưa nộp', 'Đã nộp', 'Đã chấm điểm'],
          datasets: [
            {
              data: [projectStatus.notSubmitted || 0, projectStatus.submitted || 0, projectStatus.graded || 0],
              backgroundColor: ['#dc3545', '#28a745', '#007bff'],
              borderWidth: 1,
            },
          ],
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              position: 'bottom',
              labels: {
                font: { size: 14, weight: 'bold' },
              },
            },
          },
        },
      });
      return () => projectStatusChart.destroy();
    }
  }, [projectStatus]);

  // Export Excel
  const exportDashboard = () => {
    const worksheetData = [
      ['Tổng quan Admin - Hệ thống Sinh viên HUTECH'],
      [],
      ['Thống kê nhanh'],
      ['Số lượng sinh viên', summary.studentCount],
      ['Đồ án đã nộp', summary.submittedProjects],
      ['Đề tài chờ duyệt', summary.pendingTopics],
      ['Thông báo gần đây', notifications.length],
      [],
      ['Thống kê trạng thái đồ án'],
      ['Chưa nộp', projectStatus.notSubmitted],
      ['Đã nộp', projectStatus.submitted],
      ['Đã chấm điểm', projectStatus.graded],
      [],
      ['Thông báo gần đây'],
      ...notifications.map((n) => [n.details || '', new Date(n.createdAt).toLocaleString()]),
    ];

    const worksheet = XLSX.utils.aoa_to_sheet(worksheetData);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'TongQuanAdmin');
    XLSX.writeFile(workbook, 'admin_dashboard.xlsx');
  };

  // Toggle sidebar
  const toggleSidebar = () => {
    const sidebar = document.querySelector('.sidebar');
    const content = document.querySelector('.content');
    const icon = document.getElementById('sidebarIcon');
    sidebar.classList.toggle('collapsed');
    content.classList.toggle('expanded');
    if (sidebar.classList.contains('collapsed')) {
      icon.classList.replace('bi-list', 'bi-layout-sidebar-inset');
    } else {
      icon.classList.replace('bi-layout-sidebar-inset', 'bi-list');
    }
  };

  return (
    <>
      <Helmet>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta name="description" content="Trang tổng quan Admin của hệ thống Sinh viên HUTECH." />
        <meta
          name="copyright"
          content="© 2025 - Nhóm TAD Programmer Khoa Công nghệ Thông tin - Trường Đại học Công nghệ TP.HCM - HUTECH. Tất cả quyền được bảo lưu."
        />
        <title>Tổng quan Admin | Hệ thống Sinh viên</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="/static/css/styles_admin.css" rel="stylesheet" />
        <link href="/static/img/img_logohutech.png" type="image/png" rel="icon" />
      </Helmet>
      <div>
        
        <Sidebar />

        <div className="content">
          <HeaderAdmin toggleSidebar={toggleSidebar} />
          <div className="container mt-4">
            <div className="d-flex justify-content-between align-items-center mb-4">
              <h2 className="fw-bold text-primary">📊 Tổng quan Admin</h2>
              <button className="btn btn-info" onClick={exportDashboard}>
                Xuất Excel <i className="bi bi-file-earmark-excel"></i>
              </button>
            </div>

            <nav className="breadcrumb-container">
              <ol className="breadcrumb">
                <li className="breadcrumb-item">
                  <a href="/admin/dashboard">
                    <i className="bi bi-house-door"></i>
                  </a>
                </li>
                <li className="breadcrumb-item active">
                  <i className="bi bi-house-door-fill"></i> Tổng quan
                </li>
              </ol>
            </nav>

            <div className="row mb-4">
              <div className="col-md-3">
                <div className="card-dashboard summary-card avg">
                  <div className="card-header">
                    <i className="bi bi-people"></i>
                    <h5>Số lượng sinh viên</h5>
                  </div>
                  <div className="card-content">
                    <h3 id="studentCount">{summary.studentCount}</h3>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="card-dashboard summary-card high">
                  <div className="card-header">
                    <i className="bi bi-folder-check"></i>
                    <h5>Đồ án đã nộp</h5>
                  </div>
                  <div className="card-content">
                    <h3 id="submittedProjects">{summary.submittedProjects}</h3>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="card-dashboard summary-card low">
                  <div className="card-header">
                    <i className="bi bi-lightbulb"></i>
                    <h5>Đề tài chờ duyệt</h5>
                  </div>
                  <div className="card-content">
                    <h3 id="pendingTopics">{summary.pendingTopics}</h3>
                  </div>
                </div>
              </div>
              <div className="col-md-3">
                <div className="card-dashboard summary-card avg">
                  <div className="card-header">
                    <i className="bi bi-bell"></i>
                    <h5>Thông báo gần đây</h5>
                  </div>
                  <div className="card-content">
                    <h3 id="recentNotificationsCount">{notifications.length}</h3>
                  </div>
                </div>
              </div>
            </div>

            <div className="row">
              <div className="col-md-6">
                <div className="card-dashboard">
                  <div className="card-header">
                    <i className="bi bi-bar-chart-line"></i>
                    <h5>Thống kê trạng thái đồ án</h5>
                  </div>
                  <div className="card-content chart-container">
                    <canvas id="projectStatusChart" ref={chartRef}></canvas>
                  </div>
                </div>
              </div>
              <div className="col-md-6">
                <div className="card-dashboard">
                  <div className="card-header">
                    <i className="bi bi-bell"></i>
                    <h5>Thông báo gần đây</h5>
                  </div>
                  <div className="card-content">
                    <ul className="list-group list-group-flush" id="recentNotifications">
                      {notifications.map((notification, index) => (
                        <li key={index} className="dashboard-list-group-item">
                          <i className="bi bi-bell"></i>
                          <span
                            className="dashboard-notification-title"
                            data-full-text={notification.details || ''}
                          >
                            {(notification.details || '').substring(0, 30)}...
                          </span>
                          <span className="text-muted">
                            {new Date(notification.createdAt).toLocaleString()}
                          </span>
                        </li>
                      ))}
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <FooterAdmin />
      </div>
    </>
  );
}

export default AdminDashboard;
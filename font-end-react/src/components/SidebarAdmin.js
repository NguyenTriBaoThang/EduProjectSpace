// src/components/Sidebar.js
import React from 'react';
import { NavLink } from 'react-router-dom';

function SidebarAdmin() {
  return (
    <div className="sidebar" id="sidebar">
      <h4 className="text-center mb-4">🎓 Hệ thống Admin</h4>
      <NavLink to="/admin/dashboard" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-house-door"></i> Tổng quan
      </NavLink>
      <NavLink to="/admin/users" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-person-lines-fill"></i> Quản lý người dùng
      </NavLink>
      <NavLink to="/admin/students" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-people"></i> Quản lý sinh viên
      </NavLink>
      <NavLink to="/admin/lecturers" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-person-workspace"></i> Quản lý giảng viên
      </NavLink>
      <NavLink to="/admin/notifications" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-bell"></i> Quản lý thông báo
      </NavLink>
      <NavLink to="/admin/logs" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-clock-history"></i> Lịch sử hoạt động
      </NavLink>
      <NavLink to="/admin/semesters" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-calendar"></i> Quản lý kỳ học
      </NavLink>
      <NavLink to="/admin/projects" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-folder"></i> Quản lý đề tài
      </NavLink>
      <NavLink to="/admin/grading" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-award"></i> Quản lý hội đồng
      </NavLink>
      <NavLink to="/admin/settings" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-gear"></i> Cài đặt hệ thống
      </NavLink>
      <NavLink to="/admin/reports" className={({ isActive }) => (isActive ? 'active' : '')}>
        <i className="bi bi-bar-chart"></i> Báo cáo thống kê
      </NavLink>
    </div>
  );
}

export default SidebarAdmin;
// src/App.js
import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/index/Home';
import LoginForm from './pages/login/LoginForm';
import AdminDashboard from './pages/admin/AdminDashboard';
import AdminUsers from './pages/admin/AdminUsers';
import AdminStudents from './pages/admin/AdminStudents';
import AdminLecturers from './pages/admin/AdminLecturers';
import AdminNotifications from './pages/admin/AdminNotifications';
import AdminLogs from './pages/admin/AdminLogs';
import AdminSemesters from './pages/admin/AdminSemesters';
import AdminProjects from './pages/admin/AdminProjects';
import AdminGrading from './pages/admin/AdminGrading';
import AdminSettings from './pages/admin/AdminSettings';
import AdminReports from './pages/admin/AdminReports';
import LecturerDashboard from './pages/lecturer/LecturerDashboard';
import StudentDashboard from './pages/student/StudentDashboard';
import HeadDashboard from './pages/head/HeadDashboard';

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/login" element={<LoginForm />} />
      <Route path="/admin/" element={<AdminDashboard />} />
      <Route path="/admin/dashboard" element={<AdminDashboard />} />
      <Route path="/admin/users" element={<AdminUsers />} />
      <Route path="/admin/students" element={<AdminStudents />} />
      <Route path="/admin/lecturers" element={<AdminLecturers />} />
      <Route path="/admin/notifications" element={<AdminNotifications />} />
      <Route path="/admin/logs" element={<AdminLogs />} />
      <Route path="/admin/semesters" element={<AdminSemesters />} />
      <Route path="/admin/projects" element={<AdminProjects />} />
      <Route path="/admin/grading" element={<AdminGrading />} />
      <Route path="/admin/settings" element={<AdminSettings />} />
      <Route path="/admin/reports" element={<AdminReports />} />
      <Route path="/lecturer/dashboard" element={<LecturerDashboard />} />
      <Route path="/student/dashboard" element={<StudentDashboard />} />
      <Route path="/head/dashboard" element={<HeadDashboard />} />
    </Routes>
  );
}

export default App;
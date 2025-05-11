// src/components/HeaderAdmin.js
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function HeaderAdmin({ toggleSidebar }) {
  const navigate = useNavigate();
  const [showProfileDropdown, setShowProfileDropdown] = useState(false);
  const [user, setUser] = useState(null);

  // Load user profile
  useEffect(() => {
    const storedUser = JSON.parse(localStorage.getItem('user'));
    if (storedUser && storedUser.roleName === 'ROLE_ADMIN') {
      setUser(storedUser);
    }
  }, []);

  // Toggle profile dropdown
  const toggleProfileDropdown = () => setShowProfileDropdown(!showProfileDropdown);

  // Toggle fullscreen
  const toggleFullscreen = () => {
    if (!document.fullscreenElement) document.documentElement.requestFullscreen();
    else document.exitFullscreen();
  };

  // Toggle theme
  const toggleTheme = () => {
    document.body.classList.toggle('dark-mode');
    localStorage.setItem('theme', document.body.classList.contains('dark-mode') ? 'dark' : 'light');
  };

  // Logout
  const logout = async () => {
    try {
      const response = await fetch('https://localhost:7047/api/Auth/logout', {
        method: 'POST',
        credentials: 'include',
      });
      if (response.ok) {
        localStorage.removeItem('user');
        navigate('/login');
      } else {
        throw new Error('Đăng xuất thất bại.');
      }
    } catch (error) {
      console.error('Logout error:', error);
      alert('Không đăng xuất được. Vui lòng thử lại.');
    }
  };

  // Close dropdown when clicking outside
  useEffect(() => {
    const handleClickOutside = (event) => {
      const dropdown = document.getElementById('profileDropdown');
      if (dropdown && !dropdown.contains(event.target) && event.target.id !== 'profileBtn') {
        setShowProfileDropdown(false);
      }
    };
    document.addEventListener('click', handleClickOutside);
    return () => document.removeEventListener('click', handleClickOutside);
  }, []);

  // Apply theme
  useEffect(() => {
    if (localStorage.getItem('theme') === 'dark') {
      document.body.classList.add('dark-mode');
    }
  }, []);

  return (
    <nav className="navbar navbar-expand-lg px-3">
      <button id="toggleSidebarBtn" className="btn btn-outline-light me-2" onClick={toggleSidebar}>
        <i id="sidebarIcon" className="bi bi-list"></i>
      </button>
      <button className="navbar-toggler toggle-btn" onClick={toggleSidebar}>
        <i className="bi bi-list"></i>
      </button>
      <div className="ms-auto d-flex align-items-center">
        <input type="text" className="search-box me-3" placeholder="🔍 Tìm kiếm..." />
        <button id="toggleFullscreen" className="btn" onClick={toggleFullscreen}>
          <i className="bi bi-arrows-fullscreen"></i>
        </button>
        <button id="toggleTheme" className="btn" onClick={toggleTheme}>
          <i className="bi bi-moon"></i>
        </button>
        <button id="notificationBtn" className="btn" onClick={() => navigate('/admin/notifications')}>
          <i className="bi bi-bell"></i>
        </button>
        <button id="profileBtn" className="btn" onClick={toggleProfileDropdown}>
          <i className="bi bi-person-circle"></i>
        </button>
      </div>
      <div
        className="profile-dropdown"
        id="profileDropdown"
        style={{ display: showProfileDropdown ? 'block' : 'none' }}
      >
        <div className="profile-header">
          <img src="/static/img/avatar.jpg" alt="Admin Avatar" />
          <h6 id="adminName">{user?.fullName || 'Admin HUTECH'}</h6>
          <p id="adminEmail">{user?.email || 'admin@hutech.edu.vn'}</p>
        </div>
        <div className="profile-menu">
          <a href="/admin/settings">
            <i className="bi bi-gear"></i> Cài đặt hiển thị
          </a>
          <a href="#" onClick={toggleFullscreen}>
            <i className="bi bi-arrows-fullscreen"></i> Toàn màn hình
          </a>
          <a href="#">
            <i className="bi bi-arrow-clockwise"></i> Khôi phục mặc định
          </a>
          <a href="#" className="logout" onClick={logout}>
            <i className="bi bi-box-arrow-right"></i> Đăng xuất
          </a>
        </div>
      </div>
    </nav>
  );
}

export default HeaderAdmin;
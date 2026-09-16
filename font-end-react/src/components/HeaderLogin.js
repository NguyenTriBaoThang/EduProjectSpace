// src/components/HeaderLogin.js
import React from 'react';
import { Link } from 'react-router-dom';

function HeaderLogin({ isLoginPage = false }) {
  const toggleTheme = () => {
    document.body.classList.toggle('dark-mode');
    localStorage.setItem('theme', document.body.classList.contains('dark-mode') ? 'dark' : 'light');
  };

  React.useEffect(() => {
    if (localStorage.getItem('theme') === 'dark') {
      document.body.classList.add('dark-mode');
    }
  }, []);

  return (
    <>
      {isLoginPage ? (
        <header>
          <div className="header-container">
            <img src="/static/img/hutech-logo.png" alt="HUTECH Logo" className="logo" />
          </div>
        </header>
      ) : (
        <header className="navbar navbar-expand-lg">
          <div className="container">
            <Link className="navbar-brand text-white" to="/">
              <img src="/static/img/img_logohutech.png" alt="HUTECH Logo" width="40" className="me-2 logo" />
              Hệ thống Sinh viên HUTECH
            </Link>
            <div className="ms-auto d-flex align-items-center">
              <button id="toggleTheme" className="btn btn-outline-light me-3" onClick={toggleTheme}>
                <i className="bi bi-moon-stars"></i>
              </button>
              <Link to="/login" className="btn btn-primary">
                <i className="bi bi-box-arrow-in-right"></i> Đăng nhập
              </Link>
            </div>
          </div>
        </header>
      )}
    </>
  );
}

export default HeaderLogin;
// src/components/Header.js
import React from 'react';
import { Helmet } from 'react-helmet';
import { Link } from 'react-router-dom';

function Header() {
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
      <Helmet>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta name="description" content="Hệ thống Quản lý đồ án môn học của Sinh viên HUTECH." />
        <meta
          name="copyright"
          content="© 2025 - Nhóm TAD Programmer Khoa Công nghệ Thông tin - Trường Đại học Công nghệ TP.HCM - HUTECH. Tất cả quyền được bảo lưu."
        />
        <title>HUTECH | Hệ thống Sinh viên</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet" />
        <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600;700&display=swap" rel="stylesheet" />
        <link rel="icon" href="/static/img/img_logohutech.png" type="image/png" />
        <link href="static/css/styles_index.css" rel="stylesheet"/>
      </Helmet>
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
    </>
  );
}

export default Header;
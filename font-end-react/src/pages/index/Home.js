// src/pages/index/Home.js
import React from 'react';
import { Link } from 'react-router-dom';
import Header from '../../components/Header';
import Footer from '../../components/Footer';

function Home() {
  return (
    <div>
      <Header />
      {/* Hero Section */}
      <section className="hero-section">
        <div className="container">
          <div className="row align-items-center">
            <div className="col-md-6 text-content">
              <h1 className="fw-bold text-primary">Khám phá Hệ thống Sinh viên HUTECH</h1>
              <p className="lead">
                Quản lý đồ án môn học, theo dõi tiến độ, nộp bài tập và đề xuất đề tài dễ dàng. Được phát triển bởi Team TAD Programmer, Khoa Công nghệ Thông tin.
              </p>
              <Link to="/login" className="btn btn-primary btn-lg">
                <i className="bi bi-rocket-takeoff"></i> Bắt đầu ngay
              </Link>
            </div>
            <div className="col-md-6 text-center">
              <img src="../../static/img/mobile.png" alt="HUTECH System" className="img-fluid hero-image" />
            </div>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section className="features-section">
        <div className="container">
          <h2 className="text-center fw-bold mb-5">Tại sao chọn Hệ thống HUTECH?</h2>
          <div className="row">
            <div className="col-md-4">
              <div className="feature-card">
                <i className="bi bi-book feature-icon"></i>
                <h4>Quản lý đồ án</h4>
                <p>Dễ dàng theo dõi và quản lý các đồ án môn học của bạn.</p>
              </div>
            </div>
            <div className="col-md-4">
              <div className="feature-card">
                <i className="bi bi-clock feature-icon"></i>
                <h4>Theo dõi tiến độ</h4>
                <p>Cập nhật tiến độ công việc theo thời gian thực.</p>
              </div>
            </div>
            <div className="col-md-4">
              <div className="feature-card">
                <i className="bi bi-lightbulb feature-icon"></i>
                <h4>Đề xuất đề tài</h4>
                <p>Nhận gợi ý đề tài sáng tạo và phù hợp.</p>
              </div>
            </div>
          </div>
        </div>
      </section>
      <Footer />
    </div>
  );
}

export default Home;
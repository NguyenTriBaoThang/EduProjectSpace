// src/pages/login/LoginForm.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import HeaderLogin from '../../components/HeaderLogin';
import FooterLogin from '../../components/FooterLogin';


function LoginForm() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setIsLoading(true);

    if (!username || !password) {
      setError('Vui lòng nhập đầy đủ tài khoản và mật khẩu.');
      setIsLoading(false);
      return;
    }

    try {
      const response = await axios.post(
        'https://localhost:7047/api/Auth/login',
        { username, password },
        { withCredentials: true }
      );

      const { user, token } = response.data;

      if (user.locked) {
        throw new Error('Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.');
      }

      localStorage.setItem('user', JSON.stringify(user));
      if (token) {
        localStorage.setItem('token', token);
      }

      switch (user.roleName) {
        case 'ROLE_ADMIN':
          navigate('/admin/dashboard');
          break;
        case 'ROLE_LECTURER_GUIDE':
          navigate('/lecturer/dashboard');
          break;
        case 'ROLE_STUDENT':
          navigate('/student/dashboard');
          break;
        case 'ROLE_HEAD':
          navigate('/head/dashboard');
          break;
        default:
          throw new Error('Vai trò không hợp lệ.');
      }
    } catch (err) {
      console.error('Axios error:', err);
      let message = 'Không kết nối được server. Vui lòng thử lại.';
      if (err.response) {
        const { status, data } = err.response;
        console.log('Response error:', status, data);
        if (status === 401) {
          message = 'Tên đăng nhập hoặc mật khẩu không đúng.';
        } else if (status === 403) {
          message = 'Tài khoản bị khóa hoặc không có quyền.';
        } else if (status >= 500) {
          message = 'Lỗi server. Vui lòng thử lại sau.';
        } else {
          message = data.message || message;
        }
      } else {
        message = err.message || message;
      }
      setError(message);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div>
      <HeaderLogin isLoginPage={true} />
      <div className="container">
        <div className="left-section">
          <div className="left-content">
            <h1>HỆ THỐNG ĐỒ ÁN</h1>
            <p>Ứng dụng giúp quản lý thông tin Đồ Án nhanh chóng và dễ dàng.</p>
            <div className="app-image">
              <img src="/static/img/mobile.png" alt="Mobile Dashboard" className="dashboard-image" />
            </div>
            <div className="app-links">
              <a href="#">
                <img src="/static/img/appstore.png" alt="App Store" className="store-icon" />
              </a>
              <a href="#">
                <img src="/static/img/playstore.png" alt="Google Play" className="store-icon" />
              </a>
            </div>
          </div>
        </div>
        <div className="right-section">
          <div className={`login ${isLoading ? 'disabled' : ''}`} id="loginSection">
            <form onSubmit={handleSubmit}>
              <div className="input-group">
                <i className="fas fa-user"></i>
                <input
                  type="text"
                  id="username"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  placeholder="Tài khoản"
                  required
                />
              </div>
              <div className="input-group">
                <i className="fas fa-lock"></i>
                <input
                  type="password"
                  id="password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  placeholder="Mật mã"
                  required
                />
              </div>
              {error && (
                <div className="error-message" style={{ display: 'block' }}>
                  {error}
                </div>
              )}
              <button type="submit" disabled={isLoading}>
                Đăng nhập{' '}
                {isLoading && <i className="fas fa-spinner fa-spin" id="spinner"></i>}
              </button>
            </form>
            <a href="#">Đăng nhập không được? Xem hướng dẫn tại đây</a>
          </div>
        </div>
      </div>
      <FooterLogin />
    </div>
  );
}

export default LoginForm;
import React from 'react';
export default class AppErrorBoundary extends React.Component {
  state = { failed: false };
  static getDerivedStateFromError() { return { failed: true }; }
  render() {
    return this.state.failed ? <main className="container py-5"><h1>Không thể hiển thị trang</h1><p>Đã có lỗi khi xử lý dữ liệu. Vui lòng tải lại trang.</p><button className="btn btn-primary" onClick={() => window.location.reload()}>Tải lại</button><a className="btn btn-link" href="/">Về trang chủ</a></main> : this.props.children;
  }
}

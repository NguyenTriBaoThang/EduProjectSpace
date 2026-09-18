import React from 'react';
import { Link } from 'react-router-dom';
export default function NotFound() { return <main className="container py-5" data-page="/404"><h1>Không tìm thấy trang</h1><p>Đường dẫn không tồn tại hoặc đã thay đổi.</p><Link to="/">Về trang chủ</Link></main>; }

import { Navigate } from 'react-router-dom';

export default function RequireRole({ role, children }) {
  let user;
  try { user = JSON.parse(localStorage.getItem('user')); } catch { user = null; }
  if (!user) return <Navigate to="/login" replace />;
  if (user.roleName !== role) return <p>Bạn không có quyền truy cập trang này.</p>;
  return children;
}

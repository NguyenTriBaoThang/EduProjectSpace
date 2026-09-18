import React, { useEffect, useState } from 'react';
import { NavLink, useLocation, useNavigate } from 'react-router-dom';
import { api } from '../../api/client';
import '../../screens/student/workspace.css';

export default function WorkspaceShell({ title, menu, children }) {
  const location = useLocation();
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [error, setError] = useState('');
  useEffect(() => { const previous = document.title; document.title = title; return () => { document.title = previous; }; }, [title]);
  useEffect(() => { const expired = () => navigate('/login', { replace: true }); window.addEventListener('session-expired', expired); return () => window.removeEventListener('session-expired', expired); }, [navigate]);
  async function logout() {
    try { await api('/api/Auth/logout', { method: 'POST' }); localStorage.removeItem('user'); localStorage.removeItem('token'); navigate('/login'); }
    catch (e) { setError(e.message); }
  }
  return <div className="student-workspace" data-page={location.pathname}><aside className={open ? 'open' : ''}><h2>EduProjectSpace</h2><nav aria-label="Chức năng">{menu.map(([path, label]) => <NavLink key={path} to={path} onClick={() => setOpen(false)}>{label}</NavLink>)}</nav><button className="btn btn-outline-light mt-4" onClick={logout}>Đăng xuất</button>{error && <p role="alert">{error}</p>}</aside><main><header><button className="btn btn-outline-primary student-menu" aria-label="Mở menu" aria-expanded={open} onClick={() => setOpen(!open)}>☰</button><h1>{title}</h1></header><div className="student-panel">{children}</div></main></div>;
}

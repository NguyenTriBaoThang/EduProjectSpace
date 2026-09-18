import React, { useState } from 'react';
import { useLocation } from 'react-router-dom';
import WorkspaceShell from '../../components/workspace/WorkspaceShell';
import CrudPage from '../../components/workspace/CrudPage';
import DataTable from '../../components/workspace/DataTable';
import Resource from '../../components/workspace/Resource';
import useResource from '../../api/useResource';
import { api } from '../../api/client';
import { adminResources } from './adminResources';
import StatusChart from '../../components/workspace/StatusChart';
import * as XLSX from 'xlsx';

const menu = [['dashboard', 'Tổng quan'], ['users', 'Người dùng'], ['students', 'Sinh viên'], ['lecturers', 'Giảng viên'], ['semesters', 'Kỳ học'], ['courses', 'Học phần'], ['projects', 'Đề tài'], ['grading', 'Hội đồng'], ['notifications', 'Thông báo'], ['logs', 'Nhật ký'], ['settings', 'Phân quyền'], ['reports', 'Báo cáo']].map(([path, title]) => [`/admin/${path}`, title]);

function Dashboard() {
  const summary = useResource('/api/AdminDashboard/summary');
  const progress = useResource('/api/AdminDashboard/project-status');
  const notifications = useResource('/api/Notifications/recent');
  return <><Resource resource={summary}>{data => <><div className="student-stats"><div>{data.studentCount} sinh viên</div><div>{data.submittedProjects} đồ án đã nộp</div><div>{data.pendingTopics} đề tài chờ duyệt</div></div><button className="btn btn-outline-primary mb-3" onClick={() => { const book = XLSX.utils.book_new(); XLSX.utils.book_append_sheet(book, XLSX.utils.aoa_to_sheet([['Sinh viên', 'Đồ án đã nộp', 'Đề tài chờ duyệt'], [data.studentCount, data.submittedProjects, data.pendingTopics]]), 'TongQuan'); XLSX.writeFile(book, 'tong-quan.xlsx'); }}>Xuất Excel</button></>}</Resource><Resource resource={progress}>{data => <StatusChart labels={['Chưa nộp', 'Đã nộp', 'Đã chấm']} values={[data.notSubmitted || 0, data.submitted || 0, data.graded || 0]} />}</Resource><h2 className="mt-4">Thông báo gần đây</h2><Resource resource={notifications}>{rows => <DataTable rows={rows} columns={[{ key: 'title', label: 'Tiêu đề' }, { key: 'content', label: 'Nội dung' }, { key: 'createdAt', label: 'Ngày gửi', render: row => new Date(row.createdAt).toLocaleString('vi-VN') }]} />}</Resource></>;
}

function Reports() {
  const semesters = useResource('/api/AdminReports/semesters');
  const departments = useResource('/api/AdminReports/departments');
  const [semester, setSemester] = useState('');
  const [department, setDepartment] = useState('');
  const resource = useResource(`/api/AdminReports?${new URLSearchParams({ semesterCode: semester, facultyCode: department })}`);
  return <><div className="d-flex gap-3 mb-4"><Resource resource={semesters}>{rows => <label>Kỳ học<select className="form-select" value={semester} onChange={e => setSemester(e.target.value)}><option value="">Tất cả</option>{rows.map(row => <option key={row.id} value={row.name}>{row.name}</option>)}</select></label>}</Resource><Resource resource={departments}>{rows => <label>Khoa<select className="form-select" value={department} onChange={e => setDepartment(e.target.value)}><option value="">Tất cả</option>{rows.map(row => <option key={row.id} value={row.code}>{row.name}</option>)}</select></label>}</Resource></div>
    <Resource resource={resource}>{data => <><div className="student-stats"><div>{data.summary.studentCount} sinh viên</div><div>{data.summary.lecturerCount} giảng viên</div><div>{data.summary.approvedProjects} đề tài duyệt</div><div>{data.summary.pendingProjects} chờ duyệt</div></div><h2>Đề tài</h2><DataTable rows={data.projects} columns={[{ key: 'name', label: 'Đề tài' }, { key: 'studentName', label: 'Sinh viên' }, { key: 'lecturerName', label: 'Giảng viên' }, { key: 'status', label: 'Trạng thái' }]} /><h2 className="mt-4">Sinh viên</h2><DataTable rows={data.students} columns={[{ key: 'studentId', label: 'Mã sinh viên' }, { key: 'name', label: 'Họ tên' }, { key: 'classCode', label: 'Lớp' }, { key: 'facultyCode', label: 'Khoa' }]} /><h2 className="mt-4">Giảng viên</h2><DataTable rows={data.lecturers} columns={[{ key: 'lecturerId', label: 'Mã giảng viên' }, { key: 'name', label: 'Họ tên' }, { key: 'facultyCode', label: 'Khoa' }]} /></>}</Resource></>;
}
function NotificationSettings() {
  const resource = useResource('/api/Notifications/config');
  return <details className="mb-4"><summary>Cấu hình thông báo và email</summary><Resource resource={resource}>{data => <ConfigForm data={data} />}</Resource></details>;
}
function ConfigForm({ data }) {
  const [form, setForm] = useState({ ...data, smtpConfig: { host: '', port: 587, username: '', password: '', ...data.smtpConfig } });
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  return <form className="student-form mt-3" onSubmit={async e => { e.preventDefault(); if (busy) return; setBusy(true); setMessage(''); try { await api('/api/Notifications/config', { method: 'POST', body: form }); setMessage('Đã lưu cấu hình.'); setForm({ ...form, smtpConfig: { ...form.smtpConfig, password: '' } }); } catch (error) { setMessage(error.message); } finally { setBusy(false); } }}>
    {message && <p role="status">{message}</p>}{[['enableWeb', 'Thông báo trong ứng dụng'], ['enableEmail', 'Gửi email']].map(([key, label]) => <label key={key}>{label}<input type="checkbox" checked={Boolean(form[key])} onChange={e => setForm({ ...form, [key]: e.target.checked })} /></label>)}
    <label>Tần suất nhắc hạn<select className="form-select" value={form.reminderFrequency || 'none'} onChange={e => setForm({ ...form, reminderFrequency: e.target.value })}>{[['none', 'Tắt'], ['daily', 'Hằng ngày'], ['weekly', 'Hằng tuần']].map(([value, label]) => <option key={value} value={value}>{label}</option>)}</select></label>
    { [['host', 'Máy chủ SMTP', 'text'], ['port', 'Cổng', 'number'], ['username', 'Tài khoản SMTP', 'text'], ['password', 'Mật khẩu SMTP (để trống để giữ nguyên)', 'password']].map(([key, label, type]) => <label key={key}>{label}<input className="form-control" type={type} min={type === 'number' ? 1 : undefined} max={type === 'number' ? 65535 : undefined} value={form.smtpConfig[key]} onChange={e => setForm({ ...form, smtpConfig: { ...form.smtpConfig, [key]: type === 'number' ? Number(e.target.value) : e.target.value } })} /></label>)}<button className="btn btn-primary" disabled={busy}>Lưu cấu hình</button>
  </form>;
}
export default function AdminWorkspace() {
  const location = useLocation();
  const page = location.pathname.split('/').at(-1);
  const config = adminResources[page];
  return <WorkspaceShell title={menu.find(([path]) => path === location.pathname)?.[1] || 'Quản trị'} menu={menu}><div key={page}>{page === 'dashboard' ? <Dashboard /> : page === 'reports' ? <Reports /> : <>{page === 'notifications' && <NotificationSettings />}<CrudPage config={config} /></>}</div></WorkspaceShell>;
}

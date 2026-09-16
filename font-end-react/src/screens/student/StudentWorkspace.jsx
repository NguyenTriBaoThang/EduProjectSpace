import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Link, NavLink, useLocation, useNavigate, useSearchParams } from 'react-router-dom';
import { api, downloadFile } from '../../api/client';
import DataTable from '../../components/workspace/DataTable';
import pages from '../../pageManifest.json';
import './workspace.css';

const menu = [['dashboard', 'Tổng quan'], ['proposals-list', 'Đề xuất đề tài'], ['tracking-list', 'Tiến độ'], ['submissions-list', 'Nộp bài'], ['history-submissions-list', 'Lịch sử bài nộp'], ['grades-list', 'Điểm và phản hồi'], ['schedule', 'Lịch'], ['notifications-list', 'Thông báo']];
const date = value => value ? new Date(value).toLocaleString('vi-VN') : '—';
const status = value => ({ PENDING: 'Chờ duyệt', APPROVED: 'Đã duyệt', REJECTED: 'Từ chối', TODO: 'Chưa làm', INPROGRESS: 'Đang làm', DONE: 'Hoàn thành', SUBMITTED: 'Đã nộp', VALIDATED: 'Hợp lệ', PROPOSED: 'Đề xuất' }[String(value).toUpperCase()] || value || '—');
const link = (page, id) => `/student/${page}?projectId=${encodeURIComponent(id)}`;

function useResource(path) {
  const [state, setState] = useState({ loading: true, data: null, error: '' });
  const [revision, setRevision] = useState(0);
  const reload = useCallback(() => setRevision(value => value + 1), []);
  useEffect(() => {
    const controller = new AbortController();
    setState({ loading: true, data: null, error: '' });
    api(path, { signal: controller.signal }).then(data => {
      if (!controller.signal.aborted) setState({ loading: false, data, error: '' });
    }).catch(error => { if (!controller.signal.aborted) setState({ loading: false, data: null, error: error.message }); });
    return () => controller.abort();
  }, [path, revision]);
  return { ...state, reload };
}

function Resource({ resource, children }) {
  if (resource.loading) return <p role="status">Đang tải dữ liệu…</p>;
  if (resource.error) return <div role="alert" className="alert alert-danger">{resource.error} <button className="btn btn-outline-danger" onClick={resource.reload}>Thử lại</button></div>;
  return children(resource.data);
}

function Download({ path }) {
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  return <><button disabled={busy} className="btn btn-sm btn-outline-primary" onClick={async () => { setBusy(true); setError(''); try { await downloadFile(path); } catch (e) { setError(e.message); } finally { setBusy(false); } }}>Tải tệp</button>{error && <span role="alert">{error}</span>}</>;
}

function ProjectList({ mode }) {
  const resource = useResource('/api/student/projects');
  return <Resource resource={resource}>{rows => <>
    {mode === 'dashboard' && <div className="student-stats"><div><strong>{rows.length}</strong> đồ án</div><div><strong>{rows.reduce((sum, p) => sum + p.totalTasks, 0)}</strong> nhiệm vụ</div><div><strong>{rows.reduce((sum, p) => sum + p.doneTasks, 0)}</strong> hoàn thành</div></div>}
    {mode === 'proposals' && <Link className="btn btn-primary mb-3" to="/student/proposals-create">Gửi đề xuất</Link>}
    <DataTable rows={rows} columns={[
      { key: 'projectCode', label: 'Mã đồ án' }, { key: 'title', label: 'Đề tài' }, { key: 'courseName', label: 'Học phần' }, { key: 'groupName', label: 'Nhóm' },
      { key: 'approvalStatus', label: 'Trạng thái', render: p => status(p.approvalStatus) },
      { key: 'progress', label: 'Tiến độ', render: p => `${p.totalTasks ? Math.round(100 * p.doneTasks / p.totalTasks) : 0}%` },
      { key: 'action', label: 'Thao tác', render: p => <div className="d-flex gap-2 flex-wrap"><Link to={link(mode === 'proposals' ? 'proposals-detail' : 'tracking-details', p.id)}>Chi tiết</Link><Link to={link('submissions-week', p.id)}>Nộp bài</Link><Link to={link('grades-detail', p.id)}>Điểm</Link></div> }
    ]} />
    {!rows.length && <p>Bạn chưa được phân vào nhóm đồ án. Liên hệ giảng viên để được phân nhóm.</p>}
  </>}</Resource>;
}

function ProjectDetail({ projectId, proposal }) {
  const resource = useResource(`/api/student/projects/${encodeURIComponent(projectId)}`);
  return <Resource resource={resource}>{({ project, tasks, members, versions }) => <>
    <h2>{project.title}</h2><p>{project.courseName} · {project.groupName} · {status(project.approvalStatus)}</p>
    <p className="preserve-lines">{project.description}</p>{project.approvalReason && <p>Ý kiến giảng viên: {project.approvalReason}</p>}
    {proposal && String(project.approvalStatus).toUpperCase() !== 'APPROVED' && <Link className="btn btn-primary" to={link('proposals-create', project.id)}>Chỉnh sửa và gửi duyệt</Link>}
    <h3 className="mt-4">Nhiệm vụ</h3><DataTable rows={tasks} columns={[{ key: 'title', label: 'Nhiệm vụ' }, { key: 'description', label: 'Mô tả' }, { key: 'deadline', label: 'Hạn nộp', render: t => date(t.deadline) }, { key: 'status', label: 'Trạng thái', render: t => status(t.status) }, { key: 'action', label: 'Bài nộp', render: t => <Link to={`${link('submissions-week', project.id)}&taskId=${t.id}`}>Nộp bài</Link> }]} />
    <h3 className="mt-4">Thành viên</h3><ul>{members.map(m => <li key={m.studentId}>{m.fullName}{m.isLeader ? ' · Nhóm trưởng' : ''}</li>)}</ul>
    {proposal && <><h3>Lịch sử đề xuất</h3><DataTable rows={versions} columns={[{ key: 'versionNumber', label: 'Phiên bản' }, { key: 'title', label: 'Tiêu đề' }, { key: 'description', label: 'Mô tả' }, { key: 'createdAt', label: 'Ngày lưu', render: v => date(v.createdAt) }]} /></>}
  </>}</Resource>;
}

function ProposalForm({ projectId }) {
  const resource = useResource('/api/student/projects');
  return <Resource resource={resource}>{projects => <ProposalEditor projects={projects} projectId={projectId} />}</Resource>;
}
function ProposalEditor({ projects, projectId }) {
  const choices = projects.filter(p => String(p.approvalStatus).toUpperCase() !== 'APPROVED');
  const initial = choices.find(p => String(p.id) === projectId) || choices[0];
  const [id, setId] = useState(String(initial?.id || ''));
  const [title, setTitle] = useState(initial?.title || '');
  const [description, setDescription] = useState(initial?.description || '');
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const navigate = useNavigate();
  const pending = useRef(null);
  useEffect(() => () => pending.current?.abort(), []);
  if (!choices.length) return <p>Không có đồ án đang chờ đề xuất. Liên hệ giảng viên nếu cần phân nhóm hoặc thay đổi đề tài đã duyệt.</p>;
  async function submit(event) {
    event.preventDefault(); if (busy) return; setBusy(true); setError('');
    pending.current = new AbortController();
    try { await api(`/api/student/projects/${id}/proposal`, { method: 'PUT', body: { title, description }, signal: pending.current.signal }); navigate(link('proposals-detail', id)); }
    catch (e) { if (e.name !== 'AbortError') setError(e.message); } finally { setBusy(false); }
  }
  return <form onSubmit={submit} className="student-form">{error && <p role="alert" className="alert alert-danger">{error}</p>}
    <label>Nhóm / học phần<select className="form-select" value={id} onChange={e => { const p = choices.find(p => String(p.id) === e.target.value); setId(e.target.value); setTitle(p.title); setDescription(p.description || ''); }}>{choices.map(p => <option key={p.id} value={p.id}>{p.groupName} · {p.courseName}</option>)}</select></label>
    <label>Tiêu đề<input className="form-control" required minLength={3} maxLength={255} value={title} onChange={e => setTitle(e.target.value)} /></label>
    <label>Mô tả<textarea className="form-control" required minLength={10} maxLength={10000} rows={6} value={description} onChange={e => setDescription(e.target.value)} /></label>
    <button className="btn btn-primary" disabled={busy}>{busy ? 'Đang gửi…' : 'Gửi đề xuất'}</button>
  </form>;
}

const submissionColumns = [{ key: 'projectTitle', label: 'Đề tài' }, { key: 'taskTitle', label: 'Nhiệm vụ' }, { key: 'studentName', label: 'Người nộp' }, { key: 'submittedAt', label: 'Thời gian', render: s => date(s.submittedAt) }, { key: 'status', label: 'Trạng thái', render: s => status(s.status) }, { key: 'action', label: 'Chi tiết', render: s => <Link to={`/student/history-submissions-overview?submissionId=${s.id}`}>Xem bài nộp</Link> }];
function SubmissionList({ projectId, upload, taskId }) {
  const resource = useResource(`/api/student/submissions${projectId ? `?projectId=${encodeURIComponent(projectId)}` : ''}`);
  return <>{upload && <UploadForm projectId={projectId} taskId={taskId} onSaved={resource.reload} />}<Resource resource={resource}>{rows => <DataTable rows={rows} columns={submissionColumns} />}</Resource></>;
}
function UploadForm({ projectId, taskId, onSaved }) {
  const projects = useResource('/api/student/projects');
  return <Resource resource={projects}>{rows => <UploadEditor projects={rows} projectId={projectId} taskId={taskId} onSaved={onSaved} />}</Resource>;
}
function UploadEditor({ projects, projectId, taskId, onSaved }) {
  const [id, setId] = useState(projectId || String(projects[0]?.id || ''));
  const resource = useResource(`/api/student/projects/${encodeURIComponent(id || '0')}`);
  const [selectedTask, setTask] = useState(taskId || '');
  const [file, setFile] = useState(null);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  const fileInput = useRef(null);
  const pending = useRef(null);
  useEffect(() => () => pending.current?.abort(), []);
  async function submit(event) {
    event.preventDefault(); if (busy || !file) return;
    if (file.size > 20 * 1024 * 1024) { setMessage('Tệp vượt quá 20 MB.'); return; }
    setBusy(true); setMessage(''); pending.current = new AbortController();
    const body = new FormData(); body.append('projectId', id); if (selectedTask) body.append('taskId', selectedTask); body.append('file', file);
    try { await api('/api/student/submissions', { method: 'POST', body, signal: pending.current.signal }); setMessage('Nộp bài thành công.'); setFile(null); fileInput.current.value = ''; onSaved(); }
    catch (e) { if (e.name !== 'AbortError') setMessage(e.message); } finally { setBusy(false); }
  }
  if (!projects.length) return <p>Bạn chưa có nhóm đồ án để nộp bài.</p>;
  return <form onSubmit={submit} className="student-form mb-4"><h2>Nộp bài</h2>{message && <p role="status">{message}</p>}
    <label>Đồ án<select className="form-select" value={id} onChange={e => { setId(e.target.value); setTask(''); }}>{projects.map(p => <option key={p.id} value={p.id}>{p.title}</option>)}</select></label>
    <Resource resource={resource}>{data => <label>Nhiệm vụ<select className="form-select" value={selectedTask} onChange={e => setTask(e.target.value)}><option value="">Báo cáo đồ án</option>{data.tasks.map(t => <option key={t.id} value={t.id}>{t.title} · {date(t.deadline)}</option>)}</select></label>}</Resource>
    <label>Tệp bài nộp (tối đa 20 MB)<input ref={fileInput} className="form-control" type="file" required accept=".pdf,.docx,.xlsx,.zip,.txt,.png,.jpg,.jpeg" onChange={e => setFile(e.target.files[0] || null)} /></label>
    <button className="btn btn-primary" disabled={busy || resource.loading || Boolean(resource.error)}>{busy ? 'Đang nộp…' : 'Nộp bài'}</button>
  </form>;
}
function SubmissionDetail({ id }) {
  const resource = useResource(`/api/student/submissions/${encodeURIComponent(id)}`);
  return <Resource resource={resource}>{({ submission: s, versions, feedback }) => <><h2>{s.projectTitle}</h2><p>{s.taskTitle} · {status(s.status)} · {date(s.submittedAt)}</p><Download path={s.filePath} />
    <h3 className="mt-4">Phản hồi</h3>{feedback.length ? feedback.map(f => <article key={f.id}><strong>{f.lecturerName}</strong><p className="preserve-lines">{f.content}</p><small>{date(f.createdAt)}</small></article>) : <p>Chưa có phản hồi.</p>}
    <h3 className="mt-4">Phiên bản lưu trữ</h3><DataTable rows={versions} columns={[{ key: 'versionNumber', label: 'Phiên bản' }, { key: 'createdAt', label: 'Thời gian', render: v => date(v.createdAt) }, { key: 'download', label: 'Tệp', render: v => <Download path={v.filePath} /> }]} />
  </>}</Resource>;
}
function Grades({ projectId }) {
  const resource = useResource(`/api/student/grades${projectId ? `?projectId=${encodeURIComponent(projectId)}` : ''}`);
  return <Resource resource={resource}>{rows => <DataTable rows={rows} columns={[{ key: 'projectTitle', label: 'Đồ án' }, { key: 'criteria', label: 'Tiêu chí' }, { key: 'weight', label: 'Trọng số', render: g => `${Math.round(g.weight * 100)}%` }, { key: 'score', label: 'Điểm' }, { key: 'comment', label: 'Nhận xét' }, { key: 'lecturerName', label: 'Người chấm' }, { key: 'gradedAt', label: 'Thời gian', render: g => date(g.gradedAt) }]} />}</Resource>;
}
function Schedule() {
  const resource = useResource('/api/student/schedule');
  return <Resource resource={resource}>{rows => <DataTable rows={rows.map(e => ({ ...e, id: `${e.kind}-${e.id}` }))} columns={[{ key: 'title', label: 'Nội dung' }, { key: 'kind', label: 'Loại', render: e => e.kind === 'defense' ? 'Bảo vệ' : 'Họp nhóm' }, { key: 'startTime', label: 'Bắt đầu', render: e => date(e.startTime) }, { key: 'endTime', label: 'Kết thúc', render: e => date(e.endTime) }, { key: 'location', label: 'Địa điểm', render: e => /^https?:\/\//i.test(e.location) ? <a href={e.location} target="_blank" rel="noreferrer">Tham gia cuộc họp</a> : e.location }]} />}</Resource>;
}
function Notifications({ id }) {
  const resource = useResource('/api/Notifications');
  return <Resource resource={resource}>{data => {
    const rows = data.notifications || [];
    if (id) { const item = rows.find(n => String(n.id) === id); return item ? <article><h2>{item.title}</h2><p className="preserve-lines">{item.content}</p><small>{date(item.createdAt)}</small></article> : <p role="alert">Không tìm thấy thông báo.</p>; }
    return <DataTable rows={rows} columns={[{ key: 'title', label: 'Tiêu đề', render: n => <Link to={`/student/notification-detail?id=${n.id}`}>{n.title}</Link> }, { key: 'content', label: 'Nội dung' }, { key: 'createdAt', label: 'Ngày gửi', render: n => date(n.createdAt) }]} />;
  }}</Resource>;
}

export default function StudentWorkspace() {
  const location = useLocation();
  const navigate = useNavigate();
  const [params] = useSearchParams();
  const [sidebarOpen, setSidebarOpen] = useState(false);
  const [logoutError, setLogoutError] = useState('');
  const page = location.pathname.split('/').at(-1);
  const projectId = params.get('projectId');
  const title = pages.find(p => p.path === location.pathname)?.title?.split('|')[0] || 'Sinh viên';
  useEffect(() => { const old = document.title; document.title = title; return () => { document.title = old; }; }, [title]);
  useEffect(() => { const expired = () => navigate('/login', { replace: true }); window.addEventListener('session-expired', expired); return () => window.removeEventListener('session-expired', expired); }, [navigate]);
  let content;
  if (page === 'dashboard') content = <ProjectList mode="dashboard" />;
  else if (page === 'proposals-create') content = <ProposalForm projectId={projectId} />;
  else if (page === 'proposals-detail' || page === 'tracking-details') content = projectId ? <ProjectDetail projectId={projectId} proposal={page === 'proposals-detail'} /> : <ProjectList mode="proposals" />;
  else if (page === 'proposals-list' || page === 'tracking-list') content = <ProjectList mode={page === 'proposals-list' ? 'proposals' : 'tracking'} />;
  else if (page.startsWith('grades-')) content = <Grades projectId={projectId} />;
  else if (page === 'schedule') content = <Schedule />;
  else if (page.startsWith('notification')) content = <Notifications id={page === 'notification-detail' ? params.get('id') || params.get('notificationId') : null} />;
  else if (page === 'history-submissions-overview' && (params.get('submissionId') || params.get('id'))) content = <SubmissionDetail id={params.get('submissionId') || params.get('id')} />;
  else content = <SubmissionList projectId={projectId} taskId={params.get('taskId')} upload={!page.startsWith('history-')} />;
  return <div className="student-workspace" data-page={location.pathname}><aside className={sidebarOpen ? 'open' : ''}><h2>EduProjectSpace</h2><nav aria-label="Sinh viên">{menu.map(([path, label]) => <NavLink key={path} to={`/student/${path}`} onClick={() => setSidebarOpen(false)}>{label}</NavLink>)}</nav><button className="btn btn-outline-light mt-4" onClick={async () => { try { await api('/api/Auth/logout', { method: 'POST' }); localStorage.removeItem('user'); localStorage.removeItem('token'); navigate('/login'); } catch (e) { setLogoutError(e.message); } }}>Đăng xuất</button>{logoutError && <p role="alert">{logoutError}</p>}</aside><main><header><button className="btn btn-outline-primary student-menu" aria-label="Mở menu" aria-expanded={sidebarOpen} onClick={() => setSidebarOpen(!sidebarOpen)}>☰</button><h1>{title}</h1></header><div className="student-panel" key={location.pathname + location.search}>{content}</div></main></div>;
}

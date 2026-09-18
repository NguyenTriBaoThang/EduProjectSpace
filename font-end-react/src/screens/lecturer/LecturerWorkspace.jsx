import React, { useMemo, useState } from 'react';
import { Link, useLocation, useSearchParams } from 'react-router-dom';
import WorkspaceShell from '../../components/workspace/WorkspaceShell';
import CrudPage from '../../components/workspace/CrudPage';
import DataTable from '../../components/workspace/DataTable';
import RemoteTable from '../../components/workspace/RemoteTable';
import Resource from '../../components/workspace/Resource';
import ActionForm from '../../components/workspace/ActionForm';
import useResource from '../../api/useResource';
import { api, downloadFile } from '../../api/client';
import pages from '../../pageManifest.json';
import StatusChart from '../../components/workspace/StatusChart';

const menu = [['dashboard', 'Tổng quan'], ['courses', 'Học phần'], ['course-groups', 'Quản lý nhóm'], ['course-approvals', 'Duyệt đề tài'], ['tasks', 'Nhiệm vụ'], ['course-feedback', 'Phản hồi'], ['course-reviews', 'Chấm điểm'], ['course-resources', 'Tài liệu']].map(([path, label]) => [`/lecturer/${path}`, label]);
const col = (key, label, render) => ({ key, label, render });
const field = (key, label, extra = {}) => ({ key, label, required: true, ...extra });
const query = values => new URLSearchParams(Object.entries(values).filter(([, value]) => value !== null && value !== undefined)).toString();
const href = (page, values) => `/lecturer/${page}?${query(values)}`;
const date = value => value ? new Date(value).toLocaleString('vi-VN') : '—';
const courseColumns = [col('courseId', 'Mã học phần'), col('name', 'Học phần'), col('semester', 'Kỳ học'), col('facultyCode', 'Khoa'), col('projectCount', 'Đề tài')];
const projectColumns = [col('projectId', 'Mã đề tài'), col('name', 'Đề tài'), col('groupName', 'Nhóm'), col('status', 'Trạng thái')];

function FileButton({ path }) {
  const [error, setError] = useState('');
  return <><button className="btn btn-link" onClick={async () => { try { await downloadFile(path); } catch (e) { setError(e.message); } }}>Tải tệp</button>{error && <span role="alert">{error}</span>}</>;
}
function Dashboard() {
  const summary = useResource('/api/LecturerDashboard/summary');
  return <><Resource resource={summary}>{data => <><div className="student-stats"><div>{data.projectCount} đề tài</div><div>{data.approvedProjects} đã duyệt</div><div>{data.pendingProjects} chờ duyệt</div></div><StatusChart labels={['Đã duyệt', 'Chờ duyệt']} values={[data.approvedProjects || 0, data.pendingProjects || 0]} /><h2 className="mt-4">Thông báo</h2><DataTable rows={data.notifications || []} columns={[col('title', 'Tiêu đề'), col('content', 'Nội dung'), col('createdAt', 'Thời gian', row => date(row.createdAt))]} /></>}</Resource><h2 className="mt-4">Học phần</h2><Courses /></>;
}
function Courses({ mode = 'courses' }) {
  const endpoints = { groups: '/api/LecturerCourseGroup/courses', approval: '/api/LecturerProjectApproval', feedback: '/api/LecturerFeedback', reviews: '/api/LecturerReview', resources: '/api/LecturerResources', courses: '/api/LecturerCourses' };
  const destinations = { groups: 'groups', approval: 'approval', feedback: 'feedback', reviews: 'project-review', resources: 'resources', courses: 'projects' };
  return <RemoteTable endpoint={endpoints[mode]} select={data => data.courses || data} columns={[...courseColumns, col('action', 'Thao tác', row => <Link to={href(destinations[mode], { courseId: row.courseId, semester: row.semester, facultyCode: row.facultyCode })}>Mở học phần</Link>)]} />;
}
function Projects({ courseId, mode = 'courses' }) {
  const endpoints = { courses: `/api/LecturerCourses/projects?${query({ courseId })}`, feedback: `/api/LecturerFeedback/projects?${query({ courseId })}`, reviews: `/api/LecturerReview/courses/${encodeURIComponent(courseId)}/projects` };
  const destinations = { courses: 'project-progress', feedback: 'feedback-detail', reviews: 'final-review' };
  return <RemoteTable endpoint={endpoints[mode]} columns={[...projectColumns, col('action', 'Chi tiết', row => <div className="d-flex gap-2"><Link to={href(destinations[mode], { projectId: row.projectId, courseId })}>Chi tiết</Link><Link to={href('final-review', { projectId: row.projectId, courseId })}>Chấm điểm</Link></div>)]} />;
}
function Approval({ courseId }) {
  const resource = useResource(`/api/LecturerProjectApproval/course?${query({ courseId })}`);
  return <Resource resource={resource}>{rows => rows.length ? rows.map(project => <article className="border rounded p-3 mb-3" key={project.id}><h2>{project.name}</h2><p>{project.groupName} · {project.approvalStatus}</p><p className="preserve-lines">{project.description}</p><p>{(project.students || []).map(s => s.fullName).join(', ')}</p><ActionForm key={`${project.id}-${project.approvalStatus}`} title="Lưu duyệt đề tài" endpoint={`/api/LecturerProjectApproval/${encodeURIComponent(project.projectId)}`} method="PUT" initial={{ approvalStatus: project.approvalStatus, approvalReason: project.approvalReason || '' }} fields={[field('approvalStatus', 'Quyết định', { options: [['PENDING', 'Chờ duyệt'], ['APPROVED', 'Duyệt'], ['REJECTED', 'Từ chối']].map(([value, label]) => ({ value, label })) }), field('approvalReason', 'Nhận xét', { type: 'textarea', required: false })]} onSaved={resource.reload} /></article>) : <p>Không có đề tài cần duyệt.</p>}</Resource>;
}
function Tasks({ courseId }) {
  const config = useMemo(() => ({ name: 'Nhiệm vụ', endpoint: '/api/LecturerTask', listPath: `/api/LecturerTask?${query({ courseId })}`, fields: [field('courseId', 'Học phần', { hidden: true, default: courseId }), field('projectId', 'Đề tài', { createOnly: true }), field('taskDescription', 'Nội dung nhiệm vụ', { type: 'textarea', maxLength: 255 }), field('startDate', 'Bắt đầu', { type: 'datetime-local', createOnly: true, required: false }), field('dueDate', 'Hạn nộp', { type: 'datetime-local' }), field('status', 'Trạng thái', { editOnly: true, options: ['TODO', 'IN_PROGRESS', 'DONE'].map(value => ({ value, label: value })) })], columns: [col('projectId', 'Đề tài'), col('taskDescription', 'Nhiệm vụ'), col('dueDate', 'Hạn nộp', row => date(row.dueDate)), col('status', 'Trạng thái')], lookups: { projectId: { path: `/api/LecturerCourses/projects?${query({ courseId })}`, value: 'projectId' } } }), [courseId]);
  return <CrudPage config={config} />;
}
function CourseChooser({ initialCourse, children }) {
  const resource = useResource('/api/LecturerCourses');
  const [selected, setSelected] = useState(initialCourse || '');
  return <Resource resource={resource}>{rows => <><label className="mb-3">Học phần<select className="form-select" value={selected} onChange={e => setSelected(e.target.value)}><option value="">Chọn học phần</option>{rows.map(row => <option key={row.courseId} value={row.courseId}>{row.name} · {row.semester}</option>)}</select></label>{selected ? <div key={selected}>{children(selected)}</div> : <p>Chọn học phần để tiếp tục.</p>}</>}</Resource>;
}
function Progress({ projectId }) {
  const endpoint = `/api/LecturerCourses/projects/${encodeURIComponent(projectId)}/tasks`;
  const config = useMemo(() => ({ name: 'Tiến độ', endpoint, canCreate: false, canDelete: false, fields: [field('title', 'Nhiệm vụ'), field('description', 'Mô tả', { type: 'textarea', required: false }), field('deadline', 'Hạn nộp', { type: 'datetime-local', required: false }), field('status', 'Trạng thái', { options: ['TODO', 'IN_PROGRESS', 'DONE'].map(value => ({ value, label: value })) })], columns: [col('title', 'Nhiệm vụ'), col('description', 'Mô tả'), col('deadline', 'Hạn nộp', row => date(row.deadline)), col('status', 'Trạng thái'), col('submissions', 'Bài nộp', row => (row.submissions || []).map(s => <div key={s.id}>{s.submittedBy}<FileButton path={s.filePath} /></div>))] }), [endpoint]);
  return <CrudPage config={config} />;
}
function Feedback({ projectId }) {
  const endpoint = `/api/LecturerFeedback/projects/${encodeURIComponent(projectId)}`;
  const resource = useResource(endpoint);
  return <Resource resource={resource}>{data => <><h2>{data.name}</h2><p>{data.groupName} · {data.groupMembers}</p>{(data.taskSubmissionGroups || []).map(task => <article key={task.taskId}><h3>{task.taskTitle}</h3><p>{task.taskDescription}</p>{task.submissions.map(submission => <div className="border p-3 mb-3" key={submission.submissionId}><p>{submission.fileName} · {submission.submittedBy} · {submission.submittedAt}</p><ActionForm title="Lưu phản hồi" endpoint={`${endpoint}/feedback`} initial={{ content: submission.feedback || '' }} fields={[field('content', 'Phản hồi', { type: 'textarea' })]} prepare={value => [{ submissionId: submission.submissionId, content: value.content }]} onSaved={resource.reload} /></div>)}</article>)}</>}</Resource>;
}
function Review({ projectId }) {
  const endpoint = `/api/LecturerReview/projects/${encodeURIComponent(projectId)}`;
  const resource = useResource(endpoint);
  return <Resource resource={resource}>{data => <><h2>{data.name}</h2><p>{data.groupName} · {data.groupMembers}</p><GradeEditor data={data} endpoint={`${endpoint}/grades`} onSaved={resource.reload} />{(data.tasks || []).map(task => <article key={task.id}><h3>{task.title}</h3><p>{task.description}</p>{task.submissions.map(s => <div key={s.id}>{s.fullName} · {s.fileName}<FileButton path={s.filePath} /><p>{s.feedback}</p></div>)}</article>)}<h3>Lịch sử điểm</h3><RemoteTable endpoint={`${endpoint}/history`} columns={[col('fullName', 'Sinh viên'), col('versionNumber', 'Phiên bản'), col('totalScore', 'Điểm'), col('comment', 'Nhận xét'), col('createdAt', 'Ngày chấm', row => date(row.createdAt))]} /></>}</Resource>;
}
function GradeEditor({ data, endpoint, onSaved }) {
  const [grades, setGrades] = useState((data.studentGrades || []).map(student => ({ ...student, comment: '', criteriaGrades: student.criteriaGrades.map(criterion => ({ ...criterion, score: criterion.score ?? '' })) })));
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  if (!grades.length) return <p>Chưa có sinh viên hoặc tiêu chí chấm điểm.</p>;
  return <form onSubmit={async e => { e.preventDefault(); if (busy) return; setBusy(true); try { await api(endpoint, { method: 'POST', body: { studentGrades: grades.map(s => ({ studentId: s.studentId, comment: s.comment, criteriaGrades: s.criteriaGrades.map(c => ({ criteriaId: c.criteriaId, score: Number(c.score) })) })) } }); setMessage('Đã lưu điểm.'); onSaved(); } catch (error) { setMessage(error.message); } finally { setBusy(false); } }}>
    {message && <p role="status">{message}</p>}{grades.map((student, si) => <fieldset key={student.studentId} className="border rounded p-3 mb-3"><legend>{student.fullName}</legend>{student.criteriaGrades.map((criterion, ci) => <label className="d-block mb-2" key={criterion.criteriaId}>{criterion.criteriaName} ({criterion.weight * 100}%)<input className="form-control" type="number" min="0" max="10" step="0.1" required value={criterion.score} onChange={e => setGrades(grades.map((s, i) => i !== si ? s : { ...s, criteriaGrades: s.criteriaGrades.map((c, j) => j !== ci ? c : { ...c, score: e.target.value }) }))} /></label>)}<label>Nhận xét<textarea className="form-control" value={student.comment} onChange={e => setGrades(grades.map((s, i) => i !== si ? s : { ...s, comment: e.target.value }))} /></label></fieldset>)}<button className="btn btn-primary mb-4" disabled={busy}>Lưu điểm</button>
  </form>;
}
function Groups({ courseId }) {
  const groups = useResource(`/api/LecturerCourseGroup/groups?${query({ courseId })}`);
  const students = useResource(`/api/LecturerCourseGroup/ungrouped-students?${query({ courseId })}`);
  const projects = useResource(`/api/LecturerCourseGroup/projects?${query({ courseId })}`);
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  const reload = () => { groups.reload(); students.reload(); projects.reload(); };
  async function action(name, values) { if (busy) return; setBusy(true); try { await api(`/api/LecturerCourseGroup/${name}?${query(values)}`, { method: 'POST' }); reload(); } catch (e) { setMessage(e.message); } finally { setBusy(false); } }
  return <><ActionForm title="Tạo nhóm" endpoint={value => `/api/LecturerCourseGroup/add-group?${query({ groupName: value.groupName, courseId })}`} fields={[field('groupName', 'Tên nhóm')]} onSaved={reload} /><ActionForm title="Chia nhóm tự động" endpoint="/api/LecturerCourseGroup/auto-group" initial={{ groupSize: 3 }} fields={[field('groupSize', 'Số thành viên tối đa', { type: 'number', min: 1, max: 20 })]} prepare={value => ({ courseId, groupSize: Number(value.groupSize) })} onSaved={reload} />{message && <p role="alert">{message}</p>}
    <Resource resource={students}>{studentRows => <Resource resource={projects}>{projectRows => <Resource resource={groups}>{rows => rows.map(group => <article key={group.id} className="border rounded p-3 mb-3"><h2>{group.name}</h2><p>{group.projectName}</p><ActionForm title="Đổi tên nhóm" endpoint={value => `/api/LecturerCourseGroup/update-group-name?${query({ groupId: group.id, newGroupName: value.name })}`} initial={{ name: group.name }} fields={[field('name', 'Tên nhóm')]} onSaved={reload} />
      <ActionForm title="Thêm thành viên" endpoint={value => `/api/LecturerCourseGroup/add-to-group?${query({ groupId: group.id, studentId: value.studentId, groupSize: value.groupSize })}`} fields={[field('studentId', 'Sinh viên', { options: studentRows.map(s => ({ value: s.id, label: `${s.username} · ${s.name}` })) }), field('groupSize', 'Số thành viên tối đa', { type: 'number', min: 1, max: 20 })]} initial={{ groupSize: 3 }} onSaved={reload} />
      <ActionForm title="Gán đề tài" endpoint={value => `/api/LecturerCourseGroup/assign-project?${query({ groupId: group.id, projectId: value.projectId })}`} fields={[field('projectId', 'Đề tài', { options: projectRows.map(p => ({ value: p.projectId, label: p.name })) })]} initial={{ projectId: group.projectId }} onSaved={reload} />
      <DataTable rows={group.members || []} columns={[col('username', 'Mã sinh viên'), col('name', 'Họ tên'), col('isLeader', 'Nhóm trưởng', s => s.isLeader ? 'Có' : 'Không'), col('actions', 'Thao tác', s => <div className="d-flex gap-2"><button className="btn btn-outline-primary" disabled={busy} onClick={() => action('toggle-leader', { groupId: group.id, studentId: s.id })}>Đổi trưởng nhóm</button><button className="btn btn-outline-danger" disabled={busy} onClick={() => { if (window.confirm('Bỏ sinh viên khỏi nhóm?')) action('remove-from-group', { groupId: group.id, studentId: s.id }); }}>Bỏ khỏi nhóm</button></div>)]} /><button className="btn btn-outline-danger mt-3" disabled={busy} onClick={() => { if (window.confirm('Xóa nhóm này?')) action('delete-group', { groupId: group.id }); }}>Xóa nhóm</button>
    </article>)}</Resource>}</Resource>}</Resource>
  </>;
}
function Resources({ courseId }) {
  const [revision, setRevision] = useState(0);
  const projects = useResource(`/api/LecturerCourses/projects?${query({ courseId })}`);
  const config = useMemo(() => ({ name: 'Tài liệu', endpoint: '/api/LecturerResources/resources', listPath: `/api/LecturerResources/resources?${query({ courseId })}`, fields: [field('projectId', 'Đề tài', { createOnly: true }), field('title', 'Tiêu đề'), field('type', 'Loại', { options: ['Link', 'PDF', 'Video'].map(value => ({ value, label: value })) }), field('link', 'Liên kết tài liệu')], columns: [col('projectName', 'Đề tài'), col('groupName', 'Nhóm'), col('title', 'Tài liệu'), col('type', 'Loại'), col('link', 'Mở', row => /^https?:\/\//i.test(row.link) ? <a href={row.link} target="_blank" rel="noreferrer">Mở tài liệu</a> : <FileButton path={row.link} />)], lookups: { projectId: { path: `/api/LecturerCourses/projects?${query({ courseId })}`, value: 'projectId' } } }), [courseId]);
  return <><Resource resource={projects}>{rows => <ResourceUpload projects={rows} onSaved={() => setRevision(value => value + 1)} />}</Resource><CrudPage key={revision} config={config} /><Resource resource={projects}>{rows => <Suggestions projects={rows} onSaved={() => setRevision(value => value + 1)} />}</Resource></>;
}
function ResourceUpload({ projects, onSaved }) {
  const [projectId, setProject] = useState(projects[0]?.projectId || '');
  const [title, setTitle] = useState(''); const [type, setType] = useState('PDF');
  const [file, setFile] = useState(null); const [busy, setBusy] = useState(false); const [message, setMessage] = useState('');
  return <form className="student-form mb-4" onSubmit={async e => { e.preventDefault(); if (busy || !file) return; if (file.size > 50 * 1024 * 1024) { setMessage('Tệp tối đa 50 MB.'); return; } setBusy(true); try { const body = new FormData(); body.append('file', file); body.append('projectId', projectId); body.append('title', title); body.append('type', type); const result = await api('/api/LecturerResources/upload', { method: 'POST', body }); await api('/api/LecturerResources/resources', { method: 'POST', body: { projectId, title, type, link: result.filePath } }); setMessage('Đã lưu tài liệu.'); onSaved(); } catch (error) { setMessage(error.message); } finally { setBusy(false); } }}><h2>Tải tài liệu lên</h2>{message && <p role="status">{message}</p>}<label>Đề tài<select required className="form-select" value={projectId} onChange={e => setProject(e.target.value)}><option value="">Chọn đề tài</option>{projects.map(p => <option key={p.projectId} value={p.projectId}>{p.name}</option>)}</select></label><label>Tiêu đề<input required className="form-control" value={title} onChange={e => setTitle(e.target.value)} /></label><label>Loại<select className="form-select" value={type} onChange={e => setType(e.target.value)}><option>PDF</option><option>Video</option></select></label><label>Tệp<input type="file" required accept=".pdf,.mp4,.avi,.webm" className="form-control" onChange={e => setFile(e.target.files[0])} /></label><button className="btn btn-primary" disabled={busy}>Tải lên</button></form>;
}
function Suggestions({ projects, onSaved }) {
  const [projectId, setProject] = useState(projects[0]?.projectId || ''); const [keywords, setKeywords] = useState(''); const [rows, setRows] = useState([]); const [selected, setSelected] = useState([]); const [busy, setBusy] = useState(false); const [message, setMessage] = useState('');
  return <section className="mt-4"><h2>Gợi ý tài liệu</h2><form className="student-form" onSubmit={async e => { e.preventDefault(); if (busy) return; setBusy(true); setMessage(''); try { setRows(await api('/api/LecturerResources/suggestions', { method: 'POST', body: { projectId, keywords } })); setSelected([]); } catch (error) { setMessage(error.message); } finally { setBusy(false); } }}><label>Đề tài<select required className="form-select" value={projectId} onChange={e => setProject(e.target.value)}><option value="">Chọn đề tài</option>{projects.map(p => <option key={p.projectId} value={p.projectId}>{p.name}</option>)}</select></label><label>Từ khóa<input required className="form-control" value={keywords} onChange={e => setKeywords(e.target.value)} /></label><button className="btn btn-outline-primary" disabled={busy}>Tìm gợi ý</button></form>{message && <p role="status">{message}</p>}{rows.map((row, i) => <label className="d-block mt-2" key={i}><input type="checkbox" checked={selected.includes(i)} onChange={e => setSelected(e.target.checked ? [...selected, i] : selected.filter(n => n !== i))} /> {row.content}</label>)}{rows.length > 0 && <button className="btn btn-primary mt-3" disabled={busy || !selected.length} onClick={async () => { setBusy(true); try { await api('/api/LecturerResources/save-suggestions', { method: 'POST', body: selected.map(i => rows[i]) }); setMessage('Đã lưu tài liệu được chọn.'); onSaved(); } catch (e) { setMessage(e.message); } finally { setBusy(false); } }}>Lưu gợi ý đã chọn</button>}</section>;
}
export default function LecturerWorkspace() {
  const location = useLocation(); const [search] = useSearchParams();
  const page = location.pathname.split('/').at(-1); const courseId = search.get('courseId'); const projectId = search.get('projectId');
  const title = pages.find(p => p.path === location.pathname)?.title?.split('|')[0] || 'Giảng viên';
  let content;
  const modes = { 'course-groups': 'groups', 'course-approvals': 'approval', 'course-feedback': 'feedback', 'course-reviews': 'reviews', 'course-resources': 'resources' };
  if (page === 'dashboard') content = <Dashboard />;
  else if (modes[page]) content = <Courses mode={modes[page]} />;
  else if (page === 'tasks') content = <CourseChooser initialCourse={courseId}>{id => <Tasks courseId={id} />}</CourseChooser>;
  else if (page === 'groups' && courseId) content = <Groups courseId={courseId} />;
  else if (page === 'resources' && courseId) content = <Resources courseId={courseId} />;
  else if (page === 'approval' && courseId) content = <Approval courseId={courseId} />;
  else if (page === 'project-progress' && projectId) content = <Progress projectId={projectId} />;
  else if (page === 'feedback-detail' && projectId) content = <Feedback projectId={projectId} />;
  else if ((page === 'final-review' || page === 'project-review') && projectId) content = <Review projectId={projectId} />;
  else if (['projects', 'feedback', 'project-review'].includes(page) && courseId) content = <Projects courseId={courseId} mode={page === 'feedback' ? 'feedback' : page === 'project-review' ? 'reviews' : 'courses'} />;
  else content = <Courses />;
  return <WorkspaceShell title={title} menu={menu}><div key={location.pathname + location.search}>{content}</div></WorkspaceShell>;
}

import React, { useState } from 'react';
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

const menu = [['dashboard', 'Tổng quan'], ['course-list', 'Học phần'], ['course-assign', 'Phân công hướng dẫn'], ['lecturer-assign', 'Giảng viên'], ['progress-courses', 'Tiến độ'], ['grade-criteria', 'Tiêu chí chấm điểm'], ['grading-courses', 'Duyệt điểm'], ['defense-list', 'Lịch bảo vệ'], ['google-meet', 'Lịch họp']].map(([path, name]) => [`/head/${path}`, name]);
const col = (key, label, render) => ({ key, label, render });
const field = (key, label, extra = {}) => ({ key, label, required: true, ...extra });
const query = values => new URLSearchParams(Object.entries(values).filter(([, value]) => value !== null && value !== undefined)).toString();
const date = value => value ? new Date(value).toLocaleString('vi-VN') : '—';
const courseColumns = [col('courseId', 'Mã học phần'), col('name', 'Học phần'), col('semester', 'Kỳ học'), col('facultyCode', 'Khoa')];
const groupColumns = [col('name', 'Nhóm'), col('projectName', 'Đề tài'), col('members', 'Thành viên'), col('lecturer', 'Giảng viên'), col('status', 'Trạng thái')];
const criteriaConfig = {
  name: 'Tiêu chí', endpoint: '/api/head/criteria', fields: [field('courseId', 'Học phần', { numeric: true }), field('name', 'Tên tiêu chí', { maxLength: 100 }), field('weight', 'Trọng số (0–1)', { type: 'number', numeric: true, min: 0.001, max: 1, step: 0.001 }), field('description', 'Mô tả', { type: 'textarea', maxLength: 500, required: false })],
  columns: [col('courseName', 'Học phần'), col('name', 'Tiêu chí'), col('weight', 'Trọng số', row => `${row.weight * 100}%`), col('description', 'Mô tả')],
  lookups: { courseId: { path: '/api/HeadGradeCriteria/courses' } }
};
const defenseConfig = {
  name: 'Lịch bảo vệ', endpoint: '/api/head/defenses',
  fields: [field('projectId', 'Đề tài', { numeric: true }), field('startTime', 'Bắt đầu', { type: 'datetime-local' }), field('endTime', 'Kết thúc', { type: 'datetime-local' }), field('room', 'Phòng', { maxLength: 50 }), field('meetingId', 'Cuộc họp', { numeric: true, required: false })],
  columns: [col('projectName', 'Đề tài'), col('groupName', 'Nhóm'), col('startTime', 'Bắt đầu', row => date(row.startTime)), col('endTime', 'Kết thúc', row => date(row.endTime)), col('room', 'Phòng')],
  lookups: { projectId: { path: '/api/head/defenses/projects' }, meetingId: { path: '/api/head/meetings' } },
  validate: row => row.endTime <= row.startTime ? 'Giờ kết thúc phải sau giờ bắt đầu.' : ''
};
const meetingConfig = {
  name: 'Lịch họp', endpoint: '/api/head/meetings',
  fields: [field('name', 'Tiêu đề'), field('groupId', 'Nhóm', { numeric: true }), field('startTime', 'Bắt đầu', { type: 'datetime-local' }), field('endTime', 'Kết thúc', { type: 'datetime-local' }), field('location', 'Địa điểm / liên kết họp')],
  columns: [col('name', 'Tiêu đề'), col('groupName', 'Nhóm'), col('startTime', 'Bắt đầu', row => date(row.startTime)), col('endTime', 'Kết thúc', row => date(row.endTime)), col('location', 'Địa điểm', row => /^https?:\/\//i.test(row.location) ? <a href={row.location} target="_blank" rel="noreferrer">Mở cuộc họp</a> : row.location)],
  lookups: { groupId: { path: '/api/head/groups' } },
  validate: row => row.endTime <= row.startTime ? 'Giờ kết thúc phải sau giờ bắt đầu.' : ''
};
function Files({ files = [] }) {
  const [error, setError] = useState('');
  return <>{error && <p role="alert">{error}</p>}<ul>{files.map((file, i) => <li key={file.filePath || i}>{file.fullName || file.studentCode} <button className="btn btn-link" onClick={async () => { try { await downloadFile(file.filePath); } catch (e) { setError(e.message); } }}>Tải bài nộp</button></li>)}</ul></>;
}
function Assignment({ courseId }) {
  const students = useResource(`/api/HeadCourseAssignment/students?${query({ courseId })}`);
  const lecturers = useResource(`/api/HeadCourseAssignment/lecturers?${query({ courseId })}`);
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  return <Resource resource={lecturers}>{list => <Resource resource={students}>{rows => <>
    <ActionForm title="Phân công giảng viên" endpoint={`/api/HeadCourseAssignment/assign?${query({ courseId })}`} fields={[field('studentId', 'Sinh viên'), field('lecturerName', 'Giảng viên')]} options={{ studentId: rows.map(s => ({ value: s.id, label: `${s.studentCode} · ${s.fullName}` })), lecturerName: list.map(l => ({ value: l.fullName, label: l.fullName })) }} prepare={value => ({ ...value, studentId: Number(value.studentId) })} onSaved={students.reload} />
    <ActionForm title="Phân công tự động" endpoint={`/api/HeadCourseAssignment/auto-assign?${query({ courseId })}`} fields={[field('lecturers', 'Giảng viên tham gia', { multiple: true, numeric: true })]} options={{ lecturers: list.map(l => ({ value: l.id, label: l.fullName })) }} prepare={value => value.lecturers} onSaved={students.reload} />
    <label>Nhập phân công từ Excel<input className="form-control" type="file" accept=".xlsx" disabled={busy} onChange={async e => { const file = e.target.files[0]; if (!file) return; setBusy(true); const body = new FormData(); body.append('file', file); try { await api(`/api/HeadCourseAssignment/import?${query({ courseId })}`, { method: 'POST', body }); setMessage('Đã nhập phân công.'); students.reload(); } catch (error) { setMessage(error.message); } finally { setBusy(false); } }} /></label>{message && <p role="status">{message}</p>}
    <DataTable rows={rows} columns={[col('studentCode', 'Mã sinh viên'), col('fullName', 'Họ tên'), col('lecturerName', 'Giảng viên hướng dẫn')]} />
  </>}</Resource>}</Resource>;
}
function Details({ mode, params }) {
  const routes = { progress: '/api/HeadProgressCourses/details', grading: '/api/HeadCourseGrading/group-details', group: '/api/HeadLecturer/groupdetails' };
  const resource = useResource(`${routes[mode]}?${query(params)}`);
  return <Resource resource={resource}>{data => <>
    <h2>{data.projectName}</h2><p>{data.groupName} · {data.lecturer || data.lecturerName} · {data.status}</p><p className="preserve-lines">{data.description}</p>
    {mode === 'progress' && (data.phases || []).map((phase, i) => <article key={i}><h3>{phase.phase}</h3><p>{phase.description}</p><p>Hạn: {phase.deadline} · Nộp: {phase.date}</p><Files files={phase.files} /></article>)}
    {mode === 'group' && <><DataTable rows={(data.members || []).map(m => ({ ...m, id: m.studentId }))} columns={[col('studentId', 'Mã sinh viên'), col('studentName', 'Họ tên')]} /><Files files={data.files} /></>}
    {mode === 'grading' && <><DataTable rows={(data.members || []).map(m => ({ ...m, id: m.studentId }))} columns={[col('fullName', 'Sinh viên'), col('totalScore', 'Tổng điểm'), col('councilFeedback', 'Nhận xét hội đồng')]} /><Files files={data.grades?.reportFiles} /><ActionForm title="Duyệt điểm" endpoint="/api/HeadCourseGrading/approve-grade" fields={[field('councilFeedback', 'Nhận xét hội đồng', { type: 'textarea' })]} prepare={value => ({ ...params, ...value, groupId: Number(params.groupId) })} onSaved={resource.reload} /></>}
  </>}</Resource>;
}
function Summary() {
  const resource = useResource('/api/HeadDashboard/summary');
  return <Resource resource={resource}>{data => <div className="student-stats"><div>{data.projectCount} đề tài</div><div>{data.approvedProjects} đã duyệt</div><div>{data.pendingProjects} chờ duyệt</div></div>}</Resource>;
}
export default function HeadWorkspace() {
  const location = useLocation();
  const [search] = useSearchParams();
  const page = location.pathname.split('/').at(-1);
  const params = Object.fromEntries(search);
  const title = pages.find(p => p.path === location.pathname)?.title?.split('|')[0] || 'Trưởng bộ môn';
  const href = (name, values) => `/head/${name}?${query(values)}`;
  let content;
  if (page === 'dashboard') content = <Summary />;
  else if (page === 'grade-criteria') content = <CrudPage config={criteriaConfig} />;
  else if (page === 'google-meet') content = <CrudPage config={meetingConfig} />;
  else if (['defense', 'defense-add', 'defense-edit'].includes(page)) content = <CrudPage config={defenseConfig} initialCreate={page === 'defense-add'} initialId={page === 'defense-edit' ? params.id || params.scheduleId : undefined} />;
  else if (page === 'assign' && params.courseId) content = <Assignment courseId={params.courseId} />;
  else if (['course-list', 'course-assign', 'assign'].includes(page)) content = <RemoteTable endpoint="/api/HeadCourseAssignment" columns={[...courseColumns, col('studentCount', 'Sinh viên'), col('assignedCount', 'Đã phân công'), col('action', 'Thao tác', row => <Link to={href('assign', { courseId: row.courseId })}>Phân công</Link>)]} />;
  else if (page === 'lecturer-assign') content = <RemoteTable endpoint="/api/HeadLecturer" columns={[col('lecturer', 'Giảng viên'), col('courseCode', 'Học phần'), col('semesterName', 'Kỳ học'), col('studentCount', 'Sinh viên'), col('groupCount', 'Nhóm'), col('action', 'Chi tiết', row => <Link to={href('lecturer-details', { lecturer: row.lecturer, courseId: row.courseCode, semester: row.semesterName, facultyCode: row.facultyCode })}>Xem nhóm</Link>)]} />;
  else if (page === 'lecturer-details') content = <RemoteTable endpoint={`/api/HeadLecturer/groups?${query(params)}`} columns={[col('groupName', 'Nhóm'), col('projectName', 'Đề tài'), col('studentNames', 'Thành viên'), col('action', 'Chi tiết', row => <Link to={href('group-details', { ...params, groupId: row.groupId })}>Xem chi tiết</Link>)]} />;
  else if (page === 'group-details') content = <Details mode="group" params={params} />;
  else if (page === 'progress-details') content = <Details mode="progress" params={params} />;
  else if (page === 'grading-details') content = <Details mode="grading" params={params} />;
  else if (page === 'defense-list') content = <RemoteTable endpoint="/api/HeadDefenseSchedule/courses" columns={[...courseColumns, col('classId', 'Lớp'), col('scheduledCount', 'Đã có lịch'), col('action', 'Thao tác', row => <Link to={href('defense', { courseId: row.courseId })}>Quản lý lịch</Link>)]} />;
  else if (page === 'progress-courses' || page === 'grading-courses') {
    const grading = page === 'grading-courses';
    content = <RemoteTable endpoint={grading ? '/api/HeadCourseGrading/courses-for-grading' : '/api/HeadProgressCourses'} columns={[...courseColumns, col('groupCount', 'Số nhóm'), col('action', 'Thao tác', row => <Link to={href(grading ? 'grading' : 'progress', { courseId: row.courseId, semester: row.semester, facultyCode: row.facultyCode })}>Xem nhóm</Link>)]} />;
  } else {
    const grading = page === 'grading';
    content = <RemoteTable endpoint={`${grading ? '/api/HeadCourseGrading/groups-for-grading' : '/api/HeadProgressCourses/group'}?${query(params)}`} columns={[...groupColumns, ...(grading ? [col('grade', 'Điểm'), col('approved', 'Duyệt')] : []), col('action', 'Chi tiết', row => <Link to={href(grading ? 'grading-details' : 'progress-details', { ...params, groupId: row.id })}>Xem chi tiết</Link>)]} />;
  }
  return <WorkspaceShell title={title} menu={menu}><div key={location.pathname + location.search}>{content}</div></WorkspaceShell>;
}

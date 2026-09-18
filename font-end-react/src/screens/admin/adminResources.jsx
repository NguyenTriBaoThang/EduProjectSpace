import React from 'react';
const field = (key, label, extra = {}) => ({ key, label, required: true, ...extra });
const column = (key, label, extra = {}) => ({ key, label, ...extra });
const dateColumn = (key, label) => column(key, label, { render: row => row[key] ? new Date(row[key]).toLocaleDateString('vi-VN') : '—' });
const department = { path: '/api/AdminUser/department', label: 'facultyName' };
const roles = { path: '/api/AdminRole' };
const users = {
  name: 'Người dùng', endpoint: '/api/AdminUser', importPath: '/api/AdminUser/import',
  fields: [field('username', 'Tên đăng nhập'), field('fullName', 'Họ tên'), field('email', 'Email', { type: 'email' }), field('roleId', 'Vai trò', { numeric: true }), field('departmentId', 'Khoa / bộ môn', { numeric: true, required: false }), field('classCode', 'Lớp', { required: false }), field('password', 'Mật khẩu', { type: 'password', required: false, help: 'Để trống khi sửa để giữ mật khẩu hiện tại.' }), field('locked', 'Khóa tài khoản', { type: 'checkbox', required: false, editOnly: true })],
  columns: [column('username', 'Tài khoản'), column('fullName', 'Họ tên'), column('email', 'Email'), column('roleName', 'Vai trò'), column('classCode', 'Lớp'), column('locked', 'Trạng thái', { render: u => u.locked ? 'Đã khóa' : 'Hoạt động' })],
  lookups: { departmentId: department, roleId: roles }
};
const permissionFields = [['viewUsers', 'Xem người dùng'], ['editUsers', 'Sửa người dùng'], ['viewProjects', 'Xem đề tài'], ['editProjects', 'Sửa đề tài'], ['viewGrading', 'Xem điểm'], ['editGrading', 'Sửa điểm']];
export const adminResources = {
  notifications: {
    name: 'Thông báo', endpoint: '/api/Notifications', select: data => data.notifications,
    fields: [field('title', 'Tiêu đề'), field('content', 'Nội dung', { type: 'textarea' }), field('type', 'Kênh gửi', { default: 'Web', options: ['Web', 'Email'].map(value => ({ value, label: value })) }), field('recipientType', 'Người nhận', { createOnly: true, default: 'student', options: [['student', 'Sinh viên'], ['lecturer', 'Giảng viên'], ['head', 'Trưởng bộ môn'], ['group', 'Nhóm'], ['all', 'Tất cả người dùng']].map(([value, label]) => ({ value, label })) }), field('userIds', 'Chọn người nhận', { createOnly: true, multiple: true, numeric: true, required: false, help: 'Để trống để gửi tất cả người dùng thuộc vai trò đã chọn.' }), field('groupIds', 'Chọn nhóm', { createOnly: true, multiple: true, numeric: true, required: false })],
    columns: [column('title', 'Tiêu đề'), column('content', 'Nội dung'), column('type', 'Kênh'), column('recipientType', 'Người nhận'), dateColumn('createdAt', 'Ngày gửi')],
    lookups: { userIds: { path: '/api/Notifications/users', label: 'fullName' }, groupIds: { path: '/api/Notifications/groups' } },
    prepare: row => { const dto = { ...row, userIds: row.userIds || [], groupIds: row.groupIds || [], status: row.status || 'PENDING' }; return row.id ? dto : { notificationDto: dto }; },
    validate: body => { const row = body.notificationDto || body; return row.recipientType === 'group' && !row.groupIds.length && !row.id ? 'Chọn ít nhất một nhóm nhận thông báo.' : ''; }
  },
  users,
  students: { ...users, name: 'Sinh viên', endpoint: '/api/AdminUser/students', importPath: '/api/AdminUser/students/import', updatePath: id => `/api/AdminUser/students/update/${id}`, fields: users.fields.filter(f => f.key !== 'roleId').map(f => f.key === 'username' ? { ...f, createOnly: true } : f), lookups: { departmentId: department } },
  lecturers: { ...users, name: 'Giảng viên', endpoint: '/api/AdminUser/lecturers', importPath: '/api/AdminUser/lecturers/import', updatePath: id => `/api/AdminUser/lecturers/update/${id}` },
  semesters: {
    name: 'Kỳ học', endpoint: '/api/AdminSemester', importPath: '/api/AdminSemester/import',
    fields: [field('name', 'Tên kỳ học'), field('startDate', 'Ngày bắt đầu', { type: 'date' }), field('endDate', 'Ngày kết thúc', { type: 'date' }), field('description', 'Mô tả', { required: false, type: 'textarea' })],
    columns: [column('name', 'Kỳ học'), dateColumn('startDate', 'Bắt đầu'), dateColumn('endDate', 'Kết thúc'), column('status', 'Trạng thái'), column('description', 'Mô tả')],
    validate: row => row.endDate < row.startDate ? 'Ngày kết thúc phải sau ngày bắt đầu.' : ''
  },
  courses: {
    name: 'Học phần', endpoint: '/api/AdminCourses', importPath: '/api/AdminCourses/import',
    fields: [field('name', 'Tên học phần'), field('semesterName', 'Kỳ học'), field('facultyCode', 'Khoa'), field('startDate', 'Ngày bắt đầu', { type: 'date', required: false }), field('endDate', 'Ngày kết thúc', { type: 'date', required: false }), field('defenseDate', 'Ngày bảo vệ', { type: 'date', required: false })],
    columns: [column('courseCode', 'Mã học phần'), column('name', 'Tên học phần'), column('semesterName', 'Kỳ học'), column('facultyCode', 'Khoa'), dateColumn('startDate', 'Bắt đầu'), dateColumn('endDate', 'Kết thúc'), dateColumn('defenseDate', 'Bảo vệ')],
    lookups: { semesterName: { path: '/api/AdminCourses/semesters', value: 'name' }, facultyCode: { path: '/api/AdminCourses/faculties', value: 'code' } },
    validate: row => row.startDate && row.endDate && row.endDate < row.startDate ? 'Ngày kết thúc phải sau ngày bắt đầu.' : ''
  },
  projects: {
    name: 'Đề tài', endpoint: '/api/AdminProjects', importPath: '/api/AdminProjects/import',
    fields: [field('projectCode', 'Mã đề tài'), field('title', 'Tên đề tài'), field('description', 'Mô tả', { type: 'textarea' }), field('courseId', 'Học phần', { numeric: true }), field('status', 'Trạng thái', { default: 'PROPOSED', options: ['PROPOSED', 'APPROVED', 'IN_PROGRESS', 'COMPLETED'].map(value => ({ value, label: value })) })],
    columns: [column('projectCode', 'Mã đề tài'), column('title', 'Đề tài'), column('courseName', 'Học phần'), column('lecturerName', 'Giảng viên'), column('status', 'Trạng thái'), column('group', 'Nhóm', { render: p => p.group?.name || '—', export: p => p.group?.name || '' })],
    lookups: { courseId: { path: '/api/AdminProjects/courses' } }
  },
  grading: {
    name: 'Hội đồng', endpoint: '/api/AdminDefenseCommittees',
    fields: [field('name', 'Tên hội đồng'), field('semesterId', 'Kỳ học', { numeric: true }), field('members', 'Thành viên', { hidden: true, default: [], required: false })],
    columns: [column('name', 'Hội đồng'), column('semesterName', 'Kỳ học'), column('members', 'Thành viên', { render: row => row.members.map(m => `${m.fullName} (${m.role})`).join(', '), export: row => row.members.map(m => `${m.fullName} (${m.role})`).join(', ') })],
    lookups: { semesterId: { path: '/api/AdminSemester' }, lecturers: { path: '/api/AdminUser/lecturers', label: 'fullName' } },
    validate: row => !row.members.length ? 'Chọn ít nhất một thành viên hội đồng.' : new Set(row.members.map(m => Number(m.lecturerId))).size !== row.members.length ? 'Không chọn trùng giảng viên.' : '',
    extraFields: (form, setForm, options) => <fieldset><legend>Thành viên hội đồng</legend>{(form.members || []).map((member, index) => <div className="d-flex gap-2 mb-2" key={index}><select aria-label={`Giảng viên ${index + 1}`} className="form-select" required value={member.lecturerId} onChange={e => setForm({ ...form, members: form.members.map((m, i) => i === index ? { ...m, lecturerId: Number(e.target.value) } : m) })}><option value="">Chọn giảng viên</option>{(options.lecturers || []).map(l => <option key={l.value} value={l.value}>{l.label}</option>)}</select><select aria-label={`Vai trò ${index + 1}`} className="form-select" value={member.role} onChange={e => setForm({ ...form, members: form.members.map((m, i) => i === index ? { ...m, role: e.target.value } : m) })}>{['Chủ tịch', 'Thư ký', 'Thành viên'].map(role => <option key={role}>{role}</option>)}</select><button className="btn btn-outline-danger" type="button" onClick={() => setForm({ ...form, members: form.members.filter((_, i) => i !== index) })}>Bỏ</button></div>)}<button className="btn btn-outline-primary" type="button" onClick={() => setForm({ ...form, members: [...(form.members || []), { lecturerId: '', role: 'Thành viên' }] })}>Thêm thành viên</button></fieldset>
  },
  logs: { name: 'Nhật ký', endpoint: '/api/Log', readOnly: true, fields: [], columns: [dateColumn('createdAt', 'Thời gian'), column('fullName', 'Người dùng'), column('roleName', 'Vai trò'), column('action', 'Hành động'), column('details', 'Chi tiết')] },
  settings: {
    name: 'Phân quyền', endpoint: '/api/AdminRolePermissions', canCreate: false, canDelete: false,
    select: rows => rows.map(row => ({ ...row, id: row.roleId })),
    fields: [field('roleName', 'Vai trò', { disabled: true }), ...permissionFields.map(([key, label]) => field(key, label, { type: 'checkbox', required: false }))],
    columns: [column('roleName', 'Vai trò'), ...permissionFields.map(([key, label]) => column(key, label, { render: row => row[key] ? 'Có' : 'Không' }))]
  }
};

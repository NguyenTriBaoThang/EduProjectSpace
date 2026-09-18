import React, { lazy, Suspense } from 'react';
import { Routes, Route, Navigate, useLocation } from 'react-router-dom';
import RequireRole from './components/RequireRole';
import aliases from './routeAliases.json';
const AdminDashboard = lazy(() => import("./pages/admin/AdminDashboard"));
const NotFound = lazy(() => import("./screens/error/NotFound"));
const Home = lazy(() => import("./pages/index/Home"));
const LoginForm = lazy(() => import("./pages/login/LoginForm"));

const LecturerWorkspace = lazy(() => import("./screens/lecturer/LecturerWorkspace"));
const HeadWorkspace = lazy(() => import("./screens/head/HeadWorkspace"));
const AdminWorkspace = lazy(() => import("./screens/admin/AdminWorkspace"));
const StudentWorkspace = lazy(() => import("./screens/student/StudentWorkspace"));

function Redirect({ to }) { const location = useLocation(); return <Navigate to={to + location.search + location.hash} replace />; }

export default function App() {
const location = useLocation();
return <Suspense fallback={<div className="page-loading" role="status">Đang tải trang…</div>}><Routes location={location} key={location.pathname + location.search}>
<Route path="/admin/courses" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/dashboard" element={<RequireRole role="ROLE_ADMIN"><AdminDashboard /></RequireRole>} />
<Route path="/admin/grading" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/lecturers" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/logs" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/notifications" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/projects" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/reports" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/semesters" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/settings" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/students" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/admin/users" element={<RequireRole role="ROLE_ADMIN"><AdminWorkspace /></RequireRole>} />
<Route path="/404" element={<NotFound />} />
<Route path="/head/google-meet" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/assign" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/course-assign" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/course-list" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/dashboard" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/defense" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/defense-add" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/defense-edit" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/defense-list" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/grade-criteria" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/grading" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/grading-courses" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/grading-details" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/group-details" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/lecturer-assign" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/lecturer-details" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/progress" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/progress-courses" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/head/progress-details" element={<RequireRole role="ROLE_HEAD"><HeadWorkspace /></RequireRole>} />
<Route path="/" element={<Home />} />
<Route path="/lecturer/approval" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/courses" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/course-approvals" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/course-feedback" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/course-groups" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/course-resources" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/course-reviews" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/dashboard" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/feedback" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/feedback-detail" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/final-review" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/groups" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/projects" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/project-progress" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/project-review" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/resources" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/lecturer/tasks" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerWorkspace /></RequireRole>} />
<Route path="/login" element={<LoginForm />} />
<Route path="/student/notifications-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/notification-detail" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/dashboard" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/grades-detail" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/grades-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/grades-week" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/history-submissions-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/history-submissions-overview" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/proposals-create" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/proposals-detail" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/proposals-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/schedule" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/submissions" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/submissions-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/submissions-week" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/tracking-details" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />
<Route path="/student/tracking-list" element={<RequireRole role="ROLE_STUDENT"><StudentWorkspace /></RequireRole>} />

{Object.entries(aliases).map(([oldPath,to]) => <Route key={oldPath} path={oldPath} element={<Redirect to={to} />} />)}
<Route path="/admin" element={<Redirect to="/admin/dashboard" />} />
<Route path="/head" element={<Redirect to="/head/dashboard" />} />
<Route path="/lecturer" element={<Redirect to="/lecturer/dashboard" />} />
<Route path="/student" element={<Redirect to="/student/dashboard" />} />
<Route path="*" element={<NotFound />} />
</Routes></Suspense>;
}

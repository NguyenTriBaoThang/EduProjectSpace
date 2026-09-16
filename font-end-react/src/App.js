import React, { lazy, Suspense } from 'react';
import { Routes, Route, Navigate, useLocation } from 'react-router-dom';
import RequireRole from './components/RequireRole';
import aliases from './routeAliases.json';
const AdminCourses = lazy(() => import("./screens/admin/AdminCourses"));
const AdminDashboard = lazy(() => import("./pages/admin/AdminDashboard"));
const AdminGrading = lazy(() => import("./screens/admin/AdminGrading"));
const AdminLecturers = lazy(() => import("./screens/admin/AdminLecturers"));
const AdminLogs = lazy(() => import("./screens/admin/AdminLogs"));
const AdminNotifications = lazy(() => import("./screens/admin/AdminNotifications"));
const AdminProjects = lazy(() => import("./screens/admin/AdminProjects"));
const AdminReports = lazy(() => import("./screens/admin/AdminReports"));
const AdminSemesters = lazy(() => import("./screens/admin/AdminSemesters"));
const AdminSettings = lazy(() => import("./screens/admin/AdminSettings"));
const AdminStudents = lazy(() => import("./screens/admin/AdminStudents"));
const AdminUsers = lazy(() => import("./screens/admin/AdminUsers"));
const NotFound = lazy(() => import("./screens/error/NotFound"));
const GoogleMeet = lazy(() => import("./screens/head/GoogleMeet"));
const HeadAssign = lazy(() => import("./screens/head/HeadAssign"));
const HeadCourseAssign = lazy(() => import("./screens/head/HeadCourseAssign"));
const HeadCourseList = lazy(() => import("./screens/head/HeadCourseList"));
const HeadDashboard = lazy(() => import("./screens/head/HeadDashboard"));
const HeadDefense = lazy(() => import("./screens/head/HeadDefense"));
const HeadDefenseAdd = lazy(() => import("./screens/head/HeadDefenseAdd"));
const HeadDefenseEdit = lazy(() => import("./screens/head/HeadDefenseEdit"));
const HeadDefenseList = lazy(() => import("./screens/head/HeadDefenseList"));
const HeadGradeCriteria = lazy(() => import("./screens/head/HeadGradeCriteria"));
const HeadGrading = lazy(() => import("./screens/head/HeadGrading"));
const HeadGradingCourses = lazy(() => import("./screens/head/HeadGradingCourses"));
const HeadGradingDetails = lazy(() => import("./screens/head/HeadGradingDetails"));
const HeadGroupDetails = lazy(() => import("./screens/head/HeadGroupDetails"));
const HeadLecturerAssign = lazy(() => import("./screens/head/HeadLecturerAssign"));
const HeadLecturerDetails = lazy(() => import("./screens/head/HeadLecturerDetails"));
const HeadProgress = lazy(() => import("./screens/head/HeadProgress"));
const HeadProgressCourses = lazy(() => import("./screens/head/HeadProgressCourses"));
const HeadProgressDetails = lazy(() => import("./screens/head/HeadProgressDetails"));
const Home = lazy(() => import("./pages/index/Home"));
const LecturerApproval = lazy(() => import("./screens/lecturer/LecturerApproval"));
const LecturerCourses = lazy(() => import("./screens/lecturer/LecturerCourses"));
const LecturerCourseApprovals = lazy(() => import("./screens/lecturer/LecturerCourseApprovals"));
const LecturerCourseFeedback = lazy(() => import("./screens/lecturer/LecturerCourseFeedback"));
const LecturerCourseGroups = lazy(() => import("./screens/lecturer/LecturerCourseGroups"));
const LecturerCourseResources = lazy(() => import("./screens/lecturer/LecturerCourseResources"));
const LecturerCourseReviews = lazy(() => import("./screens/lecturer/LecturerCourseReviews"));
const LecturerDashboard = lazy(() => import("./screens/lecturer/LecturerDashboard"));
const LecturerFeedback = lazy(() => import("./screens/lecturer/LecturerFeedback"));
const LecturerFeedbackDetail = lazy(() => import("./screens/lecturer/LecturerFeedbackDetail"));
const LecturerFinalReview = lazy(() => import("./screens/lecturer/LecturerFinalReview"));
const LecturerGroups = lazy(() => import("./screens/lecturer/LecturerGroups"));
const LecturerProjects = lazy(() => import("./screens/lecturer/LecturerProjects"));
const LecturerProjectProgress = lazy(() => import("./screens/lecturer/LecturerProjectProgress"));
const LecturerProjectReview = lazy(() => import("./screens/lecturer/LecturerProjectReview"));
const LecturerResources = lazy(() => import("./screens/lecturer/LecturerResources"));
const LecturerTasks = lazy(() => import("./screens/lecturer/LecturerTasks"));
const LoginForm = lazy(() => import("./pages/login/LoginForm"));
const NotificationsList = lazy(() => import("./screens/student/NotificationsList"));
const NotificationDetail = lazy(() => import("./screens/student/NotificationDetail"));
const StudentDashboard = lazy(() => import("./screens/student/StudentDashboard"));
const StudentGradesDetail = lazy(() => import("./screens/student/StudentGradesDetail"));
const StudentGradesList = lazy(() => import("./screens/student/StudentGradesList"));
const StudentGradesWeek = lazy(() => import("./screens/student/StudentGradesWeek"));
const StudentHistorySubmissionsList = lazy(() => import("./screens/student/StudentHistorySubmissionsList"));
const StudentHistorySubmissionsOverview = lazy(() => import("./screens/student/StudentHistorySubmissionsOverview"));
const StudentProposalsCreate = lazy(() => import("./screens/student/StudentProposalsCreate"));
const StudentProposalsDetail = lazy(() => import("./screens/student/StudentProposalsDetail"));
const StudentProposalsList = lazy(() => import("./screens/student/StudentProposalsList"));
const StudentSchedule = lazy(() => import("./screens/student/StudentSchedule"));
const StudentSubmissions = lazy(() => import("./screens/student/StudentSubmissions"));
const StudentSubmissionsList = lazy(() => import("./screens/student/StudentSubmissionsList"));
const StudentSubmissionsWeek = lazy(() => import("./screens/student/StudentSubmissionsWeek"));
const StudentTrackingDetails = lazy(() => import("./screens/student/StudentTrackingDetails"));
const StudentTrackingList = lazy(() => import("./screens/student/StudentTrackingList"));

function Redirect({ to }) { const location = useLocation(); return <Navigate to={to + location.search + location.hash} replace />; }

export default function App() {
const location = useLocation();
return <Suspense fallback={<div className="page-loading" role="status">Đang tải trang…</div>}><Routes location={location} key={location.pathname + location.search}>
<Route path="/admin/courses" element={<RequireRole role="ROLE_ADMIN"><AdminCourses /></RequireRole>} />
<Route path="/admin/dashboard" element={<RequireRole role="ROLE_ADMIN"><AdminDashboard /></RequireRole>} />
<Route path="/admin/grading" element={<RequireRole role="ROLE_ADMIN"><AdminGrading /></RequireRole>} />
<Route path="/admin/lecturers" element={<RequireRole role="ROLE_ADMIN"><AdminLecturers /></RequireRole>} />
<Route path="/admin/logs" element={<RequireRole role="ROLE_ADMIN"><AdminLogs /></RequireRole>} />
<Route path="/admin/notifications" element={<RequireRole role="ROLE_ADMIN"><AdminNotifications /></RequireRole>} />
<Route path="/admin/projects" element={<RequireRole role="ROLE_ADMIN"><AdminProjects /></RequireRole>} />
<Route path="/admin/reports" element={<RequireRole role="ROLE_ADMIN"><AdminReports /></RequireRole>} />
<Route path="/admin/semesters" element={<RequireRole role="ROLE_ADMIN"><AdminSemesters /></RequireRole>} />
<Route path="/admin/settings" element={<RequireRole role="ROLE_ADMIN"><AdminSettings /></RequireRole>} />
<Route path="/admin/students" element={<RequireRole role="ROLE_ADMIN"><AdminStudents /></RequireRole>} />
<Route path="/admin/users" element={<RequireRole role="ROLE_ADMIN"><AdminUsers /></RequireRole>} />
<Route path="/404" element={<NotFound />} />
<Route path="/head/google-meet" element={<RequireRole role="ROLE_HEAD"><GoogleMeet /></RequireRole>} />
<Route path="/head/assign" element={<RequireRole role="ROLE_HEAD"><HeadAssign /></RequireRole>} />
<Route path="/head/course-assign" element={<RequireRole role="ROLE_HEAD"><HeadCourseAssign /></RequireRole>} />
<Route path="/head/course-list" element={<RequireRole role="ROLE_HEAD"><HeadCourseList /></RequireRole>} />
<Route path="/head/dashboard" element={<RequireRole role="ROLE_HEAD"><HeadDashboard /></RequireRole>} />
<Route path="/head/defense" element={<RequireRole role="ROLE_HEAD"><HeadDefense /></RequireRole>} />
<Route path="/head/defense-add" element={<RequireRole role="ROLE_HEAD"><HeadDefenseAdd /></RequireRole>} />
<Route path="/head/defense-edit" element={<RequireRole role="ROLE_HEAD"><HeadDefenseEdit /></RequireRole>} />
<Route path="/head/defense-list" element={<RequireRole role="ROLE_HEAD"><HeadDefenseList /></RequireRole>} />
<Route path="/head/grade-criteria" element={<RequireRole role="ROLE_HEAD"><HeadGradeCriteria /></RequireRole>} />
<Route path="/head/grading" element={<RequireRole role="ROLE_HEAD"><HeadGrading /></RequireRole>} />
<Route path="/head/grading-courses" element={<RequireRole role="ROLE_HEAD"><HeadGradingCourses /></RequireRole>} />
<Route path="/head/grading-details" element={<RequireRole role="ROLE_HEAD"><HeadGradingDetails /></RequireRole>} />
<Route path="/head/group-details" element={<RequireRole role="ROLE_HEAD"><HeadGroupDetails /></RequireRole>} />
<Route path="/head/lecturer-assign" element={<RequireRole role="ROLE_HEAD"><HeadLecturerAssign /></RequireRole>} />
<Route path="/head/lecturer-details" element={<RequireRole role="ROLE_HEAD"><HeadLecturerDetails /></RequireRole>} />
<Route path="/head/progress" element={<RequireRole role="ROLE_HEAD"><HeadProgress /></RequireRole>} />
<Route path="/head/progress-courses" element={<RequireRole role="ROLE_HEAD"><HeadProgressCourses /></RequireRole>} />
<Route path="/head/progress-details" element={<RequireRole role="ROLE_HEAD"><HeadProgressDetails /></RequireRole>} />
<Route path="/" element={<Home />} />
<Route path="/lecturer/approval" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerApproval /></RequireRole>} />
<Route path="/lecturer/courses" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourses /></RequireRole>} />
<Route path="/lecturer/course-approvals" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourseApprovals /></RequireRole>} />
<Route path="/lecturer/course-feedback" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourseFeedback /></RequireRole>} />
<Route path="/lecturer/course-groups" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourseGroups /></RequireRole>} />
<Route path="/lecturer/course-resources" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourseResources /></RequireRole>} />
<Route path="/lecturer/course-reviews" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerCourseReviews /></RequireRole>} />
<Route path="/lecturer/dashboard" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerDashboard /></RequireRole>} />
<Route path="/lecturer/feedback" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerFeedback /></RequireRole>} />
<Route path="/lecturer/feedback-detail" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerFeedbackDetail /></RequireRole>} />
<Route path="/lecturer/final-review" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerFinalReview /></RequireRole>} />
<Route path="/lecturer/groups" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerGroups /></RequireRole>} />
<Route path="/lecturer/projects" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerProjects /></RequireRole>} />
<Route path="/lecturer/project-progress" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerProjectProgress /></RequireRole>} />
<Route path="/lecturer/project-review" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerProjectReview /></RequireRole>} />
<Route path="/lecturer/resources" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerResources /></RequireRole>} />
<Route path="/lecturer/tasks" element={<RequireRole role="ROLE_LECTURER_GUIDE"><LecturerTasks /></RequireRole>} />
<Route path="/login" element={<LoginForm />} />
<Route path="/student/notifications-list" element={<RequireRole role="ROLE_STUDENT"><NotificationsList /></RequireRole>} />
<Route path="/student/notification-detail" element={<RequireRole role="ROLE_STUDENT"><NotificationDetail /></RequireRole>} />
<Route path="/student/dashboard" element={<RequireRole role="ROLE_STUDENT"><StudentDashboard /></RequireRole>} />
<Route path="/student/grades-detail" element={<RequireRole role="ROLE_STUDENT"><StudentGradesDetail /></RequireRole>} />
<Route path="/student/grades-list" element={<RequireRole role="ROLE_STUDENT"><StudentGradesList /></RequireRole>} />
<Route path="/student/grades-week" element={<RequireRole role="ROLE_STUDENT"><StudentGradesWeek /></RequireRole>} />
<Route path="/student/history-submissions-list" element={<RequireRole role="ROLE_STUDENT"><StudentHistorySubmissionsList /></RequireRole>} />
<Route path="/student/history-submissions-overview" element={<RequireRole role="ROLE_STUDENT"><StudentHistorySubmissionsOverview /></RequireRole>} />
<Route path="/student/proposals-create" element={<RequireRole role="ROLE_STUDENT"><StudentProposalsCreate /></RequireRole>} />
<Route path="/student/proposals-detail" element={<RequireRole role="ROLE_STUDENT"><StudentProposalsDetail /></RequireRole>} />
<Route path="/student/proposals-list" element={<RequireRole role="ROLE_STUDENT"><StudentProposalsList /></RequireRole>} />
<Route path="/student/schedule" element={<RequireRole role="ROLE_STUDENT"><StudentSchedule /></RequireRole>} />
<Route path="/student/submissions" element={<RequireRole role="ROLE_STUDENT"><StudentSubmissions /></RequireRole>} />
<Route path="/student/submissions-list" element={<RequireRole role="ROLE_STUDENT"><StudentSubmissionsList /></RequireRole>} />
<Route path="/student/submissions-week" element={<RequireRole role="ROLE_STUDENT"><StudentSubmissionsWeek /></RequireRole>} />
<Route path="/student/tracking-details" element={<RequireRole role="ROLE_STUDENT"><StudentTrackingDetails /></RequireRole>} />
<Route path="/student/tracking-list" element={<RequireRole role="ROLE_STUDENT"><StudentTrackingList /></RequireRole>} />

{Object.entries(aliases).map(([oldPath,to]) => <Route key={oldPath} path={oldPath} element={<Redirect to={to} />} />)}
<Route path="/admin" element={<Redirect to="/admin/dashboard" />} />
<Route path="/head" element={<Redirect to="/head/dashboard" />} />
<Route path="/lecturer" element={<Redirect to="/lecturer/dashboard" />} />
<Route path="/student" element={<Redirect to="/student/dashboard" />} />
<Route path="*" element={<NotFound />} />
</Routes></Suspense>;
}

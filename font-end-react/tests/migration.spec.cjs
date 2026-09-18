const { test, expect } = require('@playwright/test');
const pages = require('../src/pageManifest.json');

async function session(page, role='ROLE_ADMIN') {
  await page.addInitScript(role=>{
    localStorage.setItem('user',JSON.stringify({id:1,roleName:role,fullName:'Người kiểm thử',email:'test@example.test',username:'test',departmentId:1}));
    localStorage.setItem('token','test-token');
  },role);
  page.on('dialog', dialog=>dialog.dismiss());
  await page.route('**/api/**',async route=>{
    const url=new URL(route.request().url());
    let data=[];
    if(url.pathname.includes('/Auth/login'))data={user:{id:1,roleName:'ROLE_ADMIN',fullName:'Người kiểm thử'},token:'test-token'};
    else if(url.pathname.includes('/Notifications/config'))data={enableWeb:true,enableEmail:false,reminderFrequency:'daily',smtpConfig:{host:'',port:587,username:'',password:''}};
    else if(url.pathname.endsWith('/Notifications'))data={notifications:[],totalItems:0};
    else if(url.pathname.endsWith('/AdminUser'))data=[{id:101,fullName:'Nguyễn Văn A',username:'student101',email:'a@example.test',roleId:3,roleName:'ROLE_STUDENT',locked:false,departmentId:1,classCode:'21DTH',facultyCode:'CS'}];
    else if(url.pathname.endsWith('/roles') || url.pathname.endsWith('/AdminRole'))data=[{id:3,name:'ROLE_STUDENT'}];
    else if((url.pathname.endsWith('/departments') || url.pathname.endsWith('/department')))data=[{id:1,name:'Công nghệ thông tin',facultyCode:'CS'}];
    else if(url.pathname.endsWith('/summary'))data={studentCount:1,submittedProjects:0,pendingTopics:0};
    else if(url.pathname.endsWith('/project-status'))data={notSubmitted:0,submitted:0,graded:0};
    else if(url.pathname.endsWith('/StudentDashboard'))data={studentName:'Người kiểm thử',courses:[],projects:[],tasks:[],notifications:[]};
    else if(url.pathname === '/api/student/projects')data=[{id:1,title:'Đề tài kiểm thử',groupName:'Nhóm 1',courseName:'Công nghệ phần mềm',approvalStatus:'PENDING',totalTasks:0,doneTasks:0}];
    else if(url.pathname.startsWith('/api/student/projects/'))data={project:{id:1,title:'Đề tài kiểm thử',approvalStatus:'PENDING'},tasks:[],members:[],versions:[]};
    else if(url.pathname.startsWith('/api/student/submissions/'))data={submission:{id:1,projectTitle:'Đề tài kiểm thử',filePath:'submissions/report.pdf'},feedback:[],versions:[]};
    else if(url.pathname === '/api/AdminReports')data={summary:{studentCount:0,lecturerCount:0,approvedProjects:0,pendingProjects:0},projects:[],students:[],lecturers:[]};
    else if(url.pathname.endsWith('/tasks'))data={tasks:[],totalItems:0};
    await route.fulfill({status:200,contentType:'application/json',body:JSON.stringify(data),headers:{'Access-Control-Allow-Origin':'http://127.0.0.1:4173','Access-Control-Allow-Credentials':'true'}});
  });
}

for(const screen of pages.filter(p=>p.role || p.path === '/404')) {
  test(`mount ${screen.path}`,async({page})=>{
    await session(page,screen.role || 'ROLE_ADMIN');
    const errors=[];
    page.on('pageerror',error=>errors.push(error.message));
    page.on('console',message=>{if(message.type()==='error'&&message.text().startsWith('Cannot initialize'))errors.push(message.text());});
    await page.goto(screen.path+'?courseId=IT101&semester=HK1&facultyCode=CS&classId=21DTH&projectId=1&groupId=1&lecturer=Test&id=1&taskId=1');
    await page.locator('[data-page]').waitFor({state:'attached'});
    await page.waitForTimeout(150);
    expect(errors).toEqual([]);
    expect(await page.locator('iframe[src*=".html"]').count()).toBe(0);
  });
}

test('anonymous route redirects to React login',async({page})=>{
  await page.goto('/admin/users');
  await expect(page).toHaveURL(/\/login$/);
  await expect(page.locator('#username')).toBeVisible();
});

test('old HTML URL redirects inside React and preserves query parameters',async({page})=>{
  await session(page,'ROLE_STUDENT');
  await page.goto('/font-end/student/student_schedule.html?semester=HK1');
  await expect(page).toHaveURL(/\/student\/schedule\?semester=HK1$/);
  await expect(page.locator('.fc')).toBeVisible();
});

test('user list retains filtering, editing and SPA navigation',async({page})=>{
  await session(page);
  await page.goto('/admin/users');
  await expect(page.locator('tbody')).toContainText('Nguyễn Văn A');
  await page.getByRole('searchbox').fill('Không tồn tại');
  await expect(page.locator('tbody')).not.toContainText('Nguyễn Văn A');
  await page.getByRole('searchbox').fill('');
  await page.getByRole('button',{name:'Sửa',exact:true}).click();
  await expect(page.getByRole('dialog')).toBeVisible();
  await page.getByRole('button',{name:'Hủy',exact:true}).click();
  await page.getByRole('link',{name:'Kỳ học',exact:true}).click();
  await expect(page).toHaveURL(/\/admin\/semesters$/);
  await page.goBack();
  await expect(page.locator('tbody')).toContainText('Nguyễn Văn A');
});

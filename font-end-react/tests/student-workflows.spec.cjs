const { test, expect } = require('@playwright/test');

test.beforeEach(async ({ page }) => {
  await page.addInitScript(() => localStorage.setItem('user', JSON.stringify({ id: 100, roleName: 'ROLE_STUDENT' })));
});

test('proposal is saved to API and displayed on the detail page', async ({ page }) => {
  const project = { id: 1, title: 'Đề tài ban đầu', description: 'Mô tả đề tài ban đầu', approvalStatus: 'PENDING', groupName: 'Nhóm 1', courseName: 'Đồ án', totalTasks: 0, doneTasks: 0 };
  let saved;
  await page.route('**/api/student/projects**', async route => {
    if (route.request().method() === 'PUT') {
      saved = route.request().postDataJSON(); Object.assign(project, saved);
      return route.fulfill({ json: { id: 1 } });
    }
    await route.fulfill({ json: new URL(route.request().url()).pathname.endsWith('/1') ? { project, tasks: [], members: [], versions: [] } : [project] });
  });
  await page.goto('/student/proposals-create?projectId=1');
  await page.getByLabel('Tiêu đề', { exact: true }).fill('Đề xuất mới');
  await page.getByRole('textbox', { name: 'Mô tả', exact: true }).fill('Mô tả nghiệp vụ mới cần triển khai');
  await page.getByRole('button', { name: 'Gửi đề xuất' }).click();
  await expect(page).toHaveURL(/proposals-detail\?projectId=1/);
  await expect(page.getByRole('heading', { name: 'Đề xuất mới', exact: true })).toBeVisible();
  expect(saved).toEqual({ title: 'Đề xuất mới', description: 'Mô tả nghiệp vụ mới cần triển khai' });
});

test('API failure offers retry instead of sample data', async ({ page }) => {
  let failed = true;
  await page.route('**/api/student/projects', route => route.fulfill(failed ? { status: 500, json: { message: 'Không kết nối được dữ liệu.' } } : { json: [] }));
  await page.goto('/student/proposals-list');
  await expect(page.getByRole('alert')).toContainText('Không kết nối được dữ liệu.');
  failed = false;
  await page.getByRole('button', { name: 'Thử lại' }).click();
  await expect(page.getByText('Bạn chưa được phân vào nhóm đồ án. Liên hệ giảng viên để được phân nhóm.')).toBeVisible();
});

test('upload sends multipart content then reloads the persisted list', async ({ page }) => {
  let uploaded = false;
  await page.route('**/api/student/**', async route => {
    const url = new URL(route.request().url());
    if (route.request().method() === 'POST') {
      expect(route.request().headers()['content-type']).toContain('multipart/form-data');
      const body = route.request().postDataBuffer().toString();
      expect(body).toContain('report.pdf'); expect(body).toContain('name="projectId"');
      uploaded = true; return route.fulfill({ status: 201, json: { id: 4 } });
    }
    const project = { id: 1, title: 'Đề tài đã duyệt', approvalStatus: 'APPROVED' };
    const data = url.pathname.endsWith('/projects') ? [project] : url.pathname.endsWith('/projects/1') ? { project, tasks: [] } : uploaded ? [{ id: 4, projectTitle: project.title, taskTitle: 'Báo cáo đồ án', status: 'Submitted' }] : [];
    return route.fulfill({ json: data });
  });
  await page.goto('/student/submissions-week?projectId=1');
  await page.getByLabel('Tệp bài nộp (tối đa 20 MB)').setInputFiles({ name: 'report.pdf', mimeType: 'application/pdf', buffer: Buffer.from('%PDF-1.7 example') });
  await page.getByRole('button', { name: 'Nộp bài', exact: true }).click();
  await expect(page.getByText('Nộp bài thành công.')).toBeVisible();
  await expect(page.locator('tbody')).toContainText('Đề tài đã duyệt');
});

test('expired session returns to login', async ({ page }) => {
  await page.route('**/api/student/projects', route => route.fulfill({ status: 401, json: { message: 'Hết phiên đăng nhập' } }));
  await page.goto('/student/dashboard');
  await expect(page).toHaveURL(/\/login$/);
});

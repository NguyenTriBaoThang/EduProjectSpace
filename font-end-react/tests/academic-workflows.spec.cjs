const { test, expect } = require('@playwright/test');
async function login(page, role) {
  await page.addInitScript(role => localStorage.setItem('user', JSON.stringify({ id: 100, roleName: role })), role);
}

test('semester editor validates dates and sends a real create request', async ({ page }) => {
  await login(page, 'ROLE_ADMIN'); let saved; const rows = [];
  await page.route('**/api/AdminSemester', async route => {
    if (route.request().method() === 'POST') { saved = route.request().postDataJSON(); rows.push({ id: 10, ...saved }); return route.fulfill({ status: 201, json: rows[0] }); }
    return route.fulfill({ json: rows });
  });
  await page.goto('/admin/semesters'); await page.getByRole('button', { name: 'Thêm mới', exact: true }).click();
  const dialog = page.getByRole('dialog');
  await dialog.getByLabel('Tên kỳ học', { exact: true }).fill('HK1_2026');
  await dialog.getByLabel('Ngày bắt đầu', { exact: true }).fill('2026-09-01');
  await dialog.getByLabel('Ngày kết thúc', { exact: true }).fill('2026-08-01');
  await dialog.getByRole('button', { name: 'Lưu', exact: true }).click();
  await expect(dialog.getByRole('alert')).toContainText('Ngày kết thúc phải sau ngày bắt đầu'); expect(saved).toBeUndefined();
  await dialog.getByLabel('Ngày kết thúc', { exact: true }).fill('2027-01-01');
  await dialog.getByRole('button', { name: 'Lưu', exact: true }).click();
  await expect(dialog).not.toBeVisible(); await expect(page.locator('tbody')).toContainText('HK1_2026'); expect(saved.name).toBe('HK1_2026');
});

test('a failed update retains the form and user input', async ({ page }) => {
  await login(page, 'ROLE_ADMIN');
  await page.route('**/api/AdminSemester**', route => route.fulfill(route.request().method() === 'PUT' ? { status: 409, json: { message: 'Kỳ học đang được sử dụng.' } } : { json: [{ id: 1, name: 'HK1', startDate: '2026-01-01', endDate: '2026-06-01' }] }));
  await page.goto('/admin/semesters'); await page.getByRole('button', { name: 'Sửa', exact: true }).click();
  const dialog = page.getByRole('dialog'); await dialog.getByLabel('Tên kỳ học', { exact: true }).fill('Tên mới'); await dialog.getByRole('button', { name: 'Lưu', exact: true }).click();
  await expect(dialog.getByRole('alert')).toContainText('Kỳ học đang được sử dụng.'); await expect(dialog.getByLabel('Tên kỳ học', { exact: true })).toHaveValue('Tên mới');
});

test('defense creation route opens form and saves typed IDs and UTC dates', async ({ page }) => {
  await login(page, 'ROLE_HEAD'); let saved;
  await page.route('**/api/head/**', route => {
    const path = new URL(route.request().url()).pathname;
    if (route.request().method() === 'POST') { saved = route.request().postDataJSON(); return route.fulfill({ json: { id: 1 } }); }
    return route.fulfill({ json: path.endsWith('/projects') ? [{ id: 7, name: 'Đồ án A' }] : [] });
  });
  await page.goto('/head/defense-add'); const dialog = page.getByRole('dialog'); await expect(dialog).toBeVisible();
  await dialog.getByLabel('Đề tài', { exact: true }).selectOption('7');
  await dialog.getByLabel('Bắt đầu', { exact: true }).fill('2026-12-01T09:00'); await dialog.getByLabel('Kết thúc', { exact: true }).fill('2026-12-01T10:00');
  await dialog.getByLabel('Phòng', { exact: true }).fill('A101'); await dialog.getByRole('button', { name: 'Lưu', exact: true }).click();
  await expect(dialog).not.toBeVisible(); expect(saved.projectId).toBe(7); expect(saved.meetingId).toBeNull(); expect(saved.startTime).toMatch(/Z$/);
});

test('grading preserves a valid zero score and submits numeric criteria', async ({ page }) => {
  await login(page, 'ROLE_LECTURER_GUIDE'); let saved;
  await page.route('**/api/LecturerReview/**', route => {
    if (route.request().method() === 'POST') { saved = route.request().postDataJSON(); return route.fulfill({ json: { message: 'Saved' } }); }
    return route.fulfill({ json: route.request().url().endsWith('/history') ? [] : { name: 'Đồ án A', studentGrades: [{ studentId: 100, fullName: 'Sinh viên A', criteriaGrades: [{ criteriaId: 5, criteriaName: 'Báo cáo', weight: 1, score: 0 }] }], tasks: [] } });
  });
  await page.goto('/lecturer/final-review?projectId=P1'); await page.getByRole('button', { name: 'Lưu điểm', exact: true }).click();
  await expect.poll(() => saved).toBeTruthy(); expect(saved.studentGrades[0].criteriaGrades).toEqual([{ criteriaId: 5, score: 0 }]);
});

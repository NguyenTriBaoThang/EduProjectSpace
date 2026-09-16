import { sanitizeMarkup } from './markup';
import { resolvePageLink } from './links';

test('table rows and callback bindings survive sanitization', () => {
  const result = sanitizeMarkup('<tr><td>Đồ án</td><td><button data-page-click="12">Sửa</button></td></tr>', 'admin/admin_users.html');
  expect(result).toContain('<tr>');
  expect(result).toContain('data-page-click="12"');
  expect(result).toContain('Đồ án');
});

test('untrusted scripts and inline events cannot execute', () => {
  const result = sanitizeMarkup('<img src=x onerror="alert(1)"><script>alert(2)</script><a href="javascript:alert(3)">Click</a>', 'admin/admin_users.html');
  expect(result).not.toMatch(/onerror|<script|javascript:/);
});

test('HTML navigation becomes a React route and keeps the query', () => {
  expect(resolvePageLink('../student/student_schedule.html?semester=HK1', 'login/login.html')).toBe('/student/schedule?semester=HK1');
  expect(resolvePageLink('/font-end/LOGIN/login.html', 'student/student_dashboard.html')).toBe('/login');
  expect(resolvePageLink('/does-not-exist.html', 'index.html')).toBe('/404');
});

test('links in generated rows use the same router as JSX links', () => {
  expect(sanitizeMarkup('<a href="admin_projects.html?semester=HK1">Đề tài</a>', 'admin/admin_users.html'))
    .toContain('href="/admin/projects?semester=HK1"');
});

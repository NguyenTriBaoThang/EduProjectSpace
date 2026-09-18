import { API_BASE_URL } from '../config';

export class ApiError extends Error {
  constructor(message, status) { super(message); this.status = status; }
}

export async function api(path, { body, ...options } = {}) {
  const headers = new Headers(options.headers);
  const token = localStorage.getItem('token');
  if (token) headers.set('Authorization', `Bearer ${token}`);
  if (body !== undefined && !(body instanceof FormData)) {
    headers.set('Content-Type', 'application/json');
    body = JSON.stringify(body);
  }
  const response = await fetch(`${API_BASE_URL}${path}`, { ...options, headers, body, credentials: 'include' });
  const text = await response.text();
  let data;
  try { data = text ? JSON.parse(text) : null; } catch { data = null; }
  if (!response.ok) {
    if (response.status === 401) {
      localStorage.removeItem('user'); localStorage.removeItem('token');
      window.dispatchEvent(new Event('session-expired'));
    }
    const validation = data?.errors && Object.values(data.errors).flat().join(' ');
    throw new ApiError(data?.message || validation || (response.status < 500 && typeof data === 'string' ? data : '') || (response.status === 403 ? 'Bạn không có quyền thực hiện thao tác này.' : response.status === 404 ? 'Không tìm thấy dữ liệu hoặc bạn không có quyền truy cập.' : 'Không thể xử lý yêu cầu. Vui lòng thử lại.'), response.status);
  }
  return data;
}

export async function downloadFile(path) {
  // File paths come from the authorized submission endpoint; never navigate to arbitrary URLs.
  const segments = path.replace(/^\/+/, '').split('/');
  if (segments.some(part => !part || part === '..' || part === '.' || /[:\\]/.test(part))) throw new Error('Đường dẫn tệp không hợp lệ.');
  const token = localStorage.getItem('token');
  const response = await fetch(`${API_BASE_URL}/api/File/files/${segments.map(encodeURIComponent).join('/')}?download=true`, {
    credentials: 'include', headers: token ? { Authorization: `Bearer ${token}` } : {}
  });
  if (!response.ok) throw new Error('Không tải được tệp. Kiểm tra quyền truy cập hoặc đăng nhập lại.');
  const url = URL.createObjectURL(await response.blob());
  const anchor = document.createElement('a'); anchor.href = url; anchor.download = segments.at(-1); anchor.click();
  setTimeout(() => URL.revokeObjectURL(url), 1000);
}

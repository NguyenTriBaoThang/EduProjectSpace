import 'whatwg-fetch';
import { api, ApiError } from './client';

beforeEach(() => { localStorage.clear(); global.fetch = jest.fn(); });
test('JSON mutations include credentials and the authenticated token', async () => {
  localStorage.setItem('token', 'session-token');
  fetch.mockResolvedValue({ ok: true, status: 200, text: async () => '{"id":12}' });
  await expect(api('/api/student/projects/1/proposal', { method: 'PUT', body: { title: 'Đồ án' } })).resolves.toEqual({ id: 12 });
  const options = fetch.mock.calls[0][1];
  expect(options.credentials).toBe('include');
  expect(options.headers.get('Authorization')).toBe('Bearer session-token');
  expect(JSON.parse(options.body)).toEqual({ title: 'Đồ án' });
});
test('multipart uploads preserve browser-generated boundaries', async () => {
  fetch.mockResolvedValue({ ok: true, status: 201, text: async () => '{"id":1}' });
  const body = new FormData(); body.append('file', new Blob(['content']), 'report.txt');
  await api('/api/student/submissions', { method: 'POST', body });
  expect(fetch.mock.calls[0][1].body).toBe(body);
  expect(fetch.mock.calls[0][1].headers.has('Content-Type')).toBe(false);
});
test('401 clears local identity and emits an expiry event', async () => {
  localStorage.setItem('user', '{}'); localStorage.setItem('token', 'expired');
  const expired = jest.fn(); window.addEventListener('session-expired', expired);
  fetch.mockResolvedValue({ ok: false, status: 401, text: async () => '{}' });
  await expect(api('/api/student/projects')).rejects.toBeInstanceOf(ApiError);
  expect(localStorage.getItem('user')).toBeNull(); expect(localStorage.getItem('token')).toBeNull();
  expect(expired).toHaveBeenCalledTimes(1); window.removeEventListener('session-expired', expired);
});
test('validation details are shown and successful empty responses are accepted', async () => {
  fetch.mockResolvedValueOnce({ ok: false, status: 400, text: async () => '{"errors":{"Title":["Nhập tiêu đề"]}}' });
  await expect(api('/api/student/projects/1/proposal')).rejects.toThrow('Nhập tiêu đề');
  fetch.mockResolvedValueOnce({ ok: true, status: 204, text: async () => '' });
  await expect(api('/api/head/defenses/1', { method: 'DELETE' })).resolves.toBeNull();
});

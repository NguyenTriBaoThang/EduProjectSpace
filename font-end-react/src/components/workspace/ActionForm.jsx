import React, { useEffect, useRef, useState } from 'react';
import { api } from '../../api/client';
import { FormFields } from './CrudPage';

export default function ActionForm({ title, fields, initial = {}, endpoint, method = 'POST', prepare = value => value, onSaved, options = {} }) {
  const [value, setValue] = useState(initial);
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  const pending = useRef(null);
  useEffect(() => () => pending.current?.abort(), []);
  return <form className="student-form mb-4" onSubmit={async event => {
    event.preventDefault(); if (busy) return; setBusy(true); setMessage(''); pending.current = new AbortController();
    try { await api(typeof endpoint === 'function' ? endpoint(value) : endpoint, { method, body: prepare(value), signal: pending.current.signal }); setMessage('Đã lưu thành công.'); onSaved?.(); }
    catch (e) { if (e.name !== 'AbortError') setMessage(e.message); } finally { setBusy(false); }
  }}><h2>{title}</h2>{message && <p role="status">{message}</p>}<FormFields fields={fields} value={value} onChange={setValue} options={options} /><button className="btn btn-primary" disabled={busy}>{busy ? 'Đang lưu…' : title}</button></form>;
}

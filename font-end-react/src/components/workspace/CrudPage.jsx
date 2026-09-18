import React, { useEffect, useRef, useState } from 'react';
import * as XLSX from 'xlsx';
import { api } from '../../api/client';
import useResource from '../../api/useResource';
import Resource from './Resource';
import DataTable from './DataTable';

function normalize(fields, row = {}) {
  return Object.fromEntries(fields.map(field => {
    let value = row[field.key] ?? (field.type === 'checkbox' ? false : field.multiple ? [] : field.default ?? '');
    if (field.type === 'date') value = value.slice(0, 10);
    if (field.type === 'datetime-local' && value) { const date = new Date(value); value = new Date(date.getTime() - date.getTimezoneOffset() * 60000).toISOString().slice(0, 16); }
    return [field.key, value];
  }));
}

export function FormFields({ fields, value, onChange, options = {}, editing = false }) {
  return fields.filter(field => !field.hidden && !(editing && field.createOnly) && !(!editing && field.editOnly)).map(field => {
    const choices = field.options || options[field.key];
    const props = { name: field.key, 'aria-label': field.label, required: field.required, disabled: field.disabled, className: 'form-control', value: value[field.key] ?? (field.multiple ? [] : ''), onChange: event => onChange({ ...value, [field.key]: field.multiple ? Array.from(event.target.selectedOptions, option => field.numeric ? Number(option.value) : option.value) : field.type === 'checkbox' ? event.target.checked : event.target.value }) };
    return <label key={field.key} className="d-grid gap-1">{field.label}{choices ? <select {...props} multiple={field.multiple} className="form-select">{!field.multiple && <option value="">Chọn {field.label.toLowerCase()}</option>}{choices.map(option => <option key={option.value} value={option.value}>{option.label}</option>)}</select> : field.type === 'textarea' ? <textarea {...props} rows={4} maxLength={field.maxLength || 10000} /> : field.type === 'checkbox' ? <input {...props} type="checkbox" checked={Boolean(value[field.key])} className="form-check-input" /> : <input {...props} type={field.type || 'text'} maxLength={field.maxLength || 255} min={field.min} max={field.max} step={field.step} />}{field.help && <small className="text-muted">{field.help}</small>}</label>;
  });
}

export default function CrudPage({ config, initialCreate = false, initialId }) {
  const resource = useResource(config.listPath || config.endpoint);
  const [options, setOptions] = useState({});
  const [optionError, setOptionError] = useState('');
  const [editing, setEditing] = useState(null);
  const [form, setForm] = useState({});
  const [error, setError] = useState('');
  const [notice, setNotice] = useState('');
  const [busy, setBusy] = useState(false);
  const dialog = useRef(null);
  const pending = useRef(null);
  const input = useRef(null);
  const initialOpened = useRef(false);
  useEffect(() => {
    if (initialOpened.current || resource.loading || resource.error || !resource.data) return;
    const rows = config.select ? config.select(resource.data) : resource.data;
    const row = initialId ? rows.find(item => String(item.id) === String(initialId)) : null;
    if (initialCreate || row) { setEditing(row || {}); setForm(normalize(config.fields, row || {})); }
    initialOpened.current = true;
  }, [resource.loading, resource.error, resource.data, config, initialCreate, initialId]);
  useEffect(() => {
    const controller = new AbortController();
    Promise.all(Object.entries(config.lookups || {}).map(async ([key, lookup]) => [key, (await api(lookup.path, { signal: controller.signal })).map(row => ({ value: row[lookup.value || 'id'], label: row[lookup.label || 'name'] }))]))
      .then(entries => { if (!controller.signal.aborted) setOptions(Object.fromEntries(entries)); })
      .catch(e => { if (!controller.signal.aborted) setOptionError(e.message); });
    return () => controller.abort();
  }, [config]);
  useEffect(() => () => pending.current?.abort(), []);
  useEffect(() => { if (editing !== null) dialog.current?.showModal(); }, [editing]);
  function open(row) { setError(''); setEditing(row || {}); setForm(normalize(config.fields, row)); }
  function payload(row) {
    const value = { ...row };
    for (const field of config.fields) {
      if (field.numeric && !field.multiple) value[field.key] = value[field.key] === '' ? null : Number(value[field.key]);
      if (field.type === 'date' && !value[field.key]) value[field.key] = null;
      if (field.type === 'datetime-local') value[field.key] = value[field.key] ? new Date(value[field.key]).toISOString() : null;
      if (field.type === 'password' && !value[field.key]) value[field.key] = null;
    }
    return config.prepare ? config.prepare(value) : value;
  }
  async function mutate(path, method, body, success) {
    if (busy) return;
    setBusy(true); setError(''); pending.current = new AbortController();
    try { const result = await api(path, { method, body, signal: pending.current.signal }); setNotice(success); resource.reload(); return result ?? true; }
    catch (e) { if (e.name !== 'AbortError') setError(e.message); return false; } finally { setBusy(false); }
  }
  async function save(event) {
    event.preventDefault();
    const body = payload({ ...editing, ...form });
    if (config.validate) { const message = config.validate(body); if (message) { setError(message); return; } }
    const path = editing.id ? (config.updatePath?.(editing.id) || `${config.endpoint}/${editing.id}`) : (config.createPath || config.endpoint);
    if (await mutate(path, editing.id ? 'PUT' : 'POST', body, 'Đã lưu dữ liệu.')) { dialog.current.close(); setEditing(null); }
  }
  async function remove(row) {
    if (!window.confirm(`Xóa ${row.fullName || row.title || row.name || 'bản ghi này'}?`)) return;
    await mutate(config.deletePath?.(row.id) || `${config.endpoint}/${row.id}`, 'DELETE', undefined, 'Đã xóa.');
  }
  function exportRows(rows) {
    const sheet = XLSX.utils.json_to_sheet(rows.map(row => Object.fromEntries([
      ...config.columns.filter(c => !c.exportIgnore).map(c => [c.label, c.export ? c.export(row) : row[c.key] ?? '']),
      ...(config.importPath ? config.fields.filter(f => !f.editOnly && !f.hidden).map(f => [f.label, f.type === 'password' ? '' : row[f.key] ?? '']) : [])
    ])));
    const book = XLSX.utils.book_new(); XLSX.utils.book_append_sheet(book, sheet, 'Data'); XLSX.writeFile(book, `${config.name}.xlsx`);
  }
  async function importRows(file) {
    if (!file) return;
    try {
      if (file.size > 5 * 1024 * 1024) throw new Error('Tệp nhập tối đa 5 MB.');
      const book = XLSX.read(await file.arrayBuffer());
      const records = XLSX.utils.sheet_to_json(book.Sheets[book.SheetNames[0]], { raw: false });
      if (!records.length || records.length > 1000) throw new Error('Tệp cần có từ 1 đến 1000 dòng.');
      const mapped = records.map(row => payload(Object.fromEntries(config.fields.filter(f => !f.editOnly).map(f => [f.key, row[f.label] ?? row[f.key] ?? f.default ?? '']))));
      const result = await mutate(config.importPath, 'POST', mapped, 'Đã xử lý tệp nhập.');
      if (result && result !== true) setNotice(`Nhập thành công ${result.successCount ?? 0} dòng; thất bại ${result.failedCount ?? 0} dòng. ${(result.errors || []).join(' ')}`);
    } catch (e) { setError(e.message); }
    finally { if (input.current) input.current.value = ''; }
  }
  return <>
    {notice && <p role="status" className="alert alert-success">{notice}</p>}
    {(error || optionError) && editing === null && <p role="alert" className="alert alert-danger">{error || optionError}</p>}
    <Resource resource={resource}>{data => {
      const rows = config.select ? config.select(data) : data;
      return <><div className="d-flex gap-2 mb-3 flex-wrap">{!config.readOnly && config.canCreate !== false && <button className="btn btn-primary" disabled={Boolean(optionError)} onClick={() => open(null)}>Thêm mới</button>}<button className="btn btn-outline-primary" onClick={() => exportRows(rows)}>Xuất Excel</button>{config.importPath && <><button className="btn btn-outline-primary" disabled={busy} onClick={() => input.current.click()}>Nhập Excel</button><input ref={input} type="file" hidden accept=".xlsx,.xls" onChange={e => importRows(e.target.files[0])} /></>}<button className="btn btn-outline-secondary" onClick={resource.reload}>Tải lại</button></div>
        <DataTable rows={rows} columns={[...config.columns, ...(!config.readOnly ? [{ key: 'actions', label: 'Thao tác', render: row => <div className="d-flex gap-2"><button className="btn btn-sm btn-outline-primary" disabled={busy || Boolean(optionError)} onClick={() => open(row)}>Sửa</button>{config.canDelete !== false && <button className="btn btn-sm btn-outline-danger" disabled={busy} onClick={() => remove(row)}>Xóa</button>}</div> }] : [])]} />
      </>;
    }}</Resource>
    <dialog ref={dialog} aria-label={editing?.id ? 'Chỉnh sửa' : 'Thêm mới'} onCancel={e => { if (busy) e.preventDefault(); else setEditing(null); }} className="workspace-dialog">
      {editing !== null && <form onSubmit={save} className="student-form"><h2>{editing.id ? 'Chỉnh sửa' : 'Thêm mới'}</h2>{error && <p role="alert" className="alert alert-danger">{error}</p>}<FormFields fields={config.fields} value={form} onChange={setForm} options={options} editing={Boolean(editing.id)} />{config.extraFields?.(form, setForm, options)}<div className="d-flex gap-2"><button className="btn btn-primary" disabled={busy}>Lưu</button><button type="button" className="btn btn-secondary" disabled={busy} onClick={() => { dialog.current.close(); setEditing(null); }}>Hủy</button></div></form>}
    </dialog>
  </>;
}

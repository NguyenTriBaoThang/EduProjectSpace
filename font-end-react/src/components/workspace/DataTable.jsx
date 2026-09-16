import React, { useMemo, useState } from 'react';

export default function DataTable({ rows, columns, label = 'Tìm kiếm', pageSize = 10 }) {
  const [search, setSearch] = useState('');
  const [page, setPage] = useState(1);
  const filtered = useMemo(() => rows.filter(row => columns.some(column => String(column.search ? column.search(row) : row[column.key] ?? '').toLocaleLowerCase('vi').includes(search.toLocaleLowerCase('vi')))), [rows, columns, search]);
  const total = Math.max(1, Math.ceil(filtered.length / pageSize));
  const current = Math.min(page, total);
  return <section>
    <label className="form-label">{label}<input className="form-control" value={search} onChange={event => { setSearch(event.target.value); setPage(1); }} type="search" /></label>
    <div className="table-responsive"><table className="table table-hover align-middle"><thead><tr>{columns.map(column => <th key={column.key} scope="col">{column.label}</th>)}</tr></thead>
      <tbody>{filtered.slice((current - 1) * pageSize, current * pageSize).map(row => <tr key={row.id}>{columns.map(column => <td key={column.key}>{column.render ? column.render(row) : row[column.key] ?? '—'}</td>)}</tr>)}
        {!filtered.length && <tr><td colSpan={columns.length}>Không có dữ liệu phù hợp.</td></tr>}
      </tbody></table></div>
    <nav aria-label="Phân trang" className="d-flex gap-3 align-items-center"><button className="btn btn-outline-primary" disabled={current === 1} onClick={() => setPage(current - 1)}>Trước</button><span>Trang {current}/{total} · {filtered.length} kết quả</span><button className="btn btn-outline-primary" disabled={current === total} onClick={() => setPage(current + 1)}>Sau</button></nav>
  </section>;
}

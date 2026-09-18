import React from 'react';
import useResource from '../../api/useResource';
import Resource from './Resource';
import DataTable from './DataTable';

export default function RemoteTable({ endpoint, columns, select = value => value, children }) {
  const resource = useResource(endpoint);
  return <Resource resource={resource}>{data => {
    const rows = select(data);
    if (!Array.isArray(rows)) return <p role="alert">Dữ liệu trả về không đúng định dạng.</p>;
    return <>{children?.(data, resource.reload)}<DataTable rows={rows.map((row, index) => ({ ...row, id: row.id ?? row.courseId ?? row.projectId ?? index }))} columns={columns} /></>;
  }}</Resource>;
}

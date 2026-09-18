import React from 'react';
export default function Resource({ resource, children }) {
  if (resource.loading) return <p role="status">Đang tải dữ liệu…</p>;
  if (resource.error) return <div role="alert" className="alert alert-danger">{resource.error} <button className="btn btn-outline-danger" onClick={resource.reload}>Thử lại</button></div>;
  return children(resource.data);
}

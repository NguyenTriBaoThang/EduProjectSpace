import React from 'react';
import { fireEvent, render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import DataTable from './DataTable';

const columns = [{ key: 'name', label: 'Tên' }];
test('filtering resets pagination and shrinking data keeps a valid page', () => {
  const rows = [{ id: 1, name: 'An' }, { id: 2, name: 'Bình' }, { id: 3, name: 'Chi' }];
  const view = render(<DataTable rows={rows} columns={columns} pageSize={1} />);
  fireEvent.click(screen.getByRole('button', { name: 'Sau' }));
  expect(screen.getByText('Bình')).toBeInTheDocument();
  fireEvent.change(screen.getByRole('searchbox'), { target: { value: 'Chi' } });
  expect(screen.getByText('Chi')).toBeInTheDocument();
  expect(screen.getByRole('button', { name: 'Trước' })).toBeDisabled();
  view.rerender(<DataTable rows={[]} columns={columns} pageSize={1} />);
  expect(screen.getByText('Không có dữ liệu phù hợp.')).toBeInTheDocument();
});
test('untrusted table values are rendered as text', () => {
  const payload = '<img src=x onerror="alert(1)">';
  const { container } = render(<DataTable rows={[{ id: 1, name: payload }]} columns={columns} />);
  expect(screen.getByText(payload)).toBeInTheDocument();
  expect(container.querySelector('img')).toBeNull();
});

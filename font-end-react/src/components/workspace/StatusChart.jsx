import React, { useEffect, useRef } from 'react';
import Chart from 'chart.js/auto';
export default function StatusChart({ labels, values }) {
  const canvas = useRef(null);
  useEffect(() => {
    const chart = new Chart(canvas.current, { type: 'doughnut', data: { labels, datasets: [{ data: values, backgroundColor: ['#285587', '#319976', '#dfa83a', '#c45167'] }] }, options: { responsive: true, maintainAspectRatio: false } });
    return () => chart.destroy();
  }, [labels, values]);
  return <div style={{ height: 260, maxWidth: 450 }}><canvas ref={canvas} role="img" aria-label={labels.map((label, index) => `${label}: ${values[index]}`).join(', ')} /></div>;
}

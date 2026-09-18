import React, { useEffect, useRef } from 'react';
import { Calendar } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
import viLocale from '@fullcalendar/core/locales/vi';

export default function CalendarView({ events }) {
  const root = useRef(null);
  useEffect(() => {
    const calendar = new Calendar(root.current, {
      plugins: [dayGridPlugin, timeGridPlugin, listPlugin], locale: viLocale,
      initialView: 'dayGridMonth', height: 'auto',
      headerToolbar: { left: 'prev,next today', center: 'title', right: 'dayGridMonth,timeGridWeek,listMonth' },
      events: events.map(event => ({ id: `${event.kind}-${event.id}`, title: event.title, start: event.startTime, end: event.endTime, backgroundColor: event.kind === 'defense' ? '#9b3c57' : '#285587' }))
    });
    calendar.render(); return () => calendar.destroy();
  }, [events]);
  return <div className="mb-4" ref={root} aria-label="Lịch học tập" />;
}

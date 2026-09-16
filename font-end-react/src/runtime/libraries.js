import Chart from 'chart.js/auto';
import * as XLSX from 'xlsx';
import Fuse from 'fuse.js';
import $ from 'jquery';
import select2 from 'select2';
import * as bootstrap from 'bootstrap';
import { Calendar } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import listPlugin from '@fullcalendar/list';
import Prism from 'prismjs';
import 'prismjs/components/prism-java';
import 'prismjs/components/prism-csharp';
import axios from 'axios';

if (!$.fn.select2) select2(window, $);
export { Chart, XLSX, Fuse, $, bootstrap, Prism, axios };
export const FullCalendar = {
  Calendar: class extends Calendar {
    constructor(element, options) {
      super(element, { plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin, listPlugin], ...options });
    }
  }
};

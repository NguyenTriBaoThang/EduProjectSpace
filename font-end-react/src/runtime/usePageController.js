import { useEffect, useRef } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { sanitizeMarkup } from './markup';
import { API_BASE_URL } from '../config';
import { resolvePageLink } from './links';
import * as libraries from './libraries';

// Each JSX screen owns one controller lifecycle. No script strings or window-global page functions.
export function usePageController(setup, definition) {
  const root = useRef(null);
  const handlers = useRef({});
  const navigate = useNavigate();
  const location = useLocation();
  useEffect(() => {
    const element = root.current;
    let disposed = false;
    let counter = 0;
    const callbacks = new Map();
    const cleanup = [];
    const ready = [];
    const abort = new AbortController();
    const timers = new Set();
    const objectUrls = new Set();
    const previousTitle = document.title;
    const previousClass = document.body.className;
    document.title = definition.title;
    document.body.className = definition.bodyClass || '';
    if (localStorage.getItem('theme') === 'dark') document.body.classList.add('dark-mode');
    for (const href of definition.links) {
      const link = document.createElement('link'); link.rel = 'stylesheet'; link.href = href;
      document.head.appendChild(link); cleanup.push(() => link.remove());
    }
    if (definition.styles.length) {
      const style = document.createElement('style'); style.textContent = definition.styles.join('\n');
      document.head.appendChild(style); cleanup.push(() => style.remove());
    }
    const localWindow = Object.create(null);
    const live = callback => (...args) => { if (!disposed) return callback(...args); };
    const scopedDocument = new Proxy(document, {
      get(target, property) {
        if (property === 'getElementById') return id => element.querySelector(`[id="${CSS.escape(String(id))}"]`);
        if (property === 'querySelector') return selector => element.querySelector(selector);
        if (property === 'querySelectorAll') return selector => element.querySelectorAll(selector);
        const value = Reflect.get(target, property, target);
        return typeof value === 'function' ? value.bind(target) : value;
      }
    });
    const go = live((url, replace = false) => {
      const destination = resolvePageLink(String(url), definition.source);
      if (/^https?:/i.test(destination)) window.location.assign(destination);
      else navigate(destination, { replace });
    });
    const scopedWindow = new Proxy(window, {
      get(target, property) {
        if (property === 'EDU_CONFIG') return { apiBaseUrl: API_BASE_URL };
        if (property in localWindow) return localWindow[property];
        const value = Reflect.get(target, property, target);
        // A canvas ID such as "progressChart" must not masquerade as a chart instance.
        if (value instanceof Element) return undefined;
        return typeof value === 'function' ? value.bind(target) : value;
      },
      set(target, property, value) { localWindow[property] = value; return true; }
    });
    const env = {
      ...libraries,
      document: scopedDocument, window: scopedWindow,
      navigate: go,
      alert: live(message => window.alert(message)),
      confirm: live(message => window.confirm(message)),
      ready(callback) { ready.push(callback); },
      objectUrl(blob) { const url = URL.createObjectURL(blob); objectUrls.add(url); return url; },
      bind(callback) { const key = String(++counter); callbacks.set(key, callback); return key; },
      html: value => sanitizeMarkup(value, definition.source),
      listen(target, event, callback, options) {
        if ((target === scopedDocument && event === 'DOMContentLoaded') || (target === scopedWindow && event === 'load')) { ready.push(callback); return; }
        const actual = target === scopedDocument ? document : target === scopedWindow ? window : target;
        if (!actual) throw new Error(`Missing element for ${event} in ${definition.source}`);
        actual.addEventListener(event, callback, options);
        cleanup.push(() => actual.removeEventListener(event, callback, options));
      },
      unlisten(target, event, callback, options) {
        (target === scopedDocument ? document : target === scopedWindow ? window : target)?.removeEventListener(event, callback, options);
      },
      fetch: async (input, options = {}) => {
        if (disposed) throw new DOMException('Page unmounted', 'AbortError');
        const response = await fetch(input, { credentials: 'include', ...options, signal: abort.signal });
        if (response.status === 401) { localStorage.removeItem('user'); localStorage.removeItem('token'); go('/login', true); }
        return response;
      },
      setTimeout(callback, delay, ...args) { const id = window.setTimeout(live(callback),delay,...args);timers.add(id);return id; },
      setInterval(callback, delay, ...args) { const id = window.setInterval(live(callback),delay,...args);timers.add(id);return id; },
      clearTimeout: id => window.clearTimeout(id),
      clearInterval: id => window.clearInterval(id)
    };
    const instances = [];
    env.Chart = class extends libraries.Chart { constructor(...args) { super(...args); instances.push(this); } };
    env.FullCalendar = { Calendar: class extends libraries.FullCalendar.Calendar { constructor(...args) { super(...args); instances.push(this); } } };
    const delegate = event => {
      const target = event.target.closest?.(`[data-page-${event.type}]`);
      if (target && element.contains(target)) {
        const callback = callbacks.get(target.getAttribute(`data-page-${event.type}`));
        if (callback) { event.preventDefault(); callback.call(target,event); }
      }
      if (event.type === 'click' && !event.defaultPrevented && !event.ctrlKey && !event.metaKey && event.button === 0) {
        const anchor = event.target.closest?.('a[href]');
        if (anchor && element.contains(anchor) && !anchor.target && !anchor.hasAttribute('download')) {
          const href = anchor.getAttribute('href');
          const destination = resolvePageLink(href, definition.source);
          if (destination?.startsWith('/') && !destination.startsWith('/assets/')) { event.preventDefault(); go(destination); }
        }
      }
    };
    for (const event of ['click','change','input','submit']) { element.addEventListener(event,delegate);cleanup.push(()=>element.removeEventListener(event,delegate)); }
    try {
      handlers.current = setup(env) || {};
      const reportError = error => { if (!disposed) console.error(error); };
      for (const callback of ready) Promise.resolve().then(live(callback)).catch(reportError);
    } catch (error) { console.error(`Cannot initialize ${definition.source}`,error); }
    return () => {
      disposed = true; abort.abort(); handlers.current = {}; callbacks.clear();
      for (const timer of timers) { window.clearTimeout(timer); window.clearInterval(timer); }
      for (const url of objectUrls) URL.revokeObjectURL(url);
      for (const item of instances) item.destroy();
      libraries.$(element).find('.select2-hidden-accessible').each(function () { libraries.$(this).select2('destroy'); });
      for (const modal of element.querySelectorAll('.modal')) libraries.bootstrap.Modal.getInstance(modal)?.dispose();
      for (const backdrop of document.querySelectorAll('.modal-backdrop')) backdrop.remove();
      document.body.style.removeProperty('padding-right'); document.body.style.removeProperty('overflow');
      cleanup.reverse().forEach(callback=>callback());
      document.title = previousTitle; document.body.className = previousClass;
    };
  }, [setup, definition, navigate, location.key]);
  return { root, invoke(name, event) { const result = handlers.current[name]?.call(event.currentTarget,event); if (result === false) event.preventDefault(); return result; } };
}

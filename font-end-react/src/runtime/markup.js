import DOMPurify from 'dompurify';
import { resolveAsset, resolvePageLink } from './links';

export function sanitizeMarkup(value, source) {
  const markup = String(value ?? '');
  const firstTag = /^\s*<(tr|td|th|thead|tbody|tfoot|colgroup|caption)\b/i.exec(markup)?.[1]?.toLowerCase();
  const wrapped = firstTag === 'tr' ? `<table><tbody>${markup}</tbody></table>`
    : ['td','th'].includes(firstTag) ? `<table><tbody><tr>${markup}</tr></tbody></table>`
    : firstTag ? `<table>${markup}</table>` : markup;
  const fragment = DOMPurify.sanitize(wrapped, { RETURN_DOM_FRAGMENT: true, ADD_ATTR: ['data-page-click','data-page-change','data-page-input','data-page-submit'] });
  for (const link of fragment.querySelectorAll('a[href]')) link.setAttribute('href', resolvePageLink(link.getAttribute('href'), source));
  for (const image of fragment.querySelectorAll('img[src]')) image.setAttribute('src', resolveAsset(image.getAttribute('src'), source));
  if (firstTag) return fragment.querySelector(firstTag === 'tr' ? 'tbody' : ['td','th'].includes(firstTag) ? 'tr' : 'table')?.innerHTML || '';
  const container = document.createElement('div'); container.appendChild(fragment); return container.innerHTML;
}

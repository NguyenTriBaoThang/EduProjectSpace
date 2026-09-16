import aliases from '../routeAliases.json';

const lookup = new Map(Object.entries(aliases).map(([key,value]) => [key.toLowerCase(),value]));
export function resolvePageLink(value, source, origin = window.location.origin) {
  if (!value || /^(#|mailto:|tel:|data:|blob:)/i.test(value)) return value;
  const url = new URL(value, `${origin}/font-end/${source}`);
  if (url.origin !== origin) return url.href;
  const route = lookup.get(url.pathname.toLowerCase());
  if (route) return route + url.search + url.hash;
  if (url.pathname.toLowerCase().endsWith('.html')) return '/404';
  return url.pathname + url.search + url.hash;
}

export function resolveAsset(value, source, origin = window.location.origin) {
  if (!value || /^(https?:|data:|blob:|#)/i.test(value)) return value;
  if (value.startsWith('/assets/') || value.startsWith('/static/')) return value;
  const url = new URL(value, `${origin}/font-end/${source}`);
  return url.pathname.replace(/^\/font-end\//i, '/assets/');
}

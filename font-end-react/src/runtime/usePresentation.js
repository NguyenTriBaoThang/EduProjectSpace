import { useEffect } from 'react';
import pages from '../pageManifest.json';

export function usePresentation(path) {
  useEffect(() => {
    const page = pages.find(item => item.path === path);
    const previous = document.title;
    document.title = page.title;
    const links = page.links.map(href => {
      const link = document.createElement('link'); link.rel = 'stylesheet'; link.href = href;
      document.head.appendChild(link); return link;
    });
    return () => { links.forEach(link => link.remove()); document.title = previous; };
  }, [path]);
}

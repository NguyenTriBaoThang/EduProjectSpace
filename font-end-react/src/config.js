export const API_BASE_URL = (process.env.REACT_APP_API_BASE_URL ||
  (['localhost', '127.0.0.1'].includes(window.location.hostname)
    ? 'https://localhost:7047' : window.location.origin)).replace(/\/$/, '');

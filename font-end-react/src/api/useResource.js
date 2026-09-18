import { useCallback, useEffect, useState } from 'react';
import { api } from './client';

export default function useResource(path) {
  const [state, setState] = useState({ loading: true, data: null, error: '' });
  const [revision, setRevision] = useState(0);
  const reload = useCallback(() => setRevision(value => value + 1), []);
  useEffect(() => {
    const controller = new AbortController();
    setState({ loading: true, data: null, error: '' });
    api(path, { signal: controller.signal }).then(data => {
      if (!controller.signal.aborted) setState({ loading: false, data, error: '' });
    }).catch(error => { if (!controller.signal.aborted) setState({ loading: false, data: null, error: error.message }); });
    return () => controller.abort();
  }, [path, revision]);
  return { ...state, reload };
}

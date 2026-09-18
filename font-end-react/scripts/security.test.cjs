const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const root = path.resolve(__dirname, '..');
const manifest = require('../src/pageManifest.json');
test('every route has a React component and route paths are unique', () => {
  assert.equal(new Set(manifest.map(page => page.path)).size, manifest.length);
  for (const page of manifest) assert.ok(fs.existsSync(path.join(root, page.component)), page.path);
  assert.ok(!fs.existsSync(path.join(root, 'src/runtime/usePageController.js')));
});
test('build has one frontend and no legacy copy lifecycle', () => {
  assert.ok(!fs.existsSync(path.join(root, '../font-end')));
  assert.ok(!fs.existsSync(path.join(root, 'public/legacy')));
  const scripts = require('../package.json').scripts;
  assert.ok(!scripts.prebuild && !scripts.prestart);
  assert.ok(!fs.existsSync(path.join(root, 'src/components/LegacyPage.js')));
});

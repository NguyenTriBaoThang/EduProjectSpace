const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const root = path.resolve(__dirname, '..');
const manifest = require('../src/pageManifest.json');
test('every migrated route has a React screen and controller', () => {
  assert.equal(new Set(manifest.map(page => page.path)).size, manifest.length);
  for (const page of manifest.filter(page => !page.native)) {
    const folder = page.source.split('/')[0];
    for (const extension of ['jsx', 'controller.js'])
      assert.ok(fs.existsSync(path.join(root, 'src/screens', folder, page.name + '.' + extension)), page.path);
  }
});
test('build has one frontend and no legacy copy lifecycle', () => {
  assert.ok(!fs.existsSync(path.join(root, '../font-end')));
  assert.ok(!fs.existsSync(path.join(root, 'public/legacy')));
  const scripts = require('../package.json').scripts;
  assert.ok(!scripts.prebuild && !scripts.prestart);
  assert.ok(!fs.existsSync(path.join(root, 'src/components/LegacyPage.js')));
});

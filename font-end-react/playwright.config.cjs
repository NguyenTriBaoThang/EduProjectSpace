const { defineConfig } = require('@playwright/test');
const fs = require('node:fs');
const localBrowser = ['C:/Program Files/Google/Chrome/Application/chrome.exe', 'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe'].find(p=>fs.existsSync(p));
module.exports = defineConfig({
  testDir: './tests', timeout: 30000, fullyParallel: false, workers: 1,
  use: { baseURL:'http://127.0.0.1:4173', headless:true, launchOptions:localBrowser?{executablePath:localBrowser}:{} },
  webServer:{command:'node scripts/serve-build.cjs',url:'http://127.0.0.1:4173',reuseExistingServer:false,timeout:30000},
  reporter:'list'
});

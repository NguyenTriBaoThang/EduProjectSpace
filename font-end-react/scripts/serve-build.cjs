const http = require('node:http');
const fs = require('node:fs');
const path = require('node:path');
const root = path.resolve(__dirname, '../build');
const types = { '.html':'text/html; charset=utf-8', '.js':'text/javascript', '.css':'text/css', '.json':'application/json', '.png':'image/png', '.jpg':'image/jpeg', '.svg':'image/svg+xml', '.woff2':'font/woff2', '.woff':'font/woff', '.ico':'image/x-icon' };
http.createServer((request,response)=>{
  let filename;
  try { filename = path.resolve(root, '.' + decodeURIComponent(new URL(request.url,'http://localhost').pathname)); }
  catch { response.writeHead(400).end(); return; }
  if(!filename.startsWith(root + path.sep) && filename!==root){response.writeHead(403).end();return;}
  if(!fs.existsSync(filename) || !fs.statSync(filename).isFile()){
    if(path.extname(filename) && path.extname(filename) !== '.html'){response.writeHead(404).end();return;}
    filename=path.join(root,'index.html');
  }
  response.setHeader('Content-Type',types[path.extname(filename)] || 'application/octet-stream');
  fs.createReadStream(filename).pipe(response);
}).listen(4173,'127.0.0.1',()=>console.log('React build: http://127.0.0.1:4173'));

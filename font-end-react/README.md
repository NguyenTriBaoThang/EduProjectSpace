# EduProjectSpace — React frontend

Chạy npm ci rồi npm start. Backend ASP.NET chạy riêng.

Đặt REACT_APP_API_BASE_URL trong .env.local nếu API khác https://localhost:7047.

Build: npm run build. Kiểm tra: npm run test:ci, node --test scripts/security.test.cjs và npx playwright test sau khi build.

Xem [kiến trúc và giới hạn kiểm thử](../docs/SINGLE-FRONTEND.md).

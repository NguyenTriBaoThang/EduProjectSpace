# Một frontend React

Giao diện duy nhất nằm trong font-end-react: 68 tuyến trang, gồm 3 trang React có sẵn và 65 màn hình chuyển sang JSX. Đã bỏ thư mục font-end và cơ chế sao chép public/legacy. Đường dẫn HTML cũ được ánh xạ sang React Router, giữ tham số truy vấn.

## Chạy và cấu hình

Trong font-end-react, chạy npm ci rồi npm start. Backend ASP.NET chạy riêng. API local mặc định https://localhost:7047; đặt REACT_APP_API_BASE_URL trong .env.local trước khi khởi động hoặc build để đổi địa chỉ. Khi triển khai, web server cần trả index.html cho các tuyến giao diện.

## Cấu trúc và giới hạn

- src/App.js: định tuyến và kiểm tra vai trò phía giao diện. Backend vẫn phải kiểm tra quyền.
- src/pageManifest.json: danh sách trang.
- src/screens: JSX và controller cho các trang chuyển đổi.
- src/runtime: vòng đời controller, dọn event/timer/request khi rời trang, xử lý liên kết và làm sạch HTML động bằng DOMPurify.
- public/assets: CSS, ảnh và tài nguyên tĩnh dùng chung.

Controller vẫn giữ một phần thao tác DOM từ giao diện cũ, gồm bảng dữ liệu và jQuery/Select2. Chuyển toàn bộ bảng sang React state/components là bước cải tiến tiếp theo. Dữ liệu mẫu được giữ; chưa phải mọi màn hình đều có API đầy đủ.

## Kiểm tra

Chạy node --test scripts/security.test.cjs, npm run test:ci, npm run build, rồi npx playwright test.

Playwright dùng Chrome/Edge đã cài trên Windows, hoặc Chromium của Playwright (npx playwright install chromium). Các ca trình duyệt dùng API giả lập để kiểm tra render, điều hướng, lịch và modal; chưa thay thế kiểm thử tích hợp SQL/SMTP và nghiệp vụ với dữ liệu thật.

Frontend HTML trước chuyển đổi được lưu cục bộ tại .migration-backup/font-end-before-react-20260916-235200.zip (Git bỏ qua). Bản sao này không được dùng khi chạy hay build.

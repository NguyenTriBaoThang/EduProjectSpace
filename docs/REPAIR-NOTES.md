# Sửa lỗi và chạy dự án

## Các thay đổi chính

- API trưởng bộ môn yêu cầu ROLE_HEAD; bộ lọc HeadScopeFilter lấy ID từ JWT và kiểm tra khoa/nhóm trước khi gọi action.
- API quản trị thông báo/cấu hình/danh sách người nhận chỉ dành cho admin. Người dùng khác chỉ xem thông báo được gửi cho mình/nhóm mình. GET cấu hình không trả mật khẩu SMTP; để trống mật khẩu khi lưu sẽ giữ mật khẩu hiện tại.
- Backend không phục vụ wwwroot bằng static-file middleware nữa. Các URL `/resource/...`, `/submissions/...` và `/api/File/files/...` đều qua xác thực và kiểm tra quyền dữ liệu. Giữ nguyên tệp hiện tại để tránh mất dữ liệu. **Không cấu hình IIS/nginx/CDN phục vụ trực tiếp thư mục wwwroot này.**
- Tệp không có bản ghi Resource/Submission/SubmissionVersion tương ứng không được chia sẻ cho người dùng thường. Admin vẫn có thể truy cập để kiểm tra/migrate dữ liệu cũ.
- Upload tài liệu dùng đường dẫn sinh bởi server, giới hạn loại/kích thước và quyền theo đề tài. Không nhận đường dẫn tệp trên máy chủ từ client để sao chép/xóa.
- Hai điểm XSS được phát hiện trong bảng tiêu chí và thông báo admin đã mã hóa nội dung trước khi đưa vào HTML.
- Nhắc hạn hỗ trợ người nhận cá nhân, không gửi lại bản đã thành công và tái sử dụng bản đang chờ khi thử lại. Chỉ bật gửi email khi EnableEmail được bật trong cấu hình thông báo. Nên chạy một instance worker nhắc hạn; nhiều instance cần cơ chế khóa/idempotency ở cơ sở dữ liệu.

## Cấu hình

- Development: backend dùng cấu hình hiện có; frontend local mặc định gọi `https://localhost:7047`.
- React: đặt `REACT_APP_API_BASE_URL=https://api.example.edu` trước khi `npm run build` để cấu hình ứng dụng React.
- Backend production: đặt `Cors__AllowedOrigins__0=https://app.example.edu` và các origin tiếp theo nếu cần. Không bật wildcard cùng cookie.
- Đặt `ConnectionStrings__DefaultConnection`, `Jwt__Key`, `Jwt__Issuer`, `Jwt__Audience`, `Smtp__Host`, `Smtp__Port`, `Smtp__Username`, `Smtp__Password` qua biến môi trường/secret store. Không dùng khóa JWT development cho production. Cookie yêu cầu HTTPS.
- Các tệp AI chạy trên loopback và tắt debug mặc định; có thể cấu hình `AI_HOST`, `AI_PORT`. CRUD tài liệu không còn phụ thuộc vào việc có khóa Hugging Face.

## Kiểm tra

```powershell
dotnet test back-end/EduProject_TADProgrammer.Tests/EduProject_TADProgrammer.Tests.csproj
cd font-end-react
node --test scripts/security.test.cjs
npm run build
```

Test backend dùng cơ sở dữ liệu in-memory riêng, không kết nối SQL Server hay gửi email thật. Vẫn cần kiểm tra triển khai với SQL Server, HTTPS, tài khoản thuộc các khoa/nhóm khác nhau và SMTP thực tế. Các cảnh báo nullable cũ của backend chưa được xử lý toàn bộ.

## Một frontend React

Đã thay cầu nối HTML bằng 65 màn hình JSX và 3 trang React hiện có. Xem [hướng dẫn kiến trúc và kiểm tra](SINGLE-FRONTEND.md).

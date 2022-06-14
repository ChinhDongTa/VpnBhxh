# Quản lý người dùng vpn
Prerequisite:
1. VS Community 2002
2. Microsoft RDLC Report Designer
3. Entity Framework core 6.0
4. Asp.net core, Blazor, C# (base)
5. SQL server 2008 hoặc sql localDB (chỉ dùng cho cá nhân để test)

Dùng Pakage Manager Console tạo Database sửa connectionString cho phù hợp (VpnDomain.Models.VpnBhxhContext.cs): 
1. add-migration [migrationName]
2. update-database

=> Chỉ lấy NhanVien(Id, HoTen, MaChucVu, MaPhongBan, Email, DienThoai), các trường còn lại có thể bỏ hoặc thêm vào khi cần sau này.

Mọi người có thể sử dụng và mở rộng cho mình.


Enjoy !!!


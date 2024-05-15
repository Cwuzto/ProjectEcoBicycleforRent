CREATE DATABASE EcoBicycleForRent

GO
USE EcoBicycleForRent


CREATE TABLE LoaiKhachHang 
(
    MaLKH INTEGER IDENTITY(1,1) NOT NULL,
    TenLKH NVARCHAR(80) NOT NULL,
    PRIMARY KEY (MaLKH)
)

CREATE TABLE KhachHang 
(
    MaKH INTEGER IDENTITY(1,1) NOT NULL,
    HoTen NVARCHAR(50),
    SDT VARCHAR(11),
    CCCD VARCHAR(12),
    GioiTinh NVARCHAR(3),
    Email VARCHAR(50),
    DiaChi NVARCHAR(30),
    SoDu DECIMAL,
    NgayDangKy DATETIME,
    TrangThaiThe NVARCHAR(20),
	UserName VARCHAR(15),
    Password varchar(15),
    MaLKH INTEGER FOREIGN KEY(MaLKH) REFERENCES LoaiKhachHang(MaLKH),
    PRIMARY KEY (MaKH)
)

CREATE TABLE LoaiXe 
(
    MaLX INTEGER IDENTITY(1,1) NOT NULL,
    TenLoai NVARCHAR(20),
    SoLuong INTEGER,
    DonGiaChoThue DECIMAL,
    PRIMARY KEY (MaLX)
)

CREATE TABLE ChiNhanh 
(
    MaCN INTEGER IDENTITY(1,1) NOT NULL,
    TenCN NVARCHAR(20),
    DiaChi NVARCHAR(50),
    PRIMARY KEY (MaCN)
)

CREATE TABLE XeDap 
(
    MaXD INTEGER IDENTITY(1,1) NOT NULL,
    TenXD NVARCHAR(20),
    TinhTrang NVARCHAR(10),
    MaLX INTEGER FOREIGN KEY(MaLX) REFERENCES LoaiXe(MaLX) NOT NULL,
    MaCN INTEGER FOREIGN KEY(MaCN) REFERENCES ChiNhanh(MaCN) NOT NULL,
    PRIMARY KEY (MaXD)
)

CREATE TABLE TramThueXe 
(
    MaTTX INTEGER IDENTITY(1,1) NOT NULL,
    DiaChi NVARCHAR(50),
    MaCN INTEGER FOREIGN KEY(MaCN) REFERENCES ChiNhanh(MaCN) NOT NULL,
    PRIMARY KEY (MaTTX)
)

CREATE TABLE LoaiNhanVien 
(
    MaLNV INTEGER IDENTITY(1,1) NOT NULL,
    TenLNV NVARCHAR(30) NOT NULL,
    PRIMARY KEY (MaLNV)
)

CREATE TABLE NhanVien 
(
    MaNV INTEGER IDENTITY(1,1) NOT NULL,
    HoTenNV NVARCHAR(50),
    DiaChiNV NVARCHAR(50),
    SDT VARCHAR(11),
    Email VARCHAR(50),
    GioiTinh NVARCHAR(3),
    MaLNV INTEGER FOREIGN KEY(MaLNV) REFERENCES LoaiNhanVien(MaLNV) NOT NULL,
	MaTTX INTEGER FOREIGN KEY(MaTTX) REFERENCES TramThueXe(MaTTX),
    UserName VARCHAR(15),
    Password varchar(15),
    PRIMARY KEY (MaNV)
)

CREATE TABLE XeDuocThue 
(
    MaXDT INTEGER IDENTITY(1,1) NOT NULL,
    MaXD INTEGER FOREIGN KEY(MaXD) REFERENCES XeDap(MaXD) NOT NULL,
    MaKH INTEGER FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH) NOT NULL,
    NgayThue DATE,
    TinhTrang NVARCHAR(20),
    NgayTra DATETIME,
    GiaTien DECIMAL,
    PRIMARY KEY (MaXDT)
)

------Nhập cơ sở dữ liệu--------
------Nhập loại khách hàng--------
INSERT INTO LoaiKhachHang ( TenLKH)
VALUES ( N'Khách hàng dùng thẻ trả trước'), 
       ( N'Khách hàng dùng thẻ trả sau');

------Nhập khách hàng--------
INSERT INTO KhachHang (MaKH, HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, SoDu, NgayDangKy, TrangThaiThe, UserName, Password, MaLKH)
VALUES ('KH01', N'Nguyễn Văn A', '0123456789', '123456789012', N'Nam', 'abc@gmail.com', N'123 Đường ABC', 1000000, GETDATE(), 'Active', 'user1', '1', 1),
       ('KH02', N'Trần Thị B', '0987654321', '987654321012', N'Nữ', 'def@gmail.com', N'456 Đường XYZ', 0, GETDATE(), 'Active', 'user2', '2', 2),
	   ('KH03', N'Lê Thị Lan', '0123456789', '123456789012', N'Nữ', 'lethilan@gmail.com', N'789 Đường DEF', 1350000, GETDATE(), 'Active', 'user3', '3', 1),
       ('KH04', N'Trần Văn Nam', '0987654321', '987654321012', N'Nam', 'tranvannam@gmail.com', N'101 Đường PQR', 0, GETDATE(), 'Active', 'user4', '4', 2),
	   ('KH05', N'Phạm Văn Đức', '0123456789', '123456789012', N'Nam', 'phamvanduc@example.com', N'123 Đường LMN', 2550000, GETDATE(), 'Active', 'user5', '5', 1),
       ('KH06', N'Lê Thị Hương', '0987654321', '987654321012', N'Nữ', 'lethihuong@example.com', N'456 Đường PQR', 0, GETDATE(), 'Active', 'user6', '6', 2);

------Nhập loại xe--------
INSERT INTO LoaiXe ( TenLoai, SoLuong, DonGiaChoThue)
VALUES ( N'Xe đạp Eco', 10, 20000),
       ( N'Xe đạp thể thao', 5, 30000),
	   (N'Xe đạp địa hình', 6, 25000);

------Nhập chi nhánh--------
INSERT INTO ChiNhanh ( TenCN, DiaChi)
VALUES ( N'Thủ Dầu Một', N'123 Đường CMT8'),
       (N'Thuận An', N'101 Đường Nguyễn Trãi'),
	   (N'Dĩ An', N'999 Đường Lý Thường Kiệt');

------Nhập xe đạp--------
INSERT INTO XeDap ( TenXD, TinhTrang, MaLX, MaCN)
VALUES ( N'Xe đạp 1', N'Sẵn sàng', 1, 1),
       ( N'Xe đạp 2', N'Sẵn sàng', 2, 1),
       ( N'Xe đạp 3', N'Bảo trì', 1, 2),
	   ( N'Xe đạp 1', N'Sẵn sàng', 2, 3),
	   ( N'Xe đạp 2', N'Sẵn sàng', 3, 2),
	   ( N'Xe đạp 3', N'Sẵn sàng', 2, 1),
	   ( N'Xe đạp 1', N'Bảo trì', 3, 2),
	   ( N'Xe đạp 2', N'Sẵn sàng', 2, 1),
	   ( N'Xe đạp 3', N'Sẵn sàng', 3, 2),
	   ( N'Xe đạp 1', N'Bảo trì', 2, 3),
	   ( N'Xe đạp 2', N'Sẵn sàng', 1, 2),
	   ( N'Xe đạp 3', N'Bảo trì', 1, 1);

------Nhập trạm thuê xe--------
INSERT INTO TramThueXe ( DiaChi, MaCN)
VALUES (N'234 Đường Cộng Hòa', 1),
       ( N'537 Đường Trường Chinh', 2),
	   (N'79 Đường Võ Văn Ngân', 3),
       ( N'416 Đường Lào Cai', 1),
	   ( N'23 Đường Phú Lợi', 2),
       ( N'456 Đường Hoàng Văn Thụ', 3),
	   (N'353 Đường Ngô Gia Tự', 1),
       (N'46 Đường Thích Quảng Đức', 2),
	   (N'193 Đường Trần Hưng Đạo', 3),
       ( N'16 Đường CMT8', 2);

------Nhập loại nhân viên--------
INSERT INTO LoaiNhanVien (TenLNV)
VALUES (N'Quản lý'),
       (N'Nhân viên tại trạm');

------Nhập nhân viên--------
INSERT INTO NhanVien (MaNV, HoTenNV, DiaChiNV, SDT, Email, GioiTinh,  MaLNV, MaTTX, UserName, Password)
VALUES ('NV01', N'Nguyễn Văn Quản', N'789 Đường MNP', '0123456789', 'hoahong@gmail.com', N'Nam',  1, NULL, 'admin', 'adminpass'),
       ('NV02', N'Trần Thị Thuê Xe', N'101 Đường QRS', '0987654321', 'mimosa@gmail.com', N'Nữ',  2, 1, 'nv1', '123'),
	   ('NV03', N'Phạm Thị Thu', N'123 Đường LMN', '0123456789', 'phamthithu@gmail.com', N'Nữ', 2, 2,'nv2', '123'),
       ('NV04', N'Nguyễn Văn Tài', N'456 Đường XYZ', '0987654321', 'nguyenvantai@gmail.com', N'Nam',  2, 3,'nv3', '123'),
	   ('NV05', N'Nguyễn Thị Tú', N'789 Đường ABC', '0123456789', 'nguyenthitu@example.com', N'Nữ',  2, 4, 'nv4', '123'),
       ('NV06', N'Trần Văn Long', N'456 Đường XYZ', '0987654321', 'tranvanlong@example.com', N'Nam',  2, 5, 'nv5', '123'),
	   ('NV07', N'Nguyễn Văn A', N'789 Đường ABC', '0123456789', 'nguyenvana@example.com', N'Nam',  2, 3, 'nv6', '123'),
       ('NV08', N'Trần Thị B', N'456 Đường XYZ', '0987654321', 'tranthib@example.com', N'Nữ',  2, 4, 'nv7', '123'),
       ('NV09', N'Phạm Văn C', N'123 Đường LMN', '0123456789', 'phamvanc@example.com', N'Nam',  2, 3, 'nv8', '123'),
       ('NV10', N'Lê Thị D', N'101 Đường PQR', '0987654321', 'lethid@example.com', N'Nữ',  2, 4, 'nv9', '123');

------Nhập xe được thuê--------
INSERT INTO XeDuocThue ( MaXD, MaKH, NgayThue, TinhTrang, NgayTra, GiaTien)
VALUES ( 1, 1, '2024-05-12', N'Đang thuê', NULL, NULL),
       ( 2, 2, '2024-05-12', N'Đang thuê', NULL, NULL),
	   ( 1, 2, '2024-05-10', N'Đang thuê', NULL, NULL),
       ( 3, 1, '2024-05-11', N'Đang thuê', NULL, NULL),
	   ( 6, 3, '2024-05-12', N'Đang thuê', NULL, NULL),
       ( 1, 4, '2024-05-13', N'Đang thuê', NULL, NULL);

  use EcoBicycleForRent
  CREATE PROC USP_Logins
  @userName nvarchar(100), @passWord nvarchar(100)
  AS
  BEGIN
		SELECT * FROM dbo.NhanVien, dbo.KhachHang WHERE NhanVien.UserName = @userName AND NhanVien.Password = @passWord OR KhachHang.UserName = @userName AND KhachHang.Password = @passWord
  END
  GO
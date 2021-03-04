
CREATE DATABASE DBBILUXURY
GO

DROP DATABASE DBBILUXURY
GO

USE DBBILUXURY
GO

CREATE TABLE CONTACT
(
    ConTactID INT NOT NULL PRIMARY KEY,
    [ConTent] [NVARCHAR](MAX) NOT NULL,
    [Status] BIT NOT NULL
);
GO


INSERT INTO CONTACT
(
    [ConTactID], [ConTent], [Status]
)
VALUES
(
        1, N'FACEBOOK', 1
),
(
        2, N'INSTAGRAM', 1
),
(
        3, N'YOUTUBE', 1
)
GO

CREATE TABLE GIOITHIEU
(
    AboutID INT NOT NULL PRIMARY KEY,
    Title [NVARCHAR](50) NOT NULL,
    [Image] [VARCHAR](50) NOT NULL,
    [Description] [NVARCHAR](MAX) NOT NULL,
    [Status] BIT NOT NULL
);
GO

INSERT INTO GIOITHIEU
(
    [AboutID], [Title], [Image], [Description], [Status]
)
VALUES
(
        1, N'Về Thương Hiệu', 'link', N'Biluxury tiền thân là Bionline, là thương hiệu thời trang nam của Công ty CP thời trang Bimart, ra đời từ năm 2009, tiên phong phát triển theo hình thức chuỗi nhượng quyền và nhanh chóng đạt được nhiều thành tích ấn tượng.',  1
),
(
        2, N'MỐC THỜI GIAN', 'link', N'2009 Ra đời Showroom thời trang Bionline đầu tiên', 1
),
(
        3, N'TẦM NHÌN', 'link', N'rở thành thương hiệu thời trang nam hàng đầu được giới trẻ tin dùng', 1
),
(
        4, N'GIÁ TRỊ CỐT LÕI', 'link', N'Hàng hóa đa dạng: Biluxury đem đến những sản phẩm thiết yếu và cập nhật xu hướng thời trang - đáp ứng tối đa nhu cầu của khách hàng.', 1
)
GO


CREATE TABLE KHACHHANG
(
    MaKH INT NOT NULL PRIMARY KEY,
    TenKH [NVARCHAR](50) NOT NULL,
    NgaySinh DATE,
    DiaChi [NVARCHAR](MAX),
    Email [VARCHAR](50) NOT NULL,
    [Password] [VARCHAR](20) NOT NULL
);
GO

INSERT INTO KHACHHANG
( 
 [MaKH], [TenKH], [NgaySinh], [DiaChi], [Email], [Password]
)
VALUES
( 
 1, N'Lê Văn Nam', '1999-09-28', N'Hà Nội', 'lenam28091999@gmail.com', 'nam123' 
),
( 
 2, N'Trần Văn Sơn', '1999-12-15', N'Đà Nẵng', 'transon@gmail.com', 'son123' 
),
( 
 3, N'Đỗ Anh Đức', '2001-01-09', N'Hồ Chí Minh', 'ducda@gmail.com', 'duc123' 
)
GO

CREATE TABLE LOAISANPHAM
(
    MaLoaiSP INT NOT NULL PRIMARY KEY,
    TenLoaiSP [NVARCHAR](50) NOT NULL,
    MieuTa [NVARCHAR](MAX) NOT NULL
);
GO


INSERT INTO LOAISANPHAM
( 
 [MaLoaiSP], [TenLoaiSP], [MieuTa]
)
VALUES
( 
 1, N'VEST CÔNG SỞ', N'Bộ sưu tập áo vest nam Biluxury với thiết kế đậm chất nam tính, thanh lịch cùng chất lượng hàng đầu dành cho mọi quý ông công sở hiện đại, thời thượng. Khám phá ngay những item hàng đầu cho tủ đồ của bạn thêm đa dạng, mới mẻ!'
),
( 
 2, N'ÁO T - SHIRT', N'Bộ sưu tập áo vest nam Biluxury với thiết kế đậm chất nam tính, thanh lịch cùng chất lượng hàng đầu dành cho mọi quý ông công sở hiện đại, thời thượng. Khám phá ngay những item hàng đầu cho tủ đồ của bạn thêm đa dạng, mới mẻ!'
),
( 
 3, N'ÁO POLO', N'Bộ sưu tập áo vest nam Biluxury với thiết kế đậm chất nam tính, thanh lịch cùng chất lượng hàng đầu dành cho mọi quý ông công sở hiện đại, thời thượng. Khám phá ngay những item hàng đầu cho tủ đồ của bạn thêm đa dạng, mới mẻ!'
),
( 
 4, N'ÁO SƠ MI', N'Bộ sưu tập áo vest nam Biluxury với thiết kế đậm chất nam tính, thanh lịch cùng chất lượng hàng đầu dành cho mọi quý ông công sở hiện đại, thời thượng. Khám phá ngay những item hàng đầu cho tủ đồ của bạn thêm đa dạng, mới mẻ!'
),
( 
 5, N'QUẦN ÂU', N'Bộ sưu tập áo vest nam Biluxury với thiết kế đậm chất nam tính, thanh lịch cùng chất lượng hàng đầu dành cho mọi quý ông công sở hiện đại, thời thượng. Khám phá ngay những item hàng đầu cho tủ đồ của bạn thêm đa dạng, mới mẻ!'
)
GO

CREATE TABLE NHACUNGCAP
(
    MaNCC INT NOT NULL PRIMARY KEY,
    TenNCC [NVARCHAR](50) NOT NULL,
    DiaChi [NVARCHAR](MAX) NOT NULL,
    Phone [VARCHAR](12) NOT NULL
);
GO


INSERT INTO NHACUNGCAP
( 
 [MaNCC], [TenNCC], [DiaChi], [Phone]
)
VALUES
( 
 1, N'BILUXURY', N'Hà Nội', '0944328989'
)
GO


CREATE TABLE NHANVIEN
(
    MaNV INT NOT NULL PRIMARY KEY,
    TenNV [NVARCHAR](50) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi [NVARCHAR](50) NOT NULL,
    GioiTinh [CHAR](1) NOT NULL,
    GhiChu [NVARCHAR](MAX) NOT NULL,
    Account [VARCHAR](20) NOT NULL,
    [Password] [VARCHAR](20) NOT NULL
);
GO

INSERT INTO NHANVIEN
(
 [MaNV], [TenNV], [NgaySinh], [DiaChi], [GioiTinh], [GhiChu], [Account], [Password]
)
VALUES
(
 1, N'Nguyễn Thị Châm', '2000-09-02', N'Bắc Giang', 'G', 'Nhân viên mới, có chuyên môn', 'ChamNT', 'cham123'
),
(
 2, N'Lưu Quang Nghĩa', '1999-05-26', N'Điện Biên', 'B', 'Nhân viên cũ, đã nộp đơn xin nghỉ việc', 'NghiaLQ', 'nghia123'
)
GO

CREATE TABLE SHIPPER
(
    MaShipper INT NOT NULL PRIMARY KEY,
    TenShipper [NVARCHAR](50) NOT NULL,
    Phone [VARCHAR](12) NOT NULL,
);
GO

INSERT INTO SHIPPER
( 
 [MaShipper], [TenShipper], [Phone]
)
VALUES
(
 1, N'Trịnh Văn Quyền', '0975123456'
),
( 
 2, N'Tạ Quang Trường', '0379485615'
)
GO


CREATE TABLE FEEDBACK
(
    FeedbackID INT NOT NULL PRIMARY KEY,
    [Content] [NVARCHAR](MAX) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KHACHHANG(MaKH)
);
GO

INSERT INTO FEEDBACK
( 
 [FeedbackID], [Content], [CreatedDate], [MaKH]
)
VALUES
( 
 1, N'Sản phẩm tốt, giao nhanh', '2021-03-01', 1
),
( 
 2, N'Chất lượng tốt, giá hợp lý', '2021-02-23', 2
)
GO

CREATE TABLE DONHANG
(
    MaDH INT NOT NULL PRIMARY KEY,
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KHACHHANG(MaKH),
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NHANVIEN(MaNV),
    NgayDH DATETIME NOT NULL,
    MaShipper INT NOT NULL FOREIGN KEY REFERENCES SHIPPER(MaShipper)
);
GO


INSERT INTO DONHANG
( 
 [MaDH], [MaKH], [MaNV], [NgayDH], [MaShipper]
)
VALUES
( 
 1, 1, 1, '2021-03-01', 1
)
GO

CREATE TABLE SANPHAM
(
    MaSP INT NOT NULL PRIMARY KEY,
    TenSP [NVARCHAR](50) NOT NULL,
    MaNCC INT NOT NULL FOREIGN KEY REFERENCES NHACUNGCAP(MaNCC),
    MaLoaiSP INT NOT NULL FOREIGN KEY REFERENCES LOAISANPHAM(MaLoaiSP),
    Gia DECIMAL(18,2) NOT NULL,
    ChatLieu [NVARCHAR](MAX) NOT NULL,
    KieuDang [NVARCHAR](MAX) NOT NULL,
    XuatXu [NVARCHAR](50) NOT NULL,
    Notes[NVARCHAR](MAX) NOT NULL
);
GO

INSERT INTO SANPHAM
    (
    [MaSP], [TenSP], [MaNCC], [MaLoaiSP], [Gia], [ChatLieu], [KieuDang], [XuatXu], [Notes]
    )
VALUES
    (
        1, N'ÁO VEST NAM BILUXURY - TÍM THAN TỐI', 1, 1, 295.00, N'95% Cotton và 5% Spandex', N'Form slimfit ôm vừa người, tôn dáng', N'Việt Nam', N'BILUXURY'
),
    (
        2, N'ÁO PHÔNG NAM TAY NGẮN 4APKH007TTT', 1, 2, 1295.00, N'28% Rayon, 70% Spun, 2% Spandex', N'Form slimfit ôm vừa người, tôn dáng', N'Việt Nam', N'BILUXURY'
),
    (
        3, N'ÁO POLO NAM 4APCB002GHS', 1, 3, 385.00, N'95% CVC, 5% Spandex', N'Form slimfit ôm vừa người, tôn dáng', N'Việt Nam', N'BILUXURY'
),
    (
        4, N'ÁO SƠ MI NAM DÀI TAY SMDT019TRK', 1, 4, 295.00, N'88% Poly, 12% Moadal thoáng khí, mềm mát', N'Body fit ôm người, tôn dáng, nổi bật ưu điểm cơ thể', N'Việt Nam', N'BILUXURY'
),
    (
        5, N'QUẦN ÂU NAM BILUXURY - TÍM THAN SÁNG', 1, 5, 585.00, N'28% Rayon, 70% Spun, 2% Spandex', N'Ống đứng tôn dáng người mặc', N'Việt Nam', N'BILUXURY'
),
    (
        6, N'QUẦN ÂU NAM 4QAVB001DEN', 1, 5, 2295.00, N'95% Cotton và 5% Spandex', N'Form slimfit ôm vừa người, tôn dáng', N'Việt Nam', N'BILUXURY'
),
    (
        7, N'QUẦN ÂU NAM 4QAVC006XAH', 1, 5, 12.00, N'95% Cotton và 5% Spandex', N'Form slimfit ôm vừa người, tôn dáng', N'Việt Nam', N'BILUXURY'
)
GO

CREATE TABLE SIZE
(
    MaSP INT NOT NULL,
    Size INT NOT NULL,
    PRIMARY KEY (MaSP, Size),
    SoLuong INT NOT NULL
)


INSERT INTO [SIZE]
( 
 [MaSP], [Size], [SoLuong]
)
VALUES
(
 1, 30, 100
),
( 
 2, 31, 100
),
(
 3, 29, 100
)
GO

CREATE TABLE CHITIETDONHANG
(
    MaChiTietDH INT NOT NULL PRIMARY KEY,
    MaDH INT NOT NULL FOREIGN KEY REFERENCES DONHANG(MaDH),
    MaSP INT NOT NULL FOREIGN KEY REFERENCES SANPHAM(MaSP),
    SoLuong INT NOT NULL,
    Size INT NOT NULL
);
GO

INSERT INTO CHITIETDONHANG
( 
 [MaChiTietDH], [MaDH], [MaSP], [SoLuong], [Size]
)
VALUES
( 
 1, 1, 1, 3, 30
)
GO

CREATE TABLE NEWS
(
    [NewID] INT NOT NULL PRIMARY KEY,
    Title [NVARCHAR](MAX) NOT NULL,
    NewImage [NVARCHAR](50) NOT NULL,
    [Description] [NVARCHAR](MAX) NOT NULL,
    CreatedBy [NVARCHAR](50) NOT NULL,
    [Status] BIT NOT NULL,
    ViewCount INT NOT NULL,
    MaSP INT NOT NULL FOREIGN KEY REFERENCES SANPHAM(MaSP)
);
GO

INSERT INTO NEWS
( 
 [NewID], [Title], [NewImage], [Description], [CreatedBy], [Status], [ViewCount], [MaSP]
)
VALUES
( 
 1, N'TIẾT LỘ NGƯỜI BỐ CỦA CHUỖI 130 CỬA HÀNG THỜI TRANG BILUXURY', 'link', N'Không trực tiếp phát triển Biluxury, nhưng ông Lê Xuân Tám lại là người khơi nguồn và đồng hành cùng các con trong việc sáng lập, xây dựng Biluxury.', N'Lê Văn Nam', 1, 10, 1
)
GO

CREATE TABLE [IMAGE]
(
    ImageID INT NOT NULL PRIMARY KEY,
    LinkAnh [VARCHAR](50) NOT NULL,
    MaSP INT NOT NULL FOREIGN KEY REFERENCES SANPHAM(MaSP),
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KHACHHANG(MaKH),
    MaTinTuc INT NOT NULL FOREIGN KEY REFERENCES NEWS(NewID)
);
GO





CREATE DATABASE DuLieu_ThietBi;
GO
USE DuLieu_ThietBi;
GO
CREATE TABLE ThietBi (
	MaThietBi nvarchar(10) PRIMARY KEY,
	TenThietBi nText NOT NULL,
	DonGia nvarchar(12) NOT NULL
);
GO
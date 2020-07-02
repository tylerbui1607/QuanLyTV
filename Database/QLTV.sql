create database QLTV
go

use QLTV
go

create table NHA_CUNG_CAP
(
IDNCC int identity(1,1) primary key,
Ten nvarchar(100),
DiaChi nvarchar(100),
SDT char(10),
)
go

create table CHUC_VU
(
IDCV char(6) primary key,
Ten nvarchar(20),
)
go

create table NHAN_VIEN
(
IDNV int identity(1,1) primary key,
HoTen nvarchar(100),
DiaChi nvarchar(100),
SDT char(10),
NgayVaoLam smalldatetime,
NgaySinh smalldatetime,
Username nvarchar(50),
Password varchar(50),
IDCV char(6) not null,
Active int
)
go

create table LOAI_THANH_VIEN
(
IDLTV char(6) primary key,
Ten nvarchar(20),
HanMuon int
)
go

create table THANH_VIEN
(
IDTV int identity(1,1) primary key,
HoTen nvarchar(100),
DiaChi nvarchar(100),
SDT char(10),
CMND varchar(10),
NgayDangKy smalldatetime,
NgayHetHan smalldatetime,
NgaySinh smalldatetime,
IDLTV char(6) not null,
email nvarchar(100),
Anh nvarchar(300),
GioiTinh nvarchar(10)
)
go

create table NHA_XUAT_BAN
(
IDNXB int identity(1,1) primary key,
Ten nvarchar(100),
)
go

create table TAC_GIA
(
IDTG int identity(1,1) primary key,
Ten nvarchar(100),
)
go

create table SACH
(
IDSach int identity(1,1) primary key,
IDTG int not null,
IDNXB int not null,
Ten nvarchar(100),
TheLoai nvarchar(100),
ViTri varchar(20),
SL int,
SLHienTai int,
GiaSach float
)
go

create table PHIEU_NHAP
(
IDPN int identity(1,1) primary key,
IDNCC int,
IDNV int,
NgayNhap smalldatetime,
TriGia money,
)
go

create table CTNHAP
(
IDPN int identity(1,1),
IDSach int,
SL int,
GiaNhap money,
constraint PK_CTNHAP primary key(IDPN, IDSach) 
)
go
--create table PHIEU_MUON
--(
--IDPM int identity(1,1) primary key,
--IDTV int,
--IDNV int,
--NgayMuon smalldatetime,
--)
--go

--create table PHIEU_TRA
--(
--IDPT int primary key,
--IDTV int,
--IDNV int,
--NgayTra smalldatetime,
--)
--go

--create table CTMUON
--(
--IDPM int identity(1,1),
--IDSach int,
--SL int,
--constraint PK_CTMUON primary key(IDPM,IDSach) 
--)
--go

create table VI_PHAM
(
IDVP char(6) primary key,
Ten nvarchar(20),
PhiPhat money
)
go

create table CTTRA
(
IDPT int identity(1,1),
IDSach int,
SL int,
IDVP char(6) not null,
constraint PK_CTTRA primary key(IDPT,IDSach) 
)
go

--///////////////////////////////
create table PHIEU_MUON
(
IDPM int identity(1,1) primary key,
IDTV int,
IDNV int,
NgayMuon smalldatetime,
Tra int,
)

create table PHIEU_TRA
(
IDPT int primary key,
IDTV int,
IDNV int,
NgayTra smalldatetime,
TienPhat float,
)

create table CTMUON
(
IDPM int,
IDSach int,
SL int,
checktra int,
constraint PK_CTMUON primary key(IDPM,IDSach) 
)


--Khoa ngoai
alter table  NHAN_VIEN
add constraint FK_NV_CV 
foreign key (IDCV)
references CHUC_VU (IDCV)
go

alter table  THANH_VIEN
add constraint FK_TV_LTV 
foreign key (IDLTV)
references LOAI_THANH_VIEN (IDLTV)
go

alter table  PHIEU_NHAP
add constraint FK_PN_NCC 
foreign key (IDNCC)
references NHA_CUNG_CAP (IDNCC)

alter table  PHIEU_NHAP
add constraint FK_PN_NV 
foreign key (IDNV)
references NHAN_VIEN (IDNV)
go

alter table  PHIEU_MUON
add constraint FK_PM_TV 
foreign key (IDTV)
references THANH_VIEN (IDTV)

alter table  PHIEU_MUON
add constraint FK_PM_NV 
foreign key (IDNV)
references NHAN_VIEN (IDNV)
go

alter table  PHIEU_TRA
add constraint FK_PT_TV 
foreign key (IDTV)
references THANH_VIEN (IDTV)

alter table  PHIEU_TRA
add constraint FK_PT_NV 
foreign key (IDNV)
references NHAN_VIEN (IDNV)
go

alter table  CTNHAP
add constraint FK_CTN_PN 
foreign key (IDPN)
references PHIEU_NHAP (IDPN)

alter table  CTNHAP
add constraint FK_CTN_S 
foreign key (IDSach)
references SACH (IDSach)
go

alter table  CTMUON
add constraint FK_CTM_PM 
foreign key (IDPM)
references PHIEU_MUON (IDPM)

alter table  CTMUON
add constraint FK_CTM_S 
foreign key (IDSach)
references SACH (IDSach)
go

alter table  CTTRA
add constraint FK_CTT_PT 
foreign key (IDPT)
references PHIEU_TRA (IDPT)

alter table  CTTRA
add constraint FK_CTT_S
foreign key (IDSach)
references SACH (IDSach)

alter table  CTTRA
add constraint FK_CTT_VP 
foreign key (IDVP)
references VI_PHAM (IDVP)
go

alter table  SACH
add constraint FK_S_TG 
foreign key (IDTG)
references TAC_GIA (IDTG)

alter table  SACH
add constraint FK_S_NXB 
foreign key (IDNXB)
references NHA_XUAT_BAN (IDNXB)
go
--trigger
ALTER TABLE CHUC_VU
ADD CONSTRAINT Check_CV
CHECK(Ten=N'Thủ thư'or Ten=N'Quản lí'or Ten=N'khác')


ALTER TABLE VI_PHAM
ADD CONSTRAINT Check_VP
CHECK(Ten=N'Không vi phạm'or Ten=N'Quá hạn'or Ten=N'Làm mất sách'or Ten=N'Làm hỏng sách')


ALTER TABLE LOAI_THANH_VIEN
ADD CONSTRAINT Check_LTV
CHECK(Ten=N'Tiêu chuẩn'or Ten=N'Thân thiết'or Ten=N'VIP')


ALTER TABLE THANH_VIEN
ADD CONSTRAINT Check_GioiTinh
CHECK(GioiTinh=N'Nam'or GioiTinh=N'Nữ'or GioiTinh=N'Khác')


--check phone number format
ALTER TABLE NHAN_VIEN
ADD CONSTRAINT Check_phoneNV
CHECK(SDT not like '%[^0-9]%')

ALTER TABLE THANH_VIEN
ADD CONSTRAINT Check_phoneTV
CHECK(SDT not like '%[^0-9]%')

ALTER TABLE NHA_CUNG_CAP
ADD CONSTRAINT Check_phoneNCC
CHECK(SDT not like '%[^0-9]%')

--chec email format
ALTER TABLE THANH_VIEN
ADD CONSTRAINT Check_emailTV
CHECK(email LIKE '%_@__%.__%')

--check quantity of book
ALTER TABLE CTNHAP
ADD CONSTRAINT Check_SL_CTN
CHECK (SL>=1)

ALTER TABLE CTMUON
ADD CONSTRAINT Check_SL_CTM
CHECK (SL>=1)

ALTER TABLE CTTRA
ADD CONSTRAINT Check_SL_CTR
CHECK (SL>=1)

--check ngay het han va ngay 
ALTER TABLE THANH_VIEN
ADD CONSTRAINT Check_day_S_DK
CHECK (NgaySinh<NgayDangKy)

ALTER TABLE THANH_VIEN
ADD CONSTRAINT Check_day_DK_HH
CHECK (NgayDangKy<NgayHetHan)

ALTER TABLE NHAN_VIEN
ADD CONSTRAINT Check_day_S_VL
CHECK (NgaySinh<NgayVaoLam)

--1.insert Loai thanh vien
insert into LOAI_THANH_VIEN values ('LTV01',N'VIP','30')
insert into LOAI_THANH_VIEN values ('LTV02',N'Thân Thiết','14')
insert into LOAI_THANH_VIEN values ('LTV03',N'Tiêu chuẩn','7')
select *from LOAI_THANH_VIEN
--delete from LOAI_THANH_VIEN

--0.insert Thanh vien
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Nguyễn Thị Mén',N'Linh Trung-Thủ Đức','0987654321','272892919','2/5/2020','2/5/2021','12/7/2000','LTV01','hieumb749@gmail.com','xxx',N'Nữ')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Huỳnh Văn Tèo',N'Quận 9 - TPHCM','0987232221','22233344','2/5/2020','2/5/2021','10/2/1995','LTV02','teohv749@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Lê Văn Lú',N'Biên Hòa - Đồng Nai','0987444111','27668855','2/5/2020','2/5/2021','12/2/1999','LTV03','lulv7022@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Nguyễn Văn A',N'Đồng Tháp','0987541771','22224555','2/5/2020','2/5/2021','2/2/1999','LTV03','adidauday@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Trần Thị B',N'Quận 1 - TPHCM','0982125511','244445584','2/5/2020','2/5/2021','10/2/1999','LTV03','adivenha@gmail.com','xxx',N'Nữ')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Trần Văn C',N'Lào Cai','0984548811','26787855','2/5/2020','2/5/2021','2/8/1999','LTV03','okedoiem@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Nguyễn Thị T',N'Mỹ Tho','0933333311','27787855','2/5/2020','2/5/2021','6/6/1999','LTV03','avetruocday@gmail.com','xxx',N'Nữ')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Bùi Văn N',N'Trảng Bom','0256222333','299768855','2/5/2020','2/5/2021','5/5/1997','LTV03','khongdoiemdau@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Anh D',N'Long Thành','0222448811','25458855','2/5/2020','2/5/2021','3/2/1998','LTV03','axaulam@gmail.com','xxx',N'Nam')
INSERT INTO THANH_VIEN (HoTen,DiaChi,SDT,CMND,NgayDangKy,NgayHetHan,NgaySinh,IDLTV,email,Anh,GioiTinh) VALUES (N'Chị E',N'Biên Hòa','0932156987','25888855','2/5/2020','2/5/2021','2/3/1989','LTV03','chiataydi@gmail.com','xxx',N'Nữ')
select *from THANH_VIEN
--delete from THANH_VIEN

--2.insert chuc vu
insert into CHUC_VU values ('CV01',N'Thủ thư')
insert into CHUC_VU values ('CV02',N'Quản lí')
insert into CHUC_VU values ('CV03',N'khác')
select *from CHUC_VU
--delete from CHUC_VU

--3.insert vi pham
insert into VI_PHAM values ('VP01',N'Không vi phạm',0)
insert into VI_PHAM values ('VP02',N'Quá hạn',2000)
insert into VI_PHAM values ('VP03',N'Làm mất sách',500000)
insert into VI_PHAM values ('VP04',N'Làm hỏng sách',100000)
select *from VI_PHAM
--DELETE FROM VI_PHAM

--4.insert nha cung cap
insert into NHA_CUNG_CAP (Ten,DiaChi,SDT) values (N'Nguyễn Văn A',N'Bình Dương',N'0987456123')
insert into NHA_CUNG_CAP (Ten,DiaChi,SDT) values (N'Nguyễn Văn B',N'Đồng Nai',N'0987433222')
select *from NHA_CUNG_CAP

--5.INSERT NHAN VIEN
INSERT INTO NHAN_VIEN (HoTen,DiaChi,SDT,NgayVaoLam,NgaySinh,Username,Password,IDCV,Active) VALUES (N'Bùi Nhật Tiến',N'Gò Vấp, TPHCM','0212345959','1-1-2020','1-1-2000',N'admin',N'admin','CV01',1)
INSERT INTO NHAN_VIEN (HoTen,DiaChi,SDT,NgayVaoLam,NgaySinh,Username,Password,IDCV,Active) VALUES (N'Bùi Minh Hiếu',N'Đồng Nai','0212345959','2-1-2020','2-1-2001',N'nhanvien2',N'aca6320cedd91cfb70c9f954aa239cc7','CV02',1)
INSERT INTO NHAN_VIEN (HoTen,DiaChi,SDT,NgayVaoLam,NgaySinh,Username,Password,IDCV,Active) VALUES (N'Lê Thị Bom',N'Bình Dương','0212345959','2-1-2020','2-21-1998',N'nhanvien3',N'985558bcd7df5713d066705de5c765d8','CV03',1)
INSERT INTO NHAN_VIEN (HoTen,DiaChi,SDT,NgayVaoLam,NgaySinh,Username,Password,IDCV,Active) VALUES (N'Nguyễn Thị Nổ',N'Biên Hòa','0212345959','2-1-2020','5-11-1995',N'nhanvien4',N'a3d801c1b3eee84cb217b9407be1b816','CV03',1)
select *from NHAN_VIEN

--6. INSERT TAC GIA
INSERT INTO TAC_GIA (Ten) values (N'Hamlet Trương')
INSERT INTO TAC_GIA (Ten) values (N'Nguyễn Nhật Ánh')
INSERT INTO TAC_GIA (Ten) values (N'Tuệ Nghi')
INSERT INTO TAC_GIA (Ten) values (N'Nguyễn Minh Nhật')
INSERT INTO TAC_GIA (Ten) values (N'Phan Ý Yên')
INSERT INTO TAC_GIA (Ten) values (N'Iris Cao')
select *from TAC_GIA

-- 7. insert Nha xuat ban
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản Chính trị Quốc gia')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản Trẻ')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản giáo dục')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản Hội Nhà văn')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản Tư pháp')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản thông tin và truyền thông')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản lao động')
INSERT into NHA_XUAT_BAN (Ten) VALUES (N'Nhà xuất bản văn học')
select *from NHA_XUAT_BAN
-- 8. insert Sách
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'1',N'9',N'Có Một Ai Đó Đã Đổi Thay',N'Truyện ngắn',N'A1','100','59',75000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'1',N'9',N'12 Cách yêu',N'Truyện ngắn',N'A12','100','20',99000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'3',N'9',N'Đàn Ông Hay Hứa, Phụ Nữ Hay Tin?',N'Truyện ngắn',N'A10','100','50',89000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'3',N'9',N'Sẽ có cách đừng lo',N'Truyện ngắn',N'B5','100','50',69000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'2',N'2',N'Mắt biếc',N'Truyện dài',N'B4','100','20',75000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'2',N'9',N'Tôi thấy hoa vàng trên cỏ xanh',N'Hư cấu',N'C2','100','40',45000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'4',N'9',N'Bao Giờ Là Đúng Lúc',N'Truyện ngắn',N'C1','100','50',79000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'4',N'9',N'Ai Cũng Đã Từng Yêu Như Thế',N'Truyện ngắn',N'D2','100','50',59000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'5',N'9',N'Mỉm cười cho qua',N'Tiểu thuyết',N'D3','100','35',63000)
insert into SACH (IDTG,IDNXB,Ten,TheLoai,ViTri,SL,SLHienTai,GiaSach) values (N'5',N'9',N'Ai rồi cũng khác',N'Truyện ngắn',N'D2','100','33',55000)
select *from SACH
--delete from SACH

-- 11.0 INSERT PHIEU NHAP
--INSERT INTO PHIEU_NHAP (IDNCC,IDNV,NgayNhap,TriGia) VALUES ('1','1','3/3/2020',3000000)
--select *from PHIEU_NHAP
--delete from PHIEU_NHAP

-- 11.1 INSERT CTNHAP
--INSERT INTO CTNHAP (IDPN,IDSach,SL,GiaNhap) VALUES ('1','1','600','50000')
--INSERT INTO CTNHAP (IDPN,IDSach,SL,GiaNhap) VALUES ('1','1','600','50000')
--select *from CTNHAP
--delete from CTNHAP

-- 10.0 INSERT PHIEU MUON
--INSERT INTO PHIEU_MUON (IDTV,IDNV,NgayMuon) VALUES ('1','1','7/1/2020')
--INSERT INTO PHIEU_MUON (IDTV,IDNV,NgayMuon) VALUES ('2','2','6/15/2020')
--SELECT *FROM PHIEU_MUON
--delete from PHIEU_MUON
-- 10.1 INSERT CTMUON
--INSERT INTO CTMUON (IDPM,IDSach,SL) VALUES ('1001','805','1')
--INSERT INTO CTMUON (IDPM,IDSach,SL) VALUES ('1002','801','1')
--SELECT *FROM CTMUON
--delete from CTMUON

-- 9.0 INSERT PHIEU TRA
--INSERT INTO PHIEU_TRA (IDPT,IDTV,IDNV,NgayTra) VALUES ('1','2','1','7/7/2020')
--INSERT INTO PHIEU_TRA (IDPT,IDTV,IDNV,NgayTra) VALUES ('2','2','2','6/7/2020')
--SELECT *FROM PHIEU_TRA
--delete from PHIEU_TRA

-- 9.1 insert CTTRA
--insert into CTTRA (IDPT,IDSach,SL,IDVP) VALUES ('1','1','1','VP01')
--insert into CTTRA (IDPT,IDSach,SL,IDVP) VALUES ('1','5','1','VP04')
--insert into CTTRA (IDPT,IDSach,SL,IDVP) VALUES ('2','2','2','VP01')
--insert into CTTRA (IDPT,IDSach,SL,IDVP) VALUES ('2','4','1','VP04')
--SELECT *FROM CTTRA
--delete from CTTRA


--/////ngay dang ky thanh vien va ngay muon
--CREATE TRIGGER NGM_NGDK_INSERT_UPDATEPM
--ON PHIEU_MUON
--FOR INSERT,UPDATE 
--AS 
--	DECLARE @NGM smalldatetime,  @NGDK smalldatetime
--	SELECT @NGM=NgayMuon ,@NGDK = NgayDangKy
--	FROM INSERTED,THANH_VIEN 
--	WHERE THANH_VIEN.IDTV=INSERTED.IDTV
--	IF (@NGM<@NGDK)
--	BEGIN 
--		ROLLBACK TRAN
--		RAISERROR('Ngày mượn phải >= Ngày Đăng ký',16,1)--print-> in ra mau den -> raiserror mau do
--		RETURN 
--	END

--CREATE TRIGGER NGM_NGDK_UPDATETV
--ON THANH_VIEN
--FOR UPDATE 
--AS 
--	DECLARE @NGM smalldatetime,  @NGDK smalldatetime
	
--	SELECT TOP 1 @NGM=NgayMuon ,@NGDK = NgayDangKy
--	FROM INSERTED,PHIEU_MUON 
--	WHERE PHIEU_MUON.IDTV=INSERTED.IDTV 
--	ORDER BY NgayMuon ASC 

--	IF (@NGM<@NGDK)
--	BEGIN 
--		ROLLBACK TRAN
--		RAISERROR('Ngày mượn phải >= Ngày đăng ký',16,1)--print-> in ra mau den -> raiserror mau do
--		RETURN 
--	END

USE [QLTV]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--delete nhan vien
CREATE PROC [dbo].[USP_DELETE_NV]
@IDNV int 
AS
BEGIN
	DELETE FROM NHAN_VIEN WHERE IDNV = @IDNV
END
GO

--delete thanh vien
CREATE PROC [dbo].[USP_DELETE_TV]
@IDTV int 
AS
BEGIN
	DELETE FROM THANH_VIEN WHERE IDTV = @IDTV
END
GO

--insert nhan vien
CREATE PROC [dbo].[USP_INSERT_NV]
	@IDNV int,
	@hoten nvarchar(100),
	@diachi nvarchar(100),
	@sdt char(10),
	@ngayvaolam smalldatetime,
	@ngaysinh smalldatetime,
	@username nvarchar(50),
	@password nvarchar(50),
	@IDCV char(6),
	@Active int
AS
BEGIN
	SET IDENTITY_INSERT NHAN_VIEN ON
	INSERT INTO NHAN_VIEN
	(
		IDNV,
		HoTen,
		DiaChi,
		SDT,
		NgayVaoLam,
		NgaySinh,
		Username,
		Password,
		IDCV,
		Active		
	)
	VALUES
	(
		@IDNV ,
		@hoten ,
		@diachi ,
		@sdt ,
		@ngayvaolam ,
		@ngaysinh ,
		@username ,
		@password ,
		@IDCV ,
		@Active 
	)
END
GO

--insert thanh vien
CREATE PROC [dbo].[USP_INSERT_TV]
	@IDTV int,
	@hoten nvarchar(100),
	@diachi nvarchar(100),
	@sdt char(10),
	@CMND varchar(10),
	@ngaydangki smalldatetime,
	@ngayhethan smalldatetime,
	@ngaysinh smalldatetime,
	@IDLTV char(6),
	@email nvarchar(100),
	@Image nvarchar(300),
	@Gioitinh nvarchar(10)
AS
BEGIN
	SET IDENTITY_INSERT THANH_VIEN ON
	INSERT INTO THANH_VIEN
	(
		IDTV,
		HoTen,
		DiaChi,
		SDT,
		CMND,
		NgayDangKy,
		NgayHetHan,
		NgaySinh,
		IDLTV,
		email,
		Anh,
		GioiTinh		
	)
	VALUES
	(
		@IDTV ,
		@hoten ,
		@diachi ,
		@sdt ,
		@CMND ,
		@ngaydangki ,
		@ngayhethan ,
		@ngaysinh ,
		@IDLTV ,
		@email ,
		@Image ,
		@Gioitinh 
	)
END
GO

--login
CREATE PROC [dbo].[USP_LOGIN]
@username nvarchar(100), @password nvarchar(100)
AS
BEGIN 
SELECT*FROM NHAN_VIEN WHERE Username = @username AND Password = @password
END
GO

--update nhan vien
CREATE PROC [dbo].[USP_UPDATE_NV]
	@IDNV int,
	@hoten nvarchar(100),
	@diachi nvarchar(100),
	@sdt char(10),
	@ngayvaolam smalldatetime,
	@ngaysinh smalldatetime,
	@username nvarchar(50),
	@password nvarchar(50),
	@IDCV char(6),
	@Active int
AS
BEGIN
	UPDATE NHAN_VIEN 
	SET HoTen = @hoten,
		DiaChi = @diachi,
		SDT = @sdt,
		NgayVaoLam = @ngayvaolam,
		NgaySinh = @ngaysinh,
		Username = @username,
		Password = @password,
		IDCV = @IDCV,
		Active = @Active
	WHERE IDNV = @IDNV				
END
GO

--update thanh vien
CREATE PROC [dbo].[USP_UPDATE_TV]
	@IDTV int,
	@hoten nvarchar(100),
	@diachi nvarchar(100),
	@sdt char(10),
	@CMND varchar(10),
	@ngaydangki smalldatetime,
	@ngayhethan smalldatetime,
	@ngaysinh smalldatetime,
	@IDLTV char(6),
	@email nvarchar(100),
	@Image nvarchar(300),
	@Gioitinh nvarchar(10)
AS
BEGIN
	UPDATE THANH_VIEN
	SET 
		HoTen = @hoten,
		DiaChi = @diachi,
		SDT = @sdt,
		CMND = @CMND,
		NgayDangKy = @ngaydangki,
		NgayHetHan = @ngayhethan,
		NgaySinh = @ngaysinh,
		IDLTV = @IDLTV,
		email = @email,
		Anh = @Image,
		GioiTinh = @Gioitinh
	WHERE IDTV = @IDTV				
END
go
--////////////////////////////////////////////
--insert phieu muon
CREATE PROC [dbo].[USP_INSERT_PM]
	@IDTV int,
	@IDNV int,
	@NgayMuon smalldatetime,
	@Tra int
AS
BEGIN
	INSERT INTO PHIEU_MUON
	(
		IDTV,
		IDNV,
		NgayMuon,
		Tra
	)
	VALUES
	(
		@IDTV,
		@IDNV,
		@NgayMuon,
		@Tra
	)
END
go

--update phieu muon
CREATE PROC [dbo].[USP_UPDATE_PM]
	@IDPM int,
	@Tra int
AS
BEGIN
	UPDATE PHIEU_MUON
	SET Tra = @Tra
	WHERE IDPM = @IDPM				
END
go
--insert chi tiet muon
CREATE PROC [dbo].[USP_INSERT_CTM]
	@IDPM int,
	@IDSach int,
	@SL int,
	@checktra int
AS
BEGIN
	INSERT INTO CTMUON
	(
		IDPM,
		IDSach,
		SL,
		checktra
	)
	VALUES
	(
		@IDPM,
		@IDSach,
		@SL,
		@checktra
	)
END
go
--update chi tiet muon
CREATE PROC [dbo].[USP_UPDATE_CTM]
	@IDPM int,
	@IDSach int,
	@SL int,
	@checktra int
AS
BEGIN
	UPDATE CTMUON
	SET checktra = @checktra
	WHERE IDPM = @IDPM AND IDSach = @IDSach		
END
go
--insert phieu tra
CREATE PROC [dbo].[USP_INSERT_PT]
	@IDPT int ,
	@IDTV int,
	@IDNV int,
	@NgayTra smalldatetime,
	@TienPhat float
AS
BEGIN
	INSERT INTO PHIEU_TRA
	(
		IDPT,
		IDTV,
		IDNV,
		NgayTra,
		TienPhat
	)
	VALUES
	(
		@IDPT,
		@IDTV,
		@IDNV,
		@NgayTra,
		@TienPhat
	)
END
go

-------------insert SACH-----------
CREATE PROC [dbo].[USP_INSERT_SACH]
	@IDSach int,
	@IDTG int,
	@IDNXB int,
	@Ten nvarchar(100),
	@TheLoai nvarchar(100),
	@ViTri varchar(20),
	@SL int,
	@SLHienTai int,
	@GiaSach float
	--moneyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy
AS
BEGIN
	SET IDENTITY_INSERT SACH ON
	INSERT INTO SACH
	(
		IDSach,
		IDTG,
		IDNXB,
		Ten,
		TheLoai,
		ViTri,
		SL,
		SLHienTai,
		GiaSach		
	)
	VALUES
	(
		@IDSach ,
		@IDTG ,
		@IDNXB ,
		@Ten ,
		@TheLoai ,
		@ViTri ,
		@SL ,
		@SLHienTai ,
		@GiaSach
	)
END
GO

--Update SACH
CREATE PROC [dbo].[USP_UPDATE_SACH]
	@IDSach int,
	@IDTG int,
	@IDNXB int,
	@Ten nvarchar(100),
	@TheLoai nvarchar(100),
	@ViTri varchar(20),
	@SL int,
	@SLHienTai int,
	@GiaSach float
AS
BEGIN
	UPDATE SACH
	SET 
		IDTG = @IDTG,
		IDNXB = @IDNXB,
		Ten = @Ten,
		TheLoai = @TheLoai,
		ViTri = @ViTri,
		SL = @SL,
		SLHienTai = @SLHienTai,
		GiaSach	= @GiaSach
	WHERE IDSach = @IDSach				
END
go


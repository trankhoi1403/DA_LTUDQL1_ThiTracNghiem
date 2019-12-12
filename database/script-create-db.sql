use master
go
if db_ID('QLTTN') is not null
begin
	ALTER DATABASE QLTTN SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	drop database QLTTN
end
create database QLTTN
go
use QLTTN
go

/* ============================= TẠO BẢNG VÀ KHÓA CHÍNH =============================*/
create table KyThi(
	maKT int primary key identity not null,
	TenKT nvarchar(100),
	NgayThi datetime,
	LoaiKT varchar(10),
	maGV varchar(10), -- thông tin giáo viên tạo kỳ thi
	DaThi bit
)

create table Thi(
	maHS varchar(10),
	maDT int,
	maKT int,
	Diem decimal
	primary key (maHS, maDT, maKT)
)

create table DeThi(
	maDT int primary key identity not null,
	maMH varchar(10),
	maKhoi varchar(3),
	maGV varchar(10),
	TenDT nvarchar(100),
	ThoiGianLamBai time,
	NgayTao DateTime
)

create table CT_DeThi(
	maDT int,
	maCH int,
	primary key (maDT, maCH)
)

create table CauHoi(
	maCH int primary key identity not null,
	NoiDung nvarchar(1000),
	maCD int,
	maMH varchar(10),
	maKhoi varchar(3)		
)

create table CapDo(
	maCD int primary key identity not null,
	TenCD nvarchar(100)
)

create table DapAn(
	maCH int,
	maDA int identity not null,
	NoiDung nvarchar(1000),
	DungSai bit,
	primary key (maCH, maDA)
)

create table MonHoc(
	maMH varchar(10),
	tenMH nvarchar(100),
	primary key (maMH)
)

create table KhoiLop(
	maKhoi varchar(3) primary key
)

create table LopHoc(
	maKhoi varchar(3),
	maLop varchar(3),
	primary key (maKhoi, maLop)
)

create table NguoiDung(
	maND varchar(10) primary key,
	MatKhau varchar(100),
	maLND varchar(10)
)

create table LoaiNguoiDung(
	maLND varchar(10) primary key,
	TenLND nvarchar(100),
)

create table HocSinh(
	maHS varchar(10) primary key,
	HoTen nvarchar(100),
	NgaySinh datetime,
	maKhoi varchar(3),
	maLop varchar(3)
)

create table GiaoVien(
	maGV varchar(10) primary key,
	HoTen nvarchar(100),
	NgaySinh datetime,
	maMH varchar(10)
)

create table CT_GiangDay(
	maGV varchar(10),
	maKhoi varchar(3),
	maLop varchar(3),
	SiSo int,
	primary key (maGV, maKhoi, maLop)
)
go


/* ============================== CẬP NHẬT KHÓA NGOẠI =============================*/
alter table HocSinh
add 
	constraint fk_hs_nd
	foreign key (maHS)
	references NguoiDung(maND)

alter table GiaoVien
add 
	constraint fk_gv_nd
	foreign key (maGV)
	references NguoiDung(maND),
	constraint fk_gv_mh
	foreign key (maMH)
	references MonHoc(maMH)

alter table CT_GiangDay
add
	constraint fk_ctgd_gv
	foreign key (maGV)
	references GiaoVien(maGV),
	constraint fk_ctgd_lh
	foreign key (maKhoi, maLop)
	references LopHoc(maKhoi, maLop)

alter table KyThi
add 
	constraint fk_kt_gv
	foreign key (maGV)
	references GiaoVien(maGV)

alter table Thi
add
	constraint fk_t_kt
	foreign key (maKT)
	references KyThi(maKT),
	constraint fk_t_dt
	foreign key (maDT)
	references DeThi(maDT),
	constraint fk_t_hs
	foreign key (maHS)
	references HocSinh(maHS)

alter table DeThi
add
	constraint fk_dt_mh
	foreign key (maMH)
	references MonHoc(maMH),
	constraint fk_dt_kl
	foreign key (maKhoi)
	references KhoiLop(maKhoi),
	constraint fk_dt_gv
	foreign key (maGV)
	references GiaoVien(maGV)

alter table CT_DeThi
add
	constraint fk_ctdt_dt
	foreign key (maDT)
	references DeThi(maDT),
	constraint fk_ctdt_ch
	foreign key (maCH)
	references CauHoi(maCH)

alter table CauHoi
add 
	constraint fk_ch_cd
	foreign key (maCD)
	references CapDo(maCD),
	constraint fk_ch_kl
	foreign key (maKhoi)
	references KhoiLop(maKhoi),
	constraint fk_ch_mh
	foreign key (maMH)
	references MonHoc(maMH)

alter table DapAn
add 
	constraint fk_da_ch
	foreign key (maCH)
	references CauHoi(maCH)

alter table LopHoc
add
	constraint fk_lh_kl
	foreign key (maKhoi)
	references KhoiLop(maKhoi)

alter table HocSinh
add
	constraint fk_hs_lh
	foreign key (maKhoi, maLop)
	references LopHoc(maKhoi, maLop)
go

alter table NguoiDung
add 
	constraint fk_nd_lnd
	foreign key (maLND)
	references LoaiNguoiDung(maLND)

/* ================================ TẠO TRIGGER =============================*/


/* ================================ TẠO DỮ LIỆU MẪU =============================*/
-- thêm khối lớp K10,K11,K12, mỗi khối có 9 lớp A1 -> C3
declare @i int, @c int
set @i = 10 
set @c = 65
while @i <= 12
begin
	declare @maK varchar(3)
	set @maK = 'K' + CAST(@i as char)

	insert into KhoiLop(maKhoi) values (@maK)
	while @c <= 67
	begin
		insert into LopHoc(maKhoi, maLop) values (@maK, char(@c) + CAST(1 as char))
		insert into LopHoc(maKhoi, maLop) values (@maK, char(@c) + CAST(2 as char))
		insert into LopHoc(maKhoi, maLop) values (@maK, char(@c) + CAST(3 as char))
		set @c += 1
	end

	set @i += 1
	set @c = 65
end
go

insert into MonHoc(maMH, tenMH) values ('T',  N'Toán')
insert into MonHoc(maMH, tenMH) values ('VL', N'Vật lý')
insert into MonHoc(maMH, tenMH) values ('HH', N'Hóa học')
insert into MonHoc(maMH, tenMH) values ('AV', N'Anh văn')
insert into MonHoc(maMH, tenMH) values ('TVH', N'Thiên Văn Học')

insert into LoaiNguoiDung(maLND, TenLND) values ('HS', N'Học sinh')
insert into LoaiNguoiDung(maLND, TenLND) values ('GV', N'Giáo viên')
insert into LoaiNguoiDung(maLND, TenLND) values ('AD', N'Quản trị viên')
go

insert into NguoiDung(MaND, MatKhau, maLND) values (1660339, '123', 'HS')
insert into NguoiDung(MaND, MatKhau, maLND) values (1660281, '123', 'HS')
insert into NguoiDung(MaND, MatKhau, maLND) values (1461638, '123', 'HS')
insert into NguoiDung(maND, MatKhau, maLND) values (1760013, '123', 'GV')
insert into NguoiDung(maND, MatKhau, maLND) values (1721001902, '123', 'GV')
insert into NguoiDung(maND, MatKhau, maLND) values (1, '123', 'AD')
go

insert into HocSinh(maHS, HoTen, NgaySinh, maKhoi, maLop) values(1660339, N'Nguyễn Thị Lý'  , '12/29/1998', 'K10', 'A1')
insert into HocSinh(maHS, HoTen, NgaySinh, maKhoi, maLop) values(1660281, N'Trần Khôi'      , '03/14/1998', 'K10', 'A1')
insert into HocSinh(maHS, HoTen, NgaySinh, maKhoi, maLop) values(1461638, N'Phan Xiêu Thiên', '01/09/1996', 'K12', 'A2')

insert into GiaoVien(maGV,HoTen, NgaySinh, MaMH) values(1760013, N'Lê Thanh Bình', '11/20/1990', 'T')
insert into GiaoVien(maGV,HoTen, NgaySinh, MaMH) values(1721001902, N'Trần Lam Ngọc', '09/21/1999', 'T')
go

insert into CT_GiangDay(maGV, maKhoi, maLop, SiSo) values(1760013, 'K10', 'A1', 30)
insert into CT_GiangDay(maGV, maKhoi, maLop, SiSo) values(1760013, 'K12', 'A2', 30)
insert into CT_GiangDay(maGV, maKhoi, maLop, SiSo) values(1721001902, 'K10', 'A1', 30)
go

insert into CapDo values
(N'Trứng cút'),
(N'Gà con'),
(N'Diều hâu'),
(N'Đại bàng')
go

insert into CauHoi(maMH, maKhoi, maCD, NoiDung) values
('TVH', 'K12', 1, N'Trong hệ Mặt Trời, hai hành tinh nào không có vệ tinh? '),
('TVH', 'K12', 1, N'Trọng lực bề mặt Trái Đất nặng gấp mấy lần trọng lực bề mặt Mặt Trăng? '),
('TVH', 'K12', 1, N'Mất bao lâu để tia sáng từ Mặt Trời đến Trái Đất? '),
('TVH', 'K12', 2, N'Anh hùng Phạm Tuân của Việt Nam đã bay lên vũ trụ năm 1980 trong một chương trình của nước nào? '),
('TVH', 'K12', 2, N'Con tàu đầu tiên đưa người lên Mặt Trăng là con tàu mang tên gì? '),
('TVH', 'K12', 2, N'Vũ trụ hình thành từ đâu? '),
('TVH', 'K12', 3, N'Sự nở ra của vũ trụ được phát hiện bởi nhà thiên văn nào? '),
('TVH', 'K12', 3, N'Vũ trụ giãn nở mà không co lại do đâu? '),
('TVH', 'K12', 3, N'Giả thuyết đến nay đã được khẳng định về vũ trụ giãn nở vĩnh viễn có tên là gì? '),
('TVH', 'K12', 4, N'Sự sống đã hình thành trên trái đất như thế nào? '),
('TVH', 'K12', 4, N'Cái gì gây ra trọng lực? '),

('T', 'K10', 1, N'Hai phương trình được gọi là tương đương khi:'),
('T', 'K10', 1, N'Cho phương trình:  f1(x) = g1(x) (1); f2(x) = g2(x) (2);  f1(x) + f2(x) = g2(x) + g2(x) (3).')

go

insert into DapAn(maCH, NoiDung, DungSai) values
--------------- đáp án môn THiên Văn Học K12
(1,  N'Sao Thủy và sao Kim', 1),
(1,  N'Sao Hỏa và sao Mộc', 0),
(1,  N'Sao Thổ và sao Thiên Vương', 0),
(1,  N'Sao Hải Dương và sao Diêm Vương', 0),
(2,  N'Gấp 4 lần', 0),
(2,  N'Gấp 5 lần', 0),
(2,  N'Gấp 6 lần', 1),
(2,  N'Gấp 7 lần', 0),
(3,  N'Mất 5 phút', 0),
(3,  N'Mất 6 phút', 0),
(3,  N'Mất 7 phút', 0),
(3,  N'Mất 8 phút', 1),
(4,  N'Mỹ', 0),
(4,  N'Châu Âu', 0),
(4,  N'Liên Xô', 1),
(5,  N'Apolo 9', 0),
(5,  N'Apolo 11', 1),
(5,  N'Apolo 13', 0),
(5,  N'Apolo 15', 0),
(6,  N'Một vụ nổ lớn tạo nên không gian và thời gian', 1),
(6,  N'Một đám khí và bụi tập hợp và hệ thống lại', 0),
(6,  N'Hậu quả của sự biến đổi nhiệt độ và áp suất', 0),
(7,  N'Arthur Eddington', 0),
(7,  N'Edwin Hubble', 1),
(7,  N'Harley Davidson', 0),
(7,  N'Galileo Galilei', 0),
(8,  N'Gia tốc ban đầu và tốc độ giản nở', 0),
(8,  N'Vật chất tối', 0),
(8,  N'Năng lượng tối', 0),
(8,  N'Khoa học chưa có lời giải thích', 1),
(9,  N'Vũ trụ phẳng', 0),
(9,  N'Vũ trụ mở', 1),
(9,  N'Vũ trụ đóng', 0),
(10, N'Thời xưa, Adam gặp Eva và sinh ra vạn vật', 0),
(10, N'Nhiều giả thuyết về nguồn gốc sự sống đã được nêu ra, nhưng vì rất khó để chứng minh hay bác bỏ chúng nên không tồn tại bất kỳ giả thuyết nào được chấp nhận hoàn toàn', 1),
(10, N'Đây là câu đúng', 0),
(11, N'Trọng lực là yếu nhất trong tất cả dạng lực đã biết trong vũ trụ và mô hình vật lý tiêu chuẩn hiện nay cũng không giải thích được cách thức hoạt động của nó. Các nhà vật lý lý thuyết cho rằng, trọng lực có thể liên quan đến những hạt rất nhỏ, không có khối lượng gọi là graviton. Những hạt này đã toả ra các từ trọng trường.', 0),
(11, N'Khoa học vẫn chưa tìm ra được', 1),
(11, N'Trọng lực hoàn toàn khác các lực còn lại được mô tả trong vật lý tiêu chuẩn', 0),
(11, N'Tôi không biết', 0),

------------ đáp án Môn Toán K10
(12, N'(3) tương đương với (1) hoặc (2)', 0),            
(12, N'(2) là hệ quả của (3)', 0),
(12, N'(3) là hệ quả của (1)',0),                     
(12, N'Các phát biểu a, b, c đều sai.', 1),
(13, N'Có cùng dạng phương trình', 0),
(13, N'Có cùng tập xác định', 0),                   
(13, N'Có cùng tập hợp nghiệm', 0),       
(13, N'Cả a, b, c đều đúng', 1)

go

--create table DeThi(
--	maDT int primary key identity not null,
--	maMH varchar(10),
--	maKhoi varchar(3),
--	maGV varchar(10),
--	TenDT nvarchar(100),
--	ThoiGianLamBai time,
--	NgayTao DateTime
--)

--create table CT_DeThi(
--	maDT int,
--	maCH int,
--	primary key (maDT, maCH)
--)

--insert into DeThi()


use QLTTN
select * from CauHoi
select * from DapAn
select * from CapDo
select * from NguoiDung
select * from HocSinh
select * from GiaoVien
select IDENT_CURRENT('dbo.CauHoi')

/*
-- xóa những câu hỏi mà chưa có đáp án
delete from CauHoi
where not exists (select * from DapAn
				where DapAn.maCH = CauHoi.maCH)

delete from DapAn where maCH > 50
delete from CauHoi where maCH > 50

delete from DapAn
delete from CauHoi
delete from CapDo

1,  
2,  
3,  
4,  
5,  
6,  
7,  
8,  
9,  
10, 
11, 
12, 
13, 
14, 
15, 
16, 
17, 
18, 
19, 
20, 
21, 
22, 
23, 
24, 
25, 
26, 
27, 
28, 
29, 
30, 
31, 
32, 
33, 
34, 
35, 
36, 
37, 
38, 
39, 
40, 
*/

/*
bỏ mã khối trong bảng môn học: xong
thêm khóa ngoại từ bảng giáo viên sang bảng môn học: xong
bõ mã câu hỏi trong DeThi, thêm bảng chi tiết đề thi, tronng bảng chi tiết đề thi sẽ có mã đề thi và mã câu hỏi, cả hai cùng là khóa chính
thêm khóa ngoại mã khối trong bảng câu hỏi tham chiếu đến bảng Khối
*/
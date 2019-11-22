use master
go
if db_ID('QLTTN') is not null
begin
	drop database QLTTN
end
create database QLTTN
go
use QLTTN

create table KyThi(
	maKT varchar(10) primary key,
	NgayThi datetime
)

create table Thi(
	maKT varchar(10), 
	maDT int, 
	maHS int,
	Diem decimal,
	primary key (maKT, maDT, maHS)
)

create table DeThi(
	maDT int identity not null primary key,
	maMH varchar(10),
	maCH int
)

-- cấp độ 0: dễ, 1: trung bình, 2:khó
create table CauHoi(
	maCH int identity not null primary key,
	NoiDung nvarchar(255),
	CapDo int
)

create table DapAn(
	maCH int,
	maDA int identity not null,
	NoiDung nvarchar(255),
	DungSai bit,
	primary key (maCH, maDA)
)

create table MonHoc(
	maMH varchar(10) primary key,
	tenMH nvarchar(255),
	maKhoi int
)

create table KhoiLop(
	maKhoi int identity not null primary key
)

create table LopHoc(
	maKhoi int,
	maLop int
	primary key (maKhoi, maLop)
)

create table HocSinh(
	maHS int identity not null primary key,
	HoTen nvarchar(255),
	NgaySinh datetime,
	maKhoi int,
	maLop int
)
go

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
	constraint fk_dt_ch
	foreign key (maCH)
	references CauHoi(maCH)
alter table DapAn
add 
	constraint fk_da_ch
	foreign key (maCH)
	references CauHoi(maCH)
alter table MonHoc
add
	constraint fk_mh_kl
	foreign key (maKhoi)
	references KhoiLop(maKhoi)
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

use QLTTN
select * from CauHoi
select * from DapAn

-- xóa những câu hỏi mà chưa có đáp án
delete from CauHoi
where not exists (select * from DapAn
				where DapAn.maCH = CauHoi.maCH)

delete from DapAn where maCH = 15
delete from CauHoi where maCH = 15


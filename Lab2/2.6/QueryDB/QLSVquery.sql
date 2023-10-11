Create database QuanLiSinhVien
go
use QuanLiSinhVien
go
create table Lop
(
	ID int identity(1,1),
	DisplayName nvarchar(max),
	Constraint PK_lop primary key (ID),
)
create table SinhVien
(
	ID int identity(1,1),
	DisplayName nvarchar(max),
	Gender bit,
	IDLop int,
	BirthDay smalldatetime,
	Constraint PK_SV primary key(ID),
	Constraint FK_SV_Lop foreign key (IDLop) references Lop(ID),
)
set dateformat dmy
insert into Lop(DisplayName) Values (N'KTPM2022'), (N'KTPM2023')
insert into Lop(DisplayName) Values (N'KTPM2019'), (N'KTPM2018')
insert into SinhVien(DisplayName,Gender,IDLop,BirthDay) Values (N'Duong Quang Dat', 1 , 2, '01/07/2004'),(N'Nguyen Van A', 0 , 1, '01/07/2014'),(N'Phan Thi B', 0 , 3, '11/07/2004')
select * from Lop
select * from SinhVien
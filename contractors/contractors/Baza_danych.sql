use master
go
drop database if exists ContractorsDb;
go
create database ContractorsDb;
GO
use ContractorsDb
go
CREATE TABLE [dbo].[tbLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tbContractors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imie] [nvarchar](50) NULL,
	[nazwisko] [nvarchar](50) NULL,
	[miejscowosc] [nvarchar](50) NULL,
	[adres] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[email] [nvarchar](150) NULL,
	[RodzajKontrahenta] [nvarchar](50) NULL,
	[NIP] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
insert into tbLogin
values('Marcin','admin','admin');
go
insert into tbContractors
values('Marcin','Sat³awa','Okrajnik','ul.Skalna 16','514 235 038 ','satlawamarcin@gmail.com','Osoba fizyczna','-');
go

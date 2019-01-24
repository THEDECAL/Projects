--Создание БД
create database [Publishing House]
go

use [Publishing House]
go

create table Sales (
	ID_SALE int identity primary key,
	ID_BOOK int not null,
	DateOfSale datetime default getdate(),
	Price money default 0.0,
	Quantity int default 0,
	ID_SHOP int not null
)
go

create table Shops (
	ID_SHOP int identity primary key,
	NameShop varchar(50) not null,
	ID_COUNTRY int
)
go

create table Country (
	ID_COUNTRY int identity primary key,
	NameCountry varchar(50) not null
)
go

create table Authors (
	ID_AUTHOR int identity primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	ID_COUNTRY int not null
)
go

create table Themes (
	ID_THEME int identity primary key,
	NameTheme varchar(50) not null
)
go

create table Books (
	ID_BOOK int identity primary key,
	NameBook varchar(100) not null,
	ID_THEME int not null,
	ID_AUTHOR int not null,
	Price money default 0.0,
	DrawingOfBook int not null,
	DateOfPublish date not null,
	Pages int not null,
	QuantityBooks int not null default 0
)
go

create table Accounts (
	ID_ACC int identity primary key,
	Login varchar(100) not null,
	Password varchar(100) not null,
	E-Mail varchar(100) not null
)
go

create table Users (
	ID_USER int identity primary key,
	ID_ACC int not null,
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	Birthday date not null
)
go

alter table Sales add
	constraint fk_Sales_Books_ID_BOOK foreign key (ID_BOOK) references Books (ID_BOOK) on delete cascade on update cascade,
	constraint fk_Sales_Shops_ID_SHOP foreign key (ID_SHOP) references Shops (ID_SHOP)
go

alter table Shops add
	constraint fk_Shops_Country_ID_COUNTRY foreign key (ID_COUNTRY) references Country (ID_COUNTRY)
go

alter table Authors add
	constraint fk_Authors_Country_ID_COUNTRY foreign key (ID_COUNTRY) references Country (ID_COUNTRY)
go

alter table Books add
	constraint fk_Books_Themes_ID_THEME foreign key (ID_THEME) references Themes (ID_THEME),
	constraint fk_Books_Authors_ID_AUTHOR foreign key (ID_AUTHOR) references Authors (ID_AUTHOR)
go

alter table Users add
	constraint fk_Users_Accounts_ID_ACC foreign key (ID_ACC) references Accounts (ID_ACC)
go


--Заполнение БД
insert into Country values
('США'),
('Украина'),
('Великобритания'),
('Россия'),
('Китай')
go

insert into Themes values
('Детектив'),
('Фэнтези'),
('Ужасы'),
('Фантастика'),
('Приключения')
go

insert into Shops values
('Bookrid', 1),
('Book Sale', 3),
('Букмаркет', 4),
('Amazon', 1),
('Bookcart', 1)
go

insert into Authors values
('Дэн', 'Браун', 1),
('Джоан', 'Роулинг', 1),
('Джон', 'Толкин', 3),
('Айзек', 'Азимов', 3),
('Роберт', 'Шекли', 1)
go

insert into Books values 
('Утраченный символ', 1, 1, 399.0, 1000, '2009-09-15', 576, 110),
('Конец вечности', 4, 4, 114.0, 1200, '1955-01-01', 928, 120),
('Гарри Поттер и Философский камень', 2, 2, 166.0, 2300, '1997-01-01', 432, 130),
('Властелин колец. Братство кольца', 2, 3, 135.0, 2700, '1954-01-01', 576, 140),
('Код Да Винчи', 1, 1, 134.0, 3500, '2003-04-01', 544, 150)
go

insert into Sales values
(5, '20170115 12:35:09', 1360.50, 11, 3),
(5, '20160913 10:02:11', 1370.70, 12, 3),
(3, '20181002 17:20:44', 1700.20, 12, 3),
(2, '20100101 16:10:11', 1190.73, 14, 3),
(4, '20151105 09:54:22', 1400.0, 15, 3),
(4, '20091119 11:33:17', 1410.10, 14, 3),
(1, '20170831 13:24:15', 4300.50, 16, 3),
(4, '20151105 09:54:22', 1400.0, 15, 1),
(4, '20091119 11:33:17', 1410.10, 14, 1),
(1, '20170831 13:24:15', 4300.50, 16, 1)
go

insert into Accounts values
('admin','qwerty123','admin@publishinghouse.com'),
('GramIV','123456','GramIV@publishinghouse.com'),
('DulinskiPT','123456','DulinskiPT@publishinghouse.com')
go

insert into Users values
(1,'Никита','Звегинцев','1990-08-23'),
(2,'Иван','Грэм','1985-11-12'),
(3,'Пётр','Дулински','1988-02-03')
go

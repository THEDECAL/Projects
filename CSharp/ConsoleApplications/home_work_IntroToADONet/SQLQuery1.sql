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

create table HistoryBooks (
	ID_EVENT int identity primary key,
	EventType varchar(100) not null,
	NameBook varchar(100),
	ID_THEME int,
	ID_AUTHOR int,
	Price money,
	DrawingOfBook int,
	DateOfPublish date,
	Pages int,
	QuantityBooks int,
	EventDate datetime default getdate()
)
go

create table Accounts (
	ID_ACC int identity primary key,
	Login varchar(100) not null,
	Password varchar(100) not null,
	EMail varchar(100) not null
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


--Проверка на существование аккаунта, если такой аккаунт есть вернёт больше 0, иначе 0
create proc sp_CheckAccount
@login varchar(100),
@password varchar(100),
@result int output
as
	set @result = (
		select count(*) from Accounts
		where Login = @login and Password = @password
	)
go

--declare @result int
--declare @login varchar(100) = 'admin'
--declare @password varchar(100) = 'qwerty123'
--exec sp_CheckAccount @login, @password, @result output
--print @result
--go

create view viewShowBooks
as
	select Books.ID_BOOK, Books.NameBook, Authors.FirstName + ' ' + Authors.LastName as Author, Books.DateOfPublish, Books.Pages, Books.Price, Books.QuantityBooks, Books.DrawingOfBook
	from Books,Authors
	where Books.ID_AUTHOR = Authors.ID_AUTHOR
go
--select * from viewShowHistoryBooks

create view viewShowHistoryBooks
as
	select HistoryBooks.EventType, HistoryBooks.NameBook, Authors.FirstName + ' ' + Authors.LastName as Author, HistoryBooks.DateOfPublish, HistoryBooks.Pages, HistoryBooks.Price, HistoryBooks.QuantityBooks, HistoryBooks.DrawingOfBook, HistoryBooks.EventDate
	from HistoryBooks, Authors
	where HistoryBooks.ID_AUTHOR = Authors.ID_AUTHOR
go
--select * from viewShowBooks

create proc sp_ShowBooks
as
	select * from viewShowBooks
go

create proc sp_ShowHistoryBooks
as
	select * from viewShowHistoryBooks
go

create proc sp_SearchBooks
@textSearch varchar(100)
as
	set @textSearch = '%' + @textSearch + '%'
	select * from viewShowBooks
	where
	Author like @textSearch or
	NameBook like @textSearch
go

--declare @textsearch varchar(100) = 'браун'
--exec sp_searchbooks @textsearch

--При добавлении возвращает id темы, если такая тема уже есть возвращает id существующей темы
--create proc sp_AddTheme
--@theme varchar(100),
--@id int output
--as
--	if((select count(*) from Themes where NameTheme = @theme) = 0)
--	begin
--		insert into Themes values (@theme)
--	end
--	select @id=ID_THEME from Themes
--	where NameTheme = @theme
--go

--declare @theme varchar(100) = 'Исторический'
--declare @id int
--exec sp_AddTheme @theme, @id output
--print @id
--go

create proc sp_AddBook
@fName varchar(100),
@lName varchar(100),
@country varchar(100),
@theme varchar(100),
@name varchar(100),
@price money,
@drawingOfBook int,
@dateOfPublish date,
@pages int,
@quantityBooks int
as
	declare @idAuthor int
	declare @idCounry int
	declare @idTheme int

	--Добавление темы
	if((select count(*) from Themes where NameTheme = @theme) = 0)
	begin
		insert into Themes values (@theme)
	end
	select top 1 @idTheme = ID_THEME from Themes
	where NameTheme = @theme

	--Добавление страны автора
	if((select count(*) from Country where NameCountry = @country) = 0)
	begin
		insert into Country values (@country)
	end
	select top 1 @idCounry = ID_COUNTRY from Country
	where NameCountry = @country

	--Добавление автора
	if((
		select count(*) from Authors
		where FirstName = @fName and
			  LastName = @lName and
			  ID_COUNTRY = @idCounry
		) = 0)
	begin
		insert into Authors values
		(
			@fName,
			@lName,
			@idCounry
		)
	end
	select top 1 @idAuthor = ID_AUTHOR from Authors
	where FirstName = @fName and
		  LastName = @lName and
		  ID_COUNTRY = @idCounry

	--Добавление книги
	if((
		select count(*) from Books
		where NameBook = @name and
			  ID_AUTHOR = @idAuthor and
			  ID_THEME = @idTheme
	  ) = 0)
	begin
		insert into Books values
		(
			@name,
			@idTheme,
			@idAuthor,
			@price,
			@drawingOfBook,
			@dateOfPublish,
			@pages,
			@quantityBooks
		)
	end
go

--declare @fName varchar(100) = 'Дэн'
--declare @lName varchar(100) = 'Браун'
--declare @country varchar(100) = 'США'
--declare @theme varchar(100) = 'Детектив'
--declare @name varchar(100) = 'Инферно'
--declare @price money = 136
--declare @drawingOfBook int = 300
--declare @dateOfPublish date = '2013/05/14'
--declare @pages int = 608
--declare @quantityBooks int = 170

--exec sp_AddBook 
--@fName,
--@lName,
--@country,
--@theme,
--@name,
--@price,
--@drawingOfBook,
--@dateOfPublish,
--@pages,
--@quantityBooks
--go

create proc sp_RemoveBook
@id varchar(100)
as
	delete from Books
	where ID_BOOK = @id
go

--declare @id int = 200
--exec sp_RemoveBook @id

create proc sp_EditBook
@id int,
@name varchar(100),
@price money,
@drawingOfBook int,
@dateOfPublish date,
@pages int,
@quantityBooks int
as
	if @name is null
	begin
		select @name = NameBook from Books
		where ID_BOOK = @id
	end

	if @price is null
	begin
		select @price = Price from Books
		where ID_BOOK = @id
	end

	if @drawingOfBook is null
	begin
		select @drawingOfBook = DrawingOfBook from Books
		where ID_BOOK = @id
	end

	if @dateOfPublish is null
	begin
		select @dateOfPublish = DateOfPublish from Books
		where ID_BOOK = @id
	end

	if @pages is null
	begin
		select @pages = Pages from Books
		where ID_BOOK = @id
	end

	if @quantityBooks is null
	begin
		select @quantityBooks = QuantityBooks from Books
		where ID_BOOK = @id
	end

	update Books set
	NameBook = @name,
	Price = @price,
	DrawingOfBook = @drawingOfBook,
	DateOfPublish = @dateOfPublish,
	Pages = @pages,
	QuantityBooks = @quantityBooks
	where ID_BOOK = @id
go

--declare @id int = 7
--declare @name varchar(100)
--declare @price money
--declare @drawingOfBook int
--declare @dateOfPublish date = '2001/01/03'
--declare @pages int
--declare @quantityBooks int

--exec sp_EditBook 
--@id,
--@name,
--@price,
--@drawingOfBook,
--@dateOfPublish,
--@pages,
--@quantityBooks
--go

create trigger DeletedBooks
on Books
for delete
as
	declare @NameBook varchar(100),
		@ID_THEME int,
		@ID_AUTHOR int,
		@Price money,
		@DrawingOfBook int,
		@DateOfPublish date,
		@Pages int,
		@QuantityBooks int

	select 
		@NameBook = NameBook,
		@ID_THEME = ID_THEME,
		@ID_AUTHOR = ID_AUTHOR,
		@Price = Price,
		@DrawingOfBook = DrawingOfBook,
		@DateOfPublish = DateOfPublish,
		@Pages = Pages,
		@QuantityBooks = QuantityBooks
	from deleted

	insert into HistoryBooks(
		EventType,
		NameBook,
		ID_THEME,
		ID_AUTHOR,
		Price,
		DrawingOfBook,
		DateOfPublish,
		Pages,
		QuantityBooks) values
	(
		'Удалена',
		@NameBook,
		@ID_THEME,
		@ID_AUTHOR,
		@Price,
		@DrawingOfBook,
		@DateOfPublish,
		@Pages,
		@QuantityBooks
	)
go

create trigger UpdatedBooks
on Books
for update
as
	declare @NameBook varchar(100),
		@ID_THEME int,
		@ID_AUTHOR int,
		@Price money,
		@DrawingOfBook int,
		@DateOfPublish date,
		@Pages int,
		@QuantityBooks int

	select 
		@NameBook = NameBook,
		@ID_THEME = ID_THEME,
		@ID_AUTHOR = ID_AUTHOR,
		@Price = Price,
		@DrawingOfBook = DrawingOfBook,
		@DateOfPublish = DateOfPublish,
		@Pages = Pages,
		@QuantityBooks = QuantityBooks
	from inserted

	insert into HistoryBooks(
		EventType,
		NameBook,
		ID_THEME,
		ID_AUTHOR,
		Price,
		DrawingOfBook,
		DateOfPublish,
		Pages,
		QuantityBooks) values
	(
		'Обновлена',
		@NameBook,
		@ID_THEME,
		@ID_AUTHOR,
		@Price,
		@DrawingOfBook,
		@DateOfPublish,
		@Pages,
		@QuantityBooks
	)
go

create trigger InsertedBooks
on Books
for insert
as
	declare @NameBook varchar(100),
		@ID_THEME int,
		@ID_AUTHOR int,
		@Price money,
		@DrawingOfBook int,
		@DateOfPublish date,
		@Pages int,
		@QuantityBooks int

	select 
		@NameBook = NameBook,
		@ID_THEME = ID_THEME,
		@ID_AUTHOR = ID_AUTHOR,
		@Price = Price,
		@DrawingOfBook = DrawingOfBook,
		@DateOfPublish = DateOfPublish,
		@Pages = Pages,
		@QuantityBooks = QuantityBooks
	from inserted

	insert into HistoryBooks(
		EventType,
		NameBook,
		ID_THEME,
		ID_AUTHOR,
		Price,
		DrawingOfBook,
		DateOfPublish,
		Pages,
		QuantityBooks) values
	(
		'Добавлена',
		@NameBook,
		@ID_THEME,
		@ID_AUTHOR,
		@Price,
		@DrawingOfBook,
		@DateOfPublish,
		@Pages,
		@QuantityBooks
	)
go

select * from Authors
select * from Country
select * from Books
select * from HistoryBooks
select * from Themes

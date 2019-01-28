use [Publishing House]
go

--1. �������, ������� ��� ������� ����� �������������
--�������� ���������� ���� � ������� Books.
--(���������� �������� � ������� Books ����������� ����
--���������� ��������� ���� QuantityBooks).

create trigger SaleOfBooks on Sales for insert
as
begin
	declare @id int,
			@currAmBooks int,
			@amOfBooksSale int,
			@drawingOfBooks int

	select @id = inserted.ID_BOOK, @amOfBooksSale = Quantity
	from inserted

	select @currAmBooks = Books.QuantityBooks, @drawingOfBooks = Books.DrawingOfBook
	from Books

	update Books set
	--�������� �� ��������� ����
	QuantityBooks = @currAmBooks - @amOfBooksSale,
	--��������� � ���-�� ������ �����
	DrawingOfBook = @drawingOfBooks + @amOfBooksSale
	where Books.ID_BOOK = @id

end
go

--select * from Sales
--select * from Books
--insert into Sales values (5, '2018-07-01 11:28:02', 1330.20, 12, 3)
--select * from Books
--select * from Sales
--go


--2. ������� �� ��������, ����� ���������� ������ ����
--�� ��������� ���������.

create trigger CheckAmBooks on Sales for insert
as
begin
	declare @id int, @currAmBooks int, @amOfBooksSale int

	select @id = inserted.ID_BOOK, @amOfBooksSale = Quantity
	from inserted

	select @currAmBooks = Books.QuantityBooks from Books

	if(@currAmBooks - @amOfBooksSale < 0)
	begin 
		print '� ��� ���������� ����.'
		rollback tran
	end
end
go

--insert into Sales values (5, '2018-07-01 11:28:02', 1330.20, 200, 3)
--select * from Sales
--go


--3. �������, ������� ��� �������� �����,
--�������� ������ � ��� � ��������� ������� "DeletedBooks".

--create table DeletedBooks (
--	ID_BOOK int identity primary key,
--	DateOfDelete datetime default getdate(),
--	NameBook varchar(100) not null,
--	ID_THEME int not null,
--	ID_AUTHOR int not null,
--	Price money default 0.0,
--	DrawingOfBook int not null,
--	DateOfPublish date not null,
--	Pages int not null,
--	QuantityBooks int not null default 0
--)
--go

create trigger MovingDeletedBooks
on Books
for delete
as
begin
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

	insert into DeletedBooks (
		NameBook,
		ID_THEME,
		ID_AUTHOR,
		Price,
		DrawingOfBook,
		DateOfPublish,
		Pages,
		QuantityBooks) values
	(
		@NameBook,
		@ID_THEME,
		@ID_AUTHOR,
		@Price,
		@DrawingOfBook,
		@DateOfPublish,
		@Pages,
		@QuantityBooks
	)

end
go

--select * from Books
--delete from Books where ID_BOOK = 1
--select * from DeletedBooks
--go


--4. �������, ������� ������, ����� ���� ������� �����
--�� ���� ������ �������� ���� ����� �� �������
--Books.

create trigger CheckPriceOfBookSale
on Sales
for insert
as
begin
	declare @id int, @amount int, @priceSale int, @price int

	select @id = inserted.ID_BOOK,
		   @amount = inserted.Quantity,
		   @priceSale = inserted.Price
	from inserted

	select @price = Books.Price
	from Books
	where Books.ID_BOOK = @id

	if(@priceSale / @amount < @price)
	begin
		print '���� ������� ������ ������������ ���� �� �������.'
		rollback tran
	end
end
go

--select * from Sales
--insert into Sales values (5, '2018-07-01 11:28:02', 133.20, 10, 3)
--select * from Sales
--go


--5. �������, ����������� ���������� ����� �����, ���
--������� �� ������� ���� ������� � �����������
--��������������� ��������� �� ������.
drop trigger CheckDateOfPublisher
create trigger CheckDateOfPublisher
on Books
for insert
as
begin
	declare @date date

	select @date = inserted.DateOfPublish from inserted

	if(@date is NULL)
	begin
		print '���� ���������� ������ ���� ���������.'
		rollback tran
	end
end
go


--alter table Books alter column DateOfPublish date null
--select * from Books
--insert into Books values
--('���������� ������', 1, 1, 399.0, 1000, NULL, 576, 100)
--select * from Books
--go


--6. ������� ��� ����� ���������, ������� ���������
--�������� �������� ����� ���� ������ �� �������
--(������, �������� �� ��������� � �.�.).


create trigger BlockChangeObjects
on all server
for DROP_TABLE, DROP_VIEW, DROP_DEFAULT
as
begin
	print '����� �������� ���������.'
	rollback
end
go

--create table test (id int)
--drop table test
--go

--7. �������� � ���� ������ �������, ������� ���������
--����� ��������� ������ � ������� Books.

create table AuditBooks (
	ID_BOOK int identity primary key,
	DateOfUpdate datetime default getdate(),
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

create trigger AuditUpdateDataToBooks
on Books
after update
as
begin
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

	insert into AuditBooks (
		NameBook,
		ID_THEME,
		ID_AUTHOR,
		Price,
		DrawingOfBook,
		DateOfPublish,
		Pages,
		QuantityBooks) values
	(
		@NameBook,
		@ID_THEME,
		@ID_AUTHOR,
		@Price,
		@DrawingOfBook,
		@DateOfPublish,
		@Pages,
		@QuantityBooks
	)
end
go

select * from Books
update Books set QuantityBooks = 84 where ID_BOOK = 5
select * from Books
select * from AuditBooks
go

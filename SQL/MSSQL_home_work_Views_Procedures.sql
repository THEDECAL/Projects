use [Publishing House]
go

--1. �������� �������������, � ������� ����������
--������� �������� ��������� � ��������� �� �����
--������������. ��� ���� �������� ������ �������
--������� �� ���������� ����� � � ����������� ����
--(��������, United States � US).
--

create view [Shop Locations]
as
select '�������� ��������'=Shops.NameShop, '������'=Country.NameCountry
from Shops, Country
where Shops.ID_COUNTRY = Country.ID_COUNTRY
go

--select * from [Shop Locations]
--go


--2. �������� ������, ������� �������� ������ �
--������� Books ��������� �������: ���� ����� ����
--������ ����� 2008 ����, ����� �� ����� ���������
--�� 1000 ����������, ����� ����� ��������� �� 100 ��.
--����������! ��������������� ����������� CASE.
--

--select * from Books
--go

update Books set Books.DrawingOfBook =
	case
		when datename(year, Books.DateOfPublish) > 2008
		then Books.DrawingOfBook + 1000
		else Books.DrawingOfBook + 100
	end
go

--select * from Books
--go


--3. �������� ����������� �������������, �������
--������� ����� ���������� ������ � ���� ���������
--���������� ��� ������� ��������.
--

with AmSalesAndLastDateSale("�������� ��������", "���-�� ������", "���� ��������� ������")
as
	(select Shops.NameShop, count(*), max(Sales.DateOfSale)
	from Shops, Sales
	where Shops.ID_SHOP = Sales.ID_SHOP
	group by Shops.NameShop)
	select * from AmSalesAndLastDateSale
go


--4. ������� �������� ���������, ������� ������� ��
--����� ������ ���������, ������� ������� ���� ��
--���� ����� ������ ������������.
--������� ����� ����������������� (������) ��������.
--

create proc sp_ListShopsBySalesMoreOne
as
	select Shops.NameShop, count(*) as '���-�� ������'
	from Shops, Sales
	where Shops.ID_SHOP = Sales.ID_SHOP
	group by Shops.NameShop
	having count(*) > 1
go

--exec sp_ListShopsBySalesMoreOne
--go


--5. �������� ���������, ����������� ����������� ���
--����� ������������� ������, ��� ���� ��� ���
--���������� ��� ������
--

create proc sp_ListBooksByAuthor
@name varchar(50)
as
	select Authors.FirstName + ' ' + Authors.LastName, Books.NameBook
	from Authors, Books
	where Authors.ID_AUTHOR = Books.ID_AUTHOR AND
	Authors.FirstName + ' ' + Authors.LastName = @name
go

--exec sp_ListBooksByAuthor '��� �����'
--go

--6. ������� �������� ���������, ������� ����������
--������������ �� ���� �����.
--

create proc sp_MaxNumber
@fNum int,
@sNum int,
@returnNum int output
as
	if (@fNum > @sNum) set @returnNum = @fNum
	else if (@fNum < @sNum) set @returnNum = @sNum
	else print '����� �����'
go

--declare @num int
--exec sp_MaxNumber 32, 71, @num output
--print @num
--go


--7. �������� ���������, ������� ������� �� �����
--����� � ���� �� ��������� ��������. ��� ���� ����������
--��������� ����������� ����������: 0 � �� ����,
--�� �����, 1 � �� ��������, ����� ������ � ��� ����������.
--

create proc sp_ListBooksAndPriceByTheme
@theme varchar(50),
@sort int
as
	select Books.NameBook, Books.Price
	from Books, Themes
	where Books.ID_THEME = Themes.ID_THEME AND
	Themes.NameTheme = @theme
	order by case @sort when 0 then Books.Price end asc,
			 case @sort when 1 then Books.Price end desc
go

--exec sp_ListBooksAndPriceByTheme '��������', 3
--go


--8. �������� ���������, ������� ���������� ������ ���
--������, ���� �������� ������ ���� ���� ������.
--

create proc sp_AuthorOfMostBooks
@author varchar(100) output
as
	select @author = subQuery.name from
	(select top 1 Authors.FirstName + ' ' + Authors.LastName as name, count(*) as cnt
	from Authors,Books
	where Authors.ID_AUTHOR = Books.ID_AUTHOR
	group by Authors.FirstName + ' ' + Authors.LastName
	order by cnt desc) as subQuery
go

--declare @name varchar(100)
--exec sp_AuthorOfMostBooks @name output
--print @name
--go


--9. �������� ��������� ��� ������� ���������� �����.
--

create proc sp_FactorialNumbers
@inputNum int,
@returnNum int output
as
	declare @startNum int = 1
	set @returnNum = @startNum
	while (@startNum <= @inputNum)
	begin
		set @returnNum *= @startNum
		set @startNum += 1
	end
go

--declare @factNum int
--exec sp_FactorialNumbers 5, @factNum output
--print @factNum
--go

--10.�������� �������� ���������, ������� ���������
--��������� ���� ������������ ������ �����, �������
--������������� ������� �� 2 ����. ������ ����������
--� �������� ��������� � ���������.
--

--drop proc sp_AddingTwoYearToDateOfPublishByPatten
create proc sp_AddingTwoYearToDateOfPublishByPatten
@pattern varchar(100)
as
	--���-�� ������������ �����
	declare @amEntry int = (select count(*) from Books where Books.NameBook like @pattern)
	declare @id int
	declare @date date
	while @amEntry > 0
	begin
		--������� � ���������� ID_BOOK � DateOfPublish
		select @date = Books.DateOfPublish, @id = Books.ID_BOOK
		from Books
		where Books.NameBook like @pattern
		--������� ���������� ������ 
		order by Books.NameBook desc
		offset @amEntry - 1 rows fetch first 1 row only

		--��������� DateOfPublish
		update Books
		set Books.DateOfPublish = dateadd(year, 2, @date)
		where Books.ID_BOOK = @id

		set @amEntry -= 1
	end
go

--declare @pattern varchar(100) = '%�����%'

--select * from Books where Books.NameBook like @pattern

--exec sp_AddingTwoYearToDateOfPublishByPatten @pattern

--select * from Books where Books.NameBook like @pattern
--go


--11.�������� �������� ��������� � �����������,
--������������� �������� ��� ������� ����. ���������
--��������� �������� ������ � ������ ������� ����
--�� ��������� ��������:
--� ���� ���� ������� ����� ��������� � ������������
--���������, ����� ����� ����� ��������� � ���
--����, � ���� �� ������� ��������� �� 20%;
--� ���� ���� ������� ����� �� ������ � ��������,
--����� ����� �������� ��� ���������.
--������������� ����� �� ����� ��������������� ���������
--�� ������, ���� ������������ ���� ����������,
--��� �������� ���� ���������� ������ ������, ��� ��
--��������� ������ ������� ����.
--

create proc sp_SlishkomDlinnoeNazvanie
@startDate date,
@endDate date
as
	if (@startDate > @endDate) print '��������� ���� ������ ��������.'
	else if(@startDate = @endDate) print '���� �����'
	else if(@startdate > getdate()) print '��������� ���� ������ �������.'
	else
	begin
		--���-�� ������������ �����
		declare @amEntry int = (
			select count(*)
			from Books
			where Books.DateOfPublish between @startDate and @endDate
		)
		declare @id int
		declare @draw int
		declare @price money
		while @amEntry > 0
		begin
			--������� � ���������� ID_BOOK � DateOfPublish
			select @id = Books.ID_BOOK, @draw = Books.DrawingOfBook, @price = Books.Price
			from Books
			where Books.DateOfPublish between @startDate and @endDate
			order by Books.DateOfPublish desc
			offset @amEntry - 1 rows fetch first 1 row only

			--��������� DateOfPublish
			update Books
			set Books.DrawingOfBook = @draw * 2,
				Books.Price = @price + (@price / 100 * 20)
			where Books.ID_BOOK = @id

			set @amEntry -= 1
		end
	end
go

--declare @startDate date = '1900-01-01'
--declare @endDate date = '2000-12-31'

--select Books.NameBook, Books.DrawingOfBook, Books.Price
--from Books
--where Books.DateOfPublish between @startDate and @endDate

--exec sp_SlishkomDlinnoeNazvanie @startDate, @endDate

--select Books.NameBook, Books.DrawingOfBook, Books.Price
--from Books
--where Books.DateOfPublish between @startDate and @endDate
--go
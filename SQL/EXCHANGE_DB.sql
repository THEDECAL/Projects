--------------
-- Создание БД
--------------
create database exchange_db
go

use exchange_db
go

create table accounts(
	acc_id int primary key identity,
	login nvarchar(45) not null,
	password nvarchar(45) not null,
	email nvarchar(100) not null
);
go

create table users(
	usr_id int primary key identity,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	acc_id int not null
);
go

alter table users add
constraint fk_users_accounts_acc_id
foreign key (acc_id) references accounts(acc_id);
go

create table products(
	prod_id int primary key identity,
	name nvarchar(45) not null,
	price money not null,
	quality int not null check(quality > 0 and quality < 11)
);
go

create table sales(
	sale_id int primary key identity,
	quantity int not null,
	usr_id int not null,
	prod_id int not null,
	date datetime not null default getdate(),
	removed int not null default 0
);
go

alter table sales add
constraint fk_sales_users_acc_id
foreign key (usr_id) references users(usr_id),
constraint fk_sales_products_prod_id
foreign key (prod_id) references products(prod_id)
go

create table purchases(
	pur_id int primary key identity,
	quantity int not null,
	usr_id int not null,
	prod_id int not null,
	date datetime not null default getdate(),
	removed int not null default 0
);
go

alter table purchases add
constraint fk_purchases_users_acc_id
foreign key (usr_id) references users(usr_id),
constraint fk_purchases_products_prod_id
foreign key (prod_id) references products(prod_id)
go

create table deals(
	deal_id int primary key identity,
	sale_id int not null,
	pur_id int not null,
	date datetime not null default getdate()
);
go

alter table deals add
constraint fk_deals_requests_src_req_id
foreign key (sale_id) references sales(sale_id),
constraint fk_deals_reuqests_dst_req_id
foreign key (pur_id) references purchases(pur_id)
go

--
-- Представление возможных сделок
--
create view viewPossibleDeals as
select
	sales.sale_id,
	purchases.pur_id,
	sales.quantity as 'sale_quantity',
	purchases.quantity as 'pur_quantity',
	price
from sales, purchases, products
where
	sales.prod_id = purchases.prod_id and
	products.prod_id = sales.prod_id and
	sales.quantity >= purchases.quantity and
	sales.removed != 1 and purchases.removed != 1
--------------------
-- Конец создания БД
--------------------
--------------------
-- Создание процедур
--------------------
--
-- Процедура регистрации пользователя
--
create proc sp_CreateUser
	@login nvarchar(45),
	@password nvarchar(45),
	@email nvarchar(100),
	@fname nvarchar(45),
	@lname nvarchar(45)
as
	begin try
		begin tran
			--Проверка наличия символовов
			if (@login != '' and @password != '' and @email != '' and
				@fname != '' and @lname != '')
			begin
				declare @id int = -1

				select @id = acc_id from accounts where login = @login
				if @id = -1
				begin
					insert into accounts
					values (@login, @password, @email)

					select @id = acc_id from accounts where login = @login

					insert into users
					values (@fname, @lname, @id)
				end
				else print 'Такой пользователь уже есть.'
			end
			else print 'Одно из полей пусто.'
		commit tran
	end try
	begin catch
		print 'Непредвиденная ошибка.'
		rollback tran
	end catch
go

declare
	@login nvarchar(45) = 'the-decal',
	@password nvarchar(45) = 'booblik',
	@email nvarchar(100) = 'thedecal1@gmail.com',
	@fname nvarchar(45) = 'Никита',
	@lname nvarchar(45) = 'Звегинцев';
exec sp_CreateUser @login, @password, @email, @fname, @lname

set @login = 'broker'
set @password = 'smachno'
set @email = 'bro@megashop.com'
set @fname = 'Дуглас'
set @lname = 'Бочински'

exec sp_CreateUser @login, @password, @email, @fname, @lname

select * from accounts, users
where accounts.acc_id = users.acc_id
go
--
-- Процедура добавления продукта
--
create proc sp_CreateProduct
	@name nvarchar(45),
	@price money,
	@quality int
as
	begin try
		begin tran;
			--Проверка наличия символов и корректности ввода
			if @name != '' and @price > 0 and @quality > 0 and @quality < 11
			begin
				declare @id int = -1

				select @id = prod_id from products
				where name = @name and price = @price and quality = @quality

				if @id = -1
				begin
					insert into products
					values (@name, @price, @quality)
				end
				else print 'Такой продукт уже есть.'
			end
			else print 'Не корректный формат ввода.'
		commit tran
	end try
	begin catch
		print 'Не предвиденная ошибка.'
		rollback tran
	end catch
go

declare
	@name nvarchar(45) = 'Картофель',
	@price money = '30',
	@quality int = 10;

exec sp_CreateProduct @name, @price, @quality

set	@name = 'Картофель'
set	@price = '28'
set	@quality = 9

exec sp_CreateProduct @name, @price, @quality

set	@name = 'Картофель'
set	@price = '26'
set	@quality = 8

exec sp_CreateProduct @name, @price, @quality

set	@name = 'Макароны'
set	@price = '30'
set	@quality = 8

exec sp_CreateProduct @name, @price, @quality

select * from products
go
--
-- Процедура создания заявки
--
create proc sp_CreateRequest
	@type varchar(7),
	@quantity int, 
	@usr_id int,
	@prod_id int
as
	begin try
		begin tran
			declare @id int = -1;

			select @id = usr_id from users where usr_id = @usr_id

			if @id != -1
			begin
				select @id = prod_id from products
				where prod_id = @prod_id;

				if @id != -1
				begin
					if @quantity > 0
					begin
						if @type = 'Продажа'
							insert into sales (quantity, usr_id, prod_id)
							values (@quantity, @usr_id, @prod_id)
						else if @type = 'Покупка'
							insert into purchases (quantity, usr_id, prod_id)
							values (@quantity, @usr_id, @prod_id)
						else print 'Неизвестный тип заявки.'
					end
					else print 'Кол-во должно быть больше 0.'
				end
				else print 'Такого продукта нет.'
			end
			else print 'Такого пользователя нет.'
		commit tran
	end try
	begin catch
		print 'Непредвиденная ошибка'
		rollback tran
	end catch
go

declare
	@type nchar(7) = 'Покупка',
	@quantity int = 500, 
	@usr_id int = 1,
	@prod_id int = 2;

exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

set	@type = 'Продажа'
set	@quantity = 5000 
set	@usr_id = 2
set	@prod_id = 2

exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

set	@type = 'Покупка'
set	@quantity = 100 
set	@usr_id = 1
set	@prod_id = 4

exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

select * from sales
select * from purchases
go
--
-- Процедура создания сделок
--
--drop proc sp_CommitDeals
create proc sp_CommitDeals
as
	begin try
		begin tran
			declare @cnt int = (select count(*) from viewPossibleDeals)

			while @cnt > 0
				begin
				declare
					@saleId int,
					@purId int,
					@quantityPur int,
					@tranName nvarchar(10)

				--Выборка строки с циклическим смещением
				select
					@saleId = sale_id,
					@purId = pur_id,
					@quantityPur = pur_quantity
				from viewPossibleDeals
				order by price desc
				offset @cnt - 1 rows fetch first 1 row only

				--Вставка сделки в таблицу
				insert into deals (sale_id, pur_id)
				values (@saleId, @purId)

				--Изменение кол-ва наличия продуктов у продавца
				update sales set quantity -= @quantityPur
				where sale_id = @saleId
				
				--Удаление заявки на покупку
				update purchases set removed = 1
				where pur_id = @purId
				
				--Каждую итерацию сохраняем состояние транзакции
				set @tranName = convert(nvarchar(10), @cnt)
				save tran @tranName
				set @cnt -= 1
			end
		commit tran
	end try
	begin catch
		print 'Непредвиденная ошибка'
		rollback tran
	end catch
go

exec sp_CommitDeals
select * from purchases
select * from sales
select * from deals
go
--
-- Конец создания процедур
--
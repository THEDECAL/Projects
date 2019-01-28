--
-- Создание БД
--
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

create table requests(
	req_id int primary key identity,
	type nchar(7) not null check(type in('Продажа', 'Покупка')),
	quantity int not null,
	usr_id int not null,
	prod_id int not null,
	date datetime not null default getdate()
);
go

alter table requests add
constraint fk_requests_users_acc_id
foreign key (usr_id) references users(usr_id),
constraint fk_requests_products_prod_id
foreign key (prod_id) references products(prod_id)
go

create table deals(
	deal_id int primary key identity,
	result nvarchar(10) not null check(result in('@Успешно', '@Не успешно')),
	src_req_id int not null,
	dst_req_id int,
	date datetime not null default getdate()
);
go

alter table deals add
constraint fk_deals_requests_src_req_id
foreign key (src_req_id) references requests(req_id),
constraint fk_deals_reuqests_dst_req_id
foreign key (dst_req_id) references requests(req_id)
go
--
-- Конец создания БД
--



--
-- Создание процедур
--



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
begin
	begin try
		begin tran;
		declare @id int = -1;

		select @id = acc_id from accounts where login = @login;
		if @id = -1
		begin
			insert into accounts
			values (@login, @password, @email);

			select @id = acc_id from accounts where login = @login;

			insert into users
			values (@fname, @lname, @id);
		end
		else print 'Такой пользователь уже есть'

		commit tran;
	end try
	begin catch
		print 'Не предвиденная ошибка'
		rollback tran;
	end catch
end
go

--declare
--	@login nvarchar(45) = 'the-decal',
--	@password nvarchar(45) = 'booblik',
--	@email nvarchar(100) = 'thedecal1@gmail.com',
--	@fname nvarchar(45) = 'Никита',
--	@lname nvarchar(45) = 'Звегинцев';
--exec sp_CreateUser @login, @password, @email, @fname, @lname

--set @login = 'broker'
--set @password = 'smachno'
--set @email = 'bro@megashop.com'
--set @fname = 'Дуглас'
--set @lname = 'Бочински'

--exec sp_CreateUser @login, @password, @email, @fname, @lname

--select * from accounts, users
--where accounts.acc_id = users.acc_id
--go



--
-- Процедура добавления продукта
--
create proc sp_CreateProduct
	@name nvarchar(45),
	@price money,
	@quality int
as
begin
	begin try
		begin tran;
		declare @id int = -1;

		select @id = prod_id from products
		where name = @name and price = @price and quality = @quality;

		if @id = -1
		begin
			insert into products
			values (@name, @price, @quality);
		end
		else print 'Такой продукт уже есть'

		commit tran;
	end try
	begin catch
		print 'Не предвиденная ошибка'
		rollback tran;
	end catch
end
go

--declare
--	@name nvarchar(45) = 'Картофель',
--	@price money = '30',
--	@quality int = 10;

--exec sp_CreateProduct @name, @price, @quality

--set	@name = 'Картофель'
--set	@price = '30'
--set	@quality = 9

--exec sp_CreateProduct @name, @price, @quality

--set	@name = 'Картофель'
--set	@price = '22'
--set	@quality = 8

--exec sp_CreateProduct @name, @price, @quality

--set	@name = 'Макароны'
--set	@price = '30'
--set	@quality = 8

--exec sp_CreateProduct @name, @price, @quality

--select * from products
--go



--
-- Процедура создания заявки
--
create proc sp_CreateRequest
	@type nchar(7), -- 'Продажа' или 'Покупка'
	@quantity int, 
	@usr_id int,
	@prod_id int
as
begin
	begin try
		begin tran;
		declare @id int = -1;

		select @id = usr_id from users
		where usr_id = @usr_id;

		if @id != -1
		begin
			select @id = prod_id from products
			where prod_id = @prod_id;

			if @id != -1
			begin
				if @type = 'Продажа' or @type = 'Покупка'
				begin
					if @quantity > 0
					begin
						insert into requests (type, quantity, usr_id, prod_id)
						values (@type, @quantity, @usr_id, @prod_id)
					end
					else print 'Кол-во должно быть больше ноля'
				end
				else print 'Такого типа заявки нет'
			end
			else print 'Такого продукта нет'
		end
		else print 'Такого пользователя нет'
		
		commit tran;
	end try
	begin catch
		print 'Не предвиденная ошибка'
		rollback tran;
	end catch
end
go

--declare
--	@type nchar(7) = 'Покупка',
--	@quantity int = 500, 
--	@usr_id int = 1,
--	@prod_id int = 2;

--exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

--set	@type = 'Продажа'
--set	@quantity = 5000 
--set	@usr_id = 2
--set	@prod_id = 2

--exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

--set	@type = 'Покупка'
--set	@quantity = 100 
--set	@usr_id = 1
--set	@prod_id = 4

--exec sp_CreateRequest @type, @quantity, @usr_id, @prod_id

--select * from requests
--go



--
-- Процедура создания сделок
--
create proc sp_CommitDeals
as
	with Sales as (select * from requests where type = 'Покупка')
	with Purchases as (select * from requests where type = 'Продажа')


	--declare @saleCnt int = (select count(*) from requests where type = 'Покупка')
	
	--if(@saleCnt > 0)
	--begin
	--	while @salceCnt > 0
	--	begin
			
			
	--		set @saleCnt -= 1
	--	end
	--end
go



--
-- Конец создания процедур
--

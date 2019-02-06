------
---Создание и выбор БД
-----

create database [Travel Agency]
go

use [Travel Agency]
go

------
---Завершение создания и выбора БД
-----

------
---Создание таблиц и представлений
-----

--Таблица должностей
create table posts(
	post_id int primary key identity,
	name nvarchar(45) not null
);
go

--Таблица типов курортов
create table resorts_types(
	[type_id] int primary key identity,
	name nvarchar(45) not null
);
go

--Таблица типов транспорта
create table transports(
	trans_id int primary key identity,
	name nvarchar(45) not null
);
go

--Таблица стран
create table countries(
	country_id int primary key identity,
	name nvarchar(45) not null
);
go

--Таблица городов
create table cities(
	city_id int primary key identity,
	name nvarchar(45),
	country_id int not null,
	constraint fk_cities_countries_country_id foreign key (country_id) references countries(country_id)
);
go

--Таблица сотрудников
create table employees(
	emp_id int primary key identity,
	post_id int not null,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	birth date not null,
	[date] date default getdate() not null,
	constraint fk_employees_posts_post_id foreign key (post_id) references posts(post_id)
);
go

--Таблица курортов
create table resorts(
	resort_id int primary key identity,
	name nvarchar(45) not null,
	price money not null,
	duration int not null,
	city_id int not null,
	[type_id] int not null,
	trans_id int not null,
	constraint fk_resorts_cities_city_id foreign key (city_id) references cities(city_id),
	constraint fk_resorts_resorts_types_type_id foreign key ([type_id]) references resorts_types([type_id]),
	constraint fk_resorts_transports_trnas_id foreign key (trans_id) references transports(trans_id)
);
go

--Таблица путешествий
create table travels(
	travel_id int primary key identity,
	[date] datetime not null,
	resort_id int not null,
	constraint fk_travels_resorts_resort_id foreign key (resort_id) references resorts(resort_id)
);
go

--Таблица путешествующих людей
create table peoples(
	people_id int primary key identity,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	birth date not null,
	travel_id int not null,
	constraint fk_peoples_travels_travel_id foreign key (travel_id) references travels(travel_id)
);
go

--Представление для путешествий на текущей неделе
create view ShowTravelThisWeek
as
	select resorts.name, travels.[date] from travels, resorts
	where 
	travels.resort_id = resorts.resort_id and
	year(getdate()) = year([date]) and datepart(week, getdate()) = datepart(week, [date])
go

------
---Завершение создания таблиц и представлений
-----

------
---Заполнение таблиц
-----

--Заполнение таблицы стран
set identity_insert countries on
insert into countries (country_id,name) values
(1,'США'),
(2,'Китай'),
(3,'Германия'),
(4,'Испания'),
(5,'Италия')
set identity_insert countries off
go

--Заполнение таблицы городов
set identity_insert cities on
insert into cities (city_id,name,country_id) values
(1, 'Нью-Йорк',1),
(2, 'Пекин',2),
(3, 'Вашингтон',1),
(4, 'Берлин',3),
(5, 'Рим',5)
set identity_insert cities off
go

--Заполнение таблицы должностей
set identity_insert posts on
insert into posts (post_id,name) values
(1,'Секретарь'),
(2,'Бухгалтер'),
(3,'Директор')
set identity_insert posts off
go

--Заполнение таблицы сотрудников
set identity_insert employees on
insert into employees (emp_id,post_id,fname,lname,birth,[date]) values
(1,3, 'Никита', 'Звегинцев', '1990-08-23', '2015-12-02'),
(2,2, 'Юрий', 'Долгов', '1990-07-08', '2016-02-01'),
(3,1, 'Марина', 'Кварк', '1983-02-04', '2016-02-28'),
(4,1, 'Евгения', 'Петросян', '1994-02-04', '2016-03-28'),
(5,1, 'Юлия', 'Сойдись', '1992-02-04', '2016-04-28')
set identity_insert employees off
go

--Заполнение таблицы типов курортов
set identity_insert resorts_types on
insert into resorts_types ([type_id],name) values
(1,'Лыжный'),
(2,'Спортивный'),
(3,'Морской'),
(4,'Горный'),
(5,'Экстримальный')
set identity_insert resorts_types off
go

--Заполнение таблицы типов транспорта
set identity_insert transports on
insert into transports (trans_id,name) values
(1,'Самолёт'),
(2,'Поезд'),
(3,'Автобус'),
(4,'Лошадь'),
(5,'Велосипед')
set identity_insert transports off
go

--Заполнение таблицы курортов
set identity_insert resorts on
insert into resorts (resort_id,name,price,duration,city_id,[type_id],trans_id) values
(1,'Эксремальный Нью-Йорк',5000.0,72,1,5,1),
(2,'Римский уикенд',10000.0,720,5,3,2),
(3,'Незатейлевый Берлин',7000.0,720,4,5,2),
(4,'Американская столица',12000.0,168,3,5,1),
(5,'Пекин во всей красе',1300.0,168,2,5,2)
set identity_insert resorts off
go

--Заполнение таблицы путишествий
set identity_insert travels on
insert into travels (travel_id,[date],resort_id) values
(1,'2018-02-13T12:20:00', 1),
(2,'2018-03-16T13:30:00', 1),
(3,'2019-02-15T16:10:00', 1),
(4,'2017-04-19T01:20:00', 2),
(5,'2018-10-12T13:40:00', 3)
set identity_insert travels off
go

--Заполнение таблицы людей
set identity_insert peoples on
insert into peoples (people_id,fname,lname,birth,travel_id) values
(1,'Трэвис','Баркер','1991-02-13', 1),
(2,'Иван','Додыр','1992-03-16', 2),
(3,'Григорий','Сковорода','1989-02-15', 1),
(4,'Рома','Дятел','1988-04-19', 2),
(5,'Сергей','Долгонос','1980-10-12', 1)
set identity_insert peoples off
go

------
---Завершение заполнения таблиц
-----

------
---Создание процедур
-----

--Процедура по вычитке самого популярного курорта
create proc sp_ShowPopularResorts
as
	select top 1 name from (select name,travels.resort_id,count(*) as amount_travels from travels, resorts
	where travels.resort_id = resorts.resort_id
	group by name,travels.resort_id) as q
go

--Процедура по отображению самого путешествующего пользователя
create proc sp_ShowMostTravelingUser
as
	select top 1 name from (select fname + ' ' + lname as name,travels.travel_id,count(*) as amount_travels from travels, peoples
	where travels.travel_id = peoples.travel_id
	group by fname + ' ' + lname,travels.travel_id) as q
go

--Процедура определяющая сумму полученных денег за текущий месяц
create proc sp_ShowProfitForTheMonth
as
	select sum(price) as [Sum] from resorts,travels
	where resorts.resort_id = travels.resort_id and
	datepart(year,[date]) = year(getdate()) and datepart(month,[date]) = month(getdate())
go

------
---Завершение создания процедур
-----

------
---Создание учётных записей и пользователей
-----

--Учётные записи
create login ZvegintsevN with password = '2q43gtw345h'
create login DolgovY with password = '34gtw34hb35'
create login KvarkM with password = '2q3rweegvgg'
create login PetrosjanE with password = '234rkuo;rtg'
create login SoidisY with password = '234-gegnnjg'
go

--Пользователи
create user ZvegintsevN for login ZvegintsevN
create user DolgovY for login DolgovY
create user KvarkM for login KvarkM
create user PetrosjanE for login PetrosjanE
create user SoidisY for login SoidisY
go

------
---Завершение создания учётных записей и пользователей
-----

------
---Создание ролей и их назначение
-----

--Роль для директоров
create role directors
alter role directors add member ZvegintsevN
go

--Роль для бухгалтеров
create role accountants
alter role accountants add member DolgovY
go

--Роль для секретарей
create role secretaries
alter role secretaries add member KvarkM
alter role secretaries add member PetrosjanE
alter role secretaries add member SoidisY
go

------
---Завершение создания ролей и их назначение
-----

------
---Создание прав доступа
-----

--Права для директоров
grant select on posts to directors
grant select,insert,delete on employees to directors
grant execute on sp_ShowProfitForTheMonth to directors
grant select on ShowTravelThisWeek to directors
grant select on cities to directors
grant select on countries to directors
grant select on resorts_types to directors
grant select on transports to directors
go

--Права для бухгалтеров
grant select,update,insert on resorts to accountants
grant select,update,insert on travels to accountants
grant select,update,insert on peoples to accountants
grant select on cities to accountants
grant select on countries to accountants
grant select on resorts_types to accountants
grant select on transports to accountants
go

--Права для сектретарей
grant select on resorts to secretaries
grant select on travels to secretaries
grant select on peoples to secretaries
grant select on cities to secretaries
grant select on countries to secretaries
grant select on resorts_types to secretaries
grant select on transports to secretaries
go

------
---Завершение создания прав доступа
-----
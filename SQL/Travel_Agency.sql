------
---Создание БД
-----
create database [Travel Agency]
go

use [Travel Agency]
go

--Таблица должностей
create table posts(
	post_id int primary key identity,
	name nvarchar(45) not null
);

--Таблица типов курортов
create table resorts_types(
	[type_id] int primary key identity,
	name nvarchar(45) not null
);

--Таблица типов транспорта
create table transports(
	trans_id int primary key identity,
	name nvarchar(45) not null
);

--Таблица стран
create table countries(
	country_id int primary key identity,
	name nvarchar(45) not null
);

--Таблица городов
create table cities(
	city_id int primary key identity,
	name nvarchar(45),
	country_id int not null,
	constraint fk_cities_countries_country_id foreign key (country_id) references countries(country_id)
);

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

--Таблица путешествий
create table travels(
	travel_id int primary key identity,
	[date] datetime not null,
	resort_id int not null,
	constraint fk_travels_resorts_resort_id foreign key (resort_id) references resorts(resort_id)
);

--Таблица путешествующих людей
create table peoples(
	people_id int primary key identity,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	birth date not null,
	travel_id int not null,
	constraint fk_peoples_travels_travel_id foreign key (travel_id) references travels(travel_id)
);

------
---Завершение создания БД
-----

------
---Заполнение БД
-----

--Заполнение таблицы стран
insert into countries values
('США'),
('Китай'),
('Германия'),
('Испания'),
('Италия')

--Заполнение таблицы городов
insert into cities values
('Нью-Йорк',1),
('Пекин',2),
('Вашингтон',1),
('Берлин',3),
('Рим',5)


--Заполнение таблицы должностей
insert into posts values
('Секретарь'),
('Бухгалтер'),
('Директор')

--Заполнение таблицы сотрудников
insert into employees values
(3, 'Никита', 'Звегинцев', '1990-08-23', '2015-12-02'),
(2, 'Юрий', 'Долгов', '1990-07-08', '2016-02-01'),
(1, 'Марина', 'Кварк', '1983-02-04', '2016-02-28'),
(1, 'Евгения', 'Петросян', '1994-02-04', '2016-03-28'),
(1, 'Юлия', 'Сойдись', '1992-02-04', '2016-04-28')

--Заполнение таблицы типов курортов
insert into resorts_types values
('Лыжный'),
('Спортивный'),
('Морской'),
('Горный'),
('Экстримальный')

--Заполнение таблицы типов транспорта
insert into transports values
('Самолёт'),
('Поезд'),
('Автобус'),
('Лошадь'),
('Велосипед')

--Заполнение таблицы курортов
insert into resorts values
('Эксремальный Нью-Йорк',5000.0,72,1,5,1),
('Римский уикенд',10000.0,720,5,3,2),
('Незатейлевый Берлин',7000.0,720,4,5,2),
('Американская столица',12000.0,168,3,5,1),
('Пекин во всей красе',1300.0,168,2,5,2)

------
---Завершение заполнения БД
-----
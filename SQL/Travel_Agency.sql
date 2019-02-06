------
---�������� � ����� ��
-----

create database [Travel Agency]
go

use [Travel Agency]
go

------
---���������� �������� � ������ ��
-----

------
---�������� ������ � �������������
-----

--������� ����������
create table posts(
	post_id int primary key identity,
	name nvarchar(45) not null
);
go

--������� ����� ��������
create table resorts_types(
	[type_id] int primary key identity,
	name nvarchar(45) not null
);
go

--������� ����� ����������
create table transports(
	trans_id int primary key identity,
	name nvarchar(45) not null
);
go

--������� �����
create table countries(
	country_id int primary key identity,
	name nvarchar(45) not null
);
go

--������� �������
create table cities(
	city_id int primary key identity,
	name nvarchar(45),
	country_id int not null,
	constraint fk_cities_countries_country_id foreign key (country_id) references countries(country_id)
);
go

--������� �����������
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

--������� ��������
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

--������� �����������
create table travels(
	travel_id int primary key identity,
	[date] datetime not null,
	resort_id int not null,
	constraint fk_travels_resorts_resort_id foreign key (resort_id) references resorts(resort_id)
);
go

--������� �������������� �����
create table peoples(
	people_id int primary key identity,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	birth date not null,
	travel_id int not null,
	constraint fk_peoples_travels_travel_id foreign key (travel_id) references travels(travel_id)
);
go

--������������� ��� ����������� �� ������� ������
create view ShowTravelThisWeek
as
	select resorts.name, travels.[date] from travels, resorts
	where 
	travels.resort_id = resorts.resort_id and
	year(getdate()) = year([date]) and datepart(week, getdate()) = datepart(week, [date])
go

------
---���������� �������� ������ � �������������
-----

------
---���������� ������
-----

--���������� ������� �����
set identity_insert countries on
insert into countries (country_id,name) values
(1,'���'),
(2,'�����'),
(3,'��������'),
(4,'�������'),
(5,'������')
set identity_insert countries off
go

--���������� ������� �������
set identity_insert cities on
insert into cities (city_id,name,country_id) values
(1, '���-����',1),
(2, '�����',2),
(3, '���������',1),
(4, '������',3),
(5, '���',5)
set identity_insert cities off
go

--���������� ������� ����������
set identity_insert posts on
insert into posts (post_id,name) values
(1,'���������'),
(2,'���������'),
(3,'��������')
set identity_insert posts off
go

--���������� ������� �����������
set identity_insert employees on
insert into employees (emp_id,post_id,fname,lname,birth,[date]) values
(1,3, '������', '���������', '1990-08-23', '2015-12-02'),
(2,2, '����', '������', '1990-07-08', '2016-02-01'),
(3,1, '������', '�����', '1983-02-04', '2016-02-28'),
(4,1, '�������', '��������', '1994-02-04', '2016-03-28'),
(5,1, '����', '�������', '1992-02-04', '2016-04-28')
set identity_insert employees off
go

--���������� ������� ����� ��������
set identity_insert resorts_types on
insert into resorts_types ([type_id],name) values
(1,'������'),
(2,'����������'),
(3,'�������'),
(4,'������'),
(5,'�������������')
set identity_insert resorts_types off
go

--���������� ������� ����� ����������
set identity_insert transports on
insert into transports (trans_id,name) values
(1,'������'),
(2,'�����'),
(3,'�������'),
(4,'������'),
(5,'���������')
set identity_insert transports off
go

--���������� ������� ��������
set identity_insert resorts on
insert into resorts (resort_id,name,price,duration,city_id,[type_id],trans_id) values
(1,'������������ ���-����',5000.0,72,1,5,1),
(2,'������� ������',10000.0,720,5,3,2),
(3,'������������ ������',7000.0,720,4,5,2),
(4,'������������ �������',12000.0,168,3,5,1),
(5,'����� �� ���� �����',1300.0,168,2,5,2)
set identity_insert resorts off
go

--���������� ������� �����������
set identity_insert travels on
insert into travels (travel_id,[date],resort_id) values
(1,'2018-02-13T12:20:00', 1),
(2,'2018-03-16T13:30:00', 1),
(3,'2019-02-15T16:10:00', 1),
(4,'2017-04-19T01:20:00', 2),
(5,'2018-10-12T13:40:00', 3)
set identity_insert travels off
go

--���������� ������� �����
set identity_insert peoples on
insert into peoples (people_id,fname,lname,birth,travel_id) values
(1,'������','������','1991-02-13', 1),
(2,'����','�����','1992-03-16', 2),
(3,'��������','���������','1989-02-15', 1),
(4,'����','�����','1988-04-19', 2),
(5,'������','��������','1980-10-12', 1)
set identity_insert peoples off
go

------
---���������� ���������� ������
-----

------
---�������� ��������
-----

--��������� �� ������� ������ ����������� �������
create proc sp_ShowPopularResorts
as
	select top 1 name from (select name,travels.resort_id,count(*) as amount_travels from travels, resorts
	where travels.resort_id = resorts.resort_id
	group by name,travels.resort_id) as q
go

--��������� �� ����������� ������ ��������������� ������������
create proc sp_ShowMostTravelingUser
as
	select top 1 name from (select fname + ' ' + lname as name,travels.travel_id,count(*) as amount_travels from travels, peoples
	where travels.travel_id = peoples.travel_id
	group by fname + ' ' + lname,travels.travel_id) as q
go

--��������� ������������ ����� ���������� ����� �� ������� �����
create proc sp_ShowProfitForTheMonth
as
	select sum(price) as [Sum] from resorts,travels
	where resorts.resort_id = travels.resort_id and
	datepart(year,[date]) = year(getdate()) and datepart(month,[date]) = month(getdate())
go

------
---���������� �������� ��������
-----

------
---�������� ������� ������� � �������������
-----

--������� ������
create login ZvegintsevN with password = '2q43gtw345h'
create login DolgovY with password = '34gtw34hb35'
create login KvarkM with password = '2q3rweegvgg'
create login PetrosjanE with password = '234rkuo;rtg'
create login SoidisY with password = '234-gegnnjg'
go

--������������
create user ZvegintsevN for login ZvegintsevN
create user DolgovY for login DolgovY
create user KvarkM for login KvarkM
create user PetrosjanE for login PetrosjanE
create user SoidisY for login SoidisY
go

------
---���������� �������� ������� ������� � �������������
-----

------
---�������� ����� � �� ����������
-----

--���� ��� ����������
create role directors
alter role directors add member ZvegintsevN
go

--���� ��� �����������
create role accountants
alter role accountants add member DolgovY
go

--���� ��� ����������
create role secretaries
alter role secretaries add member KvarkM
alter role secretaries add member PetrosjanE
alter role secretaries add member SoidisY
go

------
---���������� �������� ����� � �� ����������
-----

------
---�������� ���� �������
-----

--����� ��� ����������
grant select on posts to directors
grant select,insert,delete on employees to directors
grant execute on sp_ShowProfitForTheMonth to directors
grant select on ShowTravelThisWeek to directors
grant select on cities to directors
grant select on countries to directors
grant select on resorts_types to directors
grant select on transports to directors
go

--����� ��� �����������
grant select,update,insert on resorts to accountants
grant select,update,insert on travels to accountants
grant select,update,insert on peoples to accountants
grant select on cities to accountants
grant select on countries to accountants
grant select on resorts_types to accountants
grant select on transports to accountants
go

--����� ��� �����������
grant select on resorts to secretaries
grant select on travels to secretaries
grant select on peoples to secretaries
grant select on cities to secretaries
grant select on countries to secretaries
grant select on resorts_types to secretaries
grant select on transports to secretaries
go

------
---���������� �������� ���� �������
-----
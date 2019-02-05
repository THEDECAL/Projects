------
---�������� ��
-----
create database [Travel Agency]
go

use [Travel Agency]
go

--������� ����������
create table posts(
	post_id int primary key identity,
	name nvarchar(45) not null
);

--������� ����� ��������
create table resorts_types(
	[type_id] int primary key identity,
	name nvarchar(45) not null
);

--������� ����� ����������
create table transports(
	trans_id int primary key identity,
	name nvarchar(45) not null
);

--������� �����
create table countries(
	country_id int primary key identity,
	name nvarchar(45) not null
);

--������� �������
create table cities(
	city_id int primary key identity,
	name nvarchar(45),
	country_id int not null,
	constraint fk_cities_countries_country_id foreign key (country_id) references countries(country_id)
);

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

--������� �����������
create table travels(
	travel_id int primary key identity,
	[date] datetime not null,
	resort_id int not null,
	constraint fk_travels_resorts_resort_id foreign key (resort_id) references resorts(resort_id)
);

--������� �������������� �����
create table peoples(
	people_id int primary key identity,
	fname nvarchar(45) not null,
	lname nvarchar(45) not null,
	birth date not null,
	travel_id int not null,
	constraint fk_peoples_travels_travel_id foreign key (travel_id) references travels(travel_id)
);

------
---���������� �������� ��
-----

------
---���������� ��
-----

--���������� ������� �����
insert into countries values
('���'),
('�����'),
('��������'),
('�������'),
('������')

--���������� ������� �������
insert into cities values
('���-����',1),
('�����',2),
('���������',1),
('������',3),
('���',5)


--���������� ������� ����������
insert into posts values
('���������'),
('���������'),
('��������')

--���������� ������� �����������
insert into employees values
(3, '������', '���������', '1990-08-23', '2015-12-02'),
(2, '����', '������', '1990-07-08', '2016-02-01'),
(1, '������', '�����', '1983-02-04', '2016-02-28'),
(1, '�������', '��������', '1994-02-04', '2016-03-28'),
(1, '����', '�������', '1992-02-04', '2016-04-28')

--���������� ������� ����� ��������
insert into resorts_types values
('������'),
('����������'),
('�������'),
('������'),
('�������������')

--���������� ������� ����� ����������
insert into transports values
('������'),
('�����'),
('�������'),
('������'),
('���������')

--���������� ������� ��������
insert into resorts values
('������������ ���-����',5000.0,72,1,5,1),
('������� ������',10000.0,720,5,3,2),
('������������ ������',7000.0,720,4,5,2),
('������������ �������',12000.0,168,3,5,1),
('����� �� ���� �����',1300.0,168,2,5,2)

------
---���������� ���������� ��
-----
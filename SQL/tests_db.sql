create database tests_db
go

use tests_db
go

create table accounts (
	account_id int primary key identity,
	login varchar(25) not null,
	password varchar(32) not null,
	email varchar(45) not null,
	status int not null default 0,
)
go


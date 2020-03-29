create database chat_db
go

use chat_db
go

create table [messages](
	id int primary key identity,
	[text] nvarchar(MAX) check(len([text]) > 0),
	[username] nvarchar(50) check(len([username]) > 0 and len([username]) <= 50),
	[date] datetime default getdate());
go

CREATE DATABASE smartfones_DB;
USE smartfones_DB;
GO

CREATE TABLE smartfones(
	smartfoneID int primary key identity,
	name nvarchar(100),
	[image] image,
	price money default 0.0,
	comm_std nvarchar(100) default '-',

);
go

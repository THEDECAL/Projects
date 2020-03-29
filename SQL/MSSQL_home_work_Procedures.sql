use films
--1. ������� ���������, ������� ��������� ��� ��������� - ��������� ������ 
--   � �������� ������ � ������� ����� print ��� ������ � �������� ���������
--   �� ������ Directors (FirstName, LastName), �� ������� Movies(Title, Rating)
--   � �� ������� Actors (FirstName, LastName) ����� ������

create proc sp_ShowRangeEntry
	@startEntry int,  -- �������� ����������� � 0
	@endEntry int
as
begin
	declare @cur cursor

	--Directors
	set @cur = cursor scroll for
	select FirstName, LastName from Directors
	order by DirectorID
		offset @startEntry rows
		fetch next @endEntry - @startEntry + 1 rows only

	open @cur
	fetch next from @cur
	while @@fetch_status = 0
	begin
		fetch next from @cur
	end

	--Movies
	set @cur = cursor scroll for
	select Title, Rating from Movies order by MovieID
	offset @startEntry rows fetch next @endEntry - @startEntry + 1 rows only

	open @cur
	fetch next from @cur
	while @@fetch_status = 0
	begin
		fetch next from @cur
	end

	--Actors
	set @cur = cursor scroll for
	select FirstName, LastName from Actors order by ActorID
	offset @startEntry rows fetch next @endEntry - @startEntry + 1 rows only

	open @cur
	fetch next from @cur
	while @@fetch_status = 0
	begin
		fetch next from @cur
	end

	CLOSE @cur
	DEALLOCATE @cur
end
go

exec sp_ShowRangeEntry 2, 4
go

--2. ������� ���������, ������� ��������� ��� ��������� - ������� ��� ����� �
--   ����� ��� ����� � ��������� ������ � ������� Genres ����� ������

drop proc sp_ReplaceGenreName
go

create proc sp_ReplaceGenreName
	@currentGenre varchar(45),
	@newGenre varchar(45)
as
begin
	declare @cur cursor

	set @cur = cursor scroll for
	select GenreName from Genres where GenreName = @currentGenre

	open @cur
	fetch first from @cur
	if @@FETCH_STATUS = 0
	begin
		update Genres set [GenreName] = @newGenre where current of @cur
	end

	close @cur
	deallocate @cur
end
go

exec sp_ReplaceGenreName '�����', 'Drama'
select * from Genres
go

--exec sp_ReplaceGenreName 'Drama', '�����'
--select * from Genres
--go

--3. ������� ���������, ������� ������� ���� ���������� �� ������� Directors, ��
--   ������� ��� �� ����� ������ �� ������� Movies. ����� ����� ������

exec sp_InsertDirector '������', '���������', '�������', '23-08-1990'
exec sp_InsertDirector '������', '���������', '�������', '23-08-1990'
select * from Directors
go

--drop proc sp_DeleteUnreportedDirectors
--go

create proc sp_DeleteUnreportedDirectors
as
begin
	declare @cur cursor,
			@DirectorID int,
			@cnt int = 0

	set @cur = cursor scroll for
	select DirectorID from Directors

	open @cur
	fetch next from @cur into @DirectorID
	while @@FETCH_STATUS = 0
	begin
		select @cnt = count(*) from Movies where DirectorID = @DirectorID
		if @cnt = 0
		begin
			delete from Directors where current of @cur
		end
		fetch next from @cur into @DirectorID
	end
end
go

exec sp_DeleteUnreportedDirectors
select * from Directors
go
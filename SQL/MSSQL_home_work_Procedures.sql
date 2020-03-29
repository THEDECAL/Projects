use films
--1. Создать процедуру, которая принимает два аргумента - начальную запись 
--   и конечную запись и выводит через print все записи в заданном диапазоне
--   из таблиц Directors (FirstName, LastName), из таблицы Movies(Title, Rating)
--   и из таблицы Actors (FirstName, LastName) через курсор

create proc sp_ShowRangeEntry
	@startEntry int,  -- Диапазон выполняется с 0
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

--2. Создать процедуру, которая принимает два аргумента - текущее имя жанра и
--   новое имя жанра и обновляет запись в таблице Genres через курсор

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

exec sp_ReplaceGenreName 'Драма', 'Drama'
select * from Genres
go

--exec sp_ReplaceGenreName 'Drama', 'Драма'
--select * from Genres
--go

--3. Создать процедуру, которая удаляет всех продюсеров из таблицы Directors, на
--   которых нет ни одной ссылки из таблицы Movies. Также через курсор

exec sp_InsertDirector 'Никита', 'Звегинцев', 'Русский', '23-08-1990'
exec sp_InsertDirector 'Никита', 'Звегинцев', 'Русский', '23-08-1990'
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
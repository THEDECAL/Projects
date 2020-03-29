1. Добавить в файл "appsettings.json" в раздел ConnectionStrings, в переремнную DefaultConnection свою строку подключения
2. Запустить создание миграции БД (Add-Migration -Context ApplicationDbContext first-migration)
3. Создать таблицы БД (Update-Database -Context ApplicationDbContext)
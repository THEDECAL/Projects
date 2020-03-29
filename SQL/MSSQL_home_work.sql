USE Northwind

--
--Использую БД Northwind
--
--1. Показать все книги трех произвольных авторов.
--   (Показываю все продукты трёх категорий)
SELECT Categories.CategoryName, Products.ProductName
FROM Categories, Products
WHERE Categories.CategoryID=Products.CategoryID AND CategoryName IN ('Beverages','Condiments','Produce')

--2. Показать все книги, в которых количество страниц больше 500, но меньше 650
--   (Показываю цены продуктов больше 50 но меньше 65)
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 50 AND 65

--3. Необходимо вывести все названия книг, в которых первая буква или А, или С.
--   (Показываю все продукты, в которых первая буква или А, или С)
SELECT ProductName
FROM Products
WHERE ProductName LIKE 'A%' OR ProductName LIKE 'C%'

--4. Показать названия книг, тематика которых не "Science Fiction" и тираж которых >=20 экземпляров.
--   (Показываю продукты категории не "Produce" которых на складе >= 20 штук)
SELECT Products.ProductName, Categories.CategoryName, UnitsInStock
FROM Products, Categories
WHERE Products.CategoryID=Categories.CategoryID AND CategoryName!='Produce' AND Products.UnitsInStock>=20

--5. Показать все книги-новинки, цена которых ниже $30. (Новинкой будет считаться книга, которая была издана на протяжении последней недели).
--   (Показываю все заказы-новинки, цена которого, за еденицу товара ниже 30$. (Новинкой будет считаться заказ, который был добавлен на протяжении последней недели 1996 года))
SELECT CompanyName, ProductName, Products.UnitPrice as 'Цена за еденицу товара', Orders.OrderDate
FROM Orders, [Order Details], Products, Customers
WHERE
Orders.OrderID=[Order Details].OrderID AND
Customers.CustomerID=Orders.CustomerID AND
Products.ProductID=[Order Details].ProductID AND
Products.UnitPrice<30 AND
OrderDate BETWEEN '24/12/1996' AND '31/12/1996'

--6 Показать книги, в названиях которых есть слово "Microsof", но нет слова "Windows".
--  (Показываю имена клиентов, в названиях которых есть слово "Maria", но нет слова "Anders".)
SELECT * FROM Customers WHERE ContactName LIKE '%Maria%' AND ContactName NOT LIKE '%Anders%'

--7. Вывести названия книг, тематику, автора (полноеимя), цена одной страницы которых менее 10 центов.
--   (Показываю название продуктов их категорию и цену, стоимость которых за 1кг 10 центов, (если взять столбец freight, как за вес))
SELECT Products.ProductName, Categories.CategoryName, Products.UnitPrice, Orders.Freight
FROM Products, Categories, Orders, [Order Details]
WHERE
Products.CategoryID=Categories.CategoryID AND
Orders.OrderID=[Order Details].OrderID AND
Products.ProductID=[Order Details].ProductID AND
Orders.Freight / Products.UnitPrice > 0.10

--8. Вывести информацию обо всех книгах, в имени которых больше 4-х слов.
--   (Показываю информацию обо всех клиентах, в названии компании которых больше 4-х слов.)
SELECT * FROM Customers
WHERE CompanyName LIKE '% % % % %'

--9. Вывести на экран все книги, их авторов и цены их продажи в у.е., дата продажи которых находится в диапазоне 01/01/2007 по сегодняшнюю дату.
--   (Показываю все продукты их категории и цены дата продажи которых находится в диапазоне 01/01/1997 по сегодняшнюю дату.)
SELECT Products.ProductName, Categories.CategoryName, Products.UnitPrice, Orders.OrderDate
FROM Categories, Products, Orders,[Order Details]
WHERE Categories.CategoryID=Products.CategoryID AND
Orders.OrderID=[Order Details].OrderID AND
Products.ProductID=[Order Details].ProductID AND
Orders.OrderDate BETWEEN '01/01/1997' AND '15/11/2018'

--10. Показать всю информацию по продажам книг в следующем виде:
-- ■ название книги; (название продукта)
-- ■ тематик, которые касаются "Computer Science"; (категории "Produce")
-- ■ автор книги (полное имя); (Кол-во на складе)
-- ■ цена продажи книги; (продукта)
-- ■ имеющееся количество продаж данной книги; (продукта)
-- ■ название магазина, который находится не в Украине и не в Канаде и продает эту книгу. (клиентов которые не из США и Гремании)
SELECT ProductName, Categories.CategoryName, [Order Details].UnitPrice, UnitsInStock, Customers.Country, COUNT(Orders.OrderID) as 'Количество заказов продукта'
FROM Products, Categories, Customers, Orders, [Order Details]
WHERE
Categories.CategoryID = Products.CategoryID AND
Orders.OrderID = [Order Details].OrderID AND
Products.ProductID = [Order Details].ProductID
GROUP BY ProductName, Categories.CategoryName, [Order Details].UnitPrice, UnitsInStock, Customers.Country
HAVING  Customers.Country NOT IN ('USA','Germany') AND Categories.CategoryName != 'Produce'
ORDER BY Customers.Country

--11. Показать количество авторов в базе данных. Результат сохранить в другую таблицу.
--    (Показываю количество клиентов)
SELECT COUNT(*) AS 'Кол-во клиентов'
INTO CountCustomers
FROM Customers

--12. Показать среднеарифметическую цену продажи всех книг. Результат сохранить в локальную временную таблицу.
--    (Показываю среднеарифметическую цену продуктов)
SELECT AVG(Products.UnitPrice) AS 'Средняя цена продуктов'
INTO #AveragePriceProducts
FROM Products

--13. Показать тематики книг и сумму страниц по каждой из них.
-- (Показываю категории и сумму стоимости товаров этих категорий)
SELECT Categories.CategoryName, SUM(Products.UnitPrice) AS 'Сумма цен продуктов'
FROM Categories,Products
WHERE Categories.CategoryID=Products.CategoryID
GROUP BY Categories.CategoryName

--14. Вывести количество книг и сумму страниц этих книг по каждому из первых трех (!) авторов в базе данных.
--    (Показываю кол-во продуктов и сумму цен продуктов по первым трём категориям)
SELECT TOP 3 Categories.CategoryName, SUM(Products.UnitPrice) AS 'Сумма цен продуктов', COUNT(Products.CategoryID) AS 'Кол-во продуктов'
FROM Categories,Products
WHERE Categories.CategoryID=Products.CategoryID
GROUP BY Categories.CategoryName

--15. Вывести информацию о книгах по "Computer Science" с наибольшим количеством страниц.
--    (Показываю продукты по категории "Produce" с наибольшей ценой)
SELECT *
FROM Products,
(
	SELECT MAX(Products.UnitPrice) AS 'Максимальная цена'
	FROM Products,Categories
	WHERE
	Categories.CategoryID=Products.CategoryID AND
	Categories.CategoryName = 'Produce'
) ProduceMaxPrice
WHERE ProduceMaxPrice.[Максимальная цена] = Products.UnitPrice

--16. Показать авторов и самую старую книгу по каждому из них. Результат сохранить в глобальную временную таблицу.
--    (Показываю категории и самый дешёвый продукт к каждой категории)
SELECT MinPriceOfProducts.CategoryName, Products.ProductName AS 'Самый дешёвый товар'
--INTO ##MinPriceOfProductsByCategories
FROM Products,
(
	SELECT Categories.CategoryID, Categories.CategoryName, MIN(Products.UnitPrice) AS 'Минимальная цена'
	FROM Products,Categories
	WHERE Categories.CategoryID = Products.CategoryID
	GROUP BY Categories.CategoryID, Categories.CategoryName
) MinPriceOfProducts
WHERE
MinPriceOfProducts.[Минимальная цена] = Products.UnitPrice AND
Products.CategoryID = MinPriceOfProducts.CategoryID

--17. Показать на экран среднее количество страниц по каждой из тематик, при этом показать только тематики, в которых среднее количество более 400.
--    (Показываю среднюю цену продуктов по каждой из категории, средняя цена которых больше 40)
SELECT Categories.CategoryName, AVG(Products.UnitPrice) AS 'Средняя цена'
FROM Products, Categories
WHERE
Categories.CategoryID = Products.CategoryID AND
Categories.CategoryID = Products.CategoryID
GROUP BY Categories.CategoryName
HAVING AVG(Products.UnitPrice) > 40

--18. Показать на экран сумму страниц по каждой из тематик, при этом учитывать только книги с количеством страниц более 300,
--    но учитывать при этом только 3 тематики, например "Computer Science", "Science Fiction" и "Web Technologies".
--    (Показываю сумму цен по трём категориям ("Confections","Meat/Poultry","Beverages"), сумма которых больше 30)
SELECT Categories.CategoryName, SUM(Products.UnitPrice) AS 'Сумма цен'
FROM Products, Categories
WHERE
Categories.CategoryID = Products.CategoryID AND
Categories.CategoryID = Products.CategoryID
GROUP BY Categories.CategoryName
HAVING
SUM(Products.UnitPrice) > 300 AND
Categories.CategoryName IN ('Confections','Meat/Poultry', 'Beverages')

--19. Показать количество проданных книг по каждому магазину, в промежутке от 01/01/2007 до сегодняшней даты.
--    (Показываю кол-во заказов по каждой категории, в промежутке от 01/01/1997 до сегодняшней даты.)
SELECT subselect.CategoryName, COUNT(*) AS 'Кол-во продуктов'
FROM (
	SELECT Categories.CategoryName
	FROM Products,Categories,Orders,[Order Details]
	WHERE
	Products.CategoryID = Categories.CategoryID AND
	Orders.OrderID = [Order Details].OrderID AND
	[Order Details].ProductID = Products.ProductID AND
	Orders.OrderDate BETWEEN '01/01/1997' AND '15/11/2018'
) subselect
GROUP BY subselect.CategoryName

--20. Вывести всю информацию о работе магазинов: что, когда, сколько и кем было продано, а также указать страну, где находится магазин.
--    Результат сохранить в другую таблицу
--    (Показываю всю информацию о зделках: что, когда, сколько и кем было продано, а также указать страну, где находится клиент.)
SELECT Products.ProductName, Orders.OrderDate, [Order Details].Quantity, Employees.FirstName + ' ' + Employees.LastName AS 'Employees Name', Customers.Country
FROM Products, Categories, Orders, [Order Details], Employees, Customers
WHERE
Products.CategoryID = Categories.CategoryID AND
Orders.OrderID = [Order Details].OrderID AND
[Order Details].ProductID = Products.ProductID AND
Orders.EmployeeID = Employees.EmployeeID AND
Orders.CustomerID = Customers.CustomerID

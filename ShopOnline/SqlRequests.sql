CREATE TABLE [dbo].[Clients]
(
	[Id] INT  IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[LastName] NVARCHAR(50) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NOT NULL,
	[Phone] NVARCHAR(50),
	[Email] NVARCHAR(50) NOT NULL
)

INSERT INTO Clients VALUES (N'Агапов', N'Сергей', N'Петрович', '555-77-88', 'agapov@mail.ru'),
(N'Александров', N'Пётр', N'Александрович', '222-87-54', 'alexandrov@gmail.com'),
(N'Бушенёв', N'Родион', N'Максимович', '542-98-75', 'byshenev@list.ru'),
(N'Балашёв', N'Максим', N'Сергеевич', '457-00-98', 'balashov@mail.ru'),
(N'Беляев', N'Сергей', N'Андреевич', '222-78-96', 'belyev@gmail.com'),
(N'Бородин', N'Константин', N'Алексеевич', '478-99-36', 'borodin@mail.ru'),
(N'Васильева', N'Анна', N'Ивановна', '222-22-22', 'vasileva@mail.ru'),
(N'Вишневский', N'Виктор', N'Матвеевич', '214-96-32', 'vishnevskiy@gmail.com'),
(N'Вагапов', N'Булат', N'Михаилович', '555-45-77', 'vagapov@mail.ru'),
(N'Владимиров', N'Эдуард', N'Романович', '555-77-88', 'vladimirov@gmail.com'),
(N'Локотунина', N'Екатерина', N'Константиновна', '478-66-25', 'lokotunina@gmail.com');

SELECT * FROM Clients;

--UPDATE Clients SET FirstName = N'Виталий'
--WHERE LastName = N'Бородин';

--UPDATE Clients SET Phone = '777-98-01'
--WHERE Id = 2;

--SELECT * FROM Clients;

CREATE TABLE [dbo].[Purchases]
(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[ItemCode] INT NOT NULL,
	[Product] NVARCHAR(50) NOT NULL	
)

INSERT INTO Purchases VALUES(34, N'Ноутбук HP'),
(67, N'Видеокарта Palit GeForce 1660'),
(11, N'Наушники Sony'),
(34, N'Холодильник Samsung'),
(44, N'Клавиатура HyperX'),
(10, N'Смартфон Iphone 13 mini'),
(91, N'Оперативная память Crucial 8 ГБ'),
(76, N'МФУ Xerox 3015'),
(57, N'Процессор AMD Ryzen 5 2600'),
(22, N'Кулер DeepCool GAMMAXX 400');

SELECT * FROM Purchases;


SELECT Clients.LastName, Clients.FirstName, Clients.MiddleName, Clients.Phone, Clients.Email,
Purchases.ItemCode, Purchases.Product
FROM Clients
JOIN Purchases
ON Clients.Id = Purchases.Id;
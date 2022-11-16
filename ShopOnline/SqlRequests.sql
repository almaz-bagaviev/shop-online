CREATE TABLE [dbo].[Client]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [LastName] NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Contacts]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [Phone] NVARCHAR (20) NOT NULL,
    [Email] NVARCHAR (100) NOT NULL,
    [ClientId] INT NOT NULL
);

CREATE TABLE [dbo].[Location]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [Country] NVARCHAR (50) NOT NULL,
    [City] NVARCHAR (50) NOT NULL,
    [ClientId] INT NOT NULL
);

CREATE TABLE [dbo].[Order]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [Number] INT NOT NULL,
    [Date] DATETIME NOT NULL,
    [ClientId] INT NOT NULL,
    [Product] NVARCHAR (MAX) NOT NULL,
    [Count] DECIMAL (18, 2) NOT NULL
);


insert into Client values(N'Абрамов', N'Александр', N'Иванович'),
(N'Петров', N'Константин', N'Маркович'),
(N'Локотунина', N'Екатерина', N'Константиновна'),
(N'Ямалов', N'Кирилл', N'Львович')

select * from Client;


insert into [Location] values (N'Россия', N'Москва', 1),
(N'Россия', N'Санкт-Петербург', 2),
(N'Россия', N'Сочи', 3),
(N'Белоруссия', N'Минск', 4)

select * from [Location];


insert into Contacts values('555-87-85', 'abramov@mail.ru', 1),
('222-87-01', 'petrov@gmail.ru', 2),
('666-97-21', 'lok@gmail.ru', 3),
('210-74-36', 'yamalov@mail.ru', 4)

select * from Contacts;


insert into [Order] values (501, '2022-07-01 09:02:20', 1, N'Сыр', 0.5),
(901, GETDATE(), 2, N'Рыба', 7),
(908, GETDATE(), 3, N'Мясо', 16.7),
(700, GETDATE(), 4, N'Хлебобулочные изделия', 0.5)

select * from [Order];


select c.LastName, c.FirstName, c.MiddleName,
l.Country, l.City,
ct.Phone, ct.Email,
o.Number, o.[Date], o.Product, o.[Count]
from Client c
left join [Location] l on c.Id=l.ClientId
left join Contacts ct on c.Id=ct.ClientId
left join [Order] o on c.Id=o.ClientId

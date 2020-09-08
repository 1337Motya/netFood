create DATABASE netFoodDb
ON
(
	NAME='netFoodDb',
	FILENAME = 'F:\netFood\database\netFoodDb.mdf'
)
LOG ON
(
	NAME = 'LogNetFoodDb',
	FILENAME = 'F:\netFood\database\LogNetFoodDb.ldf'
)
COLLATE Cyrillic_General_CI_AS 

USE netFoodDb
GO

CREATE TABLE drinks
(
	Id smallint IDENTITY NOT NULL,
	[Name] varchar(20) NOT NULL,
	Calories smallint NOT NULL,
	Price decimal NOT NULL,
	[Image] varchar(50),
	[Description] TEXT NOT NULL,
    volume smallint not null
)
GO
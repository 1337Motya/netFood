use netFoodDb;

create table Categories (
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255)
);

create table Pizzas (
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255),
	[Description] nvarchar(255),
	ImageUrl nvarchar(MAX),
	CategoryId int references Categories (Id),
); 

create table PizzaSizes (
	Id int primary key identity(1,1) not null,
	Pizza int references Pizzas (Id),
	Size int,
	Price decimal(10,5)
);

create table PizzaDoughTypes (
	Id int primary key identity(1,1) not null,
	Pizza int references Pizzas (Id),
	DoughType nvarchar(255)
);

create table Snacks(
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255),
	[Description] nvarchar(255),
	CategoryId int references Categories (Id),
	Price decimal(10,5),
	ImageUrl nvarchar(MAX)
);

create table Desserts(
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255),
	[Description] nvarchar(255),
	CategoryId int references Categories (Id),
	Price decimal(10,5),
	ImageUrl nvarchar(MAX)
);

create table Drinks (
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255),
	[Description] nvarchar(255),
	CategoryId int references Categories (Id),
	Volume float,
	Price decimal(10,5),
	ImageUrl nvarchar(MAX)
);

create table Bundles (
	Id int primary key identity(1,1) not null,
	[Name] nvarchar(255),
	ImageUrl nvarchar(MAX),
	CategoryId int references Categories (Id),
	PizzaId int references Pizzas (Id),
	PizzaAmout int,
	SnackId int references Snacks (Id),
	SnackAmout int,
	DrinkId int references Drinks (Id),
	DrinkAmout int,
	DessertId int references Desserts (Id),
	DessertAmout int,
	Price decimal(10,5)
);

create table Orders(
	Id int primary key identity(1,1) not null,
	[Address] nvarchar(255),
	ÑashPayment bit not null,
	OrderSum decimal(10,5),
	OrderDate Date
);

create table OrderItems(
	Id int primary key identity(1,1) not null,
	OrderId int references Orders (Id),
	CategoryId int references Categories (Id),
	ProductId int,
	Amount int,
);

create table Users (
	Id int primary key identity(1,1) not null,
	Username nvarchar(255),
	Email nvarchar(255),
	[Password] nvarchar(MAX),
	Surname nvarchar(255),
	[Name] nvarchar(255),
	Patronymic nvarchar(255),
	HireDate Date
);

create table Admininstrators(
	Id int primary key identity(1,1) not null,
	UserId int references Users (Id)
);

create table Managers(
	Id int primary key identity(1,1) not null,
	UserId int references Users (Id)
);

create table Staff(
	Id int primary key identity(1,1) not null,
	UserId int references Users (Id)
);
use netFoodDb;

create table Admins (
	Id smallint primary key NOT NULL, 
	[Login] nvarchar(25) NOT NULL,
	[Password] nvarchar(max) not null,
);

create table Orders (
	order_id smallint primary key not null,
	[order] nvarchar(max) not null,
	[address] nvarchar(50) not null,
	[phoneNumber] nvarchar(13) not null
);

create table Pizza (
	Id smallint primary key not null,
	[Name] nvarchar(50) not null,
	[Description] nvarchar(300),
	Ingredients nvarchar(150) not null,
	ImageUrl nvarchar(max),
);

create table PizzaSizes (
	Size_id smallint primary key not null,
	Size smallint
)

create table PizzaPrice(
	Pizza_id smallint foreign key references dbo.Pizza(id),
	Size_id smallint foreign key references dbo.PizzaSizes(size_id),
	Price decimal not null
)


create table DoughTypes (
	Pizza_id smallint primary key foreign key references dbo.Pizza(id),
	Dough nvarchar(20) not null
)

create table Drinks (
	Id smallint primary key not null,
	[Name] nvarchar(50) not null,
	[Description] nvarchar(300),
	ImageUrl nvarchar(max),
)

create table DrinkVolumes (
	Volume_id smallint primary key not null,
	Volume smallint not null
)


create table DrinkPrice(
	Drink_id smallint foreign key references dbo.Drinks(Id),
	Volume_id smallint foreign key references dbo.DrinkVolumes(Volume_id),
	Price decimal not null
	primary key(Drink_id, Volume_id)
)

create table Bundles (
	Id smallint primary key not null,
	[Name] nvarchar(50) not null,
	ImageUrl nvarchar(max),
)

create table BundleItems (
	Bundle_id smallint primary key foreign key references dbo.Bundles(Id),
	Pizza_id smallint foreign key references dbo.Pizza(id),
	Size_id smallint foreign key references dbo.PizzaSizes(size_id),
	Drink_id smallint foreign key references dbo.Drinks(Id),
	Volume_id smallint foreign key references dbo.DrinkVolumes(Volume_id),
)
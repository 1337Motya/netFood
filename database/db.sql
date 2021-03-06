USE [master]
GO
/****** Object:  Database [netFoodDb]    Script Date: 23.12.2020 0:07:37 ******/
CREATE DATABASE [netFoodDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'netFoodDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\netFoodDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'netFoodDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\netFoodDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [netFoodDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [netFoodDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [netFoodDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [netFoodDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [netFoodDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [netFoodDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [netFoodDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [netFoodDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [netFoodDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [netFoodDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [netFoodDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [netFoodDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [netFoodDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [netFoodDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [netFoodDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [netFoodDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [netFoodDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [netFoodDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [netFoodDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [netFoodDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [netFoodDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [netFoodDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [netFoodDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [netFoodDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [netFoodDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [netFoodDb] SET  MULTI_USER 
GO
ALTER DATABASE [netFoodDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [netFoodDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [netFoodDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [netFoodDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [netFoodDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [netFoodDb] SET QUERY_STORE = OFF
GO
USE [netFoodDb]
GO
/****** Object:  Table [dbo].[Bundles]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bundles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[PizzaAmout] [int] NULL,
	[SnackId] [int] NULL,
	[SnackAmout] [int] NULL,
	[DrinkId] [int] NULL,
	[DrinkAmout] [int] NULL,
	[DessertId] [int] NULL,
	[DessertAmout] [int] NULL,
	[Price] [decimal](10, 5) NULL,
	[PizzaOrderId] [int] NULL,
 CONSTRAINT [PK__Bundles__3214EC0789B26BD8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desserts]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desserts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[Price] [decimal](10, 5) NULL,
	[ImageUrl] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drinks]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drinks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[Volume] [float] NULL,
	[Price] [decimal](10, 5) NULL,
	[ImageUrl] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[CategoryId] [int] NULL,
	[ProductId] [int] NULL,
	[Amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[СashPayment] [bit] NOT NULL,
	[OrderSum] [decimal](10, 5) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
 CONSTRAINT [PK__Orders__3214EC07E0879585] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaDoughTypes]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaDoughTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pizza] [int] NULL,
	[DoughType] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaOrders]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[PizzaSizeId] [int] NOT NULL,
	[PizzaDoughTypeId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizzas]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[ImageUrl] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaSizes]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaSizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pizza] [int] NULL,
	[Size] [int] NULL,
	[Price] [decimal](10, 5) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Snacks]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Snacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[Price] [decimal](10, 5) NULL,
	[ImageUrl] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.12.2020 0:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](max) NULL,
	[Surname] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Patronymic] [nvarchar](255) NULL,
	[HireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bundles]  WITH CHECK ADD  CONSTRAINT [FK__Bundles__Categor__37A5467C] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Bundles] CHECK CONSTRAINT [FK__Bundles__Categor__37A5467C]
GO
ALTER TABLE [dbo].[Bundles]  WITH CHECK ADD  CONSTRAINT [FK__Bundles__Dessert__3B75D760] FOREIGN KEY([DessertId])
REFERENCES [dbo].[Desserts] ([Id])
GO
ALTER TABLE [dbo].[Bundles] CHECK CONSTRAINT [FK__Bundles__Dessert__3B75D760]
GO
ALTER TABLE [dbo].[Bundles]  WITH CHECK ADD  CONSTRAINT [FK__Bundles__DrinkId__3A81B327] FOREIGN KEY([DrinkId])
REFERENCES [dbo].[Drinks] ([Id])
GO
ALTER TABLE [dbo].[Bundles] CHECK CONSTRAINT [FK__Bundles__DrinkId__3A81B327]
GO
ALTER TABLE [dbo].[Bundles]  WITH CHECK ADD  CONSTRAINT [FK__Bundles__SnackId__398D8EEE] FOREIGN KEY([SnackId])
REFERENCES [dbo].[Snacks] ([Id])
GO
ALTER TABLE [dbo].[Bundles] CHECK CONSTRAINT [FK__Bundles__SnackId__398D8EEE]
GO
ALTER TABLE [dbo].[Bundles]  WITH CHECK ADD  CONSTRAINT [FK_Bundles_PizzaOrders] FOREIGN KEY([PizzaOrderId])
REFERENCES [dbo].[PizzaOrders] ([Id])
GO
ALTER TABLE [dbo].[Bundles] CHECK CONSTRAINT [FK_Bundles_PizzaOrders]
GO
ALTER TABLE [dbo].[Desserts]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Drinks]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Order__403A8C7D] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK__OrderItem__Order__403A8C7D]
GO
ALTER TABLE [dbo].[PizzaDoughTypes]  WITH CHECK ADD FOREIGN KEY([Pizza])
REFERENCES [dbo].[Pizzas] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD FOREIGN KEY([PizzaId])
REFERENCES [dbo].[Pizzas] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD  CONSTRAINT [FK__PizzaOrde__Pizza__5DCAEF64] FOREIGN KEY([PizzaSizeId])
REFERENCES [dbo].[PizzaSizes] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders] CHECK CONSTRAINT [FK__PizzaOrde__Pizza__5DCAEF64]
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD  CONSTRAINT [FK__PizzaOrde__Pizza__5EBF139D] FOREIGN KEY([PizzaDoughTypeId])
REFERENCES [dbo].[PizzaDoughTypes] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders] CHECK CONSTRAINT [FK__PizzaOrde__Pizza__5EBF139D]
GO
ALTER TABLE [dbo].[PizzaSizes]  WITH CHECK ADD FOREIGN KEY([Pizza])
REFERENCES [dbo].[Pizzas] ([Id])
GO
ALTER TABLE [dbo].[Snacks]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
USE [master]
GO
ALTER DATABASE [netFoodDb] SET  READ_WRITE 
GO

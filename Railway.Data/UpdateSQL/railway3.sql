USE [master]
GO
/****** Object:  Database [railway3]    Script Date: 23.12.2022 20:15:17 ******/
CREATE DATABASE [railway3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'railway3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\railway3.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'railway3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\railway3_log.ldf' , SIZE = 466944KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [railway3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [railway3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [railway3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [railway3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [railway3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [railway3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [railway3] SET ARITHABORT OFF 
GO
ALTER DATABASE [railway3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [railway3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [railway3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [railway3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [railway3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [railway3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [railway3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [railway3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [railway3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [railway3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [railway3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [railway3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [railway3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [railway3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [railway3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [railway3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [railway3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [railway3] SET RECOVERY FULL 
GO
ALTER DATABASE [railway3] SET  MULTI_USER 
GO
ALTER DATABASE [railway3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [railway3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [railway3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [railway3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [railway3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [railway3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'railway3', N'ON'
GO
ALTER DATABASE [railway3] SET QUERY_STORE = OFF
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [railway3_cassier]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [railway3_cassier] WITH PASSWORD=N'rNsOz+eY68EMVZDeVDuynYGg1Yy583d0H7rXDpmla6o=', DEFAULT_DATABASE=[railway3], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [railway3_cassier] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [railway3_admin]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [railway3_admin] WITH PASSWORD=N'Kr5NMOWCEKTADxIK9C44M9EQRoJFOSRpHZCipaqAspk=', DEFAULT_DATABASE=[railway3], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [railway3_admin] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [rail]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [rail] WITH PASSWORD=N'Fk8vxkPp0tzfdlXaE8+aYEDCMtrq1xY3d7CFKpqK1Ks=', DEFAULT_DATABASE=[railway3], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [rail] DISABLE
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT SERVICE\SQLTELEMETRY] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLSERVERAGENT]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT SERVICE\SQLSERVERAGENT] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT Service\MSSQLSERVER]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT Service\MSSQLSERVER] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT AUTHORITY\СИСТЕМА]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [NT AUTHORITY\СИСТЕМА] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [DESKTOP-IQMJSCP\Евгений]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [DESKTOP-IQMJSCP\Евгений] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [DESKTOP-IQMJSCP\Vladimir]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [DESKTOP-IQMJSCP\Vladimir] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [DESKTOP-IQMJSCP\admin]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [DESKTOP-IQMJSCP\admin] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'6N5bnmNB4c0lXHTflal+NOyobxL2x6Q/lE1BnxoQb2M=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 23.12.2022 20:15:17 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'I6o1P0Vr+OKauPFyAqh+hKUWGAx3UH0SH9LXynhw6UE=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [rail]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\Winmgmt]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLSERVERAGENT]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQLSERVER]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [securityadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [serveradmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [setupadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [processadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [diskadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [dbcreator] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [bulkadmin] ADD MEMBER [DESKTOP-IQMJSCP\Евгений]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [DESKTOP-IQMJSCP\Vladimir]
GO
ALTER SERVER ROLE [securityadmin] ADD MEMBER [DESKTOP-IQMJSCP\Vladimir]
GO
ALTER SERVER ROLE [serveradmin] ADD MEMBER [DESKTOP-IQMJSCP\Vladimir]
GO
ALTER SERVER ROLE [dbcreator] ADD MEMBER [DESKTOP-IQMJSCP\Vladimir]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [DESKTOP-IQMJSCP\admin]
GO
USE [railway3]
GO
/****** Object:  User [railway3_cassier]    Script Date: 23.12.2022 20:15:17 ******/
CREATE USER [railway3_cassier] FOR LOGIN [railway3_cassier] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [railway3_admin]    Script Date: 23.12.2022 20:15:17 ******/
CREATE USER [railway3_admin] FOR LOGIN [railway3_admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [rail]    Script Date: 23.12.2022 20:15:17 ******/
CREATE USER [rail] FOR LOGIN [rail] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [cassier]    Script Date: 23.12.2022 20:15:17 ******/
CREATE USER [cassier] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[ticketservice]
GO
/****** Object:  User [admin]    Script Date: 23.12.2022 20:15:17 ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [railway3_cassier]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [railway3_cassier]
GO
ALTER ROLE [db_datareader] ADD MEMBER [railway3_admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [railway3_admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
/****** Object:  Schema [ticketservice]    Script Date: 23.12.2022 20:15:17 ******/
CREATE SCHEMA [ticketservice]
GO
/****** Object:  Table [dbo].[CAR_TYPE]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAR_TYPE](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[capacity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CITY]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CITY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [int] NULL,
	[Name] [nchar](100) NULL,
 CONSTRAINT [PK_CITY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[ShortName] [nchar](40) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PASSANGER]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PASSANGER](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NULL,
	[phone] [nchar](13) NULL,
 CONSTRAINT [PK__PASSANGE__3213E83F000B3881] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROUTE]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROUTE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[from_station_id] [int] NOT NULL,
	[to_station_id] [int] NOT NULL,
 CONSTRAINT [PK_ROUTE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROUTE_SCEDULE]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROUTE_SCEDULE](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[route_id] [int] NULL,
	[station_id] [int] NULL,
	[arrival_time] [datetime] NULL,
	[departure_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEAT]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEAT](
	[id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[train_id] [int] NULL,
	[car_type_id] [int] NULL,
	[car_number] [int] NOT NULL,
	[seat_number] [int] NOT NULL,
 CONSTRAINT [PK__SEAT__3213E83FAED32101] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATION]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATION](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[number] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[CityId] [int] NULL,
 CONSTRAINT [PK__STATION__3213E83FB25D8FAE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCK]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCK](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[train_id] [int] NULL,
	[car_type_id] [int] NULL,
	[number] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T](
	[xmlCol] [xml] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TICKET](
	[id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[number] [int] NOT NULL,
	[train_id] [int] NULL,
	[seat_id] [bigint] NULL,
	[boarding_st_id] [int] NULL,
	[destination_st_id] [int] NULL,
	[passanger] [nvarchar](50) NULL,
 CONSTRAINT [PK__TICKET__3213E83F14EB8E33] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRAIN]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRAIN](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[number] [int] NOT NULL,
	[from_station_id] [int] NULL,
	[to_station_id] [int] NULL,
	[departure] [datetime] NULL,
	[arrival] [datetime] NULL,
	[routeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[isadmin] [bit] NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CITY]  WITH CHECK ADD  CONSTRAINT [FK_CITY_COUNTRY] FOREIGN KEY([Country])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CITY] CHECK CONSTRAINT [FK_CITY_COUNTRY]
GO
ALTER TABLE [dbo].[ROUTE]  WITH CHECK ADD  CONSTRAINT [FK_ROUTE_From_STATION] FOREIGN KEY([from_station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[ROUTE] CHECK CONSTRAINT [FK_ROUTE_From_STATION]
GO
ALTER TABLE [dbo].[ROUTE]  WITH CHECK ADD  CONSTRAINT [FK_ROUTE_To_STATION] FOREIGN KEY([to_station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[ROUTE] CHECK CONSTRAINT [FK_ROUTE_To_STATION]
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE]  WITH CHECK ADD  CONSTRAINT [FK_ROUTE_SCEDULE_ROUTE] FOREIGN KEY([route_id])
REFERENCES [dbo].[ROUTE] ([Id])
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE] CHECK CONSTRAINT [FK_ROUTE_SCEDULE_ROUTE]
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE]  WITH CHECK ADD  CONSTRAINT [FK_ROUTE_SCEDULE_STATION] FOREIGN KEY([station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE] CHECK CONSTRAINT [FK_ROUTE_SCEDULE_STATION]
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD  CONSTRAINT [FK__SEAT__car_type_i__3B75D760] FOREIGN KEY([car_type_id])
REFERENCES [dbo].[CAR_TYPE] ([id])
GO
ALTER TABLE [dbo].[SEAT] CHECK CONSTRAINT [FK__SEAT__car_type_i__3B75D760]
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD  CONSTRAINT [FK__SEAT__train_id__3C69FB99] FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
GO
ALTER TABLE [dbo].[SEAT] CHECK CONSTRAINT [FK__SEAT__train_id__3C69FB99]
GO
ALTER TABLE [dbo].[STATION]  WITH CHECK ADD  CONSTRAINT [FK_STATION_CITY] FOREIGN KEY([CityId])
REFERENCES [dbo].[CITY] ([Id])
GO
ALTER TABLE [dbo].[STATION] CHECK CONSTRAINT [FK_STATION_CITY]
GO
ALTER TABLE [dbo].[STOCK]  WITH CHECK ADD FOREIGN KEY([car_type_id])
REFERENCES [dbo].[CAR_TYPE] ([id])
GO
ALTER TABLE [dbo].[STOCK]  WITH CHECK ADD FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [FK__TICKET__boarding__6CD828CA] FOREIGN KEY([boarding_st_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [FK__TICKET__boarding__6CD828CA]
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [FK__TICKET__destinat__6DCC4D03] FOREIGN KEY([destination_st_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [FK__TICKET__destinat__6DCC4D03]
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [FK__TICKET__seat_id__4222D4EF] FOREIGN KEY([seat_id])
REFERENCES [dbo].[SEAT] ([id])
GO
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [FK__TICKET__seat_id__4222D4EF]
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [FK__TICKET__train_id__4316F928] FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
GO
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [FK__TICKET__train_id__4316F928]
GO
ALTER TABLE [dbo].[TRAIN]  WITH CHECK ADD  CONSTRAINT [FK__TRAIN__from_stat__55F4C372] FOREIGN KEY([from_station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[TRAIN] CHECK CONSTRAINT [FK__TRAIN__from_stat__55F4C372]
GO
ALTER TABLE [dbo].[TRAIN]  WITH CHECK ADD  CONSTRAINT [FK__TRAIN__to_statio__56E8E7AB] FOREIGN KEY([to_station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[TRAIN] CHECK CONSTRAINT [FK__TRAIN__to_statio__56E8E7AB]
GO
ALTER TABLE [dbo].[TRAIN]  WITH CHECK ADD  CONSTRAINT [FK_TRAIN_ROUTE] FOREIGN KEY([routeId])
REFERENCES [dbo].[ROUTE] ([Id])
GO
ALTER TABLE [dbo].[TRAIN] CHECK CONSTRAINT [FK_TRAIN_ROUTE]
GO
/****** Object:  StoredProcedure [dbo].[_insert_seats]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	


-- internal

-- для процедуры add_train
-- добавляет места для вагонов одного типа с фиксированным количеством мест и фиксированной ценой билета
CREATE procedure [dbo].[_insert_seats]
	@train_id int,
	@car_type_id int,
	@number_of_O_cars int,
	@number_of_O_seats int
as
begin
DECLARE @car_number int
if not exists (select 1 from seat where train_id = @train_id)
	SET @car_number = 1
ELSE 
	select @car_number = MAX(car_number) + 1 from seat where train_id = @train_id

	declare @i int = 1
	while @i <= @number_of_O_cars
	begin
		declare @j int = 1;
		while @j <= @number_of_O_seats
		begin
			insert into SEAT(train_id, car_type_id, car_number,	seat_number)
				values (@train_id, @car_type_id, @car_number, @j);
			set @j = @j + 1;
		end
		set @i = @i + 1;
		set @car_number = @car_number + 1
	end
end
GO
/****** Object:  StoredProcedure [dbo].[check_exist_user]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[check_exist_user] 
	@name nvarchar(50),
	@login nvarchar(50),
	@isexist bit output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @flag bit = 0;
	IF EXISTS (SELECT 1 FROM [user] u WHERE u.Name = @name OR u.login = @login)
		SET @flag = 1;

    SET @isExist = @flag;
	
END
GO
/****** Object:  StoredProcedure [dbo].[delete_car_type]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_car_type] 
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM CAR_TYPE where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_city]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_city]
	
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM City WHERE Id =  @id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_country]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[delete_country]
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM Country WHERE Id =  @Id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_route]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[delete_route]
	@route_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DELETE from [ROUTE] WHERE Id = @route_id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_route_scedule]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_route_scedule]
	@route_id	int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DELETE FROM [ROUTE_SCEDULE] WHERE Route_Id = @route_id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_station]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_station]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from station where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[delete_train]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_train] @train_id int
AS
BEGIN
	SET NOCOUNT ON;
	-- удалить места
	-- удалить вагоны

	delete s
	FROM SEAT as s
	WHERE s.train_id = @train_id

	delete s
	from STOCK as s
	where s.train_id=@train_id

	delete s
	FROM SCEDULE as s
	where s.train_id=@train_id

	delete tr
	from TRAIN tr
	where tr.id = @train_id
    
END
GO
/****** Object:  StoredProcedure [dbo].[import_train_data_from_xml]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--drop procedure import_train_data_from_xml
--go

CREATE procedure [dbo].[import_train_data_from_xml]
	@xml xml
as
begin
	set nocount on
	declare @hXml int
	exec sp_xml_preparedocument @hXml output, @xml

	declare train_cursor cursor
	for
	select * from openxml (@hXml, '/Trains/Train', 10)
		with
		(
			train_number int 'TrainNumber',
			from_station_name nvarchar(50) 'FromStationName',
			toStationName nvarchar(50) 'ToStationName',
			timetable xml 'Timetable',
			stock xml 'Stock'
		)

	open train_cursor
	declare @tr_number int
	declare @tr_from nvarchar(50)
	declare @tr_to nvarchar(50)
	declare @tmt xml
	declare @hTmt int
	declare @stock xml
	declare @hStock int
	fetch next from train_cursor into @tr_number, @tr_from, @tr_to, @tmt, @stock

	while (@@FETCH_STATUS = 0)
	begin
		declare @tr_id int = 0
	
		insert into TRAIN(number, from_station_id, to_station_id)
		select @tr_number, dst.id, ast.id
		from STATION dst, STATION ast
		where dst.[name] = @tr_from and ast.[name] = @tr_to

		select @tr_id = max(id) from TRAIN

		exec sp_xml_preparedocument @hTmt output, @tmt

		insert into SCEDULE(train_id, station_id, arrival_time, departure_time)
		select @tr_id, st.id,  nullif(arrival_time, ''), nullif(departure_time, '')
		from openxml (@hTmt, '/Timetable/TimetableEntry')
			with
			(
				station_number int 'StationNumber',
				station_name nvarchar(50) 'StationName',
				arrival_time datetime 'ArrivalTime',
				departure_time datetime 'DepartureTime'
			)
			inner join STATION st on st.[name] = station_name

		exec sp_xml_removedocument @hTmt

		exec sp_xml_preparedocument @hStock output, @stock

		insert into STOCK(train_id, car_type_id, number)
		select @tr_id, ct.id, number
		from openxml (@hStock, '/Stock/StockEntry')
			with
			(
				car_type_name nvarchar(50) 'CarType',
				number int 'Number'
			)
			inner join CAR_TYPE ct on ct.[name] = car_type_name

		exec sp_xml_removedocument @hStock

		fetch next from train_cursor into @tr_number, @tr_from, @tr_to, @tmt, @stock
	end
	close train_cursor
	deallocate train_cursor

	exec sp_xml_removedocument @hXml
end
GO
/****** Object:  StoredProcedure [dbo].[insert_car_type]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_car_type] 
	@name nvarchar(50),
	@capacity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   INSERT INTO CAR_TYPE (Name, Capacity) VALUES (@name, @capacity)
	
END
GO
/****** Object:  StoredProcedure [dbo].[insert_city]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_city]
	@country_id int,
	@city_name nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO City (Country, Name) VALUES ( @country_id, @city_name)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_country]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

CREATE PROCEDURE [dbo].[insert_country]
	@country_name nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO Country (Name) VALUES (@country_name)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_route]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_route]
	@number int,
    @from_station_id int,
    @to_station_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ROUTE] (number, from_station_id, to_station_id) VALUES (@number, @from_station_id, @to_station_id)
END
GO
/****** Object:  StoredProcedure [dbo].[insert_route_scedule]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_route_scedule]
	@route_id int,
    @station_id int,
    @arrival_time DateTime,
    @departure_time  DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO ROUTE_SCEDULE (route_id, station_id, arrival_time, departure_time) VALUES ( @route_id, @station_id, @arrival_time, @departure_time);
END
GO
/****** Object:  StoredProcedure [dbo].[insert_seat]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- INSERT SEAT
CREATE procedure [dbo].[insert_seat]
	@train_id int,
	@car_type_id int,
	@car_number int,
	@seat_number int
as
begin
	insert into SEAT(train_id, car_type_id, car_number, seat_number)
		values (@train_id, @car_type_id, @car_number, @seat_number);
declare @id int,
	@i int
select @id = MAX(id) from seat;


SET @i=1
WHILE @i < @seat_number
BEGIN
	insert into PLACE (seat_id, number, basy) VALUES (@id, @i, null)
END

end
GO
/****** Object:  StoredProcedure [dbo].[insert_station]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[insert_station]
	@station_number int,
	@station_name nvarchar(50),
	@city_id int
as 
begin
	insert into STATION(number, [name], [CityId])
		values (@station_number, @station_name, @city_id);
end

GO
/****** Object:  StoredProcedure [dbo].[insert_stock]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- INSERT STOCK
create procedure [dbo].[insert_stock]
	@train_id int,
	@car_type_id int,
	@number int,
	@id int output
as
begin
	insert into STOCK(train_id, car_type_id, number)
		values (@train_id, @car_type_id, @number);
	select top(1) @id = id from STOCK;
end
GO
/****** Object:  StoredProcedure [dbo].[insert_train]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[insert_train]
	@number int,
	@from_station_id int,
	@to_station_id int,
	@departure datetime,
	@arrival datetime,
	@id int output
as
begin
	insert into TRAIN(number, from_station_id, to_station_id, departure, arrival)
	values (@number, @from_station_id, @to_station_id, @departure, @arrival);
	select top(1) @id = id from TRAIN;
end
GO
/****** Object:  StoredProcedure [dbo].[insert_train_with_stock_with_seats]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- user

-- ввод данных о поезде;
-- ввод данных о составе поезда;
-- ввод данных о местах в поезде (автовычисление на основе данных о составе)
CREATE procedure [dbo].[insert_train_with_stock_with_seats]
	@number int,
	@from_station_id int,
	@to_station_id int,
	@departure datetime,
	@arrival datetime,
	@number_of_O_cars int,
	@number_of_P_cars int,
	@number_of_K_cars int,
	@number_of_SV_cars int
as
begin

	DECLARE @route_id int
	SELECT TOP 1 @route_id = r.Id FROM ROUTE r where number = @number
	insert into TRAIN(number, from_station_id, to_station_id, departure, arrival, routeId)
		values (@number, @from_station_id, @to_station_id, @departure, @arrival, @route_id);
	declare @id int;
	select @id = id from TRAIN where TRAIN.number = @number;

	-- ввод данных о составе поезда - сколько вагонов каждого типа
	insert into STOCK(train_id, car_type_id, number) values (@id, 1, @number_of_O_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 2, @number_of_P_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 3, @number_of_K_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 4, @number_of_SV_cars);

	declare @c_O int;
	select @c_O = capacity from CAR_TYPE where id = 1;
	declare @c_P int;
	select @c_P = capacity from CAR_TYPE where id = 2;
	declare @c_K int;
	select @c_K = capacity from CAR_TYPE where id = 3;
	declare @c_SV int;
	select @c_SV = capacity from CAR_TYPE where id = 4;

	-- ввод данных о местах
	exec _insert_seats @id, 1, @number_of_O_cars, @c_O;
	exec _insert_seats @id, 2, @number_of_P_cars, @c_P;
	exec _insert_seats @id, 3, @number_of_K_cars, @c_K;
	exec _insert_seats @id, 4, @number_of_SV_cars, @c_SV;
end
GO
/****** Object:  StoredProcedure [dbo].[insert_user]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[insert_user]
	@name nvarchar(50),
	@login nvarchar(50),
	@password nvarchar(255),
	@phone  nvarchar(50),
	@email  nvarchar(50),
	@isAdmin	bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 DECLARE @flag bit; 
 exec check_exist_user @name, @login, @flag output;

 if @flag = 1 GOTO error1 

 insert into [USER] ([name], [login], [password], [phone], [email], [isAdmin])
	VALUES (@name,	@login,	@password,	@phone,	@email,	@isAdmin)
 return;


 error1:
	THROW 60001, 'Такой пользователь уже есть в базе данных!', 1


    -- Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[update_car_type]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_car_type]
	@name nvarchar(50),
	@capacity int,
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 Update CAR_TYPE set Name = @name, Capacity = @capacity where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[update_city]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_city]
	@city_name NVarChar(255), 
    @country_id int,
    @city_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update City SET Name = @city_name, Country = @country_id WHERE Id = @city_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_country]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[update_country]
	@country_name nvarchar(255),
	@country_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update Country SET Name = @country_name WHERE Id = @country_Id
END
GO
/****** Object:  StoredProcedure [dbo].[update_route]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_route]
	
	@number int,
	@from_station_id int, 
	@to_station_id int,
	@route_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update ROUTE SET Number = @number, from_station_id = @from_station_id, to_station_id = @to_station_id WHERE Id = @route_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_station]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_station] 
	@station_number int,
    @station_name NVarChar(255),
    @city_id int,
    @station_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Station SET Number = @station_number, Name = @station_name, CityId = @city_id WHERE Id = @station_id
END
GO
/****** Object:  StoredProcedure [ticketservice].[check_passanger]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [ticketservice].[check_passanger]
	@name		nvarchar(50),
	--@city		nvarchar(50),
	--@phone		nchar(13),
	@is_exists	int output
as
begin
	select @is_exists = count(*) from PASSANGER where [name] = @name
	-- and [city] = @city and [phone] = @phone;
end
GO
/****** Object:  StoredProcedure [ticketservice].[delete_ticket_by_id]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [ticketservice].[delete_ticket_by_id]
	@id int
as
begin
	delete from TICKET where id = @id;
end
GO
/****** Object:  StoredProcedure [ticketservice].[get_seat_id]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------
-- register tiсket

CREATE procedure [ticketservice].[get_seat_id]
	@train_id		int,
	@car_number		int,
	@seat_number	int,
	@id				bigint output
as
begin
	select @id = id from SEAT where train_id = @train_id and car_number = @car_number and seat_number = @seat_number;
end
GO
/****** Object:  StoredProcedure [ticketservice].[insert_passanger]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [ticketservice].[insert_passanger]
	@name		nvarchar(50),
	@city		nvarchar(50),
	@phone		nchar(13)
as
begin
	declare @is_exists int = 0;
--	exec check_passanger @name, @city, @phone, @is_exists output;
	exec check_passanger @name, @is_exists output;
	if @is_exists > 0
		return;
	insert into PASSANGER(
		[name],
		[city],
		[phone]
	) values (
		@name,
		@city,
		@phone
	)
end
GO
/****** Object:  StoredProcedure [ticketservice].[insert_ticket]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [ticketservice].[insert_ticket]

	@train_id		int,
	@car_number		int,
	@seat_number	int,
	@this_boarding_st_id		int,
	@this_destination_st_id		int,
	@passanger	nvarchar(50)
as
begin

	declare @seat_id int;		
	SELECT @seat_id = s.id  FROM seat s
	WHERE s.train_id = @train_id 
		and s.car_number = @car_number 
		and s.seat_number = @seat_number

	IF  EXISTS( SELECT 1 FROM TICKET t1 where t1.train_id = @train_id and t1.seat_id = @seat_id)
	BEGIN
		return -1;
	END
	ELSE
	BEGIN

		insert into TICKET(
			number,
			train_id,
			seat_id,
			boarding_st_id,
			destination_st_id,
			passanger
		)
		values(
			6000,
			@train_id,
			@seat_id,
			@this_boarding_st_id,
			@this_destination_st_id,
			@passanger
		)
	END
	return 0;
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_car_types]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_car_types]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [Id], name, capacity  FROM CAR_TYPE
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_cities]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_cities]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT c1.[Id]
     ,c1.[Country]
	 ,c2.[Name] as CountryName
     ,c1.[Name] as CityName
  FROM [CITY] AS c1
  JOIN COUNTRY AS c2 ON c2.Id = c1.Country
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_country]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_country] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id], [Name], [ShortName]  FROM [railway3].[dbo].[COUNTRY]
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_number_by_car_type]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ticketservice].[select_number_by_car_type]
	@car_type int,
	@train_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT DISTINCT car_number from SEAT WHERE car_type_id = @car_type AND train_id =  @train_id
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_route_by_stations]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_route_by_stations]
	@departure_id int,
	@arrival_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
declare @t1 TABLE 
(
	id int,
	number int,
	from_station_id	int,
	DepartureName VARCHAR(255),
    to_station_id int,
	ArrivalName VARCHAR(255)
    );

DECLARE @id int,
		@number int,
		@from_station_id	int,
		@to_station_id int

declare cur cursor FOR
SELECT r.[Id]
      ,r.[number]
      ,r.[from_station_id]
      ,r.[to_station_id]
FROM ROUTE r WHERE from_station_id = @departure_id

OPEN cur
  
  FETCH cur INTO @id, @number, @from_station_id, @to_station_id
  
  WHILE @@FETCH_STATUS = 0
  BEGIN
	IF EXISTS (SELECT 1 FROM ROUTE_SCEDULE WHERE station_id = @arrival_id and route_id = @id)
	BEGIN
		INSERT INTO @t1 (id ,
			number ,
			from_station_id	,
			to_station_id)
		VALUES (@id, @number, @from_station_id, @to_station_id)
	END
	print @id
	FETCH cur INTO @id, @number, @from_station_id, @to_station_id
  END

  
  CLOSE cur
  DEALLOCATE cur

  UPDATE a SET ArrivalName = s1.Name, DepartureName = s2.name
  FROM @t1 as a
  join STATION as s1 on a.to_station_id = s1.id
join STATION as s2 on a.from_station_id = s2.id



  SELECT  id,
		number ,
		from_station_id,
		DepartureName,
		to_station_id,
		ArrivalName
  FROM @t1
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_route_scedule]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_route_scedule]
	@route_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT r.route_Id
      ,r.station_id
	  ,r.arrival_time
      ,r.departure_time
FROM [ROUTE_SCEDULE] r
WHERE r.route_id = @route_Id
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_routes]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_routes]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT r.[Id]
      ,r.[number]
      ,r.[from_station_id]
	  ,s0.name
      ,r.[to_station_id]
	  ,s1.name
FROM [ROUTE] r
JOIN Station as s0 on s0.id = r.from_station_id
JOIN Station as s1 on s1.id = r.to_station_id;
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_sear_number_by_car_type]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_sear_number_by_car_type]

	@train_id int,
	@car_number int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT s.seat_number FROM seat s
	WHERE s.train_id = @train_id 
		AND s.car_number = @car_number
		AND NOT EXISTS( SELECT 1 FROM TICKET t1 where t1.train_id = @train_id AND t1.seat_id = s.id)
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_stations]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [ticketservice].[select_stations]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT s.[Id]
      ,s.[number]
      ,s.[Name] as StationName
      ,c2.[Name] as CityName
      ,c2.[Id] as CityId
  FROM [Station] AS s
  JOIN City AS c2 ON c2.Id = s.CityId
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_stock_by_train]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- select stock

create procedure [ticketservice].[select_stock_by_train]
	@train_id int
as
begin
	select car_type_id, number from STOCK where train_id = @train_id;
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_train_by_date]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ticketservice].[select_train_by_date]
	@Number int,
	@Date date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [id] FROM [TRAIN] as tr  WHERE tr.number = @Number and Convert(Date, tr.[departure]) = @Date
END
GO
/****** Object:  StoredProcedure [ticketservice].[select_trains]    Script Date: 23.12.2022 20:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ticketservice].[select_trains]
	@route_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT tr.[id] as Id
      ,tr.[number]   as Number
      ,tr.[from_station_id] as from_station_id
      ,dep.Name as depName
      ,tr.[to_station_id] as to_station_id
      ,arr.Name as arrName
      ,tr.[departure] as departure
      ,tr.[arrival] as arrival

FROM [TRAIN] tr
JOIN Station as dep on dep.Id = tr.[from_station_id]
JOIN station as arr ON arr.Id = tr.[to_station_id]

WHERE tr.[routeId] = @route_id
END
GO
USE [master]
GO
ALTER DATABASE [railway3] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [railway2]    Script Date: 20.12.2022 17:58:18 ******/
CREATE DATABASE [railway2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'railway2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\railway2.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'railway2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\railway2_log.ldf' , SIZE = 466944KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [railway2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [railway2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [railway2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [railway2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [railway2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [railway2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [railway2] SET ARITHABORT OFF 
GO
ALTER DATABASE [railway2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [railway2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [railway2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [railway2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [railway2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [railway2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [railway2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [railway2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [railway2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [railway2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [railway2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [railway2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [railway2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [railway2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [railway2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [railway2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [railway2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [railway2] SET RECOVERY FULL 
GO
ALTER DATABASE [railway2] SET  MULTI_USER 
GO
ALTER DATABASE [railway2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [railway2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [railway2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [railway2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [railway2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [railway2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'railway2', N'ON'
GO
ALTER DATABASE [railway2] SET QUERY_STORE = OFF
GO
USE [railway2]
GO
/****** Object:  User [rail]    Script Date: 20.12.2022 17:58:19 ******/
CREATE USER [rail] FOR LOGIN [rail] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [cassier]    Script Date: 20.12.2022 17:58:19 ******/
CREATE USER [cassier] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[ticketservice]
GO
/****** Object:  User [admin]    Script Date: 20.12.2022 17:58:19 ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
/****** Object:  Schema [ticketservice]    Script Date: 20.12.2022 17:58:19 ******/
CREATE SCHEMA [ticketservice]
GO
/****** Object:  Table [dbo].[CAR_TYPE]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[CASSIER]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CASSIER](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phone] [nchar](13) NOT NULL,
	[department] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CITY]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[PASSANGER]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PASSANGER](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[phone] [nchar](13) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLACE]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLACE](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[seat_id] [int] NOT NULL,
	[number] [int] NOT NULL,
	[basy] [bit] NULL,
 CONSTRAINT [PK_PLACE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROUTE]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[ROUTE_SCEDULE]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[SCEDULE]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SCEDULE](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[train_id] [int] NULL,
	[station_id] [int] NULL,
	[arrival_time] [datetime] NULL,
	[departure_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEAT]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEAT](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[train_id] [int] NULL,
	[car_type_id] [int] NULL,
	[car_number] [int] NOT NULL,
	[seat_number] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATION]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[STOCK]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  Table [dbo].[T]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T](
	[xmlCol] [xml] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TICKET](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[number] [int] NOT NULL,
	[train_id] [int] NULL,
	[seat_id] [int] NULL,
	[boarding_st_id] [int] NULL,
	[destination_st_id] [int] NULL,
	[passanger] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRAIN]    Script Date: 20.12.2022 17:58:19 ******/
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
ALTER TABLE [dbo].[PLACE]  WITH CHECK ADD  CONSTRAINT [FK_PLACE_SEAT] FOREIGN KEY([seat_id])
REFERENCES [dbo].[SEAT] ([id])
GO
ALTER TABLE [dbo].[PLACE] CHECK CONSTRAINT [FK_PLACE_SEAT]
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE]  WITH CHECK ADD  CONSTRAINT [FK_ROUTE_SCEDULE_station] FOREIGN KEY([station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[ROUTE_SCEDULE] CHECK CONSTRAINT [FK_ROUTE_SCEDULE_station]
GO
ALTER TABLE [dbo].[SCEDULE]  WITH CHECK ADD  CONSTRAINT [FK__SCEDULE__station__634EBE90] FOREIGN KEY([station_id])
REFERENCES [dbo].[STATION] ([id])
GO
ALTER TABLE [dbo].[SCEDULE] CHECK CONSTRAINT [FK__SCEDULE__station__634EBE90]
GO
ALTER TABLE [dbo].[SCEDULE]  WITH CHECK ADD FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD FOREIGN KEY([car_type_id])
REFERENCES [dbo].[CAR_TYPE] ([id])
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
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
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD FOREIGN KEY([seat_id])
REFERENCES [dbo].[SEAT] ([id])
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD FOREIGN KEY([train_id])
REFERENCES [dbo].[TRAIN] ([id])
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
/****** Object:  StoredProcedure [dbo].[_insert_seats]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[delete_train]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[import_train_data_from_xml]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[insert_scedule]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- INSERT SCEDULE
create procedure [dbo].[insert_scedule]
	@train_id int,
	@station_id int,
	@arrival_time datetime,
	@departure_time datetime
as
begin
	insert into SCEDULE(train_id, station_id, arrival_time, departure_time)
		values (@train_id, @station_id, @arrival_time, @departure_time);
end
GO
/****** Object:  StoredProcedure [dbo].[insert_seat]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[insert_station]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[insert_station]
@number int,
	@name nvarchar(50),
	@city int
as 
begin
	insert into STATION(number, [name], [city])
		values (@number, @name, @city);
end

GO
/****** Object:  StoredProcedure [dbo].[insert_stock]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[insert_train]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [dbo].[insert_train_with_stock]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- ввод данных о поезде
-- ввод данных о составе
-- кастомная вместимость
create procedure [dbo].[insert_train_with_stock]
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
		insert into TRAIN(number, from_station_id, to_station_id, departure, arrival)
		values (@number, @from_station_id, @to_station_id, @departure, @arrival);
	declare @id int;
	select @id = id from TRAIN where TRAIN.number = @number;

	-- ввод данных о составе поезда - сколько вагонов каждого типа
	insert into STOCK(train_id, car_type_id, number) values (@id, 1, @number_of_O_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 2, @number_of_P_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 3, @number_of_K_cars);
	insert into STOCK(train_id, car_type_id, number) values (@id, 4, @number_of_SV_cars);
end
GO
/****** Object:  StoredProcedure [dbo].[insert_train_with_stock_with_seats]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [ticketservice].[check_passanger]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [ticketservice].[check_passanger]
	@name		nvarchar(50),
	@city		nvarchar(50),
	@phone		nchar(13),
	@is_exists	int output
as
begin
	select @is_exists = count(*) from PASSANGER where [name] = @name and [city] = @city and [phone] = @phone;
end
GO
/****** Object:  StoredProcedure [ticketservice].[check_seat]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [ticketservice].[check_seat]
	@train_id					int,
	@car_number					int,
	@seat_number				int,
	@this_boarding_st_id		int,
	@this_destination_st_id		int,
	@busy						int output
as
begin
	declare @seat_id int;
	exec [ticketservice].get_seat_id @train_id, @car_number, @seat_number, @seat_id output;

	declare @minsk_pass_station_id int;
	select @minsk_pass_station_id = id from STATION where [name] = 'МИНСК-ПАССАЖИРСКИЙ';

	declare @this_departure datetime;
	select @this_departure = departure_time from SCEDULE where train_id = @train_id and station_id = @this_boarding_st_id;

	declare @this_arrival datetime;
	select @this_arrival = arrival_time from SCEDULE where train_id = @train_id and station_id = @this_destination_st_id;

	declare @minsk_pass_arr datetime;
	declare @minsk_pass_dep datetime;
	select @minsk_pass_arr = arrival_time, @minsk_pass_dep = departure_time from SCEDULE where train_id = @train_id
		and station_id = @minsk_pass_station_id;

	declare @count int;
	select @count = count(*) from TICKET
	inner join SCEDULE boarding on TICKET.boarding_st_id = boarding.station_id and TICKET.train_id = boarding.train_id
	inner join SCEDULE destinstion on TICKET.destination_st_id = destinstion.station_id  and TICKET.train_id = boarding.train_id
	where TICKET.seat_id = @seat_id
		and not ( ((boarding.departure_time < @this_departure) and (destinstion.arrival_time < @this_departure))
			or ((boarding.departure_time > @this_arrival) and (destinstion.arrival_time > @this_arrival)) );
	if @count > 0
		set @busy = 1
	else
		set @busy = 0;
end
GO
/****** Object:  StoredProcedure [ticketservice].[delete_ticket_by_id]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [ticketservice].[get_passanger_id]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- TODO
-- !!!!!!!!!!!!!!!!!!!!!!!!!
-- Добавить обработку ошибок
-- !!!!!!!!!!!!!!!!!!!!!!!!!

-- USER INFRASTRUCTURE

create procedure [ticketservice].[get_passanger_id]
	@name		nvarchar(50),
	@city		nvarchar(50),
	@phone		nchar(13),
	@id			int output
as
begin
	select @id = [id] from PASSANGER where [name] = @name and [city] = @city and [phone] = @phone;
end
GO
/****** Object:  StoredProcedure [ticketservice].[get_passanger_id_by_phone]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [ticketservice].[get_passanger_id_by_phone]
	@phone		nvarchar(50),
	@id			int output
as
begin
	select @id = [id] from PASSANGER where [phone] = @phone;
end
GO
/****** Object:  StoredProcedure [ticketservice].[get_seat_id]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------
-- register tiсket

create procedure [ticketservice].[get_seat_id]
	@train_id		int,
	@car_number		int,
	@seat_number	int,
	@id				int output
as
begin
	select @id = id from SEAT where train_id = @train_id and car_number = @car_number and seat_number = @seat_number;
end
GO
/****** Object:  StoredProcedure [ticketservice].[get_station_id_by_number]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- get st id

create procedure [ticketservice].[get_station_id_by_number]
	@number int,
	@id int output
as
begin
	select @id = id from STATION where number = @number;
end
GO
/****** Object:  StoredProcedure [ticketservice].[hello]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [ticketservice].[hello]
as
begin
	print 'Hello'
end
GO
/****** Object:  StoredProcedure [ticketservice].[insert_passanger]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [ticketservice].[insert_passanger]
	@name		nvarchar(50),
	@city		nvarchar(50),
	@phone		nchar(13)
as
begin
	declare @is_exists int = 0;
	exec check_passanger @name, @city, @phone, @is_exists output;
	if @is_exists > 0
		throw 99999, 'Такой пассажир уже существует', 1
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
/****** Object:  StoredProcedure [ticketservice].[insert_ticket]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [ticketservice].[select_route_by_stations]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [ticketservice].[select_station_by_city]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- select station

CREATE procedure [ticketservice].[select_station_by_city]
	@city NVARCHAR(50)
as
begin
	select s.id, s.number, s.[name], s.city from STATION as s
	join CITY as c on c.Id = s.city and c.Name = @city;
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_stock_by_train]    Script Date: 20.12.2022 17:58:19 ******/
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
/****** Object:  StoredProcedure [ticketservice].[select_stock_by_train_with_default_capacity]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [ticketservice].[select_stock_by_train_with_default_capacity]
	@train_id int
as
begin
	select car_type_id, number, capacity from STOCK
		inner join CAR_TYPE on CAR_TYPE.id = STOCK.car_type_id
		where train_id = @train_id;
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_ticket_by_passanget_id]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------
-- manage tickets

create procedure [ticketservice].[select_ticket_by_passanget_id]
	@passanger_id int
as
begin
	select * from TICKET where passanger_id = @passanger_id;
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_train_by_city]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- filter trains

create procedure [ticketservice].[select_train_by_city]
	@from_city nvarchar(50),
	@to_city nvarchar(50)
as
begin
	select a.train_id,
		tr.number as train_number,
		a.station_id as from_id,
		a.departure_time as from_time,
		ast.[name] as from_name,
		b.station_id as to_id,
		b.arrival_time as to_time,
		bst.[name] as to_name
	from SCEDULE a inner join SCEDULE b on a.train_id = b.train_id
	inner join STATION ast on ast.id = a.station_id
	inner join STATION bst on bst.id = b.station_id
	inner join TRAIN tr on tr.id = a.train_id
	where ast.[city] like @from_city
	and bst.[city] like @to_city
	and b.arrival_time > a.departure_time
end
GO
/****** Object:  StoredProcedure [ticketservice].[select_train_by_number]    Script Date: 20.12.2022 17:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------
-- TICKET INSTRASTRUCTURE

-- select train

create procedure [ticketservice].[select_train_by_number]
	@number int
as
begin
	select id, number, from_station_id, to_station_id, departure, arrival
		from TRAIN where number = @number;
end
GO
USE [master]
GO
ALTER DATABASE [railway2] SET  READ_WRITE 
GO

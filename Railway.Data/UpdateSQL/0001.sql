drop procedure [dbo].[insert_station]
go

create procedure [insert_station]
	@number int,
	@name nvarchar(50),
	@city int
as 
begin
	insert into STATION(number, [name], [city])
		values (@number, @name, @city);
end

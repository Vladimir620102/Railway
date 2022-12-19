ALTER procedure [dbo].[insert_seat]
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


-- internal

-- для процедуры add_train
-- добавляет места для вагонов одного типа с фиксированным количеством мест и фиксированной ценой билета
ALTER procedure [dbo].[_insert_seats]
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

	declare @i int = @car_number;
	while @i <= @number_of_O_cars
	begin
		declare @j int = 1;
		while @j <= @number_of_O_seats
		begin
			insert into SEAT(train_id, car_type_id, car_number,	seat_number)
				values (@train_id, @car_type_id, @i, @j);
			set @j = @j + 1;
		end
		set @i = @i + 1;
	end
end

-- допустим мы уже получили идентификатор пассажира

ALTER procedure [ticketservice].[insert_ticket]

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

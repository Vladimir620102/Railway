SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [ticketservice].[select_number_by_car_type]
	@car_type int,
	@train_id int
AS
BEGIN

	SET NOCOUNT ON;

  SELECT DISTINCT car_number from SEAT 
  WHERE car_type_id = @car_type AND train_id =  @train_id
  ORDER BY car_number
END
GO

ALTER procedure [ticketservice].[select_stock_by_train]
	@train_id int
as
begin
	select car_type_id, number from STOCK where train_id = @train_id
	order by car_type_id, number;
end

GO
ALTER PROCEDURE [ticketservice].[select_sear_number_by_car_type]

	@train_id int,
	@car_number int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT s.seat_number FROM seat s
	WHERE s.train_id = @train_id 
		AND s.car_number = @car_number
		AND NOT EXISTS( SELECT 1 FROM TICKET t1 where t1.train_id = @train_id AND t1.seat_id = s.id)
		order by s.seat_number
END
GO
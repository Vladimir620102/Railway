
CREATE PROCEDURE ticketservice.select_free_seat_by_train
	@train_id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT car_number, COUNT(*)
	from SEAT s 
	WHERE s.train_id = @train_id
		AND NOT EXISTS( SELECT 1 FROM TICKET t1 where t1.train_id = @train_id AND t1.seat_id = s.id)
	GROUP BY s.car_number
	ORDER BY s.car_number
END
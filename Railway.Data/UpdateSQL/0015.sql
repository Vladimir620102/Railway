CREATE PROCEDURE ticketservice.select_number_by_car_type
	@car_type int,
	@train_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT DISTINCT car_number from SEAT WHERE car_type_id = @car_type AND train_id =  @train_id
END

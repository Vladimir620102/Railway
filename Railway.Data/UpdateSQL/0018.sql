CREATE PROCEDURE select_car_types
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [Id], name, capacity  FROM CAR_TYPE
END
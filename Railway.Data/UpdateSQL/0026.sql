-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[insert_route]
	@number int,
    @from_station_id int,
    @to_station_id int,
	@route_id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ROUTE] (number, from_station_id, to_station_id) VALUES (@number, @from_station_id, @to_station_id)
	SET @route_id = SCOPE_IDENTITY()
END
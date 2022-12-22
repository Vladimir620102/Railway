CREATE PROCEDURE [ticketservice].[select_train_by_date]
	@Number int,
	@Date date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [id] FROM [TRAIN] as tr  WHERE tr.number = @Number and Convert(Date, tr.[departure]) = @Date
END

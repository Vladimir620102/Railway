ALTER PROCEDURE [dbo].[delete_train] @train_id int
AS
BEGIN
	SET NOCOUNT ON;
	-- удалить места
	-- удалить вагоны

	delete s
	FROM SEAT as s
	WHERE s.train_id = @train_id

	delete s
	from STOCK as s
	where s.train_id=@train_id

	delete tr
	from TRAIN tr
	where tr.id = @train_id
    
END

CREATE PROCEDURE delete_train @train_id int
AS
BEGIN
	SET NOCOUNT ON;
	-- удалить места

	delete s
	FROM SEAT as s
	WHERE s.train_id = @train_id
	
	-- удалить вагоны
	delete s
	from STOCK as s
	where s.train_id=@train_id

	delete s
	FROM SCEDULE as s
	where s.train_id=@train_id

	delete tr
	from TRAIN tr
	where tr.id = @train_id
    
END

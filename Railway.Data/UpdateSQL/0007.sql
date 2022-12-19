CREATE PROCEDURE ticketservice.select_route_by_stations
	@departure_id int,
	@arrival_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
declare @t1 TABLE 
(
	id int,
	number int,
	from_station_id	int,
	DepartureName VARCHAR(255),
    to_station_id int,
	ArrivalName VARCHAR(255)
    );

DECLARE @id int,
		@number int,
		@from_station_id	int,
		@to_station_id int

declare cur cursor FOR
SELECT r.[Id]
      ,r.[number]
      ,r.[from_station_id]
      ,r.[to_station_id]
FROM ROUTE r WHERE from_station_id = @departure_id

OPEN cur
  
  FETCH cur INTO @id, @number, @from_station_id, @to_station_id
  
  WHILE @@FETCH_STATUS = 0
  BEGIN
	IF EXISTS (SELECT 1 FROM ROUTE_SCEDULE WHERE station_id = @arrival_id and route_id = @id)
	BEGIN
		INSERT INTO @t1 (id ,
			number ,
			from_station_id	,
			to_station_id)
		VALUES (@id, @number, @from_station_id, @to_station_id)
	END
	print @id
	FETCH cur INTO @id, @number, @from_station_id, @to_station_id
  END

  
  CLOSE cur
  DEALLOCATE cur

  UPDATE a SET ArrivalName = s1.Name, DepartureName = s2.name
  FROM @t1 as a
  join STATION as s1 on a.to_station_id = s1.id
join STATION as s2 on a.from_station_id = s2.id



  SELECT  id,
		number ,
		from_station_id,
		DepartureName,
		to_station_id,
		ArrivalName
  FROM @t1
END

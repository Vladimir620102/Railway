CREATE PROCEDURE ticketservice.select_stations
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT s.[Id]
      ,s.[number]
      ,s.[Name] as StationName
      ,c2.[Name] as CityName
      ,c2.[Id] as CityId
  FROM [Station] AS s
  JOIN City AS c2 ON c2.Id = s.CityId
END
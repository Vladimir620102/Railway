CREATE PROCEDURE insert_country
	@countryName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO Country (Name) VALUES (@countryName)
END
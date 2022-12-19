ALTER TABLE station DROP CONSTRAINT FK_STATION_CITY

EXEC sp_rename 'STATION.city', 'CityId', 'COLUMN';

ALTER TABLE station ADD CONSTRAINT FK_STATION_CITY FOREIGN KEY(CityId) 
REFERENCES CITY(Id)
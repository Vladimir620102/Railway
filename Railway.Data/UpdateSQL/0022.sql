DELETE FROM [CAR_TYPE]
SET IDENTITY_INSERT [CAR_TYPE] ON
INSERT INTO [CAR_TYPE] (id, [name], capacity) VALUES (1, 'О', 81)
INSERT INTO [CAR_TYPE] (id, [name], capacity) VALUES (2, 'П', 54)
INSERT INTO [CAR_TYPE] (id, [name], capacity) VALUES (3, 'К', 36)
INSERT INTO [CAR_TYPE] (id, [name], capacity) VALUES (4, 'СВ', 18)
SET IDENTITY_INSERT [CAR_TYPE] OFF
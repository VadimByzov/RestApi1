IF (NOT EXISTS (SELECT *
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_NAME = 'Streets'))
  CREATE TABLE [Streets] (
    [id] INT PRIMARY KEY,
    [name] VARCHAR(100) NOT NULL,
    [city_id] INT NOT NULL
  );

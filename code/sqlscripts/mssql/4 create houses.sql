IF (NOT EXISTS (SELECT *
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_NAME = 'Houses'))
  CREATE TABLE [Houses] (
    [id] INT PRIMARY KEY,
    [number] VARCHAR(50) NOT NULL,
    [street_id] INT NOT NULL
  );

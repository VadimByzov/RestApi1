IF (NOT EXISTS (SELECT *
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_NAME = 'Cities'))
  CREATE TABLE [Cities] (
    [id] INT PRIMARY KEY,
    [name] VARCHAR(100) NOT NULL
  );

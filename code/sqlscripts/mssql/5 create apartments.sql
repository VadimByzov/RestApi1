IF (NOT EXISTS (SELECT *
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_NAME= 'Apartments'))
  CREATE TABLE [Apartments] (
    [id] INT PRIMARY KEY,
    [area] DECIMAL(15, 2) NOT NULL,
    [house_id] INT NOT NULL
  );

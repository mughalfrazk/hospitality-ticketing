CREATE TABLE [CategoryPrice] (
     [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     [Price] FLOAT(50),
     [CompetitionID] INT FOREIGN KEY REFERENCES Competition(Id),
     [DeletedOn] DATETIME NULL,
     [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
     [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
);

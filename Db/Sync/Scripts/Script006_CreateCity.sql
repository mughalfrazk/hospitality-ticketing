CREATE TABLE [City] (
     [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     [Name] NVARCHAR(50),
     [CountryID] INT FOREIGN KEY REFERENCES Country(Id),
     [DeletedOn] DATETIME NULL,
     [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
     [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
);

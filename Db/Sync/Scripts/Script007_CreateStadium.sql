CREATE TABLE [Stadium] (
     [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     [Name] NVARCHAR(50),
     [Address] NVARCHAR(50),
     [Lng] FLOAT(50),
     [Lat] FLOAT(50),
     [Postcode] NVARCHAR(50),
     [CountryID] INT FOREIGN KEY REFERENCES Country(Id),
     [CityID] INT FOREIGN KEY REFERENCES City(Id),
     [DeletedOn] DATETIME NULL,
     [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
     [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
);

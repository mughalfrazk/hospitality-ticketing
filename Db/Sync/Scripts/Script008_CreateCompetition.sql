CREATE TABLE [Competition] (
     [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     [Name] NVARCHAR(50),
     [Description] NVARCHAR(50),
     [DeletedOn] DATETIME NULL,
     [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
     [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
);
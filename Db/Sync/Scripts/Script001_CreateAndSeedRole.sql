CREATE TABLE [Role] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(120) NULL,
    [DeletedOn] DATETIME NULL,
    [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
    [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
    [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
    [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
    );
INSERT INTO [Role]
([Name],
[Description])
VALUES
    ('super-admin' ,'Master Admin'), ('supplier', 'App Admin'), ('client', 'App User')
    GO
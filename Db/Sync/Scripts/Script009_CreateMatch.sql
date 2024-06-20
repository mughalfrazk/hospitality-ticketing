CREATE TABLE [Match] (
     [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
     [Name] NVARCHAR(50),
     [Description] NVARCHAR(50),
     [CompetitionID] INT FOREIGN KEY REFERENCES Competition(Id),
     [StadiumID] INT FOREIGN KEY REFERENCES Stadium(Id),
     [TeamAID] INT FOREIGN KEY REFERENCES Team(Id),
     [TeamBID] INT FOREIGN KEY REFERENCES Team(Id),
     [MatchTime] DATETIME,
     [MatchTimeUTC] DATETIME NULL,
     [MatchTimeTZ] DATETIME NULL,
     [DeletedOn] DATETIME NULL,
     [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [CreatedOn] DATETIME NULL DEFAULT(GETUTCDATE()),
     [ModifiedBy] NVARCHAR(50) NOT NULL DEFAULT('N/A'),
     [ModifiedOn] DATETIME NULL DEFAULT(GETUTCDATE())
);

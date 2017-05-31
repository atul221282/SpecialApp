CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Location] [sys].[geography] NOT NULL, 
    [AuditCreatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedBy] VARCHAR(100) NOT NULL, 
    [AuditCreatedBy] VARCHAR(100) NOT NULL 
)

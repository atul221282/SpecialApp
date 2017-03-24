CREATE TABLE [dbo].[SpecialLocation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Location] [sys].[geography] NOT NULL, 
    [AuditCreatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedBy] DATETIMEOFFSET NOT NULL, 
    [AuditCreatedBy] VARCHAR(100) NOT NULL 
)

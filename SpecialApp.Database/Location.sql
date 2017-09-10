CREATE TABLE [dbo].[Location]
(
	 [Id]                   INT                IDENTITY (1, 1) NOT NULL,
    [Location] [sys].[geography] NOT NULL, 
    [AuditCreatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedDate] DATETIMEOFFSET NOT NULL, 
    [AuditLastUpdatedBy] VARCHAR(100) NOT NULL, 
    [AuditCreatedBy] VARCHAR(100) NOT NULL ,
	CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC)
)

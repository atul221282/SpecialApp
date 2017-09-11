SET IDENTITY_INSERT [dbo].[Location] ON

IF NOT EXISTS(SELECT 1 FROM [dbo].[Location] WHERE Id = 1)
BEGIN

INSERT INTO [Location] 
	(Id,[Location],AuditCreatedBy,AuditCreatedDate,AuditLastUpdatedBy,AuditLastUpdatedDate, IsDeleted)
VALUES
	(1,(SELECT geography::Point(-34.809964, 138.680274, 4326)),'system', N'5/17/2017 1:16:38 PM +00:00','system',N'5/17/2017 1:16:38 PM +00:00',0);

	END

SET IDENTITY_INSERT [dbo].[Location] OFF
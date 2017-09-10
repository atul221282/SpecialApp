SET IDENTITY_INSERT [dbo].[Location] ON

INSERT INTO [Location] 
	(Id,[Location],AuditCreatedBy,AuditCreatedDate,AuditLastUpdatedBy,AuditLastUpdatedDate)
VALUES
	(1,(SELECT geography::Point(-34.809964, 138.680274, 4326)),'system', N'5/17/2017 1:16:38 PM +00:00','system',N'5/17/2017 1:16:38 PM +00:00');

SET IDENTITY_INSERT [dbo].[Location] OFF
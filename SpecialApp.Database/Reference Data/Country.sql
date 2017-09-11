SET IDENTITY_INSERT [dbo].[Country] ON
IF NOT EXISTS(SELECT 1 FROM [dbo].[Country] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[Country] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (1, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'AUS', N'Australia', 0)
END
IF NOT EXISTS(SELECT 1 FROM [dbo].[Country] WHERE Id = 2)
BEGIN

INSERT INTO [dbo].[Country] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (2, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'NZ', N'New Zeland', 0)
END
IF NOT EXISTS(SELECT 1 FROM [dbo].[Country] WHERE Id = 3)
BEGIN

INSERT INTO [dbo].[Country] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (3, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'BHARAT', N'Bharat', 0)
END
SET IDENTITY_INSERT [dbo].[Country] OFF

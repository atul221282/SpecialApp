SET IDENTITY_INSERT [dbo].[AddressType] ON
IF NOT EXISTS(SELECT * FROM [dbo].[AddressType] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[AddressType] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) VALUES (1, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Home', N'Home', 0)
END
IF NOT EXISTS(SELECT * FROM [dbo].[AddressType] WHERE Id = 2)
BEGIN
INSERT INTO [dbo].[AddressType] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) VALUES (2, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Office', N'Office', 0)
END
IF NOT EXISTS(SELECT * FROM [dbo].[AddressType] WHERE Id = 3)
BEGIN
INSERT INTO [dbo].[AddressType] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) VALUES (3, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Postal', N'Postal', 0)
END
SET IDENTITY_INSERT [dbo].[AddressType] OFF

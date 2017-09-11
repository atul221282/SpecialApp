SET IDENTITY_INSERT [dbo].[SpecialCategory] ON
IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialCategory] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[SpecialCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (1, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'FOOD', N'Food', 0)
END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialCategory] WHERE Id = 2)
BEGIN

INSERT INTO [dbo].[SpecialCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (2, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'ELEC', N'Electric', 0)
END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialCategory] WHERE Id = 3)
BEGIN

INSERT INTO [dbo].[SpecialCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (3, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'BAKERY', N'Bakery', 0)
END
SET IDENTITY_INSERT [dbo].[SpecialCategory] OFF

SET IDENTITY_INSERT [dbo].[CompanyFranchiseCategory] ON

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchiseCategory] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[CompanyFranchiseCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) 
VALUES (1, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Food', N'Food', 0)
END

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchiseCategory] WHERE Id = 2)
BEGIN
INSERT INTO [dbo].[CompanyFranchiseCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) VALUES (2, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Mobile', N'Mobile', 0)
END

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchiseCategory] WHERE Id = 3)
BEGIN
INSERT INTO [dbo].[CompanyFranchiseCategory] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [Code], [Description], [IsDeleted]) VALUES (3, N'system', N'4/27/2017 9:21:10 PM +09:30', N'system', N'4/27/2017 9:21:10 PM +09:30', N'Car', N'Car', 0)
END

SET IDENTITY_INSERT [dbo].[CompanyFranchiseCategory] OFF

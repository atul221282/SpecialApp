SET IDENTITY_INSERT [dbo].[Company] ON
IF NOT EXISTS(SELECT 1 FROM [dbo].[Company] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (1, N'system', N'5/17/2017 1:01:31 PM +00:00', N'system', N'5/17/2017 1:01:31 PM +00:00', N'TEST 1', N'TEST DETAILS', 0, 1)
END
IF NOT EXISTS(SELECT 1 FROM [dbo].[Company] WHERE Id = 2)
BEGIN
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (2, N'system', N'5/17/2017 1:14:28 PM +00:00', N'system', N'5/17/2017 1:14:28 PM +00:00', N'TEST 2', N'TEST DETAILS 2', 0, 1)
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[Company] WHERE Id = 3)
BEGIN
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (3, N'system', N'5/17/2017 1:16:38 PM +00:00', N'system', N'5/17/2017 1:16:38 PM +00:00', N'TEST 3', N'TEST DETAILS 3', 0, 1)
END
SET IDENTITY_INSERT [dbo].[Company] OFF

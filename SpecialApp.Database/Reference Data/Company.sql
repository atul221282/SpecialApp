SET IDENTITY_INSERT [dbo].[Company] ON
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (1, N'system', N'5/17/2017 1:01:31 PM +00:00', N'system', N'5/17/2017 1:01:31 PM +00:00', N'TEST 1', N'TEST DETAILS', 0, 1)
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (2, N'system', N'5/17/2017 1:14:28 PM +00:00', N'system', N'5/17/2017 1:14:28 PM +00:00', N'TEST 2', N'TEST DETAILS 2', 0, 1)
INSERT INTO [dbo].[Company] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [CompanyName], [Details], [IsDeleted], [NumberOfEmployees]) 
VALUES (3, N'system', N'5/17/2017 1:16:38 PM +00:00', N'system', N'5/17/2017 1:16:38 PM +00:00', N'TEST 3', N'TEST DETAILS 3', 0, 1)
SET IDENTITY_INSERT [dbo].[Company] OFF

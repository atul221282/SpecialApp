SET IDENTITY_INSERT [dbo].[Users] ON

IF NOT EXISTS(SELECT 1 FROM [Users] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[Users] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [DOB], [FirstName], 
[IsDeleted], [LastName], [SpecialAppUsersId]) 
VALUES (1, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', N'12/21/1982 1:30:00 PM +00:00', 
N'Atul', 0, N'Chaudhary', N'ece2b5ed-e306-4b4a-a785-66b2a4899cc9')
END

IF NOT EXISTS(SELECT 1 FROM [Users] WHERE Id = 2)
BEGIN
INSERT INTO [dbo].[Users] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [DOB], [FirstName], 
[IsDeleted], [LastName], [SpecialAppUsersId]) 
VALUES (2, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', N'12/21/1982 1:30:00 PM +00:00', 
N'Bhanu', 0, N'Sharma', N'ece2b5ed-e306-4b4a-a785-66b2a4899cc8')
END

SET IDENTITY_INSERT [dbo].[Users] OFF

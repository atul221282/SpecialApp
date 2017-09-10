SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], [AuditLastUpdatedDate], [DOB], [FirstName], 
[IsDeleted], [LastName], [SpecialAppUsersId]) 
VALUES (1, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', N'12/21/1982 1:30:00 PM +00:00', 
N'Atul', 0, N'Chaudhary', N'ece2b5ed-e306-4b4a-a785-66b2a4899cc9')
SET IDENTITY_INSERT [dbo].[Users] OFF

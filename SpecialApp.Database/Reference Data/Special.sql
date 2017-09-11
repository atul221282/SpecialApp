SET IDENTITY_INSERT [dbo].[Special] ON

IF NOT EXISTS(SELECT 1 FROM [dbo].[Special] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[Special] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], 
[AuditLastUpdatedDate], [CompanyFranchiseId], [CreateDate], [CreatedById], [Details], [EndDate], 
[IsAvailableOnline], [IsDeleted], [ProductType], [PromoCode], [SpecialCategoryId]) 
VALUES (1, 'system', N'4/27/2017 9:21:10 PM +09:30', 'system', 
N'4/27/2017 9:21:10 PM +09:30', 1, N'4/27/2017 9:21:10 PM +09:30', N'ece2b5ed-e306-4b4a-a785-66b2a4899cc9', 'Some details', N'9/27/2017 9:21:10 PM +09:30', 
1, 0, 'Some type', 'SOMECODE123', 1)
END
SET IDENTITY_INSERT [dbo].[Special] OFF

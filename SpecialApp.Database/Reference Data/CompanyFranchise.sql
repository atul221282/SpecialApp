SET IDENTITY_INSERT [dbo].[CompanyFranchise] ON

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchise] WHERE Id = 1)
BEGIN


INSERT INTO [dbo].[CompanyFranchise] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], 
[AuditLastUpdatedDate], [CanContactCustomers], [CanGetCustomerDetails], [CanSellOnline], 
[CompanyFranchiseCategoryId], [CompanyId], [ConfirmationToken], [CreatedById], [IsConfirmed], [IsDeleted]) 
VALUES (1, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', 
1, 1, 1, 1, 1, N'112233AASS', 1, 1, 0)


END

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchise] WHERE Id = 2)
BEGIN


INSERT INTO [dbo].[CompanyFranchise] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], 
[AuditLastUpdatedDate], [CanContactCustomers], [CanGetCustomerDetails], [CanSellOnline], 
[CompanyFranchiseCategoryId], [CompanyId], [ConfirmationToken], [CreatedById], [IsConfirmed], [IsDeleted]) 
VALUES (2, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', 
1, 1, 1, 1, 2, N'112233AASS', 1, 1, 0)


END

IF NOT EXISTS(SELECT * FROM [dbo].[CompanyFranchise] WHERE Id = 3)
BEGIN


INSERT INTO [dbo].[CompanyFranchise] ([Id], [AuditCreatedBy], [AuditCreatedDate], [AuditLastUpdatedBy], 
[AuditLastUpdatedDate], [CanContactCustomers], [CanGetCustomerDetails], [CanSellOnline], 
[CompanyFranchiseCategoryId], [CompanyId], [ConfirmationToken], [CreatedById], [IsConfirmed], [IsDeleted]) 
VALUES (3, N'system', N'9/11/2017 8:54:18 AM +09:30', N'system', N'9/11/2017 8:54:18 AM +09:30', 
1, 1, 1, 1, 3, N'112233AASS', 1, 1, 0)


END

SET IDENTITY_INSERT [dbo].[CompanyFranchise] OFF

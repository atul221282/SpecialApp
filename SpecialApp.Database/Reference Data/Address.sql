SET IDENTITY_INSERT [dbo].[Address] ON
IF NOT EXISTS(SELECT * FROM [dbo].[Address] WHERE Id = 1)
BEGIN
INSERT INTO [dbo].[Address] ([Id], [AddressLine1], [AddressLine2], [AddressState], [AddressTypeId], [AuditCreatedBy], [AuditCreatedDate], 
[AuditLastUpdatedBy], [AuditLastUpdatedDate], [City], [CountryId], [IsDeleted], [PostalCode], [Province], [Suburb]) 
VALUES (1, NULL, NULL, N'SA', 1, N'system', N'5/17/2017 1:01:31 PM +00:00', N'system', N'5/17/2017 1:01:31 PM +00:00', NULL, 1, 0, N'5092', NULL, NULL)
END
IF NOT EXISTS(SELECT * FROM [dbo].[Address] WHERE Id = 2)
BEGIN
INSERT INTO [dbo].[Address] ([Id], [AddressLine1], [AddressLine2], [AddressState], [AddressTypeId], [AuditCreatedBy], [AuditCreatedDate], 
[AuditLastUpdatedBy], [AuditLastUpdatedDate], [City], [CountryId], [IsDeleted], [PostalCode], [Province], [Suburb]) 
VALUES (2, NULL, NULL, N'SA', 2, N'system', N'5/17/2017 1:14:28 PM +00:00', N'system', N'5/17/2017 1:14:28 PM +00:00', NULL, 1, 0, N'1234', NULL, NULL)
END
IF NOT EXISTS(SELECT * FROM [dbo].[Address] WHERE Id = 3)
BEGIN
INSERT INTO [dbo].[Address] ([Id], [AddressLine1], [AddressLine2], [AddressState], [AddressTypeId], [AuditCreatedBy], [AuditCreatedDate], 
[AuditLastUpdatedBy], [AuditLastUpdatedDate], [City], [CountryId], [IsDeleted], [PostalCode], [Province], [Suburb]) VALUES (3, NULL, NULL, N'WA', 3, N'system', N'5/17/2017 1:16:38 PM +00:00', N'system', N'5/17/2017 1:16:38 PM +00:00', NULL, 2, 0, N'5431', NULL, NULL)
END
SET IDENTITY_INSERT [dbo].[Address] OFF

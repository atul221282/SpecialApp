IF NOT EXISTS(SELECT 1 FROM [dbo].[CompanyAddress] WHERE [AddressId] = 1 AND CompanyId = 1)
BEGIN
	INSERT INTO [dbo].[CompanyAddress] ([AddressId], [CompanyId]) VALUES (1, 1)
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[CompanyAddress] WHERE [AddressId] = 2 AND CompanyId = 2)
BEGIN
	INSERT INTO [dbo].[CompanyAddress] ([AddressId], [CompanyId]) VALUES (2, 2)
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[CompanyAddress] WHERE [AddressId] = 3 AND CompanyId = 3)
BEGIN
	INSERT INTO [dbo].[CompanyAddress] ([AddressId], [CompanyId]) VALUES (3, 3)
END

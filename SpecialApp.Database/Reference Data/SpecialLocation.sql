IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialLocation] WHERE [SpecialId]=1 AND [LocationId]=1 AND [AddressId] = 1)
BEGIN
	INSERT INTO [dbo].[SpecialLocation] ([SpecialId], [LocationId], [AddressId]) VALUES (1, 1, 1)
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialLocation] WHERE [SpecialId]=2 AND [LocationId]=1 AND [AddressId] = 1)
BEGIN
	INSERT INTO [dbo].[SpecialLocation] ([SpecialId], [LocationId], [AddressId]) VALUES (2, 1, 1)
END


IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialLocation] WHERE [SpecialId]=3 AND [LocationId]=1 AND [AddressId] = 1)
BEGIN
	INSERT INTO [dbo].[SpecialLocation] ([SpecialId], [LocationId], [AddressId]) VALUES (3, 1, 1)
END


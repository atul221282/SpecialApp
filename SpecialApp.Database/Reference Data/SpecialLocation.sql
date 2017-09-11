IF NOT EXISTS(SELECT 1 FROM [dbo].[SpecialLocation] WHERE [SpecialId]=1 AND [LocationId]=1 AND [AddressId] = 1)
BEGIN
	INSERT INTO [dbo].[SpecialLocation] ([SpecialId], [LocationId], [AddressId]) VALUES (1, 1, 1)
END


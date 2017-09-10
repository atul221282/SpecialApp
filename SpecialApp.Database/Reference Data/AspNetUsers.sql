SET IDENTITY_INSERT [dbo].[AspNetUsers] ON
INSERT INTO 
	[dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], 
	[NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) 
VALUES 
	(N'ece2b5ed-e306-4b4a-a785-66b2a4899cc9', 0, N'01f27daf-e116-4b49-8eb7-0376707f9155', N'atul221282@gmail.com',
	0, 1, NULL, N'ATUL221282@GMAIL.COM', N'ATUL221282', N'AQAAAAEAACcQAAAAENs6uE3ualdu4fVa8ID9IJW+Q3N/+tdBgOpw1Y+W0LtPgGm/kgq7CmTewFgJxC0nxQ==',
	N'0430499210', 0, N'dd575848-fc18-40d1-aa6a-a089540b2f35', 0, N'atul221282')
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF

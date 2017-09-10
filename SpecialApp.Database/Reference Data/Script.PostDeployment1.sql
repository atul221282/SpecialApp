/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r".\CompanyFranchiseCategory.sql"
GO
:r".\AddressType.sql"
GO
:r".\Country.sql"
GO
:r".\Address.sql"
GO
:r".\Company.sql"
GO
:r".\CompanyAddress.sql"
GO
:r".\Location.sql"
GO
:r".\AspNetUsers.sql"
GO
:r".\Users.sql"
GO

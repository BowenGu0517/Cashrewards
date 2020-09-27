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

insert into [dbo].[Merchant]
values (
	'ff5bd02f-c108-41ce-a1a1-2ae6c15e07b1',
	1,
	'AUD',
	'www.test-01.com',
	'Australia',
	10,
	getdate(),
	null
)

insert into [dbo].[Merchant]
values (
	'ff5bd02f-c108-41ce-a1a1-2ae6c15e07b2',
	0,
	'USD',
	'www.test-02.com',
	'America',
	20,
	getdate(),
	null
)
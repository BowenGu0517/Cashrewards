CREATE TABLE [dbo].[Merchant]
(
	[Id]					INT				NOT NULL	IDENTITY(1,1),
	[UniqueId]				NVARCHAR(50)	NOT NULL,
	[IsActive]				BIT				NOT NULL,
	[Currency]				NVARCHAR(10)	NOT NULL,
	[WebsiteUrl]			NVARCHAR(100)	NOT NULL,
	[Country]				NVARCHAR(50)	NOT NULL,
	[DiscountPercentage]	DECIMAL(18,2)	NOT NULL,
	[CreatedTime]			DATETIME		NOT NULL,
	UpdatedTime				DATETIME		NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC)
)

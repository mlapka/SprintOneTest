﻿CREATE TABLE [dbo].[Lists](
	[SupplierID] [int] NOT NULL,
	[ItemListID] [int] NOT NULL,
	[DateListed] [date] NOT NULL
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC,
	[ItemListID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
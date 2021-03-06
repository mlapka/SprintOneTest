﻿CREATE TABLE [dbo].[EventType](
	[EventTypeID] [int] IDENTITY(100,1) NOT NULL,
	[EventName]	[varchar](255) NOT NULL
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE INDEX EventTypeIndex
ON [EventType] (EventTypeID, EventName)
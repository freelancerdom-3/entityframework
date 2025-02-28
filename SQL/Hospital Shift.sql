USE [HSMDB]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 28-02-2025 14:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[Shiftid] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Shiftname] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Shiftid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Shift] ON 
GO
INSERT [dbo].[Shift] ([Shiftid], [StartTime], [EndTime], [Shiftname]) VALUES (4, CAST(N'01:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Night')
GO
SET IDENTITY_INSERT [dbo].[Shift] OFF
GO

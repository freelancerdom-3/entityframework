USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblShift]    Script Date: 06/03/2025 03:36:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblShift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Shiftname] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblShift] ON 
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (1, CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Night')
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (2, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Morning ')
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (3, CAST(N'16:00:00' AS Time), CAST(N'23:59:00' AS Time), N'Aftoornoon')
GO
SET IDENTITY_INSERT [dbo].[TblShift] OFF
GO

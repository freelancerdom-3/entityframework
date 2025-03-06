USE [HMSDDB]
GO
/****** Object:  Table [dbo].[TblRoomLocations]    Script Date: 3/6/2025 2:00:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomLocations](
	[RoomLocationID] [int] IDENTITY(1,1) NOT NULL,
	[Floornumber] [int] NULL,
	[RoomID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblRoomLocations] ON 
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (2, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (3, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (4, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (5, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (6, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (7, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (8, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (9, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (10, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (11, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (12, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (13, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (14, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (15, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[TblRoomLocations] OFF
GO
ALTER TABLE [dbo].[TblRoomLocations]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO

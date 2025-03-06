USE [HMSDDB]
GO
/****** Object:  Table [dbo].[TblRoom]    Script Date: 3/6/2025 1:53:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoom](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NULL,
	[RoomTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblRoom] ON 
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (1, 102, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (2, 103, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (3, 104, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (4, 105, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (5, 106, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (6, 107, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (7, 109, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (8, 110, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (9, 201, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (10, 202, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (11, 203, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (12, 204, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (13, 205, 3)
GO
SET IDENTITY_INSERT [dbo].[TblRoom] OFF
GO
ALTER TABLE [dbo].[TblRoom]  WITH CHECK ADD FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[TblRoomType] ([RoomTypeId])
GO

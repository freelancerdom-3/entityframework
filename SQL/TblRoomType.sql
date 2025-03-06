USE [HMSDDB]
GO
/****** Object:  Table [dbo].[TblRoomType]    Script Date: 3/6/2025 2:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] ON 
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (1, N'private room')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (2, N'special room')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (3, N'ICU')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (4, N'PICU')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (5, N'Super deluxe room')
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] OFF
GO

USE [HSMDB]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 28-02-2025 13:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (3, N'private room')
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (4, N'special room')
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (5, N'ICU')
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (6, N'PICU')
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (7, N'Super deluxe room')
GO
INSERT [dbo].[RoomType] ([RoomId], [RoomType]) VALUES (8, N'string')
GO
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO

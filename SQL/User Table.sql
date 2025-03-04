USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 04-03-2025 18:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Password] [varchar](max) NULL,
	[MobileNumber] [varchar](10) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblUser] ON 
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (1, N'df', N'arj', N'fgn', N'7645878452', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (2, N'Parth Rethaliya', N'parth123@gmail.com', N'parth@123', N'9658456952', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (3, N'string', N'string', N'string', N'9658456952', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (4, N'vraj patel', N'vraj123@gmail.com', N'vraj@123', N'6352564256', 4)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (5, N'sahil savaj', N'sahil129@gamil.com', N'sahil@123', N'6352563254', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (6, N'jaypal vasveliya', N'jaypal126@gmail.com', N'jaypal@123', N'9658452154', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (7, N'khushi mehta', N'khushi124@gmail.com', N'khushi@123', N'6325485216', 7)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (8, N'mahipat chav', N'mahipat129@gmail.com', N'mahipat@123', N'9658745236', 8)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (9, N'Rahul bar', N'rahul143@gmail.com', N'rahul@123', N'7856952365', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (10, N'Rohit Bavliya', N'rohit123@gmail.com', N'rohit@123', N'9653256347', 8)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (12, N'Hello', N'Hello@gmail.com', N'Hssdei', N'1234567891', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (13, N'stricfgng', N'strifyng', N'strinrfyg', N'7645878452', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (14, N'strivng', N'stringc', N'strixcfng', N'7645878452', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (15, N'string', N'HEY', N'string', N'string', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (16, N'string', N'string1', N'string', N'string', 2)
GO
SET IDENTITY_INSERT [dbo].[TblUser] OFF
GO

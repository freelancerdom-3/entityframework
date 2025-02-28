USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblRole]    Script Date: 27/02/2025 10:25:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblRole] ON 
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (1, N'Doctor')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (2, N'Medical Officer')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (3, N'Nurse')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (4, N'Receptionist')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (5, N'Compounder')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (6, N'Security')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (7, N'HR manager')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (8, N'IT specialist')
GO
SET IDENTITY_INSERT [dbo].[TblRole] OFF
GO

USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblUserRoleMapping]    Script Date: 13-05-2025 11:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRoleMapping](
	[TblUserRoleMappingID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[VersionNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TblUserRoleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblUserRoleMapping] ON 
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 1, 48, CAST(N'2025-05-09T11:41:45.180' AS DateTime), 48, CAST(N'2025-05-09T11:41:45.180' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 2, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 3, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 5, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 6, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 7, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 8, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 9, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 10, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 11, 4, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 12, 3, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, 13, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, 14, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, 15, 2, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, 48, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T13:41:15.260' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, 48, 3, 0, CAST(N'2025-05-09T14:04:45.453' AS DateTime), 48, CAST(N'2025-05-09T08:34:17.313' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, 15, 3, 0, CAST(N'2025-05-09T14:09:06.243' AS DateTime), 48, CAST(N'2025-05-09T08:38:40.360' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, 15, 3, 0, CAST(N'2025-05-09T14:09:13.190' AS DateTime), 48, CAST(N'2025-05-09T08:38:40.360' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, 1, 2, 0, CAST(N'2025-05-09T14:14:49.123' AS DateTime), 48, CAST(N'2025-05-09T08:44:37.843' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblUserRoleMapping] OFF
GO

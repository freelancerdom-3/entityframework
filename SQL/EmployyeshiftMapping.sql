USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblEmployeeshiftMapping]    Script Date: 06/03/2025 12:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeshiftMapping](
	[EmployeeshiftMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeshiftMappingStartingDate] [date] NULL,
	[EmployeeshiftMappingEndingData] [date] NULL,
	[UserId] [int] NULL,
	[ShiftId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeshiftMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] ON 
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (1, CAST(N'2025-03-01' AS Date), CAST(N'2025-03-07' AS Date), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (2, CAST(N'2025-03-08' AS Date), CAST(N'2025-03-15' AS Date), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (3, CAST(N'2025-03-16' AS Date), CAST(N'2025-03-23' AS Date), 1, 3)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (4, CAST(N'2025-03-24' AS Date), CAST(N'2025-03-30' AS Date), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] OFF
GO
ALTER TABLE [dbo].[TblEmployeeshiftMapping]  WITH CHECK ADD FOREIGN KEY([ShiftId])
REFERENCES [dbo].[TblShift] ([Shiftid])
GO
ALTER TABLE [dbo].[TblEmployeeshiftMapping]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO

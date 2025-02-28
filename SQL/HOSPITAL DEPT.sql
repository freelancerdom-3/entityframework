USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblHospitalDept]    Script Date: 2/27/2025 10:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalDept](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[Department] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblHospitalDept] ON 
GO
INSERT [dbo].[TblHospitalDept] ([DeptId], [Department]) VALUES (1, N'Emergency Department')
GO
INSERT [dbo].[TblHospitalDept] ([DeptId], [Department]) VALUES (3, N'Cardiology Department')
GO
INSERT [dbo].[TblHospitalDept] ([DeptId], [Department]) VALUES (4, N'Orthopedic Department')
GO
INSERT [dbo].[TblHospitalDept] ([DeptId], [Department]) VALUES (5, N'Pediatrics Department')
GO
SET IDENTITY_INSERT [dbo].[TblHospitalDept] OFF
GO

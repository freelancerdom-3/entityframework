USE [HSMDB]
GO
/****** Object:  Table [dbo].[TbLHospitalDepartment]    Script Date: 3/5/2025 4:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbLHospitalDepartment](
	[HospitalDepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalDepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TbLHospitalDepartment] ON 
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (1, N'Emergency Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (3, N'Cancer Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (4, N'Orthopedic Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (5, N'Pediatrics Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (8, N'Gynec Department')
GO
SET IDENTITY_INSERT [dbo].[TbLHospitalDepartment] OFF
GO

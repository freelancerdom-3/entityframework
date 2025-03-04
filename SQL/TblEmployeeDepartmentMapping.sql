USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblEmployeeDepartmentMapping]    Script Date: 3/4/2025 5:21:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeDepartmentMapping](
	[EmployeeDepartmentMappingID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[HospitalDepartmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeDepartmentMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] ON 
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (4, 9, 4)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (7, 5, 4)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (8, 6, 5)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] OFF
GO
ALTER TABLE [dbo].[TblEmployeeDepartmentMapping]  WITH CHECK ADD FOREIGN KEY([HospitalDepartmentID])
REFERENCES [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID])
GO
ALTER TABLE [dbo].[TblEmployeeDepartmentMapping]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO

USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblHospitalType]    Script Date: 04-03-2025 18:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalType](
	[HospitalTypeID] [int] IDENTITY(1,1) NOT NULL,
	[HospitalType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] ON 
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (1, N'Multi-Speciality Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (2, N'Semi-Speciality Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (3, N'Neurosurgeon Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (4, N'Childeren Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (5, N'Kidney Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (6, N'Orthopedic Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (7, N'Eye Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (9, N'string')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (10, N'string')
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] OFF
GO

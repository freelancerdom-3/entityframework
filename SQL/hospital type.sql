USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblHospitalTyp]    Script Date: 27-02-2025 10:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalTyp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HospitalType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblHospitalTyp] ON 
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (1, N'Multi-Specialty Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (2, N'Semi-Speciality Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (3, N'Neurosurgeon Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (4, N'Childeren Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (5, N'Kidney Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (6, N'Orthopedic Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (7, N'Eye Hospital')
GO
INSERT [dbo].[TblHospitalTyp] ([ID], [HospitalType]) VALUES (8, N'Women''s Hospital')
GO
SET IDENTITY_INSERT [dbo].[TblHospitalTyp] OFF
GO

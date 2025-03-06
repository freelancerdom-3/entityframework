USE [HMSDDB]
GO
/****** Object:  Table [dbo].[TblDiseaseType]    Script Date: 3/6/2025 1:55:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDiseaseType](
	[DieseaseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DieseaseTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] ON 
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (1, N'Fever')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (2, N'Brain Stoke')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (3, N'Enteric Fever')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (4, N'Pneumonia')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (5, N'Anemia')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (6, N'Alcoholic Liver Disease')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (7, N'Jaundice')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (8, N'Maleria')
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] OFF
GO

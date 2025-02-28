USE [HSMDB]
GO
/****** Object:  Table [dbo].[DiseaseType]    Script Date: 2/28/2025 12:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseType](
	[DieseaseID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DieseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DiseaseType] ON 
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (1, N'Fever')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (2, N'Brain Stoke')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (3, N'Enteric Fever')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (4, N'Pneumonia')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (5, N'Anemia')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (6, N'Alcoholic Liver Disease')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (7, N'Jaundice')
GO
INSERT [dbo].[DiseaseType] ([DieseaseID], [DieseaseName]) VALUES (8, N'Maleria')
GO
SET IDENTITY_INSERT [dbo].[DiseaseType] OFF
GO

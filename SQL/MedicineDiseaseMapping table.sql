USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblMedicineDiseaseMapping]    Script Date: 3/4/2025 5:52:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineDiseaseMapping](
	[MedicineDiseaseMappingID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[MedicineTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDiseaseMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] ON 
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (1, 1, 2)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (2, 2, 4)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (3, 4, 6)
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] OFF
GO
ALTER TABLE [dbo].[TblMedicineDiseaseMapping]  WITH CHECK ADD FOREIGN KEY([DieseaseTypeID])
REFERENCES [dbo].[DiseaseType] ([DieseaseID])
GO
ALTER TABLE [dbo].[TblMedicineDiseaseMapping]  WITH CHECK ADD FOREIGN KEY([MedicineTypeID])
REFERENCES [dbo].[TblMedicineType] ([MedicineTypeID])
GO

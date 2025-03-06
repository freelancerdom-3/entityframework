USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblTreatmentDetails]    Script Date: 3/6/2025 11:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTreatmentDetails](
	[TreatmentDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[PatientId] [int] NULL,
	[TreatmentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TreatmentDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] ON 
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (1, 1, 3, CAST(N'2025-03-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (2, 2, 4, CAST(N'2025-03-09T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] OFF
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([DieseaseTypeID])
REFERENCES [dbo].[TblDiseaseType] ([DieseaseTypeID])
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO

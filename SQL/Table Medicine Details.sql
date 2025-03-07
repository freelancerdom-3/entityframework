USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblMedicineDetails]    Script Date: 3/7/2025 9:40:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineDetails](
	[MedicineDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentDetailsId] [int] NULL,
	[MedicineTypeID] [int] NULL,
	[Dosage] [int] NOT NULL,
	[Frequency] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Instruction] [varchar](100) NULL,
	[IssueDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblMedicineDetails]  WITH CHECK ADD FOREIGN KEY([MedicineTypeID])
REFERENCES [dbo].[TblMedicineType] ([MedicineTypeID])
GO
ALTER TABLE [dbo].[TblMedicineDetails]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO

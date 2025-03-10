USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblBill]    Script Date: 10-03-2025 15:50:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[PaymentMethod] [varchar](50) NOT NULL,
	[BillDate] [date] NOT NULL,
	[TreatmentDetailsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblBill] ON 
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (2, 18, CAST(5000.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-10' AS Date), 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (3, 21, CAST(8000.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-10' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[TblBill] OFF
GO
ALTER TABLE [dbo].[TblBill]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblBill]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO

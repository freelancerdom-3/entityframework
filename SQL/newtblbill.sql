USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblBill]    Script Date: 14-04-2025 12:25:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[PaymentMethod] [varchar](50) NOT NULL,
	[BillDate] [date] NOT NULL,
	[TreatmentDetailsId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblBill] ON 
GO
INSERT [dbo].[TblBill] ([BillId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, CAST(5000.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-09' AS Date), 1, 1, CAST(N'2025-03-11T17:10:47.983' AS DateTime), 2, CAST(N'2025-03-11T17:10:47.983' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(500.00 AS Decimal(10, 2)), N'Cash', CAST(N'2025-03-09' AS Date), 2, 3, CAST(N'2025-03-11T17:12:36.123' AS DateTime), 4, CAST(N'2025-03-11T17:12:36.123' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(500.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-10' AS Date), 3, 5, CAST(N'2025-03-11T17:12:46.933' AS DateTime), 6, CAST(N'2025-03-11T17:12:46.933' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8, 7, CAST(N'2025-03-11T17:12:59.257' AS DateTime), 8, CAST(N'2025-03-11T17:12:59.257' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8, 9, CAST(N'2025-03-11T17:13:19.167' AS DateTime), 10, CAST(N'2025-03-11T17:13:19.167' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblBill] OFF
GO
ALTER TABLE [dbo].[TblBill]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO

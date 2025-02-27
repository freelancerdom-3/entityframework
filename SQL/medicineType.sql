USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblMedicineType]    Script Date: 2/27/2025 10:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineType](
	[MedicineID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] ON 
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (1, N'Dolo 650')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (2, N'Painkillers')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (3, N'Antipyretics')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (4, N'No Medicine')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (5, N'Sobisis')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (6, N'J Fol')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (7, N'MPROL')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (8, N'Metformin')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (9, N'Finerenone')
GO
INSERT [dbo].[TblMedicineType] ([MedicineID], [TypeName]) VALUES (10, N'Beta Blockers')
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] OFF
GO

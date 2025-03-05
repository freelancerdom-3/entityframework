USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblMedicineType]    Script Date: 3/5/2025 3:48:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineType](
	[MedicineTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] ON 
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (1, N'Dolo 650')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (2, N'Painkillers')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (3, N'Antipyretics')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (4, N'Tamsulosin')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (5, N'Sobisis')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (6, N'J Fol')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (7, N'MPROL')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (8, N'Metformin')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (9, N'Finerenone')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (10, N'Beta Blockers')
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName]) VALUES (11, N'Anastrozole')
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] OFF
GO

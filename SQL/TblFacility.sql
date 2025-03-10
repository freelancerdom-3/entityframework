USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblFacility]    Script Date: 3/10/2025 4:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFacility](
	[FacilityID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [varchar](100) NOT NULL,
	[FacilityTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblFacility] ON 
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (1, N'Emergency Services', 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (2, N'Pharmacy', 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (3, N'Ambulance', 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (4, N'Laboratory', 1)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (5, N'Pantry', 1)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (6, N'Blood Bank', 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (7, N'X-Ray & MRI Scan', 1)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID]) VALUES (8, N'Operation Theater', 1)
GO
SET IDENTITY_INSERT [dbo].[TblFacility] OFF
GO
ALTER TABLE [dbo].[TblFacility]  WITH CHECK ADD FOREIGN KEY([FacilityTypeID])
REFERENCES [dbo].[TblFacilityType] ([FacilityTypeID])
GO

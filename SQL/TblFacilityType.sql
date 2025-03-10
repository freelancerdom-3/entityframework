USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblFacilityType]    Script Date: 3/10/2025 4:59:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFacilityType](
	[FacilityTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[FacilityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblFacilityType] ON 
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName]) VALUES (1, N'Room Facility')
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName]) VALUES (2, N'General Facility')
GO
SET IDENTITY_INSERT [dbo].[TblFacilityType] OFF
GO

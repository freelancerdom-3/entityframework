USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblPatient]    Script Date: 06-03-2025 21:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPatient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](100) NULL,
	[Blood_Group] [varchar](5) NULL,
	[Emergency_Contact] [varchar](10) NULL,
	[Medical_History] [varchar](20) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblPatient] ON 
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (3, CAST(N'2025-03-06' AS Date), N'M', N'stringfrf', N'A', N'4567891235', N'string', 20)
GO
SET IDENTITY_INSERT [dbo].[TblPatient] OFF
GO
ALTER TABLE [dbo].[TblPatient]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO

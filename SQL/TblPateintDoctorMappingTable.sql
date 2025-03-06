USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblPateintDoctormapping]    Script Date: 3/6/2025 11:44:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPateintDoctormapping](
	[PateintDoctormappingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PatientId] [int] NULL,
	[TreatmentDetailsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PateintDoctormappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] ON 
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId]) VALUES (4, 3, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] OFF
GO
ALTER TABLE [dbo].[TblPateintDoctormapping]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO
ALTER TABLE [dbo].[TblPateintDoctormapping]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO
ALTER TABLE [dbo].[TblPateintDoctormapping]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO

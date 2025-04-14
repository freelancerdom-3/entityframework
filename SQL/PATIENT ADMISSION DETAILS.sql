USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblPatientAdmitionDetails]    Script Date: 14/04/2025 08:25:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPatientAdmitionDetails](
	[PatientAdmitionDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[AdmisionDate] [datetime] NULL,
	[RoomID] [int] NULL,
	[TreatmentDetailsId] [int] NULL,
	[DischargeDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientAdmitionDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] ON 
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, CAST(N'2025-04-10T15:11:00.000' AS DateTime), 1, 1, NULL, 21, CAST(N'2025-04-11T15:12:01.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, CAST(N'2025-04-09T15:12:00.000' AS DateTime), 1, 1, NULL, 21, CAST(N'2025-04-11T15:13:08.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, CAST(N'2025-04-04T15:14:00.000' AS DateTime), 1, 2, NULL, 21, CAST(N'2025-04-11T15:14:53.000' AS DateTime), NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] OFF
GO
ALTER TABLE [dbo].[TblPatientAdmitionDetails]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO
ALTER TABLE [dbo].[TblPatientAdmitionDetails]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO

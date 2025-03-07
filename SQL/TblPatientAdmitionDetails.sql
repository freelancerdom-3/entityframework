USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblPatientAdmitionDetails]    Script Date: 07/03/2025 09:41:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPatientAdmitionDetails](
	[PatientAdmitionDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AdmisionDate] [datetime] NULL,
	[RoomID] [int] NULL,
	[TreatmentDetailsId] [int] NULL,
	[DischargeDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientAdmitionDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoom]    Script Date: 07/03/2025 09:41:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoom](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NULL,
	[RoomTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 07/03/2025 09:41:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Password] [varchar](max) NULL,
	[MobileNumber] [varchar](10) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPatient]    Script Date: 07/03/2025 09:41:33 AM ******/
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
/****** Object:  Table [dbo].[TblTreatmentDetails]    Script Date: 07/03/2025 09:41:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTreatmentDetails](
	[TreatmentDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[PatientId] [int] NULL,
	[TreatmentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TreatmentDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] ON 
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (4, 3, CAST(N'2024-03-07T02:39:27.083' AS DateTime), 2, 4, CAST(N'2025-03-07T02:39:27.083' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (5, 1, CAST(N'2025-03-06T16:08:21.357' AS DateTime), 1, 1, CAST(N'2025-03-06T16:08:21.357' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (6, 1, CAST(N'2025-03-06T16:08:21.357' AS DateTime), 1, 1, CAST(N'2025-03-06T16:08:21.357' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (7, 2, CAST(N'2025-03-02T16:15:49.510' AS DateTime), 2, 3, CAST(N'2025-03-06T16:15:49.510' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (8, 2, CAST(N'2025-03-02T16:15:49.510' AS DateTime), 2, 3, CAST(N'2025-03-06T16:15:49.510' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (9, 2, CAST(N'2025-03-02T16:15:49.510' AS DateTime), 2, 3, CAST(N'2025-03-06T16:15:49.510' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (10, 2, CAST(N'2025-03-06T16:24:19.280' AS DateTime), 3, 4, CAST(N'2025-03-06T16:24:19.280' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (11, 2, CAST(N'2025-03-06T16:24:19.280' AS DateTime), 3, 4, CAST(N'2025-03-06T16:24:19.280' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (12, 4, CAST(N'2025-03-06T16:35:33.077' AS DateTime), 4, 4, CAST(N'2025-03-06T16:35:33.077' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (13, 5, CAST(N'2025-03-06T16:40:48.217' AS DateTime), 1, 7, CAST(N'2025-03-06T16:40:48.217' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (14, 10, CAST(N'2025-03-06T16:40:48.217' AS DateTime), 1, 7, CAST(N'2025-03-06T16:40:48.217' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (18, 12, CAST(N'2025-03-06T16:40:48.217' AS DateTime), 1, 6, CAST(N'2025-03-06T16:40:48.217' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (19, 13, CAST(N'2025-03-06T17:01:32.267' AS DateTime), 3, 6, CAST(N'2025-03-06T17:01:32.267' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (20, 13, CAST(N'2025-03-07T17:01:32.267' AS DateTime), 3, 6, CAST(N'2025-03-06T17:01:32.267' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (21, 5, CAST(N'2025-03-07T02:37:55.747' AS DateTime), 2, 5, CAST(N'2025-03-07T02:37:55.747' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoom] ON 
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (1, 102, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (2, 103, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (3, 104, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (4, 105, 1)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (5, 106, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (6, 107, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (7, 109, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (8, 110, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (9, 201, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (10, 202, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (11, 203, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (12, 204, 3)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID]) VALUES (13, 205, 3)
GO
SET IDENTITY_INSERT [dbo].[TblRoom] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUser] ON 
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (1, N'df', N'arj', N'fgn', N'7645878452', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (2, N'Parth Rethaliya', N'parth123@gmail.com', N'parth@123', N'9658456952', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (3, N'string', N'string', N'string', N'9658456952', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (4, N'vraj patel', N'vraj123@gmail.com', N'vraj@123', N'6352564256', 4)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (5, N'sahil savaj', N'sahil129@gamil.com', N'sahil@123', N'6352563254', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (6, N'jaypal vasveliya', N'jaypal126@gmail.com', N'jaypal@123', N'9658452154', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (7, N'khushi mehta', N'khushi124@gmail.com', N'khushi@123', N'6325485216', 7)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (8, N'mahipat chav', N'mahipat129@gmail.com', N'mahipat@123', N'9658745236', 8)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (9, N'Rahul bar', N'rahul143@gmail.com', N'rahul@123', N'7856952365', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (10, N'Rohit Bavliya', N'rohit123@gmail.com', N'rohit@123', N'9653256347', 8)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (12, N'Hello', N'Hello@gmail.com', N'Hssdei', N'1234567891', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (13, N'stricfgng', N'strifyng', N'strinrfyg', N'7645878452', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (14, N'strivng', N'stringc', N'strixcfng', N'7645878452', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (15, N'string', N'HEY', N'string', N'string', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (16, N'string', N'string1', N'string', N'string', 2)
GO
SET IDENTITY_INSERT [dbo].[TblUser] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatient] ON 
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (1, CAST(N'2025-03-02' AS Date), N'M', N'G.nagar', N'A+', N'9520212154', N'FAVOR', 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (7, CAST(N'2025-02-02' AS Date), N'F', N'ahemdabad', N'B+', N'9520212165', N'FAVOR1', 2)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (8, CAST(N'2025-04-04' AS Date), N'm', N'ahemdabad1', N'm+', N'9520212165', N'1FAVOR1', 3)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (9, CAST(N'2026-02-02' AS Date), N'F', N'1ahemdabad', N'B+', N'9152212165', N'F1AVOR1', 4)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (10, CAST(N'2027-12-22' AS Date), N'F', N'5ahemdabad', N'B+', N'6950212165', N'F9AVOR1', 5)
GO
SET IDENTITY_INSERT [dbo].[TblPatient] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] ON 
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (1, 1, 1, CAST(N'1901-05-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (2, 2, 7, CAST(N'1901-05-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (3, 2, 8, CAST(N'2025-02-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (4, 3, 9, CAST(N'2025-03-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (5, 4, 10, CAST(N'2025-02-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (6, 3, 9, CAST(N'2025-03-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (7, 4, 10, CAST(N'2025-02-10T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] OFF
GO
ALTER TABLE [dbo].[TblPatientAdmitionDetails]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO
ALTER TABLE [dbo].[TblPatientAdmitionDetails]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO
ALTER TABLE [dbo].[TblPatientAdmitionDetails]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblPatient]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO

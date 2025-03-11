USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblBill]    Script Date: 3/11/2025 12:01:14 PM ******/
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
/****** Object:  Table [dbo].[TblDiseaseType]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDiseaseType](
	[DieseaseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DieseaseTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEmployeeDepartmentMapping]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeDepartmentMapping](
	[EmployeeDepartmentMappingID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[HospitalDepartmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeDepartmentMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEmployeeshiftMapping]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeshiftMapping](
	[EmployeeshiftMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeshiftMappingStartingDate] [date] NULL,
	[EmployeeshiftMappingEndingData] [date] NULL,
	[UserId] [int] NULL,
	[ShiftId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeshiftMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblFacility]    Script Date: 3/11/2025 12:01:14 PM ******/
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
/****** Object:  Table [dbo].[TblFacilityType]    Script Date: 3/11/2025 12:01:14 PM ******/
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
/****** Object:  Table [dbo].[TblFeedback]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFeedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NULL,
	[Comments] [varchar](250) NULL,
	[Rating] [int] NULL,
	[Response] [varchar](100) NULL,
	[TreatmentDetailsId] [int] NULL,
	[FeedbackDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbLHospitalDepartment]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbLHospitalDepartment](
	[HospitalDepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalDepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblHospitalType]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalType](
	[HospitalTypeID] [int] IDENTITY(1,1) NOT NULL,
	[HospitalType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineDetails]    Script Date: 3/11/2025 12:01:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineDetails](
	[MedicineDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentDetailsId] [int] NULL,
	[MedicineTypeID] [int] NULL,
	[Dosage] [int] NOT NULL,
	[Frequency] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Instruction] [varchar](100) NULL,
	[IssueDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineDiseaseMapping]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineDiseaseMapping](
	[MedicineDiseaseMappingID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[MedicineTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDiseaseMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineType]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblPateintDoctormapping]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblPatient]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblPatientAdmitionDetails]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblRole]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoom]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblRoomLocations]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomLocations](
	[RoomLocationID] [int] IDENTITY(1,1) NOT NULL,
	[Floornumber] [int] NULL,
	[RoomID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoomType]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoomTypeFacilityMapping]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomTypeFacilityMapping](
	[RoomTypeFacilityMappingID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[FacilityID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeFacilityMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblShift]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblShift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Shiftname] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTreatmentDetails]    Script Date: 3/11/2025 12:01:15 PM ******/
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
/****** Object:  Table [dbo].[TblUser]    Script Date: 3/11/2025 12:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[MobileNumber] [varchar](10) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblBill] ON 
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (1, 1, CAST(5000.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-09' AS Date), 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (2, 2, CAST(500.00 AS Decimal(10, 2)), N'Cash', CAST(N'2025-03-09' AS Date), 2)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (3, 3, CAST(500.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-10' AS Date), 3)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (4, 11, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId]) VALUES (5, 11, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8)
GO
SET IDENTITY_INSERT [dbo].[TblBill] OFF
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] ON 
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (1, N'Fever')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (2, N'Brain Stoke')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (3, N'Enteric Fever')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (4, N'Pneumonia')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (5, N'Anemia')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (6, N'Alcoholic Liver Disease')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (7, N'Jaundice')
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName]) VALUES (8, N'Maleria')
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] ON 
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (1, 13, 1)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (2, 14, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (3, 1, 3)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (4, 5, 3)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (5, 8, 3)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (6, 6, 5)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (7, 4, 7)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID]) VALUES (8, 10, 4)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] ON 
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (1, CAST(N'2025-03-01' AS Date), CAST(N'2025-03-07' AS Date), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (2, CAST(N'2025-03-08' AS Date), CAST(N'2025-03-15' AS Date), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (3, CAST(N'2025-03-16' AS Date), CAST(N'2025-03-23' AS Date), 1, 3)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingData], [UserId], [ShiftId]) VALUES (4, CAST(N'2025-03-24' AS Date), CAST(N'2025-03-30' AS Date), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] OFF
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
SET IDENTITY_INSERT [dbo].[TblFacilityType] ON 
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName]) VALUES (1, N'Room Facility')
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName]) VALUES (2, N'General Facility')
GO
SET IDENTITY_INSERT [dbo].[TblFacilityType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblFeedback] ON 
GO
INSERT [dbo].[TblFeedback] ([FeedbackId], [PatientId], [Comments], [Rating], [Response], [TreatmentDetailsId], [FeedbackDate]) VALUES (1, 1, N'This Hospital treatment is good', 5, N'Thank You so much sir', 1, CAST(N'2025-03-09' AS Date))
GO
INSERT [dbo].[TblFeedback] ([FeedbackId], [PatientId], [Comments], [Rating], [Response], [TreatmentDetailsId], [FeedbackDate]) VALUES (2, 3, N'This Hospital doctor is good', 5, N'Thank You so much sir', 3, CAST(N'2025-03-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TblFeedback] OFF
GO
SET IDENTITY_INSERT [dbo].[TbLHospitalDepartment] ON 
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (1, N'HR Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (2, N'IT Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (3, N'Emergency Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (4, N'Rediological Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (5, N'Reception Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (6, N'Pharmacy Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (7, N'Pediatrics Department')
GO
INSERT [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID], [DepartmentName]) VALUES (8, N'Orthopedic Department')
GO
SET IDENTITY_INSERT [dbo].[TbLHospitalDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] ON 
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (1, N'Multi-Speciality Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (2, N'Semi-Speciality Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (3, N'Neurosurgeon Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (4, N'Childeren Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (5, N'Kidney Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (6, N'Orthopedic Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (7, N'Eye Hospital')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (9, N'string')
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType]) VALUES (10, N'string')
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDetails] ON 
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime]) VALUES (1, 1, 2, 1, N'100gm', N'2days', N'Take After MEAL', CAST(N'2025-03-09T11:57:48.710' AS DateTime))
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime]) VALUES (2, 2, 11, 2, N'200gm', N'1days', N'Heavy Doase', CAST(N'2025-03-10T11:57:48.710' AS DateTime))
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime]) VALUES (3, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime))
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime]) VALUES (4, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] ON 
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (1, 1, 2)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (2, 2, 4)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID]) VALUES (3, 4, 6)
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] OFF
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
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] ON 
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId]) VALUES (1, 4, 1, 1)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId]) VALUES (2, 1, 2, 2)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId]) VALUES (3, 1, 3, 3)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId]) VALUES (4, 1, 11, 8)
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatient] ON 
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (1, CAST(N'1994-02-12' AS Date), N'M', N'Naintara banglows,Ahmedabad', N'O+', N'9624302050', N'fever', 12)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (2, CAST(N'2000-01-21' AS Date), N'M', N'Naiminath flat,Gandhinagar', N'A+', N'9250625082', N'Cold', 15)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (3, CAST(N'1964-03-10' AS Date), N'F', N'Mantra,Dahod', N'A-', N'9252623220', N'Fever', 17)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId]) VALUES (11, CAST(N'2025-03-11' AS Date), N'M', N'Ahmedabad', N'B+', N'5698545896', N'Headack', 20)
GO
SET IDENTITY_INSERT [dbo].[TblPatient] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] ON 
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (1, 12, CAST(N'2025-03-08T11:05:57.220' AS DateTime), 1, 1, CAST(N'2025-03-09T11:05:57.220' AS DateTime))
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate]) VALUES (2, 17, CAST(N'2025-03-09T11:05:57.220' AS DateTime), 2, 3, CAST(N'2025-03-10T11:05:57.220' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRole] ON 
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (1, N'Doctor')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (2, N'Medical Officer')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (3, N'Nurse')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (4, N'Receptionist')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (5, N'Compounder')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (6, N'Security')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (7, N'HR manager')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (8, N'IT specialist')
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName]) VALUES (9, N'Patient')
GO
SET IDENTITY_INSERT [dbo].[TblRole] OFF
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
SET IDENTITY_INSERT [dbo].[TblRoomLocations] ON 
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (2, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (3, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (4, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (5, 1, 1)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (6, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (7, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (8, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (9, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (10, 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (11, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (12, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (13, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (14, 2, 3)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID]) VALUES (15, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[TblRoomLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] ON 
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (1, N'private room')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (2, N'special room')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (3, N'ICU')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (4, N'PICU')
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType]) VALUES (5, N'Super deluxe room')
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] ON 
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID]) VALUES (1, 2, 6)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID]) VALUES (2, 7, 2)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID]) VALUES (3, 5, 8)
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblShift] ON 
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (1, CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Night')
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (2, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Morning ')
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname]) VALUES (3, CAST(N'16:00:00' AS Time), CAST(N'23:59:00' AS Time), N'Aftoornoon')
GO
SET IDENTITY_INSERT [dbo].[TblShift] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] ON 
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (1, 1, 1, CAST(N'2025-03-08T10:23:07.273' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (2, 3, 2, CAST(N'2025-03-10T10:23:07.273' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (3, 8, 3, CAST(N'2025-03-09T10:23:07.273' AS DateTime))
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate]) VALUES (8, 1, 11, CAST(N'2025-03-11T05:01:00.780' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUser] ON 
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (1, N'John Doe', N'johndoe@gmail.com', N'P@ssw0rd123', N'1234567890', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (2, N'Jane Smith', N'janesmith@gmail.com', N'P@ssw0rd456', N'0987654321', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (3, N'Michael Johnson', N'michaeljohnson@gmail.com', N'P@ssw0rd789', N'1122334455', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (4, N'Emily Davis', N'emilydavis@gmail.com', N'P@ssw0rd101', N'6677889900', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (5, N'David Wilson', N'davidwilson@gmail.com', N'P@ssw0rd112', N'9988776655', 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (6, N'Mitesh Simariya', N'mitesh125@gmail.com', N'Mitesh@123', N'9453762110', 4)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (7, N'Khyati Patel', N'patelkhyati52@gmail.com', N'Patel@250', N'9450207766', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (8, N'Vraj Patel', N'vraj224@gamil.com', N'vraj@224', N'9452328756', 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (9, N'Vishal Gami', N'gamivishal@gmail.com', N'gamiv123', N'9457865420', 4)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (10, N'Parth Ratheliya', N'parthesh@gmail.com', N'partha@2323', N'9496948411', 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (11, N'Sahil Savaj', N'sahillion@gmail.com', N'Lion@123', N'9484741020', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (12, N'Naitik Gondaliya', N'naitikgondaliya21@gmail.com', N'NaitikG@123', N'9033342003', 9)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (13, N'Shreya Patel', N'shreyaPatel@gmail.com', N'Spatel@2241', N'9487476737', 7)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (14, N'Stavan Hariyani', N'hariyanistavan52@gmail.com', N'stavan@2434', N'9484537684', 8)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (15, N'Gopal Vyas', N'gopalvyas@gmail.com', N'vyas@22', N'9487536420', 9)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (16, N'Nitin Maru', N'nitinmaru42@gmail.com', N'Nitin@2211', N'9474648484', 6)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (17, N'Naina Patel', N'nainapatel42@gmail.com', N'Naina@123', N'9634853742', 9)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (18, N'Naitik Gondaliya', N'NaitikGondaliya@gmail.com', N'admin@123', N'1234569632', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (19, N'Naitik Gondaliya1', N'NaitikGondaliya1@gmail.com', N'admin@1234', N'1234569632', 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId]) VALUES (20, N'Naitik Gondaliya1', N'NaitikGondaliya12@gmail.com', N'admin@1234', NULL, 9)
GO
SET IDENTITY_INSERT [dbo].[TblUser] OFF
GO
ALTER TABLE [dbo].[TblBill]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblBill]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO
ALTER TABLE [dbo].[TblEmployeeDepartmentMapping]  WITH CHECK ADD FOREIGN KEY([HospitalDepartmentID])
REFERENCES [dbo].[TbLHospitalDepartment] ([HospitalDepartmentID])
GO
ALTER TABLE [dbo].[TblEmployeeDepartmentMapping]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblEmployeeshiftMapping]  WITH CHECK ADD FOREIGN KEY([ShiftId])
REFERENCES [dbo].[TblShift] ([ShiftId])
GO
ALTER TABLE [dbo].[TblEmployeeshiftMapping]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblFacility]  WITH CHECK ADD FOREIGN KEY([FacilityTypeID])
REFERENCES [dbo].[TblFacilityType] ([FacilityTypeID])
GO
ALTER TABLE [dbo].[TblFeedback]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO
ALTER TABLE [dbo].[TblFeedback]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO
ALTER TABLE [dbo].[TblMedicineDetails]  WITH CHECK ADD FOREIGN KEY([MedicineTypeID])
REFERENCES [dbo].[TblMedicineType] ([MedicineTypeID])
GO
ALTER TABLE [dbo].[TblMedicineDetails]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO
ALTER TABLE [dbo].[TblMedicineDiseaseMapping]  WITH CHECK ADD FOREIGN KEY([DieseaseTypeID])
REFERENCES [dbo].[TblDiseaseType] ([DieseaseTypeID])
GO
ALTER TABLE [dbo].[TblMedicineDiseaseMapping]  WITH CHECK ADD FOREIGN KEY([MedicineTypeID])
REFERENCES [dbo].[TblMedicineType] ([MedicineTypeID])
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
ALTER TABLE [dbo].[TblPatient]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblPatient]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
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
ALTER TABLE [dbo].[TblRoom]  WITH CHECK ADD FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[TblRoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[TblRoomLocations]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO
ALTER TABLE [dbo].[TblRoomTypeFacilityMapping]  WITH CHECK ADD FOREIGN KEY([FacilityID])
REFERENCES [dbo].[TblFacility] ([FacilityID])
GO
ALTER TABLE [dbo].[TblRoomTypeFacilityMapping]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([DieseaseTypeID])
REFERENCES [dbo].[TblDiseaseType] ([DieseaseTypeID])
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO
ALTER TABLE [dbo].[TblTreatmentDetails]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO
ALTER TABLE [dbo].[TblUser]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[TblRole] ([RoleId])
GO

USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblBill]    Script Date: 4/4/2025 10:20:56 AM ******/
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
/****** Object:  Table [dbo].[TblDiseaseType]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDiseaseType](
	[DieseaseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseName] [varchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DieseaseTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEmployeeDepartmentMapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeDepartmentMapping](
	[EmployeeDepartmentMappingID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[HospitalDepartmentID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeDepartmentMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEmployeeshiftMapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeshiftMapping](
	[EmployeeshiftMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeshiftMappingStartingDate] [date] NULL,
	[EmployeeshiftMappingEndingDate] [date] NULL,
	[UserId] [int] NULL,
	[ShiftId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeshiftMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblFacility]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFacility](
	[FacilityID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [varchar](100) NOT NULL,
	[FacilityTypeID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblFacilityType]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFacilityType](
	[FacilityTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FacilityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblFeedback]    Script Date: 4/4/2025 10:20:57 AM ******/
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
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblHospitalDepartment]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalDepartment](
	[HospitalDepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalDepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblHospitalType]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHospitalType](
	[HospitalTypeID] [int] IDENTITY(1,1) NOT NULL,
	[HospitalType] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HospitalTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineDetails]    Script Date: 4/4/2025 10:20:57 AM ******/
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
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineDiseaseMapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineDiseaseMapping](
	[MedicineDiseaseMappingID] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[MedicineTypeID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDiseaseMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineType]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineType](
	[MedicineTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMenu]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMenu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[ParentMenuID] [int] NULL,
	[MenuName] [varchar](50) NULL,
	[Paths] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMenuRoleMapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMenuRoleMapping](
	[MenuRoleMappingID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[MenuID] [int] NULL,
	[IsAdd] [bit] NULL,
	[IsEdit] [bit] NULL,
	[IsDelete] [bit] NULL,
	[IsView] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuRoleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPateintDoctormapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPateintDoctormapping](
	[PateintDoctormappingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PatientId] [int] NULL,
	[TreatmentDetailsId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PateintDoctormappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPatient]    Script Date: 4/4/2025 10:20:57 AM ******/
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
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPatientAdmitionDetails]    Script Date: 4/4/2025 10:20:57 AM ******/
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
/****** Object:  Table [dbo].[TblRole]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoom]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoom](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NULL,
	[RoomTypeID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoomLocations]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomLocations](
	[RoomLocationID] [int] IDENTITY(1,1) NOT NULL,
	[Floornumber] [int] NULL,
	[RoomID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoomType]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomType] [varchar](255) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRoomTypeFacilityMapping]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoomTypeFacilityMapping](
	[RoomTypeFacilityMappingID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[FacilityID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeFacilityMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblShift]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblShift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Shiftname] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTreatmentDetails]    Script Date: 4/4/2025 10:20:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTreatmentDetails](
	[TreatmentDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[DieseaseTypeID] [int] NULL,
	[PatientId] [int] NULL,
	[TreatmentDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
	[TreatmentCode] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TreatmentDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 4/4/2025 10:20:57 AM ******/
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
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[VersionNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblBill] ON 
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, CAST(5000.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-09' AS Date), 1, 1, CAST(N'2025-03-11T17:10:47.983' AS DateTime), 2, CAST(N'2025-03-11T17:10:47.983' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 2, CAST(500.00 AS Decimal(10, 2)), N'Cash', CAST(N'2025-03-09' AS Date), 2, 3, CAST(N'2025-03-11T17:12:36.123' AS DateTime), 4, CAST(N'2025-03-11T17:12:36.123' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 3, CAST(500.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-10' AS Date), 3, 5, CAST(N'2025-03-11T17:12:46.933' AS DateTime), 6, CAST(N'2025-03-11T17:12:46.933' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 11, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8, 7, CAST(N'2025-03-11T17:12:59.257' AS DateTime), 8, CAST(N'2025-03-11T17:12:59.257' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblBill] ([BillId], [PatientId], [TotalAmount], [PaymentMethod], [BillDate], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 11, CAST(200.00 AS Decimal(10, 2)), N'UPI', CAST(N'2025-03-11' AS Date), 8, 9, CAST(N'2025-03-11T17:13:19.167' AS DateTime), 10, CAST(N'2025-03-11T17:13:19.167' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblBill] OFF
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] ON 
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Fever', 1, CAST(N'2025-03-11T17:18:08.133' AS DateTime), 2, CAST(N'2025-03-11T17:18:08.133' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Brain Stoke', 3, CAST(N'2025-03-11T17:18:38.513' AS DateTime), NULL, NULL, 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Enteric Fever', 4, CAST(N'2025-03-11T17:19:53.247' AS DateTime), 5, CAST(N'2025-03-11T17:19:53.247' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Pneumonia', 6, CAST(N'2025-03-11T17:20:07.170' AS DateTime), 7, CAST(N'2025-03-11T17:20:07.170' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Anemia', 8, CAST(N'2025-03-11T17:20:49.250' AS DateTime), NULL, NULL, 0, 1)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Alcoholic Liver Disease', 15, CAST(N'2025-03-11T17:22:40.470' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Jaundice', 11, CAST(N'2025-03-11T17:21:40.243' AS DateTime), 12, CAST(N'2025-03-11T17:21:40.243' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Maleria', 13, CAST(N'2025-03-11T17:21:55.230' AS DateTime), 14, CAST(N'2025-03-11T17:21:55.230' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblDiseaseType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] ON 
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 13, 1, 1, CAST(N'2025-03-11T17:23:50.960' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 14, 2, 2, CAST(N'2025-03-11T17:24:29.440' AS DateTime), 3, CAST(N'2025-03-11T17:24:29.440' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 1, 3, 14, CAST(N'2025-03-11T17:25:57.173' AS DateTime), 15, CAST(N'2025-03-11T17:25:57.173' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 5, 3, 4, CAST(N'2025-03-11T17:24:43.703' AS DateTime), 5, CAST(N'2025-03-11T17:24:43.703' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 8, 3, 6, CAST(N'2025-03-11T17:24:58.080' AS DateTime), 7, CAST(N'2025-03-11T17:24:58.080' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 6, 5, 8, CAST(N'2025-03-11T17:25:08.123' AS DateTime), 9, CAST(N'2025-03-11T17:25:08.123' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeDepartmentMapping] ([EmployeeDepartmentMappingID], [UserId], [HospitalDepartmentID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 10, 4, 12, CAST(N'2025-03-11T17:25:34.210' AS DateTime), 13, CAST(N'2025-03-11T17:25:34.210' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeDepartmentMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] ON 
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, CAST(N'2025-03-01' AS Date), CAST(N'2025-03-07' AS Date), 1, 1, 1, CAST(N'2025-03-11T17:27:01.750' AS DateTime), 2, CAST(N'2025-03-11T17:27:01.750' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(N'2025-03-08' AS Date), CAST(N'2025-03-15' AS Date), 1, 2, 3, CAST(N'2025-03-11T17:27:26.867' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(N'2025-03-16' AS Date), CAST(N'2025-03-23' AS Date), 1, 3, 4, CAST(N'2025-03-11T17:27:45.360' AS DateTime), 5, CAST(N'2025-03-11T17:27:45.360' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, CAST(N'2025-03-24' AS Date), CAST(N'2025-03-30' AS Date), 1, 1, 6, CAST(N'2025-03-11T17:27:57.977' AS DateTime), 7, CAST(N'2025-03-11T17:27:57.977' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblEmployeeshiftMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblFacility] ON 
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Emergency Services', 2, 1, CAST(N'2025-03-11T17:32:37.800' AS DateTime), 2, CAST(N'2025-03-11T17:32:37.800' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Pharmacy', 2, 3, CAST(N'2025-03-11T17:32:46.067' AS DateTime), 4, CAST(N'2025-03-11T17:32:46.067' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Ambulance', 2, 5, CAST(N'2025-03-11T17:32:56.667' AS DateTime), 6, CAST(N'2025-03-11T17:32:56.667' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Laboratory', 1, 7, CAST(N'2025-03-11T17:33:09.040' AS DateTime), 8, CAST(N'2025-03-11T17:33:09.040' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Pantry', 1, 15, CAST(N'2025-03-11T17:34:07.327' AS DateTime), 16, CAST(N'2025-03-11T17:34:07.327' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Blood Bank', 2, 9, CAST(N'2025-03-11T17:33:21.133' AS DateTime), 10, CAST(N'2025-03-11T17:33:21.133' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'X-Ray & MRI Scan', 1, 11, CAST(N'2025-03-11T17:33:30.427' AS DateTime), 12, CAST(N'2025-03-11T17:33:30.427' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Operation Theater', 1, 13, CAST(N'2025-03-11T17:33:41.117' AS DateTime), 14, CAST(N'2025-03-11T17:33:41.117' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, N'Emergency Room', 2, 8, CAST(N'2025-03-17T11:25:00.033' AS DateTime), 0, CAST(N'2025-03-17T11:25:00.033' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblFacility] ([FacilityID], [FacilityName], [FacilityTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'Emergency Rooms1', 2, 20, CAST(N'2025-03-17T11:25:00.033' AS DateTime), 20, CAST(N'2025-03-17T12:23:46.080' AS DateTime), 1, 4)
GO
SET IDENTITY_INSERT [dbo].[TblFacility] OFF
GO
SET IDENTITY_INSERT [dbo].[TblFacilityType] ON 
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Room Facility', 1, CAST(N'2025-03-11T17:34:59.260' AS DateTime), 2, CAST(N'2025-03-11T17:34:59.260' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblFacilityType] ([FacilityTypeID], [FacilityName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'General Facility', 3, CAST(N'2025-03-11T17:35:19.517' AS DateTime), NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[TblFacilityType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblFeedback] ON 
GO
INSERT [dbo].[TblFeedback] ([FeedbackId], [PatientId], [Comments], [Rating], [Response], [TreatmentDetailsId], [FeedbackDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, N'This Hospital treatment is good', 5, N'Thank You so much sir', 1, CAST(N'2025-03-09' AS Date), 1, CAST(N'2025-03-11T17:36:28.043' AS DateTime), NULL, NULL, 0, 1)
GO
INSERT [dbo].[TblFeedback] ([FeedbackId], [PatientId], [Comments], [Rating], [Response], [TreatmentDetailsId], [FeedbackDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 3, N'This Hospital doctor is good', 5, N'Thank You so much sir', 3, CAST(N'2025-03-10' AS Date), 2, CAST(N'2025-03-11T17:36:46.797' AS DateTime), 3, CAST(N'2025-03-11T17:36:46.797' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblFeedback] OFF
GO
SET IDENTITY_INSERT [dbo].[TblHospitalDepartment] ON 
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'HR Department', 1, CAST(N'2025-03-11T17:40:03.620' AS DateTime), 2, CAST(N'2025-03-11T17:40:03.620' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'IT Department', 3, CAST(N'2025-03-11T17:40:28.130' AS DateTime), 4, CAST(N'2025-03-11T17:40:28.130' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Emergency Department', 5, CAST(N'2025-03-11T17:40:38.947' AS DateTime), 6, CAST(N'2025-03-11T17:40:38.947' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Rediological Department', 7, CAST(N'2025-03-11T17:40:52.957' AS DateTime), 8, CAST(N'2025-03-11T17:40:52.957' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Reception Department', 9, CAST(N'2025-03-11T17:41:04.710' AS DateTime), 10, CAST(N'2025-03-11T17:41:04.710' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Pharmacy Department', 11, CAST(N'2025-03-11T17:41:14.077' AS DateTime), 12, CAST(N'2025-03-11T17:41:14.077' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Pediatrics Department', 13, CAST(N'2025-03-11T17:41:24.987' AS DateTime), 14, CAST(N'2025-03-11T17:41:24.987' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Orthopedic Department', 15, CAST(N'2025-03-11T17:41:34.910' AS DateTime), 16, CAST(N'2025-03-11T17:41:34.910' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, N'', NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblHospitalDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] ON 
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Multi-Speciality Hospital', 1, CAST(N'2025-03-12T14:22:43.580' AS DateTime), 2, CAST(N'2025-03-12T14:22:43.580' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Semi-Speciality Hospital', 3, CAST(N'2025-03-12T14:23:08.287' AS DateTime), 4, CAST(N'2025-03-12T14:23:08.287' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Neurosurgeon Hospital', 5, CAST(N'2025-03-12T14:23:20.023' AS DateTime), 6, CAST(N'2025-03-12T14:23:20.023' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Childeren Hospital', 7, CAST(N'2025-03-12T14:23:30.153' AS DateTime), 8, CAST(N'2025-03-12T14:23:30.153' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Kidney Hospital', 9, CAST(N'2025-03-12T14:23:55.410' AS DateTime), 10, CAST(N'2025-03-12T14:23:55.410' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Orthopedic Hospital', 11, CAST(N'2025-03-12T14:24:21.677' AS DateTime), 12, CAST(N'2025-03-12T14:24:21.677' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Eye Hospital', 13, CAST(N'2025-03-12T14:24:31.123' AS DateTime), 14, CAST(N'2025-03-12T14:24:31.123' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'hyy', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, N'nueoro', NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDetails] ON 
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 2, 1, N'100gm', N'2days', N'Take After MEAL', CAST(N'2025-03-09T11:57:48.710' AS DateTime), 1, CAST(N'2025-03-11T17:46:57.290' AS DateTime), 2, CAST(N'2025-03-11T17:46:57.290' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 2, 11, 2, N'200gm', N'1days', N'Heavy Doase', CAST(N'2025-03-10T11:57:48.710' AS DateTime), 3, CAST(N'2025-03-11T17:47:05.793' AS DateTime), 4, CAST(N'2025-03-11T17:47:05.793' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime), 5, CAST(N'2025-03-11T17:47:13.827' AS DateTime), 6, CAST(N'2025-03-11T17:47:13.827' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime), 7, CAST(N'2025-03-11T17:47:24.460' AS DateTime), 8, CAST(N'2025-03-11T17:47:24.460' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] ON 
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 2, 1, CAST(N'2025-03-11T17:48:32.933' AS DateTime), 2, CAST(N'2025-03-11T17:48:32.933' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 2, 4, 3, CAST(N'2025-03-11T17:48:41.823' AS DateTime), 4, CAST(N'2025-03-11T17:48:41.823' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineDiseaseMapping] ([MedicineDiseaseMappingID], [DieseaseTypeID], [MedicineTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 4, 6, 5, CAST(N'2025-03-11T17:48:52.640' AS DateTime), 6, CAST(N'2025-03-11T17:48:52.640' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDiseaseMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] ON 
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Dolo 650', 1, CAST(N'2025-03-12T14:20:37.860' AS DateTime), 2, CAST(N'2025-03-12T14:20:37.860' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Painkillers', 3, CAST(N'2025-03-11T17:50:12.217' AS DateTime), 4, CAST(N'2025-03-11T17:50:12.217' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Antipyretics', 5, CAST(N'2025-03-11T17:50:22.480' AS DateTime), 6, CAST(N'2025-03-11T17:50:22.480' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Tamsulosin', 7, CAST(N'2025-03-11T17:50:34.703' AS DateTime), 8, CAST(N'2025-03-11T17:50:34.703' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Sobisis', 9, CAST(N'2025-03-11T17:50:56.137' AS DateTime), 10, CAST(N'2025-03-11T17:50:56.137' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'J Fol', 11, CAST(N'2025-03-11T17:51:07.797' AS DateTime), 12, CAST(N'2025-03-11T17:51:07.797' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'MPROL', 13, CAST(N'2025-03-11T17:51:21.467' AS DateTime), 14, CAST(N'2025-03-11T17:51:21.467' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Metformin', 15, CAST(N'2025-03-11T17:51:32.063' AS DateTime), 16, CAST(N'2025-03-11T17:51:32.063' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, N'Finerenone', 17, CAST(N'2025-03-11T17:51:41.550' AS DateTime), 18, CAST(N'2025-03-11T17:51:41.550' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, N'Beta Blockers', 19, CAST(N'2025-03-11T17:51:55.510' AS DateTime), 20, CAST(N'2025-03-11T17:51:55.510' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'Anastrozole', 21, CAST(N'2025-03-11T17:52:07.910' AS DateTime), 22, CAST(N'2025-03-11T17:52:07.910' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblMedicineType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMenu] ON 
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, NULL, N'Master', NULL, NULL, 1, CAST(N'2025-03-18T15:26:19.767' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, NULL, N'Settings', NULL, NULL, 1, CAST(N'2025-03-18T15:26:19.767' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, NULL, N'Patients', NULL, NULL, 1, CAST(N'2025-03-18T15:26:19.767' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, NULL, N'Admin', NULL, NULL, 1, CAST(N'2025-03-18T15:26:19.767' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 1, N'Users', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 1, N'HospitalType', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 1, N'HospitalDepartment', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 1, N'Role', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 1, N'Shift', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 1, N'DiseaseType', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, 1, N'MedicineType', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, 1, N'RoomType', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, 1, N'FacilityType', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, 2, N'Employeeshift', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, 2, N'Room', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, 2, N'RoomLocations', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, 2, N'RoomFacility', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, 2, N'EmployeeDepartment', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, 3, N'PatientData', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, 3, N'TreatmentDetails', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, 3, N'MedicineDetails', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, 3, N'AdmissionDetails', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, 4, N'Billing', NULL, NULL, 1, CAST(N'2025-03-18T15:50:25.140' AS DateTime), NULL, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMenuRoleMapping] ON 
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2025-03-24T14:58:39.670' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 1, 2, 1, 1, 1, 1, 1, CAST(N'2025-03-24T14:59:58.367' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 1, 3, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:13.767' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 1, 4, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:17.340' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 1, 6, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:26.343' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 1, 7, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:51.033' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 1, 8, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:56.023' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 1, 9, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:00:58.370' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 1, 10, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:01.913' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 1, 11, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:06.377' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, 1, 12, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:08.880' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, 1, 13, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:11.330' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, 1, 14, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:12.993' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, 1, 15, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:14.520' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, 1, 16, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:16.950' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, 1, 17, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:18.780' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, 1, 18, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:21.023' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, 1, 19, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:23.383' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, 1, 20, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:27.640' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, 1, 21, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:30.967' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, 1, 22, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:34.120' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, 1, 23, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:39.133' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, 1, 24, 1, 1, 1, 1, 1, CAST(N'2025-03-24T15:01:40.803' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, 2, 1, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:11:53.210' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, 2, 2, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:08:36.523' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, 2, 3, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:12:45.463' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, 2, 4, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:12:50.077' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (30, 2, 6, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:12:56.620' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (31, 2, 7, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:12:58.793' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (32, 2, 8, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:06.133' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (33, 2, 9, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:09.040' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (34, 2, 10, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:13.470' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (35, 2, 11, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:17.347' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (36, 2, 12, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:21.710' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (37, 2, 13, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:24.110' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (38, 2, 14, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:27.560' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (39, 2, 15, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:29.740' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (40, 2, 16, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:32.157' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (41, 2, 17, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:34.053' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (42, 2, 18, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:39.840' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (43, 2, 19, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:41.900' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (44, 2, 20, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:13:46.773' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (45, 2, 21, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:14:10.037' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (46, 2, 22, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:14:12.537' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (47, 2, 23, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:14:15.890' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (48, 2, 24, 0, 0, 0, 1, 1, CAST(N'2025-03-24T15:14:17.980' AS DateTime), NULL, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblMenuRoleMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] ON 
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 1, 2, 2, 3, CAST(N'2025-03-11T17:56:17.500' AS DateTime), 4, CAST(N'2025-03-11T17:56:17.500' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 1, 3, 3, 5, CAST(N'2025-03-11T17:56:24.620' AS DateTime), 6, CAST(N'2025-03-11T17:56:24.620' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatient] ON 
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, CAST(N'1994-02-12' AS Date), N'M', N'Naintara banglows,Ahmedabad', N'O+', N'9624302050', N'fever', 12, 1, CAST(N'2025-03-11T17:57:45.067' AS DateTime), 2, CAST(N'2025-03-11T17:57:45.067' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(N'2000-01-21' AS Date), N'M', N'Naiminath flat,Gandhinagar', N'A+', N'9250625082', N'Cold', 15, 3, CAST(N'2025-03-11T17:57:53.713' AS DateTime), 4, CAST(N'2025-03-11T17:57:53.713' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(N'1964-03-10' AS Date), N'F', N'Mantra,Dahod', N'A-', N'9252623220', N'Fever', 17, 5, CAST(N'2025-03-11T17:58:04.580' AS DateTime), 6, CAST(N'2025-03-11T17:58:04.580' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, CAST(N'2025-03-11' AS Date), N'M', N'Ahmedabad', N'B+', N'5698545896', N'Headack', 20, 7, CAST(N'2025-03-11T17:58:33.263' AS DateTime), 8, CAST(N'2025-03-11T17:58:33.263' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblPatient] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] ON 
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 12, CAST(N'2025-03-08T11:05:57.220' AS DateTime), 1, 1, CAST(N'2025-03-09T11:05:57.220' AS DateTime), 1, CAST(N'2025-03-11T17:59:22.480' AS DateTime), 2, CAST(N'2025-03-11T17:59:22.480' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [UserId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 17, CAST(N'2025-03-09T11:05:57.220' AS DateTime), 2, 3, CAST(N'2025-03-10T11:05:57.220' AS DateTime), 3, CAST(N'2025-03-11T17:59:39.680' AS DateTime), 4, CAST(N'2025-03-11T17:59:39.680' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRole] ON 
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'admin', 1, CAST(N'2025-03-11T18:00:49.510' AS DateTime), 1, CAST(N'2025-04-02T16:04:59.773' AS DateTime), 1, 18)
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Patient', 3, CAST(N'2025-03-11T18:00:39.857' AS DateTime), 1, CAST(N'2025-04-02T13:17:19.593' AS DateTime), 1, 9)
GO
SET IDENTITY_INSERT [dbo].[TblRole] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoom] ON 
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 102, 1, 1, CAST(N'2025-03-11T18:03:47.620' AS DateTime), 2, CAST(N'2025-03-11T18:03:47.620' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 103, 1, 3, CAST(N'2025-03-11T18:03:56.567' AS DateTime), 4, CAST(N'2025-03-11T18:03:56.567' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 104, 1, 5, CAST(N'2025-03-11T18:04:04.213' AS DateTime), 6, CAST(N'2025-03-11T18:04:04.213' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 105, 1, 7, CAST(N'2025-03-11T18:04:13.187' AS DateTime), 8, CAST(N'2025-03-11T18:04:13.187' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 106, 2, 9, CAST(N'2025-03-11T18:04:26.150' AS DateTime), 10, CAST(N'2025-03-11T18:04:26.150' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 107, 2, 11, CAST(N'2025-03-11T18:04:39.710' AS DateTime), 12, CAST(N'2025-03-11T18:04:39.710' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 109, 2, 13, CAST(N'2025-03-11T18:04:49.163' AS DateTime), 14, CAST(N'2025-03-11T18:04:49.163' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 110, 2, 15, CAST(N'2025-03-11T18:04:58.667' AS DateTime), 16, CAST(N'2025-03-11T18:04:58.667' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 201, 3, 17, CAST(N'2025-03-11T18:05:06.897' AS DateTime), 18, CAST(N'2025-03-11T18:05:06.897' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 202, 3, 19, CAST(N'2025-03-11T18:05:16.620' AS DateTime), 20, CAST(N'2025-03-11T18:05:16.620' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 203, 3, 21, CAST(N'2025-03-11T18:05:26.240' AS DateTime), 22, CAST(N'2025-03-11T18:05:26.240' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, 204, 3, 23, CAST(N'2025-03-11T18:05:34.687' AS DateTime), 24, CAST(N'2025-03-11T18:05:34.687' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoom] ([RoomID], [RoomNumber], [RoomTypeID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, 205, 3, 25, CAST(N'2025-03-11T18:05:41.820' AS DateTime), 26, CAST(N'2025-03-11T18:05:41.820' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblRoom] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomLocations] ON 
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 1, 1, CAST(N'2025-03-11T18:08:23.647' AS DateTime), 2, CAST(N'2025-03-11T18:08:23.647' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 1, 1, 3, CAST(N'2025-03-11T18:08:35.247' AS DateTime), 4, CAST(N'2025-03-11T18:08:35.247' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 1, 1, 5, CAST(N'2025-03-11T18:11:02.530' AS DateTime), 6, CAST(N'2025-03-11T18:11:02.530' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 1, 1, 7, CAST(N'2025-03-11T18:11:15.267' AS DateTime), 8, CAST(N'2025-03-11T18:11:15.267' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 1, 2, 9, CAST(N'2025-03-11T18:11:54.820' AS DateTime), 10, CAST(N'2025-03-11T18:11:54.820' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 1, 2, 11, CAST(N'2025-03-11T18:12:09.880' AS DateTime), 12, CAST(N'2025-03-11T18:12:09.880' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 1, 2, 13, CAST(N'2025-03-11T18:12:20.830' AS DateTime), 14, CAST(N'2025-03-11T18:12:20.830' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 1, 2, 15, CAST(N'2025-03-11T18:12:33.640' AS DateTime), 16, CAST(N'2025-03-11T18:12:33.640' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomLocations] ([RoomLocationID], [Floornumber], [RoomID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 2, 3, 17, CAST(N'2025-03-11T18:12:45.420' AS DateTime), 18, CAST(N'2025-03-11T18:12:45.420' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblRoomLocations] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] ON 
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'private room', 1, CAST(N'2025-03-11T18:06:42.767' AS DateTime), 2, CAST(N'2025-03-11T18:06:42.767' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'special room', 3, CAST(N'2025-03-11T18:06:55.087' AS DateTime), 4, CAST(N'2025-03-11T18:06:55.087' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'ICU', 5, CAST(N'2025-03-11T18:07:04.473' AS DateTime), 6, CAST(N'2025-03-11T18:07:04.473' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'PICU', 7, CAST(N'2025-03-11T18:07:13.177' AS DateTime), 8, CAST(N'2025-03-11T18:07:13.177' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Super deluxe room', 9, CAST(N'2025-03-11T18:07:23.637' AS DateTime), 10, CAST(N'2025-03-11T18:07:23.637' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'supar ac', NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] ON 
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 2, 6, 1, CAST(N'2025-03-11T18:13:53.607' AS DateTime), 2, CAST(N'2025-03-11T18:14:41.743' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 7, 2, 3, CAST(N'2025-03-11T18:14:15.087' AS DateTime), 4, CAST(N'2025-03-11T18:14:15.087' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 5, 8, 5, CAST(N'2025-03-11T18:15:07.113' AS DateTime), 6, CAST(N'2025-03-11T18:15:07.113' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblShift] ON 
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Night', 1, CAST(N'2025-03-11T18:15:55.710' AS DateTime), 2, CAST(N'2025-03-11T18:15:55.710' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Morning ', 3, CAST(N'2025-03-11T18:16:22.193' AS DateTime), 4, CAST(N'2025-03-11T18:16:22.193' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(N'16:00:00' AS Time), CAST(N'23:59:00' AS Time), N'Aftoornoon', 5, CAST(N'2025-03-11T18:16:28.920' AS DateTime), 6, CAST(N'2025-03-11T18:16:28.920' AS DateTime), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[TblShift] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] ON 
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (1, 1, 1, CAST(N'2025-03-08T10:23:07.273' AS DateTime), 1, CAST(N'2025-03-11T18:17:09.520' AS DateTime), 2, CAST(N'2025-03-11T18:17:09.520' AS DateTime), 1, 2, N'T0001')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (2, 3, 2, CAST(N'2025-03-10T10:23:07.273' AS DateTime), 3, CAST(N'2025-03-11T18:17:21.813' AS DateTime), 4, CAST(N'2025-03-11T18:17:21.813' AS DateTime), 1, 2, N'T0002')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (3, 8, 3, CAST(N'2025-03-09T10:23:07.273' AS DateTime), 5, CAST(N'2025-03-11T18:17:54.740' AS DateTime), NULL, NULL, 0, 1, N'T0003')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (8, 1, 11, CAST(N'2025-03-11T05:01:00.780' AS DateTime), 6, CAST(N'2025-03-11T18:18:34.227' AS DateTime), 7, CAST(N'2025-03-11T18:18:34.227' AS DateTime), 1, 2, N'T0008')
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUser] ON 
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'John Doe', N'johndoe@gmail.com', N'P@ssw0rd123', N'1234567890', 1, 1, CAST(N'2025-03-11T18:19:32.833' AS DateTime), 2, CAST(N'2025-03-11T18:19:32.833' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Jane Smith', N'janesmith@gmail.com', N'P@ssw0rd456', N'0987654321', 2, 3, CAST(N'2025-03-11T18:22:34.177' AS DateTime), 4, CAST(N'2025-03-11T18:22:34.177' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Michael Johnson', N'michaeljohnson@gmail.com', N'P@ssw0rd789', N'1122334455', 2, 5, CAST(N'2025-03-11T18:22:44.757' AS DateTime), 6, CAST(N'2025-03-11T18:22:44.757' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'David Wilson', N'davidwilson@gmail.com', N'P@ssw0rd112', N'9988776655', 2, 9, CAST(N'2025-03-11T18:23:05.903' AS DateTime), 10, CAST(N'2025-03-11T18:23:05.903' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Mitesh Simariya', N'mitesh125@gmail.com', N'Mitesh@123', N'9453762110', 2, 11, CAST(N'2025-03-11T18:23:15.547' AS DateTime), 12, CAST(N'2025-03-11T18:23:15.547' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Khyati Patel', N'patelkhyati52@gmail.com', N'Patel@250', N'9450207766', 2, 13, CAST(N'2025-03-11T18:23:23.713' AS DateTime), 14, CAST(N'2025-03-11T18:23:23.713' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Vraj Patel', N'vraj224@gamil.com', N'vraj@224', N'9452328756', 2, 15, CAST(N'2025-03-11T18:23:32.503' AS DateTime), 16, CAST(N'2025-03-11T18:23:32.503' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, N'Vishal Gami', N'gamivishal@gmail.com', N'gamiv123', N'9457865420', 2, 17, CAST(N'2025-03-11T18:23:41.097' AS DateTime), 18, CAST(N'2025-03-11T18:23:41.097' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, N'Parth Ratheliya', N'parthesh@gmail.com', N'partha@2323', N'9496948411', 2, 19, CAST(N'2025-03-11T18:23:51.513' AS DateTime), 20, CAST(N'2025-03-11T18:23:51.513' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'Sahil Savaj', N'sahillion@gmail.com', N'Lion@123', N'9484741020', 2, 21, CAST(N'2025-03-11T18:24:02.960' AS DateTime), 22, CAST(N'2025-03-11T18:24:02.960' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, N'Naitik Gondaliya', N'naitikgondaliya21@gmail.com', N'NaitikG@123', N'9033342003', 2, 23, CAST(N'2025-03-11T18:24:42.150' AS DateTime), 24, CAST(N'2025-03-11T18:24:42.150' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, N'Shreya Patel', N'shreyaPatel@gmail.com', N'Spatel@2241', N'9487476737', 2, 25, CAST(N'2025-03-11T18:24:49.613' AS DateTime), 26, CAST(N'2025-03-11T18:24:49.613' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, N'Stavan Hariyani', N'hariyanistavan52@gmail.com', N'stavan@2434', N'9484537684', 2, 27, CAST(N'2025-03-11T18:24:56.417' AS DateTime), 28, CAST(N'2025-03-11T18:24:56.417' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, N'Gopal Vyas', N'gopalvyas@gmail.com', N'vyas@22', N'9487536420', 2, 29, CAST(N'2025-03-11T18:25:08.617' AS DateTime), 30, CAST(N'2025-03-11T18:25:08.617' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, N'Nitin Maru', N'nitinmaru42@gmail.com', N'Nitin@2211', N'9474648484', 2, 31, CAST(N'2025-03-11T18:25:16.473' AS DateTime), 32, CAST(N'2025-03-11T18:25:16.473' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, N'Naina Patel', N'nainapatel42@gmail.com', N'Naina@123', N'9634853742', 2, 33, CAST(N'2025-03-11T18:25:24.840' AS DateTime), 34, CAST(N'2025-03-11T18:25:24.840' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, N'Naitik Gondaliya1', N'NaitikGondaliya12@gmail.com', N'admin@1234', NULL, 2, 39, CAST(N'2025-03-11T18:25:59.140' AS DateTime), 40, CAST(N'2025-03-11T18:25:59.140' AS DateTime), 1, 2)
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
REFERENCES [dbo].[TblHospitalDepartment] ([HospitalDepartmentID])
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
ALTER TABLE [dbo].[TblMenuRoleMapping]  WITH CHECK ADD FOREIGN KEY([MenuID])
REFERENCES [dbo].[TblMenu] ([MenuID])
GO
ALTER TABLE [dbo].[TblMenuRoleMapping]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[TblRole] ([RoleId])
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

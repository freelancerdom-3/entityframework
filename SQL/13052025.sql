USE [master]
GO
/****** Object:  Database [HSMDB]    Script Date: 13/05/2025 11:57:07 AM ******/
CREATE DATABASE [HSMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HSMDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\HSMDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HSMDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\HSMDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HSMDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HSMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HSMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HSMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HSMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HSMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HSMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HSMDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HSMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HSMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HSMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HSMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HSMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HSMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HSMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HSMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HSMDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HSMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HSMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HSMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HSMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HSMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HSMDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HSMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HSMDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HSMDB] SET  MULTI_USER 
GO
ALTER DATABASE [HSMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HSMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HSMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HSMDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HSMDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HSMDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HSMDB', N'ON'
GO
ALTER DATABASE [HSMDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [HSMDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblBill]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblDiseaseType]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblEmployeeDepartmentMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblEmployeeshiftMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblFacility]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblFacilityType]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblFeedback]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblHospitalDepartment]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblHospitalType]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblMedicineDetails]    Script Date: 13/05/2025 11:57:08 AM ******/
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
	[AllotedQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineDiseaseMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblMedicineType]    Script Date: 13/05/2025 11:57:08 AM ******/
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
	[QuantityAvailable] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMenu]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblMenuRoleMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblOTP]    Script Date: 13/05/2025 11:57:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOTP](
	[OtpID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Expiry_time] [datetime] NOT NULL,
	[IsUse] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OtpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPateintDoctormapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblPatient]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblPatientAdmitionDetails]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblRole]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblRoom]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblRoomLocations]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblRoomType]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblRoomTypeFacilityMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblShift]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblTreatmentDetails]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblUser]    Script Date: 13/05/2025 11:57:08 AM ******/
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
/****** Object:  Table [dbo].[TblUserRoleMapping]    Script Date: 13/05/2025 11:57:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRoleMapping](
	[TblUserRoleMappingID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[VersionNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TblUserRoleMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Alcoholic Liver Disease', 15, CAST(N'2025-03-11T17:22:40.470' AS DateTime), 21, CAST(N'2025-04-14T16:05:25.000' AS DateTime), NULL, 3)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Jaundice', 11, CAST(N'2025-03-11T17:21:40.243' AS DateTime), 12, CAST(N'2025-03-11T17:21:40.243' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Maleria12', 13, CAST(N'2025-03-11T17:21:55.230' AS DateTime), 21, CAST(N'2025-04-14T18:55:38.000' AS DateTime), NULL, 3)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, N'123', 21, CAST(N'2025-04-14T18:55:23.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblDiseaseType] ([DieseaseTypeID], [DieseaseName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, N'gtgtggt', 21, CAST(N'2025-04-14T18:56:48.000' AS DateTime), NULL, NULL, NULL, 1)
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
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(N'2025-03-08' AS Date), CAST(N'2025-03-13' AS Date), 1, 1, 3, CAST(N'2025-03-11T17:27:26.867' AS DateTime), 40, CAST(N'2025-04-22T16:40:46.000' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(N'2025-03-16' AS Date), CAST(N'2025-03-23' AS Date), 1, 3, 4, CAST(N'2025-03-11T17:27:45.360' AS DateTime), 5, CAST(N'2025-03-11T17:27:45.360' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, CAST(N'2025-01-15' AS Date), CAST(N'2025-02-15' AS Date), 12, 2, 21, CAST(N'2025-04-15T13:49:57.000' AS DateTime), 21, CAST(N'2025-04-15T14:06:38.000' AS DateTime), NULL, 5)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, CAST(N'2025-04-02' AS Date), CAST(N'2025-04-05' AS Date), 8, 1, 21, CAST(N'2025-04-15T13:50:18.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, CAST(N'2025-04-03' AS Date), CAST(N'2025-04-05' AS Date), 6, 2, 21, CAST(N'2025-04-15T13:50:44.000' AS DateTime), 6, CAST(N'2025-04-15T16:25:55.000' AS DateTime), NULL, 4)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, CAST(N'2025-04-15' AS Date), CAST(N'2025-04-15' AS Date), 12, 2, 21, CAST(N'2025-04-15T13:52:24.000' AS DateTime), 21, CAST(N'2025-04-15T13:55:37.000' AS DateTime), NULL, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, CAST(N'2025-05-01' AS Date), CAST(N'2025-05-10' AS Date), 7, 1, 40, CAST(N'2025-04-22T16:41:06.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, CAST(N'2025-04-01' AS Date), CAST(N'2025-05-01' AS Date), 48, 3, 48, CAST(N'2025-05-01T23:05:31.000' AS DateTime), 0, CAST(N'2025-05-01T17:30:45.617' AS DateTime), 0, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, CAST(N'2025-02-01' AS Date), CAST(N'2025-05-01' AS Date), 46, 2, 48, CAST(N'2025-05-01T23:13:21.000' AS DateTime), 0, CAST(N'2025-05-01T17:41:49.850' AS DateTime), 0, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, CAST(N'2025-01-01' AS Date), CAST(N'2025-05-02' AS Date), 48, 3, 1, CAST(N'2025-05-02T00:15:30.000' AS DateTime), 1, CAST(N'2025-05-02T10:19:38.000' AS DateTime), 0, 2)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, CAST(N'2025-07-02' AS Date), CAST(N'2025-08-02' AS Date), 48, 3, 1, CAST(N'2025-05-02T09:49:27.000' AS DateTime), 0, CAST(N'2025-05-02T04:18:57.080' AS DateTime), 0, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, CAST(N'2025-07-16' AS Date), CAST(N'2025-08-01' AS Date), 48, 2, 1, CAST(N'2025-05-02T09:50:19.000' AS DateTime), 0, CAST(N'2025-05-02T04:18:57.080' AS DateTime), 0, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, CAST(N'2025-07-16' AS Date), CAST(N'2025-08-01' AS Date), 48, 1, 1, CAST(N'2025-05-02T09:50:46.000' AS DateTime), 0, CAST(N'2025-05-02T04:18:57.080' AS DateTime), 0, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, CAST(N'2025-04-02' AS Date), CAST(N'2025-05-02' AS Date), 2, 1, 1, CAST(N'2025-05-02T10:42:35.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, CAST(N'2025-04-02' AS Date), CAST(N'2025-06-02' AS Date), 2, 2, 1, CAST(N'2025-05-02T10:45:06.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, CAST(N'2025-04-20' AS Date), CAST(N'2025-05-02' AS Date), 3, 2, 1, CAST(N'2025-05-02T11:18:13.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, CAST(N'2025-04-20' AS Date), CAST(N'2025-05-03' AS Date), 3, 1, 1, CAST(N'2025-05-02T11:21:29.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, CAST(N'2025-04-20' AS Date), CAST(N'2025-05-02' AS Date), 5, 2, 1, CAST(N'2025-05-02T11:26:15.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblEmployeeshiftMapping] ([EmployeeshiftMappingId], [EmployeeshiftMappingStartingDate], [EmployeeshiftMappingEndingDate], [UserId], [ShiftId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, CAST(N'2025-04-20' AS Date), CAST(N'2025-05-02' AS Date), 6, 2, 1, CAST(N'2025-05-02T11:27:59.000' AS DateTime), 0, CAST(N'2025-05-02T05:11:15.837' AS DateTime), 1, 1)
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
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'HR Department123', 1, CAST(N'2025-03-11T17:40:03.620' AS DateTime), 2, CAST(N'2025-03-11T17:40:03.620' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'IT Department123', 3, CAST(N'2025-03-11T17:40:28.130' AS DateTime), 4, CAST(N'2025-03-11T17:40:28.130' AS DateTime), 1, 3)
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
INSERT [dbo].[TblHospitalDepartment] ([HospitalDepartmentID], [DepartmentName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, N'', NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblHospitalDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] ON 
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'Multi-Speciality Hospital', 1, CAST(N'2025-03-12T14:22:43.580' AS DateTime), 48, CAST(N'2025-04-23T15:07:05.000' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Semi-Speciality Hospital123', 3, CAST(N'2025-03-12T14:23:08.287' AS DateTime), 48, CAST(N'2025-04-23T15:28:01.000' AS DateTime), 1, 6)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Neurosurgeon Hospital12345', 5, CAST(N'2025-03-12T14:23:20.023' AS DateTime), 48, CAST(N'2025-04-23T15:39:57.000' AS DateTime), 1, 4)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'Kidney Hospital', 9, CAST(N'2025-03-12T14:23:55.410' AS DateTime), 48, CAST(N'2025-04-23T15:36:11.000' AS DateTime), 1, 11)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'hyy', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, N'nueoro', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, N'Cancer Hospital', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, N'Cancer', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, N'Geriatric Hospital', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, N'Vishal', NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, N'Vishal Gami', 21, CAST(N'2025-04-09T20:35:32.923' AS DateTime), NULL, CAST(N'2025-04-09T20:50:28.000' AS DateTime), NULL, 2)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, N'Rajesh gami', 21, CAST(N'2025-04-09T20:53:08.463' AS DateTime), 48, CAST(N'2025-04-23T16:10:43.000' AS DateTime), 1, 17)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, N'Childeren Hospital12345', 21, CAST(N'2025-04-09T20:57:20.870' AS DateTime), NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, N'Stvan ', 21, CAST(N'2025-04-09T21:47:30.383' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, N'DhavalGami', 21, CAST(N'2025-04-11T18:00:40.227' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, N'Childeren Hospital12', 21, CAST(N'2025-04-14T16:30:53.790' AS DateTime), 48, CAST(N'2025-04-23T15:17:29.000' AS DateTime), 1, 5)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, N'vishal123', 48, CAST(N'2025-04-24T18:05:50.493' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, N'vrajvasi', 48, CAST(N'2025-04-24T18:10:50.367' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, N'Gami vishal', 48, CAST(N'2025-04-24T18:12:03.613' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, N'stavan', 48, CAST(N'2025-04-24T18:13:33.790' AS DateTime), 48, NULL, 1, 1)
GO
INSERT [dbo].[TblHospitalType] ([HospitalTypeID], [HospitalType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, N'Gami vishal manubhai', 48, CAST(N'2025-04-24T18:17:02.420' AS DateTime), 48, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblHospitalType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineDetails] ON 
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [AllotedQuantity]) VALUES (1, 1, 2, 1, N'100gm', N'2days', N'Take After MEAL', CAST(N'2025-03-09T11:57:48.710' AS DateTime), 1, CAST(N'2025-03-11T17:46:57.290' AS DateTime), 2, CAST(N'2025-03-11T17:46:57.290' AS DateTime), 1, 2, 10)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [AllotedQuantity]) VALUES (2, 2, 11, 2, N'200gm', N'1days', N'Heavy Doase', CAST(N'2025-03-10T11:57:48.710' AS DateTime), 3, CAST(N'2025-03-11T17:47:05.793' AS DateTime), 4, CAST(N'2025-03-11T17:47:05.793' AS DateTime), 1, 2, 10)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [AllotedQuantity]) VALUES (3, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime), 5, CAST(N'2025-03-11T17:47:13.827' AS DateTime), 6, CAST(N'2025-03-11T17:47:13.827' AS DateTime), 1, 2, 10)
GO
INSERT [dbo].[TblMedicineDetails] ([MedicineDetailsID], [TreatmentDetailsId], [MedicineTypeID], [Dosage], [Frequency], [Duration], [Instruction], [IssueDateTime], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [AllotedQuantity]) VALUES (4, 8, 2, 2, N'Per day 3 Times', N'5', N'After Meal', CAST(N'2025-03-11T05:20:36.653' AS DateTime), 7, CAST(N'2025-03-11T17:47:24.460' AS DateTime), 8, CAST(N'2025-03-11T17:47:24.460' AS DateTime), 1, 2, 10)
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
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (1, N'Dolo 650', 1, CAST(N'2025-03-12T14:20:37.860' AS DateTime), 2, CAST(N'2025-03-12T14:20:37.860' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (2, N'Painkillers', 3, CAST(N'2025-03-11T17:50:12.217' AS DateTime), 4, CAST(N'2025-03-11T17:50:12.217' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (3, N'Antipyretics', 5, CAST(N'2025-03-11T17:50:22.480' AS DateTime), 6, CAST(N'2025-03-11T17:50:22.480' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (4, N'Tamsulosin', 7, CAST(N'2025-03-11T17:50:34.703' AS DateTime), 8, CAST(N'2025-03-11T17:50:34.703' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (5, N'Sobisis', 9, CAST(N'2025-03-11T17:50:56.137' AS DateTime), 10, CAST(N'2025-03-11T17:50:56.137' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (6, N'J Fol', 11, CAST(N'2025-03-11T17:51:07.797' AS DateTime), 12, CAST(N'2025-03-11T17:51:07.797' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (7, N'MPROL', 13, CAST(N'2025-03-11T17:51:21.467' AS DateTime), 14, CAST(N'2025-03-11T17:51:21.467' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (8, N'Metformin', 15, CAST(N'2025-03-11T17:51:32.063' AS DateTime), 16, CAST(N'2025-03-11T17:51:32.063' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (9, N'Finerenone12', 17, CAST(N'2025-03-11T17:51:41.550' AS DateTime), 21, CAST(N'2025-04-14T14:43:43.000' AS DateTime), 1, 3, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (10, N'Beta Blockers', 19, CAST(N'2025-03-11T17:51:55.510' AS DateTime), 20, CAST(N'2025-03-11T17:51:55.510' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (11, N'Anastrozole', 21, CAST(N'2025-03-11T17:52:07.910' AS DateTime), 22, CAST(N'2025-03-11T17:52:07.910' AS DateTime), 1, 2, 300)
GO
INSERT [dbo].[TblMedicineType] ([MedicineTypeID], [TypeName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [QuantityAvailable]) VALUES (12, N'vishal123', 21, CAST(N'2025-04-14T14:16:57.000' AS DateTime), 21, CAST(N'2025-04-14T14:43:12.000' AS DateTime), NULL, 2, 300)
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
INSERT [dbo].[TblMenu] ([MenuID], [ParentMenuID], [MenuName], [Paths], [Icon], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, 1, N'Menupermission', NULL, NULL, 1, NULL, NULL, NULL, 1, 1)
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
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, 2, 1, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, 2, 2, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, 2, 3, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, 2, 4, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (30, 2, 6, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (31, 2, 7, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (32, 2, 8, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (33, 2, 9, 1, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (34, 2, 10, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (35, 2, 11, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (36, 2, 12, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (37, 2, 13, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (38, 2, 14, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (39, 2, 15, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (40, 2, 16, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (41, 2, 17, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (42, 2, 18, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (43, 2, 19, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (44, 2, 20, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (45, 2, 21, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (46, 2, 22, 0, 0, 0, 0, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (47, 2, 23, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (48, 2, 24, 0, 0, 0, 1, 48, CAST(N'2025-05-01T13:59:53.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (49, 1, 25, 1, 1, 1, 1, 28, NULL, NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (50, 2, 25, 0, 0, 0, 0, 28, NULL, NULL, NULL, 1, 1)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (61, 3, 1, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (62, 3, 2, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (63, 3, 3, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (64, 3, 4, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (65, 3, 6, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (66, 3, 7, 1, 1, 1, 0, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (67, 3, 8, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (68, 3, 9, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (69, 3, 10, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (70, 3, 11, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (71, 3, 12, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (72, 3, 13, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (73, 3, 14, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (74, 3, 15, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (75, 3, 16, 0, 0, 0, 0, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (76, 3, 17, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (77, 3, 18, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (78, 3, 19, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (79, 3, 20, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (80, 3, 21, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (81, 3, 22, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (82, 3, 23, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (83, 3, 25, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
INSERT [dbo].[TblMenuRoleMapping] ([MenuRoleMappingID], [RoleID], [MenuID], [IsAdd], [IsEdit], [IsDelete], [IsView], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (84, 3, 24, 1, 1, 1, 1, 48, CAST(N'2025-05-09T10:38:44.000' AS DateTime), NULL, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[TblMenuRoleMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblOTP] ON 
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (1, N'11900', CAST(N'2025-05-01T18:47:33.817' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (2, N'660277', CAST(N'2025-05-01T18:50:31.620' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (3, N'728003', CAST(N'2025-05-01T18:52:20.347' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (4, N'770327', CAST(N'2025-05-01T18:55:59.457' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (5, N'146077', CAST(N'2025-05-01T22:13:20.030' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (6, N'788133', CAST(N'2025-05-02T10:34:48.680' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (7, N'387619', CAST(N'2025-05-02T17:17:12.553' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (8, N'306130', CAST(N'2025-05-02T17:22:32.797' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (9, N'250320', CAST(N'2025-05-04T17:01:10.763' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (10, N'824156', CAST(N'2025-05-04T17:20:34.833' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (11, N'143999', CAST(N'2025-05-04T17:21:57.490' AS DateTime), 1, 49)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (12, N'902035', CAST(N'2025-05-07T14:54:43.600' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (13, N'906286', CAST(N'2025-05-08T11:38:45.880' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (14, N'148977', CAST(N'2025-05-08T12:24:45.333' AS DateTime), 1, 49)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (15, N'219839', CAST(N'2025-05-08T12:29:52.383' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (16, N'94622', CAST(N'2025-05-08T14:00:07.290' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (17, N'664243', CAST(N'2025-05-08T14:02:30.150' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (18, N'458154', CAST(N'2025-05-08T14:54:03.517' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (19, N'91947', CAST(N'2025-05-08T16:45:53.303' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (20, N'686581', CAST(N'2025-05-08T16:56:49.843' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (21, N'715363', CAST(N'2025-05-08T17:08:44.933' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (22, N'936013', CAST(N'2025-05-08T17:53:17.357' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (23, N'190580', CAST(N'2025-05-08T18:37:12.970' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (24, N'480764', CAST(N'2025-05-08T20:47:02.423' AS DateTime), 0, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (25, N'774542', CAST(N'2025-05-08T20:47:02.423' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (26, N'702467', CAST(N'2025-05-08T21:45:48.257' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (27, N'543480', CAST(N'2025-05-08T21:53:56.540' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (28, N'253230', CAST(N'2025-05-09T10:02:08.713' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (29, N'157892', CAST(N'2025-05-09T10:40:59.873' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (30, N'523311', CAST(N'2025-05-09T10:42:07.910' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (31, N'577382', CAST(N'2025-05-11T14:41:18.310' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (32, N'575705', CAST(N'2025-05-12T09:37:45.910' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (33, N'243965', CAST(N'2025-05-12T12:30:40.213' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (34, N'718181', CAST(N'2025-05-12T15:51:46.080' AS DateTime), 1, 48)
GO
INSERT [dbo].[TblOTP] ([OtpID], [Code], [Expiry_time], [IsUse], [CreatedBy]) VALUES (35, N'729892', CAST(N'2025-05-13T11:51:23.467' AS DateTime), 0, 50)
GO
SET IDENTITY_INSERT [dbo].[TblOTP] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPateintDoctormapping] ON 
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 1, 2, 2, 3, CAST(N'2025-03-11T17:56:17.500' AS DateTime), 4, CAST(N'2025-03-11T17:56:17.500' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 1, 3, 3, 5, CAST(N'2025-03-11T17:56:24.620' AS DateTime), 6, CAST(N'2025-03-11T17:56:24.620' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblPateintDoctormapping] ([PateintDoctormappingId], [UserId], [PatientId], [TreatmentDetailsId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 1, NULL, 10, 21, CAST(N'2025-04-16T14:46:22.000' AS DateTime), NULL, NULL, 1, 1)
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
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, CAST(N'2006-02-08' AS Date), N'Male', N'Gandhinagar', N'AB+', N'9428011036', NULL, 21, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, CAST(N'2025-04-10' AS Date), N'Male', N'gandhinagar', N'AB+', N'9510212123', N'no', 22, 0, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, CAST(N'2025-04-10' AS Date), N'Male', N'gandhinagar', N'B+', N'9582651526', NULL, 23, 23, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, CAST(N'2025-04-11' AS Date), N'Male', N'gandhinagar', N'O-', N'8753654765', NULL, 24, 24, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, CAST(N'2025-04-11' AS Date), N'Male', N'gandhinagar', N'O+', N'8773764573', NULL, 25, 25, CAST(N'2025-04-18T17:10:00.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, CAST(N'2025-04-09' AS Date), N'Male', N'dholibhal', N'B+', N'8512452365', NULL, 26, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, CAST(N'2025-04-18' AS Date), N'Male', N'n', N'O+', N'9510212158', NULL, 27, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, CAST(N'2025-04-10' AS Date), N'Male', N'gandhinagar', N'B-', N'9510212108', N'no', 28, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, CAST(N'2025-04-10' AS Date), N'Male', N'dholibhal', N'B+', N'9510212154', NULL, 29, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, CAST(N'2025-04-09' AS Date), N'Male', N'dholi', N'O+', N'9510254254', NULL, 30, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, CAST(N'2025-04-04' AS Date), N'Male', N'dholi', N'B+', N'8452150325', N'no', 31, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, CAST(N'2025-04-03' AS Date), N'Male', N'dholi', N'B+', N'8765432897', NULL, 32, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, CAST(N'2025-04-04' AS Date), N'Male', N'dholibhal', N'B+', N'9102541025', NULL, 33, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, CAST(N'2025-04-03' AS Date), N'Male', N'gota', N'B+', N'9898263598', N'no', 34, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, CAST(N'2025-04-04' AS Date), N'Male', N'gandhinagar', N'B+', N'9542158425', NULL, 35, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, CAST(N'2025-04-09' AS Date), N'Male', N'gandhinagar', N'B+', N'9102154853', NULL, 36, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, CAST(N'2025-04-17' AS Date), N'Male', N'gandhinagar', N'B+', N'9841025742', NULL, 37, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (29, CAST(N'2025-04-16' AS Date), N'Male', N'dholi', N'B+', N'9124857412', NULL, 38, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (30, CAST(N'2025-04-22' AS Date), N'Male', N'abc,456', N'AB+', N'9898989898', N'NA', 39, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (31, CAST(N'2025-04-19' AS Date), N'Male', N'mnbjc', N'O+', N'6969563625', N'NA', 40, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (32, CAST(N'2025-04-11' AS Date), N'Male', N'dholi', N'AB+', N'9254125863', NULL, 41, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (33, CAST(N'2025-04-03' AS Date), N'Male', N'sb', N'A+', N'9878978978', N'd msd', 42, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (34, CAST(N'2025-04-03' AS Date), N'Male', N'dholi', N'B+', N'9214585265', NULL, 43, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (35, CAST(N'2025-04-10' AS Date), N'Male', N'no', N'B+', N'9842512586', NULL, 44, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (36, CAST(N'2025-04-11' AS Date), N'Male', N'sjasj', N'A+', N'7485968596', NULL, 45, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (37, CAST(N'2025-04-03' AS Date), N'Male', N'dholi', N'B+', N'9102541258', NULL, 46, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (38, CAST(N'2025-04-10' AS Date), N'Male', N'no', N'O+', N'9102541253', N'no', 47, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (39, CAST(N'2025-04-10' AS Date), N'Male', N'dholibhal', N'B+', N'9524512452', N'no', 48, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (40, CAST(N'2025-05-02' AS Date), N'Male', N'dholi', N'B+', N'9524125852', NULL, 49, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatient] ([PatientId], [DOB], [Gender], [Address], [Blood_Group], [Emergency_Contact], [Medical_History], [UserId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (41, CAST(N'2025-05-08' AS Date), N'Male', N'dholi', N'B-', N'9652145238', NULL, 50, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblPatient] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] ON 
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, CAST(N'2025-04-10T15:11:00.000' AS DateTime), 1, 1, NULL, 21, CAST(N'2025-04-11T15:12:01.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, CAST(N'2025-04-09T15:12:00.000' AS DateTime), 1, 1, NULL, 21, CAST(N'2025-04-11T15:13:08.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, CAST(N'2025-04-04T15:14:00.000' AS DateTime), 1, 2, NULL, 21, CAST(N'2025-04-11T15:14:53.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, CAST(N'2025-04-16T10:02:55.170' AS DateTime), 2, 8, CAST(N'2025-04-16T10:02:55.170' AS DateTime), 0, CAST(N'2025-04-16T15:33:20.000' AS DateTime), 0, CAST(N'2025-04-16T10:02:55.170' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, CAST(N'2025-04-04T15:35:00.000' AS DateTime), 2, 10, NULL, 21, CAST(N'2025-04-16T15:35:47.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, CAST(N'2025-04-11T15:36:00.000' AS DateTime), 2, 3, NULL, 21, CAST(N'2025-04-16T15:36:35.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, CAST(N'2025-04-11T21:44:00.000' AS DateTime), 3, 9, NULL, 21, CAST(N'2025-04-20T21:44:49.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, CAST(N'2025-04-05T21:46:00.000' AS DateTime), 1, 17, NULL, 21, CAST(N'2025-04-20T21:46:48.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, CAST(N'2025-04-05T22:10:00.000' AS DateTime), 1, 11, NULL, 21, CAST(N'2025-04-20T22:10:42.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (29, CAST(N'2025-04-05T22:20:00.000' AS DateTime), 2, 12, NULL, 21, CAST(N'2025-04-20T22:20:45.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (30, CAST(N'2025-04-05T22:20:00.000' AS DateTime), 1, 13, NULL, 21, CAST(N'2025-04-20T22:20:57.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (31, CAST(N'2025-04-06T22:21:00.000' AS DateTime), 1, 13, NULL, 21, CAST(N'2025-04-20T22:21:13.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (32, CAST(N'2025-04-12T22:22:00.000' AS DateTime), 2, 13, NULL, 21, CAST(N'2025-04-20T22:22:06.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (33, CAST(N'2025-04-12T22:22:00.000' AS DateTime), 1, 14, NULL, 21, CAST(N'2025-04-20T22:22:32.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (34, CAST(N'2025-04-12T22:22:00.000' AS DateTime), 2, 16, NULL, 21, CAST(N'2025-04-20T22:22:54.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblPatientAdmitionDetails] ([PatientAdmitionDetailsId], [AdmisionDate], [RoomID], [TreatmentDetailsId], [DischargeDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (35, CAST(N'2025-04-10T12:23:00.000' AS DateTime), 2, 15, NULL, 21, CAST(N'2025-04-21T12:23:44.000' AS DateTime), NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblPatientAdmitionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRole] ON 
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'admin', 1, CAST(N'2025-03-11T18:00:49.510' AS DateTime), 1, CAST(N'2025-04-02T16:04:59.773' AS DateTime), 1, 18)
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'Patient', 3, CAST(N'2025-03-11T18:00:39.857' AS DateTime), 1, CAST(N'2025-04-02T13:17:19.593' AS DateTime), 1, 9)
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Hr-Admin', 48, CAST(N'2025-03-03T00:00:00.000' AS DateTime), 48, CAST(N'2025-03-03T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblRole] ([RoleId], [RoleName], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, N'Ca-Admin', 48, CAST(N'2025-03-03T00:00:00.000' AS DateTime), 48, CAST(N'2025-03-03T00:00:00.000' AS DateTime), 1, 1)
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
INSERT [dbo].[TblRoomType] ([RoomTypeId], [RoomType], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'123', 1, CAST(N'2025-04-15T00:00:00.000' AS DateTime), 1, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblRoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] ON 
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 2, 6, 1, CAST(N'2025-03-11T18:13:53.607' AS DateTime), 2, CAST(N'2025-03-11T18:14:41.743' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 5, 8, 5, CAST(N'2025-03-11T18:15:07.113' AS DateTime), 6, CAST(N'2025-03-11T18:15:07.113' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 2, 6, 21, CAST(N'2025-04-14T16:42:40.000' AS DateTime), 21, CAST(N'2025-04-14T16:57:17.000' AS DateTime), NULL, 9)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 5, 11, 21, CAST(N'2025-04-14T18:09:33.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 6, 6, 21, CAST(N'2025-04-14T18:10:03.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 6, 3, 21, CAST(N'2025-04-14T18:10:34.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 2, 7, 21, CAST(N'2025-04-14T18:10:56.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblRoomTypeFacilityMapping] ([RoomTypeFacilityMappingID], [RoomID], [FacilityID], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 5, 5, 21, CAST(N'2025-04-14T18:23:29.000' AS DateTime), NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblRoomTypeFacilityMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TblShift] ON 
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Night', 1, CAST(N'2025-03-11T18:15:55.710' AS DateTime), 2, CAST(N'2025-03-11T18:15:55.710' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Aftoornoon', 3, CAST(N'2025-03-11T18:16:22.193' AS DateTime), 0, CAST(N'2025-05-02T14:07:45.000' AS DateTime), 1, 4)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, CAST(N'16:00:00' AS Time), CAST(N'23:59:00' AS Time), N'Aftoornoon', 5, CAST(N'2025-03-11T18:16:28.920' AS DateTime), 6, CAST(N'2025-03-11T18:16:28.920' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, CAST(N'12:31:00' AS Time), CAST(N'00:31:00' AS Time), N'vishal', 39, CAST(N'2025-04-22T12:31:57.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblShift] ([ShiftId], [StartTime], [EndTime], [Shiftname], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, CAST(N'13:41:00' AS Time), CAST(N'00:41:00' AS Time), N'stvu', 39, CAST(N'2025-04-22T12:41:09.000' AS DateTime), NULL, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblShift] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] ON 
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (1, 6, 3, CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, CAST(N'2025-03-11T18:17:09.520' AS DateTime), 21, CAST(N'2025-04-14T16:29:31.000' AS DateTime), NULL, 3, N'T0001')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (2, 3, 2, CAST(N'2025-03-10T10:23:07.273' AS DateTime), 3, CAST(N'2025-03-11T18:17:21.813' AS DateTime), 4, CAST(N'2025-03-11T18:17:21.813' AS DateTime), 1, 2, N'T0002')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (3, 2, 11, CAST(N'2025-04-17T00:00:00.000' AS DateTime), 5, CAST(N'2025-03-11T18:17:54.740' AS DateTime), 21, CAST(N'2025-04-14T16:14:11.000' AS DateTime), NULL, 3, N'T0003')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (8, 1, 1, CAST(N'2025-04-01T00:00:00.000' AS DateTime), 6, CAST(N'2025-03-11T18:18:34.227' AS DateTime), 21, CAST(N'2025-04-14T16:29:50.000' AS DateTime), NULL, 3, N'T0008')
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (9, 4, 2, CAST(N'2025-04-10T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:18:35.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (10, 2, 2, CAST(N'2025-04-10T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:18:57.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (11, 2, 2, CAST(N'2025-04-14T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:19:11.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (12, 1, 1, CAST(N'2025-04-01T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:19:50.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (13, 2, 11, CAST(N'2025-04-01T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:19:58.000' AS DateTime), 21, CAST(N'2025-04-14T16:32:24.000' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (14, 5, 3, CAST(N'2025-04-01T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:23:17.000' AS DateTime), 21, CAST(N'2025-04-14T16:34:06.000' AS DateTime), NULL, 3, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (15, 2, 1, CAST(N'2025-04-01T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:23:26.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (16, 2, 2, CAST(N'2025-04-09T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:30:37.000' AS DateTime), 21, CAST(N'2025-04-14T16:31:40.000' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[TblTreatmentDetails] ([TreatmentDetailsId], [DieseaseTypeID], [PatientId], [TreatmentDate], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo], [TreatmentCode]) VALUES (17, 5, 2, CAST(N'2025-04-08T00:00:00.000' AS DateTime), 21, CAST(N'2025-04-14T16:34:00.000' AS DateTime), NULL, NULL, NULL, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[TblTreatmentDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUser] ON 
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, N'John Doe', N'johndoe@gmail.com', N'P@ssw0rd123', N'1234567890', 2, 1, CAST(N'2025-03-11T18:19:32.833' AS DateTime), 48, CAST(N'2025-05-09T10:41:59.850' AS DateTime), 1, 26)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, N'dfvrtgfvf', N'strintgffg', N'strffing', N'9512552584', 3, 3, CAST(N'2025-03-11T18:22:34.177' AS DateTime), 48, CAST(N'2025-05-08T23:12:36.633' AS DateTime), 1, 11)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, N'Michael Johnson', N'michaeljohnson@gmail.com', N'P@ssw0rd789', N'1122334455', 3, 5, CAST(N'2025-03-11T18:22:44.757' AS DateTime), 48, CAST(N'2025-05-09T10:36:14.653' AS DateTime), 1, 7)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, N'David Wilson', N'davidwilson@gmail.com', N'P@ssw0rd112', N'9988776655', 4, 9, CAST(N'2025-03-11T18:23:05.903' AS DateTime), 48, CAST(N'2025-05-09T10:21:31.307' AS DateTime), 1, 9)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, N'Mitesh Simariya', N'mitesh125@gmail.com', N'Mitesh@123', N'9453762110', 4, 11, CAST(N'2025-03-11T18:23:15.547' AS DateTime), 48, CAST(N'2025-05-09T10:21:15.553' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, N'Khyati Patel', N'patelkhyati52@gmail.com', N'Patel@250', N'9450207766', 2, 13, CAST(N'2025-03-11T18:23:23.713' AS DateTime), 14, CAST(N'2025-03-11T18:23:23.713' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, N'Vraj Patel', N'vraj224@gamil.com', N'vraj@224', N'9452328756', 2, 15, CAST(N'2025-03-11T18:23:32.503' AS DateTime), 16, CAST(N'2025-03-11T18:23:32.503' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, N'Vishal Gami', N'gamivishal@gmail.com', N'gamiv123', N'9457865420', 2, 17, CAST(N'2025-03-11T18:23:41.097' AS DateTime), 18, CAST(N'2025-03-11T18:23:41.097' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, N'Parth Ratheliya', N'parthesh@gmail.com', N'partha@2323', N'9496948411', 2, 19, CAST(N'2025-03-11T18:23:51.513' AS DateTime), 20, CAST(N'2025-03-11T18:23:51.513' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, N'Sahil Savaj', N'sahillion@gmail.com', N'Lion@123', N'9484741020', 3, 21, CAST(N'2025-03-11T18:24:02.960' AS DateTime), 48, CAST(N'2025-05-08T23:15:41.787' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, N'stvfring', N'strifvng', N'strfvvding', N'9033342003', 2, 23, CAST(N'2025-03-11T18:24:42.150' AS DateTime), 0, CAST(N'2025-04-15T11:46:45.610' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, N'Shreya Patel', N'shreyaPatel@gmail.com', N'Spatel@2241', N'9487476737', 2, 25, CAST(N'2025-03-11T18:24:49.613' AS DateTime), 26, CAST(N'2025-03-11T18:24:49.613' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, N'Stavan Hariyani', N'hariyanistavan52@gmail.com', N'stavan@2434', N'9484537684', 4, 27, CAST(N'2025-03-11T18:24:56.417' AS DateTime), 48, CAST(N'2025-05-09T10:02:54.227' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, N'Gopal Vyas', N'gopalvyas@gmail.com', N'vyas@22', N'9487536420', 3, 29, CAST(N'2025-03-11T18:25:08.617' AS DateTime), 48, CAST(N'2025-05-09T10:02:39.270' AS DateTime), 1, 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, N'Nitin Maru', N'nitinmaru42@gmail.com', N'Nitin@2211', N'9474648484', 3, 31, CAST(N'2025-03-11T18:25:16.473' AS DateTime), 48, CAST(N'2025-05-09T10:01:07.210' AS DateTime), 1, 5)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (17, N'Niana', N'naina@123', N'password123', N'2584598725', 2, 33, CAST(N'2025-03-11T18:25:24.840' AS DateTime), 5, CAST(N'2025-04-06T07:36:30.913' AS DateTime), 1, 3)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, N'Naitik Gondaliya1', N'NaitikGondaliya12@gmail.com', N'admin@1234', NULL, 2, 39, CAST(N'2025-03-11T18:25:59.140' AS DateTime), 40, CAST(N'2025-03-11T18:25:59.140' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (21, N'Gami Vishal', N'vishal@2006', N'vmgami@2006', N'9510212154', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (22, N'gami vishal', N'vishal@2008', N'vmgami@2008', N'9510212158', 2, 0, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (23, N'Gami vishal', N'vmgami2001@g.com', N'vishal', N'7687645678', 2, 23, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (24, N'gmivishak', N'chbvddjfbh@g.com', N'vishal123', N'8756476386', 2, 24, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (25, N'gami Vishal', N'vraj@1999', N'1234567', N'8764673677', 2, 25, CAST(N'2025-04-18T17:10:00.000' AS DateTime), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (26, N'vishal Gami', N'vmgami@gami.com', N'123456', N'9510212126', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (27, N'vishaladj', N'vmgami@gamil.com', N'vishal', N'9510212154', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (28, N'Rethaliya Parth', N'vmgami2008@gami.com', N'U2FsdGVkX1+rEGLvpRvbJTTQk1WaeWAg0+Kyq3me7o4=', N'9254802546', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (29, N'vishal', N'vmgami2001@gmail.com', N'U2FsdGVkX1+Kl98xuzUn+u35yXKqyH01NVZfei0+w0Q=', N'9510212154', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (30, N'vishal', N'vmgami@2006', N'U2FsdGVkX183jqeIAA6HE73vBSey15pKAOGLE6i9Fo0=', N'9510212158', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (31, N'vishal', N'vishal2000@gmail.com', N'17756315ebd47b7110359fc7b168179bf6f2df3646fcc888bc8aa05c78b38ac1', N'9025413682', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (32, N'rajeshgami', N'gami@gamil.com', N'bQ5Y4K+88UunjhQtMZUfrg==', N'9876543210', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (33, N'gami stavan', N'Stvan@gami.com', N'r5iY5S+WKZms9518nuIekw==', N'9254123502', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (34, N'vraj patel', N'vraju@2004gmail.com', N'o33EpRUDSpguZgayNymeOw==', N'9512548526', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (35, N'dischifdv', N'discshci@juuo', N'ZSuoj6PMHihheFUbXAydpw==', N'9510245852', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (36, N'Gami vishal', N'vishL@gamil.com', N'egAD4KjIbChGHP0pjNjdMg==', N'9510212154', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (37, N'Gami rajesh', N'rajesh@gmail.com', N'egAD4KjIbChGHP0pjNjdMg==', N'9012548523', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (38, N'hariyani stavan', N'stavan@gmail.com', N'r5iY5S+WKZms9518nuIekw==', N'9510212185', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (39, N'panth', N'panth@gmail.com', N'yrgiqrXhh3Dnaio1oD+Mrw==', N'6969696969', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (40, N'panth', N'panth1@gmail.com', N'yrgiqrXhh3Dnaio1oD+Mrw==', N'8569854785', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (41, N'vishal', N'vishal@gmail.com', N'w133PRG1OLLjL3QoE8J+Iw==', N'9510252569', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (42, N'ABC', N'abc@gmail.com', N'MQiRxMeZ0E3GKGnb+nrfYA==', N'8675897685', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (43, N'vishal', N'vmgami@gmail.com', N'QWybmnK5wr8/u0akEKFvVQ==', N'9521542536', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (44, N'gami vishal', N'vm@gamil.com', N'zEIo97w/oxdio3yZr3elGA==', N'9254125852', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (45, N'Jaymin', N'jaymin@gmail.com', N'hSXTNPRt+WEiSq2Ig1uiaA==', N'8748596859', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (46, N'parth', N'parth@gmail.com', N'QWybmnK5wr8/u0akEKFvVQ==', N'9214525368', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (47, N'sduhu', N'vishal2001@gmail.com', N'w133PRG1OLLjL3QoE8J+Iw==', N'9325412586', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (48, N'Gami Vishal', N'vishal2006@gmail.com', N'w133PRG1OLLjL3QoE8J+Iw==', N'9898366398', 3, NULL, NULL, 48, CAST(N'2025-05-09T10:36:42.880' AS DateTime), NULL, 2)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (49, N'gami vishal', N'vmgami2006@gmail.com', N'qiFwavvC7uMV0VhwqpkXww==', N'9882145205', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TblUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (50, N'Gami Vishal', N'vishal2008@gmail.com', N'w133PRG1OLLjL3QoE8J%2BIw%3D%3D', N'9652145258', 2, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TblUser] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUserRoleMapping] ON 
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (1, 1, 1, 48, CAST(N'2025-05-09T11:41:45.180' AS DateTime), 48, CAST(N'2025-05-09T11:41:45.180' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (2, 2, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (3, 3, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (4, 5, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (5, 6, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (6, 7, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (7, 8, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (8, 9, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (9, 10, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (10, 11, 4, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (11, 12, 3, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (12, 13, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (13, 14, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (14, 15, 2, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (15, 48, 1, 48, CAST(N'2025-05-09T11:44:58.583' AS DateTime), 48, CAST(N'2025-05-09T13:41:15.260' AS DateTime), 1, 2)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (16, 48, 3, 0, CAST(N'2025-05-09T14:04:45.453' AS DateTime), 48, CAST(N'2025-05-09T08:34:17.313' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (18, 15, 3, 0, CAST(N'2025-05-09T14:09:06.243' AS DateTime), 48, CAST(N'2025-05-09T08:38:40.360' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (19, 15, 3, 0, CAST(N'2025-05-09T14:09:13.190' AS DateTime), 48, CAST(N'2025-05-09T08:38:40.360' AS DateTime), 1, 1)
GO
INSERT [dbo].[TblUserRoleMapping] ([TblUserRoleMappingID], [UserId], [RoleId], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [VersionNo]) VALUES (20, 1, 2, 0, CAST(N'2025-05-09T14:14:49.123' AS DateTime), 48, CAST(N'2025-05-09T08:44:37.843' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TblUserRoleMapping] OFF
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
USE [master]
GO
ALTER DATABASE [HSMDB] SET  READ_WRITE 
GO

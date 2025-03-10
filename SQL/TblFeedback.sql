USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblFeedback]    Script Date: 10-03-2025 09:43:13 ******/
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
ALTER TABLE [dbo].[TblFeedback]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[TblPatient] ([PatientId])
GO
ALTER TABLE [dbo].[TblFeedback]  WITH CHECK ADD FOREIGN KEY([TreatmentDetailsId])
REFERENCES [dbo].[TblTreatmentDetails] ([TreatmentDetailsId])
GO

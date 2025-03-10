USE [HSMDB]
GO
/****** Object:  Table [dbo].[TblRoomTypeFacilityMapping]    Script Date: 3/10/2025 5:00:52 PM ******/
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
ALTER TABLE [dbo].[TblRoomTypeFacilityMapping]  WITH CHECK ADD FOREIGN KEY([FacilityID])
REFERENCES [dbo].[TblFacility] ([FacilityID])
GO
ALTER TABLE [dbo].[TblRoomTypeFacilityMapping]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[TblRoom] ([RoomID])
GO

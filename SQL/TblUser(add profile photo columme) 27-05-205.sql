USE [HSMDB]

ALTER TABLE [dbo].[TblUser]  
ADD [ProfileImagePath] [nvarchar](255) NULL;

ALTER TABLE [dbo].[TblUser]  
ADD [ProfileImageThumbnailPath] [nvarchar](255) NULL;


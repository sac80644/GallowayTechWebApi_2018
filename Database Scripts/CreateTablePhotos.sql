USE [GallowayTechDB]
GO

DROP TABLE Photos

/****** Object:  Table [dbo].[Photos]    Script Date: 6/5/2018 10:36:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Photos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhotoID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
	[Caption] [nvarchar](50) NOT NULL,
	[FileName] [varchar](255) NOT NULL,
	[DirectoryName] [varchar](max) NOT NULL,
	[FullPath] [varchar](max) NOT NULL,
	[URL] [nvarchar](400) NOT NULL,
	[Size] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


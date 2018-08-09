USE [GallowayTechDB]
GO

/****** Object:  Table [GallowayTechWebApi].[SiteContent]    Script Date: 2/11/2018 6:27:39 PM ******/
DROP TABLE [dbo].[SiteContent]
GO

/****** Object:  Table [GallowayTechWebApi].[SiteContent]    Script Date: 2/11/2018 6:27:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SiteContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [varchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_SiteContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

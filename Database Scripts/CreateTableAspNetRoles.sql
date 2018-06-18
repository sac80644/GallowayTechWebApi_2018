USE [GallowayTechDB]
GO

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/17/2018 9:22:37 PM ******/
DROP TABLE [dbo].[AspNetRoles]
GO

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/17/2018 9:22:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



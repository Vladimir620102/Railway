﻿CREATE TABLE [dbo].[USER](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[isadmin] [bit] NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
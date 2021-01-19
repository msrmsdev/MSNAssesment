USE [PhoneBookDB]
GO
/****** Object:  Table [dbo].[PhoneBook]    Script Date: 19 Jan 2021 21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneBook](
	[PhoneBookID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
 CONSTRAINT [PK_PhoneBook] PRIMARY KEY CLUSTERED 
(
	[PhoneBookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PhoneBook] ON 
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (1, N'Sri', N'MSDev', N'0876325631', N'SriMSDev@Gmail.com', N'Capetown')
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (2, N'Nick ', N'Talman', N'0876325632', N'Talman@Gmail.com', N'California')
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (3, N'Gavin', N'Belson', N'0876325633', N'Belson@Yahoo.com', N'Silicon Valley')
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (4, N'Harvey', N'Spector', N'0876325634', N'Harry@Gmail.com', N'Dubai')
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (5, N'Gabriel', N'Macht', N'0876325635', N'Macht@Gmail.com', N'California')
GO
INSERT [dbo].[PhoneBook] ([PhoneBookID], [FirstName], [LastName], [Contact], [Email], [Address]) VALUES (6, N'Michael Gary', N'Scott', N'0876325638', N'Scott', N'UK')
GO
SET IDENTITY_INSERT [dbo].[PhoneBook] OFF
GO

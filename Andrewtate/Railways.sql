USE [Railways]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15.06.2024 19:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID_Employee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[DateBirth] [date] NULL,
	[Experiance] [int] NOT NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role_ID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID_Employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15.06.2024 19:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Roles] [int] IDENTITY(1,1) NOT NULL,
	[Names] [varchar](50) NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID_Roles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stantion]    Script Date: 15.06.2024 19:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stantion](
	[ID_Station] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Town] [varchar](50) NULL,
	[Size] [int] NULL,
	[Traint_ID] [int] NULL,
 CONSTRAINT [PK_Stantion] PRIMARY KEY CLUSTERED 
(
	[ID_Station] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 15.06.2024 19:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[ID_Train] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Seats] [int] NULL,
	[Year] [date] NULL,
	[Employee_ID] [int] NULL,
 CONSTRAINT [PK_Train] PRIMARY KEY CLUSTERED 
(
	[ID_Train] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Roles] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[Roles] ([ID_Roles])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Roles]
GO
ALTER TABLE [dbo].[Stantion]  WITH CHECK ADD  CONSTRAINT [FK_Stantion_Train] FOREIGN KEY([Traint_ID])
REFERENCES [dbo].[Train] ([ID_Train])
GO
ALTER TABLE [dbo].[Stantion] CHECK CONSTRAINT [FK_Stantion_Train]
GO
ALTER TABLE [dbo].[Train]  WITH CHECK ADD  CONSTRAINT [FK_Train_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([ID_Employee])
GO
ALTER TABLE [dbo].[Train] CHECK CONSTRAINT [FK_Train_Employee]
GO

USE [JobManagement]
GO
/****** Object:  Schema [JobManagement]    Script Date: 21/08/2016 07:54:00 ******/
CREATE SCHEMA [JobManagement]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL DEFAULT ((0)),
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL DEFAULT ((0)),
	[TwoFactorEnabled] [bit] NOT NULL DEFAULT ((0)),
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL DEFAULT ((0)),
	[AccessFailedCount] [int] NOT NULL DEFAULT ((0)),
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[AutoNumberBase]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[AutoNumberBase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Element] [nvarchar](50) NOT NULL,
	[LastUsedNumber] [int] NOT NULL,
	[Year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[Customers]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[Customers](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Name2] [nvarchar](100) NULL,
	[FullName]  AS (ltrim(rtrim((rtrim(coalesce([Name],''))+' ')+ltrim(coalesce([Name2],''))))),
	[Address] [nvarchar](100) NULL,
	[Address1] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[Province] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[FiscalCode] [nvarchar](30) NULL,
	[VATNumber] [nvarchar](30) NULL,
	[Status] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[GLAccount]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[GLAccount](
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NULL,
	[PostingType] [nvarchar](20) NULL,
 CONSTRAINT [PK_GLAccount] PRIMARY KEY CLUSTERED 
(
	[GLAccountCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[GLAccountEntries]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[GLAccountEntries](
	[GLAccountEntryId] [bigint] NOT NULL,
	[PostingDate] [date] NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[GLAccountGroup] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DocumentPrimaryKey] [nvarchar](20) NULL,
	[DebitCredit] [nchar](1) NULL,
	[LineNumber] [int] NULL,
 CONSTRAINT [PK_GLAccountEntries] PRIMARY KEY CLUSTERED 
(
	[GLAccountEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[Jobs]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[Jobs](
	[JobId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[Code] [nvarchar](20) NULL,
	[Description] [nvarchar](512) NOT NULL,
	[ExpectedIncome] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[ExpectedCost] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[ExpectedWorkHours] [int] NOT NULL DEFAULT ((0)),
	[Status] [tinyint] NOT NULL,
	[Year] [int] NULL,
	[ExpectedStartDate] [date] NULL,
	[ExpectedFinishDate] [date] NULL,
	[StartDate] [date] NULL,
	[FinishDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[JobStatus]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[JobStatus](
	[JobStateId] [tinyint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_JobsState] PRIMARY KEY CLUSTERED 
(
	[JobStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[JobTasks]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[JobTasks](
	[JobTaskId] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](75) NULL,
	[NoWorkTask] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[JobTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[Person]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[Person](
	[PeopleId] [int] IDENTITY(1,1) NOT NULL,
	[IdentityId] [nvarchar](128) NULL,
	[FirstName] [nvarchar](75) NULL,
	[LastName] [nvarchar](75) NOT NULL,
	[CompanyName] [nvarchar](150) NULL,
	[Contract] [tinyint] NOT NULL DEFAULT ((0)),
	[Email] [nvarchar](255) NULL,
	[HourCost] [decimal](18, 2) NOT NULL DEFAULT ((25)),
	[ActiveState] [bit] NOT NULL DEFAULT ((1)),
	[Code] [nvarchar](20) NULL,
	[CarPlate] [nvarchar](10) NULL,
	[CarDescription] [nvarchar](75) NULL,
	[CarKmCost] [decimal](8, 4) NOT NULL DEFAULT ((0)),
	[IdentityDefault] [bit] NOT NULL DEFAULT ((0)),
	[GLAccountGroup] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[PurchaseJobs]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[PurchaseJobs](
	[PurchaseId] [bigint] NOT NULL,
	[JobId] [bigint] NOT NULL,
	[InPercent] [decimal](6, 2) NULL,
 CONSTRAINT [PK_PurchaseJob] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC,
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[Purchases]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[Purchases](
	[PurchaseId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuyFromName] [nvarchar](100) NULL,
	[BuyFromCity] [nvarchar](100) NULL,
	[BuyFromCountry] [nvarchar](100) NULL,
	[BuyFromDocType] [int] NULL,
	[BuyFromDocNumber] [nvarchar](20) NULL,
	[BuyFromDocDate] [date] NULL,
	[Amount] [decimal](18, 2) NULL,
	[AmountNoVat] [decimal](18, 2) NULL,
	[Vat] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[DueDate] [date] NULL,
	[DcoumentURI] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenseAutoCode]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpenseAutoCode](
	[PeopleId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Prefix] [nvarchar](20) NOT NULL,
	[LastUsedNumber] [int] NOT NULL,
 CONSTRAINT [PK_TravelExpenseAutoCode] PRIMARY KEY CLUSTERED 
(
	[PeopleId] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenseJobs]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpenseJobs](
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[InPercent] [decimal](6, 2) NOT NULL CONSTRAINT [DF_TravelExpenseJob_QuotePercent]  DEFAULT ((100)),
 CONSTRAINT [PK_TravelExpenseJob] PRIMARY KEY CLUSTERED 
(
	[TravelExpenseCode] ASC,
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenseLineCategories]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpenseLineCategories](
	[TravelExpenseLineCategoryId] [int] NOT NULL,
	[UsePersonalCar] [bit] NOT NULL DEFAULT ((0)),
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseLineCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpensePurchases]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpensePurchases](
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[PurchaseId] [bigint] NOT NULL,
	[InPercent] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_TravelExpensePurchases] PRIMARY KEY CLUSTERED 
(
	[TravelExpenseCode] ASC,
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenses]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpenses](
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[Date] [date] NOT NULL,
	[Annotation] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL DEFAULT ((0)),
	[PeopleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpensesLines]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpensesLines](
	[TravelExpenseLineId] [bigint] IDENTITY(1,1) NOT NULL,
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[Date] [date] NOT NULL,
	[TravelExpenseLineCategoryId] [int] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL DEFAULT ((0)),
	[Description] [nvarchar](150) NULL,
	[Note] [nvarchar](max) NULL,
	[CarPlate] [nvarchar](10) NULL,
	[CarDescription] [nvarchar](75) NULL,
	[CarKmCost] [decimal](8, 4) NOT NULL DEFAULT ((0)),
	[CarKm] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenseStatus]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[TravelExpenseStatus](
	[StatusId] [tinyint] NOT NULL DEFAULT ((0)),
	[Description] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[WorksJournal]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[WorksJournal](
	[WorkJournalId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Date] [date] NOT NULL,
	[WorkedHours] [decimal](5, 2) NOT NULL,
	[TaskWhere] [nvarchar](160) NULL,
	[Annotation] [nvarchar](max) NULL,
	[JobTaskId] [nvarchar](20) NOT NULL,
	[PeopleId] [int] NOT NULL,
 CONSTRAINT [PK_JobWorkJournal] PRIMARY KEY CLUSTERED 
(
	[WorkJournalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [JobManagement].[JobTotalWorkedHours]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [JobManagement].[JobTotalWorkedHours]
AS
SELECT        JobId, SUM(WorkedHours) AS TotalHours
FROM            [JobManagement].WorksJournal
GROUP BY JobId


GO
/****** Object:  View [JobManagement].[JobList]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [JobManagement].[JobList]
AS
SELECT        J.JobId, J.CustomerId, J.Code, J.[Description], J.ExpectedIncome, J.ExpectedCost, J.ExpectedWorkHours, J.Status, J.Year, 
                         [JobManagement].JobTotalWorkedHours.TotalHours, JS.[Description] AS StatusDescription, C.Name AS CustomerName, C.Name2 AS CustomerName2, 
                         C.FullName AS CustomerFullName
FROM            [JobManagement].[Jobs] J LEFT OUTER JOIN
                         [JobManagement].Customers C ON J.CustomerId = C.CustomerId LEFT OUTER JOIN
                         [JobManagement].JobStatus JS ON J.Status = JS.JobStateId LEFT OUTER JOIN
                         [JobManagement].JobTotalWorkedHours ON J.JobId = [JobManagement].JobTotalWorkedHours.JobId


GO
/****** Object:  View [JobManagement].[TravelExpenseList]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [JobManagement].[TravelExpenseList]
AS
SELECT        TE.TravelExpenseCode, TE.Date, TE.Annotation, TE.Status, P.PeopleId, P.FirstName, P.LastName, 
                         P.Code, MIN(TEL.Date) AS BeginDate, MAX(TEL.Date) AS EndDate, SUM(TEL.Amount) AS Total
FROM            [JobManagement].TravelExpenses TE LEFT OUTER JOIN
                         [JobManagement].Person P ON TE.PeopleId = P.PeopleId LEFT OUTER JOIN
                         [JobManagement].TravelExpensesLines TEL ON TE.TravelExpenseCode = TEL.TravelExpenseCode
GROUP BY TE.TravelExpenseCode, TE.Date, TE.Annotation, TE.Status, P.PeopleId, P.FirstName, P.LastName, 
                         P.Code


GO
/****** Object:  View [JobManagement].[TravelExpenseJobsList]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [JobManagement].[TravelExpenseJobsList]
AS
SELECT        TEJ.TravelExpenseCode, TEJ.JobId, TEJ.InPercent, [JobManagement].TravelExpenseList.Total, [JobManagement].TravelExpenseList.Status, 
                         [JobManagement].TravelExpenseList.Total * TEJ.InPercent / 100 AS Amount, J.Code, J.[Description]
FROM            [JobManagement].TravelExpenseJobs AS TEJ LEFT OUTER JOIN
                         [JobManagement].Jobs AS J ON TEJ.JobId = J.JobId LEFT OUTER JOIN
                         [JobManagement].TravelExpenseList ON TEJ.TravelExpenseCode = [JobManagement].TravelExpenseList.TravelExpenseCode


GO
/****** Object:  View [JobManagement].[JobTotalPeopleWorkedHours]    Script Date: 21/08/2016 07:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [JobManagement].[JobTotalPeopleWorkedHours]
AS
SELECT        JobId, PeopleId, SUM(WorkedHours) AS TotalHours
FROM            [JobManagement].WorksJournal
GROUP BY JobId, PeopleId


GO
ALTER TABLE [JobManagement].[GLAccountEntries] ADD  CONSTRAINT [DF_GLAccountEntries_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases] ADD  CONSTRAINT [DF_TravelExpensePurchases_QuotePercent]  DEFAULT ((100)) FOR [InPercent]
GO
ALTER TABLE [JobManagement].[WorksJournal] ADD  DEFAULT ((1)) FOR [WorkedHours]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [JobManagement].[GLAccountEntries]  WITH CHECK ADD  CONSTRAINT [FK_GLAccountEntries_GLAccount] FOREIGN KEY([GLAccountCode])
REFERENCES [JobManagement].[GLAccount] ([GLAccountCode])
GO
ALTER TABLE [JobManagement].[GLAccountEntries] CHECK CONSTRAINT [FK_GLAccountEntries_GLAccount]
GO
ALTER TABLE [JobManagement].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK_Job_Customer] FOREIGN KEY([CustomerId])
REFERENCES [JobManagement].[Customers] ([CustomerId])
GO
ALTER TABLE [JobManagement].[Jobs] CHECK CONSTRAINT [FK_Job_Customer]
GO
ALTER TABLE [JobManagement].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Job_JobState] FOREIGN KEY([Status])
REFERENCES [JobManagement].[JobStatus] ([JobStateId])
GO
ALTER TABLE [JobManagement].[Jobs] CHECK CONSTRAINT [FK_Job_JobState]
GO
ALTER TABLE [JobManagement].[Person]  WITH NOCHECK ADD  CONSTRAINT [FK_People_AspNetUsers] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [JobManagement].[Person] CHECK CONSTRAINT [FK_People_AspNetUsers]
GO
ALTER TABLE [JobManagement].[TravelExpenseJobs]  WITH NOCHECK ADD  CONSTRAINT [FK_TravelExpenseJobs_Job] FOREIGN KEY([JobId])
REFERENCES [JobManagement].[Jobs] ([JobId])
GO
ALTER TABLE [JobManagement].[TravelExpenseJobs] CHECK CONSTRAINT [FK_TravelExpenseJobs_Job]
GO
ALTER TABLE [JobManagement].[TravelExpenseJobs]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenseJobs_TravelExpense] FOREIGN KEY([TravelExpenseCode])
REFERENCES [JobManagement].[TravelExpenses] ([TravelExpenseCode])
GO
ALTER TABLE [JobManagement].[TravelExpenseJobs] CHECK CONSTRAINT [FK_TravelExpenseJobs_TravelExpense]
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases]  WITH NOCHECK ADD  CONSTRAINT [FK_TravelExpensePurchases_Purchase] FOREIGN KEY([PurchaseId])
REFERENCES [JobManagement].[Purchases] ([PurchaseId])
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases] CHECK CONSTRAINT [FK_TravelExpensePurchases_Purchase]
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpensePurchases_TravelExpense] FOREIGN KEY([TravelExpenseCode])
REFERENCES [JobManagement].[TravelExpenses] ([TravelExpenseCode])
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases] CHECK CONSTRAINT [FK_TravelExpensePurchases_TravelExpense]
GO
ALTER TABLE [JobManagement].[TravelExpenses]  WITH NOCHECK ADD  CONSTRAINT [FK_TravelExpense_People] FOREIGN KEY([PeopleId])
REFERENCES [JobManagement].[Person] ([PeopleId])
GO
ALTER TABLE [JobManagement].[TravelExpenses] CHECK CONSTRAINT [FK_TravelExpense_People]
GO
ALTER TABLE [JobManagement].[TravelExpenses]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpense_TravelExpenseStatus] FOREIGN KEY([Status])
REFERENCES [JobManagement].[TravelExpenseStatus] ([StatusId])
GO
ALTER TABLE [JobManagement].[TravelExpenses] CHECK CONSTRAINT [FK_TravelExpense_TravelExpenseStatus]
GO
ALTER TABLE [JobManagement].[TravelExpensesLines]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenseLine_TravelExpense] FOREIGN KEY([TravelExpenseCode])
REFERENCES [JobManagement].[TravelExpenses] ([TravelExpenseCode])
GO
ALTER TABLE [JobManagement].[TravelExpensesLines] CHECK CONSTRAINT [FK_TravelExpenseLine_TravelExpense]
GO
ALTER TABLE [JobManagement].[TravelExpensesLines]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenseLine_TravelExpenseLineCategories] FOREIGN KEY([TravelExpenseLineCategoryId])
REFERENCES [JobManagement].[TravelExpenseLineCategories] ([TravelExpenseLineCategoryId])
GO
ALTER TABLE [JobManagement].[TravelExpensesLines] CHECK CONSTRAINT [FK_TravelExpenseLine_TravelExpenseLineCategories]
GO
ALTER TABLE [JobManagement].[WorksJournal]  WITH NOCHECK ADD  CONSTRAINT [FK_JobWorkJournal_Job] FOREIGN KEY([JobId])
REFERENCES [JobManagement].[Jobs] ([JobId])
GO
ALTER TABLE [JobManagement].[WorksJournal] CHECK CONSTRAINT [FK_JobWorkJournal_Job]
GO
ALTER TABLE [JobManagement].[WorksJournal]  WITH NOCHECK ADD  CONSTRAINT [FK_JobWorkJournal_JobTask] FOREIGN KEY([JobTaskId])
REFERENCES [JobManagement].[JobTasks] ([JobTaskId])
GO
ALTER TABLE [JobManagement].[WorksJournal] CHECK CONSTRAINT [FK_JobWorkJournal_JobTask]
GO
ALTER TABLE [JobManagement].[WorksJournal]  WITH NOCHECK ADD  CONSTRAINT [FK_JobWorkJournal_Person] FOREIGN KEY([PeopleId])
REFERENCES [JobManagement].[Person] ([PeopleId])
GO
ALTER TABLE [JobManagement].[WorksJournal] CHECK CONSTRAINT [FK_JobWorkJournal_Person]
GO
/****** Object:  StoredProcedure [JobManagement].[spReportCustomerWork]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [JobManagement].[spReportCustomerWork]
    @CustomerId int,
    @BeginDate date,
    @EndDate date
AS
    SELECT w.*, J.[Code] as JobCode, J.[Description] as JobDesc, p.FirstName + ' ' + p.LastName as PeopleName  FROM [JobManagement].[Jobs] j LEFT JOIN [JobManagement].[WorksJournal] w ON j.[JobId] = w.[JobId]
    LEFT JOIN [JobManagement].[Person] p on w.PeopleId = p.PeopleId   
    WHERE j.CustomerId = @CustomerId AND w.[Date] >= @BeginDate AND w.[Date] <= @EndDate 
RETURN 0

GO
/****** Object:  StoredProcedure [JobManagement].[spReportPeopleWork]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [JobManagement].[spReportPeopleWork]
    @PeopleId int,
    @BeginDate date,
    @EndDate date
AS
    SELECT w.*, J.[Code] as JobCode, J.[Description] as JobDesc FROM [JobManagement].[WorksJournal] w LEFT JOIN [JobManagement].[Jobs] J ON w.[JobId] = J.[JobId]
    WHERE w.[Date] >= @BeginDate AND w.[Date] <= @EndDate AND w.[PeopleId] = @PeopleId
RETURN 0

GO
/****** Object:  StoredProcedure [JobManagement].[upCustomerDelete]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [JobManagement].[upCustomerDelete]
    @customerId int 
AS
    DECLARE @CanDeleteRecord bit = 1 -- 1 TRUE Cancello 0 FALSE Disattivo
    -- Se ci sono commesse non cancello ma disattivo
    IF EXISTS (SELECT TOP 1 1 FROM [JobManagement].[Jobs] WHERE [CustomerId] = @customerId) 
    BEGIN
        SET @CanDeleteRecord = 0;
    END

    IF (@CanDeleteRecord = 0) 
        UPDATE [JobManagement].[Customers] SET [Status] = 0 WHERE [CustomerId] = @customerId;
    ELSE
        DELETE FROM [JobManagement].[Customers] WHERE [CustomerId] = @customerId;

RETURN 0


GO
/****** Object:  StoredProcedure [JobManagement].[upJobAdd]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [JobManagement].[upJobAdd]
    @CustomerId bigint,
    @Code nvarchar(20),
    @Description nvarchar(150),
    @ExpectedWorkHours int,
    @ExpectedIncome decimal(18,4),
    @ExpectedCost decimal(18,4),
	@ExpectedStartDate date,
	@ExpectedFinishDate date,
	@Year int,
	@Status tinyint
AS
    DECLARE @JobId bigint;
	BEGIN TRANSACTION
    IF (@Code IS NULL) 
    BEGIN
        DECLARE @LastUsedNumber int;
        SELECT @LastUsedNumber = [LastUsedNumber] FROM [JobManagement].[AutoNumberBase] WHERE [Element] = 'Job.Code' AND [Year] = @Year;
        IF @LastUsedNumber IS NULL
		BEGIN
			INSERT INTO [JobManagement].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
			VALUES ('Job.Code',5,@Year);
			SET @LastUsedNumber = 5;
		END
		SET @LastUsedNumber += 1;
        DECLARE @LastUsedNumberStr nvarchar(20) = '000000' + CAST (@LastUsedNumber AS NVARCHAR(6))
        SET @Code = 'CO-' + CAST (@Year AS NVARCHAR(4)) + '-' +  RIGHT(@LastUsedNumberStr,6);
        UPDATE [JobManagement].[AutoNumberBase] SET [LastUsedNumber] = @LastUsedNumber
        WHERE [Element] = 'Job.Code' AND [Year] = @Year;
    END
    ELSE
    BEGIN
        IF EXISTS (SELECT JobId FROM [JobManagement].[Jobs] WHERE [Code] = @Code)
            BEGIN
                ROLLBACK TRANSACTION;
                RAISERROR (N'Errore: codice commessa già esistente',16,127) WITH NOWAIT;
            END
    END

    INSERT INTO [JobManagement].[Jobs]
           ([CustomerId]
           ,[Code]
           ,[Description]
           ,[ExpectedIncome]
           ,[ExpectedCost]
           ,[ExpectedWorkHours]
		   ,[ExpectedStartDate]
		   ,[ExpectedFinishDate]
		   ,[StartDate]
		   ,[FinishDate]
		   ,[Status]
		   ,[Year]
)
     VALUES
           (@CustomerId
           ,@Code
           ,@Description
           ,@ExpectedIncome
           ,@ExpectedCost
           ,@ExpectedWorkHours
		   ,@ExpectedStartDate
		   ,@ExpectedFinishDate
		   ,NULL
		   ,NULL
		   ,@Status
		   ,@Year);
	SET @JobId = SCOPE_IDENTITY();
    COMMIT TRANSACTION

	SELECT [JobId]
		  ,[CustomerId]
		  ,[Code]
		  ,[Description]
		  ,[ExpectedIncome]
		  ,[ExpectedCost]
		  ,[ExpectedWorkHours]
		  ,[Status]
		  ,[Year]
	  FROM [JobManagement].[Jobs]
	  WHERE [JobId] = @JobId;


GO
/****** Object:  StoredProcedure [JobManagement].[upJobDelete]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [JobManagement].[upJobDelete]
    @jobId int 
AS
    DECLARE @CanDeleteRecord bit = 1 -- 1 TRUE Cancello 0 FALSE Disattivo
    -- Se Non ci sono log di attività
    IF EXISTS (SELECT TOP 1 1 FROM [JobManagement].JobWorkJournal WHERE [JobId] = @jobId) 
    BEGIN
        SET @CanDeleteRecord = 0;
    END

    IF (@CanDeleteRecord = 0) 
        UPDATE [JobManagement].[Jobs] SET [Status] = 0 WHERE [JobId] = @jobId;
    ELSE
        DELETE FROM [JobManagement].[Jobs] WHERE [JobId] = @jobId;

RETURN 0


GO
/****** Object:  StoredProcedure [JobManagement].[upOreMensiliLavorateGiornaliero]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [JobManagement].[upOreMensiliLavorateGiornaliero]
	@PeopleId int, 
	@BeginDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @EndDate AS DATE = EOMONTH(@BeginDate);
	DECLARE @CurrentDate as Date = @BeginDate;
	DECLARE @TempTable TABLE
	(
		ResId int,  
		[Date] date,
		Ore decimal(5,2)
	)
	WHILE (@CurrentDate <= @EndDate) 
	BEGIN
		INSERT INTO @TempTable(ResId,[Date],Ore) 
		VALUES (@PeopleId, @CurrentDate, NULL);
		SET @CurrentDate = DATEADD(day,1,@CurrentDate);
	END;

	WITH T AS 
	(
		SELECT [PeopleId], [Date], SUM([WorkedHours]) as Ore FROM [JobManagement].WorksJournal
		WHERE [PeopleId] = @PeopleId AND [Date] >= @BeginDate AND [Date] <= @EndDate
		GROUP BY [PeopleId], [Date]
	)
	UPDATE @TempTable SET [Ore] = T.Ore
	FROM @TempTable TT LEFT OUTER JOIN  T ON TT.Date = T.Date;

	SELECT * FROM @TempTable;
END


GO
/****** Object:  StoredProcedure [JobManagement].[upTravelExpenseAdd]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [JobManagement].[upTravelExpenseAdd]
	-- Add the parameters for the stored procedure here
		@Date date,
        @Annotation nvarchar(max),
        @PeopleId int
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
	BEGIN TRY
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		DECLARE @Code nvarchar(20);
		DECLARE @LastUsedNumber int;
		DECLARE @Year int = DATEPART(year,@Date);
        SELECT @LastUsedNumber = [LastUsedNumber] FROM [JobManagement].[AutoNumberBase] WHERE [Element] = 'TravelExpense.Code' AND [Year] = @Year;
        IF @LastUsedNumber IS NULL
		BEGIN
			INSERT INTO [JobManagement].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
			VALUES ('TravelExpense.Code',0,@Year);
			SET @LastUsedNumber = 0;
		END
		SET @LastUsedNumber += 1;
        DECLARE @LastUsedNumberStr nvarchar(20) = '000000' + CAST (@LastUsedNumber AS NVARCHAR(6))
        SET @Code = 'ST' + CAST (@Year AS NVARCHAR(4)) + '-' +  RIGHT(@LastUsedNumberStr,6);
        UPDATE [JobManagement].[AutoNumberBase] SET [LastUsedNumber] = @LastUsedNumber
        WHERE [Element] = 'TravelExpense.Code' AND [Year] = @Year;
		
		IF  NOT @Annotation IS NULL 
			IF RTRIM(LTRIM(@Annotation)) = '' SET @Annotation = NULL;
		INSERT INTO [JobManagement].[TravelExpenses]
			   (
			   [TravelExpenseCode]
			   ,[Date]
			   ,[Annotation]
			   ,[Status]
			   ,[PeopleId])
		 VALUES
			   (
			   @Code
			   ,@Date
			   ,@Annotation
			   ,0
			   ,@PeopleId
			   );
	SELECT * FROM [JobManagement].[TravelExpenses] WHERE [TravelExpenseCode] = @Code;
	COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
	END CATCH

END





GO
/****** Object:  StoredProcedure [JobManagement].[upTravelExpenseAddPurchase]    Script Date: 21/08/2016 07:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [JobManagement].[upTravelExpenseAddPurchase]
	-- Add the parameters for the stored procedure here
	@TravelExpenseCode nvarchar(20),
	@PeopleId int,
	@BuyFromName nvarchar(100),
	@BuyFromCity nvarchar(100),
	@BuyFromCountry nvarchar(100),
	@BuyFromDocType int,
	@BuyFromDocNumber nvarchar(20),
	@BuyFromDocDate date,
	@Amount decimal(18,2),
	@AmountNoVat decimal(18,2),
	@Vat decimal(18,2),
	@Total decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [JobManagement].[Purchases]
           ([BuyFromName]
           ,[BuyFromCity]
           ,[BuyFromCountry]
           ,[BuyFromDocType]
           ,[BuyFromDocNumber]
           ,[BuyFromDocDate]
           ,[Amount]
           ,[AmountNoVat]
           ,[Vat]
           ,[Total]
           ,[DueDate])
     VALUES
           (@BuyFromName,
           @BuyFromCity, 
           @BuyFromCountry, 
           @BuyFromDocType, 
           @BuyFromDocNumber,
           @BuyFromDocDate, 
           @Amount, 
           @AmountNoVat, 
           @Vat, 
           @Total,
		   @BuyFromDocDate)

END

GO

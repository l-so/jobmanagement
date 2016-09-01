USE [JobManagement]
GO
/****** Object:  Schema [jm]    Script Date: 01/09/2016 16:40:16 ******/
CREATE SCHEMA [jm]
GO
/****** Object:  Schema [JobManagement]    Script Date: 01/09/2016 16:40:16 ******/
CREATE SCHEMA [JobManagement]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[AutoNumberBase]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[Customers]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[GeneralJournalLines]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[GeneralJournalLines](
	[GeneralJournalLineId] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[LineNumber] [int] NOT NULL,
	[Description] [nvarchar](75) NOT NULL,
	[DocumentReference] [nvarchar](1024) NULL,
	[Type] [nchar](1) NULL CONSTRAINT [DF_GeneralJournalLines_Type]  DEFAULT ('S'),
 CONSTRAINT [PK_GeneralJournalLines] PRIMARY KEY CLUSTERED 
(
	[GeneralJournalLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[GenerlaJournalLineEntries]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[GenerlaJournalLineEntries](
	[GenerlaJournalLineEntryId] [bigint] IDENTITY(1,1) NOT NULL,
	[GenerlaJournalLineId] [bigint] NOT NULL,
	[Position] [int] NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DebitCredit] [nchar](1) NOT NULL,
 CONSTRAINT [PK_GenerlaJournalLineEntries] PRIMARY KEY CLUSTERED 
(
	[GenerlaJournalLineEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[GLAccount]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[GLAccount](
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nchar](1) NULL,
	[SubType] [nchar](2) NULL,
	[BeginTotal] [nvarchar](20) NULL,
	[EndTotal] [nvarchar](20) NULL,
 CONSTRAINT [PK_GLAccount] PRIMARY KEY CLUSTERED 
(
	[GLAccountCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[JobCosts]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[JobCosts](
	[JobCostId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Type] [nchar](2) NOT NULL,
	[TravelExpenseCode] [nvarchar](20) NULL,
	[PurchaseInvoiceId] [bigint] NULL,
	[Percent] [smallint] NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_JobCosts] PRIMARY KEY CLUSTERED 
(
	[JobCostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[Jobs]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[JobStatus]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[JobTasks]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[Person]    Script Date: 01/09/2016 16:40:16 ******/
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
	[DebitAccount] [nvarchar](20) NULL,
	[CreditAccount] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[PurchaseInvoicePaidBy]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[PurchaseInvoicePaidBy](
	[PurchaseInvoicePaidById] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PurchaseInvoicePaidBy] PRIMARY KEY CLUSTERED 
(
	[PurchaseInvoicePaidById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[PurchaseInvoices]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[PurchaseInvoices](
	[PurchaseInvoiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[BuyFromVendorId] [bigint] NULL,
	[BuyFromName] [nvarchar](100) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[DueDate] [date] NULL,
	[PaidById] [int] NULL,
	[Status] [tinyint] NULL,
	[PostDate] [date] NULL,
	[PostLine] [int] NULL,
 CONSTRAINT [PK_PurchaseInvoices] PRIMARY KEY CLUSTERED 
(
	[PurchaseInvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpenseAutoCode]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[TravelExpenseLineCategories]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[TravelExpensePurchases]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[TravelExpenses]    Script Date: 01/09/2016 16:40:16 ******/
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
	[PostDate] [date] NULL,
	[PostLine] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[TravelExpensesLines]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[TravelExpenseStatus]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  Table [JobManagement].[Vendors]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[Vendors](
	[VendorId] [bigint] IDENTITY(1,1) NOT NULL,
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
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [JobManagement].[WorksJournal]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JobManagement].[WorksJournal](
	[WorkJournalId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Date] [date] NOT NULL,
	[WorkedHours] [decimal](5, 2) NOT NULL DEFAULT ((1)),
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
/****** Object:  View [JobManagement].[JobTotalWorkedHours]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  View [JobManagement].[JobList]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  View [JobManagement].[JobTotalPeopleWorkedHours]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  View [JobManagement].[TravelExpenseList]    Script Date: 01/09/2016 16:40:16 ******/
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
ALTER TABLE [JobManagement].[PurchaseInvoices] ADD  CONSTRAINT [DF_PurchaseInvoices_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [JobManagement].[PurchaseInvoices] ADD  CONSTRAINT [DF_PurchaseInvoices_Vat]  DEFAULT ((0)) FOR [Vat]
GO
ALTER TABLE [JobManagement].[TravelExpensePurchases] ADD  CONSTRAINT [DF_TravelExpensePurchases_QuotePercent]  DEFAULT ((100)) FOR [InPercent]
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
ALTER TABLE [JobManagement].[GenerlaJournalLineEntries]  WITH CHECK ADD  CONSTRAINT [FK_GenerlaJournalLineEntries_GeneralJournalLines] FOREIGN KEY([GenerlaJournalLineId])
REFERENCES [JobManagement].[GeneralJournalLines] ([GeneralJournalLineId])
GO
ALTER TABLE [JobManagement].[GenerlaJournalLineEntries] CHECK CONSTRAINT [FK_GenerlaJournalLineEntries_GeneralJournalLines]
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
ALTER TABLE [JobManagement].[PurchaseInvoices]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoices_PurchaseInvoicePaidBy] FOREIGN KEY([PaidById])
REFERENCES [JobManagement].[PurchaseInvoicePaidBy] ([PurchaseInvoicePaidById])
GO
ALTER TABLE [JobManagement].[PurchaseInvoices] CHECK CONSTRAINT [FK_PurchaseInvoices_PurchaseInvoicePaidBy]
GO
ALTER TABLE [JobManagement].[PurchaseInvoices]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseInvoices_Vendors] FOREIGN KEY([BuyFromVendorId])
REFERENCES [JobManagement].[Vendors] ([VendorId])
GO
ALTER TABLE [JobManagement].[PurchaseInvoices] CHECK CONSTRAINT [FK_PurchaseInvoices_Vendors]
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
/****** Object:  StoredProcedure [jm].[upPostPurchaseInvoices]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [jm].[upPostPurchaseInvoices]
	-- Add the parameters for the stored procedure here
	@PurchaseInvoiceId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
	BEGIN TRY
		DECLARE @PostDate date = getdate();
		DECLARE @PostPAccount nvarchar(20);
		DECLARE @Total decimal(18,2) = 0;		
		DECLARE @PostEAccount nvarchar(20);
		-- Insert statements for procedure here
		SELECT @PostPAccount = P.GLAccountCode, @PostEAccount=I.GLAccountCode, @Total=I.Amount + I.Vat FROM JobManagement.PurchaseInvoices I LEFT JOIN JobManagement.PurchaseInvoicePaidBy P ON I.PaidById = P.PurchaseInvoicePaidById WHERE I.PurchaseInvoiceId = @PurchaseInvoiceId;
		
		-- General Ledger = PostLine and PostPosition
		DECLARE @PostPosition int = 0;
		DECLARE @PostLine int = NULL;
		SELECT @PostLine = [LastUsedNumber] FROM [JobManagement].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@PostDate);
		IF @PostLine IS NULL
		BEGIN
			INSERT INTO [JobManagement].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
			VALUES ('GLAccountEntries.LineNumber',0,DATEPART(year,@PostDate));
			SET @PostLine = 0;
		END
		SET @PostLine += 1;
		UPDATE [JobManagement].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
		WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@PostDate);
		-- FINE General Ledger = PostLine and PostPosition

		DECLARE @DocReference nvarchar(1024) = '~/DisplayDocument/PurchaseInvoice/' + @PurchaseInvoiceId;
		DECLARE @GeneralJournalLineId bigint;
		INSERT INTO [JobManagement].[GeneralJournalLines]
           ([Date]
           ,[LineNumber]
           ,[Description]
           ,[DocumentReference]
		   ,[Type])
		VALUES
           (@PostDate
           ,@PostLine
           ,'Fattura di acquisto'
           ,@DocReference
		   ,'S')
		SET @GeneralJournalLineId = SCOPE_IDENTITY();
		INSERT INTO [JobManagement].[GenerlaJournalLineEntries]
				   ([GenerlaJournalLineId]
				   ,[Position]
				   ,[GLAccountCode]
				   ,[Amount]
				   ,[DebitCredit])
			 VALUES
				(@GeneralJournalLineId
				,@PostPosition
				,@PostPAccount
				,@Total
				,'A')
			SET @PostPosition += 1;
		INSERT INTO [JobManagement].[GenerlaJournalLineEntries]
				   ([GenerlaJournalLineId]
				   ,[Position]
				   ,[GLAccountCode]
				   ,[Amount]
				   ,[DebitCredit])
			 VALUES
				(@GeneralJournalLineId
				,@PostPosition
				,@PostEAccount
				,@Total
				,'D')
		UPDATE JobManagement.PurchaseInvoices
		SET Status = 1, PostDate = @PostDate, PostLine = @PostLine
		WHERE PurchaseInvoiceId = @PurchaseInvoiceId;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		SELECT  
		ERROR_NUMBER() AS ErrorNumber  
		,ERROR_SEVERITY() AS ErrorSeverity  
		,ERROR_STATE() AS ErrorState  
		,ERROR_PROCEDURE() AS ErrorProcedure  
		,ERROR_LINE() AS ErrorLine  
		,ERROR_MESSAGE() AS ErrorMessage;  
		ROLLBACK TRANSACTION;
	END CATCH


END

GO
/****** Object:  StoredProcedure [jm].[upPostTravelExpense]    Script Date: 01/09/2016 16:40:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================<Procedure_Name, sysname, ProcedureName> =================
CREATE PROCEDURE [jm].[upPostTravelExpense]
	-- Add the parameters for the stored procedure here
	@TravelExpenseCode nvarchar(20)
AS
BEGIN
	-- Costanti usate
	-- Conto per rimborsi spese
	DECLARE @TravelExpenseAccountCode nvarchar(20) = '63.01.01';

	SET NOCOUNT ON;
	BEGIN TRANSACTION
	BEGIN TRY
		
		DECLARE @PostPosition int = 0;
		DECLARE @PostDate date = getdate();
		DECLARE @PostLine int = NULL;
		SELECT @PostLine = [LastUsedNumber] FROM [JobManagement].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@PostDate);
		IF @PostLine IS NULL
		BEGIN
			INSERT INTO [JobManagement].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
			VALUES ('GLAccountEntries.LineNumber',0,DATEPART(year,@PostDate));
			SET @PostLine = 0;
		END
		SET @PostLine += 1;
		UPDATE [JobManagement].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
		WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@PostDate);
		DECLARE @PostPeopleAccountCode nvarchar(20) = null;
		DECLARE @Total decimal(18,2) = 0;
		DECLARE @PeopleId int;
		SELECT @PeopleId = MAX(PeopleId), @Total=MAX(Total) FROM JobManagement.TravelExpenseList WHERE TravelExpenseCode = @TravelExpenseCode;
		SELECT @PostPeopleAccountCode = DebitAccount  FROM [JobManagement].Person WHERE PeopleId = @PeopleId;
		DECLARE @DocReference nvarchar(1024) = '~/DisplayDocument/TravelExpense/' + @TravelExpenseCode;
		DECLARE @GeneralJournalLineId bigint;
		INSERT INTO [JobManagement].[GeneralJournalLines]
           ([Date]
           ,[LineNumber]
           ,[Description]
           ,[DocumentReference]
		   ,[Type])
		VALUES
           (@PostDate
           ,@PostLine
           ,'Spese di trasferta'
           ,@DocReference
		   ,'S')
		SET @GeneralJournalLineId = SCOPE_IDENTITY();
		INSERT INTO [JobManagement].[GenerlaJournalLineEntries]
				   ([GenerlaJournalLineId]
				   ,[Position]
				   ,[GLAccountCode]
				   ,[Amount]
				   ,[DebitCredit])
			 VALUES
				(@GeneralJournalLineId
				,@PostPosition
				,@PostPeopleAccountCode
				,@Total
				,'A')
			SET @PostPosition += 1;
		INSERT INTO [JobManagement].[GenerlaJournalLineEntries]
				   ([GenerlaJournalLineId]
				   ,[Position]
				   ,[GLAccountCode]
				   ,[Amount]
				   ,[DebitCredit])
			 VALUES
				(@GeneralJournalLineId
				,@PostPosition
				,@TravelExpenseAccountCode
				,@Total
				,'D')
		UPDATE [JobManagement].TravelExpenses
		SET Status = 1, PostDate = @PostDate, PostLine = @PostLine
		WHERE [TravelExpenseCode] = @TravelExpenseCode;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		SELECT  
		ERROR_NUMBER() AS ErrorNumber  
		,ERROR_SEVERITY() AS ErrorSeverity  
		,ERROR_STATE() AS ErrorState  
		,ERROR_PROCEDURE() AS ErrorProcedure  
		,ERROR_LINE() AS ErrorLine  
		,ERROR_MESSAGE() AS ErrorMessage;  
		ROLLBACK TRANSACTION;
	END CATCH
END

GO
/****** Object:  StoredProcedure [JobManagement].[spReportCustomerWork]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[spReportPeopleWork]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[upCustomerDelete]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[upJobAdd]    Script Date: 01/09/2016 16:40:16 ******/
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
        SET @Code = 'C' + RIGHT(CAST (@Year AS NVARCHAR(4)),2) + '-' +  RIGHT(@LastUsedNumberStr,6);
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
/****** Object:  StoredProcedure [JobManagement].[upJobDelete]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[upOreMensiliLavorateGiornaliero]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[upTravelExpenseAdd]    Script Date: 01/09/2016 16:40:16 ******/
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
/****** Object:  StoredProcedure [JobManagement].[upTravelExpenseAddPurchase]    Script Date: 01/09/2016 16:40:16 ******/
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

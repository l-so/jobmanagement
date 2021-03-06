USE [master]
GO
/****** Object:  Database [Job]    Script Date: 09/12/2016 16:23:34 ******/
CREATE DATABASE [Job]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Job', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Job.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Job_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Job_log.ldf' , SIZE = 5696KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Job] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Job].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Job] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Job] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Job] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Job] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Job] SET ARITHABORT OFF 
GO
ALTER DATABASE [Job] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Job] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Job] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Job] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Job] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Job] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Job] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Job] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Job] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Job] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Job] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Job] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Job] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Job] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Job] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Job] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Job] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Job] SET RECOVERY FULL 
GO
ALTER DATABASE [Job] SET  MULTI_USER 
GO
ALTER DATABASE [Job] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Job] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Job] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Job] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Job] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Job', N'ON'
GO
USE [Job]
GO
/****** Object:  User [IIS APPPOOL\JobAppPool]    Script Date: 09/12/2016 16:23:34 ******/
CREATE USER [IIS APPPOOL\JobAppPool] FOR LOGIN [IIS APPPOOL\JobAppPool] WITH DEFAULT_SCHEMA=[Job]
GO
/****** Object:  User [IIS APPPOOL\GeCo]    Script Date: 09/12/2016 16:23:34 ******/
CREATE USER [IIS APPPOOL\GeCo] FOR LOGIN [IIS APPPOOL\GeCo] WITH DEFAULT_SCHEMA=[Job]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\JobAppPool]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\GeCo]
GO
/****** Object:  Schema [Job]    Script Date: 09/12/2016 16:23:35 ******/
CREATE SCHEMA [Job]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 09/12/2016 16:23:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 09/12/2016 16:23:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 09/12/2016 16:23:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 09/12/2016 16:23:35 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 09/12/2016 16:23:35 ******/
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
/****** Object:  Table [Job].[AutoNumberBase]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[AutoNumberBase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Element] [nvarchar](50) NOT NULL,
	[LastUsedNumber] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Prefix] [nvarchar](4) NULL,
	[BaseNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[BankAccounts]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[BankAccounts](
	[Code] [nvarchar](5) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[IBAN] [nvarchar](50) NULL,
	[BalanceAssets] [nvarchar](20) NULL,
	[BalanceLiabilities] [nvarchar](20) NULL,
 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[CustomerBusinessGroup]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[CustomerBusinessGroup](
	[CustomerBusinessGroupId] [nvarchar](20) NOT NULL,
	[DebitAccount] [nvarchar](20) NOT NULL,
	[CreditAccount] [nvarchar](20) NOT NULL,
	[CreditVatAccount] [nvarchar](20) NOT NULL,
	[DebitVatAccount] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_CustomerBusinessGroup] PRIMARY KEY CLUSTERED 
(
	[CustomerBusinessGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[Customers]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[Customers](
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
	[Salutation] [nvarchar](50) NULL,
	[CustomerBusinessGroupId] [nvarchar](20) NULL,
	[IsInternal] [bit] NOT NULL CONSTRAINT [DF_Customers_IsInternal]  DEFAULT ((0)),
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Customers_IsActive]  DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[DocumentType]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[DocumentType](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_GeneralJournalLineEntryDocType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[GeneralJournalLineEntries]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[GeneralJournalLineEntries](
	[GenerlaJournalLineEntryId] [bigint] IDENTITY(1,1) NOT NULL,
	[GenerlaJournalLineId] [bigint] NOT NULL,
	[Position] [int] NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DebitCredit] [nchar](1) NOT NULL,
	[Date] [date] NULL,
	[Type] [nchar](1) NULL,
 CONSTRAINT [PK_GeneralJournalLineEntries] PRIMARY KEY CLUSTERED 
(
	[GenerlaJournalLineEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[GeneralJournalLines]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[GeneralJournalLines](
	[GeneralJournalLineId] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[LineNumber] [int] NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[DocumentReference] [nvarchar](1024) NULL,
	[Type] [nchar](1) NULL CONSTRAINT [DF_GeneralJournalLines_Type]  DEFAULT ('S'),
	[EntryDocCode] [nvarchar](50) NULL,
	[EntryDocType] [int] NULL,
 CONSTRAINT [PK_GeneralJournalLines] PRIMARY KEY CLUSTERED 
(
	[GeneralJournalLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[GLAccount]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[GLAccount](
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BeginTotal] [nvarchar](20) NULL,
	[EndTotal] [nvarchar](20) NULL,
	[EconomicoPatrimoniale] [nchar](1) NOT NULL,
	[TotaleAnalitico] [nchar](1) NOT NULL,
	[CostoRicavo] [nchar](1) NOT NULL,
 CONSTRAINT [PK_GLAccount] PRIMARY KEY CLUSTERED 
(
	[GLAccountCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[JobBalance]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[JobBalance](
	[JobBalanceId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DocumentCode] [nvarchar](50) NULL,
	[DocumentType] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_JobBalance] PRIMARY KEY CLUSTERED 
(
	[JobBalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[JobBusinessGroup]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[JobBusinessGroup](
	[JobBudgetBusinessGroupId] [nvarchar](20) NOT NULL,
	[Invoice] [nvarchar](20) NOT NULL,
	[TravelExpense] [nvarchar](20) NOT NULL,
	[OtherCosts] [nvarchar](20) NOT NULL,
	[Works] [nvarchar](20) NULL,
 CONSTRAINT [PK_JobBudgetBusinessGroup] PRIMARY KEY CLUSTERED 
(
	[JobBudgetBusinessGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[Jobs]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[Jobs](
	[JobId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](512) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Year] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[JobStatus]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[JobStatus](
	[JobStateId] [tinyint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_JobsState] PRIMARY KEY CLUSTERED 
(
	[JobStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[JobTasks]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[JobTasks](
	[JobId] [bigint] NOT NULL,
	[JobTaskId] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](75) NULL,
	[ExpectedInvoice] [decimal](18, 2) NULL,
	[ExpectedCost] [decimal](18, 2) NULL,
	[TaskBusinessGroup] [nvarchar](10) NULL,
	[ExpectedHoursOfWork] [int] NULL,
	[IncomePerHour] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobId] ASC,
	[JobTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[Person]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[Person](
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
	[MondayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_MondayExpectedHours]  DEFAULT ((0)),
	[TuesdayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_TuesdayExpectedHours]  DEFAULT ((0)),
	[WendsdayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_WendsdayExpectedHours]  DEFAULT ((0)),
	[ThursdayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_ThursdayExpectedHours]  DEFAULT ((0)),
	[FridayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_FridayExpectedHours]  DEFAULT ((0)),
	[SaturdayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_SaturdayExpectedHours]  DEFAULT ((0)),
	[SundayExpectedHours] [decimal](5, 2) NULL CONSTRAINT [DF_Person_SundayExpectedHours]  DEFAULT ((0)),
	[PersonBusinessAccountId] [nvarchar](20) NOT NULL,
	[CompensoMensile] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[PersonBusinessAccount]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[PersonBusinessAccount](
	[Code] [nvarchar](20) NOT NULL,
	[DebitAccountCode] [nvarchar](20) NULL,
	[CreditAccountCode] [nvarchar](20) NULL,
	[TravelExpenseAccountCode] [nvarchar](20) NULL,
	[TravelExpenseInvoiceAccountCode] [nvarchar](20) NULL,
	[CompensoAccountCode] [nvarchar](20) NULL,
	[TaxAccountCode] [nvarchar](20) NULL,
	[InpsAccountCode] [nvarchar](20) NULL,
 CONSTRAINT [PK_PersonBusinessAccount] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[PrePaymentRefound]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[PrePaymentRefound](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[GLAccountCode] [nvarchar](20) NOT NULL,
	[PeopleId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL CONSTRAINT [DF_PrePaymentRefound_Status]  DEFAULT ((0)),
 CONSTRAINT [PK_PrePaymentRefound] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Job].[PrePaymentRefoundCategory]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[PrePaymentRefoundCategory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_PrePaymentRefoundCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[TravelExpenseLineCategories]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[TravelExpenseLineCategories](
	[TravelExpenseLineCategoryId] [int] NOT NULL,
	[UsePersonalCar] [bit] NOT NULL DEFAULT ((0)),
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseLineCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[TravelExpenses]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[TravelExpenses](
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[Date] [date] NOT NULL,
	[Annotation] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL DEFAULT ((0)),
	[PeopleId] [int] NOT NULL,
	[PostDate] [date] NULL,
	[InvoiceAmount] [decimal](18, 2) NULL CONSTRAINT [DF_TravelExpenses_InvoiceAmount]  DEFAULT ((0)),
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[Amount] [decimal](18, 2) NOT NULL CONSTRAINT [DF_TravelExpenses_Amount]  DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[TravelExpenseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Job].[TravelExpensesLines]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[TravelExpensesLines](
	[TravelExpenseLineId] [bigint] IDENTITY(1,1) NOT NULL,
	[TravelExpenseCode] [nvarchar](20) NOT NULL,
	[Date] [date] NOT NULL,
	[TravelExpenseLineCategoryId] [int] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL DEFAULT ((0)),
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
/****** Object:  Table [Job].[TravelExpenseStatus]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[TravelExpenseStatus](
	[StatusId] [tinyint] NOT NULL DEFAULT ((0)),
	[Description] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[UnitOfMeasure]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[UnitOfMeasure](
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[InternationalStandardCode] [nvarchar](10) NULL,
 CONSTRAINT [PK_UnitOfMeasure] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Job].[WorksJournal]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Job].[WorksJournal](
	[WorkJournalId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Date] [date] NOT NULL,
	[WorkedHours] [decimal](5, 2) NOT NULL DEFAULT ((1)),
	[TaskWhere] [nvarchar](160) NULL,
	[Annotation] [nvarchar](max) NULL,
	[JobTaskId] [nvarchar](10) NOT NULL,
	[PeopleId] [int] NOT NULL,
 CONSTRAINT [PK_JobWorkJournal] PRIMARY KEY CLUSTERED 
(
	[WorkJournalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [Job].[JobActual]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[JobActual]
AS
SELECT        JobId, SUM(WorkedHours) AS TotalHours, MIN(Date) AS BeginDate, MAX(Date) AS EndDate
FROM            Job.WorksJournal
GROUP BY JobId

GO
/****** Object:  View [Job].[JobExpected]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[JobExpected]
AS
SELECT        JobId, SUM(ExpectedInvoice) AS ExpectedIncome, SUM(ExpectedCost) AS ExpectedCost, SUM(ExpectedHoursOfWork) AS ExpectedWorks
FROM            Job.JobTasks
GROUP BY JobId

GO
/****** Object:  View [Job].[JobList]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[JobList]
AS
SELECT        J.JobId, J.CustomerId, J.Code, J.Description, J.Status, J.Year, JS.Description AS StatusDescription, C.Name AS CustomerName, C.Name2 AS CustomerName2, C.FullName AS CustomerFullName, 
                         COALESCE (JA.TotalHours, 0) AS ActualHours, JA.BeginDate AS ActualBegin, JA.EndDate AS ActualEnd, JE.ExpectedIncome, JE.ExpectedCost, JE.ExpectedWorks
FROM            Job.Jobs AS J LEFT OUTER JOIN
                         Job.JobExpected AS JE ON J.JobId = JE.JobId LEFT OUTER JOIN
                         Job.JobActual AS JA ON J.JobId = JA.JobId LEFT OUTER JOIN
                         Job.Customers AS C ON J.CustomerId = C.CustomerId LEFT OUTER JOIN
                         Job.JobStatus AS JS ON J.Status = JS.JobStateId

GO
/****** Object:  View [Job].[JobTotalPeopleWorkedHours]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[JobTotalPeopleWorkedHours]
AS
SELECT        [Job].WorksJournal.JobId, [Job].WorksJournal.PeopleId, SUM([Job].WorksJournal.WorkedHours) AS TotalHours, [Job].Person.FirstName, 
                         [Job].Person.LastName, [Job].Person.CompanyName
FROM            [Job].WorksJournal INNER JOIN
                         [Job].Person ON [Job].WorksJournal.PeopleId = [Job].Person.PeopleId
GROUP BY [Job].WorksJournal.JobId, [Job].WorksJournal.PeopleId, [Job].Person.FirstName, [Job].Person.LastName, [Job].Person.CompanyName


GO
/****** Object:  View [Job].[JobWorkList]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[JobWorkList]
AS
SELECT        DATEPART(YEAR, Job.WorksJournal.Date) * 100 + DATEPART(MONTH, Job.WorksJournal.Date) AS YearMonth, DATEPART(YEAR, Job.WorksJournal.Date) AS Year, DATEPART(MONTH, Job.WorksJournal.Date) 
                         AS Month, Job.WorksJournal.JobId, SUM(Job.WorksJournal.WorkedHours) AS WorkedHour, Job.WorksJournal.TaskWhere, Job.WorksJournal.PeopleId
FROM            Job.Person INNER JOIN
                         Job.WorksJournal ON Job.Person.PeopleId = Job.WorksJournal.PeopleId
GROUP BY DATEPART(YEAR, Job.WorksJournal.Date), DATEPART(MONTH, Job.WorksJournal.Date), Job.WorksJournal.JobId, Job.WorksJournal.TaskWhere, Job.WorksJournal.PeopleId

GO
/****** Object:  View [Job].[TravelExpenseList]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Job].[TravelExpenseList]
AS
SELECT        TE.TravelExpenseCode, TE.Date, TE.Annotation, TE.Status, P.PeopleId, P.FirstName, P.LastName, P.Code, MIN(TEL.Date) AS BeginDate, MAX(TEL.Date) AS EndDate, SUM(TEL.Amount) AS Total, 
                         TE.InvoiceAmount
FROM            Job.TravelExpenses AS TE LEFT OUTER JOIN
                         Job.Person AS P ON TE.PeopleId = P.PeopleId LEFT OUTER JOIN
                         Job.TravelExpensesLines AS TEL ON TE.TravelExpenseCode = TEL.TravelExpenseCode
GROUP BY TE.TravelExpenseCode, TE.Date, TE.Annotation, TE.Status, P.PeopleId, P.FirstName, P.LastName, P.Code, TE.InvoiceAmount

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ElementYear_Unique]    Script Date: 09/12/2016 16:23:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ElementYear_Unique] ON [Job].[AutoNumberBase]
(
	[Element] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [Job].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerBusinessGroup] FOREIGN KEY([CustomerBusinessGroupId])
REFERENCES [Job].[CustomerBusinessGroup] ([CustomerBusinessGroupId])
GO
ALTER TABLE [Job].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerBusinessGroup]
GO
ALTER TABLE [Job].[GeneralJournalLineEntries]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournalLineEntries_GeneralJournalLines] FOREIGN KEY([GenerlaJournalLineId])
REFERENCES [Job].[GeneralJournalLines] ([GeneralJournalLineId])
GO
ALTER TABLE [Job].[GeneralJournalLineEntries] CHECK CONSTRAINT [FK_GeneralJournalLineEntries_GeneralJournalLines]
GO
ALTER TABLE [Job].[GeneralJournalLineEntries]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournalLineEntries_GLAccount] FOREIGN KEY([GLAccountCode])
REFERENCES [Job].[GLAccount] ([GLAccountCode])
GO
ALTER TABLE [Job].[GeneralJournalLineEntries] CHECK CONSTRAINT [FK_GeneralJournalLineEntries_GLAccount]
GO
ALTER TABLE [Job].[GeneralJournalLines]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournalLines_GeneralJournalLineEntryDocType] FOREIGN KEY([EntryDocType])
REFERENCES [Job].[DocumentType] ([Id])
GO
ALTER TABLE [Job].[GeneralJournalLines] CHECK CONSTRAINT [FK_GeneralJournalLines_GeneralJournalLineEntryDocType]
GO
ALTER TABLE [Job].[JobBalance]  WITH CHECK ADD  CONSTRAINT [FK_JobBalance_DocumentType] FOREIGN KEY([DocumentType])
REFERENCES [Job].[DocumentType] ([Id])
GO
ALTER TABLE [Job].[JobBalance] CHECK CONSTRAINT [FK_JobBalance_DocumentType]
GO
ALTER TABLE [Job].[JobBalance]  WITH CHECK ADD  CONSTRAINT [FK_JobBalance_GLAccount] FOREIGN KEY([GLAccountCode])
REFERENCES [Job].[GLAccount] ([GLAccountCode])
GO
ALTER TABLE [Job].[JobBalance] CHECK CONSTRAINT [FK_JobBalance_GLAccount]
GO
ALTER TABLE [Job].[JobBalance]  WITH CHECK ADD  CONSTRAINT [FK_JobBalance_Jobs] FOREIGN KEY([JobId])
REFERENCES [Job].[Jobs] ([JobId])
GO
ALTER TABLE [Job].[JobBalance] CHECK CONSTRAINT [FK_JobBalance_Jobs]
GO
ALTER TABLE [Job].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK_Job_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Job].[Customers] ([CustomerId])
GO
ALTER TABLE [Job].[Jobs] CHECK CONSTRAINT [FK_Job_Customer]
GO
ALTER TABLE [Job].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Job_JobState] FOREIGN KEY([Status])
REFERENCES [Job].[JobStatus] ([JobStateId])
GO
ALTER TABLE [Job].[Jobs] CHECK CONSTRAINT [FK_Job_JobState]
GO
ALTER TABLE [Job].[JobTasks]  WITH CHECK ADD  CONSTRAINT [FK_JobTasks_Jobs] FOREIGN KEY([JobId])
REFERENCES [Job].[Jobs] ([JobId])
GO
ALTER TABLE [Job].[JobTasks] CHECK CONSTRAINT [FK_JobTasks_Jobs]
GO
ALTER TABLE [Job].[Person]  WITH NOCHECK ADD  CONSTRAINT [FK_People_AspNetUsers] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [Job].[Person] CHECK CONSTRAINT [FK_People_AspNetUsers]
GO
ALTER TABLE [Job].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_PersonBusinessAccount] FOREIGN KEY([PersonBusinessAccountId])
REFERENCES [Job].[PersonBusinessAccount] ([Code])
GO
ALTER TABLE [Job].[Person] CHECK CONSTRAINT [FK_Person_PersonBusinessAccount]
GO
ALTER TABLE [Job].[PrePaymentRefound]  WITH CHECK ADD  CONSTRAINT [FK_PrePaymentRefound_GLAccount] FOREIGN KEY([GLAccountCode])
REFERENCES [Job].[GLAccount] ([GLAccountCode])
GO
ALTER TABLE [Job].[PrePaymentRefound] CHECK CONSTRAINT [FK_PrePaymentRefound_GLAccount]
GO
ALTER TABLE [Job].[PrePaymentRefound]  WITH CHECK ADD  CONSTRAINT [FK_PrePaymentRefound_Person] FOREIGN KEY([PeopleId])
REFERENCES [Job].[Person] ([PeopleId])
GO
ALTER TABLE [Job].[PrePaymentRefound] CHECK CONSTRAINT [FK_PrePaymentRefound_Person]
GO
ALTER TABLE [Job].[TravelExpenses]  WITH NOCHECK ADD  CONSTRAINT [FK_TravelExpense_People] FOREIGN KEY([PeopleId])
REFERENCES [Job].[Person] ([PeopleId])
GO
ALTER TABLE [Job].[TravelExpenses] CHECK CONSTRAINT [FK_TravelExpense_People]
GO
ALTER TABLE [Job].[TravelExpenses]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpense_TravelExpenseStatus] FOREIGN KEY([Status])
REFERENCES [Job].[TravelExpenseStatus] ([StatusId])
GO
ALTER TABLE [Job].[TravelExpenses] CHECK CONSTRAINT [FK_TravelExpense_TravelExpenseStatus]
GO
ALTER TABLE [Job].[TravelExpensesLines]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenseLine_TravelExpense] FOREIGN KEY([TravelExpenseCode])
REFERENCES [Job].[TravelExpenses] ([TravelExpenseCode])
GO
ALTER TABLE [Job].[TravelExpensesLines] CHECK CONSTRAINT [FK_TravelExpenseLine_TravelExpense]
GO
ALTER TABLE [Job].[TravelExpensesLines]  WITH CHECK ADD  CONSTRAINT [FK_TravelExpenseLine_TravelExpenseLineCategories] FOREIGN KEY([TravelExpenseLineCategoryId])
REFERENCES [Job].[TravelExpenseLineCategories] ([TravelExpenseLineCategoryId])
GO
ALTER TABLE [Job].[TravelExpensesLines] CHECK CONSTRAINT [FK_TravelExpenseLine_TravelExpenseLineCategories]
GO
ALTER TABLE [Job].[WorksJournal]  WITH NOCHECK ADD  CONSTRAINT [FK_JobWorkJournal_Person] FOREIGN KEY([PeopleId])
REFERENCES [Job].[Person] ([PeopleId])
GO
ALTER TABLE [Job].[WorksJournal] CHECK CONSTRAINT [FK_JobWorkJournal_Person]
GO
ALTER TABLE [Job].[WorksJournal]  WITH CHECK ADD  CONSTRAINT [FK_WorksJournal_JobTasks] FOREIGN KEY([JobId], [JobTaskId])
REFERENCES [Job].[JobTasks] ([JobId], [JobTaskId])
GO
ALTER TABLE [Job].[WorksJournal] CHECK CONSTRAINT [FK_WorksJournal_JobTasks]
GO
/****** Object:  StoredProcedure [Job].[spReportCustomerWork]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Job].[spReportCustomerWork]
    @CustomerId int,
    @BeginDate date,
    @EndDate date
AS
    SELECT w.*, J.[Code] as JobCode, J.[Description] as JobDesc, p.FirstName + ' ' + p.LastName as PeopleName  FROM [Job].[Jobs] j LEFT JOIN [Job].[WorksJournal] w ON j.[JobId] = w.[JobId]
    LEFT JOIN [Job].[Person] p on w.PeopleId = p.PeopleId   
    WHERE j.CustomerId = @CustomerId AND w.[Date] >= @BeginDate AND w.[Date] <= @EndDate 
RETURN 0


GO
/****** Object:  StoredProcedure [Job].[spReportPeopleWork]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Job].[spReportPeopleWork]
    @PeopleId int,
    @BeginDate date,
    @EndDate date
AS
    SELECT w.*, J.[Code] as JobCode, J.[Description] as JobDesc FROM [Job].[WorksJournal] w LEFT JOIN [Job].[Jobs] J ON w.[JobId] = J.[JobId]
    WHERE w.[Date] >= @BeginDate AND w.[Date] <= @EndDate AND w.[PeopleId] = @PeopleId
RETURN 0


GO
/****** Object:  StoredProcedure [Job].[upCustomerDelete]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Job].[upCustomerDelete]
    @customerId int 
AS
    DECLARE @CanDeleteRecord bit = 1 -- 1 TRUE Cancello 0 FALSE Disattivo
    -- Se ci sono commesse non cancello ma disattivo
    IF EXISTS (SELECT TOP 1 1 FROM [Job].[Jobs] WHERE [CustomerId] = @customerId) 
    BEGIN
        SET @CanDeleteRecord = 0;
    END

    IF (@CanDeleteRecord = 0) 
        UPDATE [Job].[Customers] SET [Status] = 0 WHERE [CustomerId] = @customerId;
    ELSE
        DELETE FROM [Job].[Customers] WHERE [CustomerId] = @customerId;

RETURN 0



GO
/****** Object:  StoredProcedure [Job].[upGetElementNumber]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Job].[upGetElementNumber] 
	-- Add the parameters for the stored procedure here
	@Element nvarchar(50),
	@Year int,
	@ResultId nvarchar(20) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION
	BEGIN TRY
    -- Insert statements for procedure here
	    DECLARE @LastUsedNumber int;
		DECLARE @Prefix nvarchar(4);
		DECLARE @BaseNumber int;
        SELECT @LastUsedNumber = [LastUsedNumber], @Prefix=[Prefix] FROM [Job].[AutoNumberBase] WHERE [Element] = @Element AND [Year] = @Year;
        IF @LastUsedNumber IS NULL
		BEGIN
			SELECT @Prefix=[Prefix], @BaseNumber = [BaseNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = @Element AND [Year] = (@Year - 1);
			INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year],[Prefix])
			VALUES (@Element,@BaseNumber,@Year,@Prefix);
			SET @LastUsedNumber = @BaseNumber;
		END
		SET @LastUsedNumber += 1;
        DECLARE @LastUsedNumberStr nvarchar(5) =  RIGHT('000000' + CAST (@LastUsedNumber AS NVARCHAR(5)),5);
		IF (@Prefix IS NOT NULL)
		BEGIN
			SET @ResultId = COALESCE(@Prefix,'') + RIGHT(CAST (@Year AS NVARCHAR(4)),2) + '-' + @LastUsedNumberStr;
		END
		ELSE
		BEGIN
			SET @ResultId = @LastUsedNumberStr;
		END
        
		UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @LastUsedNumber
        WHERE [Element] = @Element AND [Year] = @Year;
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END


GO
/****** Object:  StoredProcedure [Job].[upJobAdd]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Job].[upJobAdd]
    @CustomerId bigint,
    @Code nvarchar(20),
    @Description nvarchar(150),
	@Year int,
	@Status tinyint
AS
    DECLARE @JobId bigint;
	BEGIN TRANSACTION
BEGIN TRY
    IF (@Code IS NULL) 
    BEGIN
        DECLARE @LastUsedNumber int;
		DECLARE @Prefix nvarchar(4);
        SELECT @LastUsedNumber = [LastUsedNumber], @Prefix=[Prefix] FROM [Job].[AutoNumberBase] WHERE [Element] = 'Job.Code' AND [Year] = @Year;
        IF @LastUsedNumber IS NULL
		BEGIN
			SELECT @Prefix=[Prefix] FROM [Job].[AutoNumberBase] WHERE [Element] = 'Job.Code' AND [Year] = (@Year - 1);
			INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year],[Prefix])
			VALUES ('Job.Code',5,@Year,@Prefix);
			SET @LastUsedNumber = 5;
		END
		SET @LastUsedNumber += 1;
        DECLARE @LastUsedNumberStr nvarchar(5) =  RIGHT('0000' + CAST (@LastUsedNumber AS NVARCHAR(5)),5);
        SET @Code = COALESCE(@Prefix,'') + RIGHT(CAST (@Year AS NVARCHAR(4)),2) + '-' + @LastUsedNumberStr;
        UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @LastUsedNumber
        WHERE [Element] = 'Job.Code' AND [Year] = @Year;
    END
    ELSE
    BEGIN
        IF EXISTS (SELECT JobId FROM [Job].[Jobs] WHERE [Code] = @Code)
            BEGIN
                ROLLBACK TRANSACTION;
                RAISERROR (N'Errore: codice commessa già esistente',16,127) WITH NOWAIT;
            END
    END

    INSERT INTO [Job].[Jobs]
           ([CustomerId]
           ,[Code]
           ,[Description]
		   ,[Status]
		   ,[Year]
)
     VALUES
           (@CustomerId
           ,@Code
           ,@Description
		   ,@Status
		   ,@Year);
	SET @JobId = SCOPE_IDENTITY();
    COMMIT TRANSACTION

	SELECT [JobId]
		  ,[CustomerId]
		  ,[Code]
		  ,[Description]
		  ,[Status]
		  ,[Year]
	  FROM [Job].[Jobs]
	  WHERE [JobId] = @JobId;
END TRY
BEGIN CATCH
	--SELECT  
	--ERROR_NUMBER() AS ErrorNumber  
	--,ERROR_SEVERITY() AS ErrorSeverity  
	--,ERROR_STATE() AS ErrorState  
	--,ERROR_PROCEDURE() AS ErrorProcedure  
	--,ERROR_LINE() AS ErrorLine  
	--,ERROR_MESSAGE() AS ErrorMessage;  
	ROLLBACK TRANSACTION;
	THROW;
END CATCH



GO
/****** Object:  StoredProcedure [Job].[upJobDelete]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Job].[upJobDelete]
    @jobId int 
AS
    DECLARE @CanDeleteRecord bit = 1 -- 1 TRUE Cancello 0 FALSE Disattivo
    -- Se Non ci sono log di attività
    IF EXISTS (SELECT TOP 1 1 FROM [Job].JobWorkJournal WHERE [JobId] = @jobId) 
    BEGIN
        SET @CanDeleteRecord = 0;
    END

    IF (@CanDeleteRecord = 0) 
        UPDATE [Job].[Jobs] SET [Status] = 0 WHERE [JobId] = @jobId;
    ELSE
        DELETE FROM [Job].[Jobs] WHERE [JobId] = @jobId;

RETURN 0



GO
/****** Object:  StoredProcedure [Job].[upOreMensiliLavorateGiornaliero]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Job].[upOreMensiliLavorateGiornaliero]
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
		SELECT [PeopleId], [Date], SUM([WorkedHours]) as Ore FROM [Job].WorksJournal
		WHERE [PeopleId] = @PeopleId AND [Date] >= @BeginDate AND [Date] <= @EndDate
		GROUP BY [PeopleId], [Date]
	)
	UPDATE @TempTable SET [Ore] = T.Ore
	FROM @TempTable TT LEFT OUTER JOIN  T ON TT.Date = T.Date;

	SELECT * FROM @TempTable;
END



GO
/****** Object:  StoredProcedure [Job].[upPostExpensePaymentRefound]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================<Procedure_Name, sysname, ProcedureName> =================
CREATE PROCEDURE [Job].[upPostExpensePaymentRefound]
	-- Add the parameters for the stored procedure here
	@Id bigint
AS
BEGIN
	IF EXISTS (SELECT * FROM  [Job].[ExpensePaymentRefound] WHERE [Id] = @Id AND [Status] = 0) 
	BEGIN
		SET NOCOUNT ON;	
		BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @PostDate date = getdate();
			DECLARE @Total decimal(18,2) = 0;
			DECLARE @PeopleId bigint = 0;
			DECLARE @GLAccountCode nvarchar(20);
			DECLARE @PostPeopleAccountCode nvarchar(20) = null;
			DECLARE @PeopleFullName nvarchar(250);
			SELECT @PostDate = MAX(E.[Date]), @GLAccountCode = MAX(E.[GLAccountCode]),@Total = MAX(E.[Amount]), @PeopleId = MAX(P.[PeopleId]) , @PeopleFullName = '[' + MAX(P.[Code]) + '] ' + RTRIM(MAX(P.[FirstName]) + ' ' + MAX(P.[LastName])), @PostPeopleAccountCode = MAX(B.[DebitAccountCode])
				  FROM [Job].[ExpensePaymentRefound] E INNER JOIN [Job].[Person] P ON E.[PeopleId] = P.[PeopleId]
				  INNER JOIN [Job].[PersonBusinessAccount] B ON P.[PersonBusinessAccountId] = B.Code
				  WHERE E.[Id] = @Id;
		
			DECLARE @PeopleCode nvarchar(10) = '00000' + CAST(@PeopleId as nvarchar(4));
			SET @PostPeopleAccountCode = @PostPeopleAccountCode + '.' + RIGHT(@PeopleCode,4);
			DECLARE @PostYear int = DATEPART(YEAR,@PostDate);
			DECLARE @PostPosition int = 0;
			DECLARE @PostLine int = NULL;

			SELECT @PostLine = [LastUsedNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = @PostYear;
			IF @PostLine IS NULL
			BEGIN
				INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
				VALUES ('GLAccountEntries.LineNumber',0,@PostYear);
				SET @PostLine = 1;
			END
			SET @PostLine += 1;
			UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
				WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = @PostYear;

				DECLARE @DocReference nvarchar(1024) = '~/DisplayDocument/ExpensePaymentRefound/' + CAST(@Id as nvarchar(20));
				DECLARE @GeneralJournalLineId bigint;
				INSERT INTO [Job].[GeneralJournalLines]
					([Date]
					,[LineNumber]
					,[Description]
					,[DocumentReference]
					,[Type])
				VALUES
					(@PostDate
					,@PostLine
					,'Rimborso fattura anticipate ' + @PeopleFullName
					,@DocReference
					,'S');
				SET @GeneralJournalLineId = SCOPE_IDENTITY();

				INSERT INTO [Job].[GeneralJournalLineEntries]
					([GenerlaJournalLineId]
					,[Date]
					,[Position]
					,[GLAccountCode]
					,[Amount]
					,[DebitCredit])
				VALUES
					(@GeneralJournalLineId
					,@PostDate
					,@PostPosition
					,@PostPeopleAccountCode
					,@Total
					,'A');

				SET @PostPosition += 1;

				INSERT INTO [Job].[GeneralJournalLineEntries]
					([GenerlaJournalLineId]
					,[Date]
					,[Position]
					,[GLAccountCode]
					,[Amount]
					,[DebitCredit])
				VALUES
					(@GeneralJournalLineId
					,@PostDate
					,@PostPosition
					,@GLAccountCode
					,@Total
					,'D');

				UPDATE [Job].[ExpensePaymentRefound]
					SET Status = 1
					WHERE [Id] = @Id;

			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			--SELECT  
			--ERROR_NUMBER() AS ErrorNumber  
			--,ERROR_SEVERITY() AS ErrorSeverity  
			--,ERROR_STATE() AS ErrorState  
			--,ERROR_PROCEDURE() AS ErrorProcedure  
			--,ERROR_LINE() AS ErrorLine  
			--,ERROR_MESSAGE() AS ErrorMessage;  
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH
	END

END



GO
/****** Object:  StoredProcedure [Job].[upPostPaymentToPerson]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Job].[upPostPaymentToPerson]
	-- Add the parameters for the stored procedure here
	@Date date,
	@PeopleId int,
	@Compenso decimal(18,2),
	@Tasse decimal(18,2),
	@INPS decimal(18,2),
	@BankAccount nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRANSACTION
	BEGIN TRY
		-- General Ledger = PostLine and PostPosition
		DECLARE @PostPosition int = 0;
		DECLARE @PostLine int = NULL;
		DECLARE @PostPeopleDebitAccount nvarchar(20);
		DECLARE @DocReference nvarchar(1024) = NULL;
		DECLARE @GeneralJournalLineId bigint;
		DECLARE @PeopleFullName nvarchar(256);
		DECLARE @CompensoCostAccount nvarchar(20) = '';
		DECLARE @TasseCostAccount nvarchar(20) = '';
		DECLARE @INPSCostAccount nvarchar(20) = '';

		SELECT @PostPeopleDebitAccount = MAX(B.[DebitAccountCode]),
		@CompensoCostAccount = MAX(B.[CompensoAccountCode]),
		@TasseCostAccount = MAX(B.[TaxAccountCode]),
		@INPSCostAccount = MAX(B.[InpsAccountCode]),
		@PeopleFullName = RTRIM(RTRIM(MAX(P.[FirstName])) + ' ' + MAX(P.[LastName]))
		FROM [Job].[Person] P INNER JOIN [Job].[PersonBusinessAccount] B ON P.[PersonBusinessAccountId] = B.[Code] WHERE P.PeopleId = @PeopleId;

		DECLARE @PeopleCode nvarchar(10) = '00000' + CAST(@PeopleId as nvarchar(4));
		SET @PeopleCode = '.' + RIGHT(@PeopleCode,4);
		SET @PostPeopleDebitAccount = @PostPeopleDebitAccount + @PeopleCode;
		SET @CompensoCostAccount = @CompensoCostAccount + @PeopleCode;
		SET @TasseCostAccount  = @TasseCostAccount + @PeopleCode;
		SET @INPSCostAccount  = @INPSCostAccount + @PeopleCode;
		IF (COALESCE(@Tasse,0) > 0) 
		BEGIN
			-- General Ledger = PostLine and PostPosition;
			SELECT @PostLine = [LastUsedNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			IF @PostLine IS NULL
			BEGIN
				INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
				VALUES ('GLAccountEntries.LineNumber',0,DATEPART(year,@Date));
				SET @PostLine = 1;
			END
			SET @PostLine += 1;
			UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
			WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			-- FINE General Ledger = PostLine and PostPosition
			SET @PostPosition = 0;
			INSERT INTO [Job].[GeneralJournalLines]
			   ([Date]
			   ,[LineNumber]
			   ,[Description]
			   ,[DocumentReference]
			   ,[Type])
			VALUES
			   (@Date
			   ,@PostLine
			   ,@PeopleFullName + ' - Registrazione Tasse e Balzelli'
			   ,@DocReference
			   ,'S')
			SET @GeneralJournalLineId = SCOPE_IDENTITY();
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@TasseCostAccount
					,@Tasse
					,'D'
					,@Date);
			SET @PostPosition += 1;
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@PostPeopleDebitAccount
					,@Tasse
					,'A'
					,@Date);
		END
		IF (COALESCE(@INPS,0) > 0) 
		BEGIN
			-- General Ledger = PostLine and PostPosition;
			SELECT @PostLine = [LastUsedNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			IF @PostLine IS NULL
			BEGIN
				INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
				VALUES ('GLAccountEntries.LineNumber',0,DATEPART(year,@Date));
				SET @PostLine = 1;
			END
			SET @PostLine += 1;
			UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
			WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			-- FINE General Ledger = PostLine and PostPosition
			SET @PostPosition = 0;
			INSERT INTO [Job].[GeneralJournalLines]
			   ([Date]
			   ,[LineNumber]
			   ,[Description]
			   ,[DocumentReference]
			   ,[Type])
			VALUES
			   (@Date
			   ,@PostLine
			   ,@PeopleFullName + ' - Registrazione INPS'
			   ,@DocReference
			   ,'S')
			SET @GeneralJournalLineId = SCOPE_IDENTITY();
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@INPSCostAccount
					,@INPS
					,'D'
					,@Date);
			SET @PostPosition += 1;
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@PostPeopleDebitAccount
					,@INPS
					,'A'
					,@Date);
		END
		DECLARE @Total decimal(18,2) = COALESCE(@Compenso,0) + COALESCE(@Tasse,0) + COALESCE(@INPS,0);
		IF (@Total > 0) 
		BEGIN
			-- General Ledger = PostLine and PostPosition;
			SELECT @PostLine = [LastUsedNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			IF @PostLine IS NULL
			BEGIN
				INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
				VALUES ('GLAccountEntries.LineNumber',0,DATEPART(year,@Date));
				SET @PostLine = 1;
			END
			SET @PostLine += 1;
			UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
			WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = DATEPART(year,@Date);
			-- FINE General Ledger = PostLine and PostPosition
			SET @PostPosition = 0;
			INSERT INTO [Job].[GeneralJournalLines]
			   ([Date]
			   ,[LineNumber]
			   ,[Description]
			   ,[DocumentReference]
			   ,[Type])
			VALUES
			   (@Date
			   ,@PostLine
			   ,@PeopleFullName + ' - Pagamento'
			   ,@DocReference
			   ,'S')
			SET @GeneralJournalLineId = SCOPE_IDENTITY();
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@PostPeopleDebitAccount
					,@Total
					,'D'
					,@Date);
			SET @PostPosition += 1;
			INSERT INTO [Job].[GeneralJournalLineEntries]
					   ([GenerlaJournalLineId]
					   ,[Position]
					   ,[GLAccountCode]
					   ,[Amount]
					   ,[DebitCredit]
					   ,[Date])
				 VALUES
					(@GeneralJournalLineId
					,@PostPosition
					,@BankAccount
					,@Total
					,'A'
					,@Date);
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--SELECT  
		--ERROR_NUMBER() AS ErrorNumber  
		--,ERROR_SEVERITY() AS ErrorSeverity  
		--,ERROR_STATE() AS ErrorState  
		--,ERROR_PROCEDURE() AS ErrorProcedure  
		--,ERROR_LINE() AS ErrorLine  
		--,ERROR_MESSAGE() AS ErrorMessage;  
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END


GO
/****** Object:  StoredProcedure [Job].[upPostTravelExpense]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ============================<Procedure_Name, sysname, ProcedureName> =================
CREATE PROCEDURE [Job].[upPostTravelExpense]
	-- Add the parameters for the stored procedure here
	@TravelExpenseCode nvarchar(20)
AS
BEGIN
	-- Costanti usate
	-- Conto per rimborsi spese
	IF EXISTS (SELECT * FROM  [Job].TravelExpenses WHERE TravelExpenseCode = @TravelExpenseCode AND [Status] = 0) 
	BEGIN
		SET NOCOUNT ON;
		BEGIN TRANSACTION
		BEGIN TRY
			DECLARE @Total decimal(18,2) = 0;
			DECLARE @PeopleId int;
			DECLARE @PostDate date = getdate();
			DECLARE @PostPeopleAccountCode nvarchar(20) = null;
			DECLARE @TravelExpenseAccountCode nvarchar(20);
			DECLARE @PeopleFullName nvarchar(180);
			SELECT @PeopleId = MAX(PeopleId), @Total=MAX(Total), @PostDate = MAX([Date]) FROM [Job].TravelExpenseList WHERE TravelExpenseCode = @TravelExpenseCode;
			SELECT @PostPeopleAccountCode = DebitAccount , @TravelExpenseAccountCode = [TravelExpenseAccount], @PeopleFullName = '[' + [Code] + '] ' + [FirstName] + ' ' + [LastName] FROM [Job].Person WHERE PeopleId = @PeopleId;
			DECLARE @PostYear int = DATEPART(YEAR,@PostDate);
			DECLARE @PostPosition int = 0;
			DECLARE @PostLine int = NULL;
			SELECT @PostLine = [LastUsedNumber] FROM [Job].[AutoNumberBase] WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = @PostYear;
			IF @PostLine IS NULL
			BEGIN
				INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year])
				VALUES ('GLAccountEntries.LineNumber',0,@PostYear);
				SET @PostLine = 1;
			END
			SET @PostLine += 1;
			UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @PostLine
				WHERE [Element] = 'GLAccountEntries.LineNumber' AND [Year] = @PostYear;

			DECLARE @DocReference nvarchar(1024) = '~/DisplayDocument/TravelExpense/' + @TravelExpenseCode;
			DECLARE @GeneralJournalLineId bigint;
			INSERT INTO [Job].[GeneralJournalLines]
				([Date]
				,[LineNumber]
				,[Description]
				,[DocumentReference]
				,[Type])
			VALUES
				(@PostDate
				,@PostLine
				,'Spese di trasferta ' + @PeopleFullName
				,@DocReference
				,'S');
			SET @GeneralJournalLineId = SCOPE_IDENTITY();

			INSERT INTO [Job].[GeneralJournalLineEntries]
				([GenerlaJournalLineId]
				,[Date]
				,[Position]
				,[GLAccountCode]
				,[Amount]
				,[DebitCredit]
				,[Type])
			VALUES
				(@GeneralJournalLineId
				,@PostDate
				,@PostPosition
				,@PostPeopleAccountCode
				,@Total
				,'A'
				,'S');

			SET @PostPosition += 1;

			INSERT INTO [Job].[GeneralJournalLineEntries]
				([GenerlaJournalLineId]
				,[Date]
				,[Position]
				,[GLAccountCode]
				,[Amount]
				,[DebitCredit]
				,[Type])
			VALUES
				(@GeneralJournalLineId
				,@PostDate
				,@PostPosition
				,@TravelExpenseAccountCode
				,@Total
				,'D'
				,'S');

			UPDATE [Job].TravelExpenses
				SET Status = 1, PostDate = @PostDate
				WHERE [TravelExpenseCode] = @TravelExpenseCode;

			INSERT INTO [Job].[GLTravelExpense] ([GenerlaJournalLineId],[TravelExpenseCode])
			VALUES (@GeneralJournalLineId,@TravelExpenseCode)

			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			--SELECT  
			--ERROR_NUMBER() AS ErrorNumber  
			--,ERROR_SEVERITY() AS ErrorSeverity  
			--,ERROR_STATE() AS ErrorState  
			--,ERROR_PROCEDURE() AS ErrorProcedure  
			--,ERROR_LINE() AS ErrorLine  
			--,ERROR_MESSAGE() AS ErrorMessage;  
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH
	END

END


GO
/****** Object:  StoredProcedure [Job].[upTravelExpenseAdd]    Script Date: 09/12/2016 16:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [Job].[upTravelExpenseAdd]
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
		DECLARE @Prefix nvarchar(4);
        SELECT @LastUsedNumber = [LastUsedNumber], @Prefix=[Prefix] FROM [Job].[AutoNumberBase] WHERE [Element] = 'TravelExpense.Code' AND [Year] = @Year;
        IF @LastUsedNumber IS NULL
		BEGIN
			SELECT @Prefix=[Prefix] FROM [Job].[AutoNumberBase] WHERE [Element] = 'TravelExpense.Code' AND [Year] = (@Year - 1);
			INSERT INTO [Job].[AutoNumberBase] ([Element],[LastUsedNumber],[Year],[Prefix])
			VALUES ('TravelExpense.Code',0,@Year,@Prefix);
			SET @LastUsedNumber = 0;
		END
		SET @LastUsedNumber += 1;
        DECLARE @LastUsedNumberStr nvarchar(5) = RIGHT('0000' + CAST (@LastUsedNumber AS NVARCHAR(5)),5);
        SET @Code = COALESCE(@Prefix,'') + RIGHT(CAST (@Year AS NVARCHAR(4)),2) + '-' +  @LastUsedNumberStr;
        UPDATE [Job].[AutoNumberBase] SET [LastUsedNumber] = @LastUsedNumber
        WHERE [Element] = 'TravelExpense.Code' AND [Year] = @Year;
		
		IF  NOT @Annotation IS NULL 
			IF RTRIM(LTRIM(@Annotation)) = '' SET @Annotation = NULL;
		INSERT INTO [Job].[TravelExpenses]
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
	SELECT * FROM [Job].[TravelExpenses] WHERE [TravelExpenseCode] = @Code;
	COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH

END







GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WorksJournal (Job)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 309
               Right = 505
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 3420
         Alias = 2715
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobActual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobActual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "JobTasks (Job)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobExpected'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobExpected'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[19] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "J"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 94
               Left = 734
               Bottom = 224
               Right = 963
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JS"
            Begin Extent = 
               Top = 207
               Left = 345
               Bottom = 303
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JE"
            Begin Extent = 
               Top = 159
               Left = 542
               Bottom = 289
               Right = 718
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JA"
            Begin Extent = 
               Top = 6
               Left = 272
               Bottom = 136
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 3075
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[32] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Person (Job)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 186
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WorksJournal (Job)"
            Begin Extent = 
               Top = 6
               Left = 299
               Bottom = 163
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 4080
         Alias = 2655
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobWorkList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'JobWorkList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TEL"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 297
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'TravelExpenseList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'Job', @level1type=N'VIEW',@level1name=N'TravelExpenseList'
GO
USE [master]
GO
ALTER DATABASE [Job] SET  READ_WRITE 
GO

ALTER DATABASE [PrototipoCoastal] SET COMPATIBILITY_LEVEL = 140
GO

ALTER DATABASE [PrototipoCoastal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET ARITHABORT OFF 
GO

ALTER DATABASE [PrototipoCoastal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrototipoCoastal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PrototipoCoastal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PrototipoCoastal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PrototipoCoastal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrototipoCoastal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrototipoCoastal] SET READ_COMMITTED_SNAPSHOT ON 
GO


ALTER DATABASE [PrototipoCoastal] SET  MULTI_USER 
GO



ALTER DATABASE [PrototipoCoastal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PrototipoCoastal] SET QUERY_STORE = OFF
GO
USE [PrototipoCoastal]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PrototipoCoastal]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 09-Apr-18 14:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbAirplanes]    Script Date: 09-Apr-18 14:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbAirplanes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Prefix] [nvarchar](25) NOT NULL,
	[Range] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[MaxWeight] [int] NOT NULL,
	[FuelConsumptionFirstHour] [int] NOT NULL,
	[FuelConsumptionSecondHour] [int] NOT NULL,
	[CruiseSpeed] [float] NOT NULL,
	[MaxFuel] [float] NOT NULL,
	[Model] [nvarchar](max) NULL,
	[Capacity] [float] NOT NULL,
	[BaseAirport_Id] [bigint] NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbAirplanes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbAirports]    Script Date: 09-Apr-18 14:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbAirports](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Latitude] [nvarchar](max) NOT NULL,
	[Longitude] [nvarchar](max) NOT NULL,
	[IATA] [nvarchar](6) NULL,
	[Region] [nvarchar](25) NULL,
	[Elevation] [int] NOT NULL,
	[RunwayLength] [int] NOT NULL,
	[MTOW_APE3] [int] NOT NULL,
	[MTOW_PC12] [int] NOT NULL,
	[LandingCost] [int] NOT NULL,
	[GroundTime] [time](7) NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
	[AirportName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.DbAirports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbExchangeRates]    Script Date: 09-Apr-18 14:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbExchangeRates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](max) NOT NULL,
	[CurrencySymbol] [nvarchar](max) NULL,
	[ValueInDolar] [float] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbExchangeRates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbFlightsReports]    Script Date: 09-Apr-18 14:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbFlightsReports](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FuelOnDeparture] [float] NOT NULL,
	[FuelOnArrival] [float] NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[Airplanes_Id] [bigint] NOT NULL,
	[Destination_Id] [bigint] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
	[Origin_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbFlightsReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbFuelPrices]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbFuelPrices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Airport_Id] [bigint] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbFuelPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbGeneralParametersDefaults]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbGeneralParametersDefaults](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.DbGeneralParametersDefaults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbImportErrors]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbImportErrors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[File] [nvarchar](max) NOT NULL,
	[Sheet] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[RowLine] [int] NOT NULL,
	[ImportationHour] [datetime] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbImportErrors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbInstances]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbInstances](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NULL,
	[Description] [nvarchar](40) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastOptimization] [datetime] NULL,
	[Optimized] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.DbInstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbParameters]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbParameters](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbParameters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbPassagensOnFlightReports]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbPassagensOnFlightReports](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Flight_Id] [bigint] NOT NULL,
	[Passenger_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbPassagensOnFlightReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbRefuelsReports]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbRefuelsReports](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RefuelTime] [time](7) NOT NULL,
	[Amount] [float] NOT NULL,
	[Airplanes_Id] [bigint] NOT NULL,
	[Airport_Id] [bigint] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbRefuelsReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbReportLists]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbReportLists](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](max) NOT NULL,
	[ReportLabel] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.DbReportLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbRequests]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbRequests](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PNR] [nvarchar](max) NOT NULL,
	[Class] [nvarchar](max) NOT NULL,
	[Sex] [nvarchar](max) NOT NULL,
	[IsChildren] [bit] NOT NULL,
	[DepartureTimeWindowBegin] [time](7) NOT NULL,
	[DepartureTimeWindowEnd] [time](7) NOT NULL,
	[ArrivalTimeWindowBegin] [time](7) NOT NULL,
	[ArrivalTimeWindowEnd] [time](7) NOT NULL,
	[Destination_Id] [bigint] NOT NULL,
	[Instance_Id] [bigint] NOT NULL,
	[Origin_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbSeats]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbSeats](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[seatClass] [nvarchar](max) NOT NULL,
	[luggageWeightLimit] [float] NOT NULL,
	[Airplanes_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.DbSeats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbStretches]    Script Date: 09-Apr-18 14:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbStretches](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Distance] [int] NOT NULL,
	[Destination_Id] [bigint] NULL,
	[Origin_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.DbStretches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_BaseAirport_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_BaseAirport_Id] ON [dbo].[DbAirplanes]
(
	[BaseAirport_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbAirplanes]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbAirports]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbExchangeRates]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Airplanes_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Airplanes_Id] ON [dbo].[DbFlightsReports]
(
	[Airplanes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Destination_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Destination_Id] ON [dbo].[DbFlightsReports]
(
	[Destination_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbFlightsReports]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Origin_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Origin_Id] ON [dbo].[DbFlightsReports]
(
	[Origin_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Airport_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Airport_Id] ON [dbo].[DbFuelPrices]
(
	[Airport_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbFuelPrices]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbImportErrors]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbParameters]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Flight_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Flight_Id] ON [dbo].[DbPassagensOnFlightReports]
(
	[Flight_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Passenger_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Passenger_Id] ON [dbo].[DbPassagensOnFlightReports]
(
	[Passenger_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Airplanes_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Airplanes_Id] ON [dbo].[DbRefuelsReports]
(
	[Airplanes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Airport_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Airport_Id] ON [dbo].[DbRefuelsReports]
(
	[Airport_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbRefuelsReports]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Destination_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Destination_Id] ON [dbo].[DbRequests]
(
	[Destination_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instance_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Instance_Id] ON [dbo].[DbRequests]
(
	[Instance_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Origin_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Origin_Id] ON [dbo].[DbRequests]
(
	[Origin_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Airplanes_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Airplanes_Id] ON [dbo].[DbSeats]
(
	[Airplanes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Destination_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Destination_Id] ON [dbo].[DbStretches]
(
	[Destination_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Origin_Id]    Script Date: 09-Apr-18 14:27:18 ******/
CREATE NONCLUSTERED INDEX [IX_Origin_Id] ON [dbo].[DbStretches]
(
	[Origin_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DbAirports] ADD  DEFAULT ('') FOR [AirportName]
GO
ALTER TABLE [dbo].[DbAirplanes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbAirplanes_dbo.DbAirports_BaseAirport_Id] FOREIGN KEY([BaseAirport_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbAirplanes] CHECK CONSTRAINT [FK_dbo.DbAirplanes_dbo.DbAirports_BaseAirport_Id]
GO
ALTER TABLE [dbo].[DbAirplanes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbAirplanes_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbAirplanes] CHECK CONSTRAINT [FK_dbo.DbAirplanes_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbAirports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbAirports_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbAirports] CHECK CONSTRAINT [FK_dbo.DbAirports_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbExchangeRates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbExchangeRates_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbExchangeRates] CHECK CONSTRAINT [FK_dbo.DbExchangeRates_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbFlightsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirplanes_Airplanes_Id] FOREIGN KEY([Airplanes_Id])
REFERENCES [dbo].[DbAirplanes] ([Id])
GO
ALTER TABLE [dbo].[DbFlightsReports] CHECK CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirplanes_Airplanes_Id]
GO
ALTER TABLE [dbo].[DbFlightsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirports_Destination_Id] FOREIGN KEY([Destination_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbFlightsReports] CHECK CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirports_Destination_Id]
GO
ALTER TABLE [dbo].[DbFlightsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirports_Origin_Id] FOREIGN KEY([Origin_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbFlightsReports] CHECK CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbAirports_Origin_Id]
GO
ALTER TABLE [dbo].[DbFlightsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbFlightsReports] CHECK CONSTRAINT [FK_dbo.DbFlightsReports_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbFuelPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFuelPrices_dbo.DbAirports_Airport_Id] FOREIGN KEY([Airport_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbFuelPrices] CHECK CONSTRAINT [FK_dbo.DbFuelPrices_dbo.DbAirports_Airport_Id]
GO
ALTER TABLE [dbo].[DbFuelPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbFuelPrices_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbFuelPrices] CHECK CONSTRAINT [FK_dbo.DbFuelPrices_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbImportErrors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbImportErrors_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbImportErrors] CHECK CONSTRAINT [FK_dbo.DbImportErrors_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbParameters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbParameters_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbParameters] CHECK CONSTRAINT [FK_dbo.DbParameters_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbPassagensOnFlightReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbPassagensOnFlightReports_dbo.DbFlightsReports_Flight_Id] FOREIGN KEY([Flight_Id])
REFERENCES [dbo].[DbFlightsReports] ([Id])
GO
ALTER TABLE [dbo].[DbPassagensOnFlightReports] CHECK CONSTRAINT [FK_dbo.DbPassagensOnFlightReports_dbo.DbFlightsReports_Flight_Id]
GO
ALTER TABLE [dbo].[DbPassagensOnFlightReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbPassagensOnFlightReports_dbo.DbRequests_Passenger_Id] FOREIGN KEY([Passenger_Id])
REFERENCES [dbo].[DbRequests] ([Id])
GO
ALTER TABLE [dbo].[DbPassagensOnFlightReports] CHECK CONSTRAINT [FK_dbo.DbPassagensOnFlightReports_dbo.DbRequests_Passenger_Id]
GO
ALTER TABLE [dbo].[DbRefuelsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbAirplanes_Airplanes_Id] FOREIGN KEY([Airplanes_Id])
REFERENCES [dbo].[DbAirplanes] ([Id])
GO
ALTER TABLE [dbo].[DbRefuelsReports] CHECK CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbAirplanes_Airplanes_Id]
GO
ALTER TABLE [dbo].[DbRefuelsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbAirports_Airport_Id] FOREIGN KEY([Airport_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbRefuelsReports] CHECK CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbAirports_Airport_Id]
GO
ALTER TABLE [dbo].[DbRefuelsReports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbRefuelsReports] CHECK CONSTRAINT [FK_dbo.DbRefuelsReports_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbRequests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRequests_dbo.DbAirports_Destination_Id] FOREIGN KEY([Destination_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbRequests] CHECK CONSTRAINT [FK_dbo.DbRequests_dbo.DbAirports_Destination_Id]
GO
ALTER TABLE [dbo].[DbRequests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRequests_dbo.DbAirports_Origin_Id] FOREIGN KEY([Origin_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbRequests] CHECK CONSTRAINT [FK_dbo.DbRequests_dbo.DbAirports_Origin_Id]
GO
ALTER TABLE [dbo].[DbRequests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbRequests_dbo.DbInstances_Instance_Id] FOREIGN KEY([Instance_Id])
REFERENCES [dbo].[DbInstances] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbRequests] CHECK CONSTRAINT [FK_dbo.DbRequests_dbo.DbInstances_Instance_Id]
GO
ALTER TABLE [dbo].[DbSeats]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbSeats_dbo.DbAirplanes_Airplane_Id] FOREIGN KEY([Airplanes_Id])
REFERENCES [dbo].[DbAirplanes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DbSeats] CHECK CONSTRAINT [FK_dbo.DbSeats_dbo.DbAirplanes_Airplane_Id]
GO
ALTER TABLE [dbo].[DbStretches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbStretches_dbo.DbAirports_Destination_Id] FOREIGN KEY([Destination_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbStretches] CHECK CONSTRAINT [FK_dbo.DbStretches_dbo.DbAirports_Destination_Id]
GO
ALTER TABLE [dbo].[DbStretches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DbStretches_dbo.DbAirports_Origin_Id] FOREIGN KEY([Origin_Id])
REFERENCES [dbo].[DbAirports] ([Id])
GO
ALTER TABLE [dbo].[DbStretches] CHECK CONSTRAINT [FK_dbo.DbStretches_dbo.DbAirports_Origin_Id]
GO

ALTER DATABASE [PrototipoCoastal] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [yoshiwarehouse]    Script Date: 16.03.2024 11:20:31 ******/
CREATE DATABASE [yoshiwarehouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'yoshiwarehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\yoshiwarehouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'yoshiwarehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\yoshiwarehouse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [yoshiwarehouse] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [yoshiwarehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [yoshiwarehouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [yoshiwarehouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [yoshiwarehouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET  ENABLE_BROKER 
GO
ALTER DATABASE [yoshiwarehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [yoshiwarehouse] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [yoshiwarehouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET RECOVERY FULL 
GO
ALTER DATABASE [yoshiwarehouse] SET  MULTI_USER 
GO
ALTER DATABASE [yoshiwarehouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [yoshiwarehouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [yoshiwarehouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [yoshiwarehouse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [yoshiwarehouse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [yoshiwarehouse] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'yoshiwarehouse', N'ON'
GO
ALTER DATABASE [yoshiwarehouse] SET QUERY_STORE = ON
GO
ALTER DATABASE [yoshiwarehouse] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [yoshiwarehouse]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dokumentPrzyjecia]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dokumentPrzyjecia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MagazynDocelowyId] [int] NULL,
	[DostawcaId] [int] NULL,
	[Anulowany] [int] NOT NULL,
	[Zatwierdzony] [int] NOT NULL,
 CONSTRAINT [PK_dokumentPrzyjecia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dokumentPrzyjeciaEtykieta]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dokumentPrzyjeciaEtykieta](
	[DokumentPrzyjeciaId] [int] NOT NULL,
	[EtykietaId] [int] NOT NULL,
 CONSTRAINT [PK_dokumentPrzyjeciaEtykieta] PRIMARY KEY CLUSTERED 
(
	[DokumentPrzyjeciaId] ASC,
	[EtykietaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dostawca]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dostawca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NazwaFirmy] [nvarchar](max) NOT NULL,
	[Adres] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dostawca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[etykieta]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etykieta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_etykieta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[magazyn]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[magazyn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](max) NOT NULL,
	[Symbol] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_magazyn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[towar]    Script Date: 16.03.2024 11:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[towar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](max) NOT NULL,
	[Kod] [nvarchar](max) NOT NULL,
	[DokumnetPrzyjeciaId] [int] NULL,
	[Ilosc] [int] NOT NULL,
	[Cena] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_towar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240315204529_Init', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[dokumentPrzyjecia] ON 

INSERT [dbo].[dokumentPrzyjecia] ([Id], [MagazynDocelowyId], [DostawcaId], [Anulowany], [Zatwierdzony]) VALUES (1, 1, 1, 0, 0)
INSERT [dbo].[dokumentPrzyjecia] ([Id], [MagazynDocelowyId], [DostawcaId], [Anulowany], [Zatwierdzony]) VALUES (2, 1, 1, 0, 0)
INSERT [dbo].[dokumentPrzyjecia] ([Id], [MagazynDocelowyId], [DostawcaId], [Anulowany], [Zatwierdzony]) VALUES (3, 2, 2, 1, 0)
SET IDENTITY_INSERT [dbo].[dokumentPrzyjecia] OFF
GO
INSERT [dbo].[dokumentPrzyjeciaEtykieta] ([DokumentPrzyjeciaId], [EtykietaId]) VALUES (1, 1)
INSERT [dbo].[dokumentPrzyjeciaEtykieta] ([DokumentPrzyjeciaId], [EtykietaId]) VALUES (1, 2)
INSERT [dbo].[dokumentPrzyjeciaEtykieta] ([DokumentPrzyjeciaId], [EtykietaId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[dostawca] ON 

INSERT [dbo].[dostawca] ([Id], [NazwaFirmy], [Adres]) VALUES (1, N'Firma1', N'adres1')
INSERT [dbo].[dostawca] ([Id], [NazwaFirmy], [Adres]) VALUES (2, N'Firma2', N'adres2')
INSERT [dbo].[dostawca] ([Id], [NazwaFirmy], [Adres]) VALUES (3, N'Firma3', N'adres3')
SET IDENTITY_INSERT [dbo].[dostawca] OFF
GO
SET IDENTITY_INSERT [dbo].[etykieta] ON 

INSERT [dbo].[etykieta] ([Id], [Nazwa]) VALUES (1, N'Etykieta1')
INSERT [dbo].[etykieta] ([Id], [Nazwa]) VALUES (2, N'Etykieta2')
INSERT [dbo].[etykieta] ([Id], [Nazwa]) VALUES (3, N'Etykieta3')
SET IDENTITY_INSERT [dbo].[etykieta] OFF
GO
SET IDENTITY_INSERT [dbo].[magazyn] ON 

INSERT [dbo].[magazyn] ([Id], [Nazwa], [Symbol]) VALUES (1, N'Magazyn1', N'Symbol1')
INSERT [dbo].[magazyn] ([Id], [Nazwa], [Symbol]) VALUES (2, N'Magazyn2', N'Symbol2')
INSERT [dbo].[magazyn] ([Id], [Nazwa], [Symbol]) VALUES (3, N'Magazyn3', N'Symbol3')
SET IDENTITY_INSERT [dbo].[magazyn] OFF
GO
SET IDENTITY_INSERT [dbo].[towar] ON 

INSERT [dbo].[towar] ([Id], [Nazwa], [Kod], [DokumnetPrzyjeciaId], [Ilosc], [Cena]) VALUES (1, N'Towar1', N'kod1', 1, 2, CAST(20.99 AS Decimal(18, 2)))
INSERT [dbo].[towar] ([Id], [Nazwa], [Kod], [DokumnetPrzyjeciaId], [Ilosc], [Cena]) VALUES (2, N'Towar2', N'kod2', 1, 4, CAST(21.99 AS Decimal(18, 2)))
INSERT [dbo].[towar] ([Id], [Nazwa], [Kod], [DokumnetPrzyjeciaId], [Ilosc], [Cena]) VALUES (3, N'Towar3', N'kod3', 2, 5, CAST(22.99 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[towar] OFF
GO
/****** Object:  Index [IX_dokumentPrzyjecia_DostawcaId]    Script Date: 16.03.2024 11:20:32 ******/
CREATE NONCLUSTERED INDEX [IX_dokumentPrzyjecia_DostawcaId] ON [dbo].[dokumentPrzyjecia]
(
	[DostawcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_dokumentPrzyjecia_MagazynDocelowyId]    Script Date: 16.03.2024 11:20:32 ******/
CREATE NONCLUSTERED INDEX [IX_dokumentPrzyjecia_MagazynDocelowyId] ON [dbo].[dokumentPrzyjecia]
(
	[MagazynDocelowyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_dokumentPrzyjeciaEtykieta_EtykietaId]    Script Date: 16.03.2024 11:20:32 ******/
CREATE NONCLUSTERED INDEX [IX_dokumentPrzyjeciaEtykieta_EtykietaId] ON [dbo].[dokumentPrzyjeciaEtykieta]
(
	[EtykietaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_towar_DokumnetPrzyjeciaId]    Script Date: 16.03.2024 11:20:32 ******/
CREATE NONCLUSTERED INDEX [IX_towar_DokumnetPrzyjeciaId] ON [dbo].[towar]
(
	[DokumnetPrzyjeciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dokumentPrzyjecia]  WITH CHECK ADD  CONSTRAINT [FK_dokumentPrzyjecia_dostawca_DostawcaId] FOREIGN KEY([DostawcaId])
REFERENCES [dbo].[dostawca] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[dokumentPrzyjecia] CHECK CONSTRAINT [FK_dokumentPrzyjecia_dostawca_DostawcaId]
GO
ALTER TABLE [dbo].[dokumentPrzyjecia]  WITH CHECK ADD  CONSTRAINT [FK_dokumentPrzyjecia_magazyn_MagazynDocelowyId] FOREIGN KEY([MagazynDocelowyId])
REFERENCES [dbo].[magazyn] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[dokumentPrzyjecia] CHECK CONSTRAINT [FK_dokumentPrzyjecia_magazyn_MagazynDocelowyId]
GO
ALTER TABLE [dbo].[dokumentPrzyjeciaEtykieta]  WITH CHECK ADD  CONSTRAINT [FK_dokumentPrzyjeciaEtykieta_dokumentPrzyjecia_DokumentPrzyjeciaId] FOREIGN KEY([DokumentPrzyjeciaId])
REFERENCES [dbo].[dokumentPrzyjecia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dokumentPrzyjeciaEtykieta] CHECK CONSTRAINT [FK_dokumentPrzyjeciaEtykieta_dokumentPrzyjecia_DokumentPrzyjeciaId]
GO
ALTER TABLE [dbo].[dokumentPrzyjeciaEtykieta]  WITH CHECK ADD  CONSTRAINT [FK_dokumentPrzyjeciaEtykieta_etykieta_EtykietaId] FOREIGN KEY([EtykietaId])
REFERENCES [dbo].[etykieta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[dokumentPrzyjeciaEtykieta] CHECK CONSTRAINT [FK_dokumentPrzyjeciaEtykieta_etykieta_EtykietaId]
GO
ALTER TABLE [dbo].[towar]  WITH CHECK ADD  CONSTRAINT [FK_towar_dokumentPrzyjecia_DokumnetPrzyjeciaId] FOREIGN KEY([DokumnetPrzyjeciaId])
REFERENCES [dbo].[dokumentPrzyjecia] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[towar] CHECK CONSTRAINT [FK_towar_dokumentPrzyjecia_DokumnetPrzyjeciaId]
GO
USE [master]
GO
ALTER DATABASE [yoshiwarehouse] SET  READ_WRITE 
GO

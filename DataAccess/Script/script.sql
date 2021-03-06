USE [master]
GO
/****** Object:  Database [CordonaCoin]    Script Date: 14.07.2021 11:07:13 ******/
CREATE DATABASE [CordonaCoin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CordonaCoin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CordonaCoin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CordonaCoin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CordonaCoin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CordonaCoin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CordonaCoin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CordonaCoin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CordonaCoin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CordonaCoin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CordonaCoin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CordonaCoin] SET ARITHABORT OFF 
GO
ALTER DATABASE [CordonaCoin] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CordonaCoin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CordonaCoin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CordonaCoin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CordonaCoin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CordonaCoin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CordonaCoin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CordonaCoin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CordonaCoin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CordonaCoin] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CordonaCoin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CordonaCoin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CordonaCoin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CordonaCoin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CordonaCoin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CordonaCoin] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CordonaCoin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CordonaCoin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CordonaCoin] SET  MULTI_USER 
GO
ALTER DATABASE [CordonaCoin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CordonaCoin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CordonaCoin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CordonaCoin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CordonaCoin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CordonaCoin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CordonaCoin] SET QUERY_STORE = OFF
GO
USE [CordonaCoin]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.07.2021 11:07:13 ******/
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
/****** Object:  Table [dbo].[Cities]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PostalCode] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dashboards]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dashboards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DepositWalletBalance] [float] NOT NULL,
	[InterestWalletBalance] [float] NOT NULL,
	[TotalDeposit] [float] NOT NULL,
	[TotalWithdraw] [float] NOT NULL,
	[TotalInvest] [float] NOT NULL,
	[ReferralEarnings] [float] NOT NULL,
 CONSTRAINT [PK_Dashboards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deposits]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deposits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Status] [bit] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Deposits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[ProfilePhoto] [tinyint] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ReferenceCode] [nvarchar](max) NULL,
	[ReferenceCodeUsed] [nvarchar](max) NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[References]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[References](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Amount] [float] NOT NULL,
	[date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [float] NOT NULL,
	[AvailableBalance] [float] NOT NULL,
	[Status] [bit] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 14.07.2021 11:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[WalletName] [nvarchar](max) NULL,
	[WalletAmount] [float] NOT NULL,
	[WalletCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Wallets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210713061505_column', N'2.2.6-servicing-10079')
GO
SET IDENTITY_INSERT [dbo].[Deposits] ON 

INSERT [dbo].[Deposits] ([Id], [UserId], [Amount], [Status], [Date]) VALUES (1, 1, 10, 1, CAST(N'2021-07-14T07:24:49.7570000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Deposits] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'Kurucu')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'Admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'Moderatör')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [PasswordSalt], [PasswordHash], [Status]) VALUES (1, N'erenkara1907', 0x4EBAE9F46FC47B6DD9F01C1E8F74A6A093FA23A8C180A3AB9B89F31DDDDF0551A8624D7C5F5257C36285814D03AB4AFADD660CEDBE765C3894D26652059EA6D3B218E5CE5D8045756744BE6489D5A63EEDF23DB009D14A63F7374370B9040A1C518FD1D3B7698C26BFA6AEFCC799274F69370A5C152DE31961C0F6E87FA23773, 0x2E91F8B27584EAC5F2898B5972F0CD119FEC4D8EA38D42AEBB576FACFDCC5E35C03A43051B965289FBA500B9854980AB730FD3B124584D70D48F07A3208FF593, 1)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordSalt], [PasswordHash], [Status]) VALUES (2, N'ahmet123', 0x4A0B0EDD58DF2AA8583C71A9EA7A7C10CCF0B21B08F593F3230246F7C88C436138AF9BBB20FBF1616C4E5B93A6C53FD27DD1E4B5D092DB3285581EBF87A8C5E9A4EAEE6DDA4500D0A610019044E6F0442B0B2548E1D5FFEF53EE6097C4CEFCF02DBEB65B652CFE7CDFC908ABD03EB232AFE74BA807368EF39151ACB43138C5E0, 0x0D5BB88082059B086E6627A149DC97CD6A02587B71D5667AAE4056CBBD4781847B0ACF5E3E34659E014370808F33D3D7A4210D30C56043DA22387EA9A652ACE9, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
ALTER TABLE [dbo].[Dashboards]  WITH CHECK ADD  CONSTRAINT [FK_Dashboards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Dashboards] CHECK CONSTRAINT [FK_Dashboards_Users]
GO
ALTER TABLE [dbo].[Deposits]  WITH CHECK ADD  CONSTRAINT [FK_Deposits_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Deposits] CHECK CONSTRAINT [FK_Deposits_Users]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Cities]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Countries]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users]
GO
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_Profiles] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_Profiles]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_Users]
GO
USE [master]
GO
ALTER DATABASE [CordonaCoin] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [Banco_pan]    Script Date: 18/11/2024 12:56:14 ******/
CREATE DATABASE [Banco_pan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Banco_pan', FILENAME = N'R:\sql\MSSQL16.SQLEXPRESS\MSSQL\DATA\Banco_pan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Banco_pan_log', FILENAME = N'R:\sql\MSSQL16.SQLEXPRESS\MSSQL\DATA\Banco_pan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Banco_pan] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Banco_pan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Banco_pan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Banco_pan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Banco_pan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Banco_pan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Banco_pan] SET ARITHABORT OFF 
GO
ALTER DATABASE [Banco_pan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Banco_pan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Banco_pan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Banco_pan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Banco_pan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Banco_pan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Banco_pan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Banco_pan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Banco_pan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Banco_pan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Banco_pan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Banco_pan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Banco_pan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Banco_pan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Banco_pan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Banco_pan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Banco_pan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Banco_pan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Banco_pan] SET  MULTI_USER 
GO
ALTER DATABASE [Banco_pan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Banco_pan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Banco_pan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Banco_pan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Banco_pan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Banco_pan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Banco_pan] SET QUERY_STORE = ON
GO
ALTER DATABASE [Banco_pan] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Banco_pan]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/11/2024 12:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [varchar](60) NULL,
	[Email] [varchar](60) NULL,
	[CPF] [varchar](14) NULL,
	[situacao] [bit] NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Banco_pan] SET  READ_WRITE 
GO

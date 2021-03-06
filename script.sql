USE [master]
GO
/****** Object:  Database [suppport_hunre]    Script Date: 5/11/2022 12:01:28 PM ******/
CREATE DATABASE [suppport_hunre]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'suppport_hunre', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\suppport_hunre.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'suppport_hunre_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\suppport_hunre_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [suppport_hunre] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [suppport_hunre].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [suppport_hunre] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [suppport_hunre] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [suppport_hunre] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [suppport_hunre] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [suppport_hunre] SET ARITHABORT OFF 
GO
ALTER DATABASE [suppport_hunre] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [suppport_hunre] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [suppport_hunre] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [suppport_hunre] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [suppport_hunre] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [suppport_hunre] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [suppport_hunre] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [suppport_hunre] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [suppport_hunre] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [suppport_hunre] SET  DISABLE_BROKER 
GO
ALTER DATABASE [suppport_hunre] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [suppport_hunre] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [suppport_hunre] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [suppport_hunre] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [suppport_hunre] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [suppport_hunre] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [suppport_hunre] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [suppport_hunre] SET RECOVERY FULL 
GO
ALTER DATABASE [suppport_hunre] SET  MULTI_USER 
GO
ALTER DATABASE [suppport_hunre] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [suppport_hunre] SET DB_CHAINING OFF 
GO
ALTER DATABASE [suppport_hunre] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [suppport_hunre] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [suppport_hunre] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'suppport_hunre', N'ON'
GO
ALTER DATABASE [suppport_hunre] SET QUERY_STORE = OFF
GO
USE [suppport_hunre]
GO
/****** Object:  Table [dbo].[cong_ty]    Script Date: 5/11/2022 12:01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cong_ty](
	[id_cong_ty] [int] IDENTITY(1,1) NOT NULL,
	[ten_cong_ty] [nvarchar](255) NULL,
	[dia_chi] [nvarchar](255) NOT NULL,
	[sdt] [nvarchar](15) NULL,
	[email] [nvarchar](100) NULL,
	[mo_ta] [nvarchar](255) NULL,
	[anh] [nvarchar](255) NULL,
	[chuyen_nganh] [nvarchar](255) NULL,
 CONSTRAINT [PK_cong_ty] PRIMARY KEY CLUSTERED 
(
	[id_cong_ty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khoa]    Script Date: 5/11/2022 12:01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoa](
	[id_khoa] [int] IDENTITY(1,1) NOT NULL,
	[ten_khoa] [nvarchar](100) NULL,
	[sdt] [nvarchar](15) NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK_khoa] PRIMARY KEY CLUSTERED 
(
	[id_khoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sach]    Script Date: 5/11/2022 12:01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sach](
	[id_sach] [int] IDENTITY(1,1) NOT NULL,
	[ten_sach] [nvarchar](255) NULL,
	[tac_gia] [nvarchar](50) NULL,
	[nxb] [nvarchar](255) NULL,
	[duong_dan] [nvarchar](255) NULL,
	[anh] [nvarchar](255) NULL,
	[mo_ta] [text] NULL,
	[id_khoa] [int] NULL,
 CONSTRAINT [PK_sach] PRIMARY KEY CLUSTERED 
(
	[id_sach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sinh_vien]    Script Date: 5/11/2022 12:01:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sinh_vien](
	[id_sinh_vien] [int] IDENTITY(1,1) NOT NULL,
	[ten_sinh_vien] [nvarchar](100) NULL,
	[gioi_tinh] [nchar](10) NULL,
	[ngay_sinh] [nvarchar](30) NULL,
	[sdt] [nvarchar](15) NULL,
	[email] [nvarchar](100) NULL,
	[mo_ta] [nvarchar](255) NULL,
	[id_cong_ty] [int] NULL,
	[id_khoa] [int] NULL,
 CONSTRAINT [PK_sinh_vien] PRIMARY KEY CLUSTERED 
(
	[id_sinh_vien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sach]  WITH CHECK ADD  CONSTRAINT [FK_sach_khoa] FOREIGN KEY([id_khoa])
REFERENCES [dbo].[khoa] ([id_khoa])
GO
ALTER TABLE [dbo].[sach] CHECK CONSTRAINT [FK_sach_khoa]
GO
ALTER TABLE [dbo].[sinh_vien]  WITH CHECK ADD  CONSTRAINT [FK_sinh_vien_cong_ty] FOREIGN KEY([id_cong_ty])
REFERENCES [dbo].[cong_ty] ([id_cong_ty])
GO
ALTER TABLE [dbo].[sinh_vien] CHECK CONSTRAINT [FK_sinh_vien_cong_ty]
GO
ALTER TABLE [dbo].[sinh_vien]  WITH CHECK ADD  CONSTRAINT [FK_sinh_vien_khoa] FOREIGN KEY([id_khoa])
REFERENCES [dbo].[khoa] ([id_khoa])
GO
ALTER TABLE [dbo].[sinh_vien] CHECK CONSTRAINT [FK_sinh_vien_khoa]
GO
USE [master]
GO
ALTER DATABASE [suppport_hunre] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [Election_Management_System]    Script Date: 1/23/2024 12:52:04 AM ******/
CREATE DATABASE [Election_Management_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Election+Management_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Election+Management_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Election+Management_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Election+Management_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Election_Management_System] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Election_Management_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Election_Management_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Election_Management_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Election_Management_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Election_Management_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Election_Management_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Election_Management_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Election_Management_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Election_Management_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Election_Management_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Election_Management_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Election_Management_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Election_Management_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Election_Management_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Election_Management_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Election_Management_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Election_Management_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Election_Management_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Election_Management_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Election_Management_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Election_Management_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Election_Management_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Election_Management_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Election_Management_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Election_Management_System] SET  MULTI_USER 
GO
ALTER DATABASE [Election_Management_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Election_Management_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Election_Management_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Election_Management_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Election_Management_System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Election_Management_System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Election_Management_System', N'ON'
GO
ALTER DATABASE [Election_Management_System] SET QUERY_STORE = ON
GO
ALTER DATABASE [Election_Management_System] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Election_Management_System]
GO
/****** Object:  Table [dbo].[City]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Cityid] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [varchar](2500) NULL,
	[stateid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Electionparty]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Electionparty](
	[Epartyid] [int] IDENTITY(1,1) NOT NULL,
	[partyname] [varchar](2500) NULL,
	[Symbol] [varchar](max) NULL,
	[yearofelection] [date] NULL,
	[Noofwinner] [int] NULL,
	[nooflost] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Epartyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElectionUsers]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElectionUsers](
	[Euserid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](2500) NULL,
	[Epassword] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Euserid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MpSeats]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MpSeats](
	[MpSeatsid] [int] IDENTITY(1,1) NOT NULL,
	[stateid] [int] NULL,
	[seats] [int] NULL,
	[cityid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MpSeatsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[states]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[states](
	[stateid] [int] IDENTITY(1,1) NOT NULL,
	[statename] [varchar](2500) NULL,
	[Statu] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[stateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voters]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voters](
	[Voterid] [int] IDENTITY(1,1) NOT NULL,
	[VoterName] [varchar](5000) NULL,
	[voterAddress] [varchar](5000) NULL,
	[Photo] [varchar](max) NULL,
	[status] [bit] NULL,
	[cityid] [int] NULL,
	[stateid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Voterid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votingsystem]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votingsystem](
	[Votingsystemid] [int] IDENTITY(1,1) NOT NULL,
	[stateid] [int] NULL,
	[partyid] [int] NULL,
	[voiterid] [int] NULL,
	[voterdate] [date] NULL,
	[cityid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Votingsystemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[states] ADD  DEFAULT ('TRUE') FOR [Statu]
GO
ALTER TABLE [dbo].[Voters] ADD  DEFAULT ('TRUE') FOR [status]
GO
/****** Object:  StoredProcedure [dbo].[Electionpartylist]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Electionpartylist]
as

begin
select * from Electionparty
end
GO
/****** Object:  StoredProcedure [dbo].[Electionpartyprd]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Electionpartyprd]( @Epartyid int,@partyname varchar(2500),@Symbol varchar(max),@yearofelection date,@Outputs varchar(1000) OUTPUT,@status varchar(1) )
as
begin

insert into  Electionparty (partyname,yearofelection )values
(@partyname ,@yearofelection )
select @status='Success'
end

GO
/****** Object:  StoredProcedure [dbo].[ElectionRegistrationlogin]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[ElectionRegistrationlogin]
@username varchar(max),@passwords varchar(max) 

as

begin
select COUNT(*) id from ElectionUsers where username=@username and Epassword=@passwords
end
GO
/****** Object:  StoredProcedure [dbo].[ElectionRegistrationuser]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[ElectionRegistrationuser]
@username varchar(max),@passwords varchar(max),@status varchar(1),@Euserid int, @Outputs varchar(1000) OUTPUT  

as

begin
	if(@status='I')
		begin
		insert into  ElectionUsers (username,Epassword) values(@username,@passwords)
		select @Outputs='Success'
		end
	if(@status='U')
		begin
		update  ElectionUsers set  username=@username,Epassword =@passwords where Euserid=@Euserid
		select @Outputs='Update'
		end

end
GO
/****** Object:  StoredProcedure [dbo].[MpSeatInsert]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MpSeatInsert]( @MpSeatsid int,@stateid int,@seats int,@cityid int,@Outputs varchar(1000) OUTPUT,@status varchar(1) )
as
begin
if(@status='I')
begin
insert into  MpSeats (stateid,seats,cityid )values
(@stateid ,@seats ,@cityid )
select @status='Success'
end

if(@status='U')
begin
update   MpSeats set seats=@seats where MpSeatsid=@MpSeatsid
select @status='Update'
end
end
GO
/****** Object:  StoredProcedure [dbo].[MpSeatsList]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MpSeatsList]
as
begin
select * from MpSeats

end
GO
/****** Object:  StoredProcedure [dbo].[Mpsetfind]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Mpsetfind] (@id int)
as
begin
select * from MpSeats where MpSeatsid=@id;
end
GO
/****** Object:  StoredProcedure [dbo].[statelist]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[statelist]
as
begin 
select * from states
end
GO
/****** Object:  StoredProcedure [dbo].[VotersInserts]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[VotersInserts] 
@VoterName varchar(max),@voterAddress varchar(max),@photo varchar(max),@cityid int,@stateid int,@status varchar(1), @Outputs varchar(1000) OUTPUT  

as

begin
	if(@status='I')
		begin
		insert into  Voters (VoterName,voterAddress,photo,cityid,stateid) values(@VoterName,@voterAddress,@photo,@cityid,@stateid)
		select @Outputs='Success'
		end
	

end
GO
/****** Object:  StoredProcedure [dbo].[VotersList]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VotersList]
as

begin
select * from Voters
end
GO
/****** Object:  StoredProcedure [dbo].[VotingsystemInserts]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE  [dbo].[VotingsystemInserts] @Votingsystemid int,@partyid int,@voiterid int, @voterdate datetime,
@cityid int,@stateid int,@status varchar(1), @Outputs varchar(1000) OUTPUT  

as

begin
	if(@status='I')
		begin
		insert into  Votingsystem (stateid,partyid,voiterid,voterdate,cityid) values
		(@stateid,@partyid,@voiterid,@voterdate,@cityid)
		select @Outputs='Success'
		end
	

end
GO
/****** Object:  StoredProcedure [dbo].[Votingsystemprd]    Script Date: 1/23/2024 12:52:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Votingsystemprd]
as
begin
select * from [Votingsystem]
end
GO
USE [master]
GO
ALTER DATABASE [Election_Management_System] SET  READ_WRITE 
GO

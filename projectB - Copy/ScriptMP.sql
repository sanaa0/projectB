USE [master]
GO
/****** Object:  Database [ProjectB]    Script Date: 5/3/2019 5:23:40 AM ******/
CREATE DATABASE [ProjectB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProjectB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProjectB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectB', N'ON'
GO
ALTER DATABASE [ProjectB] SET QUERY_STORE = OFF
GO
USE [ProjectB]
GO
/****** Object:  Table [dbo].[Clo]    Script Date: 5/3/2019 5:23:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Clo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubric]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubric](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[CloId] [int] NOT NULL,
 CONSTRAINT [PK_Rubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwCLOViewRubribs]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vwCLOViewRubribs] as
select clo.Name,Rubric.Details
from
Clo join Rubric 
ON Clo.Id=Rubric.CloId
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RegistrationNumber] [nvarchar](20) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[sasa]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[sasa] as 
select * from Student
GO
/****** Object:  View [dbo].[vwStudents]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view  [dbo].[vwStudents] as
select * from Student  
GO
/****** Object:  View [dbo].[vwwStudents]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view  [dbo].[vwwStudents] as
select * from Student  
where Status=5
GO
/****** Object:  View [dbo].[vwwwStudents]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view  [dbo].[vwwwStudents] as
select * from Student  
where Status=5
with check option
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RubricLevel]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RubricLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RubricId] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[MeasurementLevel] [int] NOT NULL,
 CONSTRAINT [PK_RubricLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssessmentComponent]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentComponent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RubricId] [int] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[AssessmentId] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentRubric] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[StudentId] [int] NOT NULL,
	[AssessmentComponentId] [int] NOT NULL,
	[RubricMeasurementId] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[AssessmentComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AssessmentWiseResult]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[AssessmentWiseResult] AS SELECT RegistrationNumber, StudentName,Title, AssessmentId, Sum(ObtainedMarks) As AssessmentMarks FROM((SELECT RegistrationNumber, StudentName, R1.AssessmentId, Title, Name, MeasurementLevel / maxi * TotalMarks AS ObtainedMarks  FROM(select  AssessmentComponent.AssessmentId, AssessmentComponent.Name, Assessment.Title, RegistrationNumber, FirstName + ' ' + LastName AS StudentName, AssessmentComponent.TotalMarks, MeasurementLevel, RubricMeasurementId FROM AssessmentComponent JOIN StudentResult ON AssessmentComponent.id = StudentResult.AssessmentComponentId JOIN Student ON Student.Id = StudentResult.StudentId JOIN RubricLevel ON RubricLevel.Id = StudentResult.RubricMeasurementId join Assessment on Assessment.Id = AssessmentComponent.AssessmentId) R1 JOIN(select Id, Max(MeasurementLevel) as maxi from RubricLevel group by Id)  R2 ON R1.RubricMeasurementId = R2.Id)) R3 group by RegistrationNumber, StudentName, AssessmentId, Title
GO
/****** Object:  Table [dbo].[ClassAttendance]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[AttendanceId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[AttendanceStatus] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assessment] ON 

INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (3009, N'assesment1', CAST(N'2019-05-03T05:05:24.000' AS DateTime), 10, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (3010, N'assesment2', CAST(N'2019-05-03T05:05:33.000' AS DateTime), 20, 10)
INSERT [dbo].[Assessment] ([Id], [Title], [DateCreated], [TotalMarks], [TotalWeightage]) VALUES (3011, N'assesment3', CAST(N'2019-05-03T05:05:42.000' AS DateTime), 10, 10)
SET IDENTITY_INSERT [dbo].[Assessment] OFF
SET IDENTITY_INSERT [dbo].[AssessmentComponent] ON 

INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (4009, N'ac1', 3007, 10, CAST(N'2019-05-03T05:10:22.000' AS DateTime), CAST(N'2019-05-03T05:10:22.000' AS DateTime), 3009)
INSERT [dbo].[AssessmentComponent] ([Id], [Name], [RubricId], [TotalMarks], [DateCreated], [DateUpdated], [AssessmentId]) VALUES (4010, N'ac2', 3008, 5, CAST(N'2019-05-03T05:10:44.000' AS DateTime), CAST(N'2019-05-03T05:10:44.000' AS DateTime), 3010)
SET IDENTITY_INSERT [dbo].[AssessmentComponent] OFF
SET IDENTITY_INSERT [dbo].[ClassAttendance] ON 

INSERT [dbo].[ClassAttendance] ([Id], [AttendanceDate]) VALUES (2030, CAST(N'2019-05-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ClassAttendance] OFF
SET IDENTITY_INSERT [dbo].[Clo] ON 

INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (3005, N'clo1', CAST(N'2019-05-03T05:07:58.000' AS DateTime), CAST(N'2019-05-03T05:07:58.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (3006, N'clo2', CAST(N'2019-05-03T05:08:03.000' AS DateTime), CAST(N'2019-05-03T05:08:03.000' AS DateTime))
INSERT [dbo].[Clo] ([Id], [Name], [DateCreated], [DateUpdated]) VALUES (3007, N'clo3', CAST(N'2019-05-03T05:08:08.000' AS DateTime), CAST(N'2019-05-03T05:08:08.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clo] OFF
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (1, N'Present', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (2, N'Absent', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (3, N'Leave', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (4, N'Late', N'ATTENDANCE_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (5, N'Active', N'STUDENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (6, N'InActive', N'STUDENT_STATUS')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Rubric] ON 

INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (3007, N'r1', 3005)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (3008, N'r2', 3005)
INSERT [dbo].[Rubric] ([Id], [Details], [CloId]) VALUES (3009, N'r3', 3005)
SET IDENTITY_INSERT [dbo].[Rubric] OFF
SET IDENTITY_INSERT [dbo].[RubricLevel] ON 

INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1015, 3007, N'rl1', 1)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1016, 3007, N'rl2', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1017, 3007, N'rl3', 3)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1018, 3007, N'rl4', 4)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1019, 3007, N'rl5', 5)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1020, 3008, N'rl2', 2)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1021, 3008, N'rl1', 1)
INSERT [dbo].[RubricLevel] ([Id], [RubricId], [Details], [MeasurementLevel]) VALUES (1022, 3008, N'rl3', 3)
SET IDENTITY_INSERT [dbo].[RubricLevel] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1020, N'Sana', N'Masood', N'03234613121', N'sanammasood9123@gmail.com', N'2016-CS-153', 5)
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Contact], [Email], [RegistrationNumber], [Status]) VALUES (1021, N'junaid', N'Masood', N'03234613145', N'kool_jony@gmail.com', N'2016-CS-211', 5)
SET IDENTITY_INSERT [dbo].[Student] OFF
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (2030, 1020, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceId], [StudentId], [AttendanceStatus]) VALUES (2030, 1021, 4)
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1020, 4009, 1017, CAST(N'2019-05-03T05:14:07.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1020, 4010, 1017, CAST(N'2019-05-03T05:14:36.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1021, 4009, 1015, CAST(N'2019-05-03T05:16:27.000' AS DateTime))
INSERT [dbo].[StudentResult] ([StudentId], [AssessmentComponentId], [RubricMeasurementId], [EvaluationDate]) VALUES (1021, 4010, 1016, CAST(N'2019-05-03T05:16:37.000' AS DateTime))
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Assessment] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Assessment]
GO
ALTER TABLE [dbo].[AssessmentComponent]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentComponent_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[AssessmentComponent] CHECK CONSTRAINT [FK_AssessmentComponent_Rubric]
GO
ALTER TABLE [dbo].[Rubric]  WITH CHECK ADD  CONSTRAINT [FK_Rubric_Clo] FOREIGN KEY([CloId])
REFERENCES [dbo].[Clo] ([Id])
GO
ALTER TABLE [dbo].[Rubric] CHECK CONSTRAINT [FK_Rubric_Clo]
GO
ALTER TABLE [dbo].[RubricLevel]  WITH CHECK ADD  CONSTRAINT [FK_RubricLevel_Rubric] FOREIGN KEY([RubricId])
REFERENCES [dbo].[Rubric] ([Id])
GO
ALTER TABLE [dbo].[RubricLevel] CHECK CONSTRAINT [FK_RubricLevel_Rubric]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_ClassAttendance] FOREIGN KEY([AttendanceId])
REFERENCES [dbo].[ClassAttendance] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_ClassAttendance]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Lookup] FOREIGN KEY([AttendanceStatus])
REFERENCES [dbo].[Lookup] ([LookupId])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Lookup]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Student]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_AssessmentComponent] FOREIGN KEY([AssessmentComponentId])
REFERENCES [dbo].[AssessmentComponent] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_AssessmentComponent]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_RubricLevel] FOREIGN KEY([RubricMeasurementId])
REFERENCES [dbo].[RubricLevel] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_RubricLevel]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Student]
GO
/****** Object:  StoredProcedure [dbo].[spAllData]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAllData] as
begin
select * from student where Status=5
end
GO
/****** Object:  StoredProcedure [dbo].[sppwithparam]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sppwithparam] @p int ,@q int
as
begin
select * from Student where id=@p and Status=@q
end
GO
/****** Object:  StoredProcedure [dbo].[spwithparam]    Script Date: 5/3/2019 5:23:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spwithparam] @p int
as
begin
select * from Student where id=@p
end 
GO
USE [master]
GO
ALTER DATABASE [ProjectB] SET  READ_WRITE 
GO

USE [master]
GO
CREATE DATABASE [bdolimpiadas] ON  PRIMARY 
( NAME = N'bdolimpiadas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\bdolimpiadas.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bdolimpiadas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\bdolimpiadas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bdolimpiadas] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdolimpiadas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdolimpiadas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdolimpiadas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdolimpiadas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdolimpiadas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdolimpiadas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdolimpiadas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdolimpiadas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdolimpiadas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdolimpiadas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdolimpiadas] SET  MULTI_USER 
GO
ALTER DATABASE [bdolimpiadas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdolimpiadas] SET DB_CHAINING OFF 
GO
USE [bdolimpiadas]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblmodalidades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblmodalidades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblpaises](
	[idpais] [int] IDENTITY(1,1) NOT NULL,
	[nombrepais] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblpaises] PRIMARY KEY CLUSTERED 
(
	[idpais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblparticipantes](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[pais] [int] NOT NULL,
	[edad] [tinyint] NULL,
 CONSTRAINT [PK_tblparticipantes] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [tblpaises] ON 

INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (1, N'COLOMBIA')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (2, N'BRASIL')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (3, N'CHILE')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (4, N'ARGENTINA')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (5, N'CHINA')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (6, N'PERU')
SET IDENTITY_INSERT [tblpaises] OFF
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (22222, N'Juana de Arco', 4, 27)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (321321, N'Alex Castro', 6, 21)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (654654, N'Marcos Rojo', 4, 30)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (987987, N'Pedro Porto', 2, 21)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (65456465, N'Andrea Perez', 1, 20)
ALTER TABLE [tblparticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tblparticipantes_tblpaises] FOREIGN KEY([pais])
REFERENCES [tblpaises] ([idpais])
GO
ALTER TABLE [tblparticipantes] CHECK CONSTRAINT [FK_tblparticipantes_tblpaises]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spConsultaPaises]
AS
SELECT * FROM dbo.tblpaises ORDER BY nombrepais ASC


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spConsultaParticipantes]
AS
SELECT par.cedula AS "CÉDULA",
par.nombre AS "NOMBRE PARTICIPANTE",
pai.nombrepais "PAÍS",
PAR.edad as "EDAD"	
FROM dbo.tblparticipantes  par
INNER JOIN dbo.tblpaises pai
ON par.pais = pai.idpais

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spEliminarPais]
@idpais INT 
AS
DELETE FROM dbo.tblpaises WHERE 
idpais = @idpais


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[spEliminarParticipantes]
@cedula INT
AS
DELETE FROM dbo.tblparticipantes
WHERE cedula = @cedula 

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spGuardarCambiosPais]
@idpais INT, @nombrepais VARCHAR(50)
AS
UPDATE dbo.tblpaises SET
nombrepais = @nombrepais WHERE
idpais = @idpais


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[spGuardarCambiosParticipanteCONPais]
@cedula INT,
@nombre VARCHAR(100),
@pais INT,
@edad TINYINt = NULL
AS
UPDATE dbo.tblparticipantes SET
nombre = @nombre , pais = @pais , edad = @edad
WHERE	cedula = @cedula

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[spGuardarCambiosParticipanteSINPais]
@cedula INT,
@nombre VARCHAR(100),
@edad TINYINt = NULL
AS
UPDATE dbo.tblparticipantes SET
nombre = @nombre,edad = @edad
WHERE	cedula = @cedula

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spGuardarNuevoParticipantes]
@cedula INT,
@nombre VARCHAR(100),
@pais INT,
@edad TINYINT = NULL
AS
INSERT INTO	dbo.tblparticipantes (cedula,nombre,pais,edad) 
VALUES (@cedula, @nombre , @pais ,@edad )

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [spNuevoPais]
@nombrepais VARCHAR(50)
AS
INSERT INTO dbo.tblpaises (nombrepais) 
VALUES (@nombrepais)


GO
USE [master]
GO
ALTER DATABASE [bdolimpiadas] SET  READ_WRITE 
GO

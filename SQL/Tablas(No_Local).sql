CREATE DATABASE [DB_BIM]

USE [DB_BIM]
GO

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Cod_0](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cod_0] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Cod_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cod_1] [float] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])


-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Cod_2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cod_2] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])


-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Local_Nombre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Local_Nombre] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Nombre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Coef](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Coeficiente] [float] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[CoefNumHabitaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoefNumHabitaciones] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Porciento_BD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Porciento_BD] [float] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Hab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hab] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Mod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mod] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Tipo_Edificio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Edificio] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Subsistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subsistema] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[No_Clasif](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No_Clasif] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Local_Tipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Local_Tipo] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Suelos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Suelo] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Impermeables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Impermeable] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Techos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Techo] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Paredes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pared] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Rodapies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rodapie] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Acabado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Suelo] [int] NOT NULL,
	[Impermeable] [int] NOT NULL,
	[Techo] [int] NOT NULL,
	[Pared] [int] NOT NULL,
	[Rodapie] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Alojamiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Alojamiento_Tipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Alojamiento] [int] NOT NULL,
	[Nombre] [varchar](max)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [int],
	[Cod_0] [int],
	[Cod_1] [int],
	[Cod_2] [int],
	[Coef] [int],
	[CoefNumHabitaciones] [int],
	[Hab] [int],
	[Local_Nombre] [int],
	[Local_Tipo] [int],
	[Mod] [int],
	[No_Clasif] [int],
	[Nombre] [int],
	[Porciento_BD] [int],
	[Subsistema] [int],
	[Tipo_Edificio] [int],
	[Acabado] [int]
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])

-------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[access_Level] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY])


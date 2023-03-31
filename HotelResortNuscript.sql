USE [CatalogoHotel]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/03/2023 22:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[NIdentidad] [nvarchar](25) NOT NULL,
	[Movil] [nvarchar](50) NOT NULL,
	[NHabitacion] [nvarchar](10) NOT NULL,
	[PHabitacion] [money] NOT NULL,
	[FyHRegistro] [datetime] NOT NULL,
	[FyHEntrada] [datetime] NOT NULL,
	[FyHSalida] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 16/03/2023 22:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Movil] [nvarchar](15) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Dui] [nvarchar](15) NOT NULL,
	[ClaveEmpleado] [nvarchar](100) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[TipoCargoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCargo]    Script Date: 16/03/2023 22:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (1, N'Jose', N'vides', N'jose@gmail.com', N'24345464-0', N'24367424', N'5', 99.9900, CAST(N'2023-11-25T00:00:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime), CAST(N'2023-11-26T01:00:00' AS SmallDateTime))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (2, N'Fernando', N'Cras', N'fer@gmail.com', N'24345454-06', N'24743782', N'3', 140.9900, CAST(N'2023-11-15T00:00:00.000' AS DateTime), CAST(N'1900-01-01T02:00:00.000' AS DateTime), CAST(N'2023-11-26T04:00:00' AS SmallDateTime))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (4, N'Adolfo', N'gaiznales', N'adolfo@gmail.com', N'24345637-9', N'24363312', N'1', 29.9900, CAST(N'2023-11-04T00:00:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime), CAST(N'2023-11-16T06:00:00' AS SmallDateTime))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (5, N'Adriana', N'cortez', N'adriana@gmail.com', N'243458459-1', N'24335353', N'43', 69.9900, CAST(N'2023-11-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime), CAST(N'2023-11-12T05:00:00' AS SmallDateTime))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (6, N'Iliana', N'Guadalupe', N'iliana@gmail.com', N'24345423-3', N'24369950', N'16', 45.9900, CAST(N'2023-11-16T00:00:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime), CAST(N'2023-12-09T07:00:00' AS SmallDateTime))
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (7, N'Elizabeth', N'Cordaba', N'Eli@gmail.com', N'24345445-6', N'24367390390', N'15', 97.9900, CAST(N'2023-11-26T00:00:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime), CAST(N'2023-11-30T08:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (1, N'Fernando', N'Crastes', N'fer@gmail.com', N'24345490', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-5', N'394be8619365fa2c196f058704cf114d', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 1)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (2, N'Jorbi', N'Crastes', N'gor@gmail.com', N'24346479', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-6', N'4eae35f1b35977a00ebd8086c259d4c9', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 2)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (3, N'Nicolas', N'Jorge', N'nicolas@gmail.com', N'24348283', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-4', N'ee59c91a09bd84be9eead809a03d95cb', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 3)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (4, N'Pepe', N'Campos', N'pe@gmail.com', N'24138380', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-2', N'897d09da20bcc530dc91e1f1d460cdd2', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 1)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (5, N'Juan', N'Cume', N'juan@gmail.com', N'23282020', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-0', N'd56b699830e77ba53855679cb1d252da', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 4)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Email], [Movil], [Direccion], [Dui], [ClaveEmpleado], [FechaRegistro], [TipoCargoId]) VALUES (6, N'Izidro', N'Castro', N'IZi@gmail.com', N'24383490', N'CALLE AGUSTIN LARA NO. 69-B COL. 2', N'83903082-9', N'4464c921ebf0e63d667ca90d61b22927', CAST(N'2023-03-13T15:58:42.997' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCargo] ON 

INSERT [dbo].[TipoCargo] ([Id], [Cargo]) VALUES (1, N'Gerente')
INSERT [dbo].[TipoCargo] ([Id], [Cargo]) VALUES (2, N'Encargado de sistema')
INSERT [dbo].[TipoCargo] ([Id], [Cargo]) VALUES (3, N'Secretaria')
INSERT [dbo].[TipoCargo] ([Id], [Cargo]) VALUES (4, N'Auxiliar de Gerente')
INSERT [dbo].[TipoCargo] ([Id], [Cargo]) VALUES (5, N'Conserje')
SET IDENTITY_INSERT [dbo].[TipoCargo] OFF
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([TipoCargoId])
REFERENCES [dbo].[TipoCargo] ([Id])
GO

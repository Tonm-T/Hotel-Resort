USE [CatalogoHotel]
GO
/****** Object:  Table [dbo].[CatalogoHotel]    Script Date: 31/03/2023 15:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogoHotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[imagen] [nvarchar](max) NOT NULL,
	[ClaseHabitacion] [nvarchar](100) NOT NULL,
	[Detalles] [nvarchar](max) NOT NULL,
	[Precio] [money] NOT NULL,
	[NumHabitacion] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 31/03/2023 15:25:33 ******/
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
/****** Object:  Table [dbo].[Reservacion]    Script Date: 31/03/2023 15:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[NIdentidad] [nvarchar](25) NOT NULL,
	[Movil] [nvarchar](50) NOT NULL,
	[NHabitacion] [nvarchar](10) NOT NULL,
	[PHabitacion] [decimal](10, 2) NOT NULL,
	[FyHRegistro] [smalldatetime] NOT NULL,
	[FyHEntrada] [smalldatetime] NOT NULL,
	[FyHSalida] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCargo]    Script Date: 31/03/2023 15:25:33 ******/
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
SET IDENTITY_INSERT [dbo].[CatalogoHotel] ON 

INSERT [dbo].[CatalogoHotel] ([Id], [imagen], [ClaseHabitacion], [Detalles], [Precio], [NumHabitacion]) VALUES (1, N'https://media3.giphy.com/media/3KYCpQN2h7UZi418uh/giphy.gif?cid=ecf05e47ostxov9qpjo40in4w0ovpbb93x1n0rh2qv11c1pq&rid=giphy.gif&ct=g', N'Junior Suite', N'Esta elegante suite, situada en la planta Club, cuenta con aire acondicionado y zona de estar independiente con TV LCD de 42 pulgadas con canales por cable y de alta definición. También hay un mini-bar y una cafetera. Internet de alta velocidad está disponible por un suplemento. ', 120.0000, N'1')
SET IDENTITY_INSERT [dbo].[CatalogoHotel] OFF
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
SET IDENTITY_INSERT [dbo].[Reservacion] ON 

INSERT [dbo].[Reservacion] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (1, N'Jose', N'Perez', N'jose@gmail.com', N'45678982-2', N'12382984', N'16', CAST(89.99 AS Decimal(10, 2)), CAST(N'2023-08-12T05:00:00' AS SmallDateTime), CAST(N'2023-11-25T01:30:00' AS SmallDateTime), CAST(N'2023-11-26T11:30:00' AS SmallDateTime))
INSERT [dbo].[Reservacion] ([Id], [Nombre], [Apellido], [Email], [NIdentidad], [Movil], [NHabitacion], [PHabitacion], [FyHRegistro], [FyHEntrada], [FyHSalida]) VALUES (2, N'Ronal', N'Campos', N'jose@gmail.com', N'12345678-9', N'38920101', N'12', CAST(15000.00 AS Decimal(10, 2)), CAST(N'2023-06-14T03:57:00' AS SmallDateTime), CAST(N'2023-01-18T01:58:00' AS SmallDateTime), CAST(N'2023-11-25T01:57:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Reservacion] OFF
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

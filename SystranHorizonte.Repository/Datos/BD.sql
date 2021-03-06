CREATE DATABASE DBSystran
GO
USE [DBSystran]
GO
/****** Object:  Table [dbo].[Carga]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carga](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Peso] [int] NOT NULL,
	[Peso2] [int] NOT NULL,
	[Precio] [decimal](9, 2) NOT NULL,
	[Tipo] [bit] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Carga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DniRuc] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NULL,
	[Cargo] [nvarchar](max) NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estacion]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad] [nvarchar](75) NOT NULL,
	[Provincia] [nvarchar](75) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Estacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Horario]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora] [datetime] NOT NULL,
	[Costo] [decimal](9, 2) NOT NULL,
	[Asientos] [int] NOT NULL,
	[OrigenId] [int] NOT NULL,
	[DestinoId] [int] NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[VehiculoId] [int] NULL,
	[CargaMax] [decimal](18, 2) NOT NULL,
	[CargaActual] [decimal](18, 2) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Horario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegUsuarios]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegUsuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](max) NOT NULL,
	[Modulo] [nvarchar](max) NOT NULL,
	[Cambio] [nvarchar](max) NOT NULL,
	[IdModulo] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.RegUsuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pago] [decimal](18, 2) NULL,
	[Asiento] [int] NULL,
	[ACuenta] [decimal](18, 2) NULL,
	[IdHorario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdCarga] [int] NOT NULL,
	[CargaReserva] [decimal](18, 2) NULL,
	[IdVenta] [int] NULL,
 CONSTRAINT [PK_dbo.Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaPropiedad] [nvarchar](max) NOT NULL,
	[NroPlaca] [nvarchar](max) NOT NULL,
	[FechaSoat] [datetime] NULL,
	[FechaSoatFin] [datetime] NULL,
	[FechaRevisionTecnica] [datetime] NULL,
	[FechaRevisionTecnicaFin] [datetime] NULL,
	[Ancho] [decimal](18, 2) NULL,
	[Largo] [decimal](18, 2) NULL,
	[Asientos] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
	[CargaMax] [decimal](18, 2) NULL,
	[CargaActual] [decimal](18, 2) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venta]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NroVenta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [int] NOT NULL,
	[TotalVenta] [decimal](9, 2) NOT NULL,
	[Estado] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[TotalCarga] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Venta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VentaAsientos]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaAsientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Asiento] [int] NOT NULL,
	[Libre] [bit] NOT NULL,
	[Falsa] [bit] NOT NULL,
	[IdVentaTemp] [int] NULL,
	[IdHorario] [int] NOT NULL,
	[IdVehiculo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.VentaAsientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VentaEncomienda]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaEncomienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaRecepcion] [datetime] NOT NULL,
	[Pago] [decimal](18, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdCarga] [int] NOT NULL,
	[CargaEncomienda] [decimal](18, 2) NULL,
	[IdHorario] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[IdVenta] [int] NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.VentaEncomienda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VentaPasaje]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaPasaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pago] [decimal](18, 2) NULL,
	[Asiento] [int] NULL,
	[IdHorario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdCarga] [int] NOT NULL,
	[CargaPasaje] [decimal](18, 2) NULL,
	[IdVenta] [int] NULL,
 CONSTRAINT [PK_dbo.VentaPasaje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 27/11/2015 17:28:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Horario_dbo.Empleado_EmpleadoId] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([Id])
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_dbo.Horario_dbo.Empleado_EmpleadoId]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Horario_dbo.Estacion_DestinoId] FOREIGN KEY([DestinoId])
REFERENCES [dbo].[Estacion] ([Id])
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_dbo.Horario_dbo.Estacion_DestinoId]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Horario_dbo.Estacion_OrigenId] FOREIGN KEY([OrigenId])
REFERENCES [dbo].[Estacion] ([Id])
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_dbo.Horario_dbo.Estacion_OrigenId]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reserva_dbo.Carga_IdCarga] FOREIGN KEY([IdCarga])
REFERENCES [dbo].[Carga] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_dbo.Reserva_dbo.Carga_IdCarga]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reserva_dbo.Cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_dbo.Reserva_dbo.Cliente_IdCliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reserva_dbo.Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_dbo.Reserva_dbo.Horario_IdHorario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reserva_dbo.Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_dbo.Reserva_dbo.Venta_IdVenta]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Venta_dbo.Cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_dbo.Venta_dbo.Cliente_IdCliente]
GO
ALTER TABLE [dbo].[VentaAsientos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaAsientos_dbo.Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaAsientos] CHECK CONSTRAINT [FK_dbo.VentaAsientos_dbo.Horario_IdHorario]
GO
ALTER TABLE [dbo].[VentaAsientos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaAsientos_dbo.Vehiculo_IdVehiculo] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculo] ([Id])
GO
ALTER TABLE [dbo].[VentaAsientos] CHECK CONSTRAINT [FK_dbo.VentaAsientos_dbo.Vehiculo_IdVehiculo]
GO
ALTER TABLE [dbo].[VentaEncomienda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Carga_IdCarga] FOREIGN KEY([IdCarga])
REFERENCES [dbo].[Carga] ([Id])
GO
ALTER TABLE [dbo].[VentaEncomienda] CHECK CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Carga_IdCarga]
GO
ALTER TABLE [dbo].[VentaEncomienda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[VentaEncomienda] CHECK CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Cliente_IdCliente]
GO
ALTER TABLE [dbo].[VentaEncomienda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
GO
ALTER TABLE [dbo].[VentaEncomienda] CHECK CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Horario_IdHorario]
GO
ALTER TABLE [dbo].[VentaEncomienda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaEncomienda] CHECK CONSTRAINT [FK_dbo.VentaEncomienda_dbo.Venta_IdVenta]
GO
ALTER TABLE [dbo].[VentaPasaje]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaPasaje_dbo.Carga_IdCarga] FOREIGN KEY([IdCarga])
REFERENCES [dbo].[Carga] ([Id])
GO
ALTER TABLE [dbo].[VentaPasaje] CHECK CONSTRAINT [FK_dbo.VentaPasaje_dbo.Carga_IdCarga]
GO
ALTER TABLE [dbo].[VentaPasaje]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaPasaje_dbo.Cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[VentaPasaje] CHECK CONSTRAINT [FK_dbo.VentaPasaje_dbo.Cliente_IdCliente]
GO
ALTER TABLE [dbo].[VentaPasaje]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaPasaje_dbo.Horario_IdHorario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
GO
ALTER TABLE [dbo].[VentaPasaje] CHECK CONSTRAINT [FK_dbo.VentaPasaje_dbo.Horario_IdHorario]
GO
ALTER TABLE [dbo].[VentaPasaje]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VentaPasaje_dbo.Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaPasaje] CHECK CONSTRAINT [FK_dbo.VentaPasaje_dbo.Venta_IdVenta]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO

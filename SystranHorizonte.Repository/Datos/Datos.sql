USE [DBSystran]
GO
SET IDENTITY_INSERT [dbo].[Carga] ON 

GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (1, 0, 0, CAST(0.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (2, 0, 10, CAST(10.00 AS Decimal(9, 2)), 0, 0)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (3, 10, 20, CAST(20.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (4, 20, 40, CAST(40.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (5, 0, 0, CAST(0.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (6, 0, 10, CAST(15.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (7, 10, 20, CAST(25.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (8, 20, 30, CAST(45.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (9, 30, 40, CAST(5.00 AS Decimal(9, 2)), 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Carga] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (1, N'Jorge', N'Quizpe', N'123456', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (2, N'Carlos', N'Alberto', N'147852', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (3, N'Juan', N'Garcia', N'258963', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (4, N'Cesar', N'Dias', N'932258', N'Conductor', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Estacion] ON 

GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (1, N'Cajamarca', N'Cajamarca', N'Jr. Angamos 1475', N'123456', N'CC01', 1)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (2, N'Cajamarca', N'San Miguel', N'Jr. La libertad', N'123748', N'CS01', 0)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (3, N'Cajamarca', N'SanMarcos', N'Jr. Angeles 147', N'123485', N'CS02', 1)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (4, N'Cajamarca', N'San Miguel', N'Jr. La libertad 1540', N'254752', N'CS03', 1)
GO
SET IDENTITY_INSERT [dbo].[Estacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

GO
INSERT [dbo].[Vehiculo] ([Id], [TarjetaPropiedad], [NroPlaca], [FechaSoat], [FechaSoatFin], [FechaRevisionTecnica], [FechaRevisionTecnicaFin], [Ancho], [Largo], [Asientos], [Tipo], [CargaMax], [CargaActual], [Estado]) VALUES (1, N'4575', N'ADR-5478', CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A5D100000000 AS DateTime), CAST(0x0000A52200000000 AS DateTime), CAST(0x0000A61500000000 AS DateTime), CAST(2.10 AS Decimal(18, 2)), CAST(4.20 AS Decimal(18, 2)), 16, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Vehiculo] ([Id], [TarjetaPropiedad], [NroPlaca], [FechaSoat], [FechaSoatFin], [FechaRevisionTecnica], [FechaRevisionTecnicaFin], [Ancho], [Largo], [Asientos], [Tipo], [CargaMax], [CargaActual], [Estado]) VALUES (2, N'4457', N'ASF-1447', CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A5D100000000 AS DateTime), CAST(0x0000A51800000000 AS DateTime), CAST(0x0000A61500000000 AS DateTime), CAST(2.10 AS Decimal(18, 2)), CAST(4.20 AS Decimal(18, 2)), 16, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Vehiculo] ([Id], [TarjetaPropiedad], [NroPlaca], [FechaSoat], [FechaSoatFin], [FechaRevisionTecnica], [FechaRevisionTecnicaFin], [Ancho], [Largo], [Asientos], [Tipo], [CargaMax], [CargaActual], [Estado]) VALUES (3, N'5478', N'FDF-5485', CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A5D100000000 AS DateTime), CAST(0x0000A51800000000 AS DateTime), CAST(0x0000A61500000000 AS DateTime), CAST(2.10 AS Decimal(18, 2)), CAST(4.20 AS Decimal(18, 2)), 16, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Vehiculo] ([Id], [TarjetaPropiedad], [NroPlaca], [FechaSoat], [FechaSoatFin], [FechaRevisionTecnica], [FechaRevisionTecnicaFin], [Ancho], [Largo], [Asientos], [Tipo], [CargaMax], [CargaActual], [Estado]) VALUES (4, N'5489', N'FDG-5482', CAST(0x0000A52200000000 AS DateTime), CAST(0x0000A5D100000000 AS DateTime), CAST(0x0000A49D00000000 AS DateTime), CAST(0x0000A61500000000 AS DateTime), CAST(2.10 AS Decimal(18, 2)), CAST(4.20 AS Decimal(18, 2)), 16, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Vehiculo] ([Id], [TarjetaPropiedad], [NroPlaca], [FechaSoat], [FechaSoatFin], [FechaRevisionTecnica], [FechaRevisionTecnicaFin], [Ancho], [Largo], [Asientos], [Tipo], [CargaMax], [CargaActual], [Estado]) VALUES (5, N'8543', N'FDG-4558', CAST(0x0000A57D00000000 AS DateTime), CAST(0x0000A5AE00000000 AS DateTime), CAST(0x0000A59200000000 AS DateTime), CAST(0x0000A62A00000000 AS DateTime), CAST(2.10 AS Decimal(18, 2)), CAST(4.20 AS Decimal(18, 2)), 16, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO

USE [DBSystran]
GO
SET IDENTITY_INSERT [dbo].[Carga] ON 

GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (1, 0, 0, CAST(0.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (2, 1, 9, CAST(10.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (3, 10, 19, CAST(20.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (4, 20, 50, CAST(40.00 AS Decimal(9, 2)), 0, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (5, 0, 0, CAST(0.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (6, 1, 9, CAST(15.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (7, 10, 19, CAST(25.00 AS Decimal(9, 2)), 1, 1)
GO
INSERT [dbo].[Carga] ([Id], [Peso], [Peso2], [Precio], [Tipo], [Estado]) VALUES (8, 20, 50, CAST(45.00 AS Decimal(9, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Carga] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (1, N'70000001', N'FLOR DE MARIA', N'ALARCON SAMAME ', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (2, N'70000002', N' RONALD GABINO', N'BURGA GUTIERREZ', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (3, N'70000003', N'NORMA LIZETH', N'CARHUAS ENCISO', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (4, N'70000004', N'ESBONEMER', N'CLEMENTE PERALTA', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (5, N'70000005', N'IRIS SILVIA', N'DURAND ANYOSA', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (6, N'70000006', N'JOSE IGNACIO', N'FLORES VILLA', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (7, N'70000007', N'HULBER', N'GARCIA OROZCO', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (8, N'70000008', N'VILMA LUISA', N'SUAREZ FLORIAN', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (9, N'70000009', N'JENNY', N'VILLANUEVA CUSIHUALLPA ', NULL, NULL)
GO
INSERT [dbo].[Cliente] ([Id], [DniRuc], [Nombre], [Apellidos], [Direccion], [Telefono]) VALUES (10, N'70000010', N'KARINA MIRIAN', N'ZEGARRA ELIAS', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (1, N'EVER ', N'HERNANDEZ SANCHEZ', N'976584520', N'Administrador', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (2, N'LUIS FRANCISCO', N'SALAZAR REATEGUI', N'975845242', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (3, N'GUSTAVO EDUARDO', N'RUIZ SARMIENTO', N'986574262', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (4, N'MARIA LUISA', N'QUISPE VELAZCO', N'975368524', N'Vendedor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (5, N'CARLOS MANUEL', N'PAREDES EPEQUIN', N'975845245', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (6, N'JOSE ANTONIO', N'NOVOA VILLALVA', N'975863542', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (7, N'RICARDO HUMBERTO', N'MONTALVO CHAVEZ', N'976585245', N'Conductor', NULL, 1)
GO
INSERT [dbo].[Empleado] ([Id], [Nombre], [Apellidos], [Telefono], [Cargo], [Comentario], [Estado]) VALUES (8, N'JULIO', N'MARIN AGUIRRE', N'976359542', N'Conductor', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Estacion] ON 

GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (1, N'Cajamarca', N'Cajamarca', N'Jr. Angamos 1475', N'123456', N'CC01', 1)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (2, N'Cajamarca', N'San Miguel', N'Jr. La libertad', N'123748', N'CS01', 0)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (3, N'Cajamarca', N'San Pablo', N'Jr. Angeles 147', N'123485', N'CS02', 1)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (4, N'Cajamarca', N'Cochan', N'Jr. La libertad 1540', N'254752', N'CS03', 1)
GO
INSERT [dbo].[Estacion] ([Id], [Ciudad], [Provincia], [Direccion], [Telefono], [Codigo], [Estado]) VALUES (5, N'Cajamarca', N'Llapa', N'Av. Independencia 21', N'975845242', N'CS04', 1)
GO
SET IDENTITY_INSERT [dbo].[Estacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Horario] ON 

GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (1, CAST(0x0000A554004A2860 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 1, 2, 2, 1, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (2, CAST(0x0000A55400B54640 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 1, 2, 3, 2, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (3, CAST(0x0000A55400E6B680 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 1, 2, 5, 3, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (4, CAST(0x0000A5540107AC00 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 1, 2, 6, 4, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (5, CAST(0x0000A55401206420 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 1, 2, 7, 5, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Horario] ([Id], [Hora], [Costo], [Asientos], [OrigenId], [DestinoId], [EmpleadoId], [VehiculoId], [CargaMax], [CargaActual], [Estado]) VALUES (6, CAST(0x0000A5540083D600 AS DateTime), CAST(13.00 AS Decimal(9, 2)), 16, 2, 1, 2, 1, CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Horario] OFF
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
SET IDENTITY_INSERT [dbo].[VentaAsientos] ON 

GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (1, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (2, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (3, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (4, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (5, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (6, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (7, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (8, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (9, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (10, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (11, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (12, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (13, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (14, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (15, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (16, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (17, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (18, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (19, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (20, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (21, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (22, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (23, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (24, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (25, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (26, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (27, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (28, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (29, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (30, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (31, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (32, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 2, 2)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (33, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (34, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (35, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (36, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (37, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (38, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (39, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (40, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (41, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (42, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (43, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (44, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (45, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (46, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (47, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (48, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 3, 3)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (49, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (50, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (51, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (52, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (53, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (54, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (55, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (56, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (57, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (58, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (59, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (60, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (61, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (62, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (63, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (64, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 4, 4)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (65, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (66, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (67, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (68, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (69, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (70, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (71, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (72, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (73, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (74, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (75, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (76, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (77, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (78, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (79, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (80, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 5, 5)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (81, CAST(0x0000A55400000000 AS DateTime), 1, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (82, CAST(0x0000A55400000000 AS DateTime), 2, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (83, CAST(0x0000A55400000000 AS DateTime), 3, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (84, CAST(0x0000A55400000000 AS DateTime), 4, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (85, CAST(0x0000A55400000000 AS DateTime), 5, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (86, CAST(0x0000A55400000000 AS DateTime), 6, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (87, CAST(0x0000A55400000000 AS DateTime), 7, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (88, CAST(0x0000A55400000000 AS DateTime), 8, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (89, CAST(0x0000A55400000000 AS DateTime), 9, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (90, CAST(0x0000A55400000000 AS DateTime), 10, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (91, CAST(0x0000A55400000000 AS DateTime), 11, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (92, CAST(0x0000A55400000000 AS DateTime), 12, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (93, CAST(0x0000A55400000000 AS DateTime), 13, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (94, CAST(0x0000A55400000000 AS DateTime), 14, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (95, CAST(0x0000A55400000000 AS DateTime), 15, 1, 1, 0, 6, 1)
GO
INSERT [dbo].[VentaAsientos] ([Id], [Fecha], [Asiento], [Libre], [Falsa], [IdVentaTemp], [IdHorario], [IdVehiculo]) VALUES (96, CAST(0x0000A55400000000 AS DateTime), 16, 1, 1, 0, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[VentaAsientos] OFF
GO

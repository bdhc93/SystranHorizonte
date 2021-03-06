USE [DBSystran]
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleVentaEncomienda]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleVentaEncomienda]
	@IdVenta int
AS
BEGIN
	DELETE FROM VentaEncomienda
	WHERE IdVenta = @IdVenta
END


GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleVentaPasaje]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleVentaPasaje]
	@IdVenta int
AS
BEGIN
	DELETE FROM VentaPasaje
	WHERE IdVenta = @IdVenta
END




GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleVentaReserva]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleVentaReserva]
	@IdVenta int
AS
BEGIN
	DELETE FROM Reserva
	WHERE IdVenta = @IdVenta
END


GO
/****** Object:  StoredProcedure [dbo].[GenerarAsientosHorario]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerarAsientosHorario]
	@Asiento int, 
	@Libre bit, 
	@Falsa bit, 
	@IdVentaTemp int, 
	@IdHorario int, 
	@IdVehiculo int
AS
BEGIN
	INSERT INTO VentaAsientos
                  (Fecha, Asiento, Libre, Falsa, IdVentaTemp, IdHorario, IdVehiculo)
VALUES (GETDATE(),@Asiento, @Libre, @Falsa, @IdVentaTemp, @IdHorario, @IdVehiculo)
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateVentaEncomienda]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaEncomienda]
	@Pago varchar(50), 
	@IdCliente int, 
	@IdCarga int, 
	@CargaEncomienda varchar(50), 
	@IdHorario int, 
	@Estado varchar(50), 
	@IdVenta int, 
	@Descripcion varchar(500)
AS
BEGIN
	INSERT INTO VentaEncomienda
                  (FechaRecepcion, Pago, IdCliente, IdCarga, CargaEncomienda, IdHorario, Estado, IdVenta, Descripcion)
	VALUES (DATEADD(HOUR,6,(Select Hora from Horario where Id = @IdHorario)), @Pago, @IdCliente, @IdCarga, @CargaEncomienda, @IdHorario, @Estado, @IdVenta, @Descripcion)
	
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateVentaPasaje]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaPasaje] 
	@Pago varchar(50),
	@Asiento int,
	@IdHorario int,
	@IdCliente int,
	@IdCarga int,
	@Carga varchar(50),
	@IdVenta int
AS
BEGIN
	INSERT INTO VentaPasaje
                  (Pago, Asiento, IdHorario, IdCliente, IdCarga, CargaPasaje, IdVenta)
	VALUES (@Pago,@Asiento,@IdHorario,@IdCliente,@IdCarga,@Carga,@IdVenta)
END




GO
/****** Object:  StoredProcedure [dbo].[UpdateVentaReserva]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaReserva]
	@Pago varchar(50), 
	@Asiento int, 
	@ACuenta varchar(50), 
	@IdHorario int, 
	@IdCliente int, 
	@IdCarga int, 
	@CargaReserva varchar(50), 
	@IdVenta int
AS
BEGIN
	INSERT INTO Reserva
                  (Pago, Asiento, ACuenta, IdHorario, IdCliente, IdCarga, CargaReserva, IdVenta)
VALUES (@Pago, @Asiento, @ACuenta, @IdHorario, @IdCliente, @IdCarga, @CargaReserva, @IdVenta)
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateVentaSUPER]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaSUPER]
	@NroVenta int,
	@Tipo bit,
	@TotalVenta varchar(50),
	@IdCliente int,
	@Id int,
	@TotalCarga varchar(50)
AS
BEGIN
	UPDATE Venta
	SET          NroVenta =@NroVenta, Fecha =GETDATE(), Tipo =@Tipo, TotalVenta =@TotalVenta, IdCliente =@IdCliente, TotalCarga =@TotalCarga
	WHERE Id = @Id
END




GO
/****** Object:  View [dbo].[DetalleEmpleados]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DetalleEmpleados] as
SELECT dbo.VentaAsientos.Id, dbo.VentaAsientos.Fecha, dbo.VentaAsientos.IdHorario, dbo.Horario.OrigenId, dbo.Horario.DestinoId, dbo.VentaAsientos.IdVehiculo, dbo.Vehiculo.TarjetaPropiedad, dbo.Vehiculo.NroPlaca, 
                  dbo.Horario.Hora
FROM     dbo.VentaAsientos INNER JOIN
                  dbo.Horario ON dbo.VentaAsientos.IdHorario = dbo.Horario.Id INNER JOIN
                  dbo.Vehiculo ON dbo.VentaAsientos.IdVehiculo = dbo.Vehiculo.Id
GO
/****** Object:  View [dbo].[DetalleVenta]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DetalleVenta] as
SELECT dbo.Venta.Id, dbo.Venta.NroVenta, dbo.VentaPasaje.IdVenta, dbo.VentaPasaje.Pago, dbo.VentaPasaje.Asiento, dbo.Horario.Costo, dbo.Cliente.Apellidos, dbo.Cliente.Direccion, dbo.Cliente.DniRuc, dbo.Horario.OrigenId, 
                  dbo.Horario.DestinoId, dbo.Horario.Hora
FROM     dbo.Venta INNER JOIN
                  dbo.VentaPasaje ON dbo.Venta.Id = dbo.VentaPasaje.IdVenta INNER JOIN
                  dbo.Horario ON dbo.VentaPasaje.IdHorario = dbo.Horario.Id INNER JOIN
                  dbo.Cliente ON dbo.Venta.IdCliente = dbo.Cliente.Id AND dbo.VentaPasaje.IdCliente = dbo.Cliente.Id


GO
/****** Object:  View [dbo].[DetalleVentaPasajes]    Script Date: 26/11/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[DetalleVentaPasajes] as
SELECT dbo.Venta.Id, dbo.Venta.NroVenta, dbo.Cliente.DniRuc, dbo.Cliente.Nombre, dbo.Cliente.Telefono, dbo.Venta.TotalVenta, dbo.Venta.Fecha, dbo.Cliente.Apellidos, dbo.Cliente.Direccion, dbo.Horario.OrigenId, 
                  dbo.Horario.DestinoId, dbo.Horario.Hora, dbo.VentaPasaje.Asiento, dbo.VentaPasaje.Pago
FROM     dbo.VentaPasaje INNER JOIN
                  dbo.Horario ON dbo.VentaPasaje.IdHorario = dbo.Horario.Id INNER JOIN
                  dbo.Cliente ON dbo.VentaPasaje.IdCliente = dbo.Cliente.Id INNER JOIN
                  dbo.Venta ON dbo.VentaPasaje.IdVenta = dbo.Venta.Id AND dbo.Cliente.Id = dbo.Venta.IdCliente

GO

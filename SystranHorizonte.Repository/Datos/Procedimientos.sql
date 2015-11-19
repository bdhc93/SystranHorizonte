USE [DBSystran]
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleVentaPasaje]    Script Date: 18/11/2015 19:30:52 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateVentaPasaje]    Script Date: 18/11/2015 19:30:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaPasaje] 
	@Pago varchar,
	@Asiento int,
	@IdHorario int,
	@IdCliente int,
	@IdCarga int,
	@IdVenta int
AS
BEGIN
	INSERT INTO VentaPasaje
                  (Pago, Asiento, IdHorario, IdCliente, IdCarga, IdVenta)
	VALUES (@Pago,@Asiento,@IdHorario,@IdCliente,@IdCarga,@IdVenta)
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateVentaSUPER]    Script Date: 18/11/2015 19:30:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVentaSUPER]
	@NroVenta int,
	@Tipo bit,
	@TotalVenta varchar,
	@IdCliente int,
	@Id int
AS
BEGIN
	UPDATE Venta
	SET          NroVenta =@NroVenta, Fecha =GETDATE(), Tipo =@Tipo, TotalVenta =@TotalVenta, IdCliente =@IdCliente
	WHERE Id = @Id
END


GO
/****** Object:  View [dbo].[DetalleVenta]    Script Date: 18/11/2015 19:30:52 ******/
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

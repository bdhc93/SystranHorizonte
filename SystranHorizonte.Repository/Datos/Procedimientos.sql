USE [DBSystran]
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleVentaPasaje]    Script Date: 09/11/2015 9:26:15 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateVentaPasaje]    Script Date: 09/11/2015 9:26:15 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateVentaSUPER]    Script Date: 09/11/2015 9:26:15 ******/
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

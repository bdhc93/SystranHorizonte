using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IVentaRepository
    {
        Venta ObtenerVentaPorId(Int32 id);
        IEnumerable<Venta> ObtenerVentasPorCriterio(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);
        IEnumerable<Venta> ObtenerVentas();
        IEnumerable<Venta> ObtenerEncomiendas(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);
        IEnumerable<Venta> ObtenerReservas(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);
        Venta ObtenerVentaporNroVenta(Int32 nroVenta);

        Int32 ObtenerNroVenta();

        int GuardarVenta(Venta venta);
        void ModificarVenta(Venta venta);
        void EliminarVenta(Int32 id);
    }
}

using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IVentaRepository
    {
        Venta ObtenerVentaPorId(Int32 id);
        IEnumerable<Venta> ObtenerVentasPorCriterio(String criterio, DateTime fechaIni, DateTime fechaFin);
        IEnumerable<Venta> ObtenerVentas();

        Int32 ObtenerNroVenta();

        void GuardarVenta(Venta venta);
        void ModificarVenta(Venta venta);
        void EliminarVenta(Int32 id);
    }
}

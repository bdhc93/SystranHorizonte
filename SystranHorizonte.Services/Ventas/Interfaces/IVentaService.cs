using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IVentaService
    {
        Venta ObtenerVentaPorId(Int32 id);
        IEnumerable<Venta> ObtenerVentasPorCriterio(String criterio, DateTime fechaIni, DateTime fechaFin);
        IEnumerable<Venta> ObtenerVentas();

        Int32 ObtenerNroVenta();

        int GuardarVenta(Venta venta);
        void ModificarVenta(Venta venta);
        void EliminarVenta(Int32 id);
    }
}

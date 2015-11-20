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
        IEnumerable<Venta> ObtenerVentasPorCriterio(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);
        IEnumerable<Venta> ObtenerVentas();
        IEnumerable<Venta> ObtenerEncomiendas(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);
        IEnumerable<Venta> ObtenerReservas(String criterio, DateTime fechaIni, DateTime fechaFin, Int32 idestacion);

        Int32 ObtenerNroVenta();

        int GuardarVenta(Venta venta);
        void ModificarVenta(Venta venta);
        void EliminarVenta(Int32 id);
    }
}

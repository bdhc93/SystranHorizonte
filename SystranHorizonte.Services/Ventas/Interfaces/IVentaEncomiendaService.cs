using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IVentaEncomiendaService
    {
        VentaEncomienda ObtenerVentaEncomiendaPorId(Int32 id);
        IEnumerable<VentaEncomienda> ObtenerVentaEncomiendasPorCriterio(String criterio);

        void GuardarVentaEncomienda(VentaEncomienda venta);
        void ModificarVentaEncomienda(VentaEncomienda venta);
        void EliminarVentaEncomienda(Int32 id);
    }
}

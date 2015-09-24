using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IVentaEncomiendaRepository
    {
        VentaEncomienda ObtenerVentaEncomiendaPorId(Int32 id);
        IEnumerable<VentaEncomienda> ObtenerVentaEncomiendasPorCriterio(String criterio);

        void GuardarVentaEncomienda(VentaEncomienda venta);
        void ModificarVentaEncomienda(VentaEncomienda venta);
        void EliminarVentaEncomienda(Int32 id);
    }
}

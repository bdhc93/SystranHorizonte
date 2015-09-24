using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IVentaPasajeService
    {
        VentaPasaje ObtenerVentaPasajePorId(Int32 id);
        IEnumerable<VentaPasaje> ObtenerVentaPasajesPorCriterio(String criterio);

        void GuardarVentaPasaje(VentaPasaje venta);
        void ModificarVentaPasaje(VentaPasaje venta);
        void EliminarVentaPasaje(Int32 id);
    }
}

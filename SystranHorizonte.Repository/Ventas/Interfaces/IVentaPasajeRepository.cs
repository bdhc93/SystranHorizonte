using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IVentaPasajeRepository
    {
        VentaPasaje ObtenerVentaPasajePorId(Int32 id);
        IEnumerable<VentaPasaje> ObtenerVentaPasajesPorCriterio(String criterio);

        void GuardarVentaPasaje(VentaPasaje venta);
        void ModificarVentaPasaje(VentaPasaje venta);
        void EliminarVentaPasaje(Int32 id);
    }
}

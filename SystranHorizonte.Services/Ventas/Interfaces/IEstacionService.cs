using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IEstacionService
    {
        Estacion ObtenerEstacionPorId(Int32 id);
        IEnumerable<Estacion> ObtenerEstacionsPorCriterio(String criterio);

        void GuardarEstacion(Estacion estacion);
        void ModificarEstacion(Estacion estacion);
        void EliminarEstacion(Int32 id);
    }
}

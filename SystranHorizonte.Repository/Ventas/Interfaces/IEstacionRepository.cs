using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IEstacionRepository
    {
        Estacion ObtenerEstacionPorId(Int32 id);
        IEnumerable<Estacion> ObtenerEstacionsPorCriterio(String criterio);

        void GuardarEstacion(Estacion estacion);
        void ModificarEstacion(Estacion estacion);
        void EliminarEstacion(Int32 id);
    }
}

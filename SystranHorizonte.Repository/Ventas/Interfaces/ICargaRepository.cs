using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface ICargaRepository
    {
        Carga ObtenerCargaPorId(Int32 id);
        IEnumerable<Carga> ObtenerCargasPorCriterio(String criterio);
        Carga ObtenerCargaPorRango(Decimal carga, Boolean tipo);

        void GuardarCarga(Carga carga);
        void ModificarCarga(Carga carga);
        void EliminarCarga(Int32 id);
    }
}

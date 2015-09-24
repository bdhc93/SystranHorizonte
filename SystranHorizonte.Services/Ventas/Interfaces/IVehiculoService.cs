using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IVehiculoService
    {
        Vehiculo ObtenerVehiculoPorId(Int32 id);
        IEnumerable<Vehiculo> ObtenerVehiculosPorCriterio(String criterio);

        void GuardarVehiculo(Vehiculo vehiculo);
        void ModificarVehiculo(Vehiculo vehiculo);
        void EliminarVehiculo(Int32 id);
    }
}

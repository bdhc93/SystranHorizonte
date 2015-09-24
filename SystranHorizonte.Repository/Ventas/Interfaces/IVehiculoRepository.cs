using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IVehiculoRepository
    {
        Vehiculo ObtenerVehiculoPorId(Int32 id);
        IEnumerable<Vehiculo> ObtenerVehiculosPorCriterio(String criterio);

        void GuardarVehiculo(Vehiculo vehiculo);
        void ModificarVehiculo(Vehiculo vehiculo);
        void EliminarVehiculo(Int32 id);
    }
}

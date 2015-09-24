using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class VehiculoService : IVehiculoService
    {
        public IVehiculoRepository vehiculoRepository { get; set; }

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            return vehiculoRepository.ObtenerVehiculoPorId(id);
        }

        public IEnumerable<Vehiculo> ObtenerVehiculosPorCriterio(string criterio)
        {
            return vehiculoRepository.ObtenerVehiculosPorCriterio(criterio);
        }

        public void GuardarVehiculo(Vehiculo vehiculo)
        {
            vehiculoRepository.GuardarVehiculo(vehiculo);
        }

        public void ModificarVehiculo(Vehiculo vehiculo)
        {
            vehiculoRepository.ModificarVehiculo(vehiculo);
        }

        public void EliminarVehiculo(int id)
        {
            vehiculoRepository.EliminarVehiculo(id);
        }
    }
}

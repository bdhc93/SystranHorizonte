using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class EstacionService : IEstacionService
    {
        public IEstacionRepository estacionRepository { get; set; }

        public EstacionService(IEstacionRepository estacionRepository)
        {
            this.estacionRepository = estacionRepository;
        }

        public Estacion ObtenerEstacionPorId(int id)
        {
            return estacionRepository.ObtenerEstacionPorId(id);
        }

        public IEnumerable<Estacion> ObtenerEstacionsPorCriterio(string criterio)
        {
            return estacionRepository.ObtenerEstacionsPorCriterio(criterio);
        }

        public void GuardarEstacion(Estacion estacion)
        {
            estacionRepository.GuardarEstacion(estacion);
        }

        public void ModificarEstacion(Estacion estacion)
        {
            estacionRepository.ModificarEstacion(estacion);
        }

        public void EliminarEstacion(int id)
        {
            estacionRepository.EliminarEstacion(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class CargaService : ICargaService
    {
        public ICargaRepository cargaRepository { get; set; }

        public CargaService(ICargaRepository cargaRepository)
        {
            this.cargaRepository = cargaRepository;
        }

        public Carga ObtenerCargaPorId(int id)
        {
            return cargaRepository.ObtenerCargaPorId(id);
        }

        public IEnumerable<Carga> ObtenerCargasPorCriterio(string criterio)
        {
            return cargaRepository.ObtenerCargasPorCriterio(criterio);
        }

        public void GuardarCarga(Carga carga)
        {
            cargaRepository.GuardarCarga(carga);
        }

        public void ModificarCarga(Carga carga)
        {
            cargaRepository.ModificarCarga(carga);
        }

        public void EliminarCarga(int id)
        {
            cargaRepository.EliminarCarga(id);
        }
    }
}

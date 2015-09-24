using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class VentaPasajeService : IVentaPasajeService
    {
        public IVentaPasajeRepository ventaPasajeRepository { get; set; }

        public VentaPasajeService(IVentaPasajeRepository ventaPasajeRepository)
        {
            this.ventaPasajeRepository = ventaPasajeRepository;
        }

        public VentaPasaje ObtenerVentaPasajePorId(int id)
        {
            return ventaPasajeRepository.ObtenerVentaPasajePorId(id);
        }

        public IEnumerable<VentaPasaje> ObtenerVentaPasajesPorCriterio(string criterio)
        {
            return ventaPasajeRepository.ObtenerVentaPasajesPorCriterio(criterio);
        }

        public void GuardarVentaPasaje(VentaPasaje venta)
        {
            ventaPasajeRepository.GuardarVentaPasaje(venta);
        }

        public void ModificarVentaPasaje(VentaPasaje venta)
        {
            ventaPasajeRepository.ModificarVentaPasaje(venta);
        }

        public void EliminarVentaPasaje(int id)
        {
            ventaPasajeRepository.EliminarVentaPasaje(id);
        }
    }
}

using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class VentaEncomiendaService : IVentaEncomiendaService
    {
        public IVentaEncomiendaRepository ventaEncomiendaRepository { get; set; }

        public VentaEncomiendaService(IVentaEncomiendaRepository ventaEncomiendaRepository)
        {
            this.ventaEncomiendaRepository = ventaEncomiendaRepository;
        }

        public VentaEncomienda ObtenerVentaEncomiendaPorId(int id)
        {
            return ventaEncomiendaRepository.ObtenerVentaEncomiendaPorId(id);
        }

        public IEnumerable<VentaEncomienda> ObtenerVentaEncomiendasPorCriterio(string criterio)
        {
            return ventaEncomiendaRepository.ObtenerVentaEncomiendasPorCriterio(criterio);
        }

        public void GuardarVentaEncomienda(VentaEncomienda venta)
        {
            ventaEncomiendaRepository.GuardarVentaEncomienda(venta);
        }

        public void ModificarVentaEncomienda(VentaEncomienda venta)
        {
            ventaEncomiendaRepository.ModificarVentaEncomienda(venta);
        }

        public void EliminarVentaEncomienda(int id)
        {
            ventaEncomiendaRepository.EliminarVentaEncomienda(id);
        }
    }
}

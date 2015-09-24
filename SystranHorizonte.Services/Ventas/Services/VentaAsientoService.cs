using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class VentaAsientoService : IVentaAsientoService
    {
        public IVentaAsientoRepository ventaAsientoRepository { get; set; }

        public VentaAsientoService(IVentaAsientoRepository ventaAsientoRepository)
        {
            this.ventaAsientoRepository = ventaAsientoRepository;
        }

        public VentaAsientos ObtenerVentaAsientosPorId(int id)
        {
            return ventaAsientoRepository.ObtenerVentaAsientosPorId(id);
        }

        public IEnumerable<VentaAsientos> ObtenerVentaAsientossPorCriterio(string criterio)
        {
            return ventaAsientoRepository.ObtenerVentaAsientossPorCriterio(criterio);
        }

        public void GuardarVentaAsientos(VentaAsientos ventaAsientos)
        {
            ventaAsientoRepository.GuardarVentaAsientos(ventaAsientos);
        }

        public void ModificarVentaAsientos(VentaAsientos ventaAsientos)
        {
            ventaAsientoRepository.ModificarVentaAsientos(ventaAsientos);
        }

        public void EliminarVentaAsientos(int id)
        {
            ventaAsientoRepository.EliminarVentaAsientos(id);
        }

        public IEnumerable<VentaAsientos> ObtenerVentaAsientosPorHorario(int id)
        {
            return ventaAsientoRepository.ObtenerVentaAsientosPorHorario(id);
        }
    }
}
using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class VentaService : IVentaService
    {
        public IVentaRepository ventaRepository { get; set; }

        public VentaService(IVentaRepository ventaRepository)
        {
            this.ventaRepository = ventaRepository;
        }

        public Venta ObtenerVentaPorId(int id)
        {
            return ventaRepository.ObtenerVentaPorId(id);
        }

        public IEnumerable<Venta> ObtenerVentasPorCriterio(string criterio, DateTime fechaIni, DateTime fechaFin)
        {
            return ventaRepository.ObtenerVentasPorCriterio(criterio, fechaIni, fechaFin);
        }

        public void GuardarVenta(Venta venta)
        {
            ventaRepository.GuardarVenta(venta);
        }

        public void ModificarVenta(Venta venta)
        {
            ventaRepository.ModificarVenta(venta);
        }

        public void EliminarVenta(int id)
        {
            ventaRepository.EliminarVenta(id);
        }

        public IEnumerable<Venta> ObtenerVentas()
        {
            return ventaRepository.ObtenerVentas();
        }
    }
}

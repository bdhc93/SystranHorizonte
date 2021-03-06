﻿using System;
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

        public IEnumerable<Venta> ObtenerVentasPorCriterio(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            return ventaRepository.ObtenerVentasPorCriterio(criterio, fechaIni, fechaFin, idestacion);
        }

        public int GuardarVenta(Venta venta)
        {
            return ventaRepository.GuardarVenta(venta);
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

        public int ObtenerNroVenta()
        {
            return ventaRepository.ObtenerNroVenta();
        }

        public IEnumerable<Venta> ObtenerEncomiendas(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            return ventaRepository.ObtenerEncomiendas(criterio, fechaIni, fechaFin, idestacion);
        }

        public IEnumerable<Venta> ObtenerReservas(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            return ventaRepository.ObtenerReservas(criterio, fechaIni, fechaFin, idestacion);
        }

        public Venta ObtenerVentaporNroVenta(int nroVenta)
        {
            return ventaRepository.ObtenerVentaporNroVenta(nroVenta);
        }
    }
}

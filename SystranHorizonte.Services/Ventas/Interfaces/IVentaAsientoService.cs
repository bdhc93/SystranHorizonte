﻿using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IVentaAsientoService
    {
        VentaAsientos ObtenerVentaAsientosPorId(Int32 id);
        IEnumerable<VentaAsientos> ObtenerVentaAsientosPorHorario(Int32 id, Int32 eve);
        IEnumerable<VentaAsientos> ObtenerVentaAsientossPorCriterio(String criterio);

        void GuardarVentaAsientos(VentaAsientos ventaAsientos);
        void ModificarVentaAsientos(VentaAsientos ventaAsientos);
        void EliminarVentaAsientos(Int32 id);
    }
}

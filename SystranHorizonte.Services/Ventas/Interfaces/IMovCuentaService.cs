using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IMovCuentaService
    {
        IEnumerable<RegUsuarios> ObtenerMovimientosPorUsuario(String usuario);

        String GuardarMovimiento(RegUsuarios movimiento);
    }
}

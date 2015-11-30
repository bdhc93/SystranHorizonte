using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IMovCuentaRepository
    {
        IEnumerable<RegUsuarios> ObtenerMovimientosPorUsuario(String usuario);

        String GuardarMovimiento(RegUsuarios movimiento);
    }
}

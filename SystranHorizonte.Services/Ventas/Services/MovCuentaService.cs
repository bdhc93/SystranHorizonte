using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class MovCuentaService : IMovCuentaService
    {
        public IMovCuentaRepository movCuentaRepository { get; set; }

        public MovCuentaService(IMovCuentaRepository movCuentaRepository)
        {
            this.movCuentaRepository = movCuentaRepository;
        }

        public string GuardarMovimiento(RegUsuarios movimiento)
        {
            return movCuentaRepository.GuardarMovimiento(movimiento);
        }

        public IEnumerable<RegUsuarios> ObtenerMovimientosPorUsuario(string usuario)
        {
            return movCuentaRepository.ObtenerMovimientosPorUsuario(usuario);
        }
    }
}

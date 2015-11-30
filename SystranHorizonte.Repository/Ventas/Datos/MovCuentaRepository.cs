using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class MovCuentaRepository : MasterRepository, IMovCuentaRepository
    {
        public string GuardarMovimiento(RegUsuarios movimiento)
        {
            try
            {
                Context.RegUsuarios.Add(movimiento);
                Context.SaveChanges();
                return "Movimiento Guardado";
            }
            catch (Exception e)
            {
                return "Error: "+e.Message;
            }
            
        }

        public IEnumerable<RegUsuarios> ObtenerMovimientosPorUsuario(string usuario)
        {
            return Context.RegUsuarios.OrderByDescending(p => p.Fecha).Take(5).Where(p => p.Usuario.Equals(usuario));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VentaEncomiendaRepository : MasterRepository, IVentaEncomiendaRepository
    {
        public void EliminarVentaEncomienda(int id)
        {
            throw new NotImplementedException();
        }

        public void GuardarVentaEncomienda(VentaEncomienda venta)
        {
            throw new NotImplementedException();
        }

        public void ModificarVentaEncomienda(VentaEncomienda venta)
        {
            throw new NotImplementedException();
        }

        public VentaEncomienda ObtenerVentaEncomiendaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VentaEncomienda> ObtenerVentaEncomiendasPorCriterio(string criterio)
        {
            throw new NotImplementedException();
        }
    }
}

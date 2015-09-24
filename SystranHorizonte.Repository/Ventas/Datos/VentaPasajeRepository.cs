using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VentaPasajeRepository : MasterRepository, IVentaPasajeRepository
    {
        public void EliminarVentaPasaje(int id)
        {
            throw new NotImplementedException();
        }

        public void GuardarVentaPasaje(VentaPasaje venta)
        {
            throw new NotImplementedException();
        }

        public void ModificarVentaPasaje(VentaPasaje venta)
        {
            throw new NotImplementedException();
        }

        public VentaPasaje ObtenerVentaPasajePorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VentaPasaje> ObtenerVentaPasajesPorCriterio(string criterio)
        {
            throw new NotImplementedException();
        }
    }
}

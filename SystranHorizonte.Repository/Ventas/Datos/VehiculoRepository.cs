using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VehiculoRepository : MasterRepository, IVehiculoRepository
    {
        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            return Context.Vehiculos.Find(id);
        }

        public IEnumerable<Vehiculo> ObtenerVehiculosPorCriterio(string criterio)
        {
            var query = from p in Context.Vehiculos
                        select p;

            if (String.IsNullOrEmpty(criterio))
                return Context.Vehiculos.ToList();
            else
                query = from p in query
                        where p.NroPlaca.ToUpper().Contains(criterio.ToUpper()) ||
                        p.TarjetaPropiedad.ToUpper().Contains(criterio.ToUpper())
                        select p;
            return query.ToList();
        }

        public void GuardarVehiculo(Vehiculo vehiculo)
        {
            Context.Vehiculos.Add(vehiculo);
            Context.SaveChanges();
        }

        public void ModificarVehiculo(Vehiculo vehiculo)
        {
            Context.Entry(vehiculo).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarVehiculo(int id)
        {
            var elim = ObtenerVehiculoPorId(id);

            Context.Vehiculos.Remove(elim);
            Context.SaveChanges();
        }
    }
}

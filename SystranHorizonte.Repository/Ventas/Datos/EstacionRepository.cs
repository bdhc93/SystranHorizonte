using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class EstacionRepository : MasterRepository, IEstacionRepository
    {
        public Estacion ObtenerEstacionPorId(int id)
        {
            return Context.Estaciones.Find(id);
        }

        public IEnumerable<Estacion> ObtenerEstacionsPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Estaciones.Where(p => p.Ciudad.ToUpper().Contains(criterio.ToUpper()) ||
                    p.Codigo.ToUpper().Contains(criterio.ToUpper()) ||
                    p.Provincia.ToUpper().Contains(criterio.ToUpper())).ToList();
            }
            return Context.Estaciones.ToList();
        }

        public void GuardarEstacion(Estacion estacion)
        {
            Context.Estaciones.Add(estacion);
            Context.SaveChanges();
        }

        public void ModificarEstacion(Estacion estacion)
        {
            Context.Entry(estacion).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarEstacion(int id)
        {
            var elim = ObtenerEstacionPorId(id);

            Context.Estaciones.Remove(elim);
            Context.SaveChanges();
        }
    }
}

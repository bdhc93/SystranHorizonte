using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VentaAsientoRepository : MasterRepository, IVentaAsientoRepository
    {
        public VentaAsientos ObtenerVentaAsientosPorId(int id)
        {
            return Context.VentaAsientos.Find(id);
        }

        public IEnumerable<VentaAsientos> ObtenerVentaAsientossPorCriterio(string criterio)
        {
            throw new NotImplementedException();
        }

        public void GuardarVentaAsientos(VentaAsientos ventaAsientos)
        {
            Context.VentaAsientos.Add(ventaAsientos);
            Context.SaveChanges();
        }

        public void ModificarVentaAsientos(VentaAsientos ventaAsientos)
        {
            Context.Entry(ventaAsientos).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarVentaAsientos(int id)
        {
            var elim = ObtenerVentaAsientosPorId(id);

            Context.VentaAsientos.Remove(elim);
            Context.SaveChanges();
        }

        public IEnumerable<VentaAsientos> ObtenerVentaAsientosPorHorario(int id, int eve)
        {
            var query = from p in Context.VentaAsientos.Include("Vehiculo").Include("Horario")
                        where p.IdHorario == id && p.Falsa == true
                        orderby p.Asiento
                        select p;

            return query;
        }
    }
}

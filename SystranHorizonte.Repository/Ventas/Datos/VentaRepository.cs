using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VentaRepository : MasterRepository, IVentaRepository
    {
        public Venta ObtenerVentaPorId(int id)
        {
            return Context.Ventas.Include("VentaPasajes").Include("VentaPasajes.Horario").Include("VentaPasajes.Cliente").Include("VentaPasajes.Carga").Include("VentaPasajes.Horario.EstacionOrigen").Include("VentaPasajes.Horario.EstacionDestino").Include("Cliente").Include("VentaEncomiendas").Include("Reseras").Where(p => p.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<Venta> ObtenerVentasPorCriterio(string criterio, DateTime fechaIni, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public void GuardarVenta(Venta venta)
        {
            foreach (var item in venta.VentaPasajes)
            {
                var asientos = Context.VentaAsientos.Find(item.Asiento);

                asientos.Libre = false;

                Context.Entry(asientos).State = EntityState.Modified;

                item.Asiento = asientos.Asiento;

                //Context.SaveChanges();
            }
            Context.Ventas.Add(venta);
            Context.SaveChanges();
        }

        public void ModificarVenta(Venta venta)
        {
            throw new NotImplementedException();
        }

        public void EliminarVenta(int id)
        {
            var elim = ObtenerVentaPorId(id);

            foreach (var item in elim.VentaPasajes)
            {
                var asien = Context.VentaAsientos.Where(p => p.IdHorario == item.IdHorario);

                foreach (var item2 in asien)
                {
                    if (item2.Asiento == item.Asiento)
                    {
                        var asientomod = Context.VentaAsientos.Find(item2.Id);

                        asientomod.Libre = true;
                    }
                }
            }

            Context.Ventas.Remove(elim);
            Context.SaveChanges();
        }

        public IEnumerable<Venta> ObtenerVentas()
        {
            return Context.Ventas.Include("Cliente").ToList();
        }

        public int ObtenerNroVenta()
        {
            try
            {
                var query = (from p in Context.Ventas.OrderByDescending(p => p.NroVenta) select p).First();
                return query.NroVenta + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}

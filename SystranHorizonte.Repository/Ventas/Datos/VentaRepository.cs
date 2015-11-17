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

        public int GuardarVenta(Venta venta)
        {
            foreach (var item in venta.VentaPasajes)
            {
                var asientos = Context.VentaAsientos.Find(item.Asiento);

                asientos.Libre = false;
                asientos.Falsa = false;

                Context.Entry(asientos).State = EntityState.Modified;

                item.Asiento = asientos.Asiento;

                //Context.SaveChanges();
            }
            Context.Ventas.Add(venta);
            Context.SaveChanges();

            return venta.Id;
        }

        public void ModificarVenta(Venta venta)
        {
            try
            {
                Context.Database.ExecuteSqlCommand("dbo.EliminarDetalleVentaPasaje @IdVenta = '"
                + venta.Id + "'");

                foreach (var item in venta.VentaPasajes)
                {
                    var asien = Context.VentaAsientos.Where(p => p.IdHorario == item.IdHorario);

                    foreach (var item2 in asien)
                    {
                        if (item2.Asiento == item.Asiento)
                        {
                            var asientomod = Context.VentaAsientos.Find(item2.Id);
                            asientomod.Falsa = true;
                            asientomod.Libre = true;
                        }
                    }
                }

                Context.Ventas.Add(venta);
                Context.SaveChanges();

                decimal totalVenta = 0;

                foreach (var detalle in venta.VentaPasajes)
                {
                    String x = detalle.Pago.ToString();
                    
                    Context.Database.ExecuteSqlCommand("exec dbo.UpdateVentaPasaje @Pago = '" + decimalAstring(detalle.Pago)
                    + "', @Asiento = '" + detalle.Asiento
                    + "', @IdHorario = '" + detalle.IdHorario
                    + "', @IdCliente = '" + detalle.IdCliente
                    + "', @IdCarga = '" + detalle.IdCarga
                    + "', @IdVenta = '" + venta.Id + "'");

                    totalVenta = totalVenta + detalle.Pago;
                }

                foreach (var item in venta.VentaPasajes)
                {
                    var asientos = Context.VentaAsientos.Find(item.Asiento);

                    asientos.Libre = false;
                    asientos.Falsa = false;

                    Context.Entry(asientos).State = EntityState.Modified;

                    item.Asiento = asientos.Asiento;
                }

                Context.Ventas.Add(venta);
                Context.SaveChanges();

                Context.Database.ExecuteSqlCommand("exec dbo.UpdateVentaSUPER @NroVenta = '" + venta.NroVenta
                    + "', @Tipo = '" + venta.Tipo
                    + "', @TotalVenta = '" + decimalAstring(totalVenta)
                    + "', @IdCliente = '" + venta.IdCliente
                    + "', @Id = '" + venta.Id + "'");

            }
            catch (Exception)
            {
                
                throw;
            }
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
                        asientomod.Falsa = true;
                        asientomod.Libre = true;
                    }
                }
            }

            Context.Ventas.Remove(elim);
            Context.SaveChanges();
        }

        public IEnumerable<Venta> ObtenerVentas()
        {
            var query = from p in Context.Ventas.Include("Cliente").ToList()
                        select p;

            query = from p in query
                    where p.Tipo == 1
                    select p;

            return query.ToList();
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

        public string decimalAstring(Decimal des)
        {
            var final = des.ToString();

            var x = final.Replace(",", ".");

            return x;
        }

        public IEnumerable<Venta> ObtenerEncomiendas()
        {
            var query = from p in Context.Ventas.Include("Cliente").ToList()
                        select p;

            query = from p in query
                    where p.Tipo == 2
                    select p;

            return query.ToList();
        }

        public IEnumerable<Venta> ObtenerReservas()
        {
            var query = from p in Context.Ventas.Include("Cliente").ToList()
                        select p;

            query = from p in query
                    where p.Tipo == 3
                    select p;

            return query.ToList();
        }
    }
}

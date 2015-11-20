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
            return Context.Ventas.Include("VentaPasajes").Include("VentaPasajes.Horario")
                .Include("VentaPasajes.Cliente").Include("VentaPasajes.Carga")
                .Include("VentaPasajes.Horario.EstacionOrigen")
                .Include("VentaPasajes.Horario.EstacionDestino")
                .Include("VentaEncomiendas").Include("VentaEncomiendas.Horario")
                .Include("VentaEncomiendas.Cliente").Include("VentaEncomiendas.Carga")
                .Include("VentaEncomiendas.Horario.EstacionOrigen")
                .Include("VentaEncomiendas.Horario.EstacionDestino")
                .Include("Cliente")
                .Include("Reseras").Where(p => p.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<Venta> ObtenerVentasPorCriterio(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            var query = from p in Context.VentaPasajes
                        .Include("Venta").Include("Venta.Cliente")
                        .Include("Horario").Include("Horario.EstacionOrigen").Include("Horario.EstacionDestino")
                        .ToList()
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }
            else
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }

            List<Venta> ventas = new List<Venta>();

            var idvent = 0;

            foreach (var item in query)
            {
                if (idvent != item.Venta.NroVenta)
                {
                    ventas.Add(item.Venta);
                }

                idvent = item.Venta.NroVenta;
            } 

            return ventas;
        }

        public int GuardarVenta(Venta venta)
        {
            try
            {
                if (venta.Tipo < 5)
                {
                    foreach (var item in venta.VentaPasajes)
                    {
                        //Cambio de Asientos
                        var asientos = Context.VentaAsientos.Find(item.Asiento);

                        asientos.Libre = false;
                        asientos.Falsa = false;

                        Context.Entry(asientos).State = EntityState.Modified;

                        item.Asiento = asientos.Asiento;
                        
                    }
                }
                Context.Ventas.Add(venta);
                Context.SaveChanges();

                return venta.Id;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void ModificarVenta(Venta venta)
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

                //Context.Ventas.Add(venta);
                Context.SaveChanges();

                decimal totalVenta = 0;
                decimal totalCarga = 0;

                foreach (var detalle in venta.VentaPasajes)
                {
                    if (detalle.IdClienteTemp != 0)
                    {
                    detalle.IdCliente = detalle.IdClienteTemp;
                    }

                    String x = detalle.Pago.ToString();
                    
                    Context.Database.ExecuteSqlCommand("exec dbo.UpdateVentaPasaje @Pago = '" + decimalAstring(detalle.Pago)
                    + "', @Asiento = '" + detalle.Asiento
                    + "', @IdHorario = '" + detalle.IdHorario
                    + "', @IdCliente = '" + detalle.IdCliente
                    + "', @IdCarga = '" + detalle.IdCarga
                    + "', @Carga = '" + decimalAstring(detalle.CargaPasaje)
                    + "', @IdVenta = '" + venta.Id + "'");

                    totalVenta = totalVenta + detalle.Pago;
                    totalCarga = totalCarga + detalle.CargaPasaje;
                
                }

                foreach (var item in venta.VentaPasajes)
                {
                    var asientos = Context.VentaAsientos.Find(item.Asiento);

                    asientos.Libre = false;
                    asientos.Falsa = false;

                    Context.Entry(asientos).State = EntityState.Modified;

                    item.Asiento = asientos.Asiento;
                }

                //Context.Ventas.Add(venta);
                Context.SaveChanges();

                Context.Database.ExecuteSqlCommand("exec dbo.UpdateVentaSUPER @NroVenta = '" + venta.NroVenta
                    + "', @Tipo = '" + venta.Tipo
                    + "', @TotalVenta = '" + decimalAstring(totalVenta)
                    + "', @IdCliente = '" + venta.IdCliente
                    + "', @Id = '" + venta.Id
                    + "', @TotalCarga = '" + decimalAstring(totalCarga) + "'");
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
            var query = from p in Context.Ventas.Include("Cliente").Include("VentaPasajes")
                        .Include("VentaPasajes.Horario")
                .Include("VentaPasajes.Cliente").Include("VentaPasajes.Carga")
                .Include("VentaPasajes.Horario.EstacionOrigen")
                .Include("VentaPasajes.Horario.EstacionDestino").ToList()
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

        public IEnumerable<Venta> ObtenerEncomiendas(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            var query = from p in Context.VentaEncomiendas
                        .Include("Venta").Include("Venta.Cliente")
                        .Include("Horario").Include("Horario.EstacionOrigen").Include("Horario.EstacionDestino")
                        .ToList()
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 5
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 5 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }
            else
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 5
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 5 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }

            List<Venta> ventas = new List<Venta>();

            var idvent = 0;

            foreach (var item in query)
            {
                if (idvent != item.Venta.NroVenta)
                {
                    ventas.Add(item.Venta);
                }

                idvent = item.Venta.NroVenta;
            }

            return ventas;
        }

        public IEnumerable<Venta> ObtenerReservas(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            var query = from p in Context.Reservas
                        .Include("Venta").Include("Venta.Cliente")
                        .Include("Horario").Include("Horario.EstacionOrigen").Include("Horario.EstacionDestino")
                        .ToList()
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 3
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 3 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }
            else
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 3
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 3 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }

            List<Venta> ventas = new List<Venta>();

            var idvent = 0;

            foreach (var item in query)
            {
                if (idvent != item.Venta.NroVenta)
                {
                    ventas.Add(item.Venta);
                }

                idvent = item.Venta.NroVenta;
            }

            return ventas;
        }
    }
}

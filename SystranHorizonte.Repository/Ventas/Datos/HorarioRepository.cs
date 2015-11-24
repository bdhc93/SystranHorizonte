using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class HorarioRepository : MasterRepository, IHorarioRepository
    {
        public Horario ObtenerClientePorId(int id)
        {
            return Context.Horarios.Find(id);
        }

        public IEnumerable<Horario> ObtenerHorariosPorEstacion(int idEstacion, int idDestino)
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino").Include("Empleados")
                        select p;

            if (idEstacion == 0 || idDestino == 0)
                return new List<Horario> { };
            else
                query = from p in query
                        where p.OrigenId.Equals(idEstacion) && p.DestinoId.Equals(idDestino) && p.Estado == true
                        select p;
            return query.ToList();
        }

        public void GuardarHorario(Horario horario)
        {
            Context.Horarios.Add(horario);

            Context.SaveChanges();

            var ventaasientos = new VentaAsientos { Fecha = DateTime.Today, IdHorario =  horario.Id, IdVehiculo = horario.VehiculoId};

            for (int i = 0; i < horario.Asientos; i++)
            {
                ventaasientos.Asiento = i + 1;
                ventaasientos.Libre = true;
                ventaasientos.Falsa = true;
                Context.VentaAsientos.Add(ventaasientos);
                Context.SaveChanges();
            }
        }

        public void ModificarHorario(Horario horario)
        {
            Context.Entry(horario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarHorario(int id)
        {
            var elim = ObtenerClientePorId(id);

            Context.Horarios.Remove(elim);
            Context.SaveChanges();
        }

        public IEnumerable<Horario> ObtenerHorarios()
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino").Include("Empleados")
                        select p;
            
            return query.ToList();
        }

        public IEnumerable<Horario> ObtenerHorariosPorEstacionNoVacio(int idEstacion, int idDestino)
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino").Include("Empleados")
                        select p;

            if (idEstacion == 0 || idDestino == 0)
                return query;
            else
                query = from p in query
                        where p.OrigenId.Equals(idEstacion) && p.DestinoId.Equals(idDestino) && p.Estado == true
                        select p;
            return query.ToList();
        }

        public IEnumerable<Horario> ObtenerHorariosPorCiudades(string origen, string destino)
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino")
                        select p;

            if (String.IsNullOrEmpty(origen) && String.IsNullOrEmpty(destino)) {
                return new List<Horario> { };
            }
            else if (String.IsNullOrEmpty(origen))
            {
                if (!String.IsNullOrEmpty(destino))
                {
                    query = from p in query
                            where p.EstacionDestino.Ciudad == destino && p.Estado == true
                            orderby (p.Hora)
                            select p;
                }
                
            }else if (String.IsNullOrEmpty(destino)){ 
                query = from p in query
                        where p.EstacionOrigen.Ciudad == origen && p.Estado == true orderby(p.Hora)
                        orderby (p.Hora)
                        select p;
            }
            else
            {
                query = from p in query
                        where p.EstacionOrigen.Ciudad == origen && p.EstacionDestino.Ciudad == destino && p.Estado == true orderby(p.Hora)
                        select p;
            }
            return query.ToList();
        }

        public void GenerarHorarios()
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino")
                        where p.Estado == true
                        select p;

            foreach (var item in query)
            {
                var ventaasientos = new VentaAsientos { Fecha = DateTime.Today, IdHorario = item.Id, IdVehiculo = item.VehiculoId };

                for (int i = 0; i < item.Asientos; i++)
                {
                    ventaasientos.Asiento = i + 1;
                    ventaasientos.Libre = true;
                    ventaasientos.Falsa = true;
                    Context.VentaAsientos.Add(ventaasientos);
                }
            }

            Context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class EmpleadoRepository : MasterRepository, IEmpleadoRepository
    {
        public Empleado ObtenerEmpleadoPorId(int id)
        {
            return Context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> ObtenerEmpleadoPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Empleados.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper()) ||
                p.Apellidos.ToUpper().Contains(criterio.ToUpper()) ||
                p.Cargo.ToUpper().Contains(criterio.ToUpper()) ||
                p.Telefono.ToUpper().Contains(criterio.ToUpper())).ToList();
            }
            return Context.Empleados.ToList();
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            Context.Empleados.Add(empleado);
            Context.SaveChanges();
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            Context.Entry(empleado).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarEmpleado(int id)
        {
            var elim = ObtenerEmpleadoPorId(id);

            Context.Empleados.Remove(elim);
            Context.SaveChanges();
        }

        public IEnumerable<DatosReportEmpleado> ObtenerEmpleadoPorCriterios(int criterio, DateTime fechaini, DateTime fechafin)
        {
            try
            {
                var query = from p in Context.VentaAsientos
                        .Include("Vehiculo")
                        .Include("Horario").Include("Horario.Empleados")
                        .Include("Horario").Include("Horario.EstacionOrigen").Include("Horario.EstacionDestino")
                        .ToList()
                            select p;

                query = from p in query
                        where p.Horario.Empleados.Id.Equals(criterio) && (p.Fecha >= fechaini.Date && p.Fecha <= fechafin.AddHours(24)) orderby(p.Fecha)
                        select p;

                List<DatosReportEmpleado> empleados = new List<DatosReportEmpleado>();

                var idhor = 0;
                var fecha = "";

                foreach (var item in query)
                {
                    if (idhor != item.Horario.Id)
                    {
                        var reportemp = new DatosReportEmpleado
                        {
                            id = item.Id,
                            Fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                            Hora = item.Horario.HoraText,
                            IdHorario = item.Horario.Id,
                            NroPlaca = item.Vehiculo.NroPlaca,
                            TarjetaPropiedad = item.Vehiculo.TarjetaPropiedad,
                            IdVehiculo = item.Vehiculo.Id,
                            IdOrigen = item.Horario.EstacionOrigen.Id,
                            IdDestino = item.Horario.EstacionDestino.Id,
                            OrigenId = item.Horario.EstacionOrigen.EstacionesT,
                            DestinoId = item.Horario.EstacionDestino.EstacionesT
                        };
                        fecha = reportemp.Fecha;
                        empleados.Add(reportemp);
                    }
                    else if (fecha != (item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year))
                    {
                        var reportemp = new DatosReportEmpleado
                        {
                            id = item.Id,
                            Fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                            Hora = item.Horario.HoraText,
                            IdHorario = item.Horario.Id,
                            NroPlaca = item.Vehiculo.NroPlaca,
                            TarjetaPropiedad = item.Vehiculo.TarjetaPropiedad,
                            IdVehiculo = item.Vehiculo.Id,
                            IdOrigen = item.Horario.EstacionOrigen.Id,
                            IdDestino = item.Horario.EstacionDestino.Id,
                            OrigenId = item.Horario.EstacionOrigen.EstacionesT,
                            DestinoId = item.Horario.EstacionDestino.EstacionesT
                        };
                        fecha = reportemp.Fecha;
                        empleados.Add(reportemp);
                    }

                    idhor = item.Horario.Id;
                }
                return empleados;
            }
            catch (Exception e)
            {
                return new List<DatosReportEmpleado>();
            }
            

        }
    }
}

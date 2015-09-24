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
    }
}

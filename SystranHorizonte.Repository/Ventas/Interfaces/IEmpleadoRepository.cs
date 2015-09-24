using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IEmpleadoRepository
    {
        Empleado ObtenerEmpleadoPorId(Int32 id);
        IEnumerable<Empleado> ObtenerEmpleadoPorCriterio(String criterio);

        void GuardarEmpleado(Empleado empleado);
        void ModificarEmpleado(Empleado empleado);
        void EliminarEmpleado(Int32 id);
    }
}

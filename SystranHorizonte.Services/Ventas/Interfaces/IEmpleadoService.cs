using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IEmpleadoService
    {
        Empleado ObtenerEmpleadoPorId(Int32 id);
        IEnumerable<Empleado> ObtenerEmpleadoPorCriterio(String criterio);
        IEnumerable<DatosReportEmpleado> ObtenerEmpleadoPorCriterios(Int32 criterio, DateTime fechaini, DateTime fechafin);

        void GuardarEmpleado(Empleado empleado);
        void ModificarEmpleado(Empleado empleado);
        void EliminarEmpleado(Int32 id);
    }
}

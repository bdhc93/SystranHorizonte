using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        public IEmpleadoRepository empleadoRepository { get; set; }

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            return empleadoRepository.ObtenerEmpleadoPorId(id);
        }

        public IEnumerable<Empleado> ObtenerEmpleadoPorCriterio(string criterio)
        {
            return empleadoRepository.ObtenerEmpleadoPorCriterio(criterio);
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            empleadoRepository.GuardarEmpleado(empleado);
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            empleadoRepository.ModificarEmpleado(empleado);
        }

        public void EliminarEmpleado(int id)
        {
            empleadoRepository.EliminarEmpleado(id);
        }
    }
}

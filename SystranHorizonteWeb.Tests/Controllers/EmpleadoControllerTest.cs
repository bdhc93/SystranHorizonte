﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Web.Controllers;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class EmpleadoControllerTest
    {
        public IEmpleadoService empleadoService { get; set; }

        //[TestMethod]
        //public void EmpleadoControllerGuardar()
        //{
        //    EmpleadoController controller = new EmpleadoController(empleadoService);

        //    Empleado model = new Empleado
        //    {
        //        Nombre = "NombreTest",
        //        Apellidos = "ApellidosTest"
        //    };

        //    ViewResult result = controller.AgregarEmpleado() as ViewResult;
        //}
        
        //[TestMethod]
        //public void EmpleadoControllerModificar()
        //{
        //    EmpleadoController controller = new EmpleadoController(empleadoService);

        //    Empleado p = new Empleado
        //    {
        //        Id = 12344,
        //    };

        //    ViewResult result = controller.AgregarEmpleado(p) as ViewResult;
        //}

        //[TestMethod]
        //public void EmpleadoControllerEliminar()
        //{
        //    EmpleadoController controller = new EmpleadoController(empleadoService);
            
        //    ViewResult result = controller.AgregarEmpleado() as ViewResult;
        //}
    }
}

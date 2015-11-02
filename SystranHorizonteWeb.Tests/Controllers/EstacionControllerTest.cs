using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonteWeb.Controllers;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class EstacionControllerTest
    {
        public IEstacionService estacionService { get; set; }

        [TestMethod]
        public void EstacionControllerGuardar()
        {
            EstacionController controller = new EstacionController(estacionService);

            Estacion model = new Estacion
            {
                Ciudad = "CiudadTest",
                Codigo = "CodigoTest",
                Direccion = "DireccionTest"
            };

            ViewResult result = controller.AgregarEstacion() as ViewResult;
        }

        [TestMethod]
        public void EstacionControllerModificar()
        {
            EstacionController controller = new EstacionController(estacionService);

            ViewResult result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void EstacionControllerEliminar()
        {
            EstacionController controller = new EstacionController(estacionService);
            

            ViewResult result = controller.Index() as ViewResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonteWeb;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonteWeb.Controllers;

namespace VentaControllerListarVentas.Tests
{
    [TestClass()]
    public class VentaPasajesTest
    {
        [TestMethod()]
        public void ListarVentasTest()
        {
            Assert.Fail();
        }
    }
}

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class VentaPasajesTest
    {
        [TestMethod]
        public void VentaController()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Web.Controllers;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class ClienteControllerTest
    {
        public IClienteService clienteService { get; set; }

        [TestMethod]
        public void ClienteControllerGuardar()
        {
            ClienteController controller = new ClienteController(clienteService);

            Carga model = new Carga
            {
                Estado = true,
                Peso = 0,
                Precio = 10,
                Tipo = true,
                TipoString = "Encomiendas"
            };

            ViewResult result = controller.Agregar() as ViewResult;
        }

        [TestMethod]
        public void ClienteControllerModificar()
        {
            ClienteController controller = new ClienteController(clienteService);

            ViewResult result = controller.Agregar() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClienteControllerEliminar()
        {
            ClienteController controller = new ClienteController(clienteService);

            ViewResult result = controller.Agregar() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

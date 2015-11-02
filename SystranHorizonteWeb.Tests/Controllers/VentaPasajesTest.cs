using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class VentaPasajesTest
    {
        Int32 nroVenta = 55555;
        DateTime fecha = DateTime.Now;
        Boolean tipo = true;
        Decimal totalVenta = 10;
        Int32 idCliente = 4;
        String rucDniCliente = "72906755";

        [TestMethod]
        public void VentaControllerGuardar()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/AgregarVenta?nroVenta="+ nroVenta +"&fecha="+ fecha+"&tipo="+ tipo+ "&totalVenta="+ totalVenta+"&idCliente="+ idCliente+"&rucDniCliente="+ rucDniCliente);
            
            WebResponse response = request.GetResponse();

            var jsonObject = response.GetResponseStream();

            if (jsonObject != null)
            {

            }
            else
            {
                Assert.Fail();
            }

            //string json = File.ReadAllText(str);

            /*
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            */
        }
    }
}

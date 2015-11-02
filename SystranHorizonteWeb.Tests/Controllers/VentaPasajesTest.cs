using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Web.Script.Serialization;

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
        String rucDniCliente = "7896545";
        Int32 IdVenta = 1019;

        [TestMethod]
        public void VentaControllerGuardar()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/AgregarVenta?nroVenta="+ nroVenta +"&fecha="+ fecha+"&tipo="+ tipo+ "&totalVenta="+ totalVenta+"&idCliente="+ idCliente+"&rucDniCliente="+ rucDniCliente);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            JavaScriptSerializer js = new JavaScriptSerializer();

            var jsonObject = reader.ReadToEnd();

            MyObject myojb = (MyObject)js.Deserialize(jsonObject, typeof(MyObject));

            if (myojb.Mensaje == "Todo ok")
            {

            }
            else if (myojb.Mensaje == "Error en la data")
            {
                Assert.Fail();
            }
            
        }

        [TestMethod]
        public void VentaControllerEliminar()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/EliminarVenta?IdVenta=" + IdVenta);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            JavaScriptSerializer js = new JavaScriptSerializer();

            var jsonObject = reader.ReadToEnd();

            MyObject myojb = (MyObject)js.Deserialize(jsonObject, typeof(MyObject));

            if (myojb.Mensaje == "Todo ok")
            {

            }
            else if (myojb.Mensaje == "Error en la data")
            {
                Assert.Fail();
            }

        }
    }

    public class MyObject
    {
        public string Mensaje { get; set; }
    }
}

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
        Int32 nroVenta = 66666;
        DateTime fecha = DateTime.Now;
        Boolean tipo = true;
        Decimal totalVenta = 100;
        Int32 idCliente = 4;
        String rucDniCliente = "7896545";
        Int32 IdVenta = 1028;

        [TestMethod]
        public void VentaControllerGuardar()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/AgregarVenta?nroVenta=" + nroVenta + "&fecha=" + fecha + "&tipo=" + tipo + "&totalVenta=" + totalVenta + "&idCliente=" + idCliente + "&rucDniCliente=" + rucDniCliente);

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
        public void VentaControllerModificar()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/ModificarVenta?nroVenta=" + nroVenta + "&fecha=" + fecha + "&tipo=" + tipo + "&totalVenta=" + totalVenta + "&idCliente=" + idCliente + "&rucDniCliente=" + rucDniCliente + "&IdVenta=" + IdVenta);

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

        [TestMethod]
        public void VentaControllerModulo()
        {
            WebRequest request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/AgregarVenta?nroVenta=" + nroVenta + "&fecha=" + fecha + "&tipo=" + tipo + "&totalVenta=" + totalVenta + "&idCliente=" + idCliente + "&rucDniCliente=" + rucDniCliente);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            JavaScriptSerializer js = new JavaScriptSerializer();

            var jsonObject = reader.ReadToEnd();

            MyObject venta = (MyObject)js.Deserialize(jsonObject, typeof(MyObject));

            if (venta.Mensaje == "Todo ok")
            {
                request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/ModificarVenta?nroVenta=" + 56565 + "&fecha=" + fecha + "&tipo=" + false + "&totalVenta=" + totalVenta + "&idCliente=" + idCliente + "&rucDniCliente=" + rucDniCliente + "&IdVenta=" + venta.IdVenta);

                response = (HttpWebResponse)request.GetResponse();

                reader = new StreamReader(response.GetResponseStream());

                js = new JavaScriptSerializer();

                jsonObject = reader.ReadToEnd();

                venta = (MyObject)js.Deserialize(jsonObject, typeof(MyObject));

                if (venta.Mensaje == "Todo ok")
                {
                    request = WebRequest.Create("http://localhost/SystranHorizonteWeb/ServiciosJsonTest/EliminarVenta?IdVenta=" + venta.IdVenta);

                    response = (HttpWebResponse)request.GetResponse();

                    reader = new StreamReader(response.GetResponseStream());

                    js = new JavaScriptSerializer();

                    jsonObject = reader.ReadToEnd();

                    venta = (MyObject)js.Deserialize(jsonObject, typeof(MyObject));

                    if (venta.Mensaje == "Todo ok")
                    {

                    }
                    else if (venta.Mensaje == "Error en la data")
                    {
                        Assert.Fail();
                    }
                }
                else if (venta.Mensaje == "Error en la data")
                {
                    Assert.Fail();
                }
            }
            else if (venta.Mensaje == "Error en la data")
            {
                Assert.Fail();
            }

        }
    }

    public class MyObject
    {
        public string Mensaje { get; set; }
        public int IdVenta { get; set; }
    }
}

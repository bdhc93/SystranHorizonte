using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonteWeb.Controllers
{
    public class ServiciosJsonTestController : Controller
    {
        public IVentaService ventaService { get; set; }

        public ServiciosJsonTestController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet]
        public ActionResult AgregarVenta(Int32 nroVenta, DateTime fecha, Boolean tipo, Decimal totalVenta, Int32 idCliente, String rucDniCliente)
        {
            try
            {
                Venta venta = new Venta
                {
                    NroVenta = nroVenta,
                    Fecha = fecha,
                    Tipo = tipo,
                    TotalVenta = totalVenta,
                    IdCliente = idCliente,
                    RucDniCliente = rucDniCliente
                };

                ventaService.GuardarVenta(venta);

                return this.Json(new
                {
                    Mensaje = "Todo ok"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return this.Json(new
                {
                    Mensaje = "Error en la data"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

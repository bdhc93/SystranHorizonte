using System;
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
        public ActionResult AgregarVenta(Int32 nroVenta, DateTime fecha, Int32 tipo, Decimal totalVenta, Int32 idCliente, String rucDniCliente)
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

                int id = ventaService.GuardarVenta(venta);

                return this.Json(new
                {
                    Mensaje = "Todo ok", IdVenta = id
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

        [HttpGet]
        public ActionResult ModificarVenta(Int32 nroVenta, DateTime fecha, Int32 tipo, Decimal totalVenta, Int32 idCliente, String rucDniCliente, Int32 IdVenta)
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
                    RucDniCliente = rucDniCliente,
                    Id = IdVenta
                };

                ventaService.ModificarVenta(venta);
                
                return this.Json(new
                {
                    Mensaje = "Todo ok",
                    IdVenta = IdVenta
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

        [HttpGet]
        public ActionResult EliminarVenta(Int32 IdVenta)
        {
            try
            {
                ventaService.EliminarVenta(IdVenta);

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

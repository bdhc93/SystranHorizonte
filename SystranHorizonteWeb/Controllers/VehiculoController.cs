using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Services;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonteWeb.Controllers
{
    public class VehiculoController : Controller
    {
        public IVehiculoService vehiculoService { get; set; }

        public VehiculoController(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarVehiculo()
        {
            var result = vehiculoService.ObtenerVehiculosPorCriterio("");
            return View(result);
        }

        [HttpGet]
        public ActionResult AgregarVehiculo()
        {
            ViewBag.FechaSoat = MostrarFecha();
            ViewBag.FechaRevisionTecnica = MostrarFecha();

            return View();
        }

        [HttpPost]
        public ActionResult AgregarVehiculo(Vehiculo model)
        {
            vehiculoService.GuardarVehiculo(model);

            return Redirect("ListarVehiculo");
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                vehiculoService.EliminarVehiculo(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puede eliminar";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        public ActionResult Modificar(Int32 id)
        {
            var result = vehiculoService.ObtenerVehiculoPorId(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Modificar(Vehiculo model)
        {
            vehiculoService.ModificarVehiculo(model);

            return Redirect(Url.Action("ListarVehiculo"));
        }

        private String MostrarFecha()
        {

            var mont = DateTime.Now.Month;
            string mes = "0";
            if (mont < 10)
            {
                mes = mes + mont;
            }
            else
            {
                mes = mont + "";
            }
            var day = DateTime.Now.Day;
            string dia = "0";
            if (day < 10)
            {
                dia = dia + day;
            }
            else
            {
                dia = day + "";
            }

            return DateTime.Now.Year + "-" + mes + "-" + dia;
        }

        [HttpGet]
        public ActionResult Buscar(String criterio)
        {
            var result = vehiculoService.ObtenerVehiculosPorCriterio(criterio);

            return PartialView("_Listar", result);
        }
    }
}
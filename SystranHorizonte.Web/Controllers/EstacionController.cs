using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class EstacionController : Controller
    {
        public IEstacionService estacionService { get; set; }

        public EstacionController(IEstacionService estacionService)
        {
            this.estacionService = estacionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult ListarEstacion()
        {
            var result = estacionService.ObtenerEstacionsPorCriterio("");
            return View(result);
        }

        [HttpGet]
        public ActionResult ListarEstaciones()
        {
            var result = estacionService.ObtenerEstacionsPorCriterio("");
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AgregarEstacion()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AgregarEstacion(Estacion model)
        {
            estacionService.GuardarEstacion(model);

            return Redirect("ListarEstacion");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                estacionService.EliminarEstacion(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puede eliminar";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Int32 id)
        {
            var result = estacionService.ObtenerEstacionPorId(id);

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Estacion model)
        {
            estacionService.ModificarEstacion(model);

            return Redirect(Url.Action("ListarEstacion"));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Buscar(String criterio)
        {
            var result = estacionService.ObtenerEstacionsPorCriterio(criterio);

            return PartialView("_Listar", result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Buscar2(String criterio)
        {
            var result = estacionService.ObtenerEstacionsPorCriterio(criterio);

            return PartialView("__Listar", result);
        }
    }
}
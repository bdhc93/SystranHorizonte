using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Services;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        public IEmpleadoService empleadoService { get; set; }

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ListarEmpleado()
        {
            var result = empleadoService.ObtenerEmpleadoPorCriterio("");
            return View(result);
        }

        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(Empleado model)
        {
            empleadoService.GuardarEmpleado(model);

            return Redirect("ListarEmpleado");
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                empleadoService.EliminarEmpleado(idve);
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
            var result = empleadoService.ObtenerEmpleadoPorId(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Modificar(Empleado model)
        {
            empleadoService.ModificarEmpleado(model);

            return Redirect(Url.Action("ListarEmpleado"));
        }

        [HttpGet]
        public ActionResult Buscar(String criterio)
        {
            var result = empleadoService.ObtenerEmpleadoPorCriterio(criterio);

            return PartialView("_Listar", result);
        }
    }
}
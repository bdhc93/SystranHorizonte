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
    public class HorarioController : Controller
    {
        public IHorarioService horarioService { get; set; }

        public HorarioController(IHorarioService horarioService)
        {
            this.horarioService = horarioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListHorarios()
        {
            var result = horarioService.ObtenerHorarios();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddHorarios()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHorarios(Horario model)
        {
            horarioService.GuardarHorario(model);

            return Redirect("ListHorarios");
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                horarioService.EliminarHorario(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puedo eliminar la venta realizada";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        public ActionResult Modificar(Int32 id)
        {
            var result = horarioService.ObtenerClientePorId(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Modificar(Horario model)
        {
            horarioService.ModificarHorario(model);

            return Redirect(Url.Action("ListHorarios"));
        }
    }
}
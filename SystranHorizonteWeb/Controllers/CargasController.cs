using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonteWeb.Controllers
{
    public class CargasController : Controller
    {
        public ICargaService cargaService { get; set; }

        public CargasController(ICargaService cargaService)
        {
            this.cargaService = cargaService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListCargas()
        {
            ViewBag.Cargas = cargaService.ObtenerCargasPorCriterio("");
            var result = cargaService.ObtenerCargasPorCriterio("");
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCarga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCarga(Carga model)
        {
            if (model.TipoString == "Encomiendas")
            {
                model.Tipo = false;
            }
            else
            {
                model.Tipo = true;
            }
            
            cargaService.GuardarCarga(model);

            return Redirect("ListCargas");
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                cargaService.EliminarCarga(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puedo eliminar la carga realizada";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        public ActionResult Modificar(Int32 id)
        {
            var result = cargaService.ObtenerCargaPorId(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Modificar(Carga model)
        {
            if (model.TipoString == "Encomiendas")
            {
                model.Tipo = false;
            }
            else
            {
                model.Tipo = true;
            }
            cargaService.ModificarCarga(model);

            return Redirect(Url.Action("ListCargas"));
        }

        [HttpGet]
        public ActionResult Buscar(String criterio)
        {
            var result = cargaService.ObtenerCargasPorCriterio(criterio);

            return PartialView("_ListCargas", result);
        }
    }
}
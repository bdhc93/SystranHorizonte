using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class CargasController : Controller
    {
        public ICargaService cargaService { get; set; }

        public CargasController(ICargaService cargaService)
        {
            this.cargaService = cargaService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult ListCargas()
        {
            ViewBag.Cargas = cargaService.ObtenerCargasPorCriterio("");
            var result = cargaService.ObtenerCargasPorCriterio("");
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AddCarga()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
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

            model.Precio = Decimal.Parse(decimalAstring(model.PrecioText));

            cargaService.GuardarCarga(model);

            return Redirect("ListCargas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
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
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Int32 id)
        {
            var result = cargaService.ObtenerCargaPorId(id);

            result.PrecioText = decimalAstring2(result.Precio.ToString());

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
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
            model.Precio = Decimal.Parse(decimalAstring(model.PrecioText));
            cargaService.ModificarCarga(model);

            return Redirect(Url.Action("ListCargas"));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Buscar(String criterio)
        {
            var result = cargaService.ObtenerCargasPorCriterio(criterio);

            return PartialView("_ListCargas", result);
        }

        public string decimalAstring(String final)
        {
            var x = final.Replace(".", ",");

            return x;
        }

        public string decimalAstring2(String final)
        {
            var x = final.Replace(",", ".");

            return x;
        }
    }
}
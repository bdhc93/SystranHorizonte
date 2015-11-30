using System;
using System.Linq;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using System.Web.Security;

namespace SystranHorizonte.Web.Controllers
{
    public class ClienteController : Controller
    {
        public IClienteService clienteService { get; set; }

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Listar()
        {
            var result = clienteService.ObtenerClientesPorCriterio("");
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Agregar()
        {
            ViewBag.RucDni = "";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Agregar(Cliente model)
        {
            var x = clienteService.GuardarCliente(model);

            if (x.Any())
            {
                foreach (var item in x)
                {
                    ViewBag.RucDni = item.Value;
                }

                return View();
            }
            else
            {
                ViewBag.RucDni = "";
            }

            return Redirect("Listar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                clienteService.EliminarCliente(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puede eliminar";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Modificar(Int32 id)
        {
            var result = clienteService.ObtenerClientePorId(id);

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Modificar(Cliente model)
        {
            clienteService.ModificarCliente(model);

            return Redirect(Url.Action("Listar"));

        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin, Vendedor")]
        public ActionResult Buscar(String criterio)
        {
            var result = clienteService.ObtenerClientesPorCriterio(criterio);

            return PartialView("_Listar", result);
        }
    }
}
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
        public IMovCuentaService movCuentaService { get; set; }

        public ClienteController(IClienteService clienteService, IMovCuentaService movCuentaService)
        {
            this.clienteService = clienteService;
            this.movCuentaService = movCuentaService;
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

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Cliente",
                Cambio = "Nuevo Cliente",
                IdModulo = model.DniRuc,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

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

            var client = clienteService.ObtenerClientePorId(idve);

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Cliente",
                Cambio = "Eliminar Cliente",
                IdModulo = client.DniRuc,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

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

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Cliente",
                Cambio = "Modifiar Cliente",
                IdModulo = model.DniRuc,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

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
﻿using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class VehiculoController : Controller
    {
        public IVehiculoService vehiculoService { get; set; }
        public IMovCuentaService movCuentaService { get; set; }

        public VehiculoController(IVehiculoService vehiculoService, IMovCuentaService movCuentaService)
        {
            this.vehiculoService = vehiculoService;
            this.movCuentaService = movCuentaService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult ListarVehiculo()
        {
            var result = vehiculoService.ObtenerVehiculosPorCriterio("");
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AgregarVehiculo()
        {
            ViewBag.FechaSoat = MostrarFecha();
            ViewBag.FechaRevisionTecnica = MostrarFecha();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AgregarVehiculo(Vehiculo model)
        {
            model.Ancho = Decimal.Parse(decimalAstring(model.AnchoText));
            model.Largo = Decimal.Parse(decimalAstring(model.LargoText));

            model.CargaActual = 0;

            vehiculoService.GuardarVehiculo(model);
            
            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Vehículo",
                Cambio = "Nuevo Vehículo",
                IdModulo = model.NroPlaca,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

            return Redirect("ListarVehiculo");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                var ve = vehiculoService.ObtenerVehiculoPorId(idve);
                RegUsuarios movimiento = new RegUsuarios
                {
                    Usuario = User.Identity.Name,
                    Modulo = "Vehículo",
                    Cambio = "Eliminar Vehículo",
                    IdModulo = ve.NroPlaca,
                    Fecha = DateTime.Now
                };

                vehiculoService.EliminarVehiculo(idve);

                movCuentaService.GuardarMovimiento(movimiento);
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
            var result = vehiculoService.ObtenerVehiculoPorId(id);

            result.AnchoText = decimalAstring2(result.Ancho.ToString());
            result.LargoText = decimalAstring2(result.Largo.ToString());

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Vehiculo model)
        {
            model.Ancho = Decimal.Parse(decimalAstring(model.AnchoText));
            model.Largo = Decimal.Parse(decimalAstring(model.LargoText));

            vehiculoService.ModificarVehiculo(model);
            
            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Vehículo",
                Cambio = "Modificar Vehículo",
                IdModulo = model.NroPlaca,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

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
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Buscar(String criterio)
        {
            var result = vehiculoService.ObtenerVehiculosPorCriterio(criterio);

            return PartialView("_Listar", result);
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
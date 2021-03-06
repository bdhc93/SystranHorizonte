﻿using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class HorarioController : Controller
    {
        public IHorarioService horarioService { get; set; }
        public IEmpleadoService empleadoService { get; set; }
        public IEstacionService estacionService { get; set; }
        public IVehiculoService vehiculoService { get; set; }
        public IMovCuentaService movCuentaService { get; set; }

        public HorarioController(IHorarioService horarioService, IMovCuentaService movCuentaService, IEmpleadoService empleadoService, IEstacionService estacionService, IVehiculoService vehiculoService)
        {
            this.horarioService = horarioService;
            this.empleadoService = empleadoService;
            this.estacionService = estacionService;
            this.vehiculoService = vehiculoService;
            this.movCuentaService = movCuentaService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult ListHorarios()
        {
            ViewBag.horarios = horarioService.ObtenerHorariosPorHora();

            var result = horarioService.ObtenerHorarios();
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");

            return View(result);
        }

        [HttpGet]
        public ActionResult VistaHorarios()
        {
            var result = horarioService.ObtenerHorariosPorHora();

            return PartialView("VistaHorarios", result);
        }

        [HttpGet]
        public ActionResult ListHorariosMostrar()
        {
            var result = horarioService.ObtenerHorarios();
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");

            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AddHorario()
        {
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");
            ViewBag.Empleado = empleadoService.ObtenerEmpleadoPorCriterio("Conductor");
            ViewBag.Vehiculo = vehiculoService.ObtenerVehiculosPorCriterio("");

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult GenerarHorarios()
        {
            ViewBag.Mensaje = horarioService.GenerarHorarios();

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Horario",
                Cambio = "Generar Horarios",
                IdModulo = "",
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

            return PartialView("Eliminar");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AddHorario(Horario model)
        {
            model.Costo = Decimal.Parse(decimalAstring(model.CostoText));

            horarioService.GuardarHorario(model);

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Horario",
                Cambio = "Nuevo Horario",
                IdModulo = model.HoraText,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

            return Redirect("ListHorarios");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                var hor = horarioService.ObtenerClientePorId(idve);

                RegUsuarios movimiento = new RegUsuarios
                {
                    Usuario = User.Identity.Name,
                    Modulo = "Horario",
                    Cambio = "Eliminar Horario",
                    IdModulo = hor.HoraText,
                    Fecha = DateTime.Now
                };

                horarioService.EliminarHorario(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
                
                movCuentaService.GuardarMovimiento(movimiento);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puedo eliminar la venta realizada";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Int32 id)
        {
            var result = horarioService.ObtenerClientePorId(id);
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");
            ViewBag.Empleado = empleadoService.ObtenerEmpleadoPorCriterio("Conductor");
            ViewBag.Vehiculo = vehiculoService.ObtenerVehiculosPorCriterio("");

            if (result.HoraText.Substring(6, 2) == "AM")
            {
                ViewBag.Hora = result.HoraText.Substring(0, 5);
            }
            else
            {
                ViewBag.Hora = (Int32.Parse(result.HoraText.Substring(0, 2)) + 12) + result.HoraText.Substring(2, 3);
            }

            result.CostoText = decimalAstring2(result.Costo.ToString());

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Modificar(Horario model)
        {
            model.Costo = Decimal.Parse(decimalAstring(model.CostoText));

            horarioService.ModificarHorario(model);

            RegUsuarios movimiento = new RegUsuarios
            {
                Usuario = User.Identity.Name,
                Modulo = "Horario",
                Cambio = "Modificar Horario",
                IdModulo = model.HoraText,
                Fecha = DateTime.Now
            };

            movCuentaService.GuardarMovimiento(movimiento);

            return Redirect(Url.Action("ListHorarios"));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult AsientosVehiculo(Int32? idVehiculo)
        {
            int id = 0;

            if (idVehiculo != null)
            {
                id = Int32.Parse(idVehiculo.ToString());
            }

            var vehiculo = vehiculoService.ObtenerVehiculoPorId(id);

            ViewBag.asientos = vehiculo.Asientos;

            return PartialView("_AddHorarios");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult HorariosEstacionOrigen(Int32? idEstacion, Int32? idDestino)
        {
            Int32 inicio = 0;
            Int32 fin = 0;

            if (idEstacion != null)
            {
                inicio = Int32.Parse(idEstacion.ToString());
            }
            if (idDestino != null)
            {
                fin = Int32.Parse(idDestino.ToString());
            }

            var result = horarioService.ObtenerHorariosPorEstacionNoVacio(inicio, fin);

            return PartialView("_ListHorarios", result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult HorariosEstacionOrigen2(Int32? idEstacion, Int32? idDestino)
        {
            Int32 inicio = 0;
            Int32 fin = 0;

            if (idEstacion != null)
            {
                inicio = Int32.Parse(idEstacion.ToString());
            }
            if (idDestino != null)
            {
                fin = Int32.Parse(idDestino.ToString());
            }

            var result = horarioService.ObtenerHorariosPorEstacionNoVacio(inicio, fin);

            return PartialView("__ListHorarios", result);
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
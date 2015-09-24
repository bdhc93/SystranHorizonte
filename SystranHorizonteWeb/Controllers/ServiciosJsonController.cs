using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;

namespace SystranHorizonteWeb.Controllers
{
    public class ServiciosJsonController : Controller
    {
        public IVehiculoService vehiculoService { get; set; }
        public IHorarioService horarioService { get; set; }
        public IEstacionService estacionService { get; set; }
        public IEmpleadoService empleadoService { get; set; }
        public IClienteService clienteService { get; set; }
        public ICargaService cargaService { get; set; }

        public ServiciosJsonController(IVehiculoService vehiculoService, IHorarioService horarioService,
            IEstacionService estacionService, IEmpleadoService empleadoService,
            IClienteService clienteService, ICargaService cargaService)
        {
            this.vehiculoService = vehiculoService;
            this.horarioService = horarioService;
            this.estacionService = estacionService;
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
            this.cargaService = cargaService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListVehiculos()
        {

            var estaciones = vehiculoService.ObtenerVehiculosPorCriterio("");
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  TarjetaPropiedad = obj.TarjetaPropiedad,
                                  NroPlaca = obj.NroPlaca,
                                  FechaSoat = obj.FechaSoat,
                                  FechaRevisionTecnica = obj.FechaRevisionTecnica,
                                  Ancho = obj.Ancho,
                                  Largo = obj.Largo,
                                  Asientos = obj.Asientos
                              })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListEstacion()
        {

            var estaciones = estacionService.ObtenerEstacionsPorCriterio("");
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  Ciudad = obj.Ciudad,
                                  Provincia = obj.Provincia,
                                  Direccion = obj.Direccion,
                                  Telefono = obj.Telefono,
                                  Codigo = obj.Codigo
                              })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListHorarios()
        {

            var estaciones = horarioService.ObtenerHorarios();
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  Hora = obj.Hora,
                                  Costo = obj.Costo,
                                  EstacionOrigen = obj.EstacionOrigen.EstacionesT,
                                  EstacionDestino = obj.EstacionDestino.EstacionesT,
                                  Empleados = obj.Empleados.Nombre + " " + obj.Empleados.Apellidos
                              })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListEmpleados()
        {

            var estaciones = empleadoService.ObtenerEmpleadoPorCriterio("");
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  Nombre = obj.Nombre,
                                  Apellidos = obj.Apellidos,
                                  Telefono = obj.Telefono,
                                  Cargo = obj.Cargo,
                                  Comentario = obj.Comentario
                              })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListClientes()
        {

            var estaciones = clienteService.ObtenerClientesPorCriterio("");
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  DniRuc = obj.DniRuc,
                                  Nombre = obj.Nombre,
                                  Apellidos = obj.Apellidos,
                                  Direccion = obj.Direccion,
                                  Telefono = obj.Telefono
                              })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListCarga()
        {

            var estaciones = cargaService.ObtenerCargasPorCriterio("");
            return this.Json(new
            {
                Estaciones = (from obj in estaciones
                              select new
                              {
                                  Id = obj.Id,
                                  Peso = obj.Peso,
                                  Precio = obj.Precio,
                                  Tipo = obj.TipoMostrar
                              })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
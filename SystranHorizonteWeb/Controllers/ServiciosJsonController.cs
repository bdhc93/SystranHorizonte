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
        public ActionResult ListEstacion(String ciudad)
        {
            if (!String.IsNullOrEmpty(ciudad))
            {
                if (ciudad== "--Todas--")
                {
                    var estaciones = estacionService.ObtenerEstacionsPorCriterio("");
                    return this.Json(new
                    {
                        Estaciones = (from obj in estaciones
                                      select new
                                      {
                                          EstacionesT = obj.EstacionesT,
                                          Provincia = obj.Provincia,
                                          Direccion = obj.Direccion,
                                          Telefono = obj.Telefono,
                                          Codigo = obj.Codigo
                                      })
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var estaciones = estacionService.ObtenerEstacionsPorCriterio(ciudad);
                    return this.Json(new
                    {
                        Estaciones = (from obj in estaciones
                                      select new
                                      {
                                          EstacionesT = obj.EstacionesT,
                                          Provincia = obj.Provincia,
                                          Direccion = obj.Direccion,
                                          Telefono = obj.Telefono,
                                          Codigo = obj.Codigo
                                      })
                    }, JsonRequestBehavior.AllowGet);
                }
                
            }

            return this.Json(new
            {
                Mensaje = "Error en la data"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListHorarios()
        {
            //var horarios = horarioService.ObtenerHorariosPorEstacion();
            var horarios = horarioService.ObtenerHorarios();
            return this.Json(new
            {
                Horarios = (from obj in horarios
                            select new
                              {
                                  Hora = obj.Hora,
                                  Costo = obj.Costo,
                                  EstacionOrigen = obj.EstacionOrigen.EstacionesT,
                                  EstacionDestino = obj.EstacionDestino.EstacionesT,
                                  Asientos = obj.Asientos
                              })
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}
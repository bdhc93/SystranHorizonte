using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Web.Controllers
{
    public class ServiciosJsonController : Controller
    {
        public IHorarioService horarioService { get; set; }
        public IEstacionService estacionService { get; set; }
        public IVentaService ventaService { get; set; }

        public ServiciosJsonController(IHorarioService horarioService,
            IEstacionService estacionService, IVentaService ventaService)
        {
            this.horarioService = horarioService;
            this.estacionService = estacionService;
            this.ventaService = ventaService;
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
                if (ciudad == "--Seleccionar--")
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
        public ActionResult ListHorarios(String origen, String destino)
        {
            if (destino == "--Seleccionar--")
            {
                destino = "";
            }

            if (origen == "--Seleccionar--")
            {
                origen = "";
            }

            var horarios = horarioService.ObtenerHorariosPorCiudades(origen, destino);

            return this.Json(new
            {
                Horarios = (from obj in horarios
                            select new
                            {
                                Hora = obj.HoraText,
                                Costo = obj.Costo,
                                Asientos = obj.Asientos,
                                Origen = obj.EstacionOrigen.Ciudad + " - " + obj.EstacionOrigen.Provincia,
                                Destino = obj.EstacionDestino.Ciudad + " - " + obj.EstacionDestino.Provincia
                            })
            }, JsonRequestBehavior.AllowGet);

            //var horarios = horarioService.ObtenerHorariosPorEstacion();
            //var horarios = horarioService.ObtenerHorarios();

        }

        [HttpGet]
        public ActionResult ListEstado(String nroVenta)
        {
            if (!String.IsNullOrEmpty(nroVenta))
            {
                int NroVenta = Int32.Parse(nroVenta);

                var venta = ventaService.ObtenerVentaporNroVenta(NroVenta);
                var ventas = new List<Venta>();
                ventas.Add(venta);

                var tipo = "";

                switch (venta.Tipo)
                {
                    case 1:
                        tipo = "Pasaje";
                        break;
                    case 3:
                        tipo = "Encomienda";
                        break;
                    case 5:
                        tipo = "Reserva";
                        break;
                    default:
                        break;
                }

                return this.Json(new
                {
                    DetalleVenta = from obj in ventas
                                   select new
                                   {
                                       Fecha = obj.Fecha.Day + "-" + obj.Fecha.Month + "-" + obj.Fecha.Year,
                                       Estado = obj.EstadoMostrar,
                                       Tipo = tipo,
                                       NombreCliente = obj.Cliente.Nombre + " " + obj.Cliente.Apellidos,
                                       RucDni = obj.Cliente.DniRuc,
                                       TotalVenta = obj.TotalVenta + ""
                                   }
                }, JsonRequestBehavior.AllowGet);

            }

            return this.Json(new
            {
                Mensaje = "Error en la data"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
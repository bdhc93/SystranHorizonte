﻿using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonteWeb.Controllers
{
    public class EncomientaController : Controller
    {
        public IEstacionService estacionService { get; set; }
        public IVentaService ventaService { get; set; }
        public IHorarioService horarioService { get; set; }
        public IVentaAsientoService ventaAsientoService { get; set; }
        public ICargaService cargaService { get; set; }
        public IClienteService clienteService { get; set; }

        public EncomientaController(IVentaService ventaService, IEstacionService estacionService,
            IHorarioService horarioService, IVentaAsientoService ventaAsientoService,
            ICargaService cargaService, IClienteService clienteService)
        {
            this.ventaService = ventaService;
            this.estacionService = estacionService;
            this.horarioService = horarioService;
            this.ventaAsientoService = ventaAsientoService;
            this.cargaService = cargaService;
            this.clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult ListarEncomiendas()
        {
            ViewBag.Fecha = MostrarFecha();
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");
            var result = ventaService.ObtenerEncomiendas();

            return View(result);
        }

        [HttpGet]
        public ActionResult AgregarEncomienda()
        {
            ViewBag.NroVenta = ventaService.ObtenerNroVenta();
            ViewBag.Fecha = MostrarFecha();
            ViewBag.RucDni = "";
            ViewBag.TotalPago = "";
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEncomienda(Venta model)
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult DetalleVenta()
        {
            ViewBag.Horarios = horarioService.ObtenerHorariosPorEstacion(0, 0);

            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");

            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(0,1);

            ViewBag.Carga = cargaService.ObtenerCargasPorCriterio("Encomiendas");

            return PartialView();
        }

        [HttpGet]
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

            ViewBag.Horarios = horarioService.ObtenerHorariosPorEstacion(inicio, fin);
            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(0,0);
            ViewBag.Carga = cargaService.ObtenerCargasPorCriterio("Encomiendas");

            return PartialView("__AddVenta");
        }

        [HttpGet]
        public ActionResult AgregarDetalle(Int32? indice, Int32? idHorario,
            Int32? idEstacion, Int32? idDestino, Int32? idCarga,
            String pago, String lbdni, String Nombres, String Apellidos,
            String Telefono, String Direccion)
        {
            var clienbor = clienteService.ObtenerClientePorRucDni(lbdni);

            if (clienbor == null)
            {
                Cliente cliente = new Cliente
                {
                    DniRuc = lbdni,
                    Nombre = Nombres,
                    Apellidos = Apellidos,
                    Telefono = Telefono,
                    Direccion = Direccion
                };

                clienteService.GuardarCliente(cliente);

                clienbor = clienteService.ObtenerClientePorRucDni(lbdni);
            }

            ViewBag.EstOrigen = estacionService.ObtenerEstacionPorId(Int32.Parse(idEstacion.ToString()));

            ViewBag.EstDestino = estacionService.ObtenerEstacionPorId(Int32.Parse(idDestino.ToString()));

            ViewBag.Indice = indice;
            ViewBag.IdHorario = idHorario;
            ViewBag.IdCarga = idCarga;
            ViewBag.Pago = pago;

            return PartialView("_DetalleVenta", clienbor);
        }

        [HttpGet]
        public ActionResult Pagos(Int32? IdHorario, Int32? IdCarga)
        {
            Int32 idhor = 0;
            Int32 idcarg = 0;

            if (IdCarga != null)
            {
                idcarg = Int32.Parse(IdCarga.ToString());
            }
            if (IdHorario != null)
            {
                idhor = Int32.Parse(IdHorario.ToString());
            }
            var hor = horarioService.ObtenerClientePorId(idhor);
            var carg = cargaService.ObtenerCargaPorId(idcarg);

            if (hor != null)
            {
                if (carg != null)
                {
                    ViewBag.Pago = hor.Costo + carg.Precio;
                }
                else
                {
                    ViewBag.Pago = hor.Costo;
                }
            }

            return PartialView("___AddVenta");
        }

        [HttpGet]
        public ActionResult ClientesPrin(String dni)
        {
            Cliente result = clienteService.ObtenerClientePorRucDni(dni);
            return PartialView("_Clientes", result);
        }

        [HttpGet]
        public ActionResult Clientes(String dni)
        {
            Cliente result = clienteService.ObtenerClientePorRucDni(dni);
            return PartialView("_AddVenta", result);
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
        public ActionResult CajaTotalPago(String pago, String totalVenta, Boolean estado)
        {
            Decimal pagod = 0;
            Decimal totalventad = 0;

            if (estado)
            {
                if (!String.IsNullOrEmpty(pago))
                {
                    pagod = Decimal.Parse(pago);
                }
                if (!String.IsNullOrEmpty(totalVenta))
                {
                    totalventad = Decimal.Parse(totalVenta);
                }

                ViewBag.TotalPago = totalventad + pagod;
            }
            else
            {
                if (!String.IsNullOrEmpty(pago))
                {
                    pagod = Decimal.Parse(pago);
                }
                if (!String.IsNullOrEmpty(totalVenta))
                {
                    totalventad = Decimal.Parse(totalVenta);
                }

                ViewBag.TotalPago = totalventad - pagod;
            }

            return PartialView("_Pago");
        }
    }
}
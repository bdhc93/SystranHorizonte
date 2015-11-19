using System;
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
        public IVehiculoService vehiculoService { get; set; }

        public EncomientaController(IVentaService ventaService, IEstacionService estacionService,
            IHorarioService horarioService, IVentaAsientoService ventaAsientoService,
            ICargaService cargaService, IClienteService clienteService,
            IVehiculoService vehiculoService)
        {
            this.ventaService = ventaService;
            this.estacionService = estacionService;
            this.horarioService = horarioService;
            this.ventaAsientoService = ventaAsientoService;
            this.cargaService = cargaService;
            this.clienteService = clienteService;
            this.vehiculoService = vehiculoService;
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
            try
            {
                var clien = clienteService.ObtenerClientePorRucDni(model.RucDniCliente);
                model.IdCliente = clien.Id;
                model.Fecha = DateTime.Now;
                model.Tipo = 5;
                model.TotalCarga = 0;
                model.Estado = 5;

                foreach (var item in model.VentaEncomiendas)
                {
                    model.TotalCarga = model.TotalCarga + item.CargaEncomienda;

                    var hor = horarioService.ObtenerClientePorId(item.IdHorario);

                    hor.CargaMax = hor.CargaMax + item.CargaEncomienda;

                    horarioService.ModificarHorario(hor);

                    item.Estado = 1;

                    item.FechaRecepcion = DateTime.Parse((hor.Hora.Hour + 5) + ":" + hor.Hora.Minute);

                    var clienbor = clienteService.ObtenerClientePorRucDni(item.DniRucClienteTemp);

                    if (clienbor == null)
                    {
                        Cliente cliente = new Cliente
                        {
                            DniRuc = item.DniRucClienteTemp,
                            Nombre = item.NombreClienteTemp,
                            Apellidos = item.ApellidosClienteTemp,
                            Telefono = item.TelefonoClienteTemp,
                            Direccion = item.DireccionClienteTemp
                        };

                        clienteService.GuardarCliente(cliente);

                        clienbor = clienteService.ObtenerClientePorRucDni(item.DniRucClienteTemp);

                        item.IdCliente = clienbor.Id;
                    }
                    else
                    {
                        item.IdCliente = item.IdClienteTemp;
                    }
                }

                ventaService.GuardarVenta(model);

                return Redirect(@Url.Action("FinalVenta", "Encomienta") + "/" + model.Id);
            }
            catch (Exception)
            {
                return Redirect(@Url.Action("ListarEncomiendas", "Encomienta") + "/" + model.Id);
            }
            
        }

        [HttpGet]
        public ActionResult FinalVenta(Int32 id)
        {
            var result = ventaService.ObtenerVentaPorId(id);
            return View(result);
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
        public ActionResult ModificarEncomienda()
        {
            return View();
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
            Int32? idEstacion, Int32? idDestino, Decimal CargaPasaje,
            String pago, String lbdni, String Nombres, String Apellidos,
            String Telefono, String Direccion, String descripcion)
        {
            try
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

                    clienbor = cliente;
                }

                if (String.IsNullOrEmpty(Nombres) || String.IsNullOrEmpty(Apellidos) || String.IsNullOrEmpty(lbdni))
                {
                    return View();
                }

                ViewBag.EstOrigen = estacionService.ObtenerEstacionPorId(Int32.Parse(idEstacion.ToString()));

                ViewBag.EstDestino = estacionService.ObtenerEstacionPorId(Int32.Parse(idDestino.ToString()));

                ViewBag.Indice = indice;
                ViewBag.IdHorario = idHorario;
                ViewBag.IdCarga = CargaPasaje;

                var cargalist = cargaService.ObtenerCargaPorRango(CargaPasaje, false);

                ViewBag.IdCarga = cargalist.Id;

                ViewBag.CargaPasaje = CargaPasaje;

                ViewBag.Pago = pago;

                ViewBag.Descripcion = descripcion;

                return PartialView("_DetalleVenta", clienbor);
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult EliminarVenta(Int32 idve)
        {
            try
            {
                ventaService.EliminarVenta(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puede eliminar";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        public ActionResult Pagos(Int32? IdHorario, Decimal? cargaPasaje)
        {
            Int32 idhor = 0;
            Decimal cargaPas = 0;

            if (cargaPasaje != null)
            {
                cargaPas = Decimal.Parse(cargaPasaje.ToString());
            }
            if (IdHorario != null)
            {
                idhor = Int32.Parse(IdHorario.ToString());
            }
            var hor = horarioService.ObtenerClientePorId(idhor);
            var carg = cargaService.ObtenerCargaPorRango(cargaPas, true);

            if (hor != null)
            {
                if (carg != null)
                {
                    var vehi = vehiculoService.ObtenerVehiculoPorId(hor.VehiculoId);

                    if (hor.CargaMax + cargaPas > vehi.CargaMax)
                    {
                        ViewBag.Pago = "Carga Superada";
                    }
                    else
                    {
                        ViewBag.Pago = hor.Costo + carg.Precio;
                    }

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
        public ActionResult CajaTotalPago(String pago, String totalVenta, Boolean estado, String lbdni)
        {
            Decimal pagod = 0;
            Decimal totalventad = 0;

            ViewBag.TotalPago = totalventad;

            if (!String.IsNullOrEmpty(lbdni))
            {
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
            }

            return PartialView("_Pago");
        }
    }
}

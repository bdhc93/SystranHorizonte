using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Collections.Generic;

namespace SystranHorizonte.Web.Controllers
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
            var result = ventaService.ObtenerEncomiendas("", DateTime.Now.Date, DateTime.Now.Date.AddDays(1), 0);

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

        [HttpGet]
        public ActionResult Buscar(string criterio, DateTime fechaini, DateTime fechafin, Int32 EstacionOringen = 0)
        {
            var result = ventaService.ObtenerEncomiendas(criterio, fechaini, fechafin, EstacionOringen);

            return PartialView("_ListVentas", result);
        }

        public ActionResult Report(string id, Int32? idventa)
        {
            LocalReport lr = new LocalReport();

            Int32 idVenta;
            string path = Path.Combine(Server.MapPath("~/Reportes"), "ComprobanteEncomienda.rdlc");
            if (System.IO.File.Exists(path))
            {
                if (idventa != null)
                {
                    idVenta = Int32.Parse(idventa.ToString());
                }
                else
                {
                    return View("ListarReservas");
                }

                lr.ReportPath = path;
            }
            else
            {
                return View("ListarReservas");
            }


            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>16cm</PageWidth>" +
            "  <PageHeight>12cm</PageHeight>" +
            "  <MarginTop>0.5cm</MarginTop>" +
            "  <MarginLeft>0.5cm</MarginLeft>" +
            "  <MarginRight>0.5cm</MarginRight>" +
            "  <MarginBottom>0.5cm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            List<DatosReportVentaComprobante> cm = new List<DatosReportVentaComprobante>();
            Venta pru = ventaService.ObtenerVentaPorId(idVenta);

            foreach (var item in pru.VentaEncomiendas)
            {
                var datos = new DatosReportVentaComprobante
                {
                    DniRuc = item.Cliente.DniRuc,
                    Apellidos = item.Cliente.Nombre + " " + item.Cliente.Apellidos,
                    OrigenId = item.Horario.EstacionOrigen.Provincia,
                    DestinoId = item.Horario.EstacionDestino.Provincia,
                    Hora = item.Horario.HoraText,
                    Pago = item.Pago
                };

                cm.Add(datos);
            }

            ReportDataSource rd = new ReportDataSource("ComprobantePago", cm);
            lr.DataSources.Add(rd);

            ReportParameter[] parametros = new ReportParameter[7];

            parametros[0] = new ReportParameter("NroVenta", pru.NroVenta + "");
            parametros[1] = new ReportParameter("Nombre", pru.Cliente.Nombre + " " + pru.Cliente.Apellidos);
            parametros[2] = new ReportParameter("Fecha", pru.Fecha + "");
            parametros[3] = new ReportParameter("DniRuc", pru.Cliente.DniRuc + "");
            parametros[4] = new ReportParameter("Direccion", pru.Cliente.Direccion + "");
            parametros[5] = new ReportParameter("Telefono", pru.Cliente.Telefono + "");
            parametros[6] = new ReportParameter("Tipo", "Encomienda");

            lr.SetParameters(parametros);

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            switch (id)
            {
                case "PDF":
                    return File(renderedBytes, mimeType);
                case "Excel":
                    return File(renderedBytes, mimeType, pru.NroVenta + ".xls");
                case "Word":
                    return File(renderedBytes, mimeType, pru.NroVenta + ".doc");
                case "Image":
                    return File(renderedBytes, mimeType, pru.NroVenta + ".png");
                default:
                    break;
            }

            return File(renderedBytes, mimeType);
        }

        public ActionResult ReportReportesEncomienda(string id, string criterio, DateTime fechaini, DateTime fechafin, int EstacionOringen = 0)
        {
            LocalReport lr = new LocalReport();

            var estmos = "";
            var pru = ventaService.ObtenerEncomiendas(criterio, fechaini, fechafin, EstacionOringen);

            if (String.IsNullOrEmpty(criterio))
            {
                criterio = "";
            }

            if (EstacionOringen == 0)
            {
                estmos = "";
            }
            else
            {
                var est = estacionService.ObtenerEstacionPorId(EstacionOringen);
                estmos = est.EstacionesT;
            }

            string path = Path.Combine(Server.MapPath("~/Reportes"), "ReporteVentaPasajes.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("ListarVentas");
            }


            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>21cm</PageWidth>" +
            "  <PageHeight>29.7cm</PageHeight>" +
            "  <MarginTop>1.54cm</MarginTop>" +
            "  <MarginLeft>1.54cm</MarginLeft>" +
            "  <MarginRight>1.54cm</MarginRight>" +
            "  <MarginBottom>1.54cm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            List<DatosReportVentaPasaje> cm = new List<DatosReportVentaPasaje>();

            foreach (var item in pru)
            {
                foreach (var item2 in item.VentaEncomiendas)
                {
                    var datos = new DatosReportVentaPasaje
                    {
                        NroVenta = item.NroVenta + "",
                        Fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                        Id = item.TotalVenta + "",
                        TotalVenta = item.EstadoMostrar,

                        DniRuc = item2.Cliente.DniRuc,
                        Nombre = item2.Cliente.Nombre,
                        OrigenId = item2.Horario.EstacionOrigen.Provincia,
                        DestinoId = item2.Horario.EstacionDestino.Provincia,
                        Hora = item2.Horario.HoraText,
                        Pago = item2.Pago
                    };
                    cm.Add(datos);
                }

            }

            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);

            ReportParameter[] parametros = new ReportParameter[5];

            parametros[0] = new ReportParameter("Cliente", criterio);
            parametros[1] = new ReportParameter("EstOrigen", estmos);
            parametros[2] = new ReportParameter("FechaInicio", fechaini.Date.Day + "/" + fechaini.Date.Month + "/" + fechaini.Date.Year + "");
            parametros[3] = new ReportParameter("FechaFin", fechafin.Date.Day + "/" + fechafin.Date.Month + "/" + fechafin.Date.Year + "");
            parametros[4] = new ReportParameter("Tipo", "Encomienda");

            lr.SetParameters(parametros);

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            switch (id)
            {
                case "PDF":
                    return File(renderedBytes, mimeType);
                case "Excel":
                    return File(renderedBytes, mimeType, "Encomienda " + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".xls");
                case "Word":
                    return File(renderedBytes, mimeType, "Encomienda " + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".doc");
                case "Image":
                    return File(renderedBytes, mimeType, "Encomienda " + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".png");
                default:
                    break;
            }

            return File(renderedBytes, mimeType);
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
                    if (String.IsNullOrEmpty(item.Descripcion))
                    {
                        item.Descripcion = "";
                    }

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
            catch (Exception e)
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

            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(0, 1);

            ViewBag.Carga = cargaService.ObtenerCargasPorCriterio("Encomiendas");

            return PartialView();
        }

        [HttpGet]
        public ActionResult ModificarEncomienda(Int32 id)
        {
            var result = ventaService.ObtenerVentaPorId(id);
            ViewBag.Fecha = MostrarFecha();

            return View(result);
        }

        [HttpPost]
        public ActionResult ModificarEncomienda(Venta model)
        {
            var ventborrar = ventaService.ObtenerVentaPorId(model.Id);

            foreach (var item in ventborrar.VentaPasajes)
            {
                var hor = horarioService.ObtenerClientePorId(item.IdHorario);

                hor.CargaMax = hor.CargaMax - item.CargaPasaje;

                horarioService.ModificarHorario(hor);

            }//Eliminar Carga

            foreach (var item in model.VentaPasajes)
            {
                var hor = horarioService.ObtenerClientePorId(item.IdHorario);

                hor.CargaMax = hor.CargaMax + item.CargaPasaje;

                horarioService.ModificarHorario(hor);
            }//Nueva Carga

            var clien = clienteService.ObtenerClientePorRucDni(model.RucDniCliente);
            model.IdCliente = clien.Id;
            model.Fecha = DateTime.Now;
            model.Tipo = 5;
            model.Estado = 5;
            ventaService.ModificarVenta(model);

            return Redirect(@Url.Action("ListarVentas", "Venta"));
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
            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(0, 0);
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
                var ventborrar = ventaService.ObtenerVentaPorId(idve);
                foreach (var item in ventborrar.VentaPasajes)
                {
                    var hor = horarioService.ObtenerClientePorId(item.IdHorario);

                    hor.CargaMax = hor.CargaMax - item.CargaPasaje;

                    horarioService.ModificarHorario(hor);

                }//Eliminar Carga

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
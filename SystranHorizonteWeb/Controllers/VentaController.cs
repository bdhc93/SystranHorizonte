using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;

namespace SystranHorizonteWeb.Controllers
{
    public class VentaController : Controller
    {
        public IEstacionService estacionService { get; set; }
        public IVentaService ventaService { get; set; }
        public IHorarioService horarioService { get; set; }
        public IVentaAsientoService ventaAsientoService { get; set; }
        public ICargaService cargaService { get; set; }
        public IClienteService clienteService { get; set; }
        public IVehiculoService vehiculoService { get; set; }

        public VentaController(IVentaService ventaService, IEstacionService estacionService,
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarVentas()
        {
            ViewBag.Fecha = MostrarFecha();
            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");
            var result = ventaService.ObtenerVentas();

            return View(result);
        }

        [HttpGet]
        public ActionResult ModificarVenta(Int32 id)
        {
            var result = ventaService.ObtenerVentaPorId(id);
            ViewBag.Fecha = MostrarFecha();

            return View(result);
        }

        [HttpPost]
        public ActionResult ModificarVenta(Venta model)
        {
            var clien = clienteService.ObtenerClientePorRucDni(model.RucDniCliente);
            model.IdCliente = clien.Id;
            model.Fecha = DateTime.Now;
            model.Tipo = 1;
            model.Estado = 2;
            ventaService.ModificarVenta(model);

            return Redirect(@Url.Action("ListarVentas", "Venta"));
        }

        [HttpGet]
        public ActionResult AgregarVenta()
        {
            ViewBag.NroVenta = ventaService.ObtenerNroVenta();
            ViewBag.Fecha = MostrarFecha();
            ViewBag.RucDni = "";
            ViewBag.TotalPago = "";
            return View();
        }

        [HttpPost]
        public ActionResult AgregarVenta(Venta model)
        {
            var clien = clienteService.ObtenerClientePorRucDni(model.RucDniCliente);
            model.IdCliente = clien.Id;
            model.Fecha = DateTime.Now;
            model.Tipo = 1;
            model.TotalCarga = 0;
            model.Estado = 1;
            try
            {
                foreach (var item in model.VentaPasajes)
                {
                    model.TotalCarga = model.TotalCarga + item.CargaPasaje;

                    var hor = horarioService.ObtenerClientePorId(item.IdHorario);

                    hor.CargaMax = hor.CargaMax + item.CargaPasaje;

                    horarioService.ModificarHorario(hor);

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
            }
            catch (Exception)
            {
                return Redirect(@Url.Action("ListarVentas", "Venta"));
            }

            ventaService.GuardarVenta(model);

            return Redirect(@Url.Action("FinalVenta", "Venta")+"/"+model.Id);
        }

        [HttpGet]
        public ActionResult FinalVenta(Int32 id)
        {
            var result = ventaService.ObtenerVentaPorId(id);
            return View(result);
        }
        
        public ActionResult Report(string id, Int32? idventa)
        {
            LocalReport lr = new LocalReport();
            
            Int32 idVenta;
            string path = Path.Combine(Server.MapPath("~/Reportes"), "ComprobantePago.rdlc");
            if (System.IO.File.Exists(path))
            {
                if (idventa != null)
                {
                    idVenta = Int32.Parse(idventa.ToString());
                }
                else
                {
                    return View("ListarVentas");
                }

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

            foreach (var item in pru.VentaPasajes)
            {
                var datos = new DatosReportVentaComprobante
                {
                    DniRuc = item.Cliente.DniRuc,
                    Apellidos = item.Cliente.Nombre + " " + item.Cliente.Apellidos,
                    OrigenId = item.Horario.EstacionOrigen.Provincia,
                    DestinoId = item.Horario.EstacionDestino.Provincia,
                    Hora = item.Horario.HoraText,
                    Asiento = item.Asiento.ToString(),
                    Pago = item.Pago
                };

                cm.Add(datos);
            }

            ReportDataSource rd = new ReportDataSource("ComprobantePago", cm);
            lr.DataSources.Add(rd);

            ReportParameter[] parametros = new ReportParameter[6];

            parametros[0] = new ReportParameter("NroVenta", pru.NroVenta + "");
            parametros[1] = new ReportParameter("Nombre", pru.Cliente.Nombre + " " + pru.Cliente.Apellidos);
            parametros[2] = new ReportParameter("Fecha", pru.Fecha + "");
            parametros[3] = new ReportParameter("DniRuc", pru.Cliente.DniRuc + "");
            parametros[4] = new ReportParameter("Direccion", pru.Cliente.Direccion + "");
            parametros[5] = new ReportParameter("Telefono", pru.Cliente.Telefono + "");

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
                    //return File(renderedBytes, mimeType, pru.NroVenta + ".pdf");
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


        public ActionResult ReportReportesVentas(string id, string criterio, DateTime fechaini, DateTime fechafin, string EstacionOringen)
        {
            LocalReport lr = new LocalReport();

            if (String.IsNullOrEmpty(criterio))
            {
                criterio = "Null";
            }

            if (String.IsNullOrEmpty(EstacionOringen))
            {
                EstacionOringen = "Null";
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
            var pru = ventaService.ObtenerVentas();

            foreach (var item in pru)
            {
                foreach (var item2 in item.VentaPasajes)
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

            ReportParameter[] parametros = new ReportParameter[4];

            parametros[0] = new ReportParameter("Cliente", criterio);
            parametros[1] = new ReportParameter("EstOrigen", EstacionOringen);
            parametros[2] = new ReportParameter("FechaInicio", fechaini.Date.Day + "/" + fechaini.Date.Month + "/" + fechaini.Date.Year + "");
            parametros[3] = new ReportParameter("FechaFin", fechafin.Date.Day + "/" + fechafin.Date.Month + "/" + fechafin.Date.Year + "");

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
                //return File(renderedBytes, mimeType, pru.NroVenta + ".pdf");
                case "Excel":
                    return File(renderedBytes, mimeType, "Venta-"+ DateTime.Now.Date + ".xls");
                case "Word":
                    return File(renderedBytes, mimeType, "Venta-" + DateTime.Now.Date + ".doc");
                case "Image":
                    return File(renderedBytes, mimeType, "Venta-" + DateTime.Now.Date + ".png");
                default:
                    break;
            }

            return File(renderedBytes, mimeType);
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
        public ActionResult Asientos(Int32? IdHorario, String asientos)
        {
            Int32 idhor = 0;

            if (IdHorario != null)
            {
                idhor = Int32.Parse(IdHorario.ToString());
            }
            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(idhor, 0);


            return PartialView("____AddVenta");
        }
        
        [HttpGet]
        public ActionResult AsientosPrevio(Int32? IdHorario, Int32? asiento, String asientos)
        {
            Int32 idhor = 0;
            Int32 asient = 0;

            if (IdHorario != null)
            {
                idhor = Int32.Parse(IdHorario.ToString());
            }
            
            var asientostemp = ventaAsientoService.ObtenerVentaAsientosPorHorario(idhor, 0);

            ViewBag.Asiento1 = "checked";
            ViewBag.Asiento2 = "checked";
            ViewBag.Asiento3 = "checked";
            ViewBag.Asiento4 = "checked";
            ViewBag.Asiento5 = "checked";
            ViewBag.Asiento6 = "checked";
            ViewBag.Asiento7 = "checked";
            ViewBag.Asiento8 = "checked";
            ViewBag.Asiento9 = "checked";
            ViewBag.Asiento10 = "checked";
            ViewBag.Asiento11 = "checked";
            ViewBag.Asiento12 = "checked";
            ViewBag.Asiento13 = "checked";
            ViewBag.Asiento14 = "checked";
            ViewBag.Asiento15 = "checked";
            ViewBag.Asiento16 = "checked";
            ViewBag.Asiento1Color = "success";
            ViewBag.Asiento2Color = "success";
            ViewBag.Asiento3Color = "success";
            ViewBag.Asiento4Color = "success";
            ViewBag.Asiento5Color = "success";
            ViewBag.Asiento6Color = "success";
            ViewBag.Asiento7Color = "success";
            ViewBag.Asiento8Color = "success";
            ViewBag.Asiento9Color = "success";
            ViewBag.Asiento10Color = "success";
            ViewBag.Asiento11Color = "success";
            ViewBag.Asiento12Color = "success";
            ViewBag.Asiento13Color = "success";
            ViewBag.Asiento14Color = "success";
            ViewBag.Asiento15Color = "success";
            ViewBag.Asiento16Color = "success";

            foreach (var item in asientostemp)
            {
                switch (item.Asiento)
                {
                    case 1:
                        ViewBag.Asiento1 = "";
                        ViewBag.Asiento1Color = "info";
                        break;
                    case 2:
                        ViewBag.Asiento2 = "";
                        ViewBag.Asiento2Color = "info";
                        break;
                    case 3:
                        ViewBag.Asiento3 = "";
                        ViewBag.Asiento3Color = "info";
                        break;
                    case 4:
                        ViewBag.Asiento4 = "";
                        ViewBag.Asiento4Color = "info";
                        break;
                    case 5:
                        ViewBag.Asiento5 = "";
                        ViewBag.Asiento5Color = "info";
                        break;
                    case 6:
                        ViewBag.Asiento6 = "";
                        ViewBag.Asiento6Color = "info";
                        break;
                    case 7:
                        ViewBag.Asiento7 = "";
                        ViewBag.Asiento7Color = "info";
                        break;
                    case 8:
                        ViewBag.Asiento8 = "";
                        ViewBag.Asiento8Color = "info";
                        break;
                    case 9:
                        ViewBag.Asiento9 = "";
                        ViewBag.Asiento9Color = "info";
                        break;
                    case 10:
                        ViewBag.Asiento10 = "";
                        ViewBag.Asiento10Color = "info";
                        break;
                    case 11:
                        ViewBag.Asiento11 = "";
                        ViewBag.Asiento11Color = "info";
                        break;
                    case 12:
                        ViewBag.Asiento12 = "";
                        ViewBag.Asiento12Color = "info";
                        break;
                    case 13:
                        ViewBag.Asiento13 = "";
                        ViewBag.Asiento13Color = "info";
                        break;
                    case 14:
                        ViewBag.Asiento14 = "";
                        ViewBag.Asiento14Color = "info";
                        break;
                    case 15:
                        ViewBag.Asiento15 = "";
                        ViewBag.Asiento15Color = "info";
                        break;
                    case 16:
                        ViewBag.Asiento16 = "";
                        ViewBag.Asiento16Color = "info";
                        break;
                    default:
                        break;
                }
            }


            if (asiento != null)
            {
                asient = Int32.Parse(asiento.ToString());

                var asi = ventaAsientoService.ObtenerVentaAsientosPorId(asient);

                switch (asi.Asiento)
                {
                    case 1:
                        ViewBag.Asiento1 = "checked";
                        ViewBag.Asiento1Color = "warning";
                        break;
                    case 2:
                        ViewBag.Asiento2 = "checked";
                        ViewBag.Asiento2Color = "warning";
                        break;
                    case 3:
                        ViewBag.Asiento3 = "checked";
                        ViewBag.Asiento3Color = "warning";
                        break;
                    case 4:
                        ViewBag.Asiento4 = "checked";
                        ViewBag.Asiento4Color = "warning";
                        break;
                    case 5:
                        ViewBag.Asiento5 = "checked";
                        ViewBag.Asiento5Color = "warning";
                        break;
                    case 6:
                        ViewBag.Asiento6 = "checked";
                        ViewBag.Asiento6Color = "warning";
                        break;
                    case 7:
                        ViewBag.Asiento7 = "checked";
                        ViewBag.Asiento7Color = "warning";
                        break;
                    case 8:
                        ViewBag.Asiento8 = "checked";
                        ViewBag.Asiento8Color = "warning";
                        break;
                    case 9:
                        ViewBag.Asiento9 = "checked";
                        ViewBag.Asiento9Color = "warning";
                        break;
                    case 10:
                        ViewBag.Asiento10 = "checked";
                        ViewBag.Asiento10Color = "warning";
                        break;
                    case 11:
                        ViewBag.Asiento11 = "checked";
                        ViewBag.Asiento11Color = "warning";
                        break;
                    case 12:
                        ViewBag.Asiento12 = "checked";
                        ViewBag.Asiento12Color = "warning";
                        break;
                    case 13:
                        ViewBag.Asiento13 = "checked";
                        ViewBag.Asiento13Color = "warning";
                        break;
                    case 14:
                        ViewBag.Asiento14 = "checked";
                        ViewBag.Asiento14Color = "warning";
                        break;
                    case 15:
                        ViewBag.Asiento15 = "checked";
                        ViewBag.Asiento15Color = "warning";
                        break;
                    case 16:
                        ViewBag.Asiento16 = "checked";
                        ViewBag.Asiento16Color = "warning";
                        break;
                    default:
                        break;
                }
            }
            
            return PartialView("_Asientos");
        }

        [HttpGet]
        public ActionResult AgregarDetalle(Int32? indice, Int32? idHorario,
            Int32? idEstacion, Int32? idDestino, Int32? idAsiento, Decimal CargaPasaje,
            String pago, String lbdni, String Nombres, String Apellidos,
            String Telefono, String Direccion, String AsientoCache, String idventa)
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

                if (String.IsNullOrEmpty(Nombres) || String.IsNullOrEmpty(Apellidos) || String.IsNullOrEmpty(lbdni) )
                {
                    return View();
                }

                ViewBag.EstOrigen = estacionService.ObtenerEstacionPorId(Int32.Parse(idEstacion.ToString()));

                ViewBag.EstDestino = estacionService.ObtenerEstacionPorId(Int32.Parse(idDestino.ToString()));
                var asiento = ventaAsientoService.ObtenerVentaAsientosPorId(Int32.Parse(idAsiento.ToString()));
                asiento.Falsa = false;
                ventaAsientoService.ModificarVentaAsientos(asiento);

                ViewBag.Asiento = asiento;
                ViewBag.Indice = indice;
                ViewBag.IdHorario = idHorario;

                var cargalist = cargaService.ObtenerCargaPorRango(CargaPasaje, true);
                
                ViewBag.IdCarga = cargalist.Id;

                ViewBag.CargaPasaje = CargaPasaje;

                ViewBag.Pago = pago;
                
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
        public ActionResult DetalleVenta()
        {
            ViewBag.Horarios = horarioService.ObtenerHorariosPorEstacion(0, 0);

            ViewBag.Estacion = estacionService.ObtenerEstacionsPorCriterio("");

            ViewBag.Asientos = ventaAsientoService.ObtenerVentaAsientosPorHorario(0,1);

            ViewBag.Carga = cargaService.ObtenerCargasPorCriterio("Pasajes");

            return PartialView();
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
            ViewBag.Carga = cargaService.ObtenerCargasPorCriterio("Pasajes");

            return PartialView("__AddVenta");
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
        public ActionResult CajaTotalPago(String pago, String totalVenta, Boolean estado, String lbdni, String asiento)
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

                try
                {
                    if (!String.IsNullOrEmpty(asiento))
                    {
                        Int32 asient = Int32.Parse(asiento.ToString());

                        var asi = ventaAsientoService.ObtenerVentaAsientosPorId(asient);

                        asi.Falsa = true;

                        ventaAsientoService.ModificarVentaAsientos(asi);
                    }
                }
                catch (Exception)
                {

                    return View();
                }

                return PartialView("_Pago");

            }

            return PartialView("_Pago");
        }
    }
}
using System;
using System.Web.Mvc;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Linq;

namespace SystranHorizonte.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        public IEmpleadoService empleadoService { get; set; }

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ListarEmpleado()
        {
            var result = empleadoService.ObtenerEmpleadoPorCriterio("");
            return View(result);
        }

        [HttpGet]
        public ActionResult ReporteEmpleado()
        {
            ViewBag.Fecha = MostrarFecha();
            ViewBag.Empleados = empleadoService.ObtenerEmpleadoPorCriterio("Conductor");
            return View();
        }

        [HttpGet]
        public ActionResult AgregarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEmpleado(Empleado model)
        {
            empleadoService.GuardarEmpleado(model);

            return Redirect("ListarEmpleado");
        }

        [HttpGet]
        public ActionResult Eliminar(Int32 idve)
        {
            try
            {
                empleadoService.EliminarEmpleado(idve);
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "No se puede eliminar";
            }

            return PartialView("Eliminar");
        }

        [HttpGet]
        public ActionResult Modificar(Int32 id)
        {
            var result = empleadoService.ObtenerEmpleadoPorId(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Modificar(Empleado model)
        {
            empleadoService.ModificarEmpleado(model);

            return Redirect(Url.Action("ListarEmpleado"));
        }

        [HttpGet]
        public ActionResult Buscar(String criterio)
        {
            var result = empleadoService.ObtenerEmpleadoPorCriterio(criterio);

            return PartialView("_Listar", result);
        }

        [HttpGet]
        public ActionResult Buscar2(Int32 id, DateTime fechaIni, DateTime fechaFin)
        {
            var result = empleadoService.ObtenerEmpleadoPorCriterios(id, fechaIni, fechaFin);

            return PartialView("__Listar", result);
        }

        public ActionResult ReportEmpleados(string id, Int32 idempleado, DateTime fechaIni, DateTime fechaFin)
        {
            LocalReport lr = new LocalReport();

            var pru = empleadoService.ObtenerEmpleadoPorCriterios(idempleado, fechaIni, fechaFin);

            string path = Path.Combine(Server.MapPath("~/Reportes"), "ReporteEmpleados.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("ReporteEmpleado");
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

            ReportDataSource rd = new ReportDataSource("VistaEmpleados", pru);
            lr.DataSources.Add(rd);

            var empleado = empleadoService.ObtenerEmpleadoPorId(idempleado);

            ReportParameter[] parametros = new ReportParameter[6];

            parametros[0] = new ReportParameter("Nombre", empleado.Nombre);
            parametros[1] = new ReportParameter("Apellidos", empleado.Apellidos);
            parametros[2] = new ReportParameter("Telefono", empleado.Telefono);
            parametros[3] = new ReportParameter("FechaIni", fechaIni.Date.Day + "/" + fechaIni.Date.Month + "/" + fechaIni.Date.Year + "");
            parametros[4] = new ReportParameter("FechaFin", fechaFin.Date.Day + "/" + fechaFin.Date.Month + "/" + fechaFin.Date.Year + "");
            parametros[5] = new ReportParameter("TotalHoras", pru.Count() + "");

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
                    return File(renderedBytes, mimeType, "Empleado " + empleado.Nombre + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".xls");
                case "Word":
                    return File(renderedBytes, mimeType, "Empleado " + empleado.Nombre + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".doc");
                case "Image":
                    return File(renderedBytes, mimeType, "Empleado " + empleado.Nombre + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + ".png");
                default:
                    break;
            }

            return File(renderedBytes, mimeType);
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
    }
}
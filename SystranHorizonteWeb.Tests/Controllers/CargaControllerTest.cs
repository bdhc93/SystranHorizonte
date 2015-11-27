using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonteWeb;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Web.Controllers;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class CargaControllerTest
    {
        public ICargaService cargaService { get; set; }
        
        //[TestMethod]
        //public void CargaControllerGuardar()
        //{
        //    CargasController controller = new CargasController(cargaService);

        //    Carga model = new Carga
        //    {
        //        Estado = true,
        //        Peso = 0,
        //        Precio = 10,
        //        Tipo = true,
        //        TipoString = "Encomiendas"
        //    };

        //    ViewResult result = controller.AddCarga() as ViewResult;
        //}

        //[TestMethod]
        //public void CargaControllerModificar()
        //{
        //    CargasController controller = new CargasController(cargaService);
            
        //    ViewResult result = controller.AddCarga() as ViewResult;

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void CargaControllerEliminar()
        //{
        //    CargasController controller = new CargasController(cargaService);
                        
        //    ViewResult result = controller.AddCarga() as ViewResult;

        //    Assert.IsNotNull(result);
        //}
    }
}

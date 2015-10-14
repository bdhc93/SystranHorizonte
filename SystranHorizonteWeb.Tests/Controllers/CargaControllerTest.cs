using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonteWeb;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonteWeb.Controllers;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class CargaControllerTest
    {
        public ICargaService cargaService { get; set; }
        
        [TestMethod]
        public void CargaControllerGuardar()
        {
            CargasController controller = new CargasController(cargaService);

            Carga model = new Carga
            {
                Estado = true,
                Peso = "0 kg Prueba",
                Precio = 10,
                Tipo = true,
                TipoString = "Encomiendas"
            };

            ViewResult result = controller.AddCarga(model) as ViewResult;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CargaControllerModificar()
        {
            CargasController controller = new CargasController(cargaService);

            Int32 idPrueba = 0;

            ViewResult result = controller.Modificar(idPrueba) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CargaControllerEliminar()
        {
            CargasController controller = new CargasController(cargaService);

            Int32 idPrueba = 0;

            ViewResult result = controller.Eliminar(idPrueba) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

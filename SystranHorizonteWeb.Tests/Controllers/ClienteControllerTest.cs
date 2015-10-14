using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystranHorizonte.Repository.Ventas.Datos;
using SystranHorizonte.Models;

namespace SystranHorizonteWeb.Tests.Controllers
{
    [TestClass]
    public class ClienteControllerTest
    {
        public ClienteRepository clienteRepository { get; set; }
        
        [TestMethod]
        public void ClienteRepGuardar()
        {
            Cliente cliente = new Cliente {
                DniRuc = "73136701",
                Nombre = "Billy Davis",
                Apellidos = "Prueba",
                Direccion = "Direccion Prueba",
                Telefono = "9797997"
            };

            clienteRepository.GuardarCliente(cliente);
        }
        
    }
}

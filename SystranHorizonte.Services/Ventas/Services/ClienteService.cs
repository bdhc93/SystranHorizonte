using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;
using SystranHorizonte.Services.Validators;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class ClienteService : IClienteService
    {
        private ClienteValidator validator { get; set; }

        public IClienteRepository clienteRepository { get; set; }

        public ClienteService(IClienteRepository clienteRepository, ClienteValidator validator)
        {
            this.clienteRepository = clienteRepository;
            this.validator = validator;
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return clienteRepository.ObtenerClientePorId(id);
        }

        public Cliente ObtenerClientePorRucDni(string RucDni)
        {
            return clienteRepository.ObtenerClientePorRucDni(RucDni);
        }

        public IEnumerable<Cliente> ObtenerClientesPorCriterio(string criterio)
        {
            return clienteRepository.ObtenerClientesPorCriterio(criterio);
        }

        public Dictionary<string, string> GuardarCliente(Cliente cliente)
        {
            var result = clienteRepository.ObtenerClientePorRucDni(cliente.DniRuc);

            if (!validator.Pass(cliente, result)) return validator.GetMensajes();

            clienteRepository.GuardarCliente(cliente);

            return new Dictionary<string, string>();
        }

        public void ModificarCliente(Cliente cliente)
        {
            clienteRepository.ModificarCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            clienteRepository.EliminarCliente(id);
        }
    }
}

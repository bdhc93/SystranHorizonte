using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Interfaces
{
    public interface IClienteService
    {
        Cliente ObtenerClientePorId(Int32 id);
        Cliente ObtenerClientePorRucDni(String RucDni);
        IEnumerable<Cliente> ObtenerClientesPorCriterio(String criterio);

        Dictionary<string, string> GuardarCliente(Cliente cliente);
        void ModificarCliente(Cliente cliente);
        void EliminarCliente(Int32 id);
    }
}

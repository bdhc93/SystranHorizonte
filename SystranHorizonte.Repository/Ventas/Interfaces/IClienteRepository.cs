using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObtenerClientePorId(Int32 id);
        Cliente ObtenerClientePorRucDni(String RucDni);
        IEnumerable<Cliente> ObtenerClientesPorCriterio(String criterio);

        void GuardarCliente(Cliente cliente);
        void ModificarCliente(Cliente cliente);
        void EliminarCliente(Int32 id);
    }
}

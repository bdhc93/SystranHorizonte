using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class ClienteRepository : MasterRepository, IClienteRepository
    {
        public Cliente ObtenerClientePorId(int id)
        {
            return Context.Clientes.Find(id);
        }

        public Cliente ObtenerClientePorRucDni(string RucDni)
        {
            return Context.Clientes.Where(p => p.DniRuc.Equals(RucDni)).SingleOrDefault();
        }

        public IEnumerable<Cliente> ObtenerClientesPorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Clientes.Where(p => p.Apellidos.ToUpper().Contains(criterio.ToUpper()) ||
                p.Nombre.ToUpper().Contains(criterio.ToUpper()) ||
                p.DniRuc.Contains(criterio)).ToList();
            }
            else
            {
                return Context.Clientes.ToList();
            }

        }

        public void GuardarCliente(Cliente cliente)
        {
            Context.Clientes.Add(cliente);
            Context.SaveChanges();
        }

        public void ModificarCliente(Cliente cliente)
        {
            Context.Entry(cliente).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var elim = ObtenerClientePorId(id);

            Context.Clientes.Remove(elim);
            Context.SaveChanges();
        }
    }
}

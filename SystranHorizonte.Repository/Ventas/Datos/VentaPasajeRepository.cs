using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class VentaPasajeRepository : MasterRepository, IVentaPasajeRepository
    {
        public void EliminarVentaPasaje(int id)
        {
            throw new NotImplementedException();
        }

        public void GuardarVentaPasaje(VentaPasaje venta)
        {
            throw new NotImplementedException();
        }

        public void ModificarVentaPasaje(VentaPasaje venta)
        {
            throw new NotImplementedException();
        }

        public VentaPasaje ObtenerVentaPasajePorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VentaPasaje> ObtenerVentaPasajesPorCriterio(string criterio, DateTime fechaIni, DateTime fechaFin, int idestacion)
        {
            var query = from p in Context.VentaPasajes
                        .Include("Venta").Include("Venta.Cliente")
                        .Include("Horario").Include("Horario.EstacionOrigen").Include("Horario.EstacionDestino")
                        .ToList()
                        select p;
            
            if (!string.IsNullOrEmpty(criterio))
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Venta.Cliente.Apellidos.ToUpper().Contains(criterio.ToUpper())
                                || p.Venta.Cliente.DniRuc.Contains(criterio.ToUpper())) && (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }
            else
            {
                if (idestacion == 0)
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1
                            select p;
                }
                else
                {
                    query = from p in query
                            where (p.Venta.Fecha >= fechaIni && p.Venta.Fecha <= fechaFin.AddHours(24)) && p.Venta.Tipo == 1 && p.Horario.OrigenId == idestacion
                            select p;
                }
            }

            return query.ToList();
        }
    }
}

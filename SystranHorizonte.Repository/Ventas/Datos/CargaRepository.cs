using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class CargaRepository : MasterRepository, ICargaRepository
    {
        public Carga ObtenerCargaPorId(int id)
        {
            return Context.Cargas.Find(id);
        }

        public IEnumerable<Carga> ObtenerCargasPorCriterio(string criterio)
        {
            var query = from p in Context.Cargas
                        select p;

            if (String.IsNullOrEmpty(criterio))
                return Context.Cargas.ToList();
            else
                if (criterio == "Pasajes")
            {
                query = from p in query
                        where p.Tipo.Equals(true)
                        select p;
            }
            else if (criterio == "Encomiendas")
            {
                query = from p in query
                        where p.Tipo.Equals(false)
                        select p;
            }
            return query.ToList();
        }

        public void GuardarCarga(Carga carga)
        {
            Context.Cargas.Add(carga);
            Context.SaveChanges();
        }

        public void ModificarCarga(Carga carga)
        {
            Context.Entry(carga).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarCarga(int id)
        {
            var elim = ObtenerCargaPorId(id);

            Context.Cargas.Remove(elim);
            Context.SaveChanges();
        }
    }
}

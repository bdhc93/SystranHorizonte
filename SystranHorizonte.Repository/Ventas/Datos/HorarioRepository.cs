using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class HorarioRepository : MasterRepository, IHorarioRepository
    {
        public Horario ObtenerClientePorId(int id)
        {
            return Context.Horarios.Find(id);
        }

        public IEnumerable<Horario> ObtenerHorariosPorEstacion(int idEstacion, int idDestino)
        {
            var query = from p in Context.Horarios.Include("EstacionOrigen").Include("EstacionDestino").Include("Empleados")
                        select p;

            if (idEstacion == 0 || idDestino == 0)
                return new List<Horario> { };
            else
                query = from p in query
                        where p.OrigenId.Equals(idEstacion) && p.DestinoId.Equals(idDestino)
                        select p;
            return query.ToList();
        }

        public void GuardarHorario(Horario horario)
        {
            throw new NotImplementedException();
        }

        public void ModificarHorario(Horario horario)
        {
            throw new NotImplementedException();
        }

        public void EliminarHorario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Horario> ObtenerHorarios()
        {
            return Context.Horarios.ToList();
        }
    }
}

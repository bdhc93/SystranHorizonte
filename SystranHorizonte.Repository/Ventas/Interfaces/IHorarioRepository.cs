using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface IHorarioRepository
    {
        Horario ObtenerClientePorId(Int32 id);
        IEnumerable<Horario> ObtenerHorariosPorEstacion(Int32 idEstacion, Int32 idDestino);
        IEnumerable<Horario> ObtenerHorariosPorCiudades(String origen, String destino);
        IEnumerable<Horario> ObtenerHorariosPorEstacionNoVacio(Int32 idEstacion, Int32 idDestino);
        IEnumerable<Horario> ObtenerHorarios();

        String GenerarHorarios();

        void GuardarHorario(Horario horario);
        void ModificarHorario(Horario horario);
        void EliminarHorario(Int32 id);
    }
}

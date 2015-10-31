using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class HorarioService : IHorarioService
    {
        public IHorarioRepository horarioRepository { get; set; }

        public HorarioService(IHorarioRepository horarioRepository)
        {
            this.horarioRepository = horarioRepository;
        }

        public Horario ObtenerClientePorId(int id)
        {
            return horarioRepository.ObtenerClientePorId(id);
        }

        public IEnumerable<Horario> ObtenerHorariosPorEstacion(int idEstacion, int idDestino)
        {
            return horarioRepository.ObtenerHorariosPorEstacion(idEstacion, idDestino);
        }

        public void GuardarHorario(Horario horario)
        {
            horarioRepository.GuardarHorario(horario);
        }

        public void ModificarHorario(Horario horario)
        {
            horarioRepository.ModificarHorario(horario);
        }

        public void EliminarHorario(int id)
        {
            horarioRepository.EliminarHorario(id);
        }

        public IEnumerable<Horario> ObtenerHorarios()
        {
            return horarioRepository.ObtenerHorarios();
        }

        public IEnumerable<Horario> ObtenerHorariosPorEstacionNoVacio(int idEstacion, int idDestino)
        {
            return horarioRepository.ObtenerHorariosPorEstacionNoVacio(idEstacion, idDestino);
        }

        public IEnumerable<Horario> ObtenerHorariosPorCiudades(string origen, string destino)
        {
            return horarioRepository.ObtenerHorariosPorCiudades(origen, destino);
        }
    }
}

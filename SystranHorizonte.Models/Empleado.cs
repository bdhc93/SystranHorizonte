using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Empleado
    {
        public Empleado()
        {
            this.Horarios = new List<Horario>();
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Cargo { get; set; }
        public String Comentario { get; set; }
        public Boolean Estado { get; set; }

        public String EstadoMostrar { get { if (!Estado) return "Inactivo"; return "Activo"; } }
        public String NombreMostrar { get { return Nombre + " " + Apellidos; } }

        public List<Horario> Horarios { get; set; }
    }
}

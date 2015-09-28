using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Estacion
    {
        public Estacion()
        {
            this.Horarios = new List<Horario>();
            this.Horarioss = new List<Horario>();
        }

        public Int32 Id { get; set; }
        public String Ciudad { get; set; }
        public String Provincia { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Codigo { get; set; }

        public Boolean Estado { get; set; }

        public String EstadoMostrar { get { if (!Estado) return "Inactivo"; return "Activo"; } }

        public String EstacionesT { get { return Codigo + ": " + Ciudad + " - " + Provincia + " - " + Direccion; } }

        public List<Horario> Horarios { get; set; }
        public List<Horario> Horarioss { get; set; }
    }
}

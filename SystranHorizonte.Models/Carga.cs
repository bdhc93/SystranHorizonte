using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Carga
    {
        public Carga()
        {
            this.VentaEncomiendas = new List<VentaEncomienda>();
            this.VentaPasajes = new List<VentaPasaje>();
            this.Reservas = new List<Reserva>();
        }

        public Int32 Id { get; set; }
        public String Peso { get; set; }
        public Decimal Precio { get; set; }
        public Boolean Tipo { get; set; }
        public Boolean Estado { get; set; }

        public String TipoMostrar { get { if (!Tipo) return "Encomiendas"; return "Pasajes"; } }

        public String TipoString { get; set; }

        public List<VentaEncomienda> VentaEncomiendas { get; set; }
        public List<VentaPasaje> VentaPasajes { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}

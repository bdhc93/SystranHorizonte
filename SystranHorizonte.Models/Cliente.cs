using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.VentaPasajes = new List<VentaPasaje>();
            this.VentaEncomiendas = new List<VentaEncomienda>();
            this.Ventas = new List<Venta>();
            this.Reservas = new List<Reserva>();
        }

        public Int32 Id { get; set; }
        public String DniRuc { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        public List<VentaPasaje> VentaPasajes { get; set; }
        public List<VentaEncomienda> VentaEncomiendas { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}

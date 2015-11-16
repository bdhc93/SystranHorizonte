using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Venta
    {
        public Venta()
        {
            this.VentaPasajes = new List<VentaPasaje>();
            this.VentaEncomiendas = new List<VentaEncomienda>();
            this.Reseras = new List<Reserva>();
        }

        public Int32 Id { get; set; }
        public Int32 NroVenta { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Tipo { get; set; }
        public Decimal TotalVenta { get; set; }

        public Int32 IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public String RucDniCliente { get; set; }

        public List<VentaPasaje> VentaPasajes { get; set; }
        public List<VentaEncomienda> VentaEncomiendas { get; set; }
        public List<Reserva> Reseras { get; set; }
    }
}

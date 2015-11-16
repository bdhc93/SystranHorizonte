using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Vehiculo
    {
        public Vehiculo()
        {
            this.VentaAsientoss = new List<VentaAsientos>();
        }

        public Int32 Id { get; set; }
        public String TarjetaPropiedad { get; set; }
        public String NroPlaca { get; set; }
        public DateTime FechaSoat { get; set; }
        public DateTime FechaSoatFin { get; set; }
        public DateTime FechaRevisionTecnica { get; set; }
        public DateTime FechaRevisionTecnicaFin { get; set; }
        public Decimal Ancho { get; set; }
        public Decimal Largo { get; set; }
        public Int32 Asientos { get; set; }
        public Int32 Tipo { get; set; }

        public String AnchoText { get; set; }
        public String LargoText { get; set; }

        public Boolean Estado { get; set; }

        public String EstadoMostrar { get { if (!Estado) return "Inactivo"; return "Activo"; } }

        public List<VentaAsientos> VentaAsientoss { get; set; }
    }
}

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

        public String FechaSoatMostrar { get { return FechaSoat.Day+"/"+FechaSoat.Month+"/"+FechaSoat.Year; } }
        public String FechaSoatFinMostrar { get { return FechaSoatFin.Day + "/" + FechaSoatFin.Month + "/" + FechaSoatFin.Year; } }
        public String FechaRevisionTecnicaMostrar { get { return FechaRevisionTecnica.Day + "/" + FechaRevisionTecnica.Month + "/" + FechaRevisionTecnica.Year; } }
        public String FechaRevisionTecnicaFinMostrar { get { return FechaRevisionTecnicaFin.Day + "/" + FechaRevisionTecnicaFin.Month + "/" + FechaRevisionTecnicaFin.Year; } }
        
        public Decimal Ancho { get; set; }
        public Decimal Largo { get; set; }
        public Int32 Asientos { get; set; }
        public Int32 Tipo { get; set; }
        public Decimal CargaMax { get; set; }
        public Decimal CargaActual { get; set; }

        public String AnchoText { get; set; }
        public String LargoText { get; set; }

        public Boolean Estado { get; set; }

        public String EstadoMostrar { get { if (!Estado) return "Inactivo"; return "Activo"; } }

        public List<VentaAsientos> VentaAsientoss { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Horario
    {
        public Horario()
        {
            this.VentaPasajes = new List<VentaPasaje>();
            this.VentaEncomiendas = new List<VentaEncomienda>();
            this.VentaAsientoss = new List<VentaAsientos>();
            this.Reservas = new List<Reserva>();
        }

        public Int32 Id { get; set; }
        public DateTime Hora { get; set; }
        public Decimal Costo { get; set; }

        public Int32 Asientos { get; set; }

        public Int32 OrigenId { get; set; }
        public Estacion EstacionOrigen { get; set; }

        public Int32 DestinoId { get; set; }
        public Estacion EstacionDestino { get; set; }

        public Int32 EmpleadoId { get; set; }
        public Empleado Empleados { get; set; }

        public Boolean Estado { get; set; }

        public List<VentaPasaje> VentaPasajes { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<VentaEncomienda> VentaEncomiendas { get; set; }
        public List<VentaAsientos> VentaAsientoss { get; set; }
    }
}

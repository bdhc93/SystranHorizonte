using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class VentaAsientos
    {
        public Int32 Id { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Asiento { get; set; }
        public Boolean Libre { get; set; }
        public Boolean Falsa { get; set; }
        public Int32 IdVentaTemp { get; set; }

        public Int32 IdHorario { get; set; }
        public Horario Horario { get; set; }

        public Int32 IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}

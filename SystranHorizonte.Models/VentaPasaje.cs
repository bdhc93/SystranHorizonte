using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class VentaPasaje
    {
        public Int32 Id { get; set; }
        public Decimal Pago { get; set; }
        public Int32 Asiento { get; set; }

        public Int32 IdHorario { get; set; }
        public Horario Horario { get; set; }

        public Int32 IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public Int32 IdCarga { get; set; }
        public Carga Carga { get; set; }
        public Decimal CargaPasaje { get; set; }

        public Int32? IdVenta { get; set; }
        public Venta Venta { get; set; }

        public Int32 IdClienteTemp { get; set; }

        public String DniRucClienteTemp { get; set; }

        public String NombreClienteTemp { get; set; }

        public String ApellidosClienteTemp { get; set; }
        public String DireccionClienteTemp { get; set; }
        public String TelefonoClienteTemp { get; set; }
    }
}

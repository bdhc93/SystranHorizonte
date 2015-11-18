﻿using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class Reserva
    {
        public Int32 Id { get; set; }
        public Decimal Pago { get; set; }
        public Int32 Asiento { get; set; }
        public Decimal ACuenta { get; set; }

        public Int32 IdHorario { get; set; }
        public Horario Horario { get; set; }

        public Int32 IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public Int32 IdCarga { get; set; }
        public Carga Carga { get; set; }
        public Decimal CargaReserva { get; set; }

        public Int32? IdVenta { get; set; }
        public Venta Venta { get; set; }
    }
}

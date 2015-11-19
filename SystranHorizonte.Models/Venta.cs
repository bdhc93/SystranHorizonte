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
        public Int32 Estado { get; set; }

        public String EstadoMostrar { get
            {
                if (Estado == 1)
                {
                    return "Compra satisfactoria";
                }
                else if (Estado == 2)
                {
                    return "Reserva por Pagar";
                }
                else if (Estado == 3)
                {
                    return "Reserva Pagada";
                }
                else if (Estado == 5)
                {
                    return "Preparando Envio";
                }
                else if (Estado == 6)
                {
                    return "Encomienda Finalizada";
                }
                else
                {
                    return "Sin Informacion";
                }
            }
        }

        public Int32 IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public Decimal TotalCarga { get; set; }

        public String RucDniCliente { get; set; }

        public List<VentaPasaje> VentaPasajes { get; set; }
        public List<VentaEncomienda> VentaEncomiendas { get; set; }
        public List<Reserva> Reseras { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SystranHorizonte.Models
{
    public class VentaEncomienda
    {
        public Int32 Id { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public Decimal Pago { get; set; }

        public Int32 IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public Int32 IdCarga { get; set; }
        public Carga Carga { get; set; }
        public Decimal CargaEncomienda { get; set; }

        public Int32 IdHorario { get; set; }
        public Horario Horario { get; set; }

        public Int32 Estado { get; set; }

        public String FechaRecepcionText
        {
            get
            {
                try
                {
                    if (Int32.Parse(FechaRecepcion.ToString().Substring(11, 2)) <= 12)
                    {
                        return FechaRecepcion.ToString().Substring(11, 5) + " AM";
                    }
                    else
                    {
                        var temp = Int32.Parse(FechaRecepcion.ToString().Substring(11, 2)) - 12;
                        if (temp < 10)
                        {
                            return "0" + temp + "" + FechaRecepcion.ToString().Substring(13, 3) + " PM";
                        }
                        return temp + "" + FechaRecepcion.ToString().Substring(13, 3) + " PM";
                    }
                }
                catch (Exception)
                {
                    return "0" + FechaRecepcion.ToString().Substring(11, 4) + " AM";
                }


            }
        }

        public String EstadoMostrar { get {

                if (Estado == 1)
                {
                    return "Preparando El envio";
                } else if (Estado == 2)
                {
                    return "Enviado";
                } else if (Estado == 3)
                {
                    return "Esperando Recojo";
                } else if (Estado == 4)
                {
                    return "Recogido";
                }
                else
                {
                    return "Sin Informacion";
                }} }

        public Int32? IdVenta { get; set; }
        public Venta Venta { get; set; }

        public String Descripcion { get; set; }

        public Int32 IdClienteTemp { get; set; }

        public String DniRucClienteTemp { get; set; }

        public String NombreClienteTemp { get; set; }

        public String ApellidosClienteTemp { get; set; }
        public String DireccionClienteTemp { get; set; }
        public String TelefonoClienteTemp { get; set; }
    }
}

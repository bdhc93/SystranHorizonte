using System;

namespace SystranHorizonte.Models
{
    public class DatosReportVentaComprobante
    {
        public String DniRuc { get; set; }
        public String Apellidos { get; set; }
        public String OrigenId { get; set; }
        public String DestinoId { get; set; }
        public String Hora { get; set; }
        public String Asiento { get; set; }
        public Decimal Pago { get; set; }
    }
}

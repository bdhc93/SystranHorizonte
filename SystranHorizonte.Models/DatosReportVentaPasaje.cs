using System;

namespace SystranHorizonte.Models
{
    public class DatosReportVentaPasaje
    {
        public String DniRuc { get; set; }
        public String Nombre { get; set; }
        public String OrigenId { get; set; }
        public String DestinoId { get; set; }
        public String Hora { get; set; }
        public String Asiento { get; set; }
        public Decimal Costo { get; set; }
    }
}

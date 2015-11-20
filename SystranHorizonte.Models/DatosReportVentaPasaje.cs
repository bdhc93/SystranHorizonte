using System;

namespace SystranHorizonte.Models
{
    public class DatosReportVentaPasaje
    {
        public String NroVenta { get; set; }
        public String Fecha { get; set; }
        public String Id { get; set; }
        public String TotalVenta { get; set; }
        public String DniRuc { get; set; }
        public String Nombre { get; set; }
        public String OrigenId { get; set; }
        public String DestinoId { get; set; }
        public String Hora { get; set; }
        public Decimal Pago { get; set; }
    }
}

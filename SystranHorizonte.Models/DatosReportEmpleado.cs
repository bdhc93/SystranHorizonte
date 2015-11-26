using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystranHorizonte.Models
{
    public class DatosReportEmpleado
    {
        public Int32 id { get; set; }
        public String Fecha { get; set; }
        public String Hora { get; set; }
        public Int32 IdHorario { get; set; }
        public String NroPlaca { get; set; }
        public String TarjetaPropiedad { get; set; }
        public Int32 IdVehiculo { get; set; }
        public Int32 IdOrigen { get; set; }
        public Int32 IdDestino { get; set; }
        public String OrigenId { get; set; }
        public String DestinoId { get; set; }
    }
}

using System;

namespace SystranHorizonte.Models
{
    public class RegUsuarios
    {
        public Int32 Id { get; set; }
        public String Usuario { get; set; }

        public String Modulo { get; set; }
        public String Cambio { get; set; }
        public Int32 IdModulo { get; set; }
    }
}

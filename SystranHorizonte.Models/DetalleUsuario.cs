using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystranHorizonte.Models
{
    public class DetalleUsuario
    {
        public Int32 Id { get; set; }
        public Int32 IdAccount { get; set; }
        public Account Account { get; set; }
        public Int32 IdRol { get; set; }
        public Roles Roles { get; set; }
    }
}

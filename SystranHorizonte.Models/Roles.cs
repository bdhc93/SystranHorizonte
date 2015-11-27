using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystranHorizonte.Models
{
    public class Roles
    {
        public Roles()
        {
            this.DetalleUsuarios = new List<DetalleUsuario>();
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Comentario { get; set; }

        public List<DetalleUsuario> DetalleUsuarios { get; set; }
    }
}

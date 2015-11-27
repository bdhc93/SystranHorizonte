using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystranHorizonte.Models
{
    public class Account
    {
        public Account()
        {
            this.DetalleUsuarios = new List<DetalleUsuario>();
        }

        public Int32 Id { get; set; }
        public String Usuario { get; set; }
        public String Contrasenia { get; set; }
        public String Email { get; set; }
        public Boolean Recuerdame { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }

        public List<DetalleUsuario> DetalleUsuarios { get; set; }
    }
}

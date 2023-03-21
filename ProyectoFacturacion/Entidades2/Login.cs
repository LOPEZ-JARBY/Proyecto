using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades2
{
   public class Login
    {
        public string CodigoUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }

        public Login()
        {
        }

        public Login(string codigoUsuario, string contrasena, string rol)
        {
            CodigoUsuario = codigoUsuario;
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}

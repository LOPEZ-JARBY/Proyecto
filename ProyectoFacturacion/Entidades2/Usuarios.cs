using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades2
{
   public class Usuarios
    {
        public String CodigoUsuario { get; set; }
        public String Nombre { get; set; }
        public String Contrasena{ get; set; }
        public String Correo{ get; set; }
        public String Rol { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(string codigoUsuario, string nombre, string contrasena, string correo, string rol, byte[] foto, DateTime fechaCreacion, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Contrasena = contrasena;
            Correo = correo;
            Rol = rol;
            Foto = foto;
            FechaCreacion = fechaCreacion;
            EstaActivo = estaActivo;
        }
    }
}

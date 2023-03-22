using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades2
{
    public class Productos
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public byte[] Foto { get; set; }

        public Productos()
        {
        }

        public Productos(string codigo, string descripcion, int existencia, decimal precio, byte[] foto)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Existencia = existencia;
            Precio = precio;
            Foto = foto;
        }
    }
}

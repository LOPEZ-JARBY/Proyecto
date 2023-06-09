﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades2
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EstaActivo { get; set; }

        public Clientes()
        {
        }

        public Clientes(string identidad, string nombre, string telefono, string correo, string direccion, DateTime fechaNacimiento, bool estaActivo)
        {
            Identidad = identidad;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            EstaActivo = estaActivo;
        }
    }
}

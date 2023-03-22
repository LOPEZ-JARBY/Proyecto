using Entidades2;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos2
{
    public class ClientesDB
    {

        string cadena = "server=localhost; user=root; database=proyectofacturacion; password=Pass.Zij4m2023;";

        public bool Insertar(Clientes clientes)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO clientes VALUES ");
                sql.Append(" (@Identidad, @Nombre, @Telefono, @Correo, @Direccion, @FechaNacimiento, @EstaActivo); ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 30).Value = clientes.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 30).Value = clientes.Nombre;
                        comando.Parameters.Add("@Telefono", MySqlDbType.VarChar, 45).Value = clientes.Telefono;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = clientes.Correo;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 100).Value = clientes.Direccion;
                        comando.Parameters.Add("@FechaNacimiento", MySqlDbType.DateTime).Value = clientes.FechaNacimiento;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit).Value = clientes.EstaActivo;
                        comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return inserto;

        }

        public bool Editar(Clientes clientes)
        {
            bool edito = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE clientes SET ");
                sql.Append(" (@Id,@Identidad, @Nombre, @Telefono, @Correo, @Direccion, @FechaNacimiento, @EstaActivo); ");
                sql.Append(" WHERE Id = @Id; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", MySqlDbType.Int32).Value = clientes.Id;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 30).Value = clientes.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 30).Value = clientes.Nombre;
                        comando.Parameters.Add("@Telefono", MySqlDbType.VarChar, 45).Value = clientes.Telefono;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 100).Value = clientes.Correo;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 20).Value = clientes.Direccion;
                        comando.Parameters.Add("@FechaNacimiento", MySqlDbType.DateTime).Value = clientes.FechaNacimiento;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit).Value = clientes.EstaActivo;
                        comando.ExecuteNonQuery();
                        edito = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return edito;
        }

        public bool Eliminar(string Id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM clientes ");
                sql.Append(" WHERE Id = @Id; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                        comando.ExecuteNonQuery();
                        elimino = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return elimino;
        }

        public DataTable DevolverClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM clientes ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }

    }
}

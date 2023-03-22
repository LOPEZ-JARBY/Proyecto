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
    public class ProductosDB
    {

        string cadena = "server=localhost; user=root; database=proyectofacturacion; password=Pass.Zij4m2023;";

        public bool Insertar(Productos productos)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO productos VALUES ");
                sql.Append(" (@Codigo, @Descripcion, @Existencia, @Precio, @Foto); ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 80).Value = productos.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 200).Value = productos.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = productos.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = productos.Precio;
                        comando.Parameters.Add("@Foto", MySqlDbType.LongBlob).Value = productos.Foto;
                        
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

        public bool Editar(Productos productos)
        {
            bool edito = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE productos SET ");
                sql.Append(" (@Codigo, @Descripcion, @Existencia, @Precio, @Foto); ");
                sql.Append(" WHERE Codigo = @Codigo; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 80).Value = productos.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 200).Value = productos.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = productos.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = productos.Precio;
                        comando.Parameters.Add("@Foto", MySqlDbType.LongBlob).Value = productos.Foto;
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

        public bool Eliminar(string Codigo)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM productos ");
                sql.Append(" WHERE Codigo = @Codigo; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = Codigo;
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

        public DataTable DevolverProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM productos ");
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

        public byte[] DevolverFoto(string Codigo)
        {
            byte[] foto = new byte[0];
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT Foto FROM productos WHERE Codigo = @Codigo;");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 80).Value = Codigo;
                        MySqlDataReader dr = comando.ExecuteReader();
                        if (dr.Read())
                        {
                            foto = (byte[])dr["Foto"];
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return foto;
        }


    }

}

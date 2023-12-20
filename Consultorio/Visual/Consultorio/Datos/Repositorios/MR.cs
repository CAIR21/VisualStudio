using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public abstract class MR:Repositorio
    {
        protected List<SqlParameter> parametros;
        protected int ExecuteNonQuery(string transactSql)
        {
            using (var conexion = ObtenerLaConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transactSql;
                    comando.CommandType = System.Data.CommandType.Text;
                    foreach(SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    int result = comando.ExecuteNonQuery();
                    parametros.Clear();
                    return result;
                }
            }
        }
        protected DataTable ExecuteReader(string transactSql)
        {
            using (var conexion = ObtenerLaConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transactSql;
                    comando.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }
        protected DataTable ExecuteReaderParam(string transactSql)
        {
            using (var conexion = ObtenerLaConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transactSql;
                    comando.CommandType = System.Data.CommandType.Text;
                    foreach(SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }
    }
}

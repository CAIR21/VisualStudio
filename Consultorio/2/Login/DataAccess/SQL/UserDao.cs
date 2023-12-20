using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun.Cache;

namespace DataAccess
{
    public class UserDao : Conexion
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Usuarios where Sesion=@user and Contra=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.UsuarioID = reader.GetString(0);
                            UserLoginCache.Sesion = reader.GetString(1);
                            UserLoginCache.Contra = reader.GetString(2);
                            UserLoginCache.NombreUsuario = reader.GetString(3);
                            UserLoginCache.Rango = reader.GetString(4);
                            UserLoginCache.CelularUsuario = reader.GetString(5);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public void anyMethod()
        {
            if (UserLoginCache.Rango == Permisos.Administrador)
            {
                //Metodos para el cargo de admin
            }
            if (UserLoginCache.Rango == Permisos.Doctor)
            {
                //Metodos para el cargo doc
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Comun.Cache;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public void anyMethod()
        {
            if (UserLoginCache.Rango == Permisos.Administrador)
            {
                //Metodos para el cargo de administrador
            }
            if (UserLoginCache.Rango == Permisos.Doctor)
            {
                //Metodos para el cargo de Doctor
            }
        }
    }
}

using System;
using System.Data;
using Escuela_DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL
{
    public class UsuarioBLL
    {
        public DataTable consultarUsuario(string nombre, string contra)
        {
            UsuarioDAL user = new UsuarioDAL();
            return user.consultarUsuario(nombre, contra);
        }
    }
}

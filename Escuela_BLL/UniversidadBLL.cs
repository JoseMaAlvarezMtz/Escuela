using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class UniversidadBLL
    {
        //FACULTADES
        public DataTable CargarUniversidades()
        {
            UniversidadDAL universidad = new UniversidadDAL();
            return universidad.CargarUniversidades();

        }
    }
}

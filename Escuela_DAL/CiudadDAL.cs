using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class CiudadDAL
    {
        ESCUELAEntities modelo;

        public CiudadDAL()
        {
            modelo = new ESCUELAEntities();
        }

        public List<Ciudad> cargarCiudadporEstado(int Estado)
        {
            var Ciudades = from mCiudades in modelo.Ciudad
                           where mCiudades.estado == Estado
                           select mCiudades;

            return Ciudades.ToList();
        }
    }
}

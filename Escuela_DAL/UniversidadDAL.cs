using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UniversidadDAL
    {
        ESCUELAEntities modelo;
        //FACULTADES
        public UniversidadDAL()
        {
            modelo = new ESCUELAEntities();
        }
        public List<UNIVERSIDADD> CargarUniversidades()
        {
            var Universidades = from mUniversidades in modelo.UNIVERSIDADD
                                select mUniversidades;

            return Universidades.ToList();
        }
    }
}

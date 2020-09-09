using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class PaisDAL
    {
        ESCUELAEntities modelo;
        
        public PaisDAL()
        {
            modelo = new ESCUELAEntities();
        }

        public List<Pais> CargarPaises()
        {
            var Pais = from mPais in modelo.Pais
                       select mPais;

            return Pais.ToList();
        }
    }
}

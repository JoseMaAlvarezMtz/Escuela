using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class EstadoDAL
    {
        ESCUELAEntities modelo;

        public EstadoDAL()
        {
            modelo = new ESCUELAEntities();
        }
        public List<Estado> cargarEstadoporPais(int Pais)
        {
            var Estado = from mEstado in modelo.Estado
                         where mEstado.pais == Pais
                         select mEstado;

            return Estado.ToList();
        }
    }
}

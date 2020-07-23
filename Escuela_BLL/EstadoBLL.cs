using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class EstadoBLL
    {
        public DataTable cargarEstadoporPais(int Pais)
        {
            EstadoDAL Estado = new EstadoDAL();
            return Estado.cargarEstadoporPais(Pais);
        }
    }
}

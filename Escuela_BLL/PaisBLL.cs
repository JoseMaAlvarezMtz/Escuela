using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class PaisBLL
    {
        public List<Pais> CargarPaises()
        {
            PaisDAL PAIS = new PaisDAL();
            return PAIS.CargarPaises();
        }
    }
}

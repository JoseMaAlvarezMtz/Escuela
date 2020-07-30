using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class MateriaBLL
    {
        public List<Materia> CargarMaterias()
        {
            MateriaDAL Materia = new MateriaDAL();
            return Materia.CargarMaterias();
        }
    }
}

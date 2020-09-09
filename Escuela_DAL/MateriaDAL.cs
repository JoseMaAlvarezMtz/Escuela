using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaDAL
    {
        ESCUELAEntities modelo;

        public MateriaDAL()
        {
            modelo = new ESCUELAEntities();

        }

        public List<Materia> CargarMaterias()
        {
            var Materias = from mMaterias in modelo.Materia
                           select mMaterias;

            return Materias.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
namespace Escuela_BLL
{
    public class MateriaFacultadBLL
    {
        public void agregarMateriaFacultad (MateriaFacultad pFacultad)
        {
            MateriaFacultadDAL Materia = new MateriaFacultadDAL();
            Materia.agregarMateriaFacultad(pFacultad);
        }

        public void eliminarMaterias(int ID_Facultad)
        {
            MateriaFacultadDAL materia = new MateriaFacultadDAL();
            materia.eliminarMaterias(ID_Facultad);
        }
    }
}

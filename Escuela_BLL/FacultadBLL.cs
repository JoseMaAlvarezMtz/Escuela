using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        //ALUMNOS
        public DataTable CargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.CargarFacultades();

        }

        //FACULTADES
        public int consultar()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.consultar();
        }

        public List<object> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public void AgregarFacultad(FACULTADD Facultad, List<MateriaFacultad> materiaFacultades)
        {
            FacultadDAL facultad = new FacultadDAL();
            FACULTADD registro = new FACULTADD();
            MateriaFacultadBLL materias = new MateriaFacultadBLL();
            
            registro = facultad.buscarFacultad(Facultad.codigo);

            if (registro != null)
            {
                throw new Exception("Codigo de Facultad ya existe favor de ingresar uno diferente.");
            }
            else
            {
                int tiempo = Facultad.fechaCreacion.Year;
                if (tiempo <= 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900”.");
                }
                else
                {
                    if( tiempo >= 2010)
                    {
                        throw new Exception("Fecha no permitida, introduce una fecha menor a 2010”.");
                    }
                    else
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            facultad.AgregarFacultad(Facultad);

                            foreach(MateriaFacultad materia in materiaFacultades)
                            {
                                materias.agregarMateriaFacultad(materia);
                            }

                            ts.Complete();
                        }
                            
                    }
                }
            }

        }

        public FACULTADD cargarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(ID_Facultad);
        }

        public void ModificarFacultad(FACULTADD pFacultad, List<MateriaFacultad> materiaFacultades)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL materia = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                facultad.ModificarFacultad(pFacultad);

                materia.eliminarMaterias(pFacultad.ID_Facultad);

                foreach(MateriaFacultad nmaterias in materiaFacultades)
                {
                    materia.agregarMateriaFacultad(nmaterias);
                }

                ts.Complete();
            }
            
        }
        public void eliminarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL materia = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                materia.eliminarMaterias(ID_Facultad);
                facultad.eliminarFacultad(ID_Facultad);

                ts.Complete();
            }
            
        }
    }
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

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
        public List<object> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public void AgregarFacultad(FACULTADD Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            FACULTADD registro = new FACULTADD();

            
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
                        facultad.AgregarFacultad(Facultad);
                    }
                }
            }

        }

        public FACULTADD cargarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(ID_Facultad);
        }

        public void ModificarFacultad(FACULTADD pFacultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.ModificarFacultad(pFacultad);
        }
        public void eliminarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.eliminarFacultad(ID_Facultad);
        }
    }
}

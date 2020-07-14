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
        public DataTable cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }

        public void AgregarFacultad(string codigo, string nombre, DateTime fecha, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.AgregarFacultad(codigo, nombre, fecha, universidad);
        }

        public DataTable cargarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(ID_Facultad);
        }

        public void ModificarFacultad(int ID_Facultad,string codigo, string nombre, DateTime fecha, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.ModificarFacultad(ID_Facultad, codigo, nombre, fecha, universidad);
        }
        public void eliminarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.eliminarFacultad(ID_Facultad);
        }
    }
}

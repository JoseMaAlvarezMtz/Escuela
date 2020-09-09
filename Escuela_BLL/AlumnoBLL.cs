using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {
        public DataTable cargarAlumnos()
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos();
        }

        public void AgregarAlumno(int matricula, string nombre, DateTime fecha, int semestre, int facultad)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            DataTable dtAlumno = new DataTable();
            dtAlumno = cargarAlumno(matricula);
            if(dtAlumno.Rows.Count > 0)
            {
                throw new Exception("La matricula ya existe en la base de datos");
            }
            else
            {
                int edad = DateTime.Now.Year - fecha.Year;
                if (edad >= 80)
                {
                    throw new Exception("El alumno es muy viejo, ingrese otra fecha");
                }
                else
                {
                    alumno.AgregarAlumno(matricula, nombre, fecha, semestre, facultad);
                }
                
            }
            
        }

        public DataTable cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }

        public void ModificarAlumno(int matricula, string nombre, DateTime fecha, int semestre, int facultad)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.ModificarAlumno(matricula, nombre, fecha, semestre, facultad);
        }

        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.eliminarAlumno(matricula);
        }
    }
    
}

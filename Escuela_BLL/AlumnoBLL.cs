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
            alumno.AgregarAlumno(matricula,nombre,fecha,semestre,facultad);
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

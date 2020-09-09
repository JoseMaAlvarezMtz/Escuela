using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class AlumnoDAL
    {
        ESCUELAEntities modelo;

        public AlumnoDAL()
        {
            modelo = new ESCUELAEntities();
        }

        public DataTable cargarAlumnos()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumno";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumnos = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumnos);

            connection.Close();
            return dtAlumnos;
        }

        public void AgregarAlumno(int matricula, string nombre, DateTime fecha, int semestre, int facultad)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_agregarAlumno";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fecha);
            command.Parameters.AddWithValue("pSemestre", semestre);
            command.Parameters.AddWithValue("pFacultad", facultad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public DataTable cargarAlumno(int matricula)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumnoPorMatricula";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumnos = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumnos);

            connection.Close();
            
            return dtAlumnos;
        }

        public void ModificarAlumno(int matricula, string nombre, DateTime fecha, int semestre, int facultad)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_ModificarAlumno";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fecha);
            command.Parameters.AddWithValue("pSemestre", semestre);
            command.Parameters.AddWithValue("pFacultad", facultad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void eliminarAlumno(int matricula)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarAlumno";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}

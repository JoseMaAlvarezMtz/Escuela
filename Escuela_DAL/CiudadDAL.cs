using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class CiudadDAL
    {
        public DataTable cargarCiudadporEstado(int Estado)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_CargarCiudadporEstado";
            command.Connection = connection;

            command.Parameters.AddWithValue("pEstado", Estado);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudad = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudad);

            connection.Close();

            return dtCiudad;
        }
    }
}

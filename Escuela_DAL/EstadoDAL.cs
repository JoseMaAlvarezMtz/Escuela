using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class EstadoDAL
    {
        public DataTable cargarEstadoporPais(int Pais)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_CargarEstadoporPais";
            command.Connection = connection;

            command.Parameters.AddWithValue("pPais", Pais);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEstado = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtEstado);

            connection.Close();

            return dtEstado;
        }
    }
}

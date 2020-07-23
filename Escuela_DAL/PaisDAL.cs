using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class PaisDAL
    {
        public DataTable CargarPaises()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_CargarPaises";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtPaises = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtPaises);

            connection.Close();
            return dtPaises;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UsuarioDAL
    {
        public DataTable consultarUsuario(string nombre, string contra)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = connection;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContra", contra);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            connection.Close();
            return dtUsuario;
        }
    }
}

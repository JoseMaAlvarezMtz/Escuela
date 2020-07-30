using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        ESCUELAEntities Modelo;

        public FacultadDAL()
        {
            Modelo = new ESCUELAEntities();
        }
        //ALUMNOS
        public DataTable CargarFacultades()
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=LENOVO-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultades";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultades);

            connection.Close();

            return dtFacultades;
        }
        //FACULTADES
        public int consultar()
        {
            try
            {
                using (ESCUELAEntities db = new ESCUELAEntities())
                {
                    var ID = db.FACULTADD.OrderByDescending(f => f.ID_Facultad).FirstOrDefault();

                    return ID.ID_Facultad;
                }
            }
            catch (Exception ex)
            {
                return 0; 
            }
            
        }
        public List<object> cargarFacultades()
        {
            var alumnos = from mFacultades in Modelo.FACULTADD
                          select new
                          {
                              ID_Facultad = mFacultades.ID_Facultad,
                              codigo = mFacultades.codigo,
                              nombre = mFacultades.nombre,
                              fechaCreacion = mFacultades.fechaCreacion,
                              universidad = mFacultades.UNIVERSIDADD.nombre,
                              ciudad = mFacultades.Ciudad1.ciudad1
                          };
            return alumnos.AsEnumerable<object>().ToList();
        }

        public void AgregarFacultad(FACULTADD facultad)
        {
            Modelo.FACULTADD.Add(facultad);
            Modelo.SaveChanges();
        }

        public FACULTADD cargarFacultad(int ID_Facultad)
        {
            var Facultad = (from mFacultad in Modelo.FACULTADD
                            where mFacultad.ID_Facultad == ID_Facultad
                            select mFacultad).FirstOrDefault();
            return Facultad;

        }

        public FACULTADD buscarFacultad(string codigo)
        {
            var Facultad = (from mFacultad in Modelo.FACULTADD
                            where mFacultad.codigo == codigo
                            select mFacultad).FirstOrDefault();
            return Facultad;
        }

        public void ModificarFacultad(FACULTADD facultad)
        {
            var Facultad = (from mFacultad in Modelo.FACULTADD
                            where mFacultad.ID_Facultad == facultad.ID_Facultad
                            select mFacultad).FirstOrDefault();

            Facultad.nombre = facultad.nombre;
            Facultad.universidad = facultad.universidad;
            Facultad.fechaCreacion = facultad.fechaCreacion;
            Facultad.ciudad = facultad.ciudad;
            Facultad.codigo = facultad.codigo;

            Modelo.SaveChanges();
        }

        public void eliminarFacultad(int ID_Facultad)
        {
            var Facultad = (from mFacultad in Modelo.FACULTADD
                            where mFacultad.ID_Facultad == ID_Facultad
                            select mFacultad).FirstOrDefault();

            Modelo.FACULTADD.Remove(Facultad);
            Modelo.SaveChanges();
        }
    }
}

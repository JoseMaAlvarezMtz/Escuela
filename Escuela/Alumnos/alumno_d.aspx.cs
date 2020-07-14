using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Alumnos
{
    public partial class alumno_d : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int matricula = int.Parse(Request.QueryString["pMatricula"]);
                CargarFacultades();
                cargarAlumno(matricula);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno eliminado exitosamente')", true);
        }
        #endregion

        #region Metodos
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumno = new AlumnoBLL();
            DataTable dtAlumnos = new DataTable();
            dtAlumnos = alumno.cargarAlumno(matricula);
            
            lblMatricula.Text = dtAlumnos.Rows[0]["matricula"].ToString();
            lblNombre.Text = dtAlumnos.Rows[0]["nombre"].ToString();
            lblFecha.Text = dtAlumnos.Rows[0]["fechaNAcimiento"].ToString().Substring(0, 10);
            lblSemestre.Text = dtAlumnos.Rows[0]["semestre"].ToString();
            ddlFacultad.SelectedValue = dtAlumnos.Rows[0]["facultad"].ToString();

        }


        public void CargarFacultades()
        {
            FacultadBLL facultad = new FacultadBLL();
            DataTable dtFacultades = new DataTable();
            dtFacultades = facultad.CargarFacultades();
            
            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("--Seleccione una Facultad--", "0"));
        }

        public void eliminarAlumno()
        {
            AlumnoBLL alumno = new AlumnoBLL();
            int matricula = int.Parse(lblMatricula.Text );
            alumno.eliminarAlumno(matricula);
        }
        #endregion
    }
}
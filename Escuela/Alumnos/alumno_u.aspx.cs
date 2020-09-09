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
    public partial class alumno_u : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    CargarFacultades();
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno modificado exitosamente')", true);
        }

        #endregion

        #region Metodos

        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumno = new AlumnoBLL();
            DataTable dtAlumnos = new DataTable();
            dtAlumnos = alumno.cargarAlumno(matricula);

            lblMatricula.Text = dtAlumnos.Rows[0]["matricula"].ToString();
            txtNombre.Text = dtAlumnos.Rows[0]["nombre"].ToString();
            txtFechaNacimiento.Text = dtAlumnos.Rows[0]["fechaNAcimiento"].ToString().Substring(0, 10);
            txtSemestre.Text = dtAlumnos.Rows[0]["semestre"].ToString();
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

        public void ModificarAlumno()
        {
            AlumnoBLL alumno = new AlumnoBLL();

            int matricula= int.Parse(lblMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);

            alumno.ModificarAlumno(matricula, nombre, fecha, semestre, facultad);
        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


    }
}
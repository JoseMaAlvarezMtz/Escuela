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
    public partial class alumno_i : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFacultades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente')", true);

        }
        #endregion
        #region Metodos
        public void AgregarAlumno()
        {
            AlumnoBLL alumno = new AlumnoBLL();
            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);

            alumno.AgregarAlumno(matricula, nombre, fecha, semestre, facultad);
        }

        public void CargarFacultades()
        {
            FacultadBLL facultad = new FacultadBLL();
            DataTable dtFacultades = new DataTable();
            dtFacultades = facultad.CargarFacultades();
            ddlFacultad.DataSource=dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("--Seleccione una Facultad--", "0"));
        }


        #endregion

        
    }
}
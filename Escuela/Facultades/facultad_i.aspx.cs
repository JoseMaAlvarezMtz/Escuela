using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Facultades
{
    public partial class facultad_i : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUniversidades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad agregado exitosamente')", true);

        }
        #endregion
        #region Metodos
        public void AgregarFacultad()
        {
            FacultadBLL Facultad = new FacultadBLL();
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);

            Facultad.AgregarFacultad(codigo, nombre, fecha, universidad);
        }

        public void CargarUniversidades()
        {
        
            UniversidadBLL universidad = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();
            dtUniversidades = universidad.CargarUniversidades();
            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem("--Seleccione una Universidad--", "0"));
        }


        #endregion
    }
}
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
    public partial class facultad_i : System.Web.UI.Page, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    CargarUniversidades();
                    cargarTabla();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
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
            try
            {
                Facultad.AgregarFacultad(codigo, nombre, fecha, universidad);
                limpirCampos();
                DataTable dtFacultades = new DataTable();
                dtFacultades = (DataTable)ViewState["Tabla Facultad"];

                dtFacultades.Rows.Add(codigo, nombre);

                grvFacultades.DataSource = dtFacultades;
                grvFacultades.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('"+ex.Message+"')", true);
            }
            
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

        public void limpirCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtFecha.Text = "";
            ddlUniversidad.SelectedIndex = 0;
        }

        public void cargarTabla()
        {
            DataTable Table = new DataTable();
            Table.Columns.Add("Codigo");
            Table.Columns.Add("Nombre");
           
            ViewState["Tabla Facultad"] = Table;
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
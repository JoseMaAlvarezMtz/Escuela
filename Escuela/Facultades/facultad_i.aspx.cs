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
    public partial class facultad_i : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    CargarUniversidades();
                    cargarPais();
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

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPais.SelectedIndex != 0)
            {
                ddlEstado.Items.Clear();
                cargarEstados();
            }
            else
            {
                ddlEstado.Items.Clear();
            }
            
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedIndex != 0)
            {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            }
            else
            {
                ddlCiudad.Items.Clear();
            }
            
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

        public void cargarPais()
        {
            PaisBLL Pais = new PaisBLL();
            DataTable dtPais = new DataTable();

            dtPais = Pais.CargarPaises();
            ddlPais.DataSource = dtPais;
            ddlPais.DataTextField = "Pais";
            ddlPais.DataValueField = "ID_Pais";
            ddlPais.DataBind();

            ddlPais.Items.Insert(0, new ListItem("---Seleccionar Pais---", "0"));
        }

        public void cargarEstados()
        {
            EstadoBLL Estado = new EstadoBLL();
            DataTable dtEstado = new DataTable();

            dtEstado = Estado.cargarEstadoporPais(int.Parse(ddlPais.SelectedValue));
            ddlEstado.DataSource = dtEstado;
            ddlEstado.DataTextField = "estado";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem("---Seleccionar Estado---", "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL Ciudad = new CiudadBLL();
            DataTable dtCiudad = new DataTable();

            dtCiudad = Ciudad.cargarCiudadporEstado(int.Parse(ddlEstado.SelectedValue));
            ddlCiudad.DataSource = dtCiudad;
            ddlCiudad.DataTextField = "ciudad";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("---Seleccionar Ciudad---", "0"));
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
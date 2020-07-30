using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

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
                ddlCiudad.Items.Clear();
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
            FACULTADD pFacultad = new FACULTADD();
            FacultadBLL Facultad = new FacultadBLL();

            pFacultad.codigo = txtCodigo.Text;
            pFacultad.nombre = txtNombre.Text;
            pFacultad.fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            pFacultad.universidad = int.Parse(ddlUniversidad.SelectedValue);
            pFacultad.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {
                Facultad.AgregarFacultad(pFacultad);
                limpirCampos();
                DataTable dtFacultades = new DataTable();
                dtFacultades = (DataTable)ViewState["Tabla Facultad"];

                dtFacultades.Rows.Add(pFacultad.codigo, pFacultad.nombre);

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
            List<UNIVERSIDADD> dtUniversidades = new List<UNIVERSIDADD>();
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
            List<Pais> dtPais = new List<Pais>();

            dtPais = Pais.CargarPaises();
            ddlPais.DataSource = dtPais;
            ddlPais.DataTextField = "Pais1";
            ddlPais.DataValueField = "ID_Pais";
            ddlPais.DataBind();

            ddlPais.Items.Insert(0, new ListItem("---Seleccionar Pais---", "0"));
        }

        public void cargarEstados()
        {
            EstadoBLL Estado = new EstadoBLL();
            List<Estado> dtEstado = new List<Estado>();

            dtEstado = Estado.cargarEstadoporPais(int.Parse(ddlPais.SelectedValue));
            ddlEstado.DataSource = dtEstado;
            ddlEstado.DataTextField = "estado1";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem("---Seleccionar Estado---", "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL Ciudad = new CiudadBLL();
            List<Ciudad> dtCiudad = new List<Ciudad>();

            dtCiudad = Ciudad.cargarCiudadporEstado(int.Parse(ddlEstado.SelectedValue));
            ddlCiudad.DataSource = dtCiudad;
            ddlCiudad.DataTextField = "ciudad1";
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
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela.Facultades
{
    public partial class facultad_d : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int ID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);
                    CargarUniversidades();
                    cargarFacultad(ID_Facultad);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
               
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            eliminarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad eliminado exitosamente')", true);
        }
        #endregion

        #region Metodos
        public void cargarFacultad(int ID_Facultad)
        {
            FacultadBLL facultad = new FacultadBLL();
            FACULTADD pFacultad = new FACULTADD();
            pFacultad = facultad.cargarFacultad(ID_Facultad);

            lblID_Facultad.Text = pFacultad.ID_Facultad.ToString();
            lblNombre.Text = pFacultad.nombre.ToString();
            lblFecha.Text = pFacultad.fechaCreacion.ToString().Substring(0, 10);
            lblCodigo.Text = pFacultad.codigo.ToString();
            ddlUniversidad.SelectedValue = pFacultad.universidad.ToString();

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

        public void eliminarFacultad()
        {
            FacultadBLL facultad = new FacultadBLL();
            int ID_Facultad = int.Parse(lblID_Facultad.Text);
            facultad.eliminarFacultad (ID_Facultad);
        }

        public bool sesionIniciada()
        {
            if(Session["Usuario"]!= null)
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
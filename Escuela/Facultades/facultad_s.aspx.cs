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
    public partial class facultad_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_Facultades.DataSource = cargarFacultades();
                    grd_Facultades.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
            }
        }

        protected void grd_Facultades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Facultades/facultad_u.aspx?pID_Facultad=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Facultades/facultad_d.aspx?pID_Facultad=" + e.CommandArgument);
            }
        }
        #endregion

        #region Metodos
        public List<object> cargarFacultades()
        {
           FacultadBLL facultad = new FacultadBLL();
            List<object> lFacultad = new List<object>();
            lFacultad = facultad.cargarFacultades();
            return lFacultad;
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
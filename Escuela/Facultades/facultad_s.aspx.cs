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
    public partial class facultad_s : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grd_Facultades.DataSource = cargarFacultades();
                grd_Facultades.DataBind();
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
        public DataTable cargarFacultades()
        {
           FacultadBLL facultad = new FacultadBLL();
            DataTable dtFacultad = new DataTable();
            dtFacultad = facultad.cargarFacultades();
            return dtFacultad;
        }

        #endregion

       
    }
}
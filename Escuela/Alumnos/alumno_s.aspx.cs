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
    public partial class WebForm1 : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_Alumnos.DataSource = cargarAlumnos();
                    grd_Alumnos.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
            }
        }

        protected void grd_Alumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Alumnos/alumno_u.aspx?pMatricula="+e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Alumnos/alumno_d.aspx?pMatricula="+e.CommandArgument);
            }
        }
        #endregion

        #region Metodos
        public DataTable cargarAlumnos()
        {
            AlumnoBLL alumno = new AlumnoBLL();
            DataTable dtAlumnos = new DataTable();
            dtAlumnos = alumno.cargarAlumnos();
            return dtAlumnos;
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
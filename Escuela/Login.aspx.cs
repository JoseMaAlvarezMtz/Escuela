using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela
{
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcceso_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Facultades/facultad_s.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('Usuario y/o contraseña incorrectos')", true);
            }
        }
        #endregion

        #region Metodos

        public bool usuarioValido()
        {
            bool validar = false;
            UsuarioBLL user = new UsuarioBLL();
            DataTable dtUser = new DataTable();
            dtUser = user.consultarUsuario(txtUsuario.Text, txtContra.Text);

            if (dtUser.Rows.Count > 0)
            {
                Session["Usuario"] = dtUser;
                validar = true;
            }
            return validar ;
        }

        #endregion
    }
}
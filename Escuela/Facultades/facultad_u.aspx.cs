﻿using System;
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
    public partial class facultad_u : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);
                CargarUniversidades();
                cargarFacultad(ID_Facultad);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad modificado exitosamente')", true);
        }

        #endregion

        #region Metodos

        public void cargarFacultad(int ID_Facultad)
        {
            FacultadBLL facultad = new FacultadBLL();
            DataTable dtFacultad = new DataTable();
            dtFacultad = facultad.cargarFacultad(ID_Facultad);

            lblID_Facultad.Text = dtFacultad.Rows[0]["ID_Facultad"].ToString();
            txtNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            txtFecha.Text = dtFacultad.Rows[0]["fechaCreacion"].ToString().Substring(0, 10);
            txtCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();

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

        public void ModificarFacultad()
        {
            FacultadBLL facultad = new FacultadBLL();

            int ID_Facultad = int.Parse(lblID_Facultad.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            string codigo = txtCodigo.Text;
            int Universidad = int.Parse(ddlUniversidad.SelectedValue);

            facultad.ModificarFacultad(ID_Facultad, codigo, nombre, fecha, Universidad);
        }
        #endregion
    }
}
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
    public partial class facultad_u : TemaEscuela, IAcceso
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
                    cargarPais();
                    CargarMaterias();
                    cargarFacultad(ID_Facultad);
                    cargarEstados();
                    cargarCiudades();
                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad modificado exitosamente')", true);
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPais.SelectedIndex != 0)
            {
                ddlEstado.Items.Clear();
                ddlCiudad.Items.Clear();
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

        public void cargarFacultad(int ID_Facultad)
        {
            FacultadBLL facultad = new FacultadBLL();
            FACULTADD lFacultad = new FACULTADD();
            lFacultad = facultad.cargarFacultad(ID_Facultad);

            lblID_Facultad.Text = lFacultad.ID_Facultad.ToString();
            txtNombre.Text = lFacultad.nombre.ToString();
            txtFecha.Text = lFacultad.fechaCreacion.ToString().Substring(0, 10);
            txtCodigo.Text = lFacultad.codigo.ToString();
            ddlUniversidad.SelectedValue = lFacultad.universidad.ToString();
            ddlPais.SelectedValue = lFacultad.Ciudad1.Estado1.pais.ToString();
            ddlEstado.SelectedValue = lFacultad.Ciudad1.estado.ToString();
            ddlCiudad.SelectedValue = lFacultad.ciudad.ToString();

            List<MateriaFacultad> listaMaterias = new List<MateriaFacultad>();
            listaMaterias = lFacultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacultad in listaMaterias)
            {
                ListBoxMaterias.Items.FindByValue(materiaFacultad.materia.ToString()).Selected = true;
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

        public void ModificarFacultad()
        {
            FacultadBLL facultad = new FacultadBLL();
            FACULTADD pFacultad = new FACULTADD();

            pFacultad.ID_Facultad = int.Parse(lblID_Facultad.Text);
            pFacultad.nombre = txtNombre.Text;
            pFacultad.fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            pFacultad.codigo = txtCodigo.Text;
            pFacultad.universidad = int.Parse(ddlUniversidad.SelectedValue);
            pFacultad.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {
                MateriaFacultad MateriaFacultad;
                List<MateriaFacultad> materiaFacultades = new List<MateriaFacultad>();

                foreach (ListItem item in ListBoxMaterias.Items)
                {
                    if (item.Selected)
                    {
                        MateriaFacultad = new MateriaFacultad();
                        MateriaFacultad.materia = int.Parse(item.Value);
                        MateriaFacultad.facultad = pFacultad.ID_Facultad;
                        materiaFacultades.Add(MateriaFacultad);
                    }
                }

                facultad.ModificarFacultad(pFacultad, materiaFacultades);
                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);
            }
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

        public void CargarMaterias()
        {
            MateriaBLL Materias = new MateriaBLL();
            List<Materia> dtFacultades = new List<Materia>();

            dtFacultades = Materias.CargarMaterias();
            ListBoxMaterias.DataSource = dtFacultades;
            ListBoxMaterias.DataTextField = "materia1";
            ListBoxMaterias.DataValueField = "ID_Materia";
            ListBoxMaterias.DataBind();
        }
        #endregion
    }
}
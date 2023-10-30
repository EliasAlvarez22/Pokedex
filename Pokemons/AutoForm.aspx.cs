using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class AutoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
                ddlColores.Items.Add("Rojo");
                ddlColores.Items.Add("Azul");
                ddlColores.Items.Add("Negro");
                ddlColores.Items.Add("Blanco");
            }

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Auto> temp = (List<Auto>)Session["listaAutos"];
                Auto seleccionado = temp.Find(x => x.Id == id);
                
                txtId.ReadOnly = true;
                txtId.Text = seleccionado.Id.ToString();
                txtDescripcion.Text = seleccionado.Descripcion;
                txtModelo.Text = seleccionado.Modelo;
                ddlColores.Text = seleccionado.Color;
                txtFecha.Text = seleccionado.Fecha.ToString();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();

            ValidarCampos();
            auto.Id = int.Parse(txtId.Text);
            auto.Modelo = txtModelo.Text;
            auto.Descripcion = txtDescripcion.Text;
            auto.Color = ddlColores.SelectedValue;
            auto.Fecha = DateTime.Parse(txtFecha.Text);
            auto.Usado = cbxUsado.Checked;

            if (rbnImportado.Checked)         
                auto.Importado = true;
            
            else if (rbnNacional.Checked)
                auto.Importado = false;

            List<Auto> temp = (List<Auto>)Session["listaAutos"];
            temp.Add(auto);

            Response.Redirect("Default.aspx");
        }

        private void ValidarCampos()
        {
            //throw new NotImplementedException();
        }        
    }
}
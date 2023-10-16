using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Pokemons
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_login_Click(object sender, EventArgs e)
        {
            Persona person = new Persona();

            if (ValidarCampos())            
                return;

            
            person.Nombre = txtNombre.Text;
            person.Edad = int.Parse(txtEdad.Text);

            Session.Add("nombre", person.Nombre);
            Session.Add("edad", person.Edad);

            Response.Redirect("About.aspx", false);
            
        }
        private bool ValidarCampos()
        {
            string campoNombre = txtNombre.Text;
            string campoEdad = txtEdad.Text;

            if (campoNombre == "")
            {                
                return true;
            }    
            if(campoEdad == "")
            {
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Pokemons
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }
        protected void Btn_login_Click(object sender, EventArgs e)
        {           
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Usuario user = new Usuario
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };
                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Profile.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }


            
        }
        private bool ValidarCampos()
        {
            string emailField = txtEmail.Text;
            string passwordField = txtPassword.Text;

            if (emailField == "")
            {
                return true;
            }
            if (passwordField == "")
            {
                return true;
            }
            return false;
        }
    }
}
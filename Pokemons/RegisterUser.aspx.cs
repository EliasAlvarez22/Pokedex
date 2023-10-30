using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (ValidarCampos())
                    return;
                //Si es verdadero significa que existe en la DB, no se puede registrar un email ya en uso.
                user.Email = txtEmail.Text;

                if (negocio.ValidarRegistroEmail(user.Email))
                {
                    lblValidacion.Text = "No puede registrarse ese email, está en uso.";
                   // lblEmail.Attributes["CssStyle"] = "border border-danger border-1";
                    //txtEmail.Attributes["CssStyle"] = "border border-danger border-1";

                    return;
                }

                ValidarContraseñas();

                user.Password = txtPassword.Text;
                Session.Add("user", user);

                negocio.RegisterUser(user);
                Response.Redirect("Profile.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", true);
                throw;
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
        private bool ValidarContraseñas()
        {

            return false;
        }
    }
}
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class Profile : Page
    {             
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario user = Session["user"] as Usuario != null ? Session["user"] as Usuario : null;
                
                if (user != null)
                {
                    lblEmail.Text += user.Email;
                    lblName.Text += user.Nombre;
                    if (user.Edad == 0)
                    {
                        lblOld.Text += "";
                    }
                    else
                    {
                        lblOld.Text += user.Edad;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", true);
                throw;
            } 
            

            
            /*
            if (Request.QueryString["user"]!= null)
            {
                lblTituloLogin.Text = "Ingresaste " + Request.QueryString["user"].ToString();
            }
            else
            {
                lblTituloLogin.Text = "Vaya a Login para ver el menu.";
            }
            */

            //lblEdad.Text += Edad.ToString();


        }
        
    }
}
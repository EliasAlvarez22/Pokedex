using Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                
                if(!Page.IsPostBack)
                {
                    //se recupera user de la session
                    Usuario user = Session["user"] as Usuario ?? null;
                    
                    //Carga de datos del user
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtEdad.Text = user.Edad == 0 ? "" : (user.Edad).ToString();                                                       
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
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

        protected void txtImagen_onchange(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = txtImagen.PostedFile.ToString();
        }
        
    }
}
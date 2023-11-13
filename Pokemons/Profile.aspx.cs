using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
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
                    Usuario user = (Usuario)Session["user"];                    
                    
                    //Carga de datos del user
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtEdad.Text = user.Edad == 0 ? "" : user.Edad.ToString();
                    imgPerfil.ImageUrl = user.ImagenPerfil != null ? "~/Images/Perfil/" + user.ImagenPerfil : "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";

                    txtFechaNac.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");

                    cbxAdmin.Checked = user.Admin;
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
        }
        protected void txtImagen_onchange(object sender, EventArgs e)
        {
            //imgPerfil.ImageUrl = txtImagen.PostedFile.ToString();
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {            
            try
            {
               
                //Guardado de datos
                Usuario user = (Usuario)Session["user"];
                user.Nombre = txtNombre.Text;
                user.Email = txtEmail.Text;

                user.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                if(txtImagen.PostedFile != null)
                {
                    //Se obtiene ruta de la carpeta de imagenes de perfil
                    string ruta = Server.MapPath("./Images/Perfil");
                    //Escribir img
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                    txtImagen.PostedFile.SaveAs(ruta + user.ImagenPerfil);
                    //Leer img
                    Image imgMaster = (Image)Master.FindControl("imgAvatar");
                    imgMaster.ImageUrl = "~/Images/Perfil/" + user.ImagenPerfil;
                    imgPerfil.ImageUrl = "~/Images/Perfil/" + user.ImagenPerfil;
                }                           
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.GuardarPerfil(user);

               

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
           

            
        }
    }
}
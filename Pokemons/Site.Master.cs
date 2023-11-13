using Dominio;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class SiteMaster : MasterPage
    {
        public Usuario Usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["user"]  ?? null;
            
            /*if (!(Page is Contact || Page is Error || Page is _Default || Page is Pokemons.Login || Page is RegisterUser && Seguridad.SesionActiva(Usuario)))
            {
                Session.Add("error", "Sin acceso a esta pagina.");
                Response.Redirect("Error.aspx", false);
            }*/


            if (Seguridad.SesionActiva(Usuario))
            {
                imgAvatar.ImageUrl = "~/Images/Perfil/"+ Usuario.ImagenPerfil ?? "~/Images/Perfil/sinPerfil.jpeg";
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}
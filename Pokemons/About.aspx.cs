using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class About : Page
    {
        public int Edad { get; set; }
        public string Nombre { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)            
                Nombre = Session["nombre"].ToString();
            

            if (Session["edad"] != null)
            {
                if (int.TryParse(Session["edad"].ToString(), out int edad))
                {
                    Edad = edad;
                }               
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

            lblEdad.Text += Edad.ToString();


        }
        
    }
}
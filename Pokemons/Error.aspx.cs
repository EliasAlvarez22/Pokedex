using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemons
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Session["error"].ToString();
                if ((string)Session["error"] == "Sin acceso a esta pagina.")                
                    lblTitulo.Visible = false;
                else 
                    lblTitulo.Visible = true;
                
            }
            

        }
    }
}
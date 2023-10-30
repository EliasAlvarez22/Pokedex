using Dominio;
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
            Usuario = (Usuario)Session["user"]  != null ? (Usuario)Session["user"] : null;
        }

        protected void btnCloseSession_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class _Default : Page
    {
        //public List<Pokemon> ListaPokemons { get; set; } //Con ForEach
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
           
            //ListaPokemons = negocio.ListarSP(); //Con ForEach

            if(!IsPostBack)
            {
                RptPokemons.DataSource = negocio.ListarSP();
                RptPokemons.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
        }
    }
}
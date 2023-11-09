using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Web.SessionState;

namespace Pokemons
{
    public partial class PokemonsLista : System.Web.UI.Page
    {
        private const string sListaPokemons = "listaPokemons";

        protected void Page_Load(object sender, EventArgs e)
        {

            PokemonNegocio negocio = new PokemonNegocio();

            if (Session[sListaPokemons] == null)
            {
                Session.Add(sListaPokemons, negocio.ListarSP());
                
            }
            else
            {
                Session[sListaPokemons] = negocio.ListarSP();
            }
            dgvPokemonsLista.DataSource = Session[sListaPokemons];
            dgvPokemonsLista.DataBind();

            if (!IsPostBack)
            {
                ddlCampos.Items.Add("Numero");
                ddlCampos.Items.Add("Numero");
                ddlCampos.Items.Add("Numero");

            }

        }

        protected void dgvPokemonsLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPokemonsLista.SelectedDataKey.Value.ToString();
            Response.Redirect("PokemonForm.aspx?id=" + id);
        }

        protected void dgvPokemonsLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemonsLista.PageIndex = e.NewPageIndex;
            dgvPokemonsLista.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {

                dgvPokemonsLista.DataSource = null;
                dgvPokemonsLista.DataSource = negocio.Filtrar(numero: txtFiltro.Text);
                dgvPokemonsLista.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //cbxFiltroAvanzado.Checked =;
        }
    }
}
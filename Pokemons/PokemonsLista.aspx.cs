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
                List<Pokemon> listaResultados = negocio.Filtrar(txtFiltro.Text);
                if (listaResultados.Count > 0 )
                {
                    EnlazarDatosDgv(listaResultados);
                }
                else
                {
                    dgvPokemonsLista.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        

        protected void ddlCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                txtFiltroAvanzado.Enabled = true;
                if (ddlCampos.Text == "Número")
                {
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                }
                else if (ddlCampos.Text == "Nombre")
                {
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Igual que");
                }
                else if (ddlCampos.Text == "Tipo Elemento")
                {
                    
                    ElementoNegocio negocioElem = new ElementoNegocio();

                    txtFiltroAvanzado.Enabled = false;

                    ddlCriterio.DataSource = null;
                    ddlCriterio.DataSource = negocioElem.ListarElementos();
                    ddlCriterio.DataBind();
                    ddlCriterio.DataMember= "Id";
                    ddlCriterio.DataTextField = "Descripcion";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocioPoke = new PokemonNegocio();

            try
            {
                //Validacion
                if (ddlCampos.Text == "Seleccione")
                    return;
                
                List<Pokemon> resultadosFiltrados = negocioPoke.Filtrar(ddlCampos.Text, ddlCriterio.Text, txtFiltroAvanzado.Text);
                
                if(resultadosFiltrados != null && resultadosFiltrados.Any())
                {
                    dgvPokemonsLista.Visible = true;
                    

                    dgvPokemonsLista.DataSource = null;
                    dgvPokemonsLista.DataSource = resultadosFiltrados;
                    dgvPokemonsLista.DataBind();
                }
                else
                {
                    dgvPokemonsLista.Visible = false;
                    
                }    
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);

            }
        }

        private void EnlazarDatosDgv(List<Pokemon> listaResultados)
        {
           if (listaResultados.Count > 0)
           {
                dgvPokemonsLista.Visible = true;
                dgvPokemonsLista.DataSource = null;
                dgvPokemonsLista.DataSource = listaResultados;
                dgvPokemonsLista.DataBind();
           }
            
        }
    }
}
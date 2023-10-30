using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Pokemons
{
    public partial class PokemonForm : System.Web.UI.Page
    {
        Pokemon seleccionado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCamposElementos();
            txtId.ReadOnly = true;
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Pokemon> temp = (List<Pokemon>)Session["listaPokemons"];
                seleccionado = temp.Find(x => x.Id == id);

                Page.Title = "Modificar Pokemon";
                btnAgregar.Text = "Modificar";

                if (!IsPostBack)
                {
                    txtId.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    imgPokemon.ImageUrl = seleccionado.UrlImagen;
                    //Seleccion de elementos del pokemon
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                }               
            }
            else
            {
                txtId.Text = "Pendiente";
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null)
                    seleccionado = new Pokemon();
                    
                PokemonNegocio negocioPokemon = new PokemonNegocio();

                
                seleccionado.Numero = int.Parse(txtNumero.Text);
                seleccionado.Descripcion = txtDescripcion.Text;
                seleccionado.Nombre = txtNombre.Text;
                seleccionado.UrlImagen = txtUrlImagen.Text;
                seleccionado.Tipo = new Elemento();
                seleccionado.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                seleccionado.Debilidad = new Elemento();
                seleccionado.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    negocioPokemon.modificar(seleccionado);
                }
                else
                {
                    negocioPokemon.agregar(seleccionado);
                }
                Response.Redirect("PokemonsLista.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("Error al agregar Pokemon", ex);
                throw ex;
            }

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
        }

        private void SetCamposElementos()
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            List<Elemento> listaElementos = negocioElemento.ListarElementos();

            ddlTipo.DataSource = listaElementos;
            ddlTipo.DataValueField = "Id";
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataBind();

            ddlDebilidad.DataSource = listaElementos;
            ddlDebilidad.DataValueField = "Id";
            ddlDebilidad.DataTextField = "Descripcion";
            ddlDebilidad.DataBind();
        }
    }
}
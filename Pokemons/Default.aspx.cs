using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

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
        protected void RptPokemons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                // Encuentra la imagen control en el Repeater
                Image imgPokemon = (Image)e.Item.FindControl("imgPokemon");


                // Obtén la URL de la imagen de la fila actual
                string imageUrl = imgPokemon.ImageUrl.ToString();

                // Verifica si la URL de la imagen es válida, true coloca la imageUrl en el control, false coloca img default
                EsUrlValida(imageUrl, imgPokemon);
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
                
            
        }
        // Función para verificar si una URL es válida
        private void EsUrlValida(string url,Image imgPokemon)
        {
            try 
            {
                if (string.IsNullOrEmpty(url))
                {
                    imgPokemon.ImageUrl = "Resources/imgError.png";
                }
                else
                {   //Queria validar que la imagen es valida
                    /*Vuelve muy lenta la carga de datos.. Mejor se validará al cargar la imagen del objeto que sea valida.   
                    // Crear una solicitud HTTP
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    // Establecer un tiempo de espera para la solicitud (opcional)
                    
                    // Realizar la solicitud y obtener la respuesta
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        // Verificar el código de estado de la respuesta
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            // La URL es válida, se obtuvo una respuesta exitosa
                            imgPokemon.ImageUrl = url;
                        }                       
                    }*/
                }
            }
            catch (Exception)
            {
                imgPokemon.ImageUrl = "Resources/imgError.png";
            }

        }

        
    }
}
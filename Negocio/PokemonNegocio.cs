using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=POKEDEX_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select  Numero, Nombre,  P.Descripcion,UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad and activo = 1";
                comando.Connection = conexion;   
                
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read() )
                {
                    Pokemon aux = new Pokemon
                    {
                        Id = (int)lector["Id"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"],
                        Numero = (int)lector["Numero"],

                    };
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];      
                    aux.Tipo = new Elemento
                    {
                        Id = (int)lector["IdTipo"],
                        Descripcion = (string)lector["Tipo"]
                    };
                    aux.Debilidad = new Elemento
                    {
                        Id = (int)lector["IdDebilidad"],
                        Descripcion = (string)lector["Debilidad"]
                    };
                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public List<Pokemon> ListarSP()
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setProcedure("storedListar");
            datos.ejecutarConsulta();
            SqlDataReader lector = datos.Lector;

            while (lector.Read())
            {
                Pokemon aux = new Pokemon
                {
                    Id = (int)lector["Id"],
                    Numero = (int)lector["Numero"],
                    Nombre = (string)lector["Nombre"],
                    Descripcion = (string)lector["Descripcion"]
                };
                if (!(lector["UrlImagen"] is DBNull))
                    aux.UrlImagen = (string)lector["UrlImagen"];

                aux.Tipo = new Elemento
                {
                    Id = (int)lector["IdTipo"],
                    Descripcion = (string)lector["Tipo"]
                };
                aux.Debilidad = new Elemento
                {
                    Id = (int)lector["IdDebilidad"],
                    Descripcion = (string)lector["Debilidad"]
                };

                lista.Add(aux);
            }

            return lista;


        }

            catch (NullReferenceException ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into POKEMONS(Numero, Nombre, Descripcion, Activo, idTipo, IdDebilidad, UrlImagen)values(" +
                    ""+ nuevo.Numero + ", '" + nuevo.Nombre + "', ' "+ nuevo.Descripcion + "', 1, @IdTipo, @IdDebilidad, @UrlImagen)");
                datos.setearParametros("@IdTipo", nuevo.Tipo.Id);
                datos.setearParametros("@IdDebilidad", nuevo.Debilidad.Id);
                datos.setearParametros("@UrlImagen", nuevo.UrlImagen);
                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); 
            }
        }
        public void modificar(Pokemon poke) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @UrlImagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad where Id = @Id ");
                datos.setearParametros("@Numero", poke.Numero);
                datos.setearParametros("@Nombre", poke.Nombre);
                datos.setearParametros("@Descripcion", poke.Descripcion);
                datos.setearParametros("@UrlImagen", poke.UrlImagen);
                datos.setearParametros("@IdTipo", poke.Tipo.Id);
                datos.setearParametros("@IdDebilidad", poke.Debilidad.Id);
                datos.setearParametros("@Id", poke.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }finally { datos.cerrarConexion();}
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("DELETE POKEMONS where id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarConsulta();                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }            
        }

        public void eliminarLogico(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update POKEMONS set Activo = 0 where Id = @Id");
                datos.setearParametros("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }


        public List<Pokemon> Filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1 And ";
                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarConsulta();
                SqlDataReader lector = datos.Lector;

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon
                    {
                        Id = (int)lector["Id"],
                        Numero = (int)lector["Numero"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"]
                    };
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new Elemento
                    {
                        Id = (int)lector["IdTipo"],
                        Descripcion = (string)lector["Tipo"]
                    };
                    aux.Debilidad = new Elemento
                    {
                        Id = (int)lector["IdDebilidad"],
                        Descripcion = (string)lector["Debilidad"]
                    };

                    lista.Add(aux);
                }

                return lista;


            }

            catch (NullReferenceException ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
    }
}

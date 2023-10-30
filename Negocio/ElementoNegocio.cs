using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> ListarElementos()
        {
			List<Elemento> lista = new List<Elemento>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select Id, Descripcion from ELEMENTOS");
				datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
				}
                return lista;

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
        public void agregarElemento(Elemento elemento)
        {
            AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("insert into ELEMENTOS values(@descripcion)");
				datos.setearParametros("@descripcion", elemento.Descripcion);
				datos.ejecutarAccion();				
			}
			catch (Exception ex)
			{

				throw ex;
			}finally {datos.cerrarConexion();}
        }
    }
}

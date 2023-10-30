using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class UsuarioNegocio
    {
        public void RegisterUser(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetProcedure("RegisterUser");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@password", user.Password);
                datos.ejecutarAccion();
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
        public bool Login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, email, password, admin,nombre, dob, imagenProfile FROM USUARIOS" +
                                     " where email = @email and password = @pass");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Password);
                datos.ejecutarConsulta();
                SqlDataReader lector = datos.Lector;

                if (lector.Read())
                {
                    user.Id = (int)lector["id"];
                    user.Admin = (bool)lector["admin"];
                    if (!(lector["name"] is DBNull))
                        user.Nombre = (string)lector["name"]; 

                   
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
            return false;
        }
        public bool ValidarRegistroEmail(string UserEmail)
        {
            AccesoDatos datos = new AccesoDatos ();
            datos.setearConsulta("SELECT email  FROM USUARIOS");
            datos.ejecutarConsulta();
            SqlDataReader lector = datos.Lector;

            string emailEnUsado;
            while (lector.Read())
            {
                try
                {
                    emailEnUsado = lector["email"].ToString();
                    if (emailEnUsado == UserEmail)
                        return true;
                }
                catch(Exception ex) 
                {
                    throw ex;
                }

            }
            datos.cerrarConexion();
            return false;
        }
    }
}

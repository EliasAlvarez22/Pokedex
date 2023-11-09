using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Security
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user) 
        {
            if (user != null)
                return true; 
           
            return false;
        }
    }
}

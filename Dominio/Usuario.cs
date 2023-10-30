using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dominio
{
    enum TipoUsuario  
    {
        NORMAL = 1,
        ADMIN = 2
    };
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }        

        public string ImagenPerfil { get; set; }
        public bool Admin { get;set; }
        //public TipoUsuario TipUser { get; set; }    
    }
}

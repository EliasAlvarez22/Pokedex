using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AutoNegocio
    {
        public List<Auto> Listar()
        {
            List <Auto> lista = new List<Auto>();
            try
            {
                Auto auto1 = new Auto
                {
                    Id = 1,
                    Modelo = "Modelo1",
                    Descripcion = "Descripción1",
                    Color = "Rojo",
                    Fecha = DateTime.Now,
                    Usado = true,
                    Importado = false
                };

                // Crear la segunda instancia de Auto y asignar sus valores
                Auto auto2 = new Auto
                {
                    Id = 2,
                    Modelo = "Modelo2",
                    Descripcion = "Descripción2",
                    Color = "Azul",
                    Fecha = DateTime.Now,
                    Usado = false,
                    Importado = true
                };
                // Agregar las instancias a la lista
                lista.Add(auto1);
                lista.Add(auto2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}

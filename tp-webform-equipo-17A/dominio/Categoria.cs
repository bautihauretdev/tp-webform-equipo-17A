using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        // ATRIBUTOS
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // CONSTRUCTOR SIN PARAMETROS
        public Categoria() { }

        // CONSTRUCTOR CON PARAMETROS
        public Categoria(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        // ATRIBUTOS
        public int id { get; set; } // Autoincrementable tomando de referencia el último que encuentra
        public string descripcion { get; set; }

        // CONSTRUCTOR SIN PARÁMETROS
        public Marca() { }

        // CONSTRUCTOR CON PARÁMETROS
        public Marca(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
    }
}

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
        public int Id { get; set; } // Autoincrementable tomando de referencia el último que encuentra
        public string Descripcion { get; set; }

        // CONSTRUCTOR SIN PARÁMETROS
        public Marca() { }

        // CONSTRUCTOR CON PARÁMETROS
        public Marca(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}

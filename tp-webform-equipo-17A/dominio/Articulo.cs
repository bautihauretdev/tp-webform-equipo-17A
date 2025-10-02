using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }

        // LLAMADO A OTRAS CLASES
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();

        [DisplayName("Marca")]
        public string NombreMarca
        {
            get { return Marca != null ? Marca.Descripcion : ""; }
        }
        [DisplayName("Categoria")]
        public string NombreCategoria
        {
            get { return Categoria != null ? Categoria.Descripcion : ""; }
        }

        // CONSTRUCTOR SIN PARAMETROS
        public Articulo() { }

        // CONSTRUCTOR CON PARAMETROS
        public Articulo(int Id, string Codigo, string Nombre, string Descripcion, decimal Precio, int idMarca, int idCategoria)
        {
            this.Id = Id;
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
            this.IdMarca = idMarca;
            this.IdCategoria = idCategoria;
        }
    }
}

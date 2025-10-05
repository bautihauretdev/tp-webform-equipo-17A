using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion as Marca, A.IdCategoria, C.Descripcion as Categoria, 
                                    A.Precio, 
                                    (SELECT TOP 1 ImagenUrl FROM IMAGENES I WHERE I.IdArticulo = A.Id) as ImagenUrl
                                    FROM ARTICULOS A 
                                    JOIN MARCAS M ON A.IdMarca = M.Id 
                                    JOIN CATEGORIAS C ON A.IdCategoria = C.Id";

                datos.setearConsulta(consulta);
                SqlDataReader lector = datos.ejecutarLectura();

                while (lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)lector["Id"];
                    articulo.Codigo = lector["Codigo"].ToString();
                    articulo.Nombre = lector["Nombre"].ToString();
                    articulo.Descripcion = lector["Descripcion"].ToString();
                    articulo.Precio = (decimal)lector["Precio"];
                    articulo.IdMarca = (int)lector["IdMarca"];
                    articulo.Marca = new Marca((int)lector["IdMarca"], lector["Marca"].ToString());
                    articulo.IdCategoria = (int)lector["IdCategoria"];
                    articulo.Categoria = new Categoria((int)lector["IdCategoria"], lector["Categoria"].ToString());
                    articulo.ImagenUrl = lector["ImagenUrl"] != DBNull.Value ? lector["ImagenUrl"].ToString() : null;

                    // NUEVO: traemos todas las imágenes
                    AccesoDatos datosImagen = new AccesoDatos();
                    datosImagen.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                    datosImagen.setearParametro("@IdArticulo", articulo.Id);
                    SqlDataReader lectorImagen = datosImagen.ejecutarLectura();

                    while (lectorImagen.Read())
                    {
                        articulo.Imagenes.Add(new Imagen(
                            (int)lectorImagen["Id"],
                            (int)lectorImagen["IdArticulo"],
                            lectorImagen["ImagenUrl"].ToString()
                        ));
                    }
                    datosImagen.cerrarConexion();

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // Siempre se ejecuta, haya o no excepción
            }
        }
    }
}

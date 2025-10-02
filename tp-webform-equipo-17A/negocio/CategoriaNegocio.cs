using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                SqlDataReader lector = datos.ejecutarLectura();

                while (lector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.Id = (int)lector["Id"];
                    cat.Descripcion = lector["Descripcion"].ToString();
                    lista.Add(cat);
                }

                return lista;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

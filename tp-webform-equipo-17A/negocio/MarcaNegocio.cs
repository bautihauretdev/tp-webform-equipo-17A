using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Id, Descripcion FROM MARCAS";
                datos.setearConsulta(consulta);
                SqlDataReader lector = datos.ejecutarLectura();

                while (lector.Read())
                {
                    int id = (int)lector["Id"];
                    string descripcion = lector["Descripcion"].ToString();
                    lista.Add(new Marca(id, descripcion));
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

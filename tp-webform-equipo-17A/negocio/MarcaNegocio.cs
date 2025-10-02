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
        // Descomentar cuando se desarrolle la clase AccesoDatos

        //public List<Marca> Listar()
        //{
        //    List<Marca> lista = new List<Marca>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        string consulta = "SELECT Id, Descripcion FROM MARCAS";
        //        datos.setearConsulta(consulta);
        //        SqlDataReader lector = datos.ejecutarLectura();


        //        while (lector.Read())
        //        {
        //            int id = (int)lector["Id"];
        //            string descripcion = lector["Descripcion"].ToString();
        //            lista.Add(new Marca(id, descripcion));
        //        }
        //        datos.cerrarConexion();
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

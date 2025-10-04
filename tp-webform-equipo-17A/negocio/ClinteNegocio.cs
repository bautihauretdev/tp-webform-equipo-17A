using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClinteNegocio
    {
        public List<Cliente> Listar ()
        {
            List<Cliente> lista = new List<Cliente> ();
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                string consulta = "SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes";
                datos.setearConsulta(consulta);
                SqlDataReader lector = datos.ejecutarLectura();

                while (lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)lector["Id"];
                    cliente.Documento = lector["Documento"].ToString();
                    cliente.Nombre = lector["Nombre"].ToString();
                    cliente.Apellido = lector["Apellido"].ToString();
                    cliente.Email = lector["Email"].ToString();
                    cliente.Direccion = lector["Direccion"].ToString();
                    cliente.Ciudad = lector["Ciudad"].ToString();
                    cliente.CP = (int)lector["CP"];
                    lista.Add(cliente);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Agrega un nuevo cliente
        public void Agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                  "VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Documento", cliente.Documento);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente BuscarPorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Documento", documento);
                SqlDataReader lector = datos.ejecutarLectura();

                if (lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)lector["Id"];
                    cliente.Documento = lector["Documento"].ToString();
                    cliente.Nombre = lector["Nombre"].ToString();
                    cliente.Apellido = lector["Apellido"].ToString();
                    cliente.Email = lector["Email"].ToString();
                    cliente.Direccion = lector["Direccion"].ToString();
                    cliente.Ciudad = lector["Ciudad"].ToString();
                    cliente.CP = (int)lector["CP"];
                    datos.cerrarConexion();
                    return cliente;
                }
                datos.cerrarConexion();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Actualizar (Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP WHERE Documento = @Documento";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CP);
                datos.setearParametro("@Documento", cliente.Documento);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public bool EsVoucherValido(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"SELECT COUNT(*) FROM Vouchers 
                                    WHERE CodigoVoucher = @codigo 
                                      AND IdCliente IS NULL 
                                      AND FechaCanje IS NULL 
                                      AND IdArticulo IS NULL";
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", codigoVoucher);
                SqlDataReader lector = datos.ejecutarLectura();
                int count = 0;
                if (lector.Read())
                    count = lector.GetInt32(0);
                datos.cerrarConexion();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CanjearVoucher(string codigoVoucher, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"UPDATE Vouchers 
                           SET IdCliente = @idCliente, 
                               IdArticulo = @idArticulo, 
                               FechaCanje = GETDATE() 
                         WHERE CodigoVoucher = @codigo 
                           AND IdCliente IS NULL 
                           AND IdArticulo IS NULL 
                           AND FechaCanje IS NULL";
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", codigoVoucher);
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@idArticulo", idArticulo);
                int filas = datos.ejecutarNonQuery();
                return filas > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExisteVoucher(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo";
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", codigoVoucher);
                SqlDataReader lector = datos.ejecutarLectura();
                int count = 0;
                if (lector.Read())
                    count = lector.GetInt32(0);
                datos.cerrarConexion();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

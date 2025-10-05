using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace presentacionWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mensajeVoucher"] != null)
            {
                lblMensaje.Text = Session["mensajeVoucher"].ToString();
                Session.Remove("mensajeVoucher"); // Borra el mensaje para que no quede persistente
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string voucher = txtVoucher.Text.Trim();

            if (!string.IsNullOrEmpty(voucher))
            {
                bool existe = false;
                bool esValido = false;

                string connectionString ="Server= localhost\\SQLEXPRESS; Database=PROMOS_DB; Trusted_Connection=True;";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    // Verifica si existe el voucher
                    string query = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@codigo", voucher);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    existe = count > 0;

                    // Existe y verifica si ya fue usado
                    if (existe)
                    {
                        string queryUsado = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL";
                        SqlCommand cmdUsado = new SqlCommand(queryUsado, cnn);
                        cmdUsado.Parameters.AddWithValue("@codigo", voucher);
                        int countValido = (int)cmdUsado.ExecuteScalar();
                        esValido = countValido > 0;
                    }
                }

                if (!existe)
                {
                    lblVoucherMensaje.Text = "El voucher ingresado no existe.";
                }
                else if (!esValido)
                {
                    lblVoucherMensaje.Text = "Este voucher ya fue utilizado.";
                }
                else
                {
                    Session["voucherCodigo"] = voucher;
                    Response.Redirect("Premios.aspx");
                }
            }
            else
            {
                lblVoucherMensaje.Text = "Debe ingresar un voucher.";
            }
        }
    }
}
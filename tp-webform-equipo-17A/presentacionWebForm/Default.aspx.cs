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
                string connectionString ="Server= localhost\\SQLEXPRESS; Database=PROMOS_DB ;Trusted_Connection=True";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@codigo", voucher);
                    cnn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    existe = count > 0;
                }

                if (existe)
                {
                    Session["voucherCodigo"] = voucher;
                    Response.Redirect("Premios.aspx");
                }
                else
                {
                    lblVoucherMensaje.Text = "El voucher ingresado no existe.";
                }
            }
            else
            {
                lblVoucherMensaje.Text = "Debe ingresar un voucher.";
            }
        }
    }
}
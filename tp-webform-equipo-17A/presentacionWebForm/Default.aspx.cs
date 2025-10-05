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
            // CUANDO ESTÉN EL ARTÍCULO SELECCIONADO Y EL CLIENTE CARGADO,
            // HAY QUE GUARDAR AMBOS DATOS EN EL VOUCHER.

            // PARA LEVANTAR EL ID DE ARTICULO SELECCIONADO (por Session):
            // Session["articuloId"] != null ? Session["articuloId"].ToString() : "";
            // (!) Pasarlo a int
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
                    Session["voucher"] = voucher;
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
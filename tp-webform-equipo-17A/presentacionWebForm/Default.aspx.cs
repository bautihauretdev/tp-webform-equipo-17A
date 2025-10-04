using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                Session["voucher"] = voucher;
                Response.Redirect("Premios.aspx");
            }
            else
            {

            }
        }
    }
}
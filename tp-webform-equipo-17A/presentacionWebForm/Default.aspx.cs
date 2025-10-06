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
                VoucherNegocio negocio = new VoucherNegocio();

                bool existe = negocio.ExisteVoucher(voucher);
                bool esValido = false;

                if (existe)
                {
                    // Existe y verifica si ya fue usado
                    esValido = negocio.EsVoucherValido(voucher);
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
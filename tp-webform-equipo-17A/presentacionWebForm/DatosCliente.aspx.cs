using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacionWebForm
{
    public partial class DatosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CUANDO ESTÉN EL ARTÍCULO SELECCIONADO Y EL CLIENTE CARGADO,
            // HAY QUE GUARDAR AMBOS DATOS EN EL VOUCHER.

            // PARA LEVANTAR EL ID DE ARTICULO SELECCIONADO (por Session):
            // Session["articuloId"] != null ? Session["articuloId"].ToString() : "";
            // (!) Pasarlo a int
        }

        protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            

            if (string.IsNullOrEmpty(dni))
            {
                lblDniMensaje.Text += " - Debe ingresar un DNI.";
                LimpiarCampos();
                return;
            }

            ClinteNegocio negocio = new ClinteNegocio();
            Cliente cliente = negocio.BuscarPorDocumento(dni);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();
                
            }
            else
            {
                LimpiarCampos();
                lblDniMensaje.Text += " - No existe un cliente con ese DNI. Complete los datos para registrarse.";
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtCiudad.Text = "";
            txtCP.Text = "";
        }
    }
}
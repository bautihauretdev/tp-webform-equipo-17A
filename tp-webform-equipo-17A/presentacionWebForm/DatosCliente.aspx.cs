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

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            if (!chkTerminos.Checked)
            {
                lblDniMensaje.Text = "Debe aceptar los términos y condiciones.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                   string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text) ||
                   string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                   string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                   string.IsNullOrWhiteSpace(txtCP.Text))
            {
                lblDniMensaje.Text = "Debe completar todos los campos.";
                return;
            }
            //validacion para email
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblDniMensaje.Text = "Ingrese un email válido.";
                return;
            }
            //valida que el dni no exista
            ClinteNegocio negocio = new ClinteNegocio();
            Cliente clienteExistente = negocio.BuscarPorDocumento(txtDNI.Text.Trim());

            if (clienteExistente != null)
            {
                lblDniMensaje.Text = "Ya existe un cliente con ese DNI.";
                
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Documento = txtDNI.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                CP = int.TryParse(txtCP.Text.Trim(), out int cp) ? cp : 0
            };

            try
            {
                negocio.Agregar(nuevoCliente);
                lblDniMensaje.Text = "¡Registro exitoso! Ahora puede participar en la promo.";
                //FALTA HACER EL Redirigir a página de Exito
                // Response.Redirect("Exito.aspx");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblDniMensaje.Text = "Error al registrar el cliente: " + ex.Message;
            }

        }
    }
}
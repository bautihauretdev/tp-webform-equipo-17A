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

        }

        protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                lblDniMensaje.Text = "Debe ingresar un DNI.";
                LimpiarCampos();
                OcultarOpcionesActualizar();
                HabilitarEdicionCampos(false);
                btnParticipar.Visible = false;
                return;
            }

            ClinteNegocio negocio = new ClinteNegocio();
            Cliente cliente = negocio.BuscarPorDocumento(dni);

            if (cliente != null)
            {
                //precarga datos en modo lectura
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();

                //pone los campos en solo lectura
                HabilitarEdicionCampos(false);

                // muestra label y radios
                lblClienteRegistrado.Visible = true;
                rblActualizar.Visible = true;
                rblActualizar.ClearSelection();

                //esconde btn actualizar hasta que sea necesario
                btnActualizar.Visible = false;

                btnParticipar.Visible = true;

                lblDniMensaje.Text = "";
            }
            else
            {
                LimpiarCampos();
                // habilita edición
                HabilitarEdicionCampos(true);

                // oculta opciones de actualización
                OcultarOpcionesActualizar();

                // muestra btn participar (para alta)
                btnParticipar.Visible = true;

                lblDniMensaje.Text = "No existe un cliente con ese DNI. Complete los datos para registrarse.";
            }
        }

        private void HabilitarEdicionCampos(bool habilitar)
        {
            txtNombre.ReadOnly = !habilitar;
            txtApellido.ReadOnly = !habilitar;
            txtEmail.ReadOnly = !habilitar;
            txtDireccion.ReadOnly = !habilitar;
            txtCiudad.ReadOnly = !habilitar;
            txtCP.ReadOnly = !habilitar;
        }

        private void OcultarOpcionesActualizar()
        {
            lblClienteRegistrado.Visible = false;
            rblActualizar.Visible = false;
            btnActualizar.Visible = false;
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
                lblMensajeError.Text = "Debe aceptar los términos y condiciones.";
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
                lblMensajeError.Text = "Debe completar todos los campos.";
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblMensajeError.Text = "Ingrese un email válido.";
                return;
            }

            ClinteNegocio negocio = new ClinteNegocio();
            Cliente clienteExistente = negocio.BuscarPorDocumento(txtDNI.Text.Trim());
            int idCliente;

            if (clienteExistente != null)
            {
                idCliente = clienteExistente.Id;
            }
            else
            {
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
                    idCliente = nuevoCliente.Id;
                }
                catch (Exception ex)
                {
                    lblMensajeError.Text = "Error al registrar el cliente: " + ex.Message;
                    return;
                }
            }

            string codigoVoucher = Session["voucherCodigo"]?.ToString();

            if (string.IsNullOrEmpty(codigoVoucher) || Session["articuloId"] == null)
            {
                lblMensajeError.Text = "No se pudo realizar la operación. Vuelva a ingresar el voucher.";
                return;
            }

            int idArticulo = Convert.ToInt32(Session["articuloId"]);

            try
            {
                VoucherNegocio voucherNegocio = new VoucherNegocio();

                // Agregar fecha!!!!!!
                bool canjeExitoso = voucherNegocio.CanjearVoucher(codigoVoucher, idCliente, idArticulo);

                if (canjeExitoso)
                {
                    // El canje fue exitoso. Limpiamos la sesión y redirigimos.
                    Session.Remove("voucherCodigo");
                    Session.Remove("articuloId");
                    Response.Redirect("Exito.aspx");
                }
                else
                {
                    Session["mensajeVoucher"] = "No se pudo realizar el canje.";
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al procesar la participación: " + ex.Message;
            }
        }

        protected void rblActualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblActualizar.SelectedValue == "si")
            {
                //habilita campos y muestra btn actualizar
                HabilitarEdicionCampos(true);
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtCiudad.ReadOnly = false;
                txtCP.ReadOnly = false;
                btnParticipar.Visible = false;

                btnActualizar.Visible = true;
            }
            else
            {
                //deshabilita campos y oculta botón actualizar
                HabilitarEdicionCampos(false);
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCiudad.ReadOnly = true;
                txtCP.ReadOnly = true;

                btnParticipar.Visible = true;
                btnActualizar.Visible = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //valida los campos
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text))
            {
                lblMensajeError.Text = "Debe completar todos los campos para actualizar.";
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblMensajeError.Text = "Ingrese un email válido.";
                return;
            }

            Cliente clienteActualizado = new Cliente
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
                ClinteNegocio negocio = new ClinteNegocio();
                negocio.Actualizar(clienteActualizado);
                lblMensajeCorrecto.Text = "¡Datos actualizados correctamente!";

                //oculta botones de actualizar y vuelve a mostrar btnParticipar
                HabilitarEdicionCampos(false);
                lblClienteRegistrado.Visible = false;
                btnActualizar.Visible = false;
                btnParticipar.Visible = true;
                rblActualizar.Visible = false;
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al actualizar el cliente: " + ex.Message;
            }
        }
    }
}
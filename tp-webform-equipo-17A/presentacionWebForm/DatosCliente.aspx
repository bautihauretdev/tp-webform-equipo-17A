<%@ Page Title="Registro de Cliente" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DatosCliente.aspx.cs" Inherits="presentacionWebForm.DatosCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container form-section">
        <div class="form-main-title">Ingresá tus datos</div>
        <!-- DNI -->
        <div class="row mb-3">
            <div class="col-12">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" MaxLength="8"
                    required="required" pattern="\d{7,8}" placeholder="Ingrese N° DNI" />
                <div class="invalid-feedback">Ingrese un DNI válido (sólo números, 7 u 8 dígitos).</div>
            </div>
        </div>
        <!-- Nombre, Apellido, Email -->
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50"
                    required="required" placeholder="Ingrese su nombre" />
                <div class="valid-feedback">Ok!</div>
                <div class="invalid-feedback">El nombre es obligatorio.</div>
            </div>
            <div class="col-md-4">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="50"
                    required="required" placeholder="Ingrese su apellido" />
                <div class="invalid-feedback">El apellido es obligatorio.</div>
            </div>
            <div class="col-md-4">
                <label for="txtEmail" class="form-label">Email</label>
                <div class="input-group">
                    <span class="input-group-text">@</span>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50"
                        required="required" TextMode="Email" placeholder="Ingrese su email" />
                </div>
                <div class="invalid-feedback">Ingrese un email válido.</div>
            </div>
        </div>
        <!-- Dirección, Ciudad, CP -->
        <div class="row mb-3">
            <div class="col-md-6 col-lg-5">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50"
                    required="required" placeholder="Ingrese su direccion" />
                <div class="invalid-feedback">Falta dirección.</div>
            </div>
            <div class="col-md-4 col-lg-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" MaxLength="50"
                    required="required" placeholder="Ingrese su ciudad" />
                <div class="invalid-feedback">La ciudad es obligatoria.</div>
            </div>
            <div class="col-md-2 col-lg-3">
                <label for="txtCP" class="form-label">CP</label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" MaxLength="10"
                    required="required" pattern="\d{3,10}" placeholder="Ingrese su codigo postal" />
                <div class="invalid-feedback">Ingrese un código postal válido.</div>
            </div>
        </div>
        <!-- Términos y condiciones -->
        <div class="row mb-3">
            <div class="col-12">
                <div class="form-check">
                    <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" />
                    <label class="form-check-label" for="chkTerminos">Acepto los términos y condiciones.</label>
                </div>
            </div>
        </div>
        <!-- Botón Participar -->
        <div class="row mb-4">
            <div class="col-12">
                <asp:Button ID="btnParticipar" runat="server" CssClass="btn btn-primary btn-block" Text="¡Participar!" />
            </div>
        </div>
    </div>
</asp:Content>
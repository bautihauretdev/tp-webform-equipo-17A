<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="presentacionWebForm.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container-exito">
        <h1 class="display-4 text-success mb-3">¡Gracias por participar!</h1>
        <p class="lead mb-2">Tus datos han sido registrados correctamente.</p>
        <p class="mb-4">Estás participando por el premio seleccionado.</p>
       <asp:Button ID="btnVolverDefault" runat="server" Text="Volver al inicio"
    OnClick="btnVolverDefault_Click"
    CssClass="btn btn-primary btn-lg mt-4" />
    </div>
</asp:Content>


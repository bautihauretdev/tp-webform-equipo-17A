<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacionWebForm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="voucher-container">
        <div class="voucher-title">Promo Ganá!</div>
        <div class="voucher-desc">Ingresá aca tu voucher para participar!</div>
        <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control voucher-input" placeholder="XXXXXXXXXXXXXXX"></asp:TextBox>
        <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="voucher-btn" OnClick="btnSiguiente_Click" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-center mt-2" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
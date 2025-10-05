<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacionWebForm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="voucher-container">
        <div class="voucher-title">Promo Ganá!</div>
        <div class="voucher-desc">Ingresá aca tu voucher para participar!</div>
        <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control voucher-input" placeholder="XXXXXXXXXXXXXXX"></asp:TextBox>
        <!-- Label para mostrar mensajes de error del voucher -->
        <asp:Label ID="lblVoucherMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2" Style="display:block; text-align:center;" EnableViewState="false"></asp:Label>
        <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="voucher-btn" OnClick="btnSiguiente_Click" />
    </div>
</asp:Content>
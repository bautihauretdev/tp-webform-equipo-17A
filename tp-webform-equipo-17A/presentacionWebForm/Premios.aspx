<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="presentacionWebForm.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="tituloPemio">Elegí tu premio!</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rRepetidor" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card">
                        <!-- PARTE ARRIBA DEL CARD -->
                        <div id="carousel_<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel" data-bs-interval="2000">
                            <div class="carousel-inner">
                                <!-- Repeater que recorre todas las imágenes del artículo -->
                                <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# ((dynamic)Container.DataItem).Imagenes %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("ImagenURL") %>' class="d-block w-100 ajuste-imagen" alt="Imagen del artículo">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!-- PARTE ARRIBA DEL CARD -->

                        <!-- DATOS CARD -->
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button Text="Quiero este" ID="btnQuieroEste" CssClass="btn btn-dark centrado" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnQuieroEste_Click" runat="server" />
                        </div>
                        <!-- FIN DATOS CARD -->
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

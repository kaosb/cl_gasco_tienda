<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="resultados-busqueda.aspx.cs" Inherits="resultados_busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Resultados búsqueda
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn">
            <div class="despacho-cont">
                <asp:Panel ID="pnlProducts" runat="server">
                    <asp:Repeater ID="rptProductos" runat="server">
                        <ItemTemplate>
                            <div class="cat-cont">
                                <a href="ver-producto.aspx?p=<%# Eval("codigo") %>">
                                    <div class="cat-contimg">
                                        <center><img alt="" id="displayimg" src="imgProductos/<%# Eval("codigo") %>.jpg" /></center>
                                        <div class="cont-precio"><%# "$"+((long)Eval("precio")).ToString("N0") %></div>
                                    </div>
                                </a>
                                <div class="cat-titulo" style="line-height:20px;"><%# Eval("nombre") %></div>
                                <div class="cat-desc"><%# Eval("descripcion") %></div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="clear:both;"></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
                <asp:Panel ID="pnlNotFound" runat="server" Visible="false">
                    <div class="productos-title" style="text-transform:none;">No se encontraron productos</div>
                    <div class="int-separ"></div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>


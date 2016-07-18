<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ver-categoria.aspx.cs" Inherits="ver_categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <asp:Panel ID="pnlProduct" runat="server">
            <div class="productos-breadcrumb">
                <asp:Label ID="lblBreadCrumb" CssClass="cat-breadcrumb" runat="server" Text=""></asp:Label></div>
            <div class="int-separ"></div>
            <div class="productos-title">
                <asp:Label ID="lblNP" runat="server" Text=""></asp:Label>
            </div>
            <div class="int-separ"></div>
            <div class="main-navbtn">
                <div class="cat-contgeneral">
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
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlNotFound" runat="server" Visible="false">
            <div class="productos-breadcrumb"><asp:Label ID="lblBreadCrumbnf" runat="server" Text=""></asp:Label></div>
            <div class="int-separ"></div>
            <div class="productos-title" style="text-transform:none;">No se encontraron productos</div>
            <div class="int-separ"></div>
        </asp:Panel>
    </div>
</asp:Content>


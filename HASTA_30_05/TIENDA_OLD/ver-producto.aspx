<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ver-producto.aspx.cs" Inherits="ver_producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.elevateZoom-3.0.8.min.js"></script>
    <script type="text/javascript" src="js/zoom-plugin.js"></script>
    <script type="text/javascript">
        function showAddProduct() {
            $('#added').fadeIn("slow");
        }
        function hideAddProduct() {
            $('#added').fadeOut("fast");
        }
    </script>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="productos">
        <asp:Panel ID="pnlProduct" runat="server">
            <div class="productos-breadcrumb">
                <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
            <div class="int-separ"></div>
            <div class="productos-title">
                <asp:Label ID="lblNP" runat="server" Text=""></asp:Label>
            </div>
            <div class="int-separ"></div>
            <div class="main-navbtn">
                <div class="productoscola">
                    <div class="productos-img">
                        <div class="productos-imgmask">
                            <%--<img alt="" id="displayimg" src="imgProductos/ESTUFA_GASCO_5KG.png" data-zoom-image="imgProductos/ESTUFA_GASCO_5KG_large1.png" />--%>
                            <asp:Image ID="imgProd" Height="200" data-zoom-image="imgProductos/ESTUFA_GASCO_5KG_large1.png" style="left:20px;" runat="server" />
                        </div>
                        
                        <%--<center><asp:Image ID="imgProd" Height="190" runat="server" /></center>--%>
                    </div>
                    <div id="gal1">
                        <%--<div class="productos-thumb">
                            <a href="#" data-image="imgProductos/ESTUFA_GASCO_5KG.png" data-zoom-image="imgProductos/ESTUFA_GASCO_5KG_large1.png">
                                <img alt="" id="img1" src="imgProductos/ESTUFA_GASCO_5KG_thumb1.png" />
                            </a>
                        </div>
                        <div class="productos-thumb">
                            <a href="#" data-image="imgProductos/ESTUFA_GASCO_5KG.png" data-zoom-image="imgProductos/ESTUFA_GASCO_5KG_large2.png">
                                <img alt="" id="img2" src="imgProductos/ESTUFA_GASCO_5KG_thumb2.png" />
                            </a>
                        </div>--%>
                        
                    </div>
                    <div class="promocion"><div ID="lblDescuento" runat="server"></div></div>
                </div>
                <div class="productosvsepar"></div>
                <div class="productoscolb">
                    <p style="font-weight: bold;">CARACTERÍSTICAS:</p>
                    <ul>
                        <asp:Repeater ID="rpCaracteristicas" runat="server">
                            <ItemTemplate>
                                <li><%# Eval("key") %>: <%# Eval("val") %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="botcaracteristicas"></div>
                    <asp:ImageButton ID="ibd" runat="server" ImageUrl="img/prod_btndespacho.png" OnClick="showDespacho" CssClass="productos-btndespacho" />
                </div>
                <div class="productosvsepar"></div>
                <div class="productoscolc">
                    <center>
                        <asp:Image ID="imgLogo" Width="180" runat="server" ImageUrl="imgProductos/ESTUFA_GASCO_2KG-logo.png" /></center>
                    <div class="int-separ"></div>
                    <div class="productos-pricebox">
                        <p class="productos-tp">Precio:</p>
                        <p class="productos-precio">
                            <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label><div class="iva_incluido">IVA INCLUIDO</div></p>
                        <div class="productos-stock">
                            <asp:Image ID="imgStock" runat="server"></asp:Image>
                        </div>
                        <center>
                            <p>*No incluye costo de despacho</p>
                            <asp:ImageButton ID="ibAddToCart" OnClick="addToCart" runat="server" ImageUrl="img/productos_addcart.png" Style="margin: 30px 0px 20px 0px;"></asp:ImageButton>
                            <img alt="" src="img/productos_formapago.png" />
                        </center>
                        <div id="added">
                            <a href="carro-de-compras.aspx"><div class="vercarro"></div></a>
                            <div class="closeme" onclick="hideAddProduct();"></div>
                        </div>
                    </div>
                </div>
            </div>
            
        </asp:Panel>
        <asp:Panel ID="pnlNotFound" runat="server" Visible="false">
            <div class="productos-breadcrumb"><asp:Label ID="lblBreadCrumbnf" runat="server" Text=""></asp:Label></div>
            <div class="int-separ"></div>
            <div class="productos-title">Producto no encontrado</div>
            <div class="int-separ"></div>
        </asp:Panel>
    </div>

</asp:Content>


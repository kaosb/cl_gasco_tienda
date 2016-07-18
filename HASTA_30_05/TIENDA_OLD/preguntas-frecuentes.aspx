<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="preguntas-frecuentes.aspx.cs" Inherits="preguntas_frecuentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#faqGeneral").accordion({ heightStyle: "content" });
            $("#faqCompra").accordion({ heightStyle: "content" });
            $("#faqDespacho").accordion({ heightStyle: "content" });
            $("#faqInstalacion").accordion({ heightStyle: "content" });
            $("#accordion").accordion({ heightStyle: "content" });
            $('.faq_general').click(function(){ 
                $('#faqGeneral').slideDown();
                $('#faqCompra').slideUp();
                $('#faqDespacho').slideUp();
                $('#faqInstalacion').slideUp();
                $('.faq_general').addClass("activo");
                $('.faq_compra').removeClass("activo");
                $('.faq_despacho').removeClass("activo");
                $('.faq_instalacion').removeClass("activo");
            });
            $('.faq_compra').click(function(){
                $('#faqCompra').slideDown();
                $('#faqGeneral').slideUp();
                $('#faqDespacho').slideUp();
                $('#faqInstalacion').slideUp();
                $('.faq_general').removeClass("activo");
                $('.faq_compra').addClass("activo");
                $('.faq_despacho').removeClass("activo");
                $('.faq_instalacion').removeClass("activo");
            });
            $('.faq_despacho').click(function(){
                $('#faqDespacho').slideDown();
                $('#faqGeneral').slideUp();
                $('#faqCompra').slideUp();
                $('#faqInstalacion').slideUp();
                $('.faq_general').removeClass("activo");
                $('.faq_compra').removeClass("activo");
                $('.faq_despacho').addClass("activo");
                $('.faq_instalacion').removeClass("activo");
            });
            $('.faq_instalacion').click(function(){
                $('#faqInstalacion').slideDown();
                $('#faqGeneral').slideUp();
                $('#faqCompra').slideUp();
                $('#faqDespacho').slideUp();
                $('.faq_general').removeClass("activo");
                $('.faq_compra').removeClass("activo");
                $('.faq_despacho').removeClass("activo");
                $('.faq_instalacion').addClass("activo");
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Preguntas frecuentes
        </div>
        <div class="int-separ"></div>

        <div id="btns_faq">
            <a class="faq_general activo"></a>
            <a class="faq_compra"></a>
            <a class="faq_despacho"></a>
            <a class="faq_instalacion"></a>
        </div>

        <div style="clear:both"></div><br><br>

        <div id="faqGeneral">
            <asp:Repeater ID="rptGenerales" runat="server">
                <ItemTemplate>
                    <h3><span style="color:#01b0f1;">• </span><%# Eval("Pregunta")%><br /></h3>
                    <div>
                        <div class="faq-bg1"></div>
                        <div class="faq-bg2"><p> <%# Eval("Respuesta")%><br /></p></div>
                        <div class="faq-bg3"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div id="faqCompra">
            <asp:Repeater ID="rptCompra" runat="server">
                <ItemTemplate>
                    <h3><span style="color:#01b0f1;">• </span><%# Eval("Pregunta")%><br /></h3>
                    <div>
                        <div class="faq-bg1"></div>
                        <div class="faq-bg2"><p> <%# Eval("Respuesta")%><br /></p></div>
                        <div class="faq-bg3"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div id="faqDespacho">
            <asp:Repeater ID="rptDespacho" runat="server">
                <ItemTemplate>
                    <h3><span style="color:#01b0f1;">• </span><%# Eval("Pregunta")%><br /></h3>
                    <div>
                        <div class="faq-bg1"></div>
                        <div class="faq-bg2"><p> <%# Eval("Respuesta")%><br /></p></div>
                        <div class="faq-bg3"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <div id="faqInstalacion">
            <asp:Repeater ID="rptInstalacion" runat="server">
                <ItemTemplate>
                    <h3><span style="color:#01b0f1;">• </span><%# Eval("Pregunta")%><br /></h3>
                    <div>
                        <div class="faq-bg1"></div>
                        <div class="faq-bg2"><p> <%# Eval("Respuesta")%><br /></p></div>
                        <div class="faq-bg3"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>



        <div style="clear:both"></div><br><br>

        <div class="main-navbtn" style="display:none;">
            <div class="despacho-cont">
                <div id="accordion">
                    <h2><img alt="general" src="img/faq-general.png" /></h2>
                    <h2><img alt="compra" src="img/faq-compra.png" /></h2>
                    <h2><img alt="despacho" src="img/faq-despacho.png" /></h2>
                    <h2><img alt="instalacion-y-servicio-tecnico" src="img/faq-instalacion-y-servicio-tecnico.png" /></h2>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


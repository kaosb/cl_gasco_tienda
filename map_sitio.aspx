<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="map_sitio.aspx.cs" Inherits="contacto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function formatRut(valor) {
            var cont = 0, tmp_valor = "", i = 0, valor2 = "";
            for (i = 0; i < valor.length; i++) {
                if (valor.charAt(i) == "0" || valor.charAt(i) == "1" || valor.charAt(i) == "2" || valor.charAt(i) == "3" || valor.charAt(i) == "4" || valor.charAt(i) == "5" || valor.charAt(i) == "6" || valor.charAt(i) == "7" || valor.charAt(i) == "8" || valor.charAt(i) == "9" || valor.charAt(i) == "k" || valor.charAt(i) == "K") {
                    if (valor.charAt(0) != "0" && valor.charAt(0) != "k" && valor.charAt(0) != "K") {
                        valor2 = valor2 + valor.charAt(i);
                    }
                }
            }
            for (i = valor2.length - 1; i >= 0; i--) {
                if (cont == 1) {
                    tmp_valor = "-" + tmp_valor;
                }
                tmp_valor = valor2.charAt(i) + tmp_valor;
                cont++;
            }
            return tmp_valor;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Mapa del sitio
        </div> 
        <div class="int-separ"></div>
        <div class="main-navbtn">
             <div style="margin:30px 0 0 0; border:solid 1px #cccccc; height:350px; width:790px; margin-bottom:30px; padding-top:20px;">
 
             <div  style="float:left; width:260px; height:150px; margin:20px 0 0 20px;">
             <ul style="color:#eb1c2e; font:bold 20px Arial, Helvetica, sans-serif; padding-left:40px;">

            <li><span style="font:bold 15px Arial, Helvetica, sans-serif; color:#738092; line-height:20px">PRODUCTO</span></li>
                <a href="ver-categoria.aspx?f=calefaccion"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none; line-height:20px" href="#;">Calefacción.</a><br />
                <!--<a  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Cocinas y hornos.</a><br />-->
                <a href="ver-categoria.aspx?f=calefones-y-termos"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Calefones y termos.</a><br />
                <a  href="ver-categoria.aspx?f=patio-y-terraza"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Patio y terraza.</a><br />
               </ul>
   
               </div>
   
                <div  style="float:left; width:400px; height:150px; margin:20px 0 0 20px;">
             <ul style="color:#eb1c2e; font:bold 20px Arial, Helvetica, sans-serif; ">

            <li><span style="font:bold 15px Arial, Helvetica, sans-serif; color:#738092;line-height:20px">INFORMACIÓN Y CONSEJOS DE ARTEFACTOS</span></li>
                <a href="informacion-y-consejos-de-artefactos.aspx?p=1" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Modo de Instalación de producto.</a><br />
                <a href="informacion-y-consejos-de-artefactos.aspx?p=2"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Recomendaciones de uso y producto</a><br />
                <a href="informacion-y-consejos-de-artefactos.aspx?p=3" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Puesta en marcha.</a><br />
    
               </ul>
   
               </div>
   
                <div  style="float:left; width:260px; height:150px; margin:20px 0 0 20px;">
             <ul style="color:#eb1c2e; font:bold 20px Arial, Helvetica, sans-serif; padding-left:40px;">

            <li><span style="font:bold 15px Arial, Helvetica, sans-serif; color:#738092; line-height:20px">SERVICIO AL CLIENTE</span></li>
                <a href="preguntas-frecuentes.aspx"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none; line-height:20px" href="#;">Preguntas frecuentes.</a><br />
                <a href="medios-de-pago.aspx"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Medios de pagos.</a><br />
                <a href="despacho-y-costos-de-envio.aspx" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Despacho y costos de envío.</a><br />
                <a href="contacto.aspx"  style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Contacto.</a><br />
               </ul>
   
               </div>
   
                <div  style="float:left; width:400px; height:150px; margin:20px 0 0 20px;">
             <ul style="color:#eb1c2e; font:bold 20px Arial, Helvetica, sans-serif; ">

            <li><span style="font:bold 15px Arial, Helvetica, sans-serif; color:#738092;line-height:20px">SERVICIO E INSTALACIONES</span></li>
                <a href="servicios-e-instalaciones.aspx" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Instalación de Redes y Estanques de Gas.</a><br />
                <a href="servicios-e-instalaciones.aspx" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Instaladores externos.</a><br />
                <a href="servicios-e-instalaciones.aspx" style="font:normal 13px Arial, Helvetica, sans-serif; color:#738092; text-decoration:none;line-height:20px" href="#;">Servicios técnicos autorizados.</a><br />
    
               </ul>
   
               </div>
   
   
             </div>   
        </div>
    </div>
</asp:Content>


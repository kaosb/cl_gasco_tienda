<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="que_es_tienda_en_linea.aspx.cs" Inherits="que_es_tienda_en_linea" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            QUÉ ES LA TIENDA EN LÍNEA
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn" style="height:500px;">
           <div style="float:left; width:395px">
               <img src="img/que-es-la-tienda3.jpg" /> 
           </div>
           <div style="float:left; width:290px;">
            La nueva Tienda en Línea Gasco es una plataforma donde encontrarás artefactos a gas licuado, para uso residencial, disponibles para comprar en línea con cualquier medio aceptado por Transbank.<br /><br />Aquí encontrarás estufas a gas licuado, calefones y calefactores de terraza. Pronto podrás encontrar también cocinas, encimeras, hornos, entre otros accesorios.<br /><br />Comprar en la nueva tienda en línea Gasco es muy fácil, seas o no cliente.<br /><br />Para comprar no te pedimos registro alguno, solo los datos necesarios para hacer el despacho del producto a tu domicilio.<br /><br />Prueba la nueva Tienda en Línea Gasco hoy mismo.
           </div>
      
        </div>
    </div>
</asp:Content>


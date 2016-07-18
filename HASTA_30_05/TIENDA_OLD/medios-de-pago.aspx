<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="medios-de-pago.aspx.cs" Inherits="medios_de_pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Medios de Pago
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn">
            <div class="despacho-cont">
                <p>Nuestra tienda en línea Gasco permite el pago con Tarjetas de Crédito y Débito Bancarias nacionales. Las transacciones se realizan a través de Transbank.</p>
                <p><br />El pago en cuotas depende de que el banco emisor de tu tarjeta las permita.</p>
                
                <center><img alt="medios-de-pago" src="img/mediospago-tarjetas.png" style="margin:15px;" /></center>
                <div class="int-separ"></div>
            </div>
        </div>
    </div>
</asp:Content>


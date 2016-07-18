<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fracaso.aspx.cs" Inherits="fracaso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="fracaso_cont">
        <p class="fracaso-titulo">TRANSACCIÓN NO HA PODIDO SER REALIZADA</p>
        <p class="fracaso-texto">Estimado cliente, no ha sido posible procesar el pago.<br />
        Para evitar cargos duplicados recomendamos revisar los últimos movimientos de la tarjeta utilizada en esta transacción antes de repetir la compra.<br />
        Si el problema persiste contacte a su banco emisor<br /><br />
        Servicio de Atención al Cliente Gasco <strong>600 822 22 22.</strong> </p>
        <a href="<%= homeurl %>"><img alt="volver" src="img/fracaso-volver.png" /></a>
    </div>
</asp:Content>


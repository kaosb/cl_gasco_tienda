<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="despacho-y-costos-de-envio.aspx.cs" Inherits="despacho_y_costos_de_envio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Despacho y costos de envío
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn">
            <div class="despacho-cont">
                <br>
                <p>
                    <!--Las compras realizadas en nuestra tienda en línea son enviadas despachadas exclusivamente a dentro de la Región Metropolitana. 
                Este servicio es realizado por ChileExpress y en un plazo no inferior a 72 horas después de realizada la compra.-->
                Solo Región Metropolitana : <br /><br >
                Debido al tamaño y peso de algunos de los artefactos ofrecidos en esta tienda, los costos de despacho a regiones superarían en algunos casos, el valor del artefacto, por esta razón sólo vendemos y despachamos dentro de la Región Metropolitana.<br><br>
                Los costos de despachos que encontrarás al momento de la compra varían por comuna y serán sumados al precio del artefacto al momento del pago en línea. Revisa bien esta lista sólo se despacha a las comunas que en ella figuren.<br><br>
                El servicio de despacho es realizado por ChileExpress y en un plazo no inferior a 72 horas hábiles después de realizada la compra.

                    <br /><br />
                Para esto cuando compres en nuestra tienda te solicitaremos una dirección de despacho que es a la cual se enviará tu compra. 
                El despacho es seguro y sólo requerirás de alguien que reciba el producto en el domicilio. 
                La entrega es realizada dentro del  tercer día hábil siguiente a la compra, entre las 9 y las 19 hrs. 
                Por ejemplo si compras una estufa un día martes, la estarás recibiendo el día viernes de esa semana. 
                Si la compras un viernes la recibirás el miércoles de la semana siguiente.<br /><br />
                </p>
                <p></p>
                <div class="despacho-contcal">
                    <div class="calendariodespacho" style="bottom:5px;">
                        <div class="cal-relleno"></div>
                        <asp:Panel runat="server" ID="cal_lunes1">Lunes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_martes1">Martes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_miercoles1">Miércoles</asp:Panel>
                        <asp:Panel runat="server" ID="cal_jueves1">Jueves</asp:Panel>
                        <asp:Panel runat="server" ID="cal_viernes1">Viernes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_sabado1">Sábado</asp:Panel>
                        <asp:Panel runat="server" ID="cal_domingo1">Domingo</asp:Panel>
                        <div style="clear:both;"></div>
                        <div class="cal-relleno"></div>
                        <asp:Panel runat="server" ID="cal_lunes2">Lunes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_martes2">Martes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_miercoles2">Miércoles</asp:Panel>
                        <asp:Panel runat="server" ID="cal_jueves2">Jueves</asp:Panel>
                        <asp:Panel runat="server" ID="cal_viernes2">Viernes</asp:Panel>
                        <asp:Panel runat="server" ID="cal_sabado2">-</asp:Panel>
                        <asp:Panel runat="server" ID="cal_domingo2">-</asp:Panel>
                        <div style="clear:both;"></div>
                    </div>
                </div>
                <p><br /><br><br>Los datos necesarios para el despacho de los productos serán solicitados al término del proceso de compra y son los siguientes:<br /></p>

            <!--
                <div class="despacho-cuadrodatos" style="width:600px;">
                    <div class="cb" style="height:10px;"></div>
                    <div class="despacho-rowdatos"><strong>INFORMACIÓN PERSONAL:</strong></div>
                    <div class="cb" style="height:5px;"></div>
                    <div class="despacho-rowdatos">Rut</div>
                    <div class="despacho-rowdatos">Nombre</div>
                    <div class="despacho-rowdatos">Teléfono fijo y/o móvil</div>
                    <div class="despacho-rowdatos">Razón Social (solo empresas)</div>
                    <div class="despacho-rowdatos">Calle</div>
                    <div class="despacho-rowdatos">Número</div>
                    <div class="despacho-rowdatos">Comuna</div>
                    <div class="despacho-rowdatos">Departamento u Oficina</div>
                    <div class="cb" style="height:15px;"></div>
                    <div class="despacho-rowdatos"><strong>INFORMACIÓN DE DESPACHO</strong></div>
                    <div class="cb" style="height:5px;"></div>
                    <div class="despacho-rowdatos">Calle</div>
                    <div class="despacho-rowdatos">Número</div>
                    <div class="despacho-rowdatos">Comuna</div>
                    <div class="cb" style="height:10px;"></div>
                </div>
            -->

            <img src="img/infodespacho.jpg" style="margin-top:10px;margin-left:40px;">
                <div class="cb" style="height:20px;"></div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pago-tienda.aspx.cs" Inherits="pago_tienda" EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body style="background-color:#fff;">
    <div style="position: absolute; left: 0px;">
        <form id="form2" method="post" action="http://smtp.gasco.cl/WebPayGSCO/Default.aspx">
            <input name="hfVkorg" type="hidden" id="hfVkorg" value="7100" />
            <input name="hfTipoTRX" type="hidden" id="hfTipoTRX" value="6" />
            <input name="hfKCC" type="hidden" id="hfKCC" value="1006" />
            <input name="hfNumeroCliente" type="hidden" id="hfNumeroCliente" runat="server" />
            <input name="hfMontoTotal" type="hidden" id="hfMontoTotal" runat="server" />
            <div runat="server" id="prodlist"></div>
            <input name="hfUserName" type="hidden" id="hfUserName" runat="server" />
            <input name="hfUrlExito" type="hidden" id="hfUrlExito" runat="server" />
            <input name="hfUrlFracaso" type="hidden" id="hfUrlFracaso" runat="server" />
            <input name="hfUrlError" type="hidden" id="hfUrlError" runat="server" />
            <input runat="server" id='hfTarget' name='hfTarget' type='hidden' value='_parent' />
            <input id="Submit1" type="submit" value="" style="cursor: pointer; background-image: url(img/carro-pagar.png); width: 138px; height: 33px; border: none; background-color: transparent;position:absolute;top:0px;left:0px;" />
        </form>
    </div>
</body>
</html>

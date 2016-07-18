<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contacto.aspx.cs" Inherits="contacto" %>

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
            Contacto
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn">
            <div class="despacho-cont">
                <div class="contacto-p1"></div>
                <div class="contacto-p2">
                    <div class="contacto-cont">
                        <p class="contacto-titulo">Formulario de contacto</p>
                        <div class="int-separ"></div>
                        <p class="contacto-p">Completa el formulario y en pocas horas responderemos tu solicitud. Recuerda que también puedes consultar en nuestro servicio al cliente. 
                        No dudes en llamar para recibir atención inmediata a nuestro teléfono <strong>600 822 22 22</strong></p>
                        <p class="contacto-p"><strong>Los campos marcados con un <span style="color:#0fa2ff;">*</span> son obligatorios.</strong><br /><br /></p>
                        <div class="contacto-row">
                            <p class="contacto-name"><font class="reqfield">*</font>Motivo de contacto</p>
                            <asp:DropDownList ID="ddlMotivo" runat="server" Width="230"></asp:DropDownList>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Nombre</p>
                            <asp:TextBox ID="txtNombre" runat="server" Width="460" MaxLength="30"></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Apellido</p>
                            <asp:TextBox ID="txtApellido" runat="server" Width="460" MaxLength="30"></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name">N° de cliente</p>
                            <asp:TextBox ID="txtCliente" runat="server" MaxLength="8"></asp:TextBox>
                            <p class="contacto-name" style="width:124px;"><font class="reqfield">*</font>Rut (ej:12345678-9)</p>
                            <asp:TextBox ID="txtRut" runat="server" onkeyup="this.value = formatRut(this.value)" MaxLength="10"  ></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>E-Mail</p>
                            <asp:TextBox ID="txtMail" runat="server" Width="460" MaxLength="30"></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Dirección</p>
                            <asp:TextBox ID="txtDireccion" runat="server" Width="460" MaxLength="30"></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>País</p>
                            <asp:DropDownList ID="ddlPais" runat="server" Width="163" AutoPostBack="true" OnSelectedIndexChanged="fillRegiones"></asp:DropDownList>
                            <p class="contacto-name" style="width:70px;"><font class="reqfield">*</font>Región</p>
                            <asp:DropDownList ID="ddlRegion" runat="server" Width="215" AutoPostBack="true" OnSelectedIndexChanged="fillCiudades"></asp:DropDownList>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Ciudad</p>
                            <asp:DropDownList ID="ddlProvincia" runat="server" Width="163" AutoPostBack="true" OnSelectedIndexChanged="fillComunas"></asp:DropDownList>
                            <p class="contacto-name" style="width:70px;"><font class="reqfield">*</font>Comuna</p>
                            <asp:DropDownList ID="ddlComuna" runat="server" Width="215"></asp:DropDownList>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Teléfono</p>
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                            <p class="contacto-name" style="width:70px;"><font class="reqfield">*</font>Celular</p>
                            <asp:TextBox ID="txtCelular" runat="server" Width="215"></asp:TextBox>
                            <div class="cb"></div>
                            <p class="contacto-name"><font class="reqfield">*</font>Mensaje</p>
                            <asp:TextBox ID="txtMensaje" runat="server" Width="460" TextMode="MultiLine" Height="70"></asp:TextBox>
                            <div class="cb"></div>
                            <asp:ImageButton ID="ibEnviar" ImageUrl="img/contacto-enviar-btn.png" runat="server" OnClick="validaForm" />
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" style="border:none;bottom:30px;right:160px;position:absolute;"></asp:Label>
                        </div>
                        <asp:FilteredTextBoxExtender ID="ftenom" FilterMode="ValidChars" TargetControlID="txtNombre" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="fteape" FilterMode="ValidChars" TargetControlID="txtApellido" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftecli" FilterMode="ValidChars" TargetControlID="txtCliente" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="fterut" FilterMode="ValidChars" TargetControlID="txtRut" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftemai" FilterMode="ValidChars" TargetControlID="txtMail" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftedir" FilterMode="ValidChars" TargetControlID="txtDireccion" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftetel" FilterMode="ValidChars" TargetControlID="txtTelefono" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftecel" FilterMode="ValidChars" TargetControlID="txtCelular" runat="server"></asp:FilteredTextBoxExtender>
                        <asp:FilteredTextBoxExtender ID="ftemen" FilterMode="ValidChars" TargetControlID="txtMensaje" runat="server"></asp:FilteredTextBoxExtender>
                    </div>
                    
                </div>
                <div class="contacto-p3"></div>
            </div>
        </div>
    </div>
</asp:Content>


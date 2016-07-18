<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registro.aspx.cs" Inherits="registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="productos">
        <asp:Panel ID="pnlNL" runat="server">
            <div class="productos-breadcrumb">
                <asp:Label ID="lblBreadCrumb" CssClass="cat-breadcrumb" runat="server" Text=""></asp:Label>
            </div>
            <div class="int-separ"></div>
            <div class="productos-title">
                <asp:Label ID="lblNP" runat="server" Text="Ingresa tus datos"></asp:Label>
            </div>
            <div class="int-separ"></div>
            <!--<div style="width:780px;height:10px;background-color:#dedede;margin:30px 8px 10px 8px; "></div>-->
            <div class="main-navbtn">
                <div class="cat-contgeneral" style="margin-left:0px;">
                        <p style="margin:20px 10px;font-size:14px;font-weight:bold;"><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></p>
                        <asp:Panel ID="pnldatos1" CssClass="carro-nueva-direccion" runat="server" Visible="true" style="border:none;width:770px;">
                        <div style="width: 250px; float: left;">
                            <p>Nombre</p>
                            <asp:TextBox ID="txtcNombre" runat="server" Width="230" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftenombre" TargetControlID="txtcNombre" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 250px; float: left;">
                            <p>Apellido Paterno</p>
                            <asp:TextBox ID="txtcApellidop" runat="server" Width="230" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteapp" TargetControlID="txtcApellidop" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 250px; float: left;">
                            <p>Apellido Materno</p>
                            <asp:TextBox ID="txtcApellidom" runat="server" Width="230" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteapm" TargetControlID="txtcApellidom" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 250px; float: left;">
                            <p>Rut</p>
                            <asp:TextBox ID="txtcRut" runat="server" Width="230" Height="22" MaxLength="10" onkeyup="this.value = formatRut(this.value)"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fterut" TargetControlID="txtcRut" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 250px; float: left;">
                            <p>Teléfono Fijo</p>
                            <asp:TextBox ID="txtcFono" runat="server" Width="230" Height="22" MaxLength="8"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftefono" TargetControlID="txtcFono" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 250px; float: left;">
                            <p>Celular</p>
                            <asp:TextBox ID="txtcCelular" runat="server" Width="230" Height="22" MaxLength="8"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftecelular" TargetControlID="txtcCelular" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 250px; float: left;">
                            <%--<p>Razón Social</p>
                            <asp:TextBox ID="txtcRazonSocial" runat="server" Width="120" MaxLength="50"></asp:TextBox>--%>
                        </div>
                        <div style="width: 320px; float: left;">
                            <p>Correo electrónico</p>
                            <asp:TextBox ID="txtcMail" runat="server" Width="230" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftemail" TargetControlID="txtcMail" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="left: 470px; position: relative; top: 35px;float:left;">
                            <a onclick="javascript:history.back();" ><img alt="volver" src="img/exito-volver.png" style="cursor:pointer;" /></a>
                        </div>
                        <div style="left: 490px; position: relative; top: 35px;float:left;">
                            <asp:ImageButton ID="ibstep1" runat="server" ImageUrl="img/registro-continuar.jpg" OnClick="validaDatos" />
                        </div>
                        <div style="position: absolute; bottom: -22px; left: 20px;">
                            <asp:Label ID="lblErrorDatos" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                    </asp:Panel>
                    <asp:Panel ID="pnlNuevaDireccion" CssClass="carro-nueva-direccion" runat="server" Visible="false" style="border:none;width:500px;">
                        <!--<div style="width:480px;height:10px;background-color:#dedede;margin:30px 8px 10px 0px; "></div>-->
                        <div style="width: 250px; float: left;">
                            <p>Calle</p>
                            <asp:TextBox ID="txtndcalle" runat="server" Width="230" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftecalled" TargetControlID="txtndcalle" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 100px; float: left;">
                            <p>Número</p>
                            <asp:TextBox ID="txtndnumero" runat="server" Width="60" Height="22" MaxLength="6"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftenumerod" TargetControlID="txtndnumero" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 100px; float: left;">
                            <p>Depto/Oficina</p>
                            <asp:TextBox ID="txtnddepto" runat="server" Width="60" Height="22" MaxLength="6"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftedeptod" TargetControlID="txtnddepto" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="width: 250px; float: left;">
                            <p>Block/Parcela/Otro</p>
                            <asp:TextBox ID="txtndotro" runat="server" Width="80" Height="22" MaxLength="50"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteotrod" TargetControlID="txtndotro" runat="server"></asp:FilteredTextBoxExtender>
                        </div>
                        <div style="width: 200px; float: left;">
                            <p>Comuna</p>
                            <asp:DropDownList ID="ddlComunas" Height="22" Width="230" runat="server"></asp:DropDownList>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="left: 358px; position: relative; top: 10px;">
                            <asp:ImageButton ID="ibstep2" runat="server" ImageUrl="img/carro-dguardar.png" OnClick="validaDireccion"  />
                        </div>
                        <div style="position: absolute; bottom: 20px; left: 20px;">
                            <asp:Label ID="lblAddDirerror" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </div>
                        <div style="clear: both;"></div>
                    </asp:Panel>
                    <asp:Panel ID="pnlFinal" CssClass="carro-nueva-direccion" runat="server" Visible="false" style="text-align:center;border:none;width:500px;margin-left:130px;">
                        <!--<div style="width:480px;height:10px;background-color:#dedede;margin:30px 8px 10px 0px; "></div>-->
                        Ya estás registrado, para continuar haz click aquí <br /><a href="carro-de-compras.aspx"><img alt="continuar" src="img/registro-continuar.jpg" style="margin:10px;" /></a>
                    </asp:Panel>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>


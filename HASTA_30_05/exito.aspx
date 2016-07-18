<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="exito.aspx.cs" Inherits="exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 550px; margin-left: 100px;">
        <table style="display: inline-table; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="550">
            <tr>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="34" height="1" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="478" height="1" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="38" height="1" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="1" border="0" alt="" /></td>
            </tr>
            <tr>
                <td><img name="tiendaartefactos_r1_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" height="58" border="0" alt="" /></td>
                <td><img name="tiendaartefactos_r1_c2" src="http://www.gasco.cl/img/mailTienda/logo.jpg" width="478" height="58" border="0" alt="" /></td>
                <td><img name="tiendaartefactos_r1_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" height="58" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="58" border="0" alt="" /></td>
            </tr>
            <tr>
                <td><img name="tiendaartefactos_r2_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" height="20" border="0" alt="" /></td>
                <td><span style="font-size: 12px;">¡Tu compra ha sido realizada con éxito!</span></td>
                <td><img name="tiendaartefactos_r2_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" height="20" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="20" border="0" alt="" /></td>
            </tr>
            <tr>
                <td><img name="tiendaartefactos_r2_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" height="34" border="0" alt="" /></td>
                <td><span style="font-size: 14px; color: #32689e; font-weight: bold;">Resumen de Datos de Compra y Despacho:</span></td>
                <td><img name="tiendaartefactos_r2_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" height="34" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="34" border="0" alt="" /></td>
            </tr>
            <tr>
                <td><img name="tiendaartefactos_r3_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" border="0" alt="" /></td>
                <td>
                    <table style="display: inline-table; border: 1px solid #bfc2c8; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                        <tr>
                            <td colspan="2" style="background-color: #cc0000; color: #ffffff; height: 20px;"><span style="margin-left: 20px; font-weight: bold;">PRODUCTOS</span></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="display: inline-table; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                                    <tr style="background-color: #cc0000; color: #ffffff; height: 20px; font-weight: bold;">
                                        <td width="60">Cantidad</td>
                                        <td width="120">Código Producto</td>
                                        <td width="206">Descripción</td>
                                        <td width="90">Valor Producto con despacho</td>
                                    </tr>
                                    <asp:Repeater ID="rptProductos" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td width="60"><%# Eval("cantidad") %></td>
                                                <td width="120"><%# Eval("codigo") %></td>
                                                <td width="206"><%# Eval("descripcion") %></td>
                                                <td width="90" style="text-align: right;"><span style="margin-right: 10px;"><%# Eval("valor") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:Repeater ID="rptCilindros" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td width="60"><%# Eval("cantidad") %></td>
                                                <td width="120"><%# Eval("codigo") %></td>
                                                <td width="206"><%# Eval("descripcion") %></td>
                                                <td width="90" style="text-align: right;"><span style="margin-right: 10px;"><%# Eval("valor") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td><img name="tiendaartefactos_r3_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="15"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="15" border="0" alt="" /></td>
            </tr>
            <asp:Panel ID="pnlPromos" runat="server">
                <tr>
                    <td><img name="tiendaartefactos_r3_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" border="0" alt="" /></td>
                    <td>
                        <asp:Repeater ID="rptPromociones" runat="server">
                            <HeaderTemplate>
                                <table style="display: inline-table; border: 1px solid #bfc2c8; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                                <tr>
                                    <td colspan="2" style="background-color: #128bd9; color: #ffffff; height: 20px;"><span style="margin-left: 20px; font-weight: bold;">PROMOCIONES</span></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td width="200"><span style="margin-left: 20px;">Vale de descuento</span></td>
                                    <td width="276"><span style="margin-left: 20px;"><%# Eval("texto") %></span></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    
                    </td>
                    <td><img name="tiendaartefactos_r3_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" border="0" alt="" /></td>
                    <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" border="0" alt="" /></td>
                </tr>
            </asp:Panel>
            <tr>
                <td colspan="3" height="15"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="15" border="0" alt="" /></td>
            </tr>
            <tr>
                <td>
                    <img name="tiendaartefactos_r5_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" border="0" alt="" /></td>
                <td>
                    <table style="display: inline-table; border: 1px solid #bfc2c8; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                        <tr>
                            <td colspan="2" style="background-color: #cc0000; color: #ffffff; height: 25px;"><span style="margin-left: 20px; font-weight: bold;">DETALLE TRANSACCIÓN</span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Monto Pagado</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblmontopagado" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Código de autorización</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblcodigoautorizacion" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">N° Cuotas</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnumerocuotas" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Tipo Cuota</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lbltipocuotas" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Número Tarjeta</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnumerotarjeta" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Fecha Transacción</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblfechatransaccion" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Hora Transacción</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblhoratransaccion" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Tipo Transacción</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lbltipotransaccion" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Nombre Comercio</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnombrecomercio" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Sitio Web</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblsitioweb" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">N° Orden de Compra</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblordendecompra" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                    </table>
                </td>
                <td><img name="tiendaartefactos_r5_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="15"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="15" border="0" alt="" /></td>
            </tr>
<%--            <tr>
                <td>
                    <img name="tiendaartefactos_r7_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" border="0" alt="" /></td>
                <td>
                    <table style="display: inline-table; border: 1px solid #bfc2c8; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                        <tr>
                            <td colspan="2" style="background-color: #128bd9; color: #ffffff; height: 25px;"><span style="margin-left: 20px; font-weight: bold;">DATOS DEL CLIENTE</span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Rut</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblrut" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Nombre</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Razón Social</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblrazonsocial" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Teléfono Fijo</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblfonofijo" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Teléfono Móvil</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblfonomovil" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Calle</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblcalle" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Número</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnumero" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Depto/Parcela/Otro</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lbldepto" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Comuna</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblcomuna" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                    </table>
                </td>
                <td><img name="tiendaartefactos_r7_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="15"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="15" border="0" alt="" /></td>
            </tr>
            <tr>
                <td>
                    <img name="tiendaartefactos_r9_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" border="0" alt="" /></td>
                <td>
                    <table style="display: inline-table; border: 1px solid #bfc2c8; font-family: Arial; font-size: 11px; color: #363d46;" border="0" cellpadding="0" cellspacing="0" width="476">
                        <tr>
                            <td colspan="2" style="background-color: #128bd9; color: #ffffff; height: 25px;"><span style="margin-left: 20px; font-weight: bold;">DIRECCIÓN DE DESPACHO</span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Calle</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblcalled" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Número</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblnumerod" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Depto/Parcela/Otro</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lbldeptod" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Región</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblregiond" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr style="background-color: #f7f5f6;">
                            <td width="200"><span style="margin-left: 20px;">Provincia</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblprovinciad" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td width="200"><span style="margin-left: 20px;">Comuna</span></td>
                            <td width="276"><span style="margin-left: 20px;"><asp:Label ID="lblcomunad" runat="server" Text=""></asp:Label></span></td>
                        </tr>
                    </table>
                </td>
                <td><img name="tiendaartefactos_r9_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="15"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="15" border="0" alt="" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div id="facturas" runat="server">
                    </div>
                </td>
                <td></td>
            </tr>--%>
            <tr>
                <td><img name="tiendaartefactos_r2_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" height="38" border="0" alt="" /></td>
                <td><span style="font-size: 12px;">*El detalle completo de tu compra y el acceso a los documentos de venta serán enviados en unos minutos al correo electrónico ingresado por ti al momento de entregar tus datos para la compra.
                    <br /><br />*El despacho de tus productos se realizará en un plazo no inferior a 72 horas hábiles a contar de la fecha de compra.
                    </span></td>
                <td><img name="tiendaartefactos_r2_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" height="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="38" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="35"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="35" border="0" alt="" /></td>
            </tr>
            <tr>
                <td><img name="tiendaartefactos_r2_c1" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="34" height="38" border="0" alt="" /></td>
                <td><a href="<%= homeurl %>"><img alt="volver" src="img/exito-volver.png" /></a></td>
                <td><img name="tiendaartefactos_r2_c3" src="http://www.gasco.cl/img/mailTienda/blank.jpg" width="38" height="38" border="0" alt="" /></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="38" border="0" alt="" /></td>
            </tr>
            <tr>
                <td colspan="3" height="35"></td>
                <td><img src="http://www.gasco.cl/img/mailTienda/spacer.gif" width="1" height="35" border="0" alt="" /></td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>


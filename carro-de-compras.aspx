<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="carro-de-compras.aspx.cs" Inherits="carro_de_compras" %>

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
    <div class="carrodecompras">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" CssClass="cat-breadcrumb" runat="server" Text=""></asp:Label>
        </div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Carro de compras
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn carro">
            <asp:Panel ID="pnlCarro" runat="server" Visible="false" style="min-height:200px;">
                <p class="carro-subt">Paso 2 de 3</p>
                <p class="terminos-subtitulo">Productos:</p>
                <div class="carro-topprod">
                    <div class="carro-headp"></div>
                    <div style="position:relative;left:15px;">
                    <asp:GridView runat="server" ID="gvCarro" AutoGenerateColumns="false" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="carro-itemp">
                                        <div class="carro-r3"><img class="carro-img" alt="" id="img1" height="35" src="imgProductos/<%# Eval("Producto") %>.jpg" /></div>
                                        <div class="carro-r4"><asp:Label CssClass="carro-producto" ID="lblnp" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></div>
                                        <div class="carro-r5"><asp:Label CssClass="carro-preciou" ID="lblpu" runat="server" Text='<%# "$"+((long)Eval("precioUnitario")).ToString("N0") %>'></asp:Label></div>
                                        <div class="carro-r6"><asp:TextBox MaxLength="2" CssClass="carro_txtcantidad carrodecompras" ID="txtcp" runat="server" Text='<%# Eval("cantidad") %>'></asp:TextBox></div>
                                        <div class="carro-r1" style="margin-left:0px;">
                                            <asp:LinkButton CssClass="carro-btn" ID="ibUpD" runat="server" CommandArgument='<%# Eval("Producto") %>' OnCommand="actualizaProducto"><img alt="eliminar" src="img/carro_actualizar.png" /></asp:LinkButton>
                                        </div>
                                        <div class="carro-r2">
                                            <asp:LinkButton CssClass="carro-btn" ID="lbDel" runat="server" style="left:8px;" CommandArgument='<%# Eval("Producto") %>' OnCommand="eliminaProducto"><img alt="eliminar" src="img/carro_eliminar.png" /></asp:LinkButton>
                                        </div>
                                        <div class="carro-r7"><asp:Label CssClass="carro-preciot" ID="lblst" runat="server" Text='<%# "$"+((long)Eval("precioSubtotal")).ToString("N0") %>'></asp:Label></div>
                                        <asp:FilteredTextBoxExtender ID="fte" runat="server" FilterType="Numbers" TargetControlID="txtcp"></asp:FilteredTextBoxExtender>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                    <asp:Panel ID="pnlDirecciones" runat="server" Visible="false" style="margin:15px;">
                        <p class="subtitle" style="background-color:#f7f7f7;font-weight:bold;font-size:14px;text-transform:uppercase;height:30px;padding-top:15px;padding-left:20px;width:730px;border:1px solid #e5e5e5">Selecciona una dirección de despacho:</p>
                        <asp:GridView runat="server" ID="gvDirecciones" AutoGenerateColumns="false" ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="carro-itemd">
                                            <div class="carro-rd1"><asp:RadioButton ID="rdb" runat="server" Text='<%# Eval("dir_completa") %>' AutoPostBack="true" OnCheckedChanged="checkPricebyDir" /></div>
                                            <div class="carro-rd2"><%--<asp:ImageButton ID="ibde" runat="server" ImageUrl="img/carro-deditar.png" CommandArgument='<%# Eval("dir_id") %>' OnClick="editNewDir" />--%></div>
                                            <div class="carro-rd2"><%--<asp:ImageButton ID="ibdd" runat="server" ImageUrl="img/carro-deliminar.png" CommandArgument='<%# Eval("dir_id") %>' OnClick="delNewDir" />--%></div>
                                            <asp:HiddenField ID="hfcomuna" runat="server" Value='<%# Eval("dir_comuna") %>' />
                                            <asp:HiddenField ID="ibdd" runat="server" Value='<%# Eval("dir_id") %>' />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Panel ID="pnlNuevaDireccion" CssClass="carro-nueva-direccion" runat="server" Visible="false">
                            <div style="width:230px;float:left;">
                                <p>Calle</p>
                                <asp:TextBox ID="txtndcalle" runat="server" Width="200" MaxLength="90"></asp:TextBox>
                            </div>
                            <div style="width:100px;float:left;">
                                <p>Número</p>
                                <asp:TextBox ID="txtndnumero" runat="server" Width="60" MaxLength="6"></asp:TextBox>
                            </div>
                            <div style="width:120px;float:left;">
                                <p>Depto/Parcela/Otro</p>
                                <asp:TextBox ID="txtnddepto" runat="server" Width="60" MaxLength="10"></asp:TextBox>
                            </div>
                            <div style="width:200px;float:left;">
                                <p>Comuna</p>
                                <asp:DropDownList ID="ddlComunas" runat="server"></asp:DropDownList>
                            </div>
                            <div style="clear:both;"></div>
                            <div style="width:120px;float:left;margin-top:10px">
                                <asp:ImageButton ID="ibsavedir" runat="server" ImageUrl="img/carro-dguardar.png" OnClick="addNewDir" />
                            </div>
                            <div style="width:300px;float:left;margin-top:25px;margin-left:10px">
                                <asp:Label ID="lblAddDirerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                            <div style="clear:both;"></div>
                        </asp:Panel>
                        <div style="clear:both;height:15px;"></div>
                        <asp:ImageButton ID="ibdd" runat="server" ImageUrl="img/carro-dagregar.png" OnClick="nuevaDireccion" />
                    </asp:Panel>
                    <asp:Panel ID="pnlDespacho" runat="server" Visible="false">
                        <p class="carro-subt">Paso 3 de 3</p>
                        <p class="terminos-subtitulo">Cálculo de despacho:</p>
                        <div class="carro-Total">
                            <asp:Label ID="lbltotalcompra" runat="server" CssClass="carro-des1" Text=""></asp:Label>
                            <asp:Label ID="lblcostoenvio" runat="server" CssClass="carro-des2" Text=""></asp:Label>
                            <asp:Label ID="lbltotalgeneral" runat="server" CssClass="carro-des3" Text=""></asp:Label>
                        </div>
                        <div  style="position:relative;left:15px;top:15px;">
                            <p style="margin-bottom:5px;">
                                    *Esta transacción no tiene derecho a retracto. <br>
                                    **Esta venta genera boleta electrónica de venta. <br>
                                    Si requiere factura escríbanos a tienda@gasco.cl antes de comprar.
                            </p>
                            <asp:CheckBox ID="cbterminos" AutoPostBack="true" OnCheckedChanged="validaterminos" runat="server" />
                        </div>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlPago" runat="server" Visible="false" style="margin-bottom:50px;">
                        <iframe frameborder="0" scrolling="no" src="pago-tienda.aspx" width="440" height="200" style="margin-top:20px;position:relative;left:15px;top:20px;"></iframe>
                    </asp:Panel>
                    <asp:Panel ID="pnlPago2" runat="server" Visible="false" style="margin-bottom:50px;">
                        <div style="background-image:url(img/carro-pagar2.png);width:138px;height:33px;cursor:not-allowed;position:relative;left:15px;top:20px; margin: 20px 0px;"></div>
                    </asp:Panel>
            </div>
            </asp:Panel>
            <asp:Panel ID="pnlSP" runat="server" Visible="false" style="min-height:200px;">
                El carro de compras está vácio, debes agregar un producto para continuar.
            </asp:Panel>
            <asp:Panel style="min-height:500px;" ID="pnlNotLogged" runat="server">
                <p class="carro-subt">PASO 1 de 3</p>
                <div class="carronl-left">
                    <div class="carrosepar"></div>
                    <p>Si ya eres cliente Gasco, granel o medidor o ya te registraste, ingresa tu RUT para continuar.</p>
                    <p style="margin:15px;margin-bottom:0;">Rut <asp:TextBox ID="txtCCRut" runat="server" MaxLength="10" onkeyup="this.value = formatRut(this.value)" onkeydown="return (event.keyCode!=13);" OnTextChanged="loginCarro"></asp:TextBox></p>
                    <asp:FilteredTextBoxExtender ID="fterut" runat="server" TargetControlID="txtCCRut"></asp:FilteredTextBoxExtender>
                    <asp:Label ID="loginerror" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                    <asp:ImageButton ID="ibIngresar" runat="server" ImageUrl="img/carro-ingresar.png" OnClick="loginCarro" />
                </div>
                <div class="carronl-right">
                    <div class="carrosepar"></div>
                    <p>Si no eres cliente Gasco regístrate aquí para continuar.</p>
                    <a href="registro.aspx" style="bottom:36px;margin-left:80px;"><img alt="registro" src="img/carro-registrar.png" /></a>
                </div>
                <div style="clear:both;"></div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


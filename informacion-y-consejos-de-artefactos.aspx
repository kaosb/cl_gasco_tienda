<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="informacion-y-consejos-de-artefactos.aspx.cs" Inherits="informacion_y_consejos_de_artefactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function overIMG(idb) {
            return;
            switch (idb) {
                case 1:
                    $('#<%=ibb1.ClientID%>').attr('src', 'img/consejos-instalacion-pruducto-btn.png');
                    break;
                case 2:
                    $('#<%=ibb2.ClientID%>').attr('src', 'img/consejos-recomendaciones-de-uso-btn.png');
                    break;
                case 3:
                    $('#<%=ibb3.ClientID%>').attr('src', 'img/consejos-puesta-en-marcha-btn.png');
                        break;
            }
        }
        function outIMG(idb) {
            return;
            switch (idb) {
                case 1:
                    $('#<%=ibb1.ClientID%>').attr('src', 'img/consejos-instalacion-pruducto-btn0.png');
                    break;
                case 2:
                    $('#<%=ibb2.ClientID%>').attr('src', 'img/consejos-recomendaciones-de-uso-btn0.png');
                    break;
                case 3:
                    $('#<%=ibb3.ClientID%>').attr('src', 'img/consejos-puesta-en-marcha-btn0.png');
                    break;
            }
        }
        function showhide(cn, cid) {
            var thisclass = $('#' + cid).attr('class');
            var nclass = thisclass + 'a';
            var sclass = thisclass.substr(0, thisclass.length - 1);
            if ($('.' + cn).is(":visible")) {
                $('.' + cn).fadeOut(0, function () {
                    $('#' + cid).attr('class', sclass);
                });
            } else {
                $('.' + cn).fadeIn(0, function () {
                    $('#' + cid).attr('class', nclass);
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <div class="productos-breadcrumb">
            <asp:Label ID="lblBreadCrumb" runat="server" Text=""></asp:Label></div>
        <div class="int-separ"></div>
        <div class="productos-title">
            Información y consejos de artefactos
        </div>
        <div class="int-separ"></div>
        <div class="main-navbtn" style="min-height:600px;">
            <div class="despacho-cont" style="width:789px;background-image:url(img/consejos-bg.png);height:113px;margin:5px 0;">
                <div class="consejosrow" style="margin:0;">
                    <asp:ImageButton ID="ibb1" onmouseover="overIMG(1);" onmouseout="outIMG(1);" ImageUrl="img/consejos-instalacion-pruducto-btn.png" runat="server" CommandArgument="pnlInstalacion" OnClick="showPanel" />
                </div>
                <div class="consejosrow">
                    <asp:ImageButton ID="ibb2" onmouseover="overIMG(2);" onmouseout="outIMG(2);" ImageUrl="img/consejos-recomendaciones-de-uso-btn0.png" runat="server" CommandArgument="pnlRecomendaciones" OnClick="showPanel" />
                </div>
                <div class="consejosrow">
                    <asp:ImageButton ID="ibb3" onmouseover="overIMG(3);" onmouseout="outIMG(3);" ImageUrl="img/consejos-puesta-en-marcha-btn0.png" runat="server" CommandArgument="pnlPuestaenMarcha" OnClick="showPanel" />
                </div>
                <div class="int-separ"></div>
            </div>
            <asp:Panel ID="pnlInstalacion" runat="server">
                <p class="subtitle" style="font-size:20px;font-weight:bold;margin-top:20px;">MODO DE INSTALACIÓN DE PRODUCTO</p>
                <div class="int-separ"></div>
                <div class="consejos-t1" id="c-t1" onclick="showhide('s-t1', 'c-t1');"></div>
                <div class="consejoscon1 s-t1">
                    <img src="img/consejos-c1.png" alt="consejos1" style="margin:20px;" />
                </div>
                <div class="consejos-t2" id="c-t2" onclick="showhide('s-t2', 'c-t2');"></div>
                <div class="consejoscon2 s-t2">
                    <img src="img/consejos-c2.png" alt="consejos2" style="margin:20px;" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlRecomendaciones" runat="server" Visible="false">
                <p class="subtitle" style="font-size:20px;font-weight:bold;margin-top:20px;">RECOMENDACIONES DE USO Y CUIDADO</p>
                <div class="int-separ"></div>
                <img src="img/consejos-c3.png" alt="consejos3" style="margin:20px;" />
            </asp:Panel>
            <asp:Panel ID="pnlPuestaenMarcha" runat="server" Visible="false">
                <p class="subtitle" style="font-size:20px;font-weight:bold;margin-top:20px;">PUESTA EN MARCHA</p>
                <div class="int-separ"></div>
                <div class="consejos-t1" id="c-t3" onclick="showhide('s-t3', 'c-t3');"></div>
                <div class="consejoscon1 s-t3">
                    <img src="img/consejos-c4.png" alt="consejos4" style="margin:20px;" />
                </div>
                <div class="consejos-t2" id="c-t4" onclick="showhide('s-t4', 'c-t4');"></div>
                <div class="consejoscon2 s-t4">
                    <img src="img/consejos-c5.png" alt="consejos5" style="margin:20px;" />
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="getProductInfo.aspx.cs" Inherits="getProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="productos">
        <asp:Repeater ID="rpInfo" runat="server">
            <ItemTemplate>
                <div style="border:1px solid #5E6D81;">
                    <ul>
                        <li>Producto: <%# Eval("prod") %></li>
                        <li>Descripción: <%# Eval("desc") %></li>
                        <li>Encode: <%# Eval("enco") %></li>
                        <li><a href="ver-producto.aspx?p=<%# Eval("enco") %>" target="_blank">Ver producto</a></li>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


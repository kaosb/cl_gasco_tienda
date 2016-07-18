<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/jquery.bxslider.min.js"></script>
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            setmySlide();
        });
        function setmySlide() {
            $('.bxslider').bxSlider({
                auto: true,
                pause: 5000
            });
        }

        $(document).ready(function () {
            var layer = localStorage.getItem("layerCBVBvisto");
            if (layer != 4) {
                //mostrarLayerRegistro();
            }

           // abrirlightbox();
        });
    </script>
    <style type="text/css">

        .bx-pager{
            left:440px !important;


        }



    </style>


    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   
    

    <div id="homeSlide" class="main-navbtn" style="width:948px;">
        <!--<ul class="bxslider">-->
           
            <!--<li> <div style="position:absolute; top:0px; left:0px; width:948px; height:400px; cursor:pointer;" onClick="location.href='http://tienda.gasco.cl/ver-categoria.aspx?f=calefaccion'"></div>
                <img alt="" src="homeSlide/banner-estufas.jpg" />
            </li>-->
           <!--<li>-->
                <div style="position:absolute; top:0px; left:0px; width:948px; height:400px; cursor:pointer;" onClick="location.href='http://tienda.gasco.cl/ver-producto.aspx?p=PATIO_PH01'"></div>
            <img alt="" src="homeSlide/banner-piramidal2.jpg" />
            <!--</li>  -->
            <!-- <li>
                <div style="position:absolute; top:0px; left:0px; width:948px; height:400px; cursor:pointer;" onClick="location.href='http://tienda.gasco.cl/aviso.aspx'"></div>
            <img alt="" src="homeSlide/Banner-tienda-gasco-thermax.png" /></li>  -->
        </ul> 
    </div>
    
    <!--
    <div class="main-navbtn" style="width:948px;">
       
        <img alt="" src="homeSlide/banner-estufas.jpg" />
    </div> 
    -->


    <div class="cb"></div>
    <div class="main-navbtn">
        <div class="homeinfolinks">
            <a href="informacion-y-consejos-de-artefactos.aspx">
                <div style="top: 7px; position: absolute; left: 0px; width: 230px; height: 89px;"></div>
                <div style="position: absolute; width: 100px; height: 100px; left: 154px; top: 23px;"></div>
            </a>
            <a href="medios-de-pago.aspx">
                <div style="top: 7px; position: absolute; height: 89px; left: 275px; width: 207px;"></div>
                <div style="position: absolute; width: 100px; height: 100px; left: 400px; top: 23px;"></div>
            </a>
            <a href="servicios-e-instalaciones.aspx">
                <div style="top: 7px; position: absolute; left: 522px; width: 230px; height: 89px;"></div>
                <div style="position: absolute; width: 100px; height: 100px; left: 675px; top: 23px;"></div>
            </a>
        </div>
    </div>
</asp:Content>


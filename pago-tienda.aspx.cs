using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class pago_tienda : System.Web.UI.Page
{
    shopingCart cart = new shopingCart();
    products prods = new products();

    
    private struct misproductos
    {
        public string counting { get; set; }
        public string codigo { get; set; }
        public string cantidad { get; set; }
        public string valor { get; set; }
        public string final { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        shopingCart.detalleCarro _detalle = cart.getCartPrice();
        hfNumeroCliente.Value = HttpContext.Current.Session["idcliente"].ToString();
        hfMontoTotal.Value = _detalle.totalFinal.ToString();
        hfUserName.Value = HttpContext.Current.Session["nombrecliente"].ToString();
        hfUserName.Value = HttpContext.Current.Session["rutcliente"].ToString();
        hfUrlExito.Value = prods.homeUrl + "/exito.aspx";
        hfUrlFracaso.Value = prods.homeUrl + "/fracaso.aspx";
        hfUrlError.Value = prods.homeUrl + "/fracaso.aspx";
//        form2.Action = "http://smtp.gasco.cl/WebPayGSCO/Default.aspx";//prod
//        form2.Action = "http://smtp.gasco.cl/WebPayGSCOTest/Default.aspx";//dev
        prodlist.InnerHtml = getProdList(_detalle.productos);
    }
    string getProdList(List<shopingCart.productosCarro> p)
    {
        string ret = null;
        int i = 1;
        foreach (shopingCart.productosCarro q in p)
        {
            string value = q.Producto + ";" + q.Nombre + ";" + q.cantidad.ToString() + ";" + (q.fleteUnitario + q.precioUnitario).ToString();
            ret += "<input type='hidden' id='Producto0" + i + "' name='Producto0" + i + "' value='" + value + "' />";
            i++;
        }
        return ret;
    }
}
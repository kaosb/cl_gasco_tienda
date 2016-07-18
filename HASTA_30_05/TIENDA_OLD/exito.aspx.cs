using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exito : System.Web.UI.Page
{
    shopingCart cart = new shopingCart();
    products prods = new products();
    cliente client = new cliente();
    webpay.qa.WebPayGascoServ wswp = new webpay.qa.WebPayGascoServ();
    tienda.qa.SrvGCOksk ws = new tienda.qa.SrvGCOksk();
    public string homeurl = "";
    private struct pdata
    {
        public string cantidad { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        homeurl = prods.homeUrl;
        getDatosCompra();
        getDatosTransaccion();
        leftpanel();
        if (validaCompra())
        {
            realizaCompra();
            cart.clearCart();
        }
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
    private void getDatosTransaccion()
    {
        try
        {
            string guid = Request.Form["gid"];
            string seid = Request.Form["sessionid"];
            webpay.qa.TBKDataExito rr = wswp.GetDataExito(long.Parse(seid), guid);
            lblmontopagado.Text = rr.TBK_MONTO.ToString("N0");
            lblcodigoautorizacion.Text = rr.Cod_Autoriza;
            lblnumerocuotas.Text = rr.Cuotas.ToString();
            lbltipocuotas.Text = rr.TBK_TIPO_PAGO_GLOSA;
            lblnumerotarjeta.Text = rr.TBK_FINAL_NUMERO_TARJETA.ToString();
            lblfechatransaccion.Text = rr.TBK_FECHA_TRANSACCION;
            lblhoratransaccion.Text = rr.TBK_HORA_TRANSACCION;
            lbltipotransaccion.Text = rr.TBK_TIPO_PAGO_GLOSA;
            lblnombrecomercio.Text = "Gasco GLP S.A.";
            lblsitioweb.Text = "tienda.gasco.cl";
            lblordendecompra.Text = rr.TBK_ORDEN_COMPRA.ToString();
            getDatosPersonales(rr.UserName);
        }
        catch
        {
        }

    }
    private void getDatosCompra()
    {
        try
        {
            string guid = Request.Form["gid"];
            string seid = Request.Form["sessionid"];
            List<webpay.qa.TBKProducto> rr = wswp.GetVentaProducto(long.Parse(seid), guid).ToList();
            List<pdata> pd = new List<pdata>();
            foreach (webpay.qa.TBKProducto p in rr)
            {
                pdata d = new pdata();
                d.cantidad = p.Cantidad.ToString();
                d.codigo = p.CodigoProducto;
                d.descripcion = p.Descripcion;
                d.valor = p.ValorAplicado.ToString("N0");
                pd.Add(d);
            }
            getDatosPromocion(pd);
            rptProductos.DataSource = pd;
            rptProductos.DataBind();
        }
        catch
        {
        }
    }
    public struct promos
    {
        public string tipo { get; set; }
        public string texto { get; set; }
        public long valor { get; set; }
    }
    private void getDatosPromocion(List<pdata> pd)
    {
        List<products.ProducData> pl = prods.getAllProducts();
        List<promos> prom = new List<promos>();
        List<pdata> cil = new List<pdata>();
        bool haypromo = false;
        foreach (pdata d in pd)
        {
            foreach (products.ProducData prodd in pl)
            {
                if (d.codigo == prodd.codigo)
                {
                    if (prodd.descuento != "")
                    {
                        for (int i = 1; i <= int.Parse(d.cantidad); i++)
                        {
                            promos cr = new promos();
                            cr.tipo = prodd.descuento;
                            cr.valor = long.Parse(prodd.descuentovalor);
                            cr.texto = cr.tipo + " $" + cr.valor.ToString("N0");
                            prom.Add(cr);
                            haypromo = true;
                        }
                    }
                    if (prodd.valecil != "")
                    {
                        pdata cp = new pdata();
                        cp.cantidad = d.cantidad;
                        cp.codigo = prodd.valecil;
                        cp.descripcion = prodd.valeciltexto;
                        cp.valor = "0";
                        cil.Add(cp);
                        haypromo = true;
                    }
                }
            }
        }
        pnlPromos.Visible = haypromo;
        rptCilindros.DataSource = cil;
        rptCilindros.DataBind();
        rptPromociones.DataSource = prom;
        rptPromociones.DataBind();
    }
    private void getDatosDespacho(string nc)
    {
        //try
        //{
        //    string dirid = HttpContext.Current.Session["activedirid"].ToString();
        //    cliente.direccionesCliente dc = client.getDirecciones(nc);
        //    foreach (cliente.datoDireccion d in dc.Direcciones)
        //    {
        //        if (d.dir_id == dirid)
        //        {
        //            lblcalled.Text = d.dir_calle;
        //            lblnumerod.Text = d.dir_numero.ToString();
        //            lbldeptod.Text = d.dir_depto;
        //            lblregiond.Text = d.dir_region;
        //            lblprovinciad.Text = d.dir_provincia;
        //            lblcomunad.Text = d.dir_comuna;
        //        }
        //    }
        //}
        //catch
        //{
        //}
    }
    private void getDatosPersonales(string rut)
    {
        //try
        //{
        //    cliente.datosClientes dc = client.checkUserbyRut(rut);
        //    lblrut.Text = rut;
        //    lblnombre.Text = dc.Cliente.nombres;
        //    lblrazonsocial.Text = dc.Cliente.razonSocial;
        //    lblfonofijo.Text = dc.Cliente.telefono;
        //    lblfonomovil.Text = dc.Cliente.celular;
        //    lblcalle.Text = dc.Direccion.dir_calle;
        //    lblnumero.Text = dc.Direccion.dir_numero.ToString();
        //    lbldepto.Text = dc.Direccion.dir_depto;
        //    lblcomuna.Text = dc.Direccion.dir_comuna;
        //    string numc = dc.Cliente.ncliente;
        //    getDatosDespacho(numc);
        //}
        //catch
        //{
        //}
    }
    private void realizaCompra()
    {
        try
        {
            DateTime now = DateTime.Now;
            string tipp = "D";
            HttpContext.Current.Session["webpay"] = Request.Form["sessionid"];
            string dirid = HttpContext.Current.Session["activedirid"].ToString();
            string guid = Request.Form["gid"];
            string seid = Request.Form["sessionid"];
            webpay.qa.TBKDataExito datowebpay = wswp.GetDataExito(long.Parse(seid), guid);
            webpay.qa.TBKProducto[] datoproducto = wswp.GetVentaProducto(long.Parse(seid), guid);
            tienda.qa.ZKSK_CREA_VENTAParam cvp = new tienda.qa.ZKSK_CREA_VENTAParam();
            if (datowebpay.TBK_TIPO_PAGO == "VC") { tipp = "C"; }
            cvp.I_CODCLIENTE = datowebpay.Num_Cliente;
            cvp.I_DIRECCION_ID = dirid;
            tienda.qa.ZKSK_WEBPAY wp = new tienda.qa.ZKSK_WEBPAY();
            wp.COD_AUTORIZACION = datowebpay.Cod_Autoriza;
            wp.FECHA = datowebpay.FechaServidor.ToString();
            wp.HORA = now.ToString("HHmmss");
            wp.MONTO = datowebpay.TBK_MONTO.ToString();
            wp.NRO_TARJETA = datowebpay.TBK_FINAL_NUMERO_TARJETA;
            wp.TBK_CREDEB = tipp;
            wp.UNIQUEID = "";
            wp.NRO_CUOTAS = datowebpay.Cuotas;
            wp.TIPO_PAGO = datowebpay.TBK_TIPO_PAGO;
            wp.TIPO_TRANSACCION = datowebpay.TBK_TIPO_TRANSACCION;
            cvp.I_PAGO_WEBPAY = wp;
            List<tienda.qa.ZKSK_COMPRA_PRODUCTOS> lcp = new List<tienda.qa.ZKSK_COMPRA_PRODUCTOS>();
            foreach (webpay.qa.TBKProducto tp in datoproducto)
            {
                tienda.qa.ZKSK_COMPRA_PRODUCTOS cp = new tienda.qa.ZKSK_COMPRA_PRODUCTOS();
                cp.CANTIDAD = tp.Cantidad;
                cp.PRODUCTO = tp.CodigoProducto;
                lcp.Add(cp);
            }
            cvp.I_T_PRODUCTO = lcp.ToArray();
            tienda.qa.ZKSK_CREA_VENTARet ret = ws.ZKSK_CREA_VENTA(cvp);
            if (ret.Retorno.Trim() == "")
            {
                //if (ret.O_FACTURA != "")
                //{
                //    facturas.InnerHtml = "<a href='descarga-factura.ashx?doc=" + ret.O_FACTURA  + "' target='_blank' style='margin-left: 0px;'><img alt='factura' src='http://www.gasco.cl/img/mailTienda/factura.jpg' /></a>";
                //}
                //if (ret.O_FACTURA_VALE != "")
                //{
                //    facturas.InnerHtml += "<a href='descarga-factura.ashx?doc=" + ret.O_FACTURA_VALE  + "' target='_blank' style='margin-left: 15px;'><img alt='factura' src='http://www.gasco.cl/img/mailTienda/vales.jpg' /></a>";
                //}
                //lblError.Text = "factura: " + ret.O_FACTURA + " factura vales: " + ret.O_FACTURA_VALE;
            }
            else
            {
                lblError.Text = ret.Retorno + "_" + ret.Mensaje;
            }
        }
        catch (Exception ex)
        {
        }
    }
    private bool validaCompra()
    {
        bool pp = false;
        string seid = Request.Form["sessionid"];
        string webp = null;
        if (HttpContext.Current.Session["webpay"] != null)
        {
            webp = HttpContext.Current.Session["webpay"].ToString();
            pp = false;
        }
        if (webp != seid)
        {
            pp = true;
        }
        return pp;
    }
}
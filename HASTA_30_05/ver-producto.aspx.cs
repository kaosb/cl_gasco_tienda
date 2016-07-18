using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ver_producto : System.Web.UI.Page
{
    shopingCart carro = new shopingCart();
    cypher _mc = new cypher();
    products productos = new products();
    contact cont = new contact();
    tienda.qa.SrvGCOksk _wsv = new tienda.qa.SrvGCOksk();

    protected void Page_Load(object sender, EventArgs e)
    {
        disableLeftPnl();
        fillCaracteristicas();
        getNombreProducto();
        if (IsPostBack)
        {
            ClientScriptManager csm = Page.ClientScript;
            csm.RegisterStartupScript(this.GetType(), "asd", "initGal();", true);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "asd", "initGal()", true);
        }
        leftpanel();
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
    private void disableLeftPnl()
    {
        Panel _mp = (Panel)Master.FindControl("mPnlPrice");
        _mp.Enabled = false;
    }
    private void fillCaracteristicas()
    {
        string p = _mc.Decrypt(Request.QueryString["p"], "r5b1bo4u");
        rpCaracteristicas.DataSource = productos.getCaracteristicas(p);
        rpCaracteristicas.DataBind();
    }
    private void getNombreProducto()
    {
        string homeUrl = productos.homeUrl;
        string _pn = _mc.Decrypt(Request.QueryString["p"], "r5b1bo4u");
        string _bc = null;
        lblDescuento.InnerHtml = null;
        bool found = false;
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam _cpp = new tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam();
        _cpp.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _r = _wsv.ZKSK_CONSULTA_PRODUCTOS(_cpp);
        bool exist = false;
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _r.O_T_PRODUCTO)
        {
            if (_p.PRODUCTO == _pn)
            {
                lblNP.Text = _p.DESCRIPCION;
                imgLogo.ImageUrl = productos.getImgbyDesc(_p.DESCRIPCION);
                imgProd.ImageUrl = "imgProductos/" + _pn + ".jpg";
                imgProd.Attributes.Add("data-zoom-image", "imgProductos/" + _pn + "l1.jpg");
                //imgLogo.ImageUrl = "imgProductos/" + _pn + "-logo.png";
                getPrecio(_p.PRECIO);
                getStock(_p.STOCK);
                if (_p.VALE_CIL_DESC.Trim().Length > 0)
                {
                    lblDescuento.InnerHtml += "<p class='promo'>Gratis con esta compra:<br/></p><div class='p1'></div><div class='p2'>";
                    lblDescuento.InnerHtml += "<p style='margin-left:10px;'>• " + cont.capitalizeMe(_p.VALE_CIL_DESC) + "</p>";
                    exist = true;
                }
                if (_p.VALE_DSCTO.Trim().Length > 0)
                {
                    lblDescuento.InnerHtml += "<p style='margin-left:10px;'>• " + cont.capitalizeMe(_p.VALE_DSCTO) + " $" + long.Parse(_p.VALE_DSCTO_MNT).ToString("N0") + "</p>";
                    exist = true;
                }
                found = true;
            }
        }
        if (exist)
        {
            lblDescuento.InnerHtml += "</div><div class='p3'></div>";
        }
        foreach (tienda.qa.ZKSK_JERARQUIA_RFC _jr in _r.O_T_JERARQUIA)
        {
            if (_jr.PRODUCTO == _pn)
            {
                _bc = "<span><a href='" + homeUrl + "'>Home</a></span> | <a href='ver-categoria.aspx?f=" + _jr.FAMILIA + "'>" + productos.prodDictionary(_jr.FAMILIA) + "</a>" + " | " + "<a href='ver-categoria.aspx?c=" + _jr.CATEGORIA + "'>" + productos.prodDictionary(_jr.CATEGORIA) + "</a>" + " | " + "<span class='current-bc'><a href='ver-categoria.aspx?s=" + _jr.SUBCATEGORIA + "'>" + productos.prodDictionary(_jr.SUBCATEGORIA) + "</a></span>";
                lblBreadCrumb.Text = _bc.ToLower();
                lblBreadCrumbnf.Text = _bc.ToLower();
            }
        }
        if (!found)
        {
            pnlNotFound.Visible = !found;
            pnlProduct.Visible = found;
        }
    }
    private void getPrecio(string precio)
    {
        try
        {
            if (long.Parse(precio) > 0)
            {
                lblPrecio.Text = "<span style='font-size:35px;'>$</span>" + long.Parse(precio).ToString("N0");
            }
            else
            {
                lblPrecio.Text = "No hay Registro de Precio";
                lblPrecio.Font.Size = new FontUnit("12px");
                ibAddToCart.ImageUrl = "img/productos_addcartna.png";
                ibAddToCart.Style.Add("cursor", "not-allowed");
                ibAddToCart.Enabled = false;
            }
        }
        catch
        {
            lblPrecio.Text = "No hay Registro de Precio";
            lblPrecio.Font.Size = new FontUnit("12px");
            ibAddToCart.ImageUrl = "img/productos_addcartna.png";
            ibAddToCart.Style.Add("cursor", "not-allowed");
            ibAddToCart.Enabled = false;
        }
    }
    private void getStock(string stock)
    {
        try
        {
            if (int.Parse(stock) > 0)
            {
                imgStock.ImageUrl = "img/productos_stockd.png";
            }
            else
            {
                imgStock.ImageUrl = "img/productos_stockn.png";
                ibAddToCart.ImageUrl = "img/productos_addcartna.png";
                ibAddToCart.Style.Add("cursor", "not-allowed");
                ibAddToCart.Enabled = false;
            }
        }
        catch
        {
            imgStock.ImageUrl = "img/productos_stock.png";
            ibAddToCart.ImageUrl = "img/productos_addcartna.png";
            ibAddToCart.Style.Add("cursor", "not-allowed");
            ibAddToCart.Enabled = false;
        }
    }
    public void addToCart(object sender, EventArgs e)
    {
        string _pn = _mc.Decrypt(Request.QueryString["p"], "r5b1bo4u");
        shopingCart.prodRow _prow = new shopingCart.prodRow();
        products.ProducData _pdata = productos.getProductData(_pn);
        _prow.codigo = _pn;
        _prow.cantid = 1;
        _prow.nombre = _pdata.nombre;
        _prow.precio = _pdata.precio;
        carro.addProduct(_prow);
        getCarro();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sap", "showAddProduct();", true);
    }
    private void getCarro()
    {
        DataTable _d = carro.getCart();
        int _items = 0;
        foreach (DataRow p in _d.Rows)
        {
            _items += int.Parse(p["cantid"].ToString());
        }
        Label lblCartCount = (Label)Master.FindControl("lblCartCount");
        lblCartCount.Text = _items.ToString();
    }
    public void showDespacho(object sender, EventArgs e)
    {
        HiddenField _ib = (HiddenField)Master.FindControl("hfDesp");
        _ib.Value = Request.QueryString["p"];
        DropDownList _dl = (DropDownList)Master.FindControl("dcalcom");
        _dl.ClearSelection();
        Panel _p = (Panel)Master.FindControl("pnlDespacho");
        _p.Visible = true;
    }
}
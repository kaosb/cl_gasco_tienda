using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ver_categoria : System.Web.UI.Page
{
    shopingCart carro = new shopingCart();
    cypher _mc = new cypher();
    products productos = new products();
    tienda.qa.SrvGCOksk _wsv = new tienda.qa.SrvGCOksk();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string familia = Request.QueryString["f"];
            string categoria = Request.QueryString["c"];
            string subcategoria = Request.QueryString["s"];
            if (familia != null)
            {
                getProdbyFam(familia);
                filterByPrice();
            }
            else if (categoria != null)
            {
                getProdbyCat(categoria);
                filterByPrice();
            }
            else if (subcategoria != null)
            {
                getProdbySubcat(subcategoria);
                filterByPrice();
            }
            else
            {
                pnlProduct.Visible = false;
                pnlNotFound.Visible = true;
            }
            
        }
    }
    private List<products.ProducData> sortThis(List<products.ProducData> pd)
    {
        products.sortProductos sp = new products.sortProductos();
        pd.Sort(sp);
        return pd;
    }
    private void filterByPrice()
    {
        string thisuri = Request.Url.PathAndQuery;
        try
        {
            if (Request.QueryString["pf"] != null && Request.QueryString["pt"] != null)
            {
                bool isvalid = false;
                long staPrice = long.Parse(Request.QueryString["pf"]);
                long endPrice = long.Parse(Request.QueryString["pt"]);
                List<products.ProducData> _fp = new List<products.ProducData>();
                List<products.ProducData> _tpr = rptProductos.DataSource as List<products.ProducData>;
                foreach (products.ProducData _tp in _tpr)
                {
                    if (_tp.precio > staPrice && _tp.precio <= endPrice)
                    {
                        _fp.Add(_tp);
                        isvalid = true;
                    }
                }
                if (isvalid)
                {
                    rptProductos.DataSource = sortThis(_fp);
                    rptProductos.DataBind();
                }
                else
                {
                    getBCNF();
                    lblBreadCrumbnf.Text += " | <span class='current-bc'><a href='" + thisuri + "' style='text-transform:none;'>Precio entre $" + staPrice.ToString("N0") + " y $" + endPrice.ToString("N0") + "</a></span>";
                    pnlNotFound.Visible = !isvalid;
                    pnlProduct.Visible = isvalid;
                }
                lblBreadCrumb.Text += " | <span class='current-bc'><a href='" + thisuri + "' style='text-transform:none;'>Precio entre $" + staPrice.ToString("N0") + " y $" + endPrice.ToString("N0") + "</a></span>";
            }
        }
        catch
        {
            getBCNF();
            lblBreadCrumbnf.Text += " | <span class='current-bc'><a href='" + thisuri + "' style='text-transform:none;'>Precio entre $" + Request.QueryString["pf"] + " y $" + Request.QueryString["pt"] + "</a></span>";
            pnlNotFound.Visible = true;
            pnlProduct.Visible = false;
        }
    }
    private void buscarCat(List<products.ProducData> plist)
    {
        products.subcat sc = new products.subcat();
        List<products.valores> catf = new List<products.valores>();
        string linkfam = "";
        foreach (products.ProducData pd in plist)
        {
            products.valores cat = new products.valores();
            cat.texto = productos.prodDictionary(pd.categoria);
            cat.uri = "?c=" + pd.categoria;
            catf.Add(cat);
            linkfam = pd.familia;
        }
        sc.texto = catf.Distinct().ToList();
        LinkButton lb = (LinkButton)Master.FindControl("c1");
        lb.CommandArgument = "?f=" + linkfam;
        Repeater rptc = (Repeater)Master.FindControl("rptCat");
        Panel pnlc = (Panel)Master.FindControl("pnlCat");
        rptc.DataSource = sc.texto;
        rptc.DataBind();
        pnlc.Visible = true;
    }
    private void buscarsubCat(List<products.ProducData> plist)
    {
        products.subcat sc = new products.subcat();
        List<products.valores> catf = new List<products.valores>();
        string linkcat = "";
        foreach (products.ProducData pd in plist)
        {
            products.valores cat = new products.valores();
            cat.texto = productos.prodDictionary(pd.subcat);
            cat.uri = "?s=" + pd.subcat;
            catf.Add(cat);
            linkcat = pd.categoria;
        }
        sc.texto = catf.Distinct().ToList();
        LinkButton lb = (LinkButton)Master.FindControl("sc1");
        lb.CommandArgument = "?c=" + linkcat;
        Repeater rptc = (Repeater)Master.FindControl("rptSubcat");
        Panel pnlc = (Panel)Master.FindControl("pnlSubcat");
        rptc.DataSource = sc.texto;
        rptc.DataBind();
        pnlc.Visible = true;
    }
    private void getProdbyFam(string value)
    {
        try
        {
            lblNP.Text = productos.prodDictionary(value);
            products.ProducList prodFamilia = productos.getProductDataByFam(value);
            lblBreadCrumb.Text = prodFamilia.breadCrumb.ToLower();
            pnlProduct.Visible = prodFamilia.isValid;
            pnlNotFound.Visible = !prodFamilia.isValid;
            if (prodFamilia.isValid)
            {
                rptProductos.DataSource = sortThis(prodFamilia.products);
                rptProductos.DataBind();
                buscarCat(prodFamilia.products);
                buscarsubCat(prodFamilia.products);
            }
        }
        catch(Exception ex)
        {
            pnlProduct.Visible = false;
            pnlNotFound.Visible = true;
        }
    }
    private void getProdbyCat(string value)
    {
        try
        {
            lblNP.Text = productos.prodDictionary(value);
            products.ProducList prodFamilia = productos.getProductDataByCat(value);
            lblBreadCrumb.Text = prodFamilia.breadCrumb.ToLower();
            pnlProduct.Visible = prodFamilia.isValid;
            pnlNotFound.Visible = !prodFamilia.isValid;
            if (prodFamilia.isValid)
            {
                rptProductos.DataSource = sortThis(prodFamilia.products);
                rptProductos.DataBind();
                buscarCat(prodFamilia.products);
                buscarsubCat(prodFamilia.products);
            }
        }
        catch (Exception ex)
        {
            pnlProduct.Visible = false;
            pnlNotFound.Visible = true;
        }
    }
    private void getBCNF()
    {
        try
        {
            string qf = Request.QueryString["f"].ToLower();
            if (qf == "calefaccion" || qf == "cocinas-y-hornos" || qf == "celfones-y-termos" || qf == "patio-y-terraza")
            {
                lblBreadCrumbnf.Text = "<span class='current-bc'><a href='ver-categoria.aspx?f=" + qf + "'>" + productos.prodDictionary(qf) + "</a></span>";
            }
        }
        catch
        {
        }
    }
    private void getProdbySubcat(string value)
    {
        try
        {
            lblNP.Text = productos.prodDictionary(value);
            products.ProducList prodFamilia = productos.getProductDataBysubCat(value);
            lblBreadCrumb.Text = prodFamilia.breadCrumb.ToLower();
            pnlProduct.Visible = prodFamilia.isValid;
            pnlNotFound.Visible = !prodFamilia.isValid;
            if (prodFamilia.isValid)
            {
                rptProductos.DataSource = sortThis(prodFamilia.products);
                rptProductos.DataBind();
                buscarsubCat(prodFamilia.products);
            }
        }
        catch (Exception ex)
        {
            pnlProduct.Visible = false;
            pnlNotFound.Visible = true;
        }
    }
}
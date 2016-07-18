using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class MasterPage : System.Web.UI.MasterPage
{
    shopingCart carro = new shopingCart();
    products productos = new products();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkIP();
        if (!IsPostBack)
        {
            setCAT("R");
            fillComunas();
            setCalDay();
        }
        carro.initCart();
        getCarro();
        string family = Request.QueryString["f"];
        if (family != null)
        {
            setCAT(productos.checKCategory(family));
        }
    }
    protected void checkIP()
    {
        string ipaddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        if (ipaddr != "190.151.101.61" && ipaddr != "200.68.10.197" && ipaddr != "127.0.0.1" && ipaddr != "::1")
        {
            Response.Redirect("http://www.google.com");
        }
    }
    public void searchByName(object sender, EventArgs e)
    {
        string sp = txtSearch.Text;
        Response.Redirect("resultados-busqueda.aspx?s=" + sp);
    }
    public void priceFilter(object sender, EventArgs e)
    {
        LinkButton _lb = (LinkButton)sender;
        string _pr = _lb.CommandArgument;
        string muri = HttpContext.Current.Request.Url.AbsolutePath;
        if (Request.QueryString["f"] != null)
        {
            muri += "?f=" + Request.QueryString["f"];
        }
        else if (Request.QueryString["c"] != null)
        {
            muri += "?c=" + Request.QueryString["c"];
        }
        else if (Request.QueryString["s"] != null)
        {
            muri += "?s=" + Request.QueryString["s"];
        }
        Response.Redirect(muri + _pr);
    }
    public void catFilter(object sender, EventArgs e)
    {
        LinkButton _lb = (LinkButton)sender;
        string _pr = _lb.CommandArgument;
        string muri = HttpContext.Current.Request.Url.AbsolutePath;
        /*if (Request.QueryString["f"] != null)
        {
            muri += "?f=" + Request.QueryString["f"];
        }
        else if (Request.QueryString["c"] != null)
        {
            muri += "?c=" + Request.QueryString["c"];
        }
        else if (Request.QueryString["s"] != null)
        {
            muri += "?s=" + Request.QueryString["s"];
        }*/
        Response.Redirect(muri + _pr);
    }
    public void subcatFilter(object sender, EventArgs e)
    {
        LinkButton _lb = (LinkButton)sender;
        string _pr = _lb.CommandArgument;
        string muri = HttpContext.Current.Request.Url.AbsolutePath;
        /*if (Request.QueryString["f"] != null)
        {
            muri += "?f=" + Request.QueryString["f"];
        }
        else if (Request.QueryString["c"] != null)
        {
            muri += "?c=" + Request.QueryString["c"];
        }
        else if (Request.QueryString["s"] != null)
        {
            muri += "?s=" + Request.QueryString["s"];
        }*/
        Response.Redirect(muri + _pr);
    }
    private void setCAT(string cat)
    {
        if (cat == "R")
        {
            ibResidencial.Attributes.CssStyle.Add("z-index", "20");
            ibComercial.Attributes.CssStyle.Add("z-index", "10");
            ibResidencial.ImageUrl = "img/mp_btnres1.png";
            ibComercial.ImageUrl = "img/mp_btncom2.png";
            pnlComercial.Visible = false;
            pnlResidencial.Visible = true;
        }
        else
        {
            ibResidencial.Attributes.CssStyle.Add("z-index", "10");
            ibComercial.Attributes.CssStyle.Add("z-index", "20");
            ibResidencial.ImageUrl = "img/mp_btnres2.png";
            ibComercial.ImageUrl = "img/mp_btncom1.png";
            pnlComercial.Visible = true;
            pnlResidencial.Visible = false;
        }
        ibComercial.Attributes.CssStyle.Add("left", "-10px");
    }
    public void setCategoria(object sender, EventArgs e)
    {
        ImageButton _ib = (ImageButton)sender;
        string _cat = _ib.CommandArgument;
        setCAT(_cat);
    }
    private void getCarro()
    {
        DataTable _d = carro.getCart();
        int _items = 0;
        foreach (DataRow p in _d.Rows)
        {
            _items += int.Parse(p["cantid"].ToString());
        }
        lblCartCount.Text = _items.ToString();
    }
    public void viewCart(object sender, EventArgs e)
    {
        Response.Redirect("carro-de-compras.aspx");
    }
    public void closeCalendar(object sender, EventArgs e)
    {
        pnlDespacho.Visible = false;
    }
    private void fillComunas()
    {
        dcalcom.DataSource = productos.comunas();
        dcalcom.DataBind();
    }
    public void setComuna(object sender, EventArgs e)
    {
        ListItem _li = new ListItem("Selecciona tu comuna", "0");
        if (dcalcom.Items.Contains(_li))
        {
            dcalcom.Items.Remove(_li);
        }
        ListItem _li2 = new ListItem("Selecciona tu comuna", "Selecciona tu comuna");
        if (dcalcom.Items.Contains(_li2))
        {
            dcalcom.Items.Remove(_li2);
        }
        //ibcalcula.Enabled = true;
    }
    public void calculaFlete(object sender, EventArgs e)
    {
        //string com = dcalcom.SelectedValue;
        //string cod = ibcalcula.CommandArgument;
        //lblValorDespacho.Text = productos.calculaFlete(com, cod);
    }
    private void setCalDay()
    {
        cal_lunes1.Attributes.Add("class", "cal-inactive");
        cal_martes1.Attributes.Add("class", "cal-inactive");
        cal_miercoles1.Attributes.Add("class", "cal-inactive");
        cal_jueves1.Attributes.Add("class", "cal-inactive");
        cal_viernes1.Attributes.Add("class", "cal-inactive");
        cal_sabado1.Attributes.Add("class", "cal-inactive");
        cal_domingo1.Attributes.Add("class", "cal-inactive");
        cal_lunes2.Attributes.Add("class", "cal-inactive");
        cal_martes2.Attributes.Add("class", "cal-inactive");
        cal_miercoles2.Attributes.Add("class", "cal-inactive");
        cal_jueves2.Attributes.Add("class", "cal-inactive");
        cal_viernes2.Attributes.Add("class", "cal-inactive");
        cal_sabado2.Attributes.Add("class", "cal-inactive");
        cal_domingo2.Attributes.Add("class", "cal-inactive");
        string dow = DateTime.Now.DayOfWeek.ToString();
        if (DayOfWeek.Monday.ToString() == dow)
        {
            cal_lunes1.Attributes.Clear();
            cal_lunes1.Attributes.Add("class", "cal-active");
            cal_jueves2.Attributes.Clear();
            cal_jueves2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Tuesday.ToString() == dow)
        {
            cal_martes1.Attributes.Clear();
            cal_martes1.Attributes.Add("class", "cal-active");
            cal_viernes2.Attributes.Clear();
            cal_viernes2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Wednesday.ToString() == dow)
        {
            cal_miercoles1.Attributes.Clear();
            cal_miercoles1.Attributes.Add("class", "cal-active");
            cal_lunes2.Attributes.Clear();
            cal_lunes2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Thursday.ToString() == dow)
        {
            cal_jueves1.Attributes.Clear();
            cal_jueves1.Attributes.Add("class", "cal-active");
            cal_martes2.Attributes.Clear();
            cal_martes2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Friday.ToString() == dow)
        {
            cal_viernes1.Attributes.Clear();
            cal_viernes1.Attributes.Add("class", "cal-active");
            cal_miercoles2.Attributes.Clear();
            cal_miercoles2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Saturday.ToString() == dow)
        {
            cal_sabado1.Attributes.Clear();
            cal_sabado1.Attributes.Add("class", "cal-active");
            cal_jueves2.Attributes.Clear();
            cal_jueves2.Attributes.Add("class", "cal-active");
        }
        if (DayOfWeek.Sunday.ToString() == dow)
        {
            cal_domingo1.Attributes.Clear();
            cal_domingo1.Attributes.Add("class", "cal-active");
            cal_jueves2.Attributes.Clear();
            cal_jueves2.Attributes.Add("class", "cal-active");
        }
    }
}

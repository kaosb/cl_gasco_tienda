using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class carro_de_compras : System.Web.UI.Page
{
    shopingCart carro = new shopingCart();
    cypher _mc = new cypher();
    products productos = new products();
    cliente clientes = new cliente();
    contact cont = new contact();
    tienda.qa.SrvGCOksk _wsv = new tienda.qa.SrvGCOksk();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initFTE();
            calculaCarro();
            fillComunas();
            HttpContext.Current.Session["activedir"] = null;
            getDirecciones();
            initcb();
            getBC();
        }
        leftpanel();
    }
    private void getBC()
    {
        string homeUrl = productos.homeUrl;
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='carro-de-compras.aspx' style='text-transform:none;'>Carro de compras</a></span>";
    }
    private void initcb()
    {
        cbterminos.Text = "<span style='margin-left:3px;'>Acepto los</span> <a href='terminos-y-condiciones.aspx' target='_blank'>términos y condiciones</a>";
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
    private void initFTE()
    {
        fterut.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        fterut.ValidChars = "1234567890-kK";
    }
    private void calculaCarro()
    {
        shopingCart.detalleCarro _detalle = carro.getCartPrice();
        pnlCarro.Visible = _detalle.isValid;
        pnlDirecciones.Visible = _detalle.isValid;
        pnlSP.Visible = !_detalle.isValid;
        if (_detalle.isValid)
        {
            gvCarro.DataSource = _detalle.productos;
            gvCarro.DataBind();
            lbltotalcompra.Text = "$" + _detalle.totalPrecio.ToString("N0");
            lblcostoenvio.Text = "$" + _detalle.totalFlete.ToString("N0");
            lbltotalgeneral.Text = "$" + _detalle.totalFinal.ToString("N0");
        }
        getCarro();
        checkLogin(!_detalle.isValid);
    }
    private void checkLogin(bool valid)
    {
        pnlSP.Visible = valid;
        if (!valid)
        {
            if (HttpContext.Current.Session["idcliente"] == null)
            {
                pnlCarro.Visible = false;
                pnlNotLogged.Visible = true;
            }
            else
            {
                pnlNotLogged.Visible = false;
                getDirecciones();
            }
        }
        else
        {
            pnlNotLogged.Visible = false;
        }
    }
    public void eliminaProducto(object sender, CommandEventArgs e)
    {
        shopingCart.prodRow _pr = new shopingCart.prodRow();
        _pr.codigo = e.CommandArgument.ToString();
        carro.removeProduct(_pr);
        calculaCarro();
    }
    public void actualizaProducto(object sender, CommandEventArgs e)
    {
        shopingCart.prodRow _pr = new shopingCart.prodRow();
        LinkButton _lb = (LinkButton)sender;
        GridViewRow _tr = (GridViewRow)_lb.Parent.Parent;
        TextBox _tb = (TextBox)_tr.FindControl("txtcp");
        _pr.codigo = e.CommandArgument.ToString();
        _pr.cantid = int.Parse(_tb.Text);
        carro.updateProduct(_pr);
        calculaCarro();
    }
    private void getCarro()
    {
        Label lblCartCount = (Label)Master.FindControl("lblCartCount");
        try
        {
            DataTable _d = carro.getCart();
            int _items = 0;
            foreach (DataRow p in _d.Rows)
            {
                _items += int.Parse(p["cantid"].ToString());
            }
            lblCartCount.Text = _items.ToString();
        }
        catch
        {
            lblCartCount.Text = "0";
        }
    }
    private void fillComunas()
    {
        ddlComunas.DataSource = productos.comunas();
        ddlComunas.DataBind();
    }
    public void nuevaDireccion(object sender, EventArgs e)
    {
        pnlNuevaDireccion.Visible = true;
    }
    private void getDirecciones()
    {
        try
        {
            cliente.direccionesCliente dir = clientes.getDirecciones(HttpContext.Current.Session["idcliente"].ToString());
            if (dir.valido)
            {
                int ndirs = dir.Direcciones.Count;
                int ndirr = gvDirecciones.Rows.Count;
                if (ndirr == ndirs) { return; }
                gvDirecciones.DataSource = dir.Direcciones;
                gvDirecciones.DataBind();
                pnlDirecciones.Visible = true;
            }
        }
        catch
        {
        }
    }
    public void checkPricebyDir(object sender, EventArgs e)
    {
        clearNewDir();
        RadioButton rb = (RadioButton)sender;
        foreach(GridViewRow _gvr in gvDirecciones.Rows)
        {
            RadioButton _rbr = (RadioButton)_gvr.FindControl("rdb");
            _rbr.Checked = false;
        }
        GridViewRow _tr = (GridViewRow)rb.Parent.Parent;
        rb.Checked = true;
        HiddenField _tb = (HiddenField)_tr.FindControl("hfcomuna");
        HiddenField _ib = (HiddenField)_tr.FindControl("ibdd");
        if (rb.Checked)
        {
            string comuna = _tb.Value;
            HttpContext.Current.Session["activedir"] = comuna;
            HttpContext.Current.Session["activedirid"] = _ib.Value;
            calculaCarro();
            pnlDespacho.Visible = true;
            if (cbterminos.Checked)
            {
                pnlPago.Visible = true;
                pnlPago2.Visible = false;
            }
            else
            {
                pnlPago.Visible = false;
                pnlPago2.Visible = true;
            }
        }
    }
    public void delNewDir(object sender, EventArgs e)
    {
        HttpContext.Current.Session["activedir"] = null;
        HttpContext.Current.Session["activedirid"] = null;
        pnlPago.Visible = false;
        ImageButton _ib = (ImageButton)sender;
        string aid = _ib.CommandArgument;
        string ncl = HttpContext.Current.Session["idcliente"].ToString();
        cliente.minDireccionCiente _retdc = clientes.eliminaDireccion(aid, ncl);
        if (_retdc.valido)
        {
            getDirecciones();
        }
        else
        {
        }
    }
    public void editNewDir(object sender, EventArgs e)
    {
        ImageButton _ib = (ImageButton)sender;
        string aid = _ib.CommandArgument;
        bool updated = false;
        cliente.direccionesCliente dir = clientes.getDirecciones(HttpContext.Current.Session["idcliente"].ToString());
        foreach (cliente.datoDireccion d in dir.Direcciones)
        {
            if (aid == d.dir_id)
            {
                txtndcalle.Text = d.dir_calle;
                txtndnumero.Text = d.dir_numero.ToString();
                txtnddepto.Text = d.dir_depto;
                ibsavedir.CommandName = "update";
                updated = true;
            }
        }
        if (!updated)
        {
            ibsavedir.CommandName = "new";
        }
    }
    public void addNewDir(object sender, EventArgs e)
    {
        try
        {
            if (cont.validateDireccion(txtndcalle.Text))
            {
                CEdtxt(txtndcalle);
            }
            else
            {
                SEdtxt(txtndcalle, "Recuerda ingresar una calle válida");
                return;
            }
            if (cont.validateNumdir(txtndnumero.Text))
            {
                CEdtxt(txtndnumero);
            }
            else
            {
                SEdtxt(txtndnumero, "Recuerda ingresar una numeración válida");
                return;
            }
            if (cont.validateCombos(ddlComunas.SelectedValue))
            {
                CEdddl(ddlComunas);
            }
            else
            {
                SEdddl(ddlComunas, "Recuerda seleccionar tu comuna");
                return;
            }
            ImageButton sbtn = (ImageButton)sender;
            string action = sbtn.CommandName;
            string calle = txtndcalle.Text;
            string numero = txtndnumero.Text;
            string depto = txtnddepto.Text;
            string comuna = ddlComunas.SelectedValue;
            string region = "13";
            string provincia = "SANTIAGO";
            cliente.datosClientes dc = new cliente.datosClientes();
            cliente.datoCliente _c = new cliente.datoCliente();
            _c.ncliente = HttpContext.Current.Session["idcliente"].ToString();
            cliente.datoDireccion _d = new cliente.datoDireccion();
            _d.dir_calle = calle;
            _d.dir_comuna = comuna;
            _d.dir_depto = depto;
            _d.dir_numero = int.Parse(numero);
            _d.dir_orgventa = "7100";
            _d.dir_provincia = provincia;
            _d.dir_region = region;
            dc.Cliente = _c;
            dc.Direccion = _d;
            //if (action == "new")
            //{
            cliente.minDireccionCiente _retdc = clientes.grabaDireccion(dc);
            if (_retdc.valido)
            {
                pnlNuevaDireccion.Visible = false;
                clearNewDir();
                getDirecciones();
            }
            else
            {
                lblAddDirerror.Text = _retdc.Errormsg;
            }
            //}
            //else
            //{
            //    cliente.minDireccionCiente _retdc = clientes.grabaDireccion(dc);
            //    if (_retdc.valido)
            //    {
            //        pnlNuevaDireccion.Visible = false;
            //        getDirecciones();
            //    }
            //    else
            //    {
            //        lblAddDirerror.Text = _retdc.Errormsg;
            //    }
            //}
        }
        catch (Exception ex)
        {
            lblAddDirerror.Text = ex.Message;
        }
    }
    private void clearNewDir()
    {
        pnlNuevaDireccion.Visible = false;
        txtndcalle.Text = null;
        txtnddepto.Text = null;
        txtndnumero.Text = null;
        pnlPago.Visible = false;
    }
    public void loginCarro(object sender, EventArgs e)
    {
        string rut = txtCCRut.Text;
        cliente.datosClientes _cli = clientes.checkUserbyRut(rut);
        if (_cli.valido)
        {
            if (_cli.Cliente.rut == rut)
            {
                HttpContext.Current.Session["idcliente"] = _cli.Cliente.ncliente;
                HttpContext.Current.Session["rutcliente"] = _cli.Cliente.rut;
                HttpContext.Current.Session["nombrecliente"] = _cli.Cliente.nombres;
                HttpContext.Current.Session["tipocliente"] = _cli.Cliente.tipo;
                loginerror.Text = "";
                calculaCarro();
            }
            else
            {
                Response.Redirect("registro.aspx?err=" + DateTime.Now.Ticks.ToString());
                loginerror.Text = "Los datos ingresados no corresponden.";
            }
        }
        else
        {
            Response.Redirect("registro.aspx?err=" + DateTime.Now.Ticks.ToString());
            loginerror.Text = "Los datos ingresados no corresponden.";
        }
    }
    protected void validaterminos(object sender, EventArgs e)
    {
        if (cbterminos.Checked)
        {
            pnlPago.Visible = true;
            pnlPago2.Visible = false;
        }
        else
        {
            pnlPago.Visible = false;
            pnlPago2.Visible = true;
        }
    }
    private void SEdtxt(TextBox txt, string msg)
    {
        txt.BorderColor = System.Drawing.Color.Red;
        lblAddDirerror.Text = msg;
    }
    private void CEdtxt(TextBox txt)
    {
        txt.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CDCDCD");
        lblAddDirerror.Text = null;
    }
    private void SEdddl(DropDownList txt, string msg)
    {
        txt.BorderColor = System.Drawing.Color.Red;
        lblAddDirerror.Text = msg;
    }
    private void CEdddl(DropDownList txt)
    {
        txt.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CDCDCD");
        lblAddDirerror.Text = null;
    }
}
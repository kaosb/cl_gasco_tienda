using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registro : System.Web.UI.Page
{
    products prods = new products();
    cliente client = new cliente();
    products productos = new products();
    contact cont = new contact();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initFTE();
            checkLogin();
            fillComunas();
            leftpanel();
            checkmsg();
        }
    }
    private void checkmsg()
    {
        if (Request.QueryString["err"] != null)
        {
            lblMensaje.Text = "El RUT ingresado no figura como cliente. Registrate completando los datos solicitados a continuación para continuar el proceso de compra.";
            lblMensaje.Visible = true;
        }
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
        fteapm.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        fteapp.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftecalled.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftecelular.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftedeptod.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftefono.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftemail.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftenombre.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        ftenumerod.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        fteotrod.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;
        fterut.FilterMode = AjaxControlToolkit.FilterModes.ValidChars;

        fteapm.ValidChars = cont.charsnombre;
        fteapp.ValidChars = cont.charsnombre;
        ftecalled.ValidChars = cont.charscalle;
        ftecelular.ValidChars = cont.charsnum;
        ftedeptod.ValidChars = cont.charscalle;
        ftefono.ValidChars = cont.charsnum;
        ftemail.ValidChars = cont.charsmail;
        ftenombre.ValidChars = cont.charsnombre;
        ftenumerod.ValidChars = cont.charsnum;
        fteotrod.ValidChars = cont.charscalle;
        fterut.ValidChars = cont.charsrut;
    }
    private void checkLogin()
    {
        try
        {
            if (HttpContext.Current.Session["idcliente"] == null)
            {

            }
            else
            {
                //Response.Redirect(prods.homeUrl);
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect(prods.homeUrl + "?err=" + ex.Message);
        }
    }
    public void validaDatos(object sender, EventArgs e)
    {
        if (cont.validateNombre(txtcNombre.Text))
        {
            CEtxt(txtcNombre);
        }
        else
        {
            SEtxt(txtcNombre, "Recuerda ingresar un Nombre válido");
            return;
        }
        if (cont.validateNombre(txtcApellidop.Text))
        {
            CEtxt(txtcApellidop);
        }
        else
        {
            SEtxt(txtcApellidop, "Recuerda ingresar un Apellido válido");
            return;
        }
        if (cont.validaRut(txtcRut.Text))
        {
            CEtxt(txtcRut);
        }
        else
        {
            SEtxt(txtcRut, "Recuerda ingresar un Rut válido");
            return;
        }
        if (cont.validateFono(txtcFono.Text) || cont.validateFono(txtcCelular.Text))
        {
            CEtxt(txtcFono);
            CEtxt(txtcCelular);
        }
        else
        {
            SEtxt(txtcFono, "Recuerda ingresar al menos un teléfono");
            SEtxt(txtcCelular, "Recuerda ingresar al menos un teléfono");
            return;
        }
        if (cont.validateMail(txtcMail.Text))
        {
            CEtxt(txtcMail);
        }
        else
        {
            SEtxt(txtcMail, "Recuerda ingresar un Mail válido");
            return;
        }
        grabaCliente();
    }
    private void SEtxt(TextBox txt, string msg)
    {
        txt.BorderColor = System.Drawing.Color.Red;
        lblErrorDatos.Text = msg;
    }
    private void CEtxt(TextBox txt)
    {
        txt.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CDCDCD");
        lblErrorDatos.Text = null;
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
    private void fillComunas()
    {
        ddlComunas.DataSource = productos.comunas();
        ddlComunas.DataBind();
    }
    public void validaDireccion(object sender, EventArgs e)
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
            string otro = txtndotro.Text;
            string comuna = ddlComunas.SelectedValue;
            string region = "13";
            string provincia = "SANTIAGO";
            cliente.datosClientes dc = new cliente.datosClientes();
            cliente.datoCliente _c = new cliente.datoCliente();
            string nombre = txtcNombre.Text;
            string apellidop = txtcApellidop.Text;
            string apellidom = txtcApellidom.Text;
            string rut = txtcRut.Text;
            string fono = txtcFono.Text;
            string celular = txtcCelular.Text;
            string razonsocial = null;
            string mail = txtcMail.Text;
            _c.nombres = nombre;
            _c.apellidoP = apellidop;
            _c.apellidoM = apellidom;
            _c.rut = rut;
            _c.telefono = fono;
            _c.celular = celular;
            _c.razonSocial = razonsocial;
            _c.email = mail;
            cliente.datoDireccion _d = new cliente.datoDireccion();
            _d.dir_calle = calle;
            _d.dir_comuna = comuna;
            _d.dir_depto = depto;
            _d.dir_numero = int.Parse(numero);
            _d.dir_orgventa = "7100";
            _d.dir_otro = otro;
            _d.dir_provincia = provincia;
            _d.dir_region = region;
            dc.Cliente = _c;
            dc.Direccion = _d;
            cliente.minDatoCliente _retdc = client.creaProspecto(dc);
            if (_retdc.valido)
            {
                pnlNuevaDireccion.Visible = false;
                pnlFinal.Visible = true;
                HttpContext.Current.Session["idcliente"] = _retdc.numeroCliente;
                HttpContext.Current.Session["rutcliente"] = rut; ;
                HttpContext.Current.Session["nombrecliente"] = nombre;
                HttpContext.Current.Session["tipocliente"] = "P";
            }
            else
            {
                lblAddDirerror.Text = _retdc.Errormsg;
            }
        }
        catch (Exception ex)
        {
            lblAddDirerror.Text = ex.Message;
        }
    }
    private void grabaCliente()
    {
        string nombre = txtcNombre.Text;
        string apellidop = txtcApellidop.Text;
        string apellidom = txtcApellidom.Text;
        string rut = txtcRut.Text;
        string fono = txtcFono.Text;
        string celular = txtcCelular.Text;
        string razonsocial = null;
        string mail = txtcMail.Text;
        cliente.datoCliente cl = new cliente.datoCliente();
        cl.nombres = nombre;
        cl.apellidoP = apellidop;
        cl.apellidoM = apellidom;
        cl.rut = rut;
        cl.telefono = fono;
        cl.celular = celular;
        cl.razonSocial = razonsocial;
        cl.email = mail;
        cliente.datosClientes dc = client.checkUserbyRut(rut);
        if (dc.valido)
        {
            lblErrorDatos.Text = "El rut ingresado ya está registrado como cliente";
        }
        else
        {
            pnldatos1.Visible = false;
            pnlNuevaDireccion.Visible = true;
            lblNP.Text = "Dirección de despacho";
        }
    }
}
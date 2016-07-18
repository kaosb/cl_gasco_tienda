using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contacto : System.Web.UI.Page
{
    products productos = new products();
    contact cont = new contact();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBC();
            leftpanel();
            fillMotivos();
            ftevalidChars();
            fillPaises();
        }
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
    private void getBC()
    {
        string homeUrl = productos.homeUrl;
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='contacto.aspx' style='text-transform:none;'>Contacto</a></span>";
    }
    private void fillMotivos()
    {
        ddlMotivo.DataSource = cont.getMotivos();
        ddlMotivo.DataBind();
    }
    private void ftevalidChars()
    {
        ftenom.ValidChars = cont.charsnombre;
        fteape.ValidChars = cont.charsnombre;
        ftecli.ValidChars = cont.charsnum;
        fterut.ValidChars = cont.charsrut;
        ftemai.ValidChars = cont.charsmail;
        ftedir.ValidChars = cont.charscalle;
        ftetel.ValidChars = cont.charsnum;
        ftecel.ValidChars = cont.charsnum;
        ftemen.ValidChars = cont.charsmensaje;
    }
    private void fillPaises()
    {
        ddlPais.Items.Add(new ListItem("Selecciona tu Pais", "0"));
        ddlPais.Items.Add(new ListItem("Chile", "Chile"));
        ddlPais.Items.Add(new ListItem("Resto del mundo", "Resto del mundo"));
    }
    public void fillRegiones(object sender, EventArgs e)
    {
        ddlRegion.Items.Clear();
        ddlComuna.Items.Clear();
        ddlProvincia.Items.Clear();
        if (ddlPais.Items.Contains(new ListItem("Selecciona tu Pais", "0")))
        {
            ddlPais.Items.Remove(new ListItem("Selecciona tu Pais", "0"));
        }
        if (ddlPais.SelectedValue == "Chile")
        {
            ddlRegion.DataSource = cont.regiones();
            ddlRegion.DataBind();
            ddlRegion.Enabled = true;
            ddlProvincia.Enabled = true;
            ddlComuna.Enabled = true;
        }
        else
        {
            ddlRegion.Enabled = false;
            ddlProvincia.Enabled = false;
            ddlComuna.Enabled = false;
        }
    }
    public void fillCiudades(object sender, EventArgs e)
    {
        ddlProvincia.Items.Clear();
        ddlComuna.Items.Clear();
        string region = ddlRegion.SelectedValue;
        ddlProvincia.DataSource = cont.provincias(region);
        ddlProvincia.DataBind();
        if (ddlRegion.Items.Contains(new ListItem("Selecciona tu región", "Selecciona tu región")))
        {
            ddlRegion.Items.Remove(new ListItem("Selecciona tu región", "Selecciona tu región"));
        }
    }
    public void fillComunas(object sender, EventArgs e)
    {
        string provincia = ddlProvincia.SelectedValue;
        ddlComuna.DataSource = cont.comunas(provincia);
        ddlComuna.DataBind();
        if (ddlProvincia.Items.Contains(new ListItem("Selecciona tu ciudad", "Selecciona tu ciudad")))
        {
            ddlProvincia.Items.Remove(new ListItem("Selecciona tu ciudad", "Selecciona tu ciudad"));
        }
    }
#region validaciones
    public void validaForm(object sender, ImageClickEventArgs e)
    {
        if (cont.validateNombre(txtNombre.Text))
        {
            CEtxt(txtNombre);
        }
        else
        {
            SEtxt(txtNombre, "Recuerda ingresar un Nombre válido");
            return;
        }
        if (cont.validateNombre(txtApellido.Text))
        {
            CEtxt(txtApellido);
        }
        else
        {
            SEtxt(txtApellido, "Recuerda ingresar un Apellido válido");
            return;
        }
        if (cont.validaRut(txtRut.Text))
        {
            CEtxt(txtRut);
        }
        else
        {
            SEtxt(txtRut, "Recuerda ingresar un Rut válido");
            return;
        }
        if (cont.validateMail(txtMail.Text))
        {
            CEtxt(txtMail);
        }
        else
        {
            SEtxt(txtMail, "Recuerda ingresar un E-Mail válido");
            return;
        }
        if (cont.validateDireccion(txtDireccion.Text))
        {
            CEtxt(txtDireccion);
        }
        else
        {
            SEtxt(txtDireccion, "Recuerda ingresar una Dirección válida");
            return;
        }
        //validaciones pais ciudad comuna
        
        //
        if (txtMensaje.Text.Trim().Length > 2 )
        {
            CEtxt(txtMensaje);
        }
        else if (txtMensaje.Text.Length > 255)
        {
            SEtxt(txtMensaje, "Puedes ingresar un máximo de 255 caracteres en tu Mensaje");
            return;
        }
        else
        {
            SEtxt(txtMensaje, "Recuerda ingresar un Mensaje válido");
            return;
        }
        sendMail();
    }
    private void sendMail()
    {
        string mail = null;
        mail += "<p>Motivo del contacto: " + ddlMotivo.SelectedValue + "</p>";
        mail += "<p>Nombre: " + txtNombre.Text + "</p>";
        mail += "<p>Apellido: " + txtApellido.Text + "</p>";
        mail += "<p>N° de Cliente: " + txtCliente.Text + "</p>";
        mail += "<p>Rut: " + txtRut.Text + "</p>";
        mail += "<p>E-Mail: " + txtMail.Text + "</p>";
        mail += "<p>Dirección: " + txtDireccion.Text + "</p>";
        mail += "<p>Pais: " + ddlPais.SelectedValue + "</p>";
        try
        {
            mail += "<p>Región: " + ddlRegion.SelectedValue + "</p>";
        }
        catch
        {
            mail += "<p>Región: </p>";
        }
        try
        {
            mail += "<p>Ciudad: " + ddlProvincia.SelectedValue + "</p>";
        }
        catch
        {
            mail += "<p>Ciudad: </p>";
        }
        try
        {
            mail += "<p>Comuna: " + ddlComuna.SelectedValue + "</p>";
        }
        catch
        {
            mail += "<p>Comuna: </p>";
        }
        mail += "<p>Teléfono: " + txtTelefono.Text + "</p>";
        mail += "<p>Celular: " + txtCelular.Text + "</p>";
        mail += "<p>Mensaje: " + txtMensaje.Text + "</p>";
        cont.sendMail(mail);
        cont.sendMailResponse(txtMail.Text);
        LimpiaCampos();
    }
    private void LimpiaCampos()
    {
        txtNombre.Text = null;
        txtApellido.Text = null;
        txtCliente.Text = null;
        txtRut.Text = null;
        txtMail.Text = null;
        txtDireccion.Text = null;
        ddlPais.Items.Clear();
        fillPaises();
        ddlRegion.Items.Clear();
        ddlProvincia.Items.Clear();
        ddlComuna.Items.Clear();
        txtTelefono.Text = null;
        txtCelular.Text = null;
        txtMensaje.Text = null;
        lblError.Text = "Tu mensaje ha sido enviado exitosamente!";
    }
    private void SEtxt(TextBox txt, string msg)
    {
        txt.BorderColor = System.Drawing.Color.Red;
        lblError.Text = msg;
    }
    private void SEddl(DropDownList txt, string msg)
    {
        txt.BorderColor = System.Drawing.Color.Red;
        lblError.Text = msg;
    }
    private void CEtxt(TextBox txt)
    {
        txt.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CDCDCD");
        lblError.Text = null;
    }
    private void CEddl(DropDownList txt)
    {
        txt.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CDCDCD");
        lblError.Text = null;
    }
#endregion
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class preguntas_frecuentes : System.Web.UI.Page
{
    products productos = new products();
    faq faqs = new faq();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBC();
            leftpanel();
            getFaqs();
        }
    }
    private void getFaqs()
    {
        rptGenerales.DataSource = faqs.getPreguntas("GENERALES");
        rptGenerales.DataBind();
        rptCompra.DataSource = faqs.getPreguntas("COMPRA");
        rptCompra.DataBind();
        rptDespacho.DataSource = faqs.getPreguntas("DESPACHO");
        rptDespacho.DataBind();
        rptInstalacion.DataSource = faqs.getPreguntas("INSTALACIÓN Y SERVICIO TÉCNICO");
        rptInstalacion.DataBind();
    }
    private void getBC()
    {
        string homeUrl = productos.homeUrl;
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='preguntas-frecuentes.aspx' style='text-transform:none;'>Preguntas frecuentes</a></span>";
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
}
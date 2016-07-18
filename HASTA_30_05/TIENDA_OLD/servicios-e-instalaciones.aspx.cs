using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class servicios_e_instalaciones : System.Web.UI.Page
{
    products productos = new products();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBC();
            leftpanel();
        }
    }
    private void getBC()
    {
        string homeUrl = productos.homeUrl;
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='servicios-e-instalaciones.aspx' style='text-transform:none;'>Servicios e instalaciones</a></span>";
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
}
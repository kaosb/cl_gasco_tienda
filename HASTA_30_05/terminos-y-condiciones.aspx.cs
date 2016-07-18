using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class terminos_y_condiciones : System.Web.UI.Page
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
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='terminos-y-condiciones.aspx' style='text-transform:none;'>Términos y condiciones</a></span>";
    }
}
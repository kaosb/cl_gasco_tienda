using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fracaso : System.Web.UI.Page
{
    public string homeurl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        leftpanel();
        products p = new products();
        homeurl = p.homeUrl;
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = false;
        pnlotr.Visible = true;
    }
}
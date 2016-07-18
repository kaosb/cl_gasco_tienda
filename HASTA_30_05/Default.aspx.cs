using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel _mpl = (Panel)Master.FindControl("pnlLeft");
        _mpl.Visible = false;
        Panel _mpr = (Panel)Master.FindControl("pnlRight");
        _mpr.Width = 950;
        if (IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "asd", "setmySlide()", true);
        }
    }
}
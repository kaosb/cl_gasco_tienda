using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        string Str = "";
        Str = System.Net.Dns.GetHostName();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Str);
        IPAddress[] addr = ipEntry.AddressList;
        String IP = addr[addr.Length - 1].ToString();

       
        Log.Debug("IP CLIENTE: " + IP);

        if (IP != "200.29.21.246" && IP != "200.68.10.197" && IP != "200.68.10.193" && IP != "172.20.1.136")
        {
            //Response.Redirect("no_existo.aspx");
        }
        */
         
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
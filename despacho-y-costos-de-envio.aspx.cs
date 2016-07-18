using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class despacho_y_costos_de_envio : System.Web.UI.Page
{
    products productos = new products();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setCalDay();
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
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='despacho-y-costos-de-envio.aspx' style='text-transform:none;'>Despacho y costos de envío</a></span>";
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
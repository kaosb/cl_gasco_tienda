using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class informacion_y_consejos_de_artefactos : System.Web.UI.Page
{
    products productos = new products();
    protected void Page_Load(object sender, EventArgs e)
    {
        getBC();
        leftpanel();
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
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='informacion-y-consejos-de-artefactos.aspx' style='text-transform:none;'>Información y consejos de artefactos</a></span>";
    }
    protected void showPanel(object sender, ImageClickEventArgs e)
    {
        pnlInstalacion.Visible = false;
        pnlPuestaenMarcha.Visible = false;
        pnlRecomendaciones.Visible = false;
        ImageButton i = (ImageButton)sender;
        Panel p = (Panel)i.Parent.FindControl(i.CommandArgument);
        p.Visible = true;
        setib(i);
    }
    protected void setib(ImageButton ibb)
    {
        string idb = ibb.ID.Substring(ibb.ID.Length - 1, 1);
        string im1 = ibb1.ImageUrl.Replace("0.png", ".png");
        string im2 = ibb2.ImageUrl.Replace("0.png", ".png");
        string im3 = ibb3.ImageUrl.Replace("0.png", ".png");
        ibb1.ImageUrl = im1.Replace(".png", "0.png");
        ibb2.ImageUrl = im2.Replace(".png", "0.png");
        ibb3.ImageUrl = im3.Replace(".png", "0.png");
        ibb1.Attributes.Remove("onmouseover");
        ibb1.Attributes.Remove("onmouseout");
        ibb2.Attributes.Remove("onmouseover");
        ibb2.Attributes.Remove("onmouseout");
        ibb3.Attributes.Remove("onmouseover");
        ibb3.Attributes.Remove("onmouseout");
        //ibb1.Attributes.Add("onmouseover", "overIMG(1);");
        //ibb1.Attributes.Add("onmouseout", "outIMG(1);");
        //ibb2.Attributes.Add("onmouseover", "overIMG(2);");
        //ibb2.Attributes.Add("onmouseout", "outIMG(2);");
        //ibb3.Attributes.Add("onmouseover", "overIMG(3);");
        //ibb3.Attributes.Add("onmouseout", "outIMG(3);");
        string sso = ibb.ImageUrl.Replace("0.png", ".png");
        //sso
        ibb.Attributes.Remove("onmouseover");
        ibb.Attributes.Remove("onmouseout");
        ibb.ImageUrl = sso;
    }
}
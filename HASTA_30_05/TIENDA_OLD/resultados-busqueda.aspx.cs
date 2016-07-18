using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class resultados_busqueda : System.Web.UI.Page
{
    products productos = new products();
    protected void Page_Load(object sender, EventArgs e)
    {
        getBC();
        leftpanel();
        getAllData();
    }
    private List<products.ProducData> sortThis(List<products.ProducData> pd)
    {
        products.sortProductos sp = new products.sortProductos();
        pd.Sort(sp);
        return pd;
    }
    private void getAllData()
    {
        try
        {
            string s = Request.QueryString["s"].ToString().ToLower();
            List<products.ProducData> pd = productos.getAllProducts();
            List<products.ProducData> ps = new List<products.ProducData>();
            foreach (products.ProducData p in pd)
            {
                string sp = p.nombre.ToLower();
                string sp2 = p.descripcion.ToLower();
                string sp3 = p.descripcion2.ToLower();
                if (sp.Contains(s) || sp2.Contains(s) || sp3.Contains(s))
                {
                    ps.Add(p);
                }
            }
            if (ps.Count > 0)
            {
                rptProductos.DataSource = sortThis(ps);
                rptProductos.DataBind();
            }
            else
            {
                pnlNotFound.Visible = true;
                pnlProducts.Visible = false;
            }
        }
        catch
        {
            pnlNotFound.Visible = true;
            pnlProducts.Visible = false;
        }
    }
    private void leftpanel()
    {
        Panel pnlprecio = (Panel)Master.FindControl("mPnlPrice");
        Panel pnlotr = (Panel)Master.FindControl("pnlOtros");
        pnlprecio.Visible = true;
        pnlotr.Visible = false;
    }
    private void getBC()
    {
        string homeUrl = productos.homeUrl;
        lblBreadCrumb.Text = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='resultados-busqueda.aspx' style='text-transform:none;'>Resultados búsqueda</a></span>";
    }
}
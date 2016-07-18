using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class getProductInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable _dt = new DataTable();
        _dt.Columns.Add("prod");
        _dt.Columns.Add("desc");
        _dt.Columns.Add("enco");
        cypher _c = new cypher();
        tienda.qa.SrvGCOksk _wsv = new tienda.qa.SrvGCOksk();
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam _cpp = new tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam();
        _cpp.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _r = _wsv.ZKSK_CONSULTA_PRODUCTOS(_cpp);
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _r.O_T_PRODUCTO)
        {
            DataRow _dr = _dt.NewRow();
            _dr["prod"] = _p.PRODUCTO;
            _dr["desc"] = _p.DESCRIPCION;
            _dr["enco"] = _c.Encrypt(_p.PRODUCTO, "r5b1bo4u");
            _dt.Rows.Add(_dr);
        }
        rpInfo.DataSource = _dt;
        rpInfo.DataBind();
    }
}
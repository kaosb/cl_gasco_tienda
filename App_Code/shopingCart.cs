using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for shopingCart
/// </summary>
public class shopingCart
{
    tienda.qa.SrvGCOksk ws = new tienda.qa.SrvGCOksk();
    public struct detalleCarro
    {
        public bool isValid { get; set; }
        public string mensaje { get; set; }
        public long totalPrecio { get; set; }
        public long totalDescuento { get; set; }
        public long totalFlete { get; set; }
        public long totalFinal { get; set; }
        public List<productosCarro> productos { get; set; }
    }
    public struct productosCarro
    {
        public string Producto { get; set; }
        public string Nombre { get; set; }
        public int cantidad { get; set; }
        public long precioUnitario { get; set; }
        public long precioSubtotal { get; set; }
        public long descuentoUnitario { get; set; }
        public long descuentoSubtotal { get; set; }
        public long fleteUnitario { get; set; }
        public long fleteSubtotal { get; set; }
        public long precioTotal { get; set; }
    }
	public shopingCart()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public struct prodRow
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public long precio { get; set; }
        public int cantid { get; set; }
    }
    public void initCart()
    {
        if (HttpContext.Current.Session["carro"] == null)
        {
            HttpContext.Current.Session["carro"] = "new";
            DataTable _d = new DataTable();
            _d.Columns.Add("codigo");
            _d.Columns.Add("nombre");
            _d.Columns.Add("precio");
            _d.Columns.Add("cantid");
            _d.Rows.Clear();
            HttpContext.Current.Session["productos"] = _d;
        }
    }
    public DataTable getCart()
    {
        DataTable _d = HttpContext.Current.Session["productos"] as DataTable;
        return _d;
    }
    public prodRow getLastProd()
    {
        prodRow _pr = new prodRow();
        DataTable _d = getCart();
        foreach (DataRow _r in _d.Rows)
        {
            _pr.codigo = _r["codigo"].ToString();
            _pr.nombre = _r["nombre"].ToString();
            _pr.precio = long.Parse(_r["precio"].ToString());
            _pr.cantid = int.Parse(_r["cantid"].ToString());
        }
        return _pr;
    }
    public void addProduct(prodRow _pr)
    {
        string _cod = _pr.codigo;
        DataTable _d = getCart();
        bool _add = true;
        foreach (DataRow _r in _d.Rows)
        {
            if (_r["codigo"].ToString() == _cod)
            {
                _r["cantid"] = (_pr.cantid + int.Parse(_r["cantid"].ToString())).ToString();
                _add = false;
            }
        }
        if (_add)
        {
            DataRow _dr = _d.NewRow();
            _dr["codigo"] = _pr.codigo;
            _dr["nombre"] = _pr.nombre;
            _dr["precio"] = _pr.precio;
            _dr["cantid"] = _pr.cantid.ToString();
            _d.Rows.Add(_dr);
        }
        HttpContext.Current.Session["productos"] = _d;
    }
    public void removeProduct(prodRow _pr)
    {
        string _cod = _pr.codigo;
        DataTable _d = getCart();
        DataRow removerow = _d.NewRow();
        foreach (DataRow _r in _d.Rows)
        {
            if (_r["codigo"].ToString() == _cod)
            {
                removerow = _r;
            }
        }
        _d.Rows.Remove(removerow);
        HttpContext.Current.Session["productos"] = _d;
    }
    public void clearCart()
    {
        DataTable _d = getCart();
        if (_d != null)
        {
            _d.Rows.Clear();
        }
        HttpContext.Current.Session["productos"] = _d;
    }
    public void updateProduct(prodRow _pr)
    {
        string _cod = _pr.codigo;
        int _cant = _pr.cantid;
        DataTable _d = getCart();
        foreach (DataRow _r in _d.Rows)
        {
            if (_r["codigo"].ToString() == _cod)
            {
                _r["cantid"] = _cant;
            }
        }
        HttpContext.Current.Session["productos"] = _d;
    }
    public detalleCarro getCartPrice()
    {
        detalleCarro _detcar = new detalleCarro();

        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_detcar.GetType());
        StringWriter sww = new StringWriter();
        XmlWriter writer = XmlWriter.Create(sww);
        x.Serialize(writer, _detcar);
        String xml = sww.ToString();
        Log.Debug("_detcar :" + xml);


        try
        {
            List<productosCarro> _lpc = new List<productosCarro>();
            List<productosCarro> _lpcf = new List<productosCarro>();
            DataTable _d = getCart();
            List<tienda.qa.ZKSK_COMPRA_PRODUCTOS> _arrp = new List<tienda.qa.ZKSK_COMPRA_PRODUCTOS>();
            if (_d.Rows.Count > 0)
            {
                foreach (DataRow _dr in _d.Rows)
                {
                    tienda.qa.ZKSK_COMPRA_PRODUCTOS _compra = new tienda.qa.ZKSK_COMPRA_PRODUCTOS();
                    _compra.PRODUCTO = _dr["codigo"].ToString();
                    _compra.CANTIDAD = int.Parse(_dr["cantid"].ToString());
                    _arrp.Add(_compra);
                }
            }
            else
            {
                _detcar.isValid = false;
                _detcar.mensaje = "Carro vacío";
                return _detcar;
            }
            tienda.qa.ZKSK_CALCULA_CARRO_COMPRAParam _cpp = new tienda.qa.ZKSK_CALCULA_CARRO_COMPRAParam();
            if (HttpContext.Current.Session["idcliente"] == null)
            {
                _cpp.I_CODCLIENTE = "";
            }
            else
            {
                _cpp.I_CODCLIENTE = HttpContext.Current.Session["idcliente"].ToString();
            }
            if (HttpContext.Current.Session["activedir"] == null)
            {
                _cpp.I_COMUNA = "";
            }
            else
            {
                _cpp.I_COMUNA = HttpContext.Current.Session["activedir"].ToString();
            }
            
            _cpp.I_ORGVTA = "7100";
            _cpp.I_T_PRODUCTO = _arrp.ToArray();
            tienda.qa.ZKSK_CALCULA_CARRO_COMPRARet _ret = ws.ZKSK_CALCULA_CARRO_COMPRA(_cpp);
            if (_ret.Retorno != "")
            {
                _detcar.isValid = false;
                _detcar.mensaje = _ret.Mensaje;
            }
            else
            {
                _detcar.isValid = true;
                _detcar.totalPrecio = long.Parse(_ret.O_TOTAL_PRECIO);
                _detcar.totalDescuento = long.Parse(_ret.O_TOTAL_DSCTO);
                _detcar.totalFlete = long.Parse(_ret.O_TOTAL_FLETE);
                _detcar.totalFinal = long.Parse(_ret.O_TOTAL_FINAL);
                foreach (tienda.qa.ZKSK_CONSULTA_PRECIO_CARRO _c in _ret.O_T_CALCULO_CARRO)
                {
                    productosCarro _pc = new productosCarro();
                    _pc.Producto = _c.PRODUCTO;
                    _pc.Nombre = _c.PRODUCTO.ToLower();
                    _pc.cantidad = int.Parse(_c.CANTIDAD);
                    _pc.precioUnitario = long.Parse(_c.PRECIO_UNIT);
                    _pc.precioSubtotal = long.Parse(_c.PRECIO_LIN);
                    _pc.descuentoUnitario = long.Parse(_c.DESCUENTO_UNIT);
                    _pc.descuentoSubtotal = long.Parse(_c.DESCUENTO_LIN);
                    _pc.fleteUnitario = long.Parse(_c.FLETE_UNIT);
                    _pc.fleteSubtotal = long.Parse(_c.FLETE_LIN);
                    _pc.precioTotal = long.Parse(_c.TOTAL_LIN);
                    _lpc.Add(_pc);
                }
                foreach (productosCarro _pcs in _lpc)
                {
                    foreach (DataRow _drp in _d.Rows)
                    {
                        if (_drp["codigo"].ToString() == _pcs.Producto)
                        {
                            productosCarro _pc = new productosCarro();
                            _pc.Producto = _pcs.Producto;
                            _pc.Nombre = _drp["nombre"].ToString();
                            _pc.cantidad = _pcs.cantidad;
                            _pc.precioUnitario = _pcs.precioUnitario;
                            _pc.precioSubtotal = _pcs.precioSubtotal;
                            _pc.descuentoUnitario = _pcs.descuentoUnitario;
                            _pc.descuentoSubtotal = _pcs.descuentoSubtotal;
                            _pc.fleteUnitario = _pcs.fleteUnitario;
                            _pc.fleteSubtotal = _pcs.fleteSubtotal;
                            _pc.precioTotal = _pcs.precioTotal;
                            
                            _lpcf.Add(_pc);
                        }
                    }
                }
            }
            _detcar.productos = _lpcf;
        }
        catch (Exception ex)
        {
            _detcar.isValid = false;
            _detcar.mensaje = ex.Message;
        }
        return _detcar;
    }
}
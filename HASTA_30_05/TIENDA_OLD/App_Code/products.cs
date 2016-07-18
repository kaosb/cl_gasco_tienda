using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for products
/// </summary>
public class products
{
    public string homeUrl = "http://tienda.gasco.cl";
	public products()
	{
	}
    cypher cp = new cypher();
    tienda.qa.SrvGCOksk ws = new tienda.qa.SrvGCOksk();
    tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam consultaProductosParam = new tienda.qa.ZKSK_CONSULTA_PRODUCTOSParam();
    public ProducData getProductData(string pn)
    {
        string _codigoProducto = pn;
        ProducData _retorno = new ProducData();
        consultaProductosParam.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _cpr = ws.ZKSK_CONSULTA_PRODUCTOS(consultaProductosParam);
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _cpr.O_T_PRODUCTO)
        {
            if (_p.PRODUCTO == _codigoProducto)
            {
                _retorno.nombre = _p.DESCRIPCION;
                _retorno.codigo = _p.PRODUCTO;
                _retorno.precio = long.Parse(_p.PRECIO);
                _retorno.descripcion = _p.GLOSA;
                _retorno.descripcion2 = _p.GLOSA_EXT;
            }
        }
        return _retorno;
    }
    public List<ProducData> getAllProducts()
    {
        List<ProducData> s = new List<ProducData>();
        consultaProductosParam.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _cpr = ws.ZKSK_CONSULTA_PRODUCTOS(consultaProductosParam);
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _cpr.O_T_PRODUCTO)
        {
            ProducData _retorno = new ProducData();
            _retorno.nombre = _p.DESCRIPCION;
            _retorno.codigo = _p.PRODUCTO;
            _retorno.precio = long.Parse(_p.PRECIO);
            _retorno.descripcion = _p.GLOSA;
            _retorno.descripcion2 = _p.GLOSA_EXT;
            _retorno.descuento = _p.VALE_DSCTO;
            _retorno.descuentovalor = _p.VALE_DSCTO_MNT;
            _retorno.valecil = _p.VALE_CIL;
            _retorno.valeciltexto = _p.VALE_CIL_DESC;
            s.Add(_retorno);
        }
        return s;
    }
    public struct caracteristicas
    {
        public int sort { get; set; }
        public string key { get; set; }
        public string val { get; set; }
    }
    public struct subcat
    {
        public List<valores> texto { get; set; }
    }
    public struct valores
    {
        public string texto { get; set; }
        public string uri { get; set; }
    }
    private string ucf(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
    class sortCaracteristicas : IComparer<caracteristicas>
    {
        public int Compare(caracteristicas x, caracteristicas y)
        {
            if (x.sort > y.sort) return 1;
            else if (x.sort < y.sort) return -1;
            else return 0;
        }
    }
    public class sortProductos : IComparer<ProducData>
    {
        public int Compare(ProducData x, ProducData y)
        {
            if (x.precio > y.precio) return 1;
            else if (x.precio < y.precio) return -1;
            else return 0;
        }
    }
    public List<caracteristicas> getCaracteristicas(string producto)
    {
        List<caracteristicas> s = new List<caracteristicas>();
        tienda.qa.ZKSK_CONSULTA_CARACTERISTICASParam _ccp = new tienda.qa.ZKSK_CONSULTA_CARACTERISTICASParam();
        _ccp.I_PRODUCTO = producto;
        tienda.qa.ZKSK_CONSULTA_CARACTERISTICASRet _rp = ws.ZKSK_CONSULTA_CARACTERISTICAS(_ccp);
        if (_rp.Retorno == "")
        {
            foreach (tienda.qa.ZKSK_PROD_CARACT_RFC _ca in _rp.O_T_CARACTERISTICAS)
            {
                caracteristicas x = new caracteristicas();
                x.sort = _ca.INDICE;
                x.key = _ca.CARACTERISTICA;
                x.val = _ca.VALOR_CARACT;
                s.Add(x);
            }
        }
        else
        {
            caracteristicas x = new caracteristicas();
            x.sort = 0;
            x.key = "sin datos";
            x.val = "";
            s.Add(x);
        }
        sortCaracteristicas sc = new sortCaracteristicas();
        s.Sort(sc);
        return s;
    }
    public string prodDictionary(string value)
    {
        
        string result = value.ToLower();
        value = result.Trim();
        result = value.Replace("-", " ");
        switch (result)
        {
            case "calefaccion":
                result = "calefacción";
                break;
            case "de cilindro":
                result = "de cilíndro";
                break;
            default:
                break;
        }
        return ucf(result);
    }
    public string checKCategory(string value)
    {
        switch (value)
        {
            case "calefaccion":
                return "R";
            case "cocinas-y-hornos":
                return "R";
            case "calefones-y-termos":
                return "R";
            case "patio-y-terraza":
                return "R";
            case "patio-heater":
                return "C";
            case "hornos":
                return "C";
            case "cocina":
                return "C";
            case "otros":
                return "C";
            default:
                return "R";
        }
    }
    public struct ProducData
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public long precio { get; set; }
        public string descripcion { get; set; }
        public string descripcion2 { get; set; }
        public string familia { get; set; }
        public string categoria { get; set; }
        public string subcat { get; set; }
        public string descuento { get; set; }
        public string descuentovalor { get; set; }
        public string valecil { get; set; }
        public string valeciltexto { get; set; }
    }
    public struct ProducList
    {
        public bool isValid { get; set; }
        public string breadCrumb { get; set; }
        public List<ProducData> products { get; set; }
    }
    public ProducList getProductDataByFam(string myval)
    {
        ProducList _retorno = new ProducList();
        _retorno.isValid = false;
        List<ProducData> _ptemp = new List<ProducData>();
        List<ProducData> _plist = new List<ProducData>();
        consultaProductosParam.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _cpr = ws.ZKSK_CONSULTA_PRODUCTOS(consultaProductosParam);
        foreach (tienda.qa.ZKSK_JERARQUIA_RFC _jrfc in _cpr.O_T_JERARQUIA)
        {
            if (myval.ToLower() == _jrfc.FAMILIA.ToLower())
            {
                ProducData _prod = new ProducData();
                _prod.codigo = _jrfc.PRODUCTO;
                _prod.familia = _jrfc.FAMILIA;
                _prod.categoria = _jrfc.CATEGORIA;
                _prod.subcat = _jrfc.SUBCATEGORIA;
                _ptemp.Add(_prod);
                _retorno.breadCrumb = "<span><a href='" + homeUrl + "'>Home</a></span> | <span class='current-bc'><a href='ver-categoria.aspx?f=" + _jrfc.FAMILIA + "'>" + prodDictionary(_jrfc.FAMILIA) + "</a></span>";
            }
        }
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _cpr.O_T_PRODUCTO)
        {
            foreach (ProducData _pdata in _ptemp)
            {
                if (_pdata.codigo == _p.PRODUCTO)
                {
                    ProducData _pfinal = new ProducData();
                    _pfinal.codigo = _pdata.codigo;
                    _pfinal.familia = _pdata.familia;
                    _pfinal.categoria = _pdata.categoria;
                    _pfinal.subcat = _pdata.subcat;
                    _pfinal.nombre = _p.DESCRIPCION;
                    _pfinal.precio = long.Parse(_p.PRECIO);
                    _pfinal.descripcion = _p.GLOSA;
                    _pfinal.descripcion2 = _p.GLOSA_EXT;
                    _retorno.isValid = true;
                    _plist.Add(_pfinal);
                }
            }
        }
        _retorno.products = _plist;
        return _retorno;
    }
    public ProducList getProductDataByCat(string myval)
    {
        ProducList _retorno = new ProducList();
        _retorno.isValid = false;
        List<ProducData> _ptemp = new List<ProducData>();
        List<ProducData> _plist = new List<ProducData>();
        consultaProductosParam.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _cpr = ws.ZKSK_CONSULTA_PRODUCTOS(consultaProductosParam);
        foreach (tienda.qa.ZKSK_JERARQUIA_RFC _jrfc in _cpr.O_T_JERARQUIA)
        {
            if (myval.ToLower() == _jrfc.CATEGORIA.ToLower())
            {
                ProducData _prod = new ProducData();
                _prod.codigo = _jrfc.PRODUCTO;
                _prod.familia = _jrfc.FAMILIA;
                _prod.categoria = _jrfc.CATEGORIA;
                _prod.subcat = _jrfc.SUBCATEGORIA;
                _ptemp.Add(_prod);
                _retorno.breadCrumb = "<span><a href='" + homeUrl + "'>Home</a></span> | <a href='ver-categoria.aspx?f=" + _jrfc.FAMILIA + "'>" + prodDictionary(_jrfc.FAMILIA) + "</a>" + " | " + "<span class='current-bc'><a href='ver-categoria.aspx?c=" + _jrfc.CATEGORIA + "'>" + prodDictionary(_jrfc.CATEGORIA) + "</a></span>";
            }
        }
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _cpr.O_T_PRODUCTO)
        {
            foreach (ProducData _pdata in _ptemp)
            {
                if (_pdata.codigo == _p.PRODUCTO)
                {
                    ProducData _pfinal = new ProducData();
                    _pfinal.codigo = _pdata.codigo;
                    _pfinal.familia = _pdata.familia;
                    _pfinal.categoria = _pdata.categoria;
                    _pfinal.subcat = _pdata.subcat;
                    _pfinal.nombre = _p.DESCRIPCION;
                    _pfinal.precio = long.Parse(_p.PRECIO);
                    _pfinal.descripcion = _p.GLOSA;
                    _pfinal.descripcion2 = _p.GLOSA_EXT;
                    _retorno.isValid = true;
                    _plist.Add(_pfinal);
                }
            }
        }
        _retorno.products = _plist;
        return _retorno;
    }
    public ProducList getProductDataBysubCat(string myval)
    {
        ProducList _retorno = new ProducList();
        _retorno.isValid = false;
        List<ProducData> _ptemp = new List<ProducData>();
        List<ProducData> _plist = new List<ProducData>();
        consultaProductosParam.I_CODCLIENTE = "";
        tienda.qa.ZKSK_CONSULTA_PRODUCTOSRet _cpr = ws.ZKSK_CONSULTA_PRODUCTOS(consultaProductosParam);
        foreach (tienda.qa.ZKSK_JERARQUIA_RFC _jrfc in _cpr.O_T_JERARQUIA)
        {
            if (myval.ToLower() == _jrfc.SUBCATEGORIA.ToLower())
            {
                ProducData _prod = new ProducData();
                _prod.codigo = _jrfc.PRODUCTO;
                _prod.familia = _jrfc.FAMILIA;
                _prod.categoria = _jrfc.CATEGORIA;
                _prod.subcat = _jrfc.SUBCATEGORIA;
                _ptemp.Add(_prod);
                _retorno.breadCrumb = "<span><a href='" + homeUrl + "'>Home</a></span> | <a href='ver-categoria.aspx?f=" + _jrfc.FAMILIA + "'>" + prodDictionary(_jrfc.FAMILIA) + "</a>" + " | " + "<a href='ver-categoria.aspx?c=" + _jrfc.CATEGORIA + "'>" + prodDictionary(_jrfc.CATEGORIA) + "</a>" + " | " + "<span class='current-bc'><a href='ver-categoria.aspx?s=" + _jrfc.SUBCATEGORIA + "'>" + prodDictionary(_jrfc.SUBCATEGORIA) + "</a></span>";
            }
        }
        foreach (tienda.qa.ZKSK_PRODUCTOS _p in _cpr.O_T_PRODUCTO)
        {
            foreach (ProducData _pdata in _ptemp)
            {
                if (_pdata.codigo == _p.PRODUCTO)
                {
                    ProducData _pfinal = new ProducData();
                    _pfinal.codigo = _pdata.codigo;
                    _pfinal.familia = _pdata.familia;
                    _pfinal.categoria = _pdata.categoria;
                    _pfinal.subcat = _pdata.subcat;
                    _pfinal.nombre = _p.DESCRIPCION;
                    _pfinal.precio = long.Parse(_p.PRECIO);
                    _pfinal.descripcion = _p.GLOSA;
                    _pfinal.descripcion2 = _p.GLOSA_EXT;
                    _retorno.isValid = true;
                    _plist.Add(_pfinal);
                }
            }
        }
        _retorno.products = _plist;
        return _retorno;
    }
    public List<ListItem> comunas()
    {
        List<ListItem> _s = new List<ListItem>();
        tienda.qa.ZKSK_CONSULTA_COMUNASRet _ret = ws.ZKSK_CONSULTA_COMUNAS(null);
        if (_ret.Retorno.Trim() == "")
        {
            ListItem _l1 = new ListItem("Selecciona tu comuna", "0");
            _s.Add(_l1);
            foreach (tienda.qa.ZKSK_COMUNAS _com in _ret.O_T_COMUNAS)
            {
                if (_com.REGION_COD == "13")
                {
                    ListItem _l2 = new ListItem(_com.COMUNA_TXT, _com.COMUNA_TXT);
                    _s.Add(_l2);
                }
            }
        }
        else
        {
            ListItem _li = new ListItem("Error al cargar comunas","0");
            _s.Add(_li);
        }
        return _s;
    }
    private List<tienda.qa.ZKSK_COMPRA_PRODUCTOS> productoFlete(string cod)
    {
        List<tienda.qa.ZKSK_COMPRA_PRODUCTOS> _l = new List<tienda.qa.ZKSK_COMPRA_PRODUCTOS>();
        tienda.qa.ZKSK_COMPRA_PRODUCTOS _c = new tienda.qa.ZKSK_COMPRA_PRODUCTOS();
        _c.CANTIDAD = 1;
        _c.PRODUCTO = cod;
        _l.Add(_c);
        return _l;
    }
    public string calculaFlete(string com, string cod)
    {
        string _s = "";
        tienda.qa.ZKSK_CONSULTA_PRECIO_FLETEParam _p = new tienda.qa.ZKSK_CONSULTA_PRECIO_FLETEParam();
        _p.I_COMUNA = com;
        _p.I_ORGVTA = "7100";
        tienda.qa.ZKSK_COMPRA_PRODUCTOS _cp = new tienda.qa.ZKSK_COMPRA_PRODUCTOS();
        _p.I_T_PRODUCTOS = productoFlete(cod).ToArray();
        tienda.qa.ZKSK_CONSULTA_PRECIO_FLETERet _ret = ws.ZKSK_CONSULTA_PRECIO_FLETE(_p);
        if (_ret.Retorno.Trim() == "")
        {
            _s = "<span class='desp1'>Valor de despacho:</span><span class='desp2'>$" + (long.Parse(_ret.O_TOTAL_FLETE)).ToString("N0") + "</span>";
        }
        else
        {
            _s = "<span class='desp1'>" + _ret.Mensaje + "</span>";
        }
        return _s;
    }
    public string getImgbyDesc(string desc)
    {
        string temp = desc.ToLower();
        string iname = null;
        if (temp.Contains("ursus"))
        {
            iname = "imgProductos/ursus-trotter-logo.jpg";
        }
        else if (temp.Contains("albin"))
        {
            iname = "imgProductos/albin-trotter-logo.jpg";
        }
        else if (temp.Contains("thermax"))
        {
            iname = "imgProductos/thermax-logo.jpg";
        }
        else if (temp.Contains("rinnai"))
        {
            iname = "imgProductos/rinnai-logo.jpg";
        }
        else if (temp.Contains("junker"))
        {
            iname = "imgProductos/junkers-logo.jpg";
        }
        else if (temp.Contains("italkero"))
        {
            iname = "imgProductos/italkero-logo.jpg";
        }
        else
        {
            iname = "imgProductos/ESTUFA_GASCO_2KG-logo.png";
        }
        return iname;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for contact
/// </summary>
public class contact
{
    gasco.mail.SucOnlineServ wsm = new gasco.mail.SucOnlineServ();
    gasco.mail.MailMessage mmsg = new gasco.mail.MailMessage();
    tienda.qa.SrvGCOksk ws = new tienda.qa.SrvGCOksk();
	public contact()
	{
	}
    #region structs
    public string charsnombre = "abcdefghijklmnopqrstuvwxyzñQWERTYUIOPÑLKJHGFDSAZXCVBNMáéíóúÁÉÍÓÚ ";
    public string charsrut = "1234567890k-K";
    public string charsnum = "1234567890";
    public string charscalle = "1234567890abcdefghijklmnopqrstuvwxyzñQWERTYUIOPÑLKJHGFDSAZXCVBNMáéíóúÁÉÍÓÚ ." + "#,";
    public string charsmail = "abcdefghijklmnopqrstuvwxyzñQWERTYUIOPÑLKJHGFDSAZXCVBNM_-@.0123456789";
    public string charsmensaje = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYSáéíóúÁÉÍÓÚ !().,-_?¿¡0123456789#@";

    #endregion
    #region methods
    public List<ListItem> getMotivos()
    {
        List<ListItem> s = new List<ListItem>();
        string[] motivos = new string[] { "Compra en línea de artefactos", "Sugerencias", "Reclamos", "Felicitaciones" };
        foreach (string v in motivos)
        {
            ListItem r1 = new ListItem();
            r1.Text = v;
            r1.Value = v;
            s.Add(r1);
        }
        return s;
    }
    public List<ListItem> regiones()
    {
        List<ListItem> _s = new List<ListItem>();
        tienda.qa.ZKSK_CONSULTA_COMUNASRet _ret = ws.ZKSK_CONSULTA_COMUNAS(null);
        if (_ret.Retorno.Trim() == "")
        {
            ListItem _l1 = new ListItem("Selecciona tu región", "0");
            _s.Add(_l1);
            foreach (tienda.qa.ZKSK_COMUNAS _com in _ret.O_T_COMUNAS)
            {
                if (!_s.Contains(new ListItem(_com.REGION_TXT, _com.REGION_COD)))
                {
                    ListItem _l2 = new ListItem(_com.REGION_TXT, _com.REGION_COD);
                    _s.Add(_l2);
                }
            }
            _s.Distinct().ToList();
        }
        else
        {
            ListItem _li = new ListItem("Error al cargar regiones", "0");
            _s.Add(_li);
        }
        return _s;
    }
    public string capitalizeMe(string s)
    {
        string aux = s.ToLower();
        s = aux.Substring(0, 1).ToUpper() + aux.Substring(1, aux.Length - 1);
        return s;
    }
    public string mailHead()
    {
        string r = "";
        r = "<table style='display: inline-table;font-family:Arial; font-size:11px;color:#363d46;' border='0' cellpadding='0' cellspacing='0' width='550'>" +
        "<tr>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='34' height='1' border='0' alt='' /></td>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='478' height='1' border='0' alt='' /></td>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='38' height='1' border='0' alt='' /></td>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='1' height='1' border='0' alt='' /></td>" +
        "</tr>" +
        "<tr>" +
        "<td><img name='tiendaartefactos_r1_c1' src='http://www.gasco.cl/img/mailTienda/blank.jpg' width='34' height='58' border='0' alt='' /></td>" +
        "<td><img name='tiendaartefactos_r1_c2' src='http://www.gasco.cl/img/mailTienda/logo.jpg' width='478' height='58' border='0' alt='' /></td>" +
        "<td><img name='tiendaartefactos_r1_c3' src='http://www.gasco.cl/img/mailTienda/blank.jpg' width='38' height='58' border='0' alt='' /></td>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='1' height='58' border='0' alt='' /></td>" +
        "</tr><tr><td></td><td>";
        return r;
    }
    public string mailFooter()
    {
        string r = "";
        r = "</td><td></td><tr>" +
        "<td colspan='3'><img name='tiendaartefactos_r11_c1' src='http://www.gasco.cl/img/mailTienda/r11_c1.jpg' width='550' height='37' border='0' alt='' /></td>" +
        "<td><img src='http://www.gasco.cl/img/mailTienda/spacer.gif' width='1' height='37' border='0' alt='' /></td>" +
        "</tr>" +
        "</table>";
        return r;
    }
    public bool sendMail(string content)
    {
        bool result = false;
        string mkey = "6FAEF3DE-1C2C-4e56-A57F-AB7D73D8D21B";
        mmsg.From = "contacto@gasco.cl";
        mmsg.SUBJ = "Contacto Tienda en línea";
        mmsg.TO = "gascoenvios@gmail.com";
        mmsg.HtmlContent = mailHead() + content + mailFooter();
        gasco.mail.MailMessageRetorno ret = wsm.SendMail(mmsg, mkey);
        if (ret.Retorno.Trim() == "")
        {
            result = true;
        }
        return result;
    }
    public bool sendMailResponse(string to)
    {
        bool result = false;
        string mkey = "6FAEF3DE-1C2C-4e56-A57F-AB7D73D8D21B";
        mmsg.From = "contacto@gasco.cl";
        mmsg.SUBJ = "Tienda en línea Gasco Tu pregunta ha sido recibida";
        mmsg.TO = to;
        mmsg.HtmlContent = mailHead() + "<p>Tu pregunta ha sido recibida con éxito, pronto nos pondremos en contacto contigo para resolver tus dudas.</p>" + mailFooter();
        gasco.mail.MailMessageRetorno ret = wsm.SendMail(mmsg, mkey);
        if (ret.Retorno.Trim() == "")
        {
            result = true;
        }
        return result;
    }
    public List<ListItem> provincias(string idcon)
    {
        List<ListItem> _s = new List<ListItem>();
        tienda.qa.ZKSK_CONSULTA_COMUNASRet _ret = ws.ZKSK_CONSULTA_COMUNAS(null);
        if (_ret.Retorno.Trim() == "")
        {
            ListItem _l1 = new ListItem("Selecciona tu ciudad", "0");
            _s.Add(_l1);
            foreach (tienda.qa.ZKSK_COMUNAS _com in _ret.O_T_COMUNAS)
            {
                if (_com.REGION_TXT == idcon && !_s.Contains(new ListItem(_com.CIUDAD_TXT, _com.CIUDAD_COD)))
                {
                    ListItem _l2 = new ListItem(_com.CIUDAD_TXT, _com.CIUDAD_COD);
                    _s.Add(_l2);
                }
            }
        }
        else
        {
            ListItem _li = new ListItem("Error al cargar ciudades", "0");
            _s.Add(_li);
        }
        return _s;
    }
    public List<ListItem> comunas(string idcon)
    {
        List<ListItem> _s = new List<ListItem>();
        tienda.qa.ZKSK_CONSULTA_COMUNASRet _ret = ws.ZKSK_CONSULTA_COMUNAS(null);
        if (_ret.Retorno.Trim() == "")
        {
            ListItem _l1 = new ListItem("Selecciona tu comuna", "0");
            _s.Add(_l1);
            foreach (tienda.qa.ZKSK_COMUNAS _com in _ret.O_T_COMUNAS)
            {
                if (_com.CIUDAD_TXT == idcon)
                {
                    ListItem _l2 = new ListItem(_com.COMUNA_TXT, _com.COMUNA_TXT);
                    _s.Add(_l2);
                }
            }
        }
        else
        {
            ListItem _li = new ListItem("Error al cargar comunas", "0");
            _s.Add(_li);
        }
        return _s;
    }

    #endregion
    #region validaciones
    public bool validateNombre(string txt)
    {
        return regthis(@"^[a-záéíóúA-ZÁÉÍÓÚñÑ \-]{2,25}$", txt);
    }
    public bool validateEdad(string txt)
    {
        return regthis(@"^[0-9\-]{2,3}$", txt);
    }
    public bool validateMail(string txt)
    {
        return regthis(@"^[a-zA-Z0-9._\-]{2,25}[@]{1}[a-z0-9._\-]{2,25}[.]{1}[a-z]{2,3}$", txt);
    }
    public bool validateFono(string txt)
    {
        return regthis(@"^[0-9]{5,8}$", txt);
    }
    public bool validateDireccion(string txt)
    {
        return regthis(@"^[a-zñÑ A-ZáéíóúÁÉÍÓÚ#0-9,.]{5,50}$", txt);
    }
    public bool validateCombos(string txt)
    {
        if (txt.Contains("Selecciona")) { return false; } else { return true; }
    }
    public bool validateNumdir(string txt)
    {
        return regthis(@"^[0-9]{1,8}$", txt);
    }
    public bool regthis(string reg, string val)
    {
        try
        {
            Regex rx = new Regex(reg);
            if (rx.IsMatch(val))
            { return true; }
            else { return false; }
        }
        catch
        {
            return false;
        }
    }
    public bool validaRut(string fullrut)
    {
        try
        {
            int rut = int.Parse(fullrut.Split('-')[0].ToString());
            string mydv = fullrut.Split('-')[1].ToString();
            if (mydv == "k" || mydv == "K") { mydv = "K"; }
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }
            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }

            if (mydv == RutDigito && fullrut.Length > 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
    #endregion
}
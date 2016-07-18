using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cliente
/// </summary>
public class cliente
{
	public cliente()
	{
	}
    tienda.qa.SrvGCOksk ws = new tienda.qa.SrvGCOksk();
    tienda.qa.ZKSK_CONSULTA_CLI_RUTParam conclirut = new tienda.qa.ZKSK_CONSULTA_CLI_RUTParam();
    tienda.qa.ZKSK_CONSULTA_DATOS_CLIENTEParam condatcli = new tienda.qa.ZKSK_CONSULTA_DATOS_CLIENTEParam();
    tienda.qa.ZKSK_CONSULTA_DIRECC_CLIENTEParam condircli = new tienda.qa.ZKSK_CONSULTA_DIRECC_CLIENTEParam();
    tienda.qa.ZKSK_CREA_DIRECC_CLIENTEParam credircli = new tienda.qa.ZKSK_CREA_DIRECC_CLIENTEParam();
    tienda.qa.ZKSK_CREA_PROSPECTOParam creprocli = new tienda.qa.ZKSK_CREA_PROSPECTOParam();
    tienda.qa.ZKSK_ELIMINA_DIRECC_CLIENTEParam elidircli = new tienda.qa.ZKSK_ELIMINA_DIRECC_CLIENTEParam();
    tienda.qa.ZKSK_MODIFICA_CLIENTEParam moddatcli = new tienda.qa.ZKSK_MODIFICA_CLIENTEParam();
    tienda.qa.ZKSK_MODIFICA_PROSPECTOParam moddatpro = new tienda.qa.ZKSK_MODIFICA_PROSPECTOParam();
    string sqlservcon = "server=200.29.21.246;database=Gasco;uid=testgasco;password=6776Y426";
    public struct datosClientes
    {
        public bool valido { get; set; }
        public datoCliente Cliente { get; set; }
        public datoDireccion Direccion { get; set; }
    }
    public struct datoCliente
    {
        public int id { get; set; }
        public string ncliente { get; set; }
        public string tipo { get; set; }
        public string rut { get; set; }
        public string nombres { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public int codArea { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string razonSocial { get; set; }
        public string email { get; set; }
    }
    public struct direccionesCliente
    {
        public bool valido { get; set; }
        public string errorMessage { get; set; }
        public string rut { get; set; }
        public string cliente { get; set; }
        public List<datoDireccion> Direcciones { get; set; }
    }
    public struct datoDireccion
    {
        public string dir_id { get; set; }
        public string dir_calle { get; set; }
        public int dir_numero { get; set; }
        public string dir_depto { get; set; }
        public string dir_otro { get; set; }
        public string dir_region { get; set; }
        public string dir_provincia { get; set; }
        public string dir_comuna { get; set; }
        public string dir_orgventa { get; set; }
        public string dir_completa { get; set; }
    }
    public struct minDatoCliente
    {
        public bool valido {get; set; }
        public string Errormsg { get; set; }
        public string numeroCliente { get; set; }
        public string idDireccion { get; set; }
        public string orgVenta { get; set; }
    }
    public struct minDireccionCiente
    {
        public bool valido { get; set; }
        public string Errormsg { get; set; }
        public string idDireccion { get; set; }
        public string orgVenta { get; set; }
    }
    public minDireccionCiente eliminaDireccion(string addressid, string ncliente)
    {
        minDireccionCiente _ds = new minDireccionCiente();
        try
        {
            elidircli.I_ADDRESS_ID = addressid;
            elidircli.I_CLIENTE = ncliente;
            tienda.qa.ZKSK_ELIMINA_DIRECC_CLIENTERet _ret = ws.ZKSK_ELIMINA_DIRECC_CLIENTE(elidircli);
            if (_ret.Retorno.Trim() == "")
            {
                _ds.valido = true;
            }
            else
            {
                _ds.valido = false;
                _ds.Errormsg = _ret.Mensaje;
            }
        }
        catch (Exception ex)
        {
            _ds.valido = false;
            _ds.Errormsg = ex.Message;
        }
        return _ds;
    }
    public direccionesCliente getDirecciones(string Ncliente)
    {
        direccionesCliente _ds = new direccionesCliente();
        try
        {
            condircli.I_CLIENTE = Ncliente;
            List<datoDireccion> ld = new List<datoDireccion>();
            _ds.cliente = Ncliente;
            tienda.qa.ZKSK_CONSULTA_DIRECC_CLIENTERet _ret = ws.ZKSK_CONSULTA_DIRECC_CLIENTE(condircli);
            if (_ret.Retorno.Trim() == "")
            {
                foreach (tienda.qa.ZKSK_DIR_CLIENTE_RFC _dc in _ret.O_T_DIRECCIONES)
                {
                    if (_dc.ACTIVO == "X" || _dc.ACTIVO == "x")
                    {
                        datoDireccion _dd = new datoDireccion();
                        _dd.dir_id = _dc.ADDRESS_ID;
                        _dd.dir_calle = _dc.CALLE;
                        _dd.dir_numero = int.Parse(_dc.NUMERO);
                        _dd.dir_depto = _dc.COMP_DIR;
                        _dd.dir_comuna = _dc.COMUNA;
                        _dd.dir_provincia = _dc.CIUDAD;
                        _dd.dir_region = _dc.REGION;
                        _dd.dir_orgventa = _dc.ORGVTA;
                        _dd.dir_completa = _dc.CALLE + " #" + _dc.NUMERO + " " + _dc.COMP_DIR + ", " + _dc.COMUNA;
                        ld.Add(_dd);
                        _ds.valido = true;
                    }
                }
                _ds.Direcciones = ld;
            }
            else
            {
                _ds.valido = false;
                _ds.errorMessage = _ret.Mensaje;
            }
        }
        catch (Exception ex)
        {
            _ds.valido = false;
            _ds.errorMessage = ex.Message;
        }

        return _ds;
    }
    public minDireccionCiente grabaDireccion(datosClientes dd)
    {
        minDireccionCiente _ds = new minDireccionCiente();
        try
        {
            credircli.I_CALLE = dd.Direccion.dir_calle;
            credircli.I_CIUDAD = dd.Direccion.dir_provincia;
            credircli.I_CLIENTE = dd.Cliente.ncliente;
            credircli.I_COMUNA = dd.Direccion.dir_comuna;
            credircli.I_COMP_DIR = dd.Direccion.dir_depto;
            credircli.I_NUMERO = dd.Direccion.dir_numero.ToString();
            credircli.I_REGION = dd.Direccion.dir_region;
            credircli.I_TIPO = "P";
            tienda.qa.ZKSK_CREA_DIRECC_CLIENTERet _ret = ws.ZKSK_CREA_DIRECC_CLIENTE(credircli);
            if (_ret.Retorno.Trim() == "")
            {
                _ds.valido = true;
                _ds.Errormsg = "";
                _ds.idDireccion = _ret.O_DIRECCION_ID;
                _ds.orgVenta = _ret.O_ORGVTA;
            }
            else
            {
                _ds.valido = false;
                _ds.Errormsg = _ret.Mensaje;
            }
        }
        catch (Exception ex)
        {
            _ds.valido = false;
            _ds.Errormsg = ex.Message;
        }
        return _ds;
    }
    public minDatoCliente creaProspecto(datosClientes dc)
    {
        minDatoCliente _ds = new minDatoCliente();
        try
        {
            creprocli.I_CALLE = dc.Direccion.dir_calle;
            creprocli.I_CIUDAD = dc.Direccion.dir_provincia;
            creprocli.I_COMUNA = dc.Direccion.dir_comuna;
            creprocli.I_COMP_DIR = dc.Direccion.dir_depto;
            creprocli.I_EMAIL = dc.Cliente.email;
            creprocli.I_NOMBRE = dc.Cliente.nombres + " " + dc.Cliente.apellidoP + " " + dc.Cliente.apellidoM;
            creprocli.I_NUMERO = dc.Direccion.dir_numero.ToString();
            creprocli.I_REGION = dc.Direccion.dir_region;
            creprocli.I_RUT = dc.Cliente.rut;
            creprocli.I_TIPO = "P";
            creprocli.I_TEL_FIJO = dc.Cliente.telefono;
            creprocli.I_TEL_MOVIL = dc.Cliente.celular;
            tienda.qa.ZKSK_CREA_PROSPECTORet _ret = ws.ZKSK_CREA_PROSPECTO(creprocli);
            if (_ret.Retorno.Trim() == "")
            {
                _ds.valido = true;
                _ds.Errormsg = "";
                _ds.idDireccion = _ret.O_DIRECCION_ID;
                _ds.numeroCliente = _ret.O_CLIENTE_PROSPECTO;
                _ds.orgVenta = _ret.O_ORGVTA;
            }
            else
            {
                _ds.valido = false;
                _ds.Errormsg = _ret.Mensaje;
            }
        }
        catch(Exception ex)
        {
            _ds.valido = false;
            _ds.Errormsg = ex.Message;
        }
        return _ds;
    }
    public datosClientes checkUserbyRut(string rut)
    {
        datosClientes _ds = new datosClientes();
        conclirut.I_RUT = rut;
        tienda.qa.ZKSK_CONSULTA_CLI_RUTRet _ret = ws.ZKSK_CONSULTA_CLI_RUT(conclirut);
        try
        {
            if (_ret.Retorno.Trim() == "")
            {
                datoCliente _cli = new datoCliente();
                foreach (tienda.qa.ZKSK_CLI_X_RUT _cr in _ret.O_T_CLIENTES)
                {
                    _cli.rut = rut;
                    _cli.nombres = _cr.NOMBRE;
                    _cli.ncliente = _cr.CLIENTE;
                    _cli.telefono = _cr.TEL_FIJO;
                    _cli.celular = _cr.TEL_MOVIL;
                    if (_cr.CLIENTE.Contains("PROS"))
                    {
                        _cli.tipo = "Prospecto";
                    }
                    else
                    {
                        _cli.tipo = "Cliente";
                    }
                    _cli.email = _cr.EMAIL;
                }
                _ds.Cliente = _cli;
                datoDireccion _dir = new datoDireccion();
                foreach (tienda.qa.ZKSK_DIR_CLIENTE_RFC _dd in _ret.O_T_DIRECCIONES)
                {
                    if (_dd.ACTIVO == "X" || _dd.ACTIVO == "x")
                    {
                        _dir.dir_id = _dd.ADDRESS_ID;
                        _dir.dir_calle = _dd.CALLE;
                        _dir.dir_numero = int.Parse(_dd.NUMERO);
                        _dir.dir_depto = _dd.COMP_DIR;
                        _dir.dir_comuna = _dd.COMUNA;
                        _dir.dir_provincia = _dd.CIUDAD;
                        _dir.dir_region = _dd.REGION;
                        _dir.dir_orgventa = _dd.ORGVTA;
                    }
                }
                _ds.Direccion = _dir;
                _ds.valido = true;
            }
            else
            {
                _ds.valido = false;
            }
        }
        catch
        {
            _ds.valido = false;
        }
        return _ds;
    }
    
}
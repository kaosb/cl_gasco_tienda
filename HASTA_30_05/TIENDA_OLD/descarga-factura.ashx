<%@ WebHandler Language="C#" Class="descarga_factura" %>

using System;
using System.Web;
using pdf.qa;

public class descarga_factura : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            context.Response.ContentType = "text/plain";
            string output = "";
            string com = context.Request.QueryString["doc"];
            RFCWebServ ws = new RFCWebServ();
            ZZFEAZ_GETPDFParam p = new ZZFEAZ_GETPDFParam();
            p.INDFONDO = "";
            p.VBELN = com;
            if (com.Length < 10)
            {
                p.VBELN = long.Parse(com).ToString("D0");
            }
            ZZFEAZ_GETPDFRet ret = ws.ZZFEAZ_GETPDF(p);
            if (ret.Retorno.Trim() == "")
            {
                genPDF(ret.PDFDATA, context, p.VBELN);
            }
            else
            {
                context.Response.Write(ret.Mensaje);
            }
        }
        catch
        {
            context.Response.Write("no se encuentra factura");
        }
    }
    private void genPDF(byte[] pdfFile, HttpContext context, string factura)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/pdf";
        context.Response.AppendHeader("Content-Disposition", "attachment;filename=facturaN" + factura + ".pdf");
        context.Response.BufferOutput = true;
        context.Response.AddHeader("Content-Length", pdfFile.Length.ToString());
        context.Response.BinaryWrite(pdfFile);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
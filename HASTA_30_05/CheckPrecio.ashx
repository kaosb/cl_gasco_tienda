<%@ WebHandler Language="C#" Class="CheckPrecio" %>

using System;
using System.Web;


public class CheckPrecio : IHttpHandler {
    products productos = new products();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string output = null;
        string com = context.Request.Form["com"];
        string cod = context.Request.Form["cod"];
        output = productos.calculaFlete(com, cod);        
        context.Response.Write(output);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
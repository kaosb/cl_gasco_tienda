<%@ WebHandler Language="C#" Class="logout" %>

using System;
using System.Web;

public class logout : IHttpHandler, System.Web.SessionState.IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Session.Abandon();
        context.Response.Write("Sesión finalizada");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
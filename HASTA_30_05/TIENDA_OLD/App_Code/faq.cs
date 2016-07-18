using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for faq
/// </summary>
public class faq
{
	public faq()
	{
	}
    public string constring = "Data Source=200.29.21.246;Initial Catalog=GascoTienda;User ID=sa;Pwd=aErGS1L852x2";
    public struct preguntas
    {
        public string categoria { get; set; }
        public string pregunta { get; set; }
        public string respuesta { get; set; }
    }
    public List<preguntas> getPreguntas(string cat)
    {
        List<preguntas> sa = new List<preguntas>();
        SqlDataSource myds = new SqlDataSource();
        myds.ConnectionString = constring;
        SqlConnection mycon = new SqlConnection(myds.ConnectionString);
        SqlCommand mycom = new SqlCommand("select * from tienda_preguntas_frecuentes where Categoria = '" + cat + "' order by Categoria, Orden ", mycon);
        mycon.Open();
        try
        {
            SqlDataReader myreader = mycom.ExecuteReader(CommandBehavior.CloseConnection);
            while (myreader.Read())
            {
                preguntas p = new preguntas();
                p.categoria = myreader["Categoria"].ToString();
                p.pregunta = myreader["Pregunta"].ToString();
                p.respuesta = myreader["Respuesta"].ToString();
                sa.Add(p);
            }
            mycon.Close();
        }
        catch
        {
            mycon.Close();
        }
        return sa;
    }
}